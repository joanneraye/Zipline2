using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.BusinessLogic.WcfRemote
{
    public static class DataConversion
    {

        public static Order ConvertDbCheckToOrder(DBCheck check, decimal tableId)
        {           
            var openOrder = new Order()
            {
                IsTakeout = false,
                TableId = tableId
            };
            foreach (var item in check.Items)
            {
                var openOrderItem = OrderItemFactory.GetOrderItem(item);
                openOrder.AddItemToOrder(openOrderItem);
            }
            return openOrder;
        }

        public static Drink GetDrink(GuestItem oldGuestItem)
        {
            DrinkSize drinkSize = DrinkSize.JustOneSize;
            switch (oldGuestItem.SelectSizeID)
            {
                case 3:
                    drinkSize = DrinkSize.Glass;
                    break;
                case 6:
                    drinkSize = DrinkSize.Bottle;
                    break;
                case 1:
                    drinkSize = DrinkSize.Pint;
                    break;
                case 2:
                    drinkSize = DrinkSize.Pitcher;
                    break;
                default:
                    drinkSize = DrinkSize.JustOneSize;
                    break;
            }

            Drink drink =  Drinks.GetDrinkFromMenu(oldGuestItem.ID, drinkSize);
            var newdrink = drink.GetClone();
            newdrink.DbItemId = oldGuestItem.ID;
            newdrink.WasSentToKitchen = oldGuestItem.OrderSent;
            newdrink.DbOrderId = (int)oldGuestItem.OrderID;
            newdrink.ItemCount = 1;
            newdrink.UpdateItemTotal();
            return newdrink;
        }

        public static Pizza GetPizza(GuestItem oldGuestItem)
        {
            var pizza = new Pizza();
            pizza.Base = PizzaBase.Regular;
            switch (oldGuestItem.ID)
            {
                case 57:
                    if (oldGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (oldGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (oldGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (oldGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    break;
                case 59:
                    if (oldGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (oldGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (oldGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (oldGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    pizza.MajorMamaInfo = MajorOrMama.Major;
                    pizza.Toppings = new Toppings(pizza.PizzaType);
                    pizza.Toppings.AddMajorToppings();
                    break;
                case 60:
                    pizza.PizzaType = PizzaType.Mfp;
                    break;
                case 61:
                    pizza.PizzaType = PizzaType.SatchPan;
                    break;
                case 51:
                    pizza.PizzaType = PizzaType.Calzone;
                    break;
                case 54:
                    pizza.PizzaType = PizzaType.CalzoneSteakAndCheese;
                    break;
                case 56:
                    pizza.PizzaType = PizzaType.Calzone;
                    pizza.MajorMamaInfo = MajorOrMama.Major;
                    pizza.Toppings = new Toppings(pizza.PizzaType);
                    pizza.Toppings.AddMajorToppings();
                    break;
            }
            pizza.PopulateDisplayName();
            pizza.PopulatePricePerItem();
            return pizza;
        }

        public static Table ConvertDbTableToTable(DBTable dbTable)
        {
            return new Table
            {
                IsOccupied = !(dbTable.IsClear),
                TableName = dbTable.Name,
                TableId = dbTable.ID
            };
        }

        internal static Order ConvertDbGuestsToOrder(List<GuestItem> guestItems, decimal tableId)
        {
            var openOrder = new Order()
            {
                IsTakeout = false,
                TableId = tableId,
                AllItemsSent = true
            };

            foreach (var guestItem in guestItems)
            {
                var openOrderItem = OrderItemFactory.GetOrderItem(guestItem);
                if (!openOrderItem.WasSentToKitchen)
                {
                    openOrder.AllItemsSent = false;
                }
                openOrder.AddItemToOrder(openOrderItem);
            }
            //openOrder.CombineLikeItems();
            return openOrder;
        }
    }
}
