using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Support.V4.Content.Res;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Zipline2.CustomControls;

namespace Zipline2.Droid.Renderer
{
    class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            //I copied this class but couldn't get the next line right...
            //Control.Background = ResourcesCompat.GetDrawable(Resource.Drawable.customPicker);
            //this.Control.Background = Forms.Context.GetDrawable(Resource.Drawable.customPicker);
            if (e.OldElement != null || e.NewElement != null)
            {
                var customPicker = e.NewElement as CustomPicker;
                Control?.SetPadding(20, 0, 0, 0);
                Control.TextSize *= (customPicker.FontSize * 0.01f);
            }

        }
    }
}