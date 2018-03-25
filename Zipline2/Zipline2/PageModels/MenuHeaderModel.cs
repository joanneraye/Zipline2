using System;
using System.Collections.Generic;
using System.Text;
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

        public decimal ItemTotal
        {
            get
            {
                return itemTotal;
            }
            set
            {
                SetProperty(ref itemTotal, value);

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
        #endregion
        private static MenuHeaderModel instance = null;
        private static readonly object padlock = new object();
        private MenuHeaderModel()
        {
            itemTotal = 0M;
            OrderTotal = OrderManager.Instance.OrderInProgress.Total;
            UserName = Users.Instance.LoggedInUser.UserName;
            TableName = OrderManager.Instance.GetCurrentTable().TableName;
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
        public void UpdateItemTotal(decimal basePrice, decimal toppingsTotal)
        {
            ItemTotal = basePrice + toppingsTotal;
        }
        #endregion
    }
}
