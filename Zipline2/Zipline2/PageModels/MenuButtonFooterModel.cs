using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.Data;
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
            CalzoneCommand = new Command(OnCalzonesButtonClick);
            SpecialsCommand = new Command(OnSpecialsButtonClick);
            DessertCommand = new Command(OnDessertButtonClick);
            OrderPageCommand = new Command(OnOrderPage);
            TablesCommand = new Command(OnTablesPage);
            AddToOrderCommand = new Command(OnAddToOrder);
            SendOrderCommand = new Command(OnSendOrder);
            EditOrderItemCommand = new Command(OnEditOrderItem);
            DeleteOrderItemCommand = new Command(OnDeleteOrderItem);
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

        public DessertPageModel ThisDessertPageModel { get; set; }
        public ICommand DrinksCommand { get; set; }
        public ICommand SaladsCommand { get; set; }
        public ICommand CalzoneCommand { get; set; }
        public ICommand PizzaCommand { get; set; }
        public ICommand SpecialsCommand { get; set; }
        public ICommand DessertCommand { get; set; }
        public ICommand AddToOrderCommand { get; set; }
        public ICommand TablesCommand { get; set; }
        public ICommand OrderPageCommand { get; set; }
        public ICommand SendOrderCommand { get; set; }

        public ICommand EditOrderItemCommand { get; set; }
        public ICommand DeleteOrderItemCommand { get; set; }
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
                    IsSaladPageDisplayed = false;
                    IsCalzonePageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    IsDessertPageDisplayed = false;
                }
            }
        }

        private bool isSaladPageDisplayed;
        public bool IsSaladPageDisplayed
        {
            get
            {
                return isSaladPageDisplayed;
            }
            set
            {
                SetProperty(ref isSaladPageDisplayed, value);
                if (isSaladPageDisplayed)
                {
                    IsPizzaPageDisplayed = false;
                    IsDrinkPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                    DisplayAddToOrderButton = false;
                    IsCalzonePageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    IsDessertPageDisplayed = false;
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
                    IsSaladPageDisplayed = false;
                    IsCalzonePageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    IsDessertPageDisplayed = false;
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
                    IsSaladPageDisplayed = false;
                    IsCalzonePageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    IsDessertPageDisplayed = false;
                }
            }
        }

        private bool isCalzonePageDisplayed;
        public bool IsCalzonePageDisplayed
        {
            get
            {
                return isCalzonePageDisplayed;
            }
            set
            {
                SetProperty(ref isCalzonePageDisplayed, value);
                if (isCalzonePageDisplayed)
                {
                    IsDrinkPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                    IsSaladPageDisplayed = false;
                    IsPizzaPageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    IsDessertPageDisplayed = false;
                }
            }
        }

        private bool isSpecialsPageDisplayed;
        public bool IsSpecialsPageDisplayed
        {
            get
            {
                return isSpecialsPageDisplayed;
            }
            set
            {
                SetProperty(ref isSpecialsPageDisplayed, value);
                if (isSpecialsPageDisplayed)
                {
                    IsDrinkPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                    IsSaladPageDisplayed = false;
                    IsPizzaPageDisplayed = false;
                    IsCalzonePageDisplayed = false;
                    IsDessertPageDisplayed = false;
                    DisplayAddToOrderButton = false;
                }
            }
        }

        private bool isDessertPageDisplayed;
        public bool IsDessertPageDisplayed
        {
            get
            {
                return isDessertPageDisplayed;
            }
            set
            {
                SetProperty(ref isDessertPageDisplayed, value);
                if (isDessertPageDisplayed)
                {
                    IsDrinkPageDisplayed = false;
                    IsOrderPageDisplayed = false;
                    IsSaladPageDisplayed = false;
                    IsPizzaPageDisplayed = false;
                    IsCalzonePageDisplayed = false;
                    IsSpecialsPageDisplayed = false;
                    DisplayAddToOrderButton = false;
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
                Tables.AllTables[OrderManager.Instance.CurrentTableIndex].HasUnsentOrder = false;
            }
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnAddToOrder()
        {
            if (IsDrinkPageDisplayed)
            {
                ThisDrinksPageModel.OnAddDrinks();
            }
            else if (IsDessertPageDisplayed)
            {
                ThisDessertPageModel.OnAddDesserts();
            }
          
        }

        void OnSendOrder()
        {
           
            ThisOrderPageModel.OnSendOrder();
        }


        void OnDrinksButtonClick()
        {
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

        public void OnCalzonesButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }

        public void OnSpecialsButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new SpecialsPage());
            Application.Current.MainPage = currentMainPage;
        }

        public void OnDessertButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new DessertPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnSaladsButtonClick()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new SaladsPage());
            Application.Current.MainPage = currentMainPage;
        }

        void OnEditOrderItem()
        {
            OrderManager.Instance.OrderInProgress.EditingExistingOrder = true;
            MessagingCenter.Send(this, "EditOrderItem");
        }

        void OnDeleteOrderItem()
        {
            MessagingCenter.Send(this, "DeleteOrderItem");
        }
    }
}
