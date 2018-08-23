using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Foundation;
using Staunch.POS.Classes;
using UIKit;
using Zipline2.ConnectedServices;
using Zipline2.iOS.Services;

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

            App.ScreenHeight = (int)UIScreen.MainScreen.Bounds.Height;
            App.ScreenWidth = (int)UIScreen.MainScreen.Bounds.Width;

            UINavigationBar.Appearance.BarTintColor = UIColor.Black;

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private void LoadMenu()
        {
        //    Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.MenuDictionary = WaiterClient.GetMenu();
            
        }

        private void LoadTables()
        {
            //Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.DbTablesDictionary = new Dictionary<decimal, DBTable>();
            //List<DBTable> tablesSection1 = WaiterClient.GetTablesForSection(1M);
            //foreach (var item1 in tablesSection1)
            //{
            //    Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.DbTablesDictionary.Add(item1.ID, item1);
            //}
            //List<DBTable> tablesSection2 = WaiterClient.GetTablesForSection(2M);
            //foreach (var item2 in tablesSection2)
            //{
            //    Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.DbTablesDictionary.Add(item2.ID, item2);
            //}
        }

        private void LoadToppings()
        {
            //Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.PizzaToppingsDictionary = new Dictionary<decimal, DBModifier>();
            //List<DBModGroup> modgroups = WaiterClient.GetAllMods(57M, 0M);
            //foreach (var modgroup in modgroups)
            //{
            //    foreach (var mod in modgroup.SelectionList)
            //    {
            //        if (!Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.PizzaToppingsDictionary.ContainsKey(mod.ID))
            //        {
            //            Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.PizzaToppingsDictionary.Add(mod.ID, mod);
            //            if (!Zipline2.BusinessLogic.WcfRemote.DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID) && mod.ID != 50 && mod.ID != 51)
            //            {
            //                Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
            //            }
            //        }
            //    }
            //}
        }
    }
}
