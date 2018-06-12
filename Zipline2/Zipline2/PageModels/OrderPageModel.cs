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
    public class OrderPageModel : BasePageModel
    {
        public ICommand SendOrderCommand { get; set; }
        private List<OrderDisplayItem> displayOrder;
        public List<OrderDisplayItem> DisplayOrder
        {
            get
            {
                return displayOrder;
            }
            set
            {
                SetProperty(ref displayOrder, value);
            }
        }

        private Order currentOrder;
            public Order CurrentOrder
            {
                get
                {
                    return currentOrder;
                }
                set
                {
                    SetProperty(ref currentOrder, value);
                }
            }
          
        public OrderPageModel()
        {
            CurrentOrder = OrderManager.Instance.OrderInProgress;
            SendOrderCommand = new Command(OnSendOrder);
            DisplayOrder = new List<OrderDisplayItem>();
            foreach (var orderitem in CurrentOrder.OrderItems)
            {
                DisplayOrder.Add(orderitem.PopulateOrderDisplayItem());
            }
        }
        
        private void OnSendOrder()
        {
            //TODO:  Don't actually send order until ready to work on:
            //OrderManager.Instance.SendOrder();

            //Should any of this be done from OrderPage.xaml.cs?
          
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }
    }
}
