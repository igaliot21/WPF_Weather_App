using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWeathreApp.Model
{
    public class AccuWeather5Day : INotifyPropertyChanged {
        private IList<DailyForecast> dailyForecasts;
        public IList<DailyForecast> DailyForecasts {
            get { return this.dailyForecasts; }
            set {
                this.dailyForecasts = value;
                OnPropertyChange("DailyForecasts");
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class DailyForecast : INotifyPropertyChanged{
        private DateTime date;
        private Temperature temperature;
        public DateTime Date {
            get { return this.date; }
            set {
                this.date = value;
                OnPropertyChange("Date");
            }
        }
        public Temperature Temperature {
            get { return this.temperature; }
            set {
                this.temperature = value;
                OnPropertyChange("Temperature");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName){
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Temperature : INotifyPropertyChanged{
        private Minimum minimum;
        private Maximum maximum;
        public Minimum Minimum {
            get { return this.minimum; }
            set {
                this.minimum = value;
                OnPropertyChange("Minimum");
            }
        }
        public Maximum Maximum {
            get { return this.maximum;}
            set {
                this.maximum = value;
                OnPropertyChange("Maximum");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName){
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Minimum : INotifyPropertyChanged{
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
    public class Maximum : INotifyPropertyChanged{
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
