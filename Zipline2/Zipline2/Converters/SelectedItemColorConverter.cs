using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.Converters
{
    /// <summary>
    /// This converter returns the color of the button background
    /// depending on whether the button is selected or not.
    /// </summary>
    public class SelectedItemColorConverter : IValueConverter
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
                return Xamarin.Forms.Color.Black;
            }
            if (isSelected)
            {
                return Xamarin.Forms.Color.Orange;
            }
            else
            {
                return Xamarin.Forms.Color.Black;
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
            if (currentColor == Xamarin.Forms.Color.Black)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Would love to use this version with parameter to indicate colors, 
        //but cannot figure out how to implement/use it.
        //public class ConversionColorIndicator
        //{
        //    public Color NotSelectedColor { get; set; }
        //    public Color SelectedColor { get; set; }

        //    public ConversionColorIndicator(Color selectedColor, Color notSelectedColor)
        //    {
        //        NotSelectedColor = notSelectedColor;
        //        SelectedColor = selectedColor;
        //    }
        //}

        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (parameter == null || !(parameter is ConversionColorIndicator))
        //    {
        //        return Xamarin.Forms.Color.Black;
        //    }
        //    var colorIndicator = (ConversionColorIndicator)parameter;

        //    bool isSelected;
        //    if (value is bool)
        //    {
        //        isSelected = (bool)value;
        //    }
        //    else
        //    {
        //        return colorIndicator.NotSelectedColor;
        //    }
        //    if (isSelected)
        //    {
        //        return colorIndicator.SelectedColor;
        //    }
        //    else
        //    {
        //        return colorIndicator.NotSelectedColor;
        //    }
        //}

        //public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (parameter == null || !(parameter is ConversionColorIndicator))
        //    {
        //        return false;
        //    }

        //    var colorIndicator = (ConversionColorIndicator)parameter;

        //    Xamarin.Forms.Color currentColor = Color.Black;
        //    if (value is Xamarin.Forms.Color)
        //    {
        //        currentColor = (Xamarin.Forms.Color)value;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    if (currentColor == colorIndicator.NotSelectedColor)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


    }
}
