using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.Pages;
using Zipline2.Data;
using Zipline2.ConnectedServices;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.WcfRemote;
using Staunch.POS.Classes;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2
{
    
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            //for now....
            //Zipline2.Models.User joanne = new Zipline2.Models.User("Joanne", true, "8011");
            //Zipline2.Models.User satch = new Zipline2.Models.User("Satch", true, "1168");
            //Zipline2.Models.User jim = new Zipline2.Models.User("Jim", true, "4321");
            //Users.Instance.AddNewUser(joanne);
            //Users.Instance.AddNewUser(satch);
            //Users.Instance.AddNewUser(jim);
            Zipline2.Data.Tables.LoadInitialTableData();
            Zipline2.Data.MenuFood.LoadInitialPizzaToppings();
            Zipline2.Data.MenuFood.LoadInitialSaladToppings();

            //These do not need to process on a different thread because they must be processed
            //before the UI can be displayed.
            if (WcfServicesProxy.Instance.ServiceCallConfig != WcfServicesProxy.ServiceCallConfigType.AllServiceCallsOff)
            {
                LoadMenuFromServer();
               //LoadMenuFromServerAsync();

                DataBaseDictionaries.LoadToppingsFromServer();
                //LoadToppingsFromServerAsync();

                LoadTablesFromServer();
                //LoadTablesFromServerAsync();
            }
           

            LoadDrinks();

            //TODO:  When and how to close services?

            MainPage = new MainMasterDetailPage();
            //var assembly = typeof(App).GetType().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("Found resource: " + res);
            //}
        }

        private void LoadMenuFromServer()
        {
            WcfServicesProxy.Instance.GetMenu();
        }


        private void LoadTablesFromServer()
        {
            WcfServicesProxy.Instance.GetTables();
        }

        async private void LoadTablesFromServerAsync()
        {
            await WcfServicesProxy.Instance.GetTablesAsync();
        }

        async private void LoadMenuFromServerAsync()
        {
            await WcfServicesProxy.Instance.GetMenuAsync();
        }

        

        private void LoadDrinks()
        {
            MenuDrinks.CreateAllDrinks();
        }

        
        public void LoadMenuPizzaPage()
        {
            var currentMainPage = (Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }

        protected override void OnStart()
        {
            //Prices.WritePricesToJsonFile();
            //Prices.ReadPricesFromJsonFile();
            //Somewhere load users file....
        }

        protected override void OnSleep()
        {
            //save data and app state
            //Save time so that when resume, if more than 30 minutes, can 
            //require new login (assuming can save the current user info)...
        }

        protected override void OnResume()
        {
            //when wakes up from idle state...refresh screen if data has changed from when it 
            //went to sleep

            //Maybe just display tables screen?
        }

        
    }
}
