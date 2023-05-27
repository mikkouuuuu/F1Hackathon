using F1Hack_api.Entities;
using Microsoft.EntityFrameworkCore;

public class F1Context : DbContext
{
    public DbSet<Prediction> Predictions { get; set; }
    public DbSet<PredictionGroup> PredictionGroups { get; set; }
    public DbSet<PredictionValues> PredictionValues { get; set; }
    public DbSet<User> Users { get; set; }

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
            .HasOne(p => p.PredictionGroup)
            .WithMany(p => p.Predictions)
            .HasForeignKey(x => x.PredictionGroupId);

        builder.Entity<Prediction>()
            .HasOne(x => x.User)
            .WithMany(x => x.Predictions)
            .HasForeignKey(x => x.UserId);
    }
}