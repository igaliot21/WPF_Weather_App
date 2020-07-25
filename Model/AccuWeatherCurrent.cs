using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFWeathreApp.Model
{
    public class AccuWeatherCurrent : INotifyPropertyChanged
    {
        private DateTime localobservationdatetime;
        private string weathertext;
        private TemperatureCurrent temperature;
        public DateTime LocalObservationDateTime {
            get { return this.localobservationdatetime; }
            set {
                this.localobservationdatetime = value;
                OnPropertyChange("LocalObservationDateTime");
            } 
        }
        public string WeatherText {
            get { return this.weathertext; }
            set {
                this.weathertext = value;
                OnPropertyChange("WeatherText");
            } 
        }
        public TemperatureCurrent Temperature {
            get { return this.temperature; }
            set {
                this.temperature = value;
                OnPropertyChange("Temperature");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class TemperatureCurrent : INotifyPropertyChanged
    {
        private Metric metric;
        public Metric Metric {
            get { return this.metric; }
            set {
                this.metric = value;
                OnPropertyChange("Metric");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Metric : INotifyPropertyChanged
    {
        private double value;
        public double Value{
            get { return this.value; }
            set{
                this.value = value;
                OnPropertyChange("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName){
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
