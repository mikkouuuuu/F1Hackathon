using F1Hack_api;
using F1Hack_api.Entities.Identity;
using FIHack.Scraper.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FIHack.Scraper
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var season = Int32.Parse(args[0]);
            var service = new ScraperService();
            Console.WriteLine("Fetching Drivers...");
            var drivers = await service.GetDataOfTypeAsync<Driver>(season);
            var addedAmount = AddEntitiesToDatabase(drivers);
            Console.WriteLine($"Added {addedAmount} new Drivers.");
        }

        private static async Task<int> AddEntitiesToDatabase<T>(IEnumerable<T> entities)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<F1Context>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("F1HackDB"));
            using (var context = new F1Context(optionsBuilder.Options))
            {
                await context.AddRangeAsync(entities);
                return await context.SaveChangesAsync();
            }
        }
    }
}