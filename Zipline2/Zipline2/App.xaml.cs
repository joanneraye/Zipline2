using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.Pages;
using Zipline2.BusinessLogic;
using Zipline2.Connected_Services;
using System.Threading.Tasks;

namespace Zipline2
{
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //for now....
            User joanne = new User("Joanne", true, "8011");
            User satch = new User("Satch", true, "1168");
            User jim = new User("Jim", true, "4321");
            Users.Instance.AddNewUser(joanne);
            Users.Instance.AddNewUser(satch);
            Users.Instance.AddNewUser(jim);
            Tables.LoadInitialTableData();
            Toppings.LoadInitialToppings();

            LoadMenu();

            //TODO:  When and how to close services?

            MainPage = new MainMasterDetailPage();
            //var assembly = typeof(App).GetType().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("Found resource: " + res);
            //}
        }

        async private void LoadMenu()
        {
            await WcfServicesProxy.Instance.GetMenuAsync();
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
