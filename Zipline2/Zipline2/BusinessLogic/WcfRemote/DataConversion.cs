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

        public static Order ConvertDbCheckToOrder(DBCheck check, decimal tableId, decimal guestId)
        {    
            var openOrder = new Order()
            {
                IsTakeout = false,
                TableId = tableId,
                GuestId = guestId
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
            pizza.Toppings = GetPizzaToppings(oldGuestItem, ref pizza);
            pizza.PopulateBasePrice();
            pizza.PopulateDisplayName();
            pizza.PopulatePricePerItem();
            pizza.DbItemId = oldGuestItem.ID;
            pizza.WasSentToKitchen = oldGuestItem.OrderSent;
            pizza.DbOrderId = (int)oldGuestItem.OrderID;
            pizza.ItemCount = 1;
            pizza.UpdateItemTotal();
           
            return pizza;
        }

        private static Toppings GetPizzaToppings(GuestItem oldGuestItem, ref Pizza pizza)
        {
            //TODO:  Not yet accounting for mod.State
            var toppings = new Toppings(pizza.PizzaType);
            foreach (GuestModifier mod in oldGuestItem.Mods)
            {
                Topping topping = new Topping(ToppingName.Unknown);
                topping.ToppingWholeHalf = ToppingWholeHalf.Whole;
                topping.Count = (int)mod.Count;
                if (Toppings.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    topping.ToppingName = Toppings.DbIdToppingDictionary[mod.ID];
                    switch (mod.Half)
                    {
                        case "Half_A":
                        case "Half A":
                            topping.ToppingWholeHalf = ToppingWholeHalf.HalfA;
                            break;
                        case "Half_B":
                        case "Half B":
                            topping.ToppingWholeHalf = ToppingWholeHalf.HalfB;
                            break;
                    }
                }
                toppings.AddTopping(topping, false);
                if (mod.ID == 50)
                {
                    pizza.ChangePizzaBase(PizzaBase.Pesto, false);
                }
                else if (mod.ID == 51)
                {
                    pizza.ChangePizzaBase(PizzaBase.White, false);
                }
                else if (Toppings.ToppingDbIdDictionary.ContainsKey(ToppingName.Deep) && 
                          mod.ID == Toppings.ToppingDbIdDictionary[ToppingName.Deep])
                {
                    pizza.ChangePizzaToDeep();
                }
            }
            
            toppings.UpdateToppingsTotal();
            return toppings;
        }

        internal static DBTable ConvertOrderToDbTable(Order orderToSend, decimal guestId, bool sendOrderToKitchen = false)
        {
            //Create Guest_DB object.
            var guestDB = new Staunch.POS.Classes.Guest_DB()
            {
                ComboItems = new List<GuestComboItem>(),
                Items = new List<GuestItem>(),
                TableID = orderToSend.TableId,
                ID = guestId
            };

            //Create DBItems for Guest_DB object.
            foreach (var orderItem in orderToSend.OrderItems)
            {
                var keysTuple = orderItem.GetMenuDbItemKeys();
                var dbItem = new DBItem();
                foreach (var menuItem in DataBaseDictionaries.MenuDictionary[keysTuple.Item1])
                {
                    if (menuItem.ID == keysTuple.Item2)
                    {
                        dbItem = menuItem;
                    }
                }

                if (orderItem.DbOrderId <= 0)
                {
                    orderItem.DbOrderId = -1;
                }
                
                GuestItem guestItem = orderItem.CreateGuestItem(dbItem, orderItem.DbOrderId);
                guestItem.OrderSent = sendOrderToKitchen;
                guestDB.Items.Add(guestItem);
            }

            //Add guestDB just created to Guests of new DBTable object.
            return new DBTable()
            {
                ID = OrderManager.Instance.GetCurrentTable().TableId,
                Guests = new List<Staunch.POS.Classes.Guest_DB>()
                {
                    guestDB
                }
            };
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

            if (guestItems.Count > 0)
            {
                openOrder.GuestId = guestItems[0].ID;
            }

            return openOrder;
        }
    }
}
