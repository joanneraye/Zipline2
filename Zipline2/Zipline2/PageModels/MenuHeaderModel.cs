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

        //Ideally we would expose this as a bindableproperty to the pages it is 
        //imbedded in.  That way we can do a binding on this property in 
        //the ToppingsPage.xaml, for example and Bind it with a ToppingsPage total.
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
                    var subTotal = OrderManager.GetInstance().OrderInProgress.Total + itemTotal;
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

        private static MenuHeaderModel Instance;
        private MenuHeaderModel()
        {
            itemTotal = 0M;
            OrderTotal = OrderManager.GetInstance().OrderInProgress.Total;
            UserName = Users.GetInstance().LoggedInUser.UserName;
            TableName = OrderManager.GetInstance().GetCurrentTable().TableName;
        }

        public static MenuHeaderModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MenuHeaderModel();
            }
            return Instance;
        }
        #region Methods
        public void UpdateItemTotal(decimal basePrice, decimal toppingsTotal)
        {
            ItemTotal = basePrice + toppingsTotal;
        }
        #endregion
    }
}
