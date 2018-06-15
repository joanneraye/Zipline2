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
            else
            {
                Console.WriteLine("***Debug JOANNE***Topping DB ID not found: " + topping.DbItemId);
            }

            GuestModifier newGuestMod = new GuestModifier(databaseMod);
            newGuestMod.State = "Plus";
            switch (topping.ToppingModifier)
            {
                case (ToppingModifierType.ExtraTopping):
                    newGuestMod.Multiplier = topping.Count;
                    break;
                case (ToppingModifierType.NoTopping):
                    newGuestMod.State = "No";
                    break;
                case (ToppingModifierType.LightTopping):
                    newGuestMod.State = "Lite";
                    break;
                case (ToppingModifierType.ToppingOnSide):
                    newGuestMod.State = "Side";
                    break;
            }

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
                    if (dbGuestItem.SelectSizeID == 90) pizza.PizzaType = PizzaType.ThinSlice;

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
                bool addThisModAsTopping = true;
                Topping newTopping = new Topping(ToppingName.Unknown);
                var wholeOrHalf = ToppingWholeHalf.Whole;
                var halfOpposite = ToppingWholeHalf.Whole;
                if (DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    var ToppingName = DataBaseDictionaries.DbIdToppingDictionary[mod.ID];
                    if (App.AllToppings.ContainsKey(ToppingName))
                    {
                        newTopping = App.AllToppings[ToppingName].GetClone();
                    }
                    else
                    {
                        addThisModAsTopping = false;
                        Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY DOES NOT CONTAIN: " + ToppingName);
                        continue;
                    }
                    switch (mod.Half)
                    {
                        case "Half_A":
                        case "Half A":
                            wholeOrHalf = ToppingWholeHalf.HalfA;
                            halfOpposite = ToppingWholeHalf.HalfB;
                            break;
                        case "Half_B":
                        case "Half B":
                            wholeOrHalf = ToppingWholeHalf.HalfB;
                            halfOpposite = ToppingWholeHalf.HalfA;
                            break;
                    }
                    if (DataBaseDictionaries.ToppingDbIdDictionary.ContainsKey(ToppingName.HalfMajor) &&
                          mod.ID == DataBaseDictionaries.ToppingDbIdDictionary[ToppingName.HalfMajor])
                    {
                        addThisModAsTopping = false;
                        if (wholeOrHalf == ToppingWholeHalf.Whole)
                        {
                            wholeOrHalf = ToppingWholeHalf.HalfA;
                        }
                        
                        pizza.Toppings.AddMajorToppingsToHalf(wholeOrHalf);
                    }

                    if (mod.State == "Lite")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.LightTopping;
                    }
                    else if (mod.State == "Plus" && mod.Count > 1)
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ExtraTopping;
                        newTopping.Count = (int)mod.Count;
                    }
                    else if (mod.State == "Side")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ToppingOnSide;
                    }
                    

                    if (mod.State == "No")
                    {
                        if (pizza.MajorMamaInfo == MajorOrMama.Major)
                        {
                            if (wholeOrHalf == ToppingWholeHalf.Whole)
                            {
                                pizza.Toppings.RemoveTopping(newTopping.ToppingName);
                                addThisModAsTopping = false;
                            }
                            else
                            {
                                pizza.Toppings.ChangeToppingToHalf(newTopping.ToppingName, halfOpposite);
                                addThisModAsTopping = false;
                            }
                        }
                        else 
                        {
                            newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                            pizza.Toppings.RemoveTopping(newTopping.ToppingName);
                        }
                    }
                }
                else
                {
                    addThisModAsTopping = false;
                    if (mod.ID != 50 && mod.ID != 51)
                    {
                        Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
                    }
                }
                
                if (mod.ID == 50)
                {
                    pizza.ChangePizzaBase(PizzaBase.Pesto, false);
                    addThisModAsTopping = false;
                }
                else if (mod.ID == 51)
                {
                    pizza.ChangePizzaBase(PizzaBase.White, false);
                    addThisModAsTopping = false;
                }
                else if (DataBaseDictionaries.ToppingDbIdDictionary.ContainsKey(ToppingName.Deep) && 
                          mod.ID == DataBaseDictionaries.ToppingDbIdDictionary[ToppingName.Deep])
                {
                    pizza.ChangePizzaToDeep();
                    addThisModAsTopping = false;
                }
                if (addThisModAsTopping)
                {
                    newTopping.ToppingWholeHalf = wholeOrHalf;
                    newTopping.ChangeToppingDisplayNameHalf(wholeOrHalf);
                    pizza.Toppings.AddTopping(newTopping, false);
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
                openOrder.AddItemToOrder(openOrderItem);
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
