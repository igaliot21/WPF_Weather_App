using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.TextFormatting;
using WPFWeathreApp.Model;
using WPFWeathreApp.ViewModel;

namespace WPFWeathreApp.ViewModel
{
    public class WeatherViewModel
    {
        private string query;
        private AccuWeatherLocation accuweatherlocation;
        public AccuWeatherCurrent accuWeatherCurrent { get; set; }
        public AccuWeather5Day accuWeather5Day { get; set; }
        public AccuWeatherLocation accuWeatherLocation {
            get { return this.accuweatherlocation; }
            set {
                this.accuweatherlocation = value;
                GetWeather();
            } 
        }

        public string Query {
            get { return this.query;  }
            set { 
                this.query = value;
                GetCities();
            } 
        }
        public ObservableCollection<AccuWeatherLocation> Cities { get; set; }
        public WeatherViewModel()
        {
            accuWeatherCurrent = new AccuWeatherCurrent();
            accuWeather5Day = new AccuWeather5Day();
            accuWeatherLocation = new AccuWeatherLocation();
            Cities = new ObservableCollection<AccuWeatherLocation>();
        }
        private async void GetCities(){
            var items = await AccuWeatherViewModel.GetAccuWeatherLocationInfoAsync(this.query);
            Cities.Clear();
            foreach (var item in items) {
                Cities.Add(item);
            }
        }
        private async void GetWeather()
        {
            var varAccuWeatherCurrent = await AccuWeatherViewModel.GetAccuWeatherCurrentInfoAsync(this.accuweatherlocation.Key);
            this.accuWeatherCurrent.LocalObservationDateTime = varAccuWeatherCurrent.LocalObservationDateTime;
            this.accuWeatherCurrent.Temperature = varAccuWeatherCurrent.Temperature;
            this.accuWeatherCurrent.WeatherText = varAccuWeatherCurrent.WeatherText;
            
            var varAccuWeather5Day = await AccuWeatherViewModel.GetAccuWeather5DayInfoAsync(this.accuweatherlocation.Key);
            this.accuWeather5Day.DailyForecasts = varAccuWeather5Day.DailyForecasts;
        }
    }
}
