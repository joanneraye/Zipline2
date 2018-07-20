using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public event EventHandler NavigateToTablesPage;
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
            var lunchSpecialDisplayItem = new OrderDisplayItem();
            var lunchSpecialItems = new List<OrderItem>();
            Guid firstGuid = Guid.Empty;
            foreach (var orderitem in CurrentOrder.OrderItems)
            {
                var displayItem = orderitem.PopulateOrderDisplayItem();

                //TODO:  ???   Logic assumes that lunch special items are sequential.
                if (orderitem.PartOfCombo)
                {
                    displayItem.OrderitemDisplayName = "   " + orderitem.ItemName;
                    if (firstGuid == Guid.Empty)
                    {
                        firstGuid = orderitem.ComboId;

                        displayItem.CustomHeader = "LUNCH SPECIAL:";
                        displayItem.UseCustomHeader = true;
                    }
                    else
                    {
                        firstGuid = Guid.Empty;
                    }
                }
                
                DisplayOrder.Add(displayItem);

            }
        }

        public async void OnSendOrder()
        {
            //TODO:  Don't actually send order until ready to work on:
            await OrderManager.Instance.SendOrderAsync();

            OnNavigateToTablesPage();
        }

        public void OnNavigateToTablesPage()
        {
            NavigateToTablesPage?.Invoke(this, EventArgs.Empty);
        }
    }
}
