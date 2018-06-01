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
using Zipline2.BusinessLogic.WcfRemote;
using Staunch.POS.Classes;

namespace Zipline2
{
    
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //for now....
            Zipline2.Models.User joanne = new Zipline2.Models.User("Joanne", true, "8011");
            Zipline2.Models.User satch = new Zipline2.Models.User("Satch", true, "1168");
            Zipline2.Models.User jim = new Zipline2.Models.User("Jim", true, "4321");
            Users.Instance.AddNewUser(joanne);
            Users.Instance.AddNewUser(satch);
            Users.Instance.AddNewUser(jim);
            Tables.LoadInitialTableData();
            Toppings.LoadInitialToppings();

            LoadMenuFromServer();
            LoadToppingsFromServer();
            LoadDrinks();

            //TODO:  When and how to close services?

            MainPage = new MainMasterDetailPage();
            //var assembly = typeof(App).GetType().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("Found resource: " + res);
            //}
        }

        async private void LoadMenuFromServer()
        {
            await WcfServicesProxy.Instance.GetMenuAsync();
        }

        async private void LoadToppingsFromServer()
        {
            //TODO:  Not doing anything with this dictionary yet.
            DataBaseDictionaries.PizzaToppingsDictionary = new Dictionary<decimal, DBModifier>();
            DBModGroup[] modgroups = await WcfServicesProxy.Instance.GetToppingsAsync();
            foreach (var modgroup in modgroups)
            {
                foreach (var mod in modgroup.SelectionList)
                {
                    if (!DataBaseDictionaries.PizzaToppingsDictionary.ContainsKey(mod.ID))
                    {
                        DataBaseDictionaries.PizzaToppingsDictionary.Add(mod.ID, mod);
                        if (!Toppings.DbIdToppingDictionary.ContainsKey(mod.ID))
                        {
                            Console.WriteLine("TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
                        }
                    }
                }
            }
        }

        private void LoadDrinks()
        {
            Drinks.CreateAllDrinks();
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
