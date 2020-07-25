using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFWeathreApp.Model
{
    public class AccuWeatherLocation : INotifyPropertyChanged
    {
        private string key;
        private string localizedname;
        private Country country;
        public string Key {
            get { return this.key; }
            set {
                this.key = value;
                OnPropertyChange("Key");
            }
        }
        public string LocalizedName {
           get { return this.localizedname;}
            set {
                this.localizedname = value;
                OnPropertyChange("LocalizedName");
            }  
        }
        public Country Country {
            get { return this.country; }
            set {
                this.country = value;
                OnPropertyChange("Country");
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class Country : INotifyPropertyChanged
    {
        private string localizedname;
        public string LocalizedName{
            get { return this.localizedname; }
            set{
                this.localizedname = value;
                OnPropertyChange("LocalizedName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
