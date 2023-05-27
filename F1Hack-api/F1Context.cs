using F1Hack_api.Entities;
using F1Hack_api.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace F1Hack_api
{
    public class F1Context : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Prediction> Predictions { get; set; }
        public DbSet<PredictionGroup> PredictionGroups { get; set; }
        public DbSet<PredictionValues> PredictionValues { get; set; }

        public F1Context(DbContextOptions<F1Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Prediction>()
                .HasMany(p => p.PredictionValues)
                .WithOne(p => p.Prediction)
                .HasForeignKey(p => p.PredictionId);

            builder.Entity<Prediction>()
                .Navigation(x => x.PredictionValues)
                .AutoInclude();

            builder.Entity<Prediction>()
                .HasOne(p => p.PredictionGroup)
                .WithMany(p => p.Predictions)
                .HasForeignKey(x => x.PredictionGroupId);

            builder.Entity<Prediction>()
                .HasOne(x => x.User)
                .WithMany(x => x.Predictions)
                .HasForeignKey(x => x.UserId);

            builder.Entity<IdentityUserLogin<int>>().HasNoKey();
            builder.Entity<IdentityUserRole<int>>().HasNoKey();
            builder.Entity<IdentityUserToken<int>>().HasNoKey();
        }
    }
}