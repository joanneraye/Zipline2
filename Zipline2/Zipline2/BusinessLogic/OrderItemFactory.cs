using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.Pages;

namespace Zipline2.BusinessLogic
{
    public sealed class OrderItemFactory
    {
        //This is a singleton class:
        private static readonly Lazy<OrderItemFactory> lazy =
            new Lazy<OrderItemFactory>(() => new OrderItemFactory());
        public static OrderItemFactory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private OrderItemFactory()
        {

        }

        public static OrderItem GetOrderItem(CustomerSelections guiData)
        {
            OrderItem thisOrderItem = new OrderItem();
            switch (guiData.MenuItemGeneralCategory)
            {
                case Enums.MenuCategory.Pizza:
                    thisOrderItem = new Pizza(guiData);
                    break;
                case Enums.MenuCategory.Calzone:
                    break;
                case Enums.MenuCategory.Drink:
                    break;
                case Enums.MenuCategory.Dessert:
                    break;
                case Enums.MenuCategory.LunchSpecial:
                    break;
                case Enums.MenuCategory.Merchandise:
                    break;
            }
            return thisOrderItem;
        }
    }
}
