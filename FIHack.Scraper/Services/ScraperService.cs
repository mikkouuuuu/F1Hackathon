using F1Hack_api.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIHack.Scraper.Services
{
    internal class ScraperService
    {
        private async Task<string> ExecuteQueryAsync(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://ergast.com/api/f1/");
                return await client.GetStringAsync(url);
            }
        }

        public async Task GetDataOfTypeAsync<T>(int season)
        {
            string urlToRequest = string.Empty;
            string jsonTokenToParse = string.Empty;
            switch typeof(T)
            {
                case Type t when t == typeof(Driver):
                    urlToRequest = $"https://ergast.com/api/f1/{season}/drivers.json";
                    jsonTokenToParse = "DriverTable";
                    break;
                default:

            };
            var dataJson = await ExecuteQueryAsync(urlToRequest);
        }
    }
}
