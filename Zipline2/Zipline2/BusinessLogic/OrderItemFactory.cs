using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Pages;
using Staunch.POS.Classes;
using Zipline2.BusinessLogic.WcfRemote;

namespace Zipline2.BusinessLogic
{
    /// <summary>
    /// Instantiates objects derrived from OrderItems.
    /// </summary>
    public sealed class OrderItemFactory
    {
        public OrderItemFactory()
        {

        }

        public static OrderItem GetOrderItem(OrderItem partialOrderItem)
        {
            if (partialOrderItem is Pizza)
            {
                return CreatePizza(partialOrderItem);
            }
            else if (partialOrderItem is Drink)
            {
                return CreateDrink(partialOrderItem);
            }
            return null;
           
        }

        public static OrderItem GetOrderItem(GuestItem oldGuestItem)
        {
            OrderItem thisOrderItem = new Drink();
            switch (oldGuestItem.SuperCategoryID)
            {
                case 1:
                    thisOrderItem = DataConversion.GetPizza(oldGuestItem);
                    break;
                //case 2:
                //    break;
                //case 3:
                //    //Create Salad
                //    break;
                case 4:
                    thisOrderItem = DataConversion.GetDrink(oldGuestItem);
                    break;
                    //case 5:
                    //    //Create Dessert
                    //    break;
                    //TODO:  Others????
            }

            return thisOrderItem;
        }


        private static OrderItem CreatePizza(OrderItem partialDataItem)
        {
            var newPizza = partialDataItem as Pizza;
            newPizza.CompleteOrderItem();
            newPizza.PopulateDisplayName();
            newPizza.PopulatePricePerItem();
            newPizza.UpdateItemTotal();
            return newPizza;
        }
        private static OrderItem CreateDrink(OrderItem partialDataItem)
        {
            var newDrink = partialDataItem as Drink;
            newDrink.CompleteOrderItem();
            return newDrink;
        }
        private static OrderItem CreateDessert(CustomerSelection guiData)
        {
            return new Dessert(guiData);
        }
        private static OrderItem CreateLunchSpecial(CustomerSelection guiData)
        {
            return new LunchSpecial(guiData);
        }
        private static OrderItem CreateMerchandise(CustomerSelection guiData)
        {
            return new Merchandise(guiData);
        }
    }
}
