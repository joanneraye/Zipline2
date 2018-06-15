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
        private static Dictionary<ToppingName, Topping> allToppings;
        public static Dictionary<ToppingName, Topping> AllToppings
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
                        if (!DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID) && mod.ID != 50 && mod.ID != 51)
                        {
                            Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
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
            allToppings = new Dictionary<ToppingName, Topping>();
            allToppings.Add(ToppingName.Anchovies, new Topping(ToppingName.Anchovies));
            allToppings.Add(ToppingName.Artichokes, new Topping(ToppingName.Artichokes));
            allToppings.Add(ToppingName.Bacon, new Topping(ToppingName.Bacon));
            allToppings.Add(ToppingName.BananaPeppers, new Topping(ToppingName.BananaPeppers));
            allToppings.Add(ToppingName.Basil, new Topping(ToppingName.Basil));
            allToppings.Add(ToppingName.Beef, new Topping(ToppingName.Beef));
            allToppings.Add(ToppingName.BlackOlives, new Topping(ToppingName.BlackOlives));
            allToppings.Add(ToppingName.Broccoli, new Topping(ToppingName.Broccoli));
            allToppings.Add(ToppingName.Carrots, new Topping(ToppingName.Carrots));
            allToppings.Add(ToppingName.Cheese, new Topping(ToppingName.Cheese));
            allToppings.Add(ToppingName.CrispyCook, new Topping(ToppingName.CrispyCook) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.DAIYA, new Topping(ToppingName.DAIYA) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            allToppings.Add(ToppingName.Deep, new Topping(ToppingName.Deep) { SpecialPricingType = SpecialPricingType.SpecialLogic });
            allToppings.Add(ToppingName.ExtraCheese, new Topping(ToppingName.ExtraCheese));
            allToppings.Add(ToppingName.ExtraMozarellaCalzone, new Topping(ToppingName.ExtraMozarellaCalzone));
            allToppings.Add(ToppingName.ExtraPSauceOS, new Topping(ToppingName.ExtraPSauceOS));
            allToppings.Add(ToppingName.ExtraPSauceOP, new Topping(ToppingName.ExtraPSauceOP));
            allToppings.Add(ToppingName.ExtraRicottaCalzone, new Topping(ToppingName.ExtraRicottaCalzone));
            allToppings.Add(ToppingName.Feta, new Topping(ToppingName.Feta));
            allToppings.Add(ToppingName.Garlic, new Topping(ToppingName.Garlic));
            allToppings.Add(ToppingName.GlutenFreeIndyOnly, new Topping(ToppingName.GlutenFreeIndyOnly) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.GreenOlives, new Topping(ToppingName.GreenOlives));
            allToppings.Add(ToppingName.GreenPeppers, new Topping(ToppingName.GreenPeppers));
            allToppings.Add(ToppingName.HalfMajor, new Topping(ToppingName.HalfMajor) { SpecialPricingType = SpecialPricingType.SpecialLogic });
            allToppings.Add(ToppingName.Jalapenos, new Topping(ToppingName.Jalapenos));
            allToppings.Add(ToppingName.KidCook, new Topping(ToppingName.KidCook) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.LightCook, new Topping(ToppingName.LightCook) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.Meatballs, new Topping(ToppingName.Meatballs));
            allToppings.Add(ToppingName.Mushrooms, new Topping(ToppingName.Mushrooms));
            allToppings.Add(ToppingName.NoCheese, new Topping(ToppingName.NoCheese) { SpecialPricingType = SpecialPricingType.SubtractTopping });
            allToppings.Add(ToppingName.Onion, new Topping(ToppingName.Onion));
            allToppings.Add(ToppingName.PestoTopping, new Topping(ToppingName.PestoTopping));
            allToppings.Add(ToppingName.Pepperoni, new Topping(ToppingName.Pepperoni));
            allToppings.Add(ToppingName.Pineapple, new Topping(ToppingName.Pineapple));
            allToppings.Add(ToppingName.RedOnions, new Topping(ToppingName.RedOnions));
            allToppings.Add(ToppingName.Ricotta, new Topping(ToppingName.Ricotta));
            allToppings.Add(ToppingName.RicottaCalzone, new Topping(ToppingName.RicottaCalzone));
            allToppings.Add(ToppingName.RoastedRedPepper, new Topping(ToppingName.RoastedRedPepper));
            allToppings.Add(ToppingName.Sausage, new Topping(ToppingName.Sausage));
            allToppings.Add(ToppingName.Spinach, new Topping(ToppingName.Spinach));
            allToppings.Add(ToppingName.Steak, new Topping(ToppingName.Steak));
            allToppings.Add(ToppingName.SundriedTomatoes, new Topping(ToppingName.SundriedTomatoes));
            allToppings.Add(ToppingName.Teese, new Topping(ToppingName.Teese) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            allToppings.Add(ToppingName.TempehBBQ, new Topping(ToppingName.TempehBBQ));
            allToppings.Add(ToppingName.TempehOriginal, new Topping(ToppingName.TempehOriginal));
            allToppings.Add(ToppingName.Tomatoes, new Topping(ToppingName.Tomatoes));
            allToppings.Add(ToppingName.Zucchini, new Topping(ToppingName.Zucchini));
            allToppings.Add(ToppingName.LightSauce, new Topping(ToppingName.LightSauce) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.LightMozarella, new Topping(ToppingName.LightMozarella) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.LightRicotta, new Topping(ToppingName.LightRicotta) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.NoButter, new Topping(ToppingName.NoButter) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.NoSauce, new Topping(ToppingName.NoSauce) { SpecialPricingType = SpecialPricingType.Free });
            allToppings.Add(ToppingName.NoMozarella, new Topping(ToppingName.NoMozarella) { SpecialPricingType = SpecialPricingType.SubtractTopping });
            allToppings.Add(ToppingName.NoRicotta, new Topping(ToppingName.NoRicotta) { SpecialPricingType = SpecialPricingType.SubtractTopping });
           
        }
    }
}
