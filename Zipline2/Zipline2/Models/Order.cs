using SQLite;
using System;
using System.Collections.Generic;
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
        private int SpecialSaladCount;
        private int SliceCount;
        public int OrderNumberId { get; set; }

        private List<OrderItem> orderItems;
        public List<OrderItem> OrderItems
        {
            get
            {
                return orderItems;
            }
            set
            {
                SetProperty(ref orderItems, value);
            }
        }
        
        public decimal SubTotal { get; set; }
       
        public decimal Tax { get; set; }
       
        public decimal Total { get; set; }

     
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
            SliceCount = 0;
            SpecialSaladCount = 0;
            IsTakeout = false;
            TableId = tableId;
            TableIndexInAllTables = tableIndex;
        }

        private void UpdateOrderTotals()
        {
            SubTotal = 0;
            //int lunchSpecialCount = 0;
            //if (SliceCount > 0 && SpecialSaladCount > 0)
            //{
            //    if (SliceCount == SpecialSaladCount)
            //    {
            //        lunchSpecialCount = SliceCount;
            //    }
            //    else
            //    {
            //        lunchSpecialCount = Math.Min(SliceCount, SpecialSaladCount);
            //    }
            //}

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
        public void AddItemToOrder(OrderItem item)
        {
            bool addItemToOrder = true;
            if (item != null)
            {
                if (item is Drink)
                {
                    Drink drinkToAdd = (Drink)item;
                    var beforeOrderItems = OrderItems;
                    if (UpdateDrinkIfAlreadyOnOrder(drinkToAdd))
                    {
                        addItemToOrder = false;
                    }
                }

                if (addItemToOrder)
                {
                    OrderItems.Add(item);
                }

                //Check for lunch special.
                //if (item is Pizza)
                //{
                //    Pizza thisPizza = (Pizza)item;
                //    if (thisPizza.PizzaType == PizzaType.ThinSlice)
                //    {
                //        //SliceCount++;
                //    }
                //}
                //else if (item is Salad)
                //{
                //    Salad thisSalad = (Salad)item;
                //    if (thisSalad.SizeOfSalad == SaladSize.LunchSpecial)
                //    {
                //        //SpecialSaladCount++;
                //    }
                //}


                UpdateOrderTotals();
            }
        }

        public async Task UpdateOrderOnServerAsync()
        {
            await WcfServicesProxy.Instance.UpdateOrderAsync(this);
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
                        orderItem.ItemCount++;
                        //orderItem.UpdateItemTotal();
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
        
    }
}
