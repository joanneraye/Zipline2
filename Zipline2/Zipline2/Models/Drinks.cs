using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public static class Drinks
    {
        public static List<Drink> SoftDrinks { get; set; }
        public static List<Drink> DraftBeers { get; set; }
        public static List<Drink> BottledBeers { get; set; }
        public static List<Drink> RedWines { get; set; }
        public static List<Drink> WhiteWines { get; set; }
        public static List<Drink> HouseWines { get; set; }
        public static List<Drink> HotDrinks { get; set; }
        public static List<Drink> GetDrinksList(DrinkCategory drinkCategory)
        {
            switch (drinkCategory)
            {
                case DrinkCategory.SoftDrink:
                    if (SoftDrinks == null || SoftDrinks.Count <= 0)
                    {
                        CreateSoftDrinks();
                    }
                    return SoftDrinks;
                case DrinkCategory.DraftBeer:
                    if (DraftBeers == null || DraftBeers.Count <= 0)
                    {
                        CreateDraftBeers();
                    }
                    return DraftBeers;
                case DrinkCategory.BottledBeer:
                    if (BottledBeers == null || BottledBeers.Count <= 0)
                    {
                        CreateBottledBeers();
                    }
                    return BottledBeers;
                case DrinkCategory.RedWine:
                    if (RedWines == null || RedWines.Count <= 0)
                    {
                        CreateRedWines();
                    }
                    return RedWines;
                case DrinkCategory.WhiteWine:
                    if (WhiteWines == null || WhiteWines.Count <= 0)
                    {
                        CreateWhiteWines();
                    }
                   return WhiteWines;
                case DrinkCategory.HouseWine:
                    if (HouseWines == null || HouseWines.Count <= 0)
                    {
                        CreateHouseWines();
                    }
                    return HouseWines;
                case DrinkCategory.HotDrink:
                    if (HotDrinks == null || HotDrinks.Count <= 0)
                    {
                        CreateHotDrinks();
                    }
                    return HotDrinks;
            }
            return new List<Drink>();
        }

        private static void CreateSoftDrinks()
        {
            SoftDrinks = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplaySoftDrinkNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value,
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.SoftDrink,
                    DrinkSize = DrinkSize.JustOneSize
                };
                SoftDrinks.Add(thisDrink);
            }
        }
        private static void CreateDraftBeers()
        {
            DraftBeers = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayDraftBeerNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.DraftBeer
                };
                if (drinks.Key == DrinkType.EmployeeBeer ||
                    drinks.Key == DrinkType.Beer12Oz)
                {
                    thisDrink.ItemName = drinks.Value;
                    thisDrink.DrinkSize = DrinkSize.JustOneSize;
                    DraftBeers.Add(thisDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Pint";
                    thisDrink.DrinkSize = DrinkSize.Pint;
                    DraftBeers.Add(thisDrink);

                    Drink pitcherDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Pitcher",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.DraftBeer,
                        DrinkSize = DrinkSize.Pitcher
                    };
                    pitcherDrink.PricePerItem *= 3;
                    DraftBeers.Add(pitcherDrink);
                }
            }
        }

        private static void CreateBottledBeers()
        {
            BottledBeers = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayBottledBeerNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value,
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.BottledBeer,
                    DrinkSize = DrinkSize.JustOneSize
                };
                BottledBeers.Add(thisDrink);
            }
        }
        private static void CreateRedWines()
        {
            RedWines = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayRedWineNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {  
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.RedWine
                };
                if (drinks.Key == DrinkType.LeeseFitchCab ||
                    drinks.Key == DrinkType.AlverdiSangiovese)
                {
                    thisDrink.ItemName = drinks.Value +" - Glass";
                    thisDrink.DrinkSize = DrinkSize.Glass;
                    RedWines.Add(thisDrink);

                    Drink bottleDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Bottle",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.RedWine
                    };
                    bottleDrink.DrinkSize = DrinkSize.Bottle;
                    bottleDrink.PricePerItem *= 3;
                    RedWines.Add(bottleDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Bottle";
                    thisDrink.DrinkSize = DrinkSize.Bottle;
                    RedWines.Add(thisDrink);
                }
            }
        }
        private static void CreateWhiteWines()
        {
            WhiteWines = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayWhiteWineNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.WhiteWine
                };
                if (drinks.Key == DrinkType.DouglasGreenSb)
                {
                    thisDrink.ItemName = drinks.Value + " - Bottle";
                    thisDrink.DrinkSize = DrinkSize.Bottle;
                    WhiteWines.Add(thisDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Glass";
                    thisDrink.DrinkSize = DrinkSize.Glass;
                    WhiteWines.Add(thisDrink);

                    Drink bottleDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Bottle",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.WhiteWine,
                        DrinkSize = DrinkSize.Bottle
                    };
                    bottleDrink.PricePerItem *= 3;
                    WhiteWines.Add(bottleDrink);
                }
            }
        }
        private static void CreateHouseWines()
        {
            HouseWines = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayHouseWineNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value,
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.HouseWine,
                    DrinkSize = DrinkSize.JustOneSize
                };
                HouseWines.Add(thisDrink);
            }
        }
        private static void CreateHotDrinks()
        {
            HotDrinks = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayHotDrinkNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value,
                    ItemCount = 0,
                    DrinkCategory = DrinkCategory.HotDrink,
                    DrinkSize = DrinkSize.JustOneSize
                };
                HotDrinks.Add(thisDrink);
            }
        }
    }
}
