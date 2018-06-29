using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Zipline2.iOS.Services;

[assembly: Xamarin.Forms.Dependency(typeof(WaiterClient))]
namespace Zipline2.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            //ButtonCircleRenderer.Init();
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
