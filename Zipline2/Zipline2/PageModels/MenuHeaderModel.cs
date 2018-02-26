using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;

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

        private MenuHeaderModel()
        {

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

        public decimal ItemTotal
        {
            get
            {
                if (OrderManager.OrderItemInProgress != null)
                {
                    itemTotal = OrderManager.OrderItemInProgress.Total;
                }

                return itemTotal;
            }
            set
            {
                if (OrderManager.OrderItemInProgress != null)
                {
                    itemTotal = OrderManager.OrderItemInProgress.Total;
                }

                SetProperty(ref itemTotal, value);
            }
        }

        public decimal OrderTotal
        {
            get
            {
                if (OrderManager.OrderInProgress != null)
                {
                    orderTotal = OrderManager.OrderInProgress.Total;
                }
                return orderTotal;
            }
            set
            {
                if (OrderManager.OrderInProgress != null)
                {
                    orderTotal = OrderManager.OrderInProgress.Total;
                }

                SetProperty(ref orderTotal, value);
            }
        }
    }
}
