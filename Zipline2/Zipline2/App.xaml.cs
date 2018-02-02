using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Zipline2
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public App()
        {
            MainPage = new NavigationPage(new LoginPage())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.Transparent
            };

            //InitializeComponent();

            //MainPage = new MainPage();

            //if (!IsUserLoggedIn)
            //{
            //    MainPage = new NavigationPage(new LoginPageModel());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new TableListPageModel());
            //}
        }

        private void ShowLoginPage()
        {            
            //Can't figure how to get from showing login page to then show main page 
            //unless I code it in LoginPageModel?  How do I get back here and then show MainPage?
            //var loginPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>(null);
            //MainPage = new FreshNavigationContainer(loginPage);
        }

        private void ShowMainPage()
        {
            //MainPage = new NavigationPage(new TableListPageModel());
            //var tabContainer = new FreshTabbedNavigationContainer();
            //tabContainer.AddTab<MainPageModel>("Table List Page", "icon.pgn");
            //tabContainer.AddTab<MainMenuPageModel>("Main Menu Page", "icon.pgn");

            //MainPage = tabContainer;
            //var mainPage = FreshPageModelResolver.ResolvePageModel<MainPageModel>(null);
            //var navContainer = new FreshNavigationContainer(mainPage);
            //MainPage = navContainer;
        }

        protected override void OnStart()
        {
            //ShowLoginPage();
        }

        protected override void OnSleep()
        {
            //ShowMainPage();
        }

        protected override void OnResume()
        {
            
            //????? 
        }
    }
}
