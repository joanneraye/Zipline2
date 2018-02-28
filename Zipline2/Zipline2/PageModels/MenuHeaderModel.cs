using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class MenuHeaderModel : BasePageModel
    {
        //Need to figure out a way to update these whenever
        //OrderManager properties update.  How do I have the program
        //notify this class when there is an update in OrderManager 
        //so that I can update these totals bound to the screen??
        private decimal itemTotal;
        private decimal orderTotal;
        private string userName;
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
                if (OrderManager.GetInstance().OrderItemInProgress != null)
                {
                    itemTotal = OrderManager.GetInstance().OrderItemInProgress.Total;
                }

                return itemTotal;
            }
            set
            {
                if (OrderManager.GetInstance().OrderItemInProgress != null)
                {
                    itemTotal = OrderManager.GetInstance().OrderItemInProgress.Total;
                }

                SetProperty(ref itemTotal, value);
            }
        }

        public decimal OrderTotal
        {
            get
            {
                if (OrderManager.GetInstance().OrderInProgress != null)
                {
                    orderTotal = OrderManager.GetInstance().OrderInProgress.Total;
                }
                return orderTotal;
            }
            set
            {
                if (OrderManager.GetInstance().OrderInProgress != null)
                {
                    orderTotal = OrderManager.GetInstance().OrderInProgress.Total;
                }

                SetProperty(ref orderTotal, value);
            }
        }

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
    }
}
