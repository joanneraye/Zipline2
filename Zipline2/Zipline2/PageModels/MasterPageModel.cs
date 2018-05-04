using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.Models;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class MasterPageModel : BasePageModel
    {
        Users _Users = Users.Instance;
        public ICommand NavigationCommand { get; set; }
        string menuLoggedOnText = "Not Logged In";
        public string MenuLoggedOnText
        {
            get
            {
                return menuLoggedOnText;
            } 
            set
            {
                SetProperty(ref menuLoggedOnText, value);
            }
        }

        string menuLoggedOnIconName;
        public string MenuLoggedOnIconName
        {
            get
            {
                return menuLoggedOnIconName;
            }
            set
            {
                SetProperty(ref menuLoggedOnIconName, value);
            }
        }

        public MasterPageModel()
        {
            MenuLoggedOnIconName = "fa-question-circle";
            MessagingCenter.Subscribe<Users, string>(this, "UserLoggedIn",
                  (sender, arg) => 
                  {
                      MenuLoggedOnText = "Logged In As: " + arg;
                      MenuLoggedOnIconName = "fa-smile-o";
                  });

            NavigationCommand = new Command<string>(NavigateToPage);
        }

        private void NavigateToPage(string menuNumber)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            var detailPage = currentMainPage.Detail as NavigationPage;
            if (menuNumber.Equals("1") && detailPage.RootPage is TablesPage) return;
            switch (menuNumber)
            {
                case "1":
                    currentMainPage.Detail = new NavigationPage(new TablesPage());
                    break;
                case "5":
                    currentMainPage.Detail = new NavigationPage(new PizzaPage());
                    break;
                    //case "2":
                    //    currentMainPage.Detail = new NavigationPage(new PizzaPage());
                    //    break;
            };
            currentMainPage.IsPresented = false;
            App.Current.MainPage = currentMainPage;
            
        }
    }
}
