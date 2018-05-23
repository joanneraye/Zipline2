using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Pages;
using Staunch.POS.Classes;

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
            //switch (guiData.MenuItemGeneralCategory)
            //{
            //    case Enums.MenuCategory.Pizza:
            //    case Enums.MenuCategory.Calzone:
            //        return CreatePizza(guiData);
            //    //case Enums.MenuCategory.Drink:
            //    //    return CreateDrink(guiData);
            //    case Enums.MenuCategory.Dessert:
            //        return CreateDessert(guiData);
            //    case Enums.MenuCategory.LunchSpecial:
            //        return CreateLunchSpecial(guiData);
            //    case Enums.MenuCategory.Merchandise:
            //        return CreateMerchandise(guiData);
            //    default:
            //        return null;
            //}
        }

        public static OrderItem GetOrderItem(GuestItem oldGuestItem)
        {
            switch (oldGuestItem.SuperCategoryID)
            {
                case 1:
                    //Create Pizza or Major Pizza
                    return new Pizza();
                //case 2:
                //    break;
                //case 3:
                //    //Create Salad
                //    break;
                case 4:
                    return new Drink();
                //case 5:
                //    //Create Dessert
                //    break;
                //TODO:  Others????
            }
            return new Drink();
        }


        private static OrderItem CreatePizza(OrderItem partialDataItem)
        {
            var newPizza = partialDataItem as Pizza;
            newPizza.CompleteOrderItem();
            return newPizza;
        }
        private static OrderItem CreateDrink(OrderItem partialDataItem)
        {
            var newDrink = partialDataItem as Drink;
            if (newDrink.CompleteOrderItem())
            {
                return newDrink;
            }
            return null;
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
