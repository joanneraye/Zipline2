using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Zipline2;
using Zipline2.ConnectedServices;
using Zipline2.Android.Services;
using Android;

[assembly: Xamarin.Forms.Dependency(typeof(WaiterClient))]
namespace Zipline2.Android
{
    [Activity(Label = "Zipline2", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TODO:  WHY DON'T THESE WORK ANYMORE???
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;


            //Commented out because can't find Xamarin Insights Nuget package.
            //Insights.HasPendingCrashReport += (sender, isStartupCrash) =>
            //{
            //    if (isStartupCrash)
            //    {
            //        Insights.PurgePendingCrashReports().Wait();
            //    }
            //};
            //Insights.Initialize("Your API Key");

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

            //TODO:  WHY DOESN'T THIS WORK ANYMORE???????
            //FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar);

            //string dbPath = FileAccessHelper.GetLocalFilePath("orders.db3");

            //LoadApplication(new App(dbPath));
            LoadApplication(new App());
        }
    }
}

