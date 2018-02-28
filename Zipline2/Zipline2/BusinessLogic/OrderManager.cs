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
        public OrderItem OrderItemInProgress { get; set; }
        public Order OrderInProgress { get; set; }
        
        public int CurrentTableIndex { get; set; }
       
        private static OrderManager Instance;

        //This is a singleton class:
        public static OrderManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new OrderManager();
            }

            return Instance;
        }

        private OrderManager()
        {
            OrderInProgress = new Order();
            OrderItemInProgress = new OrderItem();
        }

        public Table GetCurrentTable()
        {
            return Tables.AllTables[CurrentTableIndex];
        }

        public void UpdateCurrentTable(Table updatedTable)
        {
            
           Tables.AllTables[CurrentTableIndex] = updatedTable;
             
        }

        public void HandleOrderItem(CustomerSelections guiData)
        {
            OrderItemInProgress = OrderItemFactory.GetOrderItem(guiData);
            OrderInProgress.AddItemToOrder(OrderItemInProgress);
            var menuHeader = MenuHeaderModel.GetInstance();
            menuHeader.ItemTotal = OrderItemInProgress.Total;
            menuHeader.OrderTotal = OrderInProgress.Total;
            //Somehow need to update the MenuHeaderView
        }
    }
}
