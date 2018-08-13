using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    /// <summary>
    /// An Order class represents a customer ticket.  It includes OrderItem class objects
    /// and order information such as order subtotal, tax and total as well as a reference to 
    /// the table for the order.
    /// </summary>
    [Table("order")]
    public class Order : BasePageModel
    {
        public int OrderNumberId { get; set; }

        private List<OrderItem> orderItems;
        public List<OrderItem> OrderItems
        {
            get
            {
                return orderItems;
            }
            private set
            {
                SetProperty(ref orderItems, value);
            }
        }
        
        public decimal SubTotal { get; set; }
       
        public decimal Tax { get; set; }
       
        public decimal Total { get; set; }

        public bool EditingExistingOrder;
        public bool IsTakeout { get; set; }

        private bool allItemsSent;
        public bool AllItemsSent
        {
            get
            {
                return allItemsSent;
            }
            set
            {
                SetProperty(ref allItemsSent, value);
            }
        }

       
        public decimal TableId { get; set; }
        public int TableIndexInAllTables { get; set; }
        public decimal[] GuestIds { get; set; } = new decimal[2];

        public Order(decimal tableId, int tableIndex)
        {
            OrderItems = new List<OrderItem>();
            IsTakeout = false;
            TableId = tableId;
            TableIndexInAllTables = tableIndex;
        }

        private void UpdateOrderTotals()
        {
            SubTotal = 0;
            
            foreach (var orderItem in OrderItems)
            {
                if (orderItem.PartOfCombo && orderItem is Pizza)
                {
                    Pizza thisPizza = (Pizza)orderItem;
                    if (thisPizza.PizzaType == PizzaType.LunchSpecialSlice)
                    {
                        if (thisPizza.Toppings.ToppingsTotal > 0)
                        {
                            thisPizza.GetsLunchSpecialDiscount = true;
                        }
                    }
                    else
                    {
                        thisPizza.GetsLunchSpecialDiscount = false;
                    }
                }
               
                SubTotal += orderItem.TotalPricePerItemTimesCount;
            }
            Tax = HelperMethods.GetTaxAmount(SubTotal);
            Total = SubTotal + Tax;
        }

        

        //When a new OrderItem is added, subtotal, tax, and total are 
        //automatically updated.
        public void AddItemToOrder(OrderItem newOrderItem)
        {
            bool addItemToOrder = true;
            if (newOrderItem != null)
            {
                AllItemsSent = false;
                if (newOrderItem is Drink)
                {
                    Drink drinkToAdd = (Drink)newOrderItem;
                    if (UpdateDrinkIfAlreadyOnOrder(drinkToAdd))
                    {
                        addItemToOrder = false;
                    }
                }
                else if (newOrderItem is Dessert)
                {
                    Dessert dessertToAdd = (Dessert)newOrderItem;
                    if (UpdateDessertIfAlreadyOnOrder(dessertToAdd))
                    {
                        addItemToOrder = false;
                    }
                }

                if (addItemToOrder)
                {
                    newOrderItem.OrderItemNumber = OrderItems.Count + 1;
                    OrderItems.Add(newOrderItem);
                }
               
                UpdateOrderTotals();
            }
        }

        public void UpdateOrderItem(OrderItem existingOrderItem)
        {
            if (existingOrderItem != null)
            {
                //TODO:  Not sure yet how handling editing of drinks....
                //if (existingOrderItem is Drink)
                //{
                //    Drink drinkToAdd = (Drink)existingOrderItem;
                //    if (!UpdateDrinkIfAlreadyOnOrder(drinkToAdd))
                //    {
                //        existingOrderItem.EditingExistingItem = true;
                //        OrderItems.Add(existingOrderItem);
                //    }
                //}

                for (int i = 0; i < OrderItems.Count; i++)
                {
                    if (OrderItems[i].OrderItemNumber == existingOrderItem.OrderItemNumber)
                    {
                        OrderItems[i] = existingOrderItem;
                    }
                }

                UpdateOrderTotals();
            }

        }

        public async Task UpdateOrderOnServerAsync()
        {
            try
            {
                await WcfServicesProxy.Instance.UpdateOrderAsync(this);
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
         
            //WcfServicesProxy.Instance.UpdateOrderSync(this);
        }

        public bool UpdateDrinkIfAlreadyOnOrder(Drink drinkToAdd)
        {
            foreach (var orderItem in OrderItems)
            {
                if (orderItem is Drink)
                {
                    Drink drinkAlreadyOnOrder = (Drink)orderItem;
                    if (drinkToAdd.DrinkType == drinkAlreadyOnOrder.DrinkType &&
                        drinkToAdd.DrinkSize == drinkAlreadyOnOrder.DrinkSize)
                    {
                        if (EditingExistingOrder)
                        {
                            orderItem.ItemCount = drinkToAdd.ItemCount;
                        }
                        else
                        {
                            orderItem.ItemCount++;
                        }
                        
                        return true;
                    }
                }
            }

            return false;
        }

        public bool UpdateDessertIfAlreadyOnOrder(Dessert dessertToAdd)
        {
            foreach (var orderItem in OrderItems)
            {
                if (orderItem is Dessert)
                {
                    Dessert dessertAlreadyOnOrder = (Dessert)orderItem;
                    if (dessertToAdd.DessertType == dessertAlreadyOnOrder.DessertType)
                    {
                        if (EditingExistingOrder)
                        {
                            orderItem.ItemCount = dessertToAdd.ItemCount;
                        }
                        else
                        {
                            orderItem.ItemCount++;
                        }
                        return true;
                    }
                }
            }

            return false;
        }


        public void CombineLikeItems()
        {
            //For now just combining drink like items - not sure which other ones
            //I will need to combine...
            var newOrderItemList = new List<OrderItem>();
            Dictionary<Tuple<DrinkType, DrinkSize>, int> drinkTally = new Dictionary<Tuple<DrinkType, DrinkSize>, int>();
            foreach (var item in OrderItems)
            {
                if (item is Drink)
                {
                    Drink drink = (Drink)item;
                    var drinkKey = Tuple.Create<DrinkType, DrinkSize>(drink.DrinkType, drink.DrinkSize);
                    if (drinkTally.ContainsKey(drinkKey))
                    {
                        drinkTally[drinkKey]++;
                    }
                    else
                    {
                        drinkTally.Add(drinkKey, 1);
                        newOrderItemList.Add(item);
                    }
                }
                else
                {
                    newOrderItemList.Add(item);
                }
            }
           foreach (var item in newOrderItemList)
            {
                if (item is Drink)
                {
                    var drink = (Drink)item;
                    var key = Tuple.Create<DrinkType, DrinkSize>(drink.DrinkType, drink.DrinkSize);
                    drink.ItemCount = drinkTally[key];
                }
            }
            OrderItems = newOrderItemList;
        }

        internal void DeleteOrderItem(int orderItemNumber)
        {
            var itemToRemove = OrderItems.SingleOrDefault(o => o.OrderItemNumber == orderItemNumber);
            if (itemToRemove != null)
            {
                OrderItems.Remove(itemToRemove);
            }
        }
    }
}
