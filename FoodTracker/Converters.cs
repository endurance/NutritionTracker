using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FoodTracker.Converters
{
   public class DoubleToStringConverter : IValueConverter
   {
      public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
      {
         // Do the conversion from bool to visibility
         string converted = System.Convert.ToString(value);
         return converted;
      }

      public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
      {
         // Do the conversion from visibility to bool
         return null;
      }
   }
}
