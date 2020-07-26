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
        private const string API_ACCUWEATHER5DAY = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/{0}?apikey={1}&language=es-es&details=false&metric=true";
        private const string API_ACCUWEATHERCURRENT = "http://dataservice.accuweather.com/currentconditions/v1/{0}?apikey={1}&language=es-es";
        private const string API_ACCUWEATHERLOCATION = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete?apikey={0}&q={1}&language=es-es";
        private const string API_KEY = "f8pavAAIIXoxguKpAncmZfBeLSXDLvAk";

        public static async Task<AccuWeatherCurrent> GetAccuWeatherCurrentInfoAsync(string LocationKey) // 307297 Barcelona
        {
            AccuWeatherCurrent result = new AccuWeatherCurrent();
            string url = string.Format(API_ACCUWEATHERCURRENT, LocationKey, API_KEY);
            using (HttpClient client = new HttpClient())
            {
                var resultado = await client.GetAsync(url);
                if (resultado.IsSuccessStatusCode)
                {
                    string content = await resultado.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<AccuWeatherCurrent>>(content).FirstOrDefault();
                }
            }
            return result;
        }
        public static async Task<AccuWeather5Day> GetAccuWeather5DayInfoAsync(string LocationKey) // 307297 Barcelona
        {
            AccuWeather5Day result = new AccuWeather5Day();
            string url = string.Format(API_ACCUWEATHER5DAY, LocationKey, API_KEY);
            using (HttpClient client = new HttpClient()) {
                var resultado = await client.GetAsync(url);
                if (resultado.IsSuccessStatusCode)
                {
                    string content = await resultado.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AccuWeather5Day>(content);
                }
            }
            return result;
        }
        public static async Task<List<AccuWeatherLocation>> GetAccuWeatherLocationInfoAsync(string Query) 
        {
            List<AccuWeatherLocation> result = new List<AccuWeatherLocation>();
            string url = string.Format(API_ACCUWEATHERLOCATION, API_KEY, Query);
            using (HttpClient client = new HttpClient())
            {
                var resultado = await client.GetAsync(url);
                if (resultado.IsSuccessStatusCode)
                {
                    string content = await resultado.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<AccuWeatherLocation>>(content);
                }
            }
            return result;
        }
    }
}