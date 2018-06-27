using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Foundation;
using Staunch.POS.Classes;
using UIKit;
using Zipline2.ConnectedServices;

namespace Zipline2.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //string dbPath = FileAccessHelper.GetLocalFilePath("orders.db3");
            //LoadApplication(new App(dbPath));

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            FormsPlugin.Iconize.iOS.IconControls.Init();


            //waiterClient = new PosServiceClient(
            //         new BasicHttpBinding(),
            //         new EndpointAddress("http://192.168.1.26/WP7Waiter/POServiceHost.svc"));
            //waiterClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);

            //checkClient = new CheckHostClient(
            //     new BasicHttpBinding(),
            //     new EndpointAddress("http://192.168.1.26/CheckHost/CheckHost.svc"));
            //checkClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);

            //ChannelFactory<IPosService> WaiterClientChannelFactory = new ChannelFactory<IPosService>(
            //    new BasicHttpBinding(), 
            //    new EndpointAddress("http://192.168.1.26/WP7Waiter/POServiceHost.svc"));

            //IPosService waiterclient = WaiterClientChannelFactory.CreateChannel();
            //DBUser user = waiterclient.GetUser("8011");


            //ChannelFactory<Zipline2.ConnectedServices.ICheckHost> CheckClientChannelFactory = new ChannelFactory<ICheckHost>(
            //    new BasicHttpBinding(),
            //    new EndpointAddress("http://192.168.1.26/CheckHost/CheckHost.svc"));

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
