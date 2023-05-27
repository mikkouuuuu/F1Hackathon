using F1Hack_api.Entities.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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

        public async Task<IEnumerable<T>> GetDataOfTypeAsync<T>(int season)
        {
            string urlToRequest = string.Empty;
            string jsonTokenToParse = string.Empty;
            if(typeof(T) == typeof(Driver))
            {
                urlToRequest = $"https://ergast.com/api/f1/{season}/drivers.json";
                jsonTokenToParse = "DriverTable";
            }
            var dataJson = await ExecuteQueryAsync(urlToRequest);
            if (!string.IsNullOrEmpty(dataJson))
            {
                var resultObject = new JObject(dataJson);
                var entityJson = resultObject[jsonTokenToParse];
                return entityJson?.ToObject<IEnumerable<T>>();
            }
            return null;
        }
    }
}
