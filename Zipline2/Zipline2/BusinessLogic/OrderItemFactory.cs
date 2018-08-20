﻿using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Pages;

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

        public static OrderItem GetOrderItem(CustomerSelections guiData)
        {
            switch (guiData.MenuItemGeneralCategory)
            {
                case Enums.MenuCategory.Pizza:
                case Enums.MenuCategory.Calzone:
                    return CreatePizza(guiData);
                case Enums.MenuCategory.Drink:
                    return CreateDrink(guiData);
                case Enums.MenuCategory.Dessert:
                    return CreateDessert(guiData);
                case Enums.MenuCategory.LunchSpecial:
                    return CreateLunchSpecial(guiData);
                case Enums.MenuCategory.Merchandise:
                    return CreateMerchandise(guiData);
                default:
                    return null;
            }
        }

        private static OrderItem CreatePizza(CustomerSelections guiData)
        {
            return new Pizza(guiData);
            
        }
        private static OrderItem CreateDrink(CustomerSelections guiData)
        {
            return new Drink(guiData);
        }
        private static OrderItem CreateDessert(CustomerSelections guiData)
        {
            return new Dessert(guiData);
        }
        private static OrderItem CreateLunchSpecial(CustomerSelections guiData)
        {
            return new LunchSpecial(guiData);
        }
        private static OrderItem CreateMerchandise(CustomerSelections guiData)
        {
            return new Merchandise(guiData);
        }
    }
}
