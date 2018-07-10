﻿using System;
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
        private static Dictionary<ToppingName, Topping> pizzaToppings;
        public static Dictionary<ToppingName, Topping> PizzaToppings
        {
            get
            {
                if (pizzaToppings == null || pizzaToppings.Count == 0)
                {
                    LoadInitialPizzaToppings();
                }
                return pizzaToppings;
            }
        }

        private static Dictionary<ToppingName, Topping> saladToppings;
        public static Dictionary<ToppingName, Topping> SaladToppings
        {
            get
            {
                if (saladToppings == null || saladToppings.Count == 0)
                {
                    LoadInitialSaladToppings();
                }
                return saladToppings;
            }
        }
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
            Tables.LoadInitialTableData();
            LoadInitialPizzaToppings();
            LoadInitialSaladToppings();

            //These do not need to process on a different thread because they must be processed
            //before the UI can be displayed.
            if (WcfServicesProxy.Instance.ServiceCallConfig != WcfServicesProxy.ServiceCallConfigType.AllServiceCallsOff)
            {
                LoadMenuFromServer();
                LoadToppingsFromServer();
                LoadTablesFromServer();
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

        //async private void LoadTablesFromServerAsync()
        //{
        //    await WcfServicesProxy.Instance.GetTablesAsync();
        //}

        //async private void LoadMenuFromServerAsync()
        //{
        //    await WcfServicesProxy.Instance.GetMenuAsync();
        //}

        //async private void LoadToppingsFromServerAsync()
        //{
        //    DataBaseDictionaries.PizzaToppingsDictionary = new Dictionary<decimal, DBModifier>();
        //    List<DBModGroup> modgroups = await WcfServicesProxy.Instance.GetToppingsAsync();
        //    foreach (var modgroup in modgroups)
        //    {
        //        foreach (var mod in modgroup.SelectionList)
        //        {
        //            if (!DataBaseDictionaries.PizzaToppingsDictionary.ContainsKey(mod.ID))
        //            {
        //                DataBaseDictionaries.PizzaToppingsDictionary.Add(mod.ID, mod);
        //                if (!DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID) && mod.ID != 50 && mod.ID != 51)
        //                {
        //                    Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
        //                }
        //            }
        //        }
        //    }
        //}

        private void LoadToppingsFromServer()
        {
            DataBaseDictionaries.PizzaToppingsDictionary = new Dictionary<decimal, DBModifier>();
            List<DBModGroup> modgroups = WcfServicesProxy.Instance.GetPizzaToppings();
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

            DataBaseDictionaries.SaladToppingsDictionary = new Dictionary<decimal, DBModifier>();
            List<DBModGroup> modgroups2 = WcfServicesProxy.Instance.GetSaladToppings();
            foreach (var modgroup in modgroups2)
            {
                foreach (var mod in modgroup.SelectionList)
                {
                    if (!DataBaseDictionaries.SaladToppingsDictionary.ContainsKey(mod.ID))
                    {
                        DataBaseDictionaries.SaladToppingsDictionary.Add(mod.ID, mod);
                        //if (!DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID) && mod.ID != 50 && mod.ID != 51)
                        //{
                        //    Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
                        //}
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

        public static void LoadInitialPizzaToppings()
        {
            pizzaToppings = new Dictionary<ToppingName, Topping>();
            pizzaToppings.Add(ToppingName.Anchovies, new Topping(ToppingName.Anchovies));
            pizzaToppings.Add(ToppingName.Artichokes, new Topping(ToppingName.Artichokes));
            pizzaToppings.Add(ToppingName.Bacon, new Topping(ToppingName.Bacon));
            pizzaToppings.Add(ToppingName.BananaPeppers, new Topping(ToppingName.BananaPeppers));
            pizzaToppings.Add(ToppingName.Basil, new Topping(ToppingName.Basil));
            pizzaToppings.Add(ToppingName.Beef, new Topping(ToppingName.Beef));
            pizzaToppings.Add(ToppingName.BlackOlives, new Topping(ToppingName.BlackOlives));
            pizzaToppings.Add(ToppingName.Broccoli, new Topping(ToppingName.Broccoli));
            pizzaToppings.Add(ToppingName.Carrots, new Topping(ToppingName.Carrots));
            pizzaToppings.Add(ToppingName.Cheese, new Topping(ToppingName.Cheese));
            pizzaToppings.Add(ToppingName.CrispyCook, new Topping(ToppingName.CrispyCook) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.DAIYA, new Topping(ToppingName.DAIYA) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            pizzaToppings.Add(ToppingName.Deep, new Topping(ToppingName.Deep) { SpecialPricingType = SpecialPricingType.SpecialLogic });
            pizzaToppings.Add(ToppingName.ExtraCheese, new Topping(ToppingName.ExtraCheese));
            pizzaToppings.Add(ToppingName.ExtraMozarellaCalzone, new Topping(ToppingName.ExtraMozarellaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.ExtraPSauceOS, new Topping(ToppingName.ExtraPSauceOS));
            pizzaToppings.Add(ToppingName.ExtraPSauceOP, new Topping(ToppingName.ExtraPSauceOP));
            pizzaToppings.Add(ToppingName.ExtraRicottaCalzone, new Topping(ToppingName.ExtraRicottaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.Feta, new Topping(ToppingName.Feta));
            pizzaToppings.Add(ToppingName.Garlic, new Topping(ToppingName.Garlic));
            pizzaToppings.Add(ToppingName.GlutenFreeIndyOnly, new Topping(ToppingName.GlutenFreeIndyOnly) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.GreenOlives, new Topping(ToppingName.GreenOlives));
            pizzaToppings.Add(ToppingName.GreenPeppers, new Topping(ToppingName.GreenPeppers));
            pizzaToppings.Add(ToppingName.HalfMajor, new Topping(ToppingName.HalfMajor) { SpecialPricingType = SpecialPricingType.SpecialLogic });
            pizzaToppings.Add(ToppingName.Jalapenos, new Topping(ToppingName.Jalapenos));
            pizzaToppings.Add(ToppingName.KidCook, new Topping(ToppingName.KidCook) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightCook, new Topping(ToppingName.LightCook) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightSauce, new Topping(ToppingName.LightSauce) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightMozarella, new Topping(ToppingName.LightMozarella) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightRicotta, new Topping(ToppingName.LightRicotta) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.Meatballs, new Topping(ToppingName.Meatballs));
            pizzaToppings.Add(ToppingName.Mushrooms, new Topping(ToppingName.Mushrooms));
            pizzaToppings.Add(ToppingName.NoButter, new Topping(ToppingName.NoButter) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.NoCheese, new Topping(ToppingName.NoCheese) { SpecialPricingType = SpecialPricingType.SubtractTopping });
            pizzaToppings.Add(ToppingName.NoMozarella, new Topping(ToppingName.NoMozarella) { SpecialPricingType = SpecialPricingType.SubtractTopping, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.NoRicotta, new Topping(ToppingName.NoRicotta) { SpecialPricingType = SpecialPricingType.SubtractTopping, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.NoSauce, new Topping(ToppingName.NoSauce) { SpecialPricingType = SpecialPricingType.Free });            
            pizzaToppings.Add(ToppingName.Onion, new Topping(ToppingName.Onion));
            pizzaToppings.Add(ToppingName.PestoTopping, new Topping(ToppingName.PestoTopping));
            pizzaToppings.Add(ToppingName.Pepperoni, new Topping(ToppingName.Pepperoni));
            pizzaToppings.Add(ToppingName.Pineapple, new Topping(ToppingName.Pineapple));
            pizzaToppings.Add(ToppingName.RedOnions, new Topping(ToppingName.RedOnions));
            pizzaToppings.Add(ToppingName.Ricotta, new Topping(ToppingName.Ricotta) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.RicottaCalzone, new Topping(ToppingName.RicottaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.RoastedRedPepper, new Topping(ToppingName.RoastedRedPepper));
            pizzaToppings.Add(ToppingName.Sausage, new Topping(ToppingName.Sausage));
            pizzaToppings.Add(ToppingName.Spinach, new Topping(ToppingName.Spinach));
            pizzaToppings.Add(ToppingName.Steak, new Topping(ToppingName.Steak));
            pizzaToppings.Add(ToppingName.SundriedTomatoes, new Topping(ToppingName.SundriedTomatoes));
            pizzaToppings.Add(ToppingName.Teese, new Topping(ToppingName.Teese) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            pizzaToppings.Add(ToppingName.TempehBBQ, new Topping(ToppingName.TempehBBQ));
            pizzaToppings.Add(ToppingName.TempehOriginal, new Topping(ToppingName.TempehOriginal));
            pizzaToppings.Add(ToppingName.Tomatoes, new Topping(ToppingName.Tomatoes));
            pizzaToppings.Add(ToppingName.Zucchini, new Topping(ToppingName.Zucchini));
        }

        public static void LoadInitialSaladToppings()
        {

            saladToppings = new Dictionary<ToppingName, Topping>();
            saladToppings.Add(ToppingName.FiftyCentsUpcharge, new Topping(ToppingName.FiftyCentsUpcharge) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = .50M });
            saladToppings.Add(ToppingName.ExtraCheese, new Topping(ToppingName.ExtraCheese) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = .50M  });
            saladToppings.Add(ToppingName.ExtraDressingOnSide, new Topping(ToppingName.ExtraDressingOnSide) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = 1.50M });
            saladToppings.Add(ToppingName.Feta, new Topping(ToppingName.Feta) { ForPizza = false, ForSalad = true });
            saladToppings.Add(ToppingName.Ham, new Topping(ToppingName.Ham) { ForPizza = false, ForSalad = true });
            saladToppings.Add(ToppingName.Almonds, new Topping(ToppingName.Almonds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Apples, new Topping(ToppingName.Apples) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Carrots, new Topping(ToppingName.Carrots) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Cheese, new Topping(ToppingName.Cheese) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Cucumbers, new Topping(ToppingName.Cucumbers) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.DressingOnSide, new Topping(ToppingName.DressingOnSide) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Joiner, new Topping(ToppingName.Joiner) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Lettuce, new Topping(ToppingName.Lettuce) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoDressing, new Topping(ToppingName.NoDressing) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoNutsNoSeeds, new Topping(ToppingName.NoNutsNoSeeds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoNutsSeedsOk, new Topping(ToppingName.NoNutsSeedsOk) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Onion, new Topping(ToppingName.Onion) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.OutFirst, new Topping(ToppingName.OutFirst) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.PecansWalnuts, new Topping(ToppingName.PecansWalnuts) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Seeds, new Topping(ToppingName.Seeds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.TakeoutBring2Table, new Topping(ToppingName.TakeoutBring2Table) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.TakeoutKeepInKitch, new Topping(ToppingName.TakeoutKeepInKitch) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Tomatoes, new Topping(ToppingName.Tomatoes) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.WithOrder, new Topping(ToppingName.WithOrder) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
        }
    }
}
