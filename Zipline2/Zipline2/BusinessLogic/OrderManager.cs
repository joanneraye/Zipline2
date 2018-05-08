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
    //displayed in the app for the user.  It is a singleton class.
    public sealed class OrderManager
    {
        #region Singleton
        private static OrderManager instance = null;
        private static readonly object padlock = new object();
        private OrderManager()
        {
            OrderInProgress = new Order();
        }
        public static OrderManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OrderManager();
                    }
                    return instance;
                }
            }
        }
        #endregion
        

        #region Public Properties
        public OrderItem OrderItemInProgress { get; set; }
        public Order OrderInProgress { get; set; }
        /// <summary>
        /// Stores the index of the Table in the list of all tables
        /// for this order.
        /// </summary>
        
        public int CurrentTableIndex { get; set; }
        public string CurrentTableName { get; set; }
        #endregion
        #region Methods
        /// <summary>
        /// Retrieves the Table object for the current order's table.
        /// </summary>
        /// <returns></returns>
        public Table GetCurrentTable()
        {
            return Tables.AllTables[CurrentTableIndex];
        }

        /// <summary>
        /// Updates a Table object in the list of tables.
        /// </summary>
        /// <param name="updatedTable"></param>
        public void UpdateCurrentTable(Table updatedTable)
        {
            CurrentTableIndex = updatedTable.IndexInAllTables;
            Tables.AllTables[CurrentTableIndex] = updatedTable;
            CurrentTableName = updatedTable.TableName;
        }

        public void MarkCurrentTableOccupied(bool isTableOccupied)
        {
            Tables.AllTables[CurrentTableIndex].IsOccupied = isTableOccupied;
        }

        /// <summary>
        /// Adds a new OrderItem.  This OrderItem may not be completed
        /// (such as in the case of a Pizza) since toppings or notes may
        /// be added.  When the order is completed, it will be added to the 
        /// OrderInProgress.
        /// </summary>
        /// <param name="guiData"></param>
        public void AddItemInProgress(CustomerSelection guiData)
        {
            OrderItemInProgress = OrderItemFactory.GetOrderItem(guiData);
            if (OrderItemInProgress == null)
            {
                throw new Exception("OrderManager null order item in progress");
            }

            //Derrived classed are responsible for populating the
            //name of the item and handle pricing for the item,
            //after which the order item total should be updated.
            OrderItemInProgress.PopulateDisplayName();
            OrderItemInProgress.PopulatePricePerItem();
            OrderItemInProgress.UpdateItemTotal();
        }

        public void AddDrinksToOrder(List<Drink> drinksToAdd)
        {
             List<OrderItem> orderItemList = new List<OrderItem>(drinksToAdd);
;            OrderInProgress.AddItemsToOrder(orderItemList);
        }

        public void SendOrder()
        {
            //1)  Create kitchen printout from the order.
            //2)  Send to kitchen printer.
            //3)  Send order to online service for storage and retrieval by all phones.
            //4)  Send order to Cash Register program for checkout, reporting, etc.
        }

        //Central location for taking the current OrderItem and 
        //creating a Pizza object.
        public Pizza GetCurrentPizza()
        {
            if (OrderItemInProgress != null && OrderItemInProgress is Pizza)
            {
                return OrderItemInProgress as Pizza;
            }
            return null;
        }

        /// <summary>
        /// The OrderItem has been completed and is added to the order.
        /// </summary>
        public void AddItemInProgressToOrder()
        {
            OrderItemInProgress.PopulatePricePerItem();
            OrderItemInProgress.UpdateItemTotal();
            OrderInProgress.AddItemToOrder(OrderItemInProgress);
            OrderItemInProgress = null;
        }
        #endregion
    }
}
