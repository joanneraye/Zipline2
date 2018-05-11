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

        public class OrderDisplayItem : BasePageModel
        {
            private string orderItemName;
            private decimal pricePerItem;
            private decimal itemCount;
            private decimal total;
            private string toppings;
            private bool wasSentToKitchen;
            public string OrderItemName
            {
                get
                {
                    return orderItemName;
                }
                set
                {
                    SetProperty(ref orderItemName, value);
                }
            }

            public decimal PricePerItem
            {
                get
                {
                    return pricePerItem;
                }
                set
                {
                    SetProperty(ref pricePerItem, value);
                }
            }
            public decimal ItemCount
            {
                get
                {
                    return itemCount;
                }
                set
                {
                    SetProperty(ref itemCount, value);
                }
            }
            public decimal Total
            {
                get
                {
                    return total;
                }
                set
                {
                    SetProperty(ref total, value);
                }
            }
            public string Toppings
            {
                get
                {
                    return toppings;
                }
                set
                {
                    SetProperty(ref toppings, value);
                }
            }
            public bool WasSentToKitchen
            {
                get
                {
                    return wasSentToKitchen;
                }
                set
                {
                    SetProperty(ref wasSentToKitchen, value);
                }

            }
        }

        //**************end of embedded display item class*********************


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
            //Populate OrderDisplayItem
            DisplayOrder = new List<OrderDisplayItem>();
            foreach (var orderitem in CurrentOrder.OrderItems)
            {
                var newOrderDisplayItem = new OrderDisplayItem()
                {
                    OrderItemName = orderitem.ItemName,
                    ItemCount = orderitem.ItemCount,
                    PricePerItem = orderitem.PricePerItem,
                    WasSentToKitchen = orderitem.WasSentToKitchen,
                    Total = orderitem.Total
                };
                if (orderitem is Pizza)
                {
                    var toppingsString = new StringBuilder();
                    Pizza pizza = (Pizza)orderitem;
                    for (int i = 0; i < pizza.Toppings.CurrentToppings.Count; i++)
                    {
                        if (i > 0)
                        {
                            toppingsString.Append(", ");
                        }
                        toppingsString.Append(pizza.Toppings.CurrentToppings[i].ToppingDisplayName);
                    }
                 
                    newOrderDisplayItem.Toppings = toppingsString.ToString();
                }
                DisplayOrder.Add(newOrderDisplayItem);
            }
            
        }
        private void OnSendOrder()
        {
            OrderManager.Instance.SendOrder();

            //Should this be done from OrderPage.xaml.cs?
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }
    }
}
