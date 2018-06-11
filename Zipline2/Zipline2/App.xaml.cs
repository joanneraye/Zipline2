using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.Pages;
using Zipline2.BusinessLogic;
using Zipline2.ConnectedServices;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.WcfRemote;
using Staunch.POS.Classes;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2
{
    
    public partial class App : Application
    {
        private static List<Topping> allToppings;
        public static List<Topping> AllToppings
        {
            get
            {
                if (allToppings == null || allToppings.Count == 0)
                {
                    LoadInitialToppings();
                }
                return allToppings;
            }
        }
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
            LoadInitialToppings();

            LoadMenuFromServerSync();
            LoadToppingsFromServerAsync();
            LoadTablesFromServerSync();
            LoadDrinks();

            //TODO:  When and how to close services?

            MainPage = new MainMasterDetailPage();
            //var assembly = typeof(App).GetType().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("Found resource: " + res);
            //}
        }

        private void LoadMenuFromServerSync()
        {
            WcfServicesProxy.Instance.GetMenuSync();
        }
        

        private void LoadTablesFromServerSync()
        {
            WcfServicesProxy.Instance.GetTablesSync();
        }

        async private void LoadMenuFromServerAsync()
        {
            await WcfServicesProxy.Instance.GetMenuAsync();
        }

        async private void LoadToppingsFromServerAsync()
        {
            //TODO:  Not doing anything with this dictionary yet.
            DataBaseDictionaries.PizzaToppingsDictionary = new Dictionary<decimal, DBModifier>();
            List<DBModGroup> modgroups = await WcfServicesProxy.Instance.GetToppingsAsync();
            foreach (var modgroup in modgroups)
            {
                foreach (var mod in modgroup.SelectionList)
                {
                    if (!DataBaseDictionaries.PizzaToppingsDictionary.ContainsKey(mod.ID))
                    {
                        DataBaseDictionaries.PizzaToppingsDictionary.Add(mod.ID, mod);
                        if (!DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
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

        public static void LoadInitialToppings()
        {
            allToppings = new List<Topping>()
            {
                new Topping(ToppingName.Anchovies),
                new Topping(ToppingName.Artichokes),
                new Topping(ToppingName.Bacon),
                new Topping(ToppingName.BananaPeppers),
                new Topping(ToppingName.Basil),
                new Topping(ToppingName.Beef),
                new Topping(ToppingName.BlackOlives),
                new Topping(ToppingName.Broccoli),
                new Topping(ToppingName.Carrots),
                new Topping(ToppingName.Cheese),
                new Topping(ToppingName.DAIYA),
                new Topping(ToppingName.Deep) {SpecialPricingType = SpecialPricingType.Unknown},
                new Topping(ToppingName.ExtraCheese),
                new Topping(ToppingName.ExtraMozarellaCalzone),
                new Topping(ToppingName.ExtraPSauceOS) { SpecialPricingType = SpecialPricingType.AddHalfTopping },
                new Topping(ToppingName.ExtraPSauceOP) { SpecialPricingType = SpecialPricingType.AddHalfTopping },
                new Topping(ToppingName.ExtraRicottaCalzone),
                new Topping(ToppingName.Feta),
                new Topping(ToppingName.Garlic) ,
                new Topping(ToppingName.GreenOlives),
                new Topping(ToppingName.GreenPeppers),
                new Topping(ToppingName.HalfMajor)
                            { ToppingWholeHalf = ToppingWholeHalf.HalfA },
                new Topping(ToppingName.Jalapenos),
                new Topping(ToppingName.Meatballs),
                new Topping(ToppingName.Mushrooms),
                new Topping(ToppingName.NoCheese) {SpecialPricingType = SpecialPricingType.GetExtraTopping},
                new Topping(ToppingName.Onion),
                new Topping(ToppingName.PestoTopping) ,
                new Topping(ToppingName.Pepperoni),
                new Topping(ToppingName.Pineapple),
                new Topping(ToppingName.RedOnions),
                new Topping(ToppingName.Ricotta),
                new Topping(ToppingName.RoastedRedPepper),
                new Topping(ToppingName.Sausage),
                new Topping(ToppingName.Spinach),
                new Topping(ToppingName.Steak),
                new Topping(ToppingName.SundriedTomatoes),
                new Topping(ToppingName.Teese) {SpecialPricingType = SpecialPricingType.DoubleTopping},
                new Topping(ToppingName.TempehBBQ),
                new Topping(ToppingName.TempehOriginal),
                new Topping(ToppingName.Tomatoes),
                new Topping(ToppingName.Zucchini),
                new Topping(ToppingName.LightSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightRicotta) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoButter) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoRicotta) {SpecialPricingType = SpecialPricingType.SubtractTopping}
            };
        }
    }
}
