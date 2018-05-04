using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.Converters
{
    /// <summary>
    /// This converter returns the color of the button text
    /// depending on whether the button is selected or not.
    /// </summary>
    public class SelectedDrinkColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSelected;
            if (value is bool)
            {
                isSelected = (bool)value;
            }
            else
            {
                return Xamarin.Forms.Color.DimGray;
            }
            if (isSelected)
            {
                return Xamarin.Forms.Color.White;
            }
            else
            {
                return Xamarin.Forms.Color.DimGray;
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
            if (currentColor == Xamarin.Forms.Color.DimGray)
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
