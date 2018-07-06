using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using Zipline2.Pages;

namespace Zipline2.PageModels
{
    public class MenuButtonFooterModel : BasePageModel
    {
        #region Singleton
        private static MenuButtonFooterModel instance = null;
        private static readonly object padlock = new object();
        private MenuButtonFooterModel()
        {
            DrinksCommand = new Command(OnDrinksButtonClick);
            PizzaCommand = new Command(OnPizzaButtonClick);
            SaladsCommand = new Command(OnSaladsButtonClick);
            OrderPageCommand = new Command(OnOrderPage);
            TablesCommand = new Command(OnTablesPage);
            AddToOrderCommand = new Command(OnAddToOrder);
            SendOrderCommand = new Command(OnSendOrder);
            AddToOrderButtonText = "Add To Order";
        }
        public static MenuButtonFooterModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MenuButtonFooterModel();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public DrinksPageModel ThisDrinksPageModel { get; set; }
        public OrderPageModel ThisOrderPageModel { get; set; }
        public ICommand DrinksCommand { get; set; }
        public ICommand SaladsCommand { get; set; }
        public ICommand PizzaCommand { get; set; }
        public ICommand AddToOrderCommand { get; set; }
        public ICommand TablesCommand { get; set; }
        public ICommand OrderPageCommand { get; set; }
        public ICommand SendOrderCommand { get; set; }
        private string addToOrderButtonText;
        public string AddToOrderButtonText
        {
            get
            {
                return addToOrderButtonText;
            }
            set
            {
              
                SetProperty(ref addToOrderButtonText, value);
            }
        }
        private bool displayAddToOrderButton;
        public bool DisplayAddToOrderButton
        {
            get
            {
                return displayAddToOrderButton;
            }
            set
            {
               
                SetProperty(ref displayAddToOrderButton, value);

            }
        }
        private bool isOrderPageDisplayed;
        public bool IsOrderPageDisplayed
        {
            get
            {
                return isOrderPageDisplayed;
            }
            set
            {
                SetProperty(ref isOrderPageDisplayed, value);
                if (isOrderPageDisplayed)
                {
                    IsPizzaPageDisplayed = false;
                    IsDrinkPageDisplayed = false;
                }
            }
        }

        private bool isDrinkPageDisplayed;
        public bool IsDrinkPageDisplayed
        {
            get
            {
                return isDrinkPageDisplayed;
            }
            set
            {
                SetProperty(ref isDrinkPageDisplayed, value);
                if (isDrinkPageDisplayed)
                {
                    IsPizzaPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                }
            }
        }

        private bool isPizzaPageDisplayed;
        public bool IsPizzaPageDisplayed
        {
            get
            {
                return isPizzaPageDisplayed;
            }
            set
            {
                SetProperty(ref isPizzaPageDisplayed, value);
                if (isPizzaPageDisplayed)
                {
                    IsDrinkPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                }
            }
        }

        private void OnOrderPage()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new OrderPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnTablesPage()
        {
            if (OrderManager.Instance.OrderInProgress.OrderItems.Count == 0)
            {
                Tables.AllTables[OrderManager.Instance.CurrentTableIndex].IsOccupied = false;
            }
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnAddToOrder()
        {
            ThisDrinksPageModel.OnAddDrinks();
        }

        void OnSendOrder()
        {
           
            ThisOrderPageModel.OnSendOrder();
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

        void OnSaladsButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new SaladsPage());
            Application.Current.MainPage = currentMainPage;
        }



    }
}
