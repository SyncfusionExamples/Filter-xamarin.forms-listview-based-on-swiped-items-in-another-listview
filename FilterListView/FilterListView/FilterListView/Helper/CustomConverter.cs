using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Swiping
{
    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object eventArgs = null;

            if (value is ScrollStateChangedEventArgs)
                eventArgs = value as ScrollStateChangedEventArgs;
            else if (value is Syncfusion.ListView.XForms.ItemTappedEventArgs)
                eventArgs = value as Syncfusion.ListView.XForms.ItemTappedEventArgs;

            return eventArgs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
