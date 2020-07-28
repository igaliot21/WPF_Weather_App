using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFWeathreApp.Model;

namespace WPFWeathreApp.ViewModel.Commands
{
    public class RefreshCommand : ICommand
    {
        public WeatherViewModel VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public RefreshCommand(WeatherViewModel vm){
            this.VM = vm;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter != null) {
                var WeatherCurrent = parameter as AccuWeatherCurrent;
                if (WeatherCurrent.Temperature.Metric.Value != 10) return false;
                else return true;
            }
            return false;
        }
        public void Execute(object parameter)
        {
            VM.GetWeather();
        }
    }
}
