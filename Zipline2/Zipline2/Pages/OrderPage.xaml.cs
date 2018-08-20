using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.Data;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : BasePage
	{
        OrderPageModel orderPageModel;
        OrderItem saveSelectedItem;

        OrderItem[] saveSpecialItems = new OrderItem[2];
        bool itemSelectedForEditIsSpecial = false;

		public OrderPage ()
		{
            OrderManager.Instance.OrderInProgress.EditingExistingOrder = false;
            orderPageModel = new OrderPageModel();
            InitializeComponent();
            BindingContext = orderPageModel;
            Footer.FooterPageModel.IsOrderPageDisplayed = true;
            Footer.FooterPageModel.DisplayAddToOrderButton = false;
            Footer.FooterPageModel.ThisOrderPageModel = orderPageModel;
            string pizzaTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Order";
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
            MessagingCenter.Subscribe<MenuButtonFooterModel>(this, "EditOrderItem",
               (sender) => { OnEditOrderItem(); });
            MessagingCenter.Subscribe<MenuButtonFooterModel>(this, "DeleteOrderItem",
              (sender) => { OnDeleteOrderItem(); });

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            orderPageModel.NavigateToTablesPage += HandleNavigateToTablesPage;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedObject = e.SelectedItem;
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }           
            OrderDisplayItem selectedItem;
            if (selectedObject is OrderDisplayItem)
            {
                selectedItem = (OrderDisplayItem)selectedObject;

                //if item clicked is unselected, and therefore is being selected
                //deselect all items to clear screen so that only selecting one
                //item at a time.
                if (!selectedItem.ItemIsSelected)
                {
                    foreach (var displayItem in orderPageModel.DisplayOrder)
                    {
                        displayItem.ItemIsSelected = false;
                    }
                }

                selectedItem.ItemIsSelected = !selectedItem.ItemIsSelected;  //toggle
                if (!selectedItem.ItemIsSelected)
                {
                    return;
                }
                bool newValueItemIsSelected = selectedItem.ItemIsSelected;
               
                if (selectedItem.OrderItem.PartOfCombo)
                {
                    itemSelectedForEditIsSpecial = true;
                    if (selectedItem.UseCustomHeader)
                    {
                        saveSpecialItems[0] = selectedItem.OrderItem;
                        if (orderPageModel.DisplayOrder.Count > selectedItem.ItemIndex)
                        {
                            saveSpecialItems[1] = orderPageModel.DisplayOrder[selectedItem.ItemIndex + 1].OrderItem;
                            orderPageModel.DisplayOrder[selectedItem.ItemIndex + 1].ItemIsSelected = newValueItemIsSelected;
                        }                        
                    }
                    else
                    {
                        saveSpecialItems[1] = selectedItem.OrderItem;
                        if ((selectedItem.ItemIndex - 1) >= 0)
                        {
                            saveSpecialItems[0] = orderPageModel.DisplayOrder[selectedItem.ItemIndex - 1].OrderItem;
                            orderPageModel.DisplayOrder[selectedItem.ItemIndex - 1].ItemIsSelected = newValueItemIsSelected;
                        }
                    }
                }
                else
                {
                    saveSelectedItem = selectedItem.OrderItem;
                }
            }
        }

        async void OnEditOrderItem()
        {
            if (saveSpecialItems[0] == null && saveSelectedItem == null)
            {
                await DisplayAlert("Warning", "Please select an item to edit before clicking the edit button.", "OK");
                return;
            }

            OrderManager.Instance.OrderItemInProgressLoadedForEdit = true;

            if (itemSelectedForEditIsSpecial)
            {
                OrderManager.Instance.SpecialOrderItemsInProgress = saveSpecialItems;
                var currentMainPage = Application.Current.MainPage as MasterDetailPage;
                currentMainPage.Detail = new NavigationPage(new SaladToppingsPage((Salad)saveSpecialItems[0]));
                Application.Current.MainPage = currentMainPage;
            }
            else
            {
                OrderManager.Instance.OrderItemInProgress = saveSelectedItem;
            }

            var selectedItemForEdit = saveSelectedItem;
            saveSelectedItem = null;
            saveSpecialItems = new OrderItem[2];

            if (selectedItemForEdit is Pizza)
            {
                NavigateToPizzaPage();
            }
            else if (selectedItemForEdit is Salad)
            {
                NavigateToSaladToppingsPage((Salad)selectedItemForEdit);
            }
            else if (selectedItemForEdit is Drink)
            {
                NavigateToDrinksPage((Drink)selectedItemForEdit);
            }
            else if (selectedItemForEdit is Calzone)
            {
                NavigateToCalzoneToppingsPage((Calzone)selectedItemForEdit);
            }
            else if (selectedItemForEdit is Dessert)
            {
                NavigateToDessertPage((Dessert)selectedItemForEdit);
            }
        }

        async void OnDeleteOrderItem()
        { 
            if (saveSpecialItems[0] == null && saveSelectedItem == null)
            {
                await DisplayAlert("Warning", "Please select an item to delete before clicking the delete button.", "OK");
                return;
            }
            OrderManager.Instance.OrderItemInProgressLoadedForEdit = true;

            if (itemSelectedForEditIsSpecial)
            {
               if (saveSpecialItems.Length > 1)
                {
                    int[] orderItemNumbers = new int[]
                    {
                        saveSpecialItems[0].OrderItemNumber,
                        saveSpecialItems[1].OrderItemNumber
                    };

                    OrderManager.Instance.DeleteSpecialItemsFromOrderInProgress(orderItemNumbers);
                }
            }
            else
            {
                OrderManager.Instance.DeleteItemFromOrderInProgress(saveSelectedItem.OrderItemNumber);
            }

            saveSelectedItem = null;
            saveSpecialItems = new OrderItem[2];
            orderPageModel.LoadOrderPageData();
        }

        void NavigateToPizzaPage()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }
        void NavigateToCalzoneToppingsPage(Calzone calzone)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new CalzoneToppingsPage(calzone));
            Application.Current.MainPage = currentMainPage;
        }

        void NavigateToSaladToppingsPage(Salad thisSalad)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new SaladToppingsPage(thisSalad));
            Application.Current.MainPage = currentMainPage;
        }

        void NavigateToDrinksPage(Drink drinkForEdit)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new DrinksPage(drinkForEdit));
            Application.Current.MainPage = currentMainPage;
        }

        void NavigateToDessertPage(Dessert dessertForEdit)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new DessertPage(dessertForEdit));
            Application.Current.MainPage = currentMainPage;
        }


        void HandleNavigateToTablesPage(object sender, EventArgs e)
        {
            if (OrderManager.Instance.OrderInProgress.OrderItems.Count == 0)
            {
                Tables.AllTables[OrderManager.Instance.CurrentTableIndex].IsOccupied = false;
                Tables.AllTables[OrderManager.Instance.CurrentTableIndex].HasUnsentOrder = false;
            }
            else
            {
                DisplayAlert("NOTE:", "During this phase of testing, no orders are being sent to the server or kitchen.", "OK");
            }
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            orderPageModel.NavigateToTablesPage -= HandleNavigateToTablesPage;
            MessagingCenter.Unsubscribe<string>(this, "EditOrderItem");
            MessagingCenter.Unsubscribe<string>(this, "DeleteOrderItem");
        }
    }
}