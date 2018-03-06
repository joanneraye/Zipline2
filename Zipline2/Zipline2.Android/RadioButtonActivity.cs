using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Zipline2.Droid
{
    [Activity(Label = "RadioButtonActivity")]
    public class RadioButtonActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            RadioButton radio1 = FindViewById<RadioButton>(Resource.Id.radio1);
            RadioButton radio2 = FindViewById<RadioButton>(Resource.Id.radio2);

            //radio1.Click += delegate { RadioButtonClick(); };

            // Create your application here
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Toast.MakeText(this, rb.Text, ToastLength.Short).Show();
        }
    }
}