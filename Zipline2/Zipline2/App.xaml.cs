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

            Users.AllUsers = new List<User>();
            //Somewhere load users file....
            User joanne = new User
            {
                UserPin = "8011",
                UserName = "Joanne",
                HasManagerPrivilege = true
            };
            Users.AllUsers.Add(joanne);

            Tables.LoadInitialTableData();

            //Read User file into program......

            Application.Current.Properties.Clear();


            
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
