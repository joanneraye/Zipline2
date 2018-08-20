using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.Converters
{
    /// <summary>
    /// This converter returns the color of the buttonorder item text
    /// depending on whether item sent to the kitchen or not.
    /// </summary>
    public class SentOrderItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool orderWasSent;
            if (value is bool)
            {
                orderWasSent = (bool)value;
            }
            else
            {
                return Xamarin.Forms.Color.Red;
            }
            if (orderWasSent)
            {
                return Xamarin.Forms.Color.Green;
            }
            else
            {
                return Xamarin.Forms.Color.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Xamarin.Forms.Color currentColor;
            if (value is Xamarin.Forms.Color)
            {
                currentColor = (Xamarin.Forms.Color)value;
            }
            else
            {
                return null;
            }
            if (currentColor == Xamarin.Forms.Color.Red)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
