using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.CustomControls
{
    public class CustomPicker : Picker
    {
        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(Int32), typeof(CustomPicker),
                10, BindingMode.Default);
        public Int32 FontSize
        {
            get
            {
                return (Int32)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }
    }
}
