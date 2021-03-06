﻿using System;
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
using Zipline2.BusinessLogic.Enums;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Zipline2
{
    
    public partial class App : Application
    {

        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static double PlusMinusButtonHeightWidth;
        public static double PlusMinusButtonCornerRadius;
        public static double PlusMinusButtonRowHeight;
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
            //var watch = System.Diagnostics.Stopwatch.StartNew();
            //The following 4 statements take about a half a second (total).
            Zipline2.Data.Tables.LoadInitialTableData();
            Zipline2.Data.MenuFood.LoadInitialPizzaToppings();
            Zipline2.Data.MenuFood.LoadInitialSaladToppings();
            Zipline2.Data.MenuDrinks.CreateAllDrinks();
            CalculatePlusMinusButtonInfo();
            MenuFood.CreateDesserts();
            DataLoader.LoadMenuFromFileOrServer();
            DataLoader.LoadToppingsFromFileOrServer();
           
            MainPage = new MainMasterDetailPage();
        }

        private void CalculatePlusMinusButtonInfo()
        {
            int buttonWidthHeight = (ScreenWidth - 20) / 3;
            PlusMinusButtonHeightWidth = buttonWidthHeight;
            PlusMinusButtonCornerRadius = (buttonWidthHeight / 2);
            PlusMinusButtonRowHeight = (buttonWidthHeight + 5);
        }

        //private void LoadMenuFromServer()
        //{
        //    WcfServicesProxy.Instance.GetMenu();
        //}


        //private void LoadTablesFromServer()
        //{
        //    WcfServicesProxy.Instance.GetTables();
        //}

        //async private void LoadTablesFromServerAsync()
        //{
        //    await WcfServicesProxy.Instance.GetTablesAsync();
        //}

        //async private void LoadMenuFromServerAsync()
        //{
        //    await WcfServicesProxy.Instance.GetMenuAsync();
        //}

        

        //private void LoadDrinks()
        //{
        //    MenuDrinks.CreateAllDrinks();
        //}

        
        //public void LoadMenuPizzaPage()
        //{
        //    var currentMainPage = (Current.MainPage as MasterDetailPage);
        //    currentMainPage.Detail = new NavigationPage(new PizzaPage());
        //    Application.Current.MainPage = currentMainPage;
        //}

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
