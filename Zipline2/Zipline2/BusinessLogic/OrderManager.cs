using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using Zipline2.PageModels;
using Zipline2.Pages;

namespace Zipline2.BusinessLogic
{
    //This class will maintain the orders in progress that may be
    //displayed in the app for the user.
    public sealed class OrderManager
    {
        //private static OrderItem orderItemInProgress;
        //public static OrderItem OrderItemInProgress
        //{
        //    get
        //    {
        //        return orderItemInProgress;
        //    }
        //    set
        //    {
        //        orderItemInProgress = value;
        //    }
        //}

        public static OrderItem OrderItemInProgress { get; set; }
        public static Order OrderInProgress { get; set; }

        //This is a singleton class:
        private static readonly Lazy<OrderManager> lazy =
            new Lazy<OrderManager>(() => new OrderManager());
        public static OrderManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private OrderManager()
        {

        }

        public static void HandleOrderItem(CustomerSelections guiData)
        {
            OrderItemInProgress = OrderItemFactory.GetOrderItem(guiData);
            OrderInProgress.AddItemToOrder(OrderItemInProgress);
            var menuHeader = MenuHeaderModel.GetInstance();
            menuHeader.ItemTotal = OrderItemInProgress.Total;
            menuHeader.OrderTotal = OrderInProgress.Total;
        }
    }
}
