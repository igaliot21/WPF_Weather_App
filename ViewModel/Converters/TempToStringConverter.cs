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
            double actualTemp = (double)value;
            string tempString = $"It's OK ({actualTemp.ToString()})";

            if (actualTemp > 25) tempString = $"Hot! ({actualTemp.ToString()})";
            else if (actualTemp < 15) tempString = $"Cold! ({actualTemp.ToString()})";

            return tempString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
