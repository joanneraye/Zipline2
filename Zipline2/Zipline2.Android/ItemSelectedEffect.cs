using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zipline2.Droid;

[assembly:ResolutionGroupName ("Zipline2")]
[assembly:ExportEffect (typeof(ItemSelectedEffect), "ItemSelectedEffect")]
namespace Zipline2.Droid
{
    /// <summary>
    /// NOTE THAT THIS EFFECT DOESN'T WORK, but leaving in case I might
    /// be able to make it work in the future.  Trying to make 
    /// selection of listview item background transparent.
    /// </summary>
    public class ItemSelectedEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            try
            {
                if (args.PropertyName == "SelectedItem")
                {
                    Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }
    }
}