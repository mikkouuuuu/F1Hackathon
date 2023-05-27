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
            if(typeof(T) == typeof(Driver))
            {
                var dataJson = await ExecuteQueryAsync($"https://ergast.com/api/f1/{season}/drivers.json");
                if (!string.IsNullOrEmpty(dataJson))
                {
                    var resultObject = JObject.Parse(dataJson);
                    var entityJson = resultObject["MRData"]["DriverTable"]["Drivers"];
                    return entityJson?.ToObject<IEnumerable<T>>();
                }
            }
            return null;
        }
    }
}
