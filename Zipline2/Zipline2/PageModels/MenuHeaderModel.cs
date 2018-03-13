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
                if (OrderManager.GetInstance().OrderItemInProgress != null)
                {
                    var subTotal = OrderManager.GetInstance().OrderItemInProgress.Total + itemTotal;
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

        #endregion

        #region Singleton Class setup including constructor
        private MenuHeaderModel()
        {
            UserName = Users.GetInstance().LoggedInUser.UserName;
            itemTotal = 0M;
            orderTotal = 0M;
            tableName = OrderManager.GetInstance().GetCurrentTable().TableName;
        }

        private static MenuHeaderModel Instance;

        public static MenuHeaderModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MenuHeaderModel();
            }

            return Instance;
        }
        #endregion

        #region Methods
        public void PopulateItemTotal()
        {
            var currentOrderItem = OrderManager.GetInstance().OrderItemInProgress;
            if (currentOrderItem is Pizza)
            {
                Pizza thisPizza = (Pizza)currentOrderItem;
                itemTotal = (thisPizza.BasePrice +
                    thisPizza.PizzaToppings.ToppingsTotal) *
                    thisPizza.ItemCount;
            }
        }
        #endregion
    }
}
