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
        private static Dictionary<DrinkType, decimal> drinkTypeDbIdDictionary;
        private static Dictionary<DrinkType, decimal> DrinkTypeDbIdDictionary
        {
            get
            {
                if (drinkTypeDbIdDictionary == null)
                {
                    CreateDrinkTypeDbIdDictionary();
                }
                return drinkTypeDbIdDictionary;
            }
        }

        private static Dictionary<decimal, DrinkType> dbIdDrinkTypeDictionary;
        private static Dictionary<decimal, DrinkType> DbIdDrinkTypeDictionary
        {
            get
            {
                if (dbIdDrinkTypeDictionary == null)
                {
                    CreateDbIdDrinkTypeDictionary();
                }
                return dbIdDrinkTypeDictionary;
            }
        }

        private static Dictionary<Tuple<decimal, DrinkSize>, Drink> dbIdDrinkDictionary;
        private static Dictionary<Tuple<decimal, DrinkSize>, Drink> DbIdDrinkDictionary
        {
            get
            {
                if (dbIdDrinkDictionary == null)
                {
                    dbIdDrinkDictionary = new Dictionary<Tuple<decimal, DrinkSize>, Drink>();
                }
                return dbIdDrinkDictionary;
            }
        }
        private static void CreateDrinkTypeDbIdDictionary()
        {
            drinkTypeDbIdDictionary = new Dictionary<DrinkType, decimal>()
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

        private static void CreateDbIdDrinkDictionary()
        {

        }

        private static void CreateDbIdDrinkTypeDictionary()
        {
            dbIdDrinkTypeDictionary = new Dictionary<decimal, DrinkType>()
            {
                 { 1,  DrinkType.Water },
                { 4, DrinkType.LolaCola },
                { 5, DrinkType.StevieZ },
                { 6,  DrinkType.LennieLemonLime },
                { 7,  DrinkType.GinnieGingerAle },
                { 8, DrinkType.RubyRootBeer },
                { 9, DrinkType.AppleJuice },
                { 10, DrinkType.Lemonade },
                { 11,  DrinkType.SweetTea },
                { 13, DrinkType.Hefeweizen },
                 { 17, DrinkType.Guinness },
                 { 21, DrinkType.OmissionPaleAle },
                 { 22, DrinkType.Bud },
                 { 23, DrinkType.BudLight },
                  { 24, DrinkType.AlverdiPinotGrigio },
                 { 25, DrinkType.SilverRidgeChardonnay },
                  { 26, DrinkType.LeeseFitchCab },
                 { 28, DrinkType.AlverdiSangiovese },
              
                 { 30, DrinkType.RaywoodWhiteZin },
                    { 37, DrinkType.CaposaldoChianti },
                { 42, DrinkType.SweetArnoldPalmer },
                { 43, DrinkType.UnsweetArnoldPalmer },
                 { 74, DrinkType.RegularCoffee },
                 { 75,  DrinkType.DecafCoffee },
                 { 80, DrinkType.HotTea },
                { 78, DrinkType.UnsweetTea },
                { 79, DrinkType.SodaWater },
                { 98, DrinkType.Milk },
                 { 150, DrinkType.WineSpecial10 },
                 { 151, DrinkType.WineSpecial12 },
                   { 152, DrinkType.WineSpecial15 },
                 { 160, DrinkType.HotCocoa },
                { 161, DrinkType.BottledCoke },
                { 163, DrinkType.HalfNHalfTea },
                   { 166, DrinkType.CorkageFee },
                 { 174, DrinkType.WineSpecial14 },
                { 175, DrinkType.DietCokeCan },
                { 185, DrinkType.SodaPitcher },
                 { 188, DrinkType.ClineZinfandel },
                  { 190, DrinkType.Flight },
                 { 195, DrinkType.GreenTruckPetitiSyrah },
                 { 197, DrinkType.ClayhouseRedBlend },
                  { 199, DrinkType.FirstMagnitude72 },
                { 203, DrinkType.EmployeeBeer },
                { 204, DrinkType.SwampHeadBigNoseIpa },
                 { 205, DrinkType.TheRoseGardenRose },
                { 207, DrinkType.PilsLagerOrBlondeAle },
                 { 208, DrinkType.YauquenMalbec },
                 { 209, DrinkType.BodegasLaya },
                 { 210, DrinkType.DouglasGreenSb },
                 { 211, DrinkType.NaGenesee },
                { 212,  DrinkType.Beer12Oz },
                { 214, DrinkType.CrystalCreme },
                 { 216, DrinkType.JaiAlaiIpa }
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

                PopulateDbInfo(ref thisDrink);                               
                SoftDrinks.Add(thisDrink);
            }
        }

        public static void PopulateDbInfo(ref Drink thisDrink)
        {
            thisDrink.DbItemId = GetDbItemId(thisDrink.DrinkType);
            var drinkItemKey = Tuple.Create<decimal, DrinkSize>(thisDrink.DbItemId, thisDrink.DrinkSize);
            if (DbIdDrinkDictionary.ContainsKey(drinkItemKey))
            {
                DbIdDrinkDictionary[drinkItemKey] = thisDrink;
            }
            else
            {
                DbIdDrinkDictionary.Add(drinkItemKey, thisDrink);
            }
        }

        public static decimal GetDbItemId(DrinkType drinkType)
        {
            if (DrinkTypeDbIdDictionary.ContainsKey(drinkType))
            {
                return DrinkTypeDbIdDictionary[drinkType];
            }
            return 0;
        }

        public static DrinkType GetDrinkType(decimal dbId)
        {
            if (DbIdDrinkTypeDictionary.ContainsKey(dbId))
            {
                return DbIdDrinkTypeDictionary[dbId];
            }
            return DrinkType.None;
        }

        public static Drink GetDrinkFromMenu(decimal dbId, DrinkSize drinkSize)
        {
            var drinkKey = Tuple.Create<decimal, DrinkSize>(dbId, drinkSize);
            if (DbIdDrinkDictionary.ContainsKey(drinkKey))
            {
                return DbIdDrinkDictionary[drinkKey];
            }
            //TODO:  Display error if drink is not in dictionary!
            return new Drink();
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
                if (drinks.Key == DrinkType.Beer12Oz)
                {
                    thisDrink.ItemName = drinks.Value;
                    thisDrink.DrinkSize = DrinkSize.JustOneSize;
                    PopulateDbInfo(ref thisDrink);
                    DraftBeers.Add(thisDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Pint";
                    thisDrink.DrinkSize = DrinkSize.Pint;
                    PopulateDbInfo(ref thisDrink);
                    DraftBeers.Add(thisDrink);
                    
                    Drink pitcherDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Pitcher",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.DraftBeer,
                        DrinkSize = DrinkSize.Pitcher
                    };
                    pitcherDrink.PricePerItem *= 3;
                    PopulateDbInfo(ref pitcherDrink);
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
                PopulateDbInfo(ref thisDrink);
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
                    PopulateDbInfo(ref thisDrink);
                    RedWines.Add(thisDrink);

                    Drink bottleDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Bottle",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.RedWine
                    };
                    bottleDrink.DrinkSize = DrinkSize.Bottle;
                    bottleDrink.PricePerItem *= 3;
                    PopulateDbInfo(ref bottleDrink);
                    RedWines.Add(bottleDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Bottle";
                    thisDrink.DrinkSize = DrinkSize.Bottle;
                    PopulateDbInfo(ref thisDrink);
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
                    PopulateDbInfo(ref thisDrink);
                    WhiteWines.Add(thisDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value + " - Glass";
                    thisDrink.DrinkSize = DrinkSize.Glass;
                    PopulateDbInfo(ref thisDrink);
                    WhiteWines.Add(thisDrink);

                    Drink bottleDrink = new Drink(drinks.Key)
                    {
                        ItemName = drinks.Value + " - Bottle",
                        ItemCount = 0,
                        DrinkCategory = DrinkCategory.WhiteWine,
                        DrinkSize = DrinkSize.Bottle
                    };
                    bottleDrink.PricePerItem *= 3;
                    PopulateDbInfo(ref bottleDrink);
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
                PopulateDbInfo(ref thisDrink);
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
                PopulateDbInfo(ref thisDrink);
                HotDrinks.Add(thisDrink);
            }
        }

        public static void CreateAllDrinks()
        {
            CreateSoftDrinks();
            CreateHotDrinks();
            CreateRedWines();
            CreateWhiteWines();
            CreateHouseWines();
            CreateDraftBeers();
            CreateBottledBeers();
        }
    }
}
