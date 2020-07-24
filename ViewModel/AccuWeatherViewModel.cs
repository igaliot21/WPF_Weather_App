using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WPFWeathreApp.Model;

namespace WPFWeathreApp.ViewModel
{
    public class AccuWeatherViewModel
    {
        private const string API_ACCUWEATHER = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=es-es&details=false&metric=true";
        private const string API_KEY = "f8pavAAIIXoxguKpAncmZfBeLSXDLvAk";
        
        public async Task<AccuWeather> GetAccuWeatherInfoAsync(string LocationKey) // 307297 Barcelona
        {
            AccuWeather result = new AccuWeather();
            string url = string.Format(API_ACCUWEATHER, LocationKey, API_KEY);
            using (HttpClient client = new HttpClient()) {
                var resultado = await client.GetAsync(url);
                if (resultado.IsSuccessStatusCode)
                {
                    string content = await resultado.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AccuWeather>(content);
                }
            }
            return result;
        }
    }
}