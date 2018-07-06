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
            foreach (var orderitem in CurrentOrder.OrderItems)
            {
                DisplayOrder.Add(orderitem.PopulateOrderDisplayItem());
            }
        }

        public void OnSendOrder()
        {
            //TODO:  Don't actually send order until ready to work on:
            OrderManager.Instance.SendOrder();

            OnNavigateToTablesPage();
        }

        void OnNavigateToTablesPage()
        {
            NavigateToTablesPage?.Invoke(this, EventArgs.Empty);
        }
    }
}
