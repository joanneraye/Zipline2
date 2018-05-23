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
        private static Dictionary<DrinkType, decimal> dbItemIdDictionary;
        private static Dictionary<DrinkType, decimal> DbItemIdDictionary
        {
            get
            {
                if (dbItemIdDictionary == null)
                {
                    CreateDbItemIdDictionary();
                }
                return dbItemIdDictionary;
            }
        }
        private static void CreateDbItemIdDictionary()
        {
            dbItemIdDictionary = new Dictionary<DrinkType, decimal>()
            {
                 { DrinkType.Water, 1 },
                { DrinkType.WaterWithLemon, 1 },
                { DrinkType.WaterNoIce, 1 },
                { DrinkType.LolaCola, 4 },
                { DrinkType.StevieZ, 5 },
                { DrinkType.LennieLemonLime, 6 },
                { DrinkType.GinnieGingerAle, 7 },
                { DrinkType.RubyRootBeer, 8 },
                { DrinkType.AppleJuice, 9 },
                { DrinkType.Lemonade, 10 },
                { DrinkType.SweetTea, 11 },
                { DrinkType.SweetArnoldPalmer, 42 },
                { DrinkType.UnsweetArnoldPalmer, 43 },
                { DrinkType.UnsweetTea, 78 },
                { DrinkType.SodaWater, 79 },
                { DrinkType.Milk, 98 },
                { DrinkType.BottledCoke, 161 },
                { DrinkType.HalfNHalfTea, 163 },
                { DrinkType.DietCokeCan, 175 },
                { DrinkType.SodaPitcher, 185 },
                { DrinkType.Flight, 190 },
                { DrinkType.CrystalCreme, 214 },
                { DrinkType.Hefeweizen, 13 },
                { DrinkType.FirstMagnitude72,  199 },
                { DrinkType.EmployeeBeer,  203 },
                { DrinkType.SwampHeadBigNoseIpa,  204 },
                { DrinkType.PilsLagerOrBlondeAle,  207 },
                { DrinkType.Beer12Oz,  212 },
                { DrinkType.Guinness,  17},
                 { DrinkType.OmissionPaleAle,  21 },
                 { DrinkType.Bud,  22 },
                 { DrinkType.BudLight,  23 },
                 { DrinkType.NaGenesee,  211 },
                 { DrinkType.JaiAlaiIpa,  216 },
                 { DrinkType.AlverdiPinotGrigio,  24 },
                 { DrinkType.SilverRidgeChardonnay,  25 },
                 { DrinkType.RaywoodWhiteZin,  30 },
                 { DrinkType.TheRoseGardenRose,  205 },
                 { DrinkType.DouglasGreenSb,  210 },
                 { DrinkType.LeeseFitchCab, 26 },
                 { DrinkType.AlverdiSangiovese,  28 },
                 { DrinkType.CaposaldoChianti,  37 },
                 { DrinkType.ClineZinfandel,  188 },
                 { DrinkType.GreenTruckPetitiSyrah,  195 },
                 { DrinkType.ClayhouseRedBlend,  197 },
                 { DrinkType.YauquenMalbec,  208 },
                 { DrinkType.BodegasLaya,  209 },
                 { DrinkType.RegularCoffee,  74 },
                 { DrinkType.DecafCoffee,  75 },
                 { DrinkType.HotTea,  80 },
                 { DrinkType.HotCocoa, 160 },
                 { DrinkType.WineSpecial10, 150 },
                 { DrinkType.WineSpecial12, 151 },
                 { DrinkType.WineSpecial14, 174 },
                 { DrinkType.WineSpecial15, 152 },
                 { DrinkType.CorkageFee, 166 }

            };

        }
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
                    DrinkSize = DrinkSize.JustOneSize,
                    DbItemId = Drinks.GetDbItemId(drinks.Key)
                };
                SoftDrinks.Add(thisDrink);
            }
        }

        public static decimal GetDbItemId(DrinkType drinkType)
        {
            if (DbItemIdDictionary.ContainsKey(drinkType))
            {
                return DbItemIdDictionary[drinkType];
            }
            return 0;
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
