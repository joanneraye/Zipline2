using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;
using Zipline2.Models;

namespace Zipline2.BusinessLogic.WcfRemote
{
    public static class DataConversion
    {

        //public static Order ConvertDbCheckToOrder(DBCheck check, decimal tableId, decimal[] guestIds)
        //{    
        //    //var openOrder = new Order(tableId)
        //    //{
        //    //    IsTakeout = false,
        //    //    GuestIds = guestIds
        //    //};
        //    //foreach (var item in check.Items)
        //    //{
        //    //    var openOrderItem = OrderItemFactory.GetOrderItem(item);
        //    //    openOrder.AddItemToOrder(openOrderItem);
        //    //}
        //    //return openOrder;
        //}

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

            Drink drink =  MenuDrinks.GetDrinkFromMenu(oldGuestItem.ID, drinkSize);
            var newdrink = drink.GetClone();
            newdrink.DbItemId = oldGuestItem.ID;
            newdrink.WasSentToKitchen = oldGuestItem.OrderSent;
            newdrink.DbOrderId = (int)oldGuestItem.OrderID;
            newdrink.ItemCount = 1;
            //newdrink.UpdateItemTotal();
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

        internal static List<OrderItem> GetLunchSpecial(GuestComboItem guestComboItem)
        {
            throw new NotImplementedException();
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

        public static Salad GetSalad(GuestItem dbGuestItem)
        {
            var sizeOfSalad = SaladSize.None;
            switch (dbGuestItem.SelectSizeID)
            {
                case 7:
                    sizeOfSalad = SaladSize.Small;
                    break;
                case 8:
                    sizeOfSalad = SaladSize.Large;
                    break;
                case 14:
                    sizeOfSalad = SaladSize.LunchSpecial;
                    break;
            }
            var salad = new Salad(sizeOfSalad);
            if (dbGuestItem.Mods.Count > 0)
            {
                GetSaladToppings(dbGuestItem, ref salad);
            }
            salad.PopulateBasePrice();
            salad.PopulateDisplayName();
            salad.PopulatePricePerItem();
            salad.DbItemId = dbGuestItem.ID;
            salad.WasSentToKitchen = dbGuestItem.OrderSent;
            salad.DbOrderId = (int)dbGuestItem.OrderID;
            salad.ItemCount = 1;
            return salad;

        }

        public static Pizza GetPizza(GuestItem dbGuestItem)
        {
            var pizza = new Pizza();
            
            switch (dbGuestItem.ID)
            {
                case 57:
                    if (dbGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (dbGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (dbGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (dbGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    if (dbGuestItem.SelectSizeID == 90) pizza.PizzaType = PizzaType.LunchSpecialSlice;

                    break;
                case 59:
                    if (dbGuestItem.SelectSizeID == 9) pizza.PizzaType = PizzaType.ThinSlice;
                    if (dbGuestItem.SelectSizeID == 10) pizza.PizzaType = PizzaType.Indy;
                    if (dbGuestItem.SelectSizeID == 11) pizza.PizzaType = PizzaType.Medium;
                    if (dbGuestItem.SelectSizeID == 12) pizza.PizzaType = PizzaType.Large;
                    if (dbGuestItem.SelectSizeID == 22) pizza.PizzaType = PizzaType.Mfp;
                    if (dbGuestItem.SelectSizeID == 23) pizza.PizzaType = PizzaType.SatchPan;
                    pizza.MajorMamaInfo = MajorOrMama.Major;
                    pizza.Toppings.AddMajorToppings();
                    break;
                case 60:
                    pizza.PizzaType = PizzaType.Mfp;
                    break;
                case 61:
                    pizza.PizzaType = PizzaType.SatchPan;
                    break;
                //case 51:
                //    pizza.PizzaType = PizzaType.Calzone;
                //    break;
                //case 54:
                //    pizza.PizzaType = PizzaType.CalzoneSteakAndCheese;
                //    break;
                //case 56:
                //    pizza.PizzaType = PizzaType.Calzone;
                //    pizza.MajorMamaInfo = MajorOrMama.Major;
                //    pizza.Toppings.AddMajorToppings();
                //    break;
                default:
                    Console.WriteLine("***Debug JOANNE***PIZZA TYPE FROM SERVER NOT FOUND FOR GuestItem ID " + dbGuestItem.ID + " & SizeID: " + dbGuestItem.SelectSizeID);
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
            //pizza.UpdateItemTotal();
           
            return pizza;
        }

        public static Calzone GetCalzone(GuestItem dbGuestItem)
        {
            var calzone = new Calzone();
            switch (dbGuestItem.ID)
            {
                case 51:
                    calzone.CalzoneType = CalzoneType.RicottaMozarella;
                    break;
                case 52:
                    calzone.CalzoneType = CalzoneType.HotRope;
                    break;
                case 53:
                    calzone.CalzoneType = CalzoneType.PBJ;
                    break;
                case 54:
                    calzone.CalzoneType = CalzoneType.SteakAndCheese;
                    break;
                case 56:
                    calzone.CalzoneType = CalzoneType.Major;
                    calzone.MajorMamaInfo = MajorOrMama.Major;
                    calzone.Toppings.AddMajorToppings();
                    break;
                default:
                    Console.WriteLine("***Debug JOANNE***calzone TYPE FROM SERVER NOT FOUND FOR GuestItem ID " + dbGuestItem.ID);
                    break;

            }
            if (dbGuestItem.Mods.Count > 0)
            {
                GetCalzoneToppings(dbGuestItem, ref calzone);
            }
            calzone.PopulateBasePrice();
            calzone.PopulateDisplayName();
            calzone.PopulatePricePerItem();
            calzone.DbItemId = dbGuestItem.ID;
            calzone.WasSentToKitchen = dbGuestItem.OrderSent;
            calzone.DbOrderId = (int)dbGuestItem.OrderID;
            calzone.ItemCount = 1;
            return calzone;
        }

        private static void GetSaladToppings(GuestItem oldGuestItem, ref Salad salad)
        {
            foreach (GuestModifier mod in oldGuestItem.Mods)
            {
                Topping newTopping = new Topping(ToppingName.Unknown);
                if (DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    var ToppingName = DataBaseDictionaries.DbIdToppingDictionary[mod.ID];
                    if (MenuFood.SaladToppings.ContainsKey(ToppingName))
                    {
                        newTopping = MenuFood.SaladToppings[ToppingName].GetClone();
                    }
                    else
                    {
                        Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY DOES NOT CONTAIN: " + ToppingName);
                        continue;
                    }
                   
                    if (mod.State == "Lite")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.LightTopping;
                    }
                    else if (mod.State == "" || (mod.State == "Plus" && mod.Count > 0))
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
                        newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                        //TODO:  ??  At present, default toppings aren't included with salads.
                        //pizza.Toppings.RemoveTopping(newTopping.ToppingName);                      
                    }
                }
                else
                {
                    Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY Salad ITEM NOT FOUND: " + mod.Name + mod.ID);
                }
               
                salad.Toppings.AddTopping(newTopping, false);
            }

            salad.Toppings.UpdateToppingsTotal();
        }

        private static void GetPizzaToppings(GuestItem oldGuestItem, ref Pizza pizza)
        {
            foreach (GuestModifier mod in oldGuestItem.Mods)
            {
                bool addThisModAsTopping = true;
                Topping newTopping = new Topping(ToppingName.Unknown);
                var wholeOrHalf = ToppingWholeHalf.Whole;
                var halfOpposite = ToppingWholeHalf.Whole;
                if (DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    var ToppingName = DataBaseDictionaries.DbIdToppingDictionary[mod.ID];
                    if (MenuFood.PizzaToppings.ContainsKey(ToppingName))
                    {
                        newTopping = MenuFood.PizzaToppings[ToppingName].GetClone();
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
                    else if (mod.State == "" || (mod.State == "Plus" && mod.Count > 1))
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ExtraTopping;
                        newTopping.Count = (int)mod.Count;
                    }
                    else if (mod.State == "Plus" && mod.Name.ToUpper() == "NO CHEESE")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                        addThisModAsTopping = true;
                    }
                    else if (mod.State == "Side")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ToppingOnSide;
                    }
                    

                    if (mod.State == "No")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                        addThisModAsTopping = true;

                        if (pizza.MajorMamaInfo == MajorOrMama.Major)
                        {
                            if (wholeOrHalf == ToppingWholeHalf.Whole)
                            {
                                pizza.Toppings.RemoveTopping(newTopping.ToppingName);
                            }
                            else
                            {
                                pizza.Toppings.ChangeToppingToHalf(newTopping.ToppingName, halfOpposite);
                            }
                        }
                        else 
                        {
                            //Try to remove topping just in case it is there, but will probably
                            //be something like no cheese.
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
                    pizza.Toppings.AddTopping(newTopping, false);
                }
            }
            
            pizza.Toppings.UpdateToppingsTotal();
        }
        private static void GetCalzoneToppings(GuestItem oldGuestItem, ref Calzone calzone)
        {
            foreach (GuestModifier mod in oldGuestItem.Mods)
            {
                bool addThisModAsTopping = true;
                Topping newTopping = new Topping(ToppingName.Unknown);
                if (DataBaseDictionaries.DbIdToppingDictionary.ContainsKey(mod.ID))
                {
                    var ToppingName = DataBaseDictionaries.DbIdToppingDictionary[mod.ID];
                    if (MenuFood.PizzaToppings.ContainsKey(ToppingName))
                    {
                        newTopping = MenuFood.PizzaToppings[ToppingName].GetClone();
                    }
                    else
                    {
                        addThisModAsTopping = false;
                        Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY DOES NOT CONTAIN: " + ToppingName);
                        continue;
                    }
                   
                    if (mod.State == "Lite")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.LightTopping;
                    }
                    else if (mod.State == "" || (mod.State == "Plus" && mod.Count > 1))
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ExtraTopping;
                        newTopping.Count = (int)mod.Count;
                    }
                    else if (mod.State == "Plus" && mod.Name.ToUpper() == "NO CHEESE")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                        addThisModAsTopping = true;
                    }
                    else if (mod.State == "Side")
                    {
                        newTopping.ToppingModifier = ToppingModifierType.ToppingOnSide;
                    }

                    if (mod.State == "No")
                    {
                        if (calzone.MajorMamaInfo == MajorOrMama.Major)
                        {
                            newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                            calzone.Toppings.RemoveTopping(newTopping.ToppingName);
                            addThisModAsTopping = true;
                        }
                        else
                        {
                            newTopping.ToppingModifier = ToppingModifierType.NoTopping;
                            //Try to remove topping just in case it is there, but will probably
                            //be something like no cheese.
                            calzone.Toppings.RemoveTopping(newTopping.ToppingName);
                            addThisModAsTopping = true;
                        }
                    }
                }
                else
                {
                    addThisModAsTopping = false;
                    Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + mod.Name + mod.ID);
                }

             
                if (addThisModAsTopping)
                {
                    calzone.Toppings.AddTopping(newTopping, false);
                }
            }

            calzone.Toppings.UpdateToppingsTotal();
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

        internal static Order ConvertDbGuestsToOrder(decimal[] guestIds, List<GuestItem> guestItems, List<GuestComboItem> guestComboItems, decimal tableId, int tableIndex)
        {
            var openOrder = new Order(tableId, tableIndex)
            {
                IsTakeout = false,
                AllItemsSent = true,
                GuestIds = guestIds
            };
            foreach (var guestItem in guestItems)
            {
                var openOrderItem = GetOrderItem(guestItem);
                if (!openOrderItem.WasSentToKitchen)
                {
                    openOrder.AllItemsSent = false;
                }
                openOrder.AddItemToOrder(openOrderItem);
            }

            foreach (var guestComboItem in guestComboItems)
            {
                var lunchSpecialItems = GetLunchSpecialOrderItems(guestComboItem);
                if (lunchSpecialItems != null)
                {
                    foreach (var lunchSpecialItem in lunchSpecialItems)
                    {
                        if (!lunchSpecialItem.WasSentToKitchen)
                        {
                            openOrder.AllItemsSent = false;
                        }
                        openOrder.AddItemToOrder(lunchSpecialItem);
                    }
                }                
            }

            return openOrder;
        }

        public static OrderItem GetOrderItem(GuestItem oldGuestItem)
        {
            OrderItem thisOrderItem = new Drink();
            switch (oldGuestItem.SuperCategoryID)
            {
                case 1:
                    thisOrderItem = GetPizza(oldGuestItem);
                    break;
                case 2:
                    thisOrderItem = GetCalzone(oldGuestItem);
                    break;
                case 3:
                    thisOrderItem = GetSalad(oldGuestItem);
                    break;
                case 4:
                    thisOrderItem = GetDrink(oldGuestItem);
                    break;
                    //case 5:
                    //    //Create Dessert
                    //    break;
                    //case 6:  Merch
                    //case 7:  Sides
                    //case 8:  Variable??
            }

            return thisOrderItem;
        }

        public static List<OrderItem> GetLunchSpecialOrderItems(GuestComboItem guestComboItem)
        {
            bool foundSalad = false;
            bool foundSlice = false;
            var orderItems = new List<OrderItem>();
            OrderItem lunchSpecialPizza = new Pizza();
            OrderItem lunchSpecialSalad = new Salad(SaladSize.LunchSpecial);
            OrderItem slice = new Pizza() { PizzaType = PizzaType.LunchSpecialSlice };
            foreach (var item in guestComboItem.ComboGuestItems)
            {
                Guid id = Guid.NewGuid();
                if (item.ID == 57M)
                {
                    foundSlice = true;
                    lunchSpecialPizza = GetPizza(item);
                    lunchSpecialPizza.PartOfCombo = true;
                    lunchSpecialPizza.ComboId = id;
                }
                else if (item.ID == 50M)
                {
                    foundSalad = true;
                    lunchSpecialSalad = GetSalad(item);
                    lunchSpecialSalad.PartOfCombo = true;
                    lunchSpecialSalad.ComboId = id;
                }
            }
            if (foundSlice && foundSalad)
            {
                orderItems.Add(lunchSpecialSalad);
                orderItems.Add(lunchSpecialPizza);
                return orderItems;
            }
            return null;
        }
    }
}
