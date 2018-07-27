﻿using System;
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

        void OnEditOrderItem()
        {
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
            
            if (saveSelectedItem is Pizza)
            {
                NavigateToPizzaPage();
            }
            else if (saveSelectedItem is Salad)
            {
                NavigateToSaladToppingsPage((Salad)saveSelectedItem);
            }
            else if (saveSelectedItem is Drink)
            {
                NavigateToDrinksPage();
            }
            else if (saveSelectedItem is Calzone)
            {
                NavigateToCalzoneToppingsPage((Calzone)saveSelectedItem);
            }
        }

        void OnDeleteOrderItem()
        {

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

        void NavigateToDrinksPage()
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new DrinksPage());
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