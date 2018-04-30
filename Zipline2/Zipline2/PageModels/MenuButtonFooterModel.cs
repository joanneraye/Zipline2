using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class MenuButtonFooterModel : BasePageModel
    {
        public ICommand DrinksCommand { get; set; }
        public ICommand PizzaCommand { get; set; }

        public ICommand OrderPageCommand { get; set; }
        public MenuButtonFooterModel()
        {
            DrinksCommand = new Command(OnDrinksButtonClick);
            PizzaCommand = new Command(OnPizzaButtonClick);
            OrderPageCommand = new Command(OnOrderPage);
        }

        private void OnOrderPage()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new OrderPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnDrinksButtonClick()
        {
            //TODO: This was copied and modified from TablesPage.HandleNavigateToPizzaPage.
            //Can we make this a helper method???

            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new DrinksPage());
            Application.Current.MainPage = currentMainPage;

        }
        void OnPizzaButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }
    }
}
