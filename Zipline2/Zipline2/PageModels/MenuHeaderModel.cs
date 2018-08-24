using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class MenuHeaderModel : BasePageModel
    {
        #region Private Variables
        private decimal itemTotal;
        private decimal orderTotal;
        private string userName;
        private string pizzaName;
        #endregion

        #region Properties
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                SetProperty(ref userName, value);
            }
        }
        private string tableName;
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                SetProperty(ref tableName, value);
            }
        }

        private int itemCount;
        public int ItemCount
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

        private string itemTotalDisplay;

        public string ItemTotalDisplay
        {
            get
            {
                return itemTotalDisplay;
            }
            set
            {
                SetProperty(ref itemTotalDisplay, value);
            }
        }

        private string orderTotalDisplay;
        public string OrderTotalDisplay
        {
            get
            {
                return orderTotalDisplay;
            }
            set
            {
                SetProperty(ref orderTotalDisplay, value);
            }
        }

        public decimal ItemTotal
        {
            get
            {
                return itemTotal;
            }
            set
            { 
                SetProperty(ref itemTotal, value);
                ItemTotalDisplay = string.Format("{0:C}", itemTotal);
                //The order item has not been added to the order yet.  We will 
                //add whatever this item total is to the current order total
                //for our current order total.
                if (OrderManager.Instance.OrderItemInProgress != null)
                {
                    var subTotal = OrderManager.Instance.OrderInProgress.Total + itemTotal;
                    OrderTotal = subTotal + HelperMethods.GetTaxAmount(subTotal);
                }
            }
        }

        public decimal OrderTotal
        {
            get
            {
                return orderTotal;
            }
            set
            {
              
                SetProperty(ref orderTotal, value);
                OrderTotalDisplay = string.Format("{0:C}", orderTotal);
            }
        }

       
        public string PizzaName
        {
            get
            {
                return pizzaName;
            }
            set
            {
                SetProperty(ref pizzaName, value);
            }
        }

        public ICommand MinusCommand { get; set; }
        public ICommand PlusCommand { get; set; }

        private bool showPlusMinus;
        public bool ShowPlusMinus
        {
            get
            {
                return showPlusMinus;
            }
            set
            {
                SetProperty(ref showPlusMinus, value);
            }
        }
        #endregion
        private static MenuHeaderModel instance = null;
        private static readonly object padlock = new object();
        
        private MenuHeaderModel()
        {
            ItemTotal = 0M;
            MinusCommand = new Command(OnMinusClicked);
            PlusCommand = new Command(OnPlusClicked);
            OrderTotal = OrderManager.Instance.OrderInProgress.Total;
            if (Users.Instance.LoggedInUser != null)
            {
                UserName = Users.Instance.LoggedInUser.UserName;
            }            
            TableName = OrderManager.Instance.GetCurrentTable().TableName;
            MessagingCenter.Subscribe<OrderItem, decimal>(this, "ItemPriceUpdated",
                (sender, arg) => { UpdateItemTotal(arg); });
        }
        public static MenuHeaderModel Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MenuHeaderModel();
                    }
                    return instance;
                }
            }
        }
        #region Methods

        public void OnMinusClicked()
        {
            if (ItemCount > 0)
            {
                ItemCount--;
                MessagingCenter.Send(this, "HeaderMinusClicked");
            }      
        }

        public void OnPlusClicked()
        {
            ItemCount++;
            MessagingCenter.Send(this, "HeaderPlusClicked");
        }
        
        public void UpdateItemTotal(decimal newItemTotal)
        {
            ItemTotal = newItemTotal;
        }
        public void UpdateItemTotal(decimal basePrice, decimal toppingsTotal)
        {
            ItemTotal = (basePrice + toppingsTotal);
        }
        
        #endregion
    }
}
