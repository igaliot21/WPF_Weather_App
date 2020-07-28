using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WPFWeathreApp.ViewModel.Converters
{
    public class TempToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tempString = "It's OK";
            double actualTemp = (double)value;

            if (actualTemp > 25) tempString = "Hot!";
            else if (actualTemp < 15) tempString = "Cold!";

            return tempString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
