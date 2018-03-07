using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.Pages;
using Zipline2.BusinessLogic;

namespace Zipline2
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        
        public App()
        {
            InitializeComponent();
           
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.White
                };
            }
            else
            {
                MainPage = new NavigationPage(new TablesPage());
            }
        }

        protected override void OnStart()
        {
            //Prices.WritePricesToJsonFile();
            //Prices.ReadPricesFromJsonFile();
            //Somewhere load users file....

            //for now....
            User joanne = new User("Joanne", true, "8011");
            User satch = new User("Satch", true, "1168");
            Users.GetInstance().AddNewUser(joanne);
            Users.GetInstance().AddNewUser(satch);

            Tables.LoadInitialTableData();
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
