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

        //public Toppings ToppingsInProgress { get; set; }

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
        }

        public Table GetCurrentTable()
        {
            return Tables.AllTables[CurrentTableIndex];
        }

        public void UpdateCurrentTable(Table updatedTable)
        {

            Tables.AllTables[CurrentTableIndex] = updatedTable;

        }

        public void AddToppingsToItemInProgress(List<Topping> toppingsToAdd)
        {
          
        }

        public void AddItemInProgress(CustomerSelections guiData)
        {
            OrderItemInProgress = OrderItemFactory.GetOrderItem(guiData);
            if (OrderItemInProgress == null)
            {
                //Throw exception with error message.
            }
            OrderItemInProgress.PopulateDisplayName(guiData);
            OrderItemInProgress.PopulatePricePerItem(guiData);
        }
   
        public void HandleOrderItem(CustomerSelections guiData)
        {
            OrderItemInProgress = OrderItemFactory.GetOrderItem(guiData);
            //Need the following?
            OrderItemInProgress.Total = OrderItemInProgress.PricePerItem * OrderItemInProgress.ItemCount;
            OrderInProgress.AddItemToOrder(OrderItemInProgress);
        }
    }
}
