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

        public static Order ConvertDbCheckToOrder(DBCheck check, decimal tableId, decimal[] guestIds)
        {    
            var openOrder = new Order(tableId)
            {
                IsTakeout = false,
                GuestIds = guestIds
            };
            foreach (var item in check.Items)
            {
                var openOrderItem = OrderItemFactory.GetOrderItem(item);
                openOrder.AddItemToOrder(openOrderItem, false);
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

        public static List<GuestModifier> GetDbMods(List<Topping> currentToppings)
        {
            List<GuestModifier> mods = new List<GuestModifier>();
            foreach (var topping in currentToppings)
            {
                mods.Add(GetMod(topping));
            }
            return mods;
        }

        public static GuestModifier GetNoMod(Topping topping)
        {
            GuestModifier newGuestMod = GetMod(topping);
            newGuestMod.State = "No";
            return newGuestMod;
        }

       
        public static GuestModifier GetMod(Topping topping)
        {
            DBModifier databaseMod = new DBModifier();
            if (DataBaseDictionaries.PizzaToppingsDictionary.ContainsKey(topping.DbItemId))
            {
                databaseMod = DataBaseDictionaries.PizzaToppingsDictionary[topping.DbItemId];
            }

            GuestModifier newGuestMod = new GuestModifier(databaseMod);

            //TODO:  See the following from POSTabletClient ModifiersPage.xaml.cs:
            //I don't have buttons for lite, no, Side, plus, and extra button yet....
            //if (extraButton.IsChecked == true)
            //    guestMod.Multiplier = 2;

            //if (liteButton.IsChecked == true)
            //    guestMod.State = "Lite";
            //else if (noButton.IsChecked == true)
            //    guestMod.State = "No";
            //else if (sideButton.IsChecked == true)
            //    guestMod.State = "Side";
            //else
            //    guestMod.State = "Plus";

            newGuestMod.Half = "Whole";
            if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfA)
            {
                newGuestMod.Half = "Half_A";
            }
            else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfB)
            {
                newGuestMod.Half = "Half_B";
            }

            newGuestMod.isDefault = false;
            newGuestMod.Priority = databaseMod.Priority;

            return newGuestMod;
        }

        public static Pizza GetPizza(GuestItem dbGuestItem)
        {
            var pizza = new Pizza();
            pizza.Base = PizzaBase.Regular;
            switch (dbGuestItem.ID)
            {
                case 57:
                    if (dbGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (dbGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (dbGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (dbGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    break;
                case 59:
                    if (dbGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (dbGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (dbGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (dbGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    pizza.MajorMamaInfo = MajorOrMama.Major;
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
                    pizza.Toppings.AddMajorToppings();
                    break;
            }
            if (dbGuestItem.Mods.Count > 0)
            {
                GetPizzaToppings(dbGuestItem, ref pizza);
            }
            pizza.PopulateBasePrice();
            pizza.PopulateDisplayName();
            pizza.PopulatePricePerItem();
            pizza.DbItemId = dbGuestItem.ID;
            pizza.WasSentToKitchen = dbGuestItem.OrderSent;
            pizza.DbOrderId = (int)dbGuestItem.OrderID;
            pizza.ItemCount = 1;
            pizza.UpdateItemTotal();
           
            return pizza;
        }

        private static void GetPizzaToppings(GuestItem oldGuestItem, ref Pizza pizza)
        {
            //TODO:  Not yet accounting for mod.State
          
            foreach (GuestModifier mod in oldGuestItem.Mods)
            {
                Topping topping = new Topping(ToppingName.Unknown);
                topping.ToppingWholeHalf = ToppingWholeHalf.Whole;
                topping.Count = (int)mod.Count;
                if (DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    topping.ToppingName = DataBaseDictionaries.DbIdToppingDictionary[mod.ID];
                    switch (mod.Half)
                    {
                        case "Half_A":
                        case "Half A":
                            topping.ToppingWholeHalf = ToppingWholeHalf.HalfA;
                            topping.ToppingDisplayName = "Half A - " + topping.ToppingDisplayName;
                            break;
                        case "Half_B":
                        case "Half B":
                            topping.ToppingWholeHalf = ToppingWholeHalf.HalfB;
                            topping.ToppingDisplayName = "Half B - " + topping.ToppingDisplayName;
                            break;
                    }
                }

                pizza.Toppings.AddTopping(topping);
                
                if (mod.ID == 50)
                {
                    pizza.ChangePizzaBase(PizzaBase.Pesto, false);
                }
                else if (mod.ID == 51)
                {
                    pizza.ChangePizzaBase(PizzaBase.White, false);
                }
                else if (DataBaseDictionaries.ToppingDbIdDictionary.ContainsKey(ToppingName.Deep) && 
                          mod.ID == DataBaseDictionaries.ToppingDbIdDictionary[ToppingName.Deep])
                {
                    pizza.ChangePizzaToDeep();
                }
            }
            
            pizza.Toppings.UpdateToppingsTotal();
            pizza.UpdateItemTotal();
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
            var openOrder = new Order(tableId)
            {
                IsTakeout = false,
                AllItemsSent = true
            };

            foreach (var guestItem in guestItems)
            {
                var openOrderItem = OrderItemFactory.GetOrderItem(guestItem);
                if (!openOrderItem.WasSentToKitchen)
                {
                    openOrder.AllItemsSent = false;
                }
                openOrder.AddItemToOrder(openOrderItem, false);
            }

            if (guestItems.Count > 1)
            {
                openOrder.GuestIds[0] = guestItems[0].ID;
                openOrder.GuestIds[1] = guestItems[1].ID;
            }

            return openOrder;
        }
    }
}
