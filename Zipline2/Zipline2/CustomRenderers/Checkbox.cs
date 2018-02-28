using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.CustomRenderers
{

    //This was copied from: www.grapecity.com/en/blogs/using-a-custom-native-control-with-xamarin-forms-via-a-custom-renderer/
    public class Checkbox : View
    {

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
            propertyName: "IsChecked",
            returnType: typeof(bool),
            declaringType: typeof(Checkbox),
            defaultValue: false
            );

        //public static readonly BindableProperty IsCheckedProperty = 
        //    BindableProperty.Create<Checkbox, bool>(p => p.IsChecked, true,
        //    propertyChanged: (s, o, n) => { (s as Checkbox).OnChecked(new EventArgs()); });
        //public static readonly BindableProperty ColorProperty = 
        //    BindableProperty.Create<Checkbox, Color>(p => p.Color, Color.Default);

        public bool IsChecked
        {
            get
            {
                return (bool)GetValue(IsCheckedProperty);
            }
            set
            {
                if (this.IsChecked != value)
                {
                    this.SetValue(IsCheckedProperty, value);
                }            }
        }

        //public Color Color
        //{
        //    get
        //    {
        //        return (Color)GetValue(ColorProperty);
        //    }
        //    set
        //    {
        //        SetValue(ColorProperty, value);
        //    }
        //}

        public event EventHandler Checked;

        protected virtual void OnChecked(EventArgs e)
        {
            Checked?.Invoke(this, e);
        }
    }
}
