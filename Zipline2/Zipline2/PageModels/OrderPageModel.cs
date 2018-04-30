using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class OrderPageModel : BasePageModel
    {
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
        private List<OrderItem> currentOrderItems;
        public List<OrderItem> CurrentOrderItems
        {
            get
            {
                return currentOrderItems;
            }
            set
            {
                SetProperty(ref currentOrderItems, value);
            }
        }

        public OrderPageModel()
        {
            currentOrder = OrderManager.Instance.OrderInProgress;
            currentOrderItems = currentOrder.OrderItems;
        }
        //public class DisplayOrderItem : BasePageModel
        //{
        //    private OrderItem orderItemForDisplay;
        //    public OrderItem OrderItemForDisplay
        //    {
        //        get
        //        {
        //            return OrderItemForDisplay;
        //        }
        //        set
        //        {
        //            SetProperty(ref orderItemForDisplay, value);
        //        }
        //    }
        //}
    }
}
