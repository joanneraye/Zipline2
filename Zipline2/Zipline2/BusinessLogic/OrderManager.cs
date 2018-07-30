using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Data;
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
            InitializeOrderInProgress();
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

        public bool OrderItemInProgressLoadedForEdit { get; set; }
        public Order OrderInProgress { get; set; }

        public OrderItem[] SpecialOrderItemsInProgress { get; set; }

        /// <summary>
        /// Stores the index of the Table in the list of all tables
        /// for this order.
        /// </summary>
        public int CurrentTableIndex { get; set; }
        public string CurrentTableName { get; set; }

        public decimal CurrentTableId { get; set; }
        #endregion
        #region Methods
        /// <summary>
        /// Retrieves the Table object for the current order's table.
        /// </summary>
        /// <returns></returns>
        public Table GetCurrentTable()
        {
            if (CurrentTableIndex < 0)
            {
                return new Table();
            }
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
            CurrentTableId = updatedTable.TableId;
        }


        public void MarkCurrentTableOccupied(bool isTableOccupied)
        {
            Tables.AllTables[CurrentTableIndex].IsOccupied = isTableOccupied;
        }

        public void MarkCurrentTableUnsentOrder(bool hasUnsentOrder)
        {
            Tables.AllTables[CurrentTableIndex].HasUnsentOrder = hasUnsentOrder;
        }

        public void RemoveOrderItem(OrderItem itemToRemove)
        {
            //TODO:  Need to ensure deleting the correct item.  Best
            //way is through ID but not sure how to do that yet (SQL Lite DB?)

            //foreach (var item in OrderInProgress.OrderItems)
            //{
            //    if (item.GetType() == itemToRemove.GetType())
            //}
        }

        /// <summary>
        /// Adds a new OrderItem.  This OrderItem may not be completed
        /// (such as in the case of a Pizza) since toppings or notes may
        /// be added.  When the order is completed, it will be added to the 
        /// OrderInProgress.
        /// </summary>
        /// <param name="guiData"></param>
        public void AddNewItemInProgress(OrderItem partialItemNoToppingMods)
        {
            partialItemNoToppingMods.PopulateDisplayName();
            partialItemNoToppingMods.PopulateBasePrice();
            partialItemNoToppingMods.PopulatePricePerItem();
            OrderItemInProgress = partialItemNoToppingMods;
            SpecialOrderItemsInProgress = null;
        }

        public void AddNewSpecialItemsInProgress(OrderItem[] specialItems)
        {
            foreach (var item in specialItems)
            {
                item.PopulateDisplayName();
                item.PopulateBasePrice();
                item.PopulatePricePerItem();
            }
            SpecialOrderItemsInProgress = specialItems;
            OrderItemInProgress = null;
        }

        public void UpdateSpecialItemInProgress(OrderItem specialItem)
        {
            if (specialItem is Pizza)
            {
                SpecialOrderItemsInProgress[1] = specialItem;
            }
            else if (specialItem is Salad)
            {
                SpecialOrderItemsInProgress[0] = specialItem;
            }
        }

        public void UpdateItemInProgress(OrderItem itemWithToppings)
        {
            if (itemWithToppings.PartOfCombo)
            {
                UpdateSpecialItemInProgress(itemWithToppings);
            }
            else
            {
                OrderItemInProgress = itemWithToppings;
            }
            
        }



        public async Task AddItemsToOrderAsync(List<OrderItem> itemsToAdd)
        { 
             foreach (var item in itemsToAdd)
             {
                if (item.EditingExistingItem)
                {
                    
                }
                else
                {
                    OrderManager.Instance.OrderInProgress.UpdateOrderItem(item);
                }
                OrderManager.Instance.OrderInProgress.AddItemToOrder(item);
             }
            await OrderManager.Instance.OrderInProgress.UpdateOrderOnServerAsync();
        }

        public void InitializeOrderInProgress()
        {
            OrderInProgress = new Order(CurrentTableId, CurrentTableIndex);
        }

        public async Task SendOrderAsync()
        {
            //WcfServicesProxy.Instance.SendOrderSync(OrderInProgress);
            await WcfServicesProxy.Instance.PrepareAndSendOrderAsync(OrderInProgress);
            MarkCurrentTableUnsentOrder(false);
            foreach (var item in OrderInProgress.OrderItems)
            {
                item.WasSentToKitchen = true;
            }

            //Send message that table 
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
        public async void AddItemInProgressToOrder()
        {
            //Go ahead and add item to order so we can see the price change....
            if (OrderItemInProgress != null)
            {
                OrderInProgress.AddItemToOrder(OrderItemInProgress);
                await OrderInProgress.UpdateOrderOnServerAsync();
                OrderItemInProgress = null;
            }
        }

        public async void AddSpeciaItemsToOrder()
        {
            if (SpecialOrderItemsInProgress != null)
            {
                OrderInProgress.AddItemToOrder(SpecialOrderItemsInProgress[0]);
                OrderInProgress.AddItemToOrder(SpecialOrderItemsInProgress[1]);
                await OrderInProgress.UpdateOrderOnServerAsync();
                SpecialOrderItemsInProgress = null;
            }
        }

        public Pizza GetSpecialSliceWithSalad(Guid saladComboId)
        {
            Pizza thisPizza = new Pizza();
            if (SpecialOrderItemsInProgress[1] is Pizza)
            {
                 thisPizza = SpecialOrderItemsInProgress[1] as Pizza;
                 return thisPizza;
            }
                   
            thisPizza.PartOfCombo = false;
            return thisPizza;
        }

        public void DeleteItemFromOrderInProgress(int orderItemNumber)
        {
            OrderInProgress.DeleteOrderItem(orderItemNumber);
        }

        public void DeleteSpecialItemsFromOrderInProgress(int[] itemNumbers)
        {
            if (itemNumbers.Length > 1)
            {
                OrderInProgress.DeleteOrderItem(itemNumbers[0]);
                OrderInProgress.DeleteOrderItem(itemNumbers[1]);
            }
            
        }

        #endregion
    }
}
