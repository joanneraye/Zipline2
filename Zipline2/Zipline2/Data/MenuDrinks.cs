using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Data
{
    public static class MenuDrinks
    {
        public static List<Drink> SoftDrinks { get; set; }
        public static List<Drink> DraftBeers { get; set; }
        public static List<Drink> BottledBeers { get; set; }
        public static List<Drink> GlassWines { get; set; }
        public static List<Drink> BottleWines { get; set; }
       
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
                { DrinkType.SpecialSoda, 214 },
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
                 { DrinkType.PinotGrigio,  24 },
                 { DrinkType.Chardonnay,  25 },
                 { DrinkType.WhiteZin,  30 },
                 { DrinkType.Rose,  205 },
                 { DrinkType.DouglasGreenSb,  210 },
                 { DrinkType.LeeseFitchCab, 26 },
                 { DrinkType.AlverdiSangiovese,  28 },
                 { DrinkType.Chianti,  37 },
                 { DrinkType.RedZinfandel,  188 },
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
                  { 24, DrinkType.PinotGrigio },
                 { 25, DrinkType.Chardonnay },
                  { 26, DrinkType.LeeseFitchCab },
                 { 28, DrinkType.AlverdiSangiovese },
              
                 { 30, DrinkType.WhiteZin },
                    { 37, DrinkType.Chianti },
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
                 { 188, DrinkType.RedZinfandel },
                  { 190, DrinkType.Flight },
                 { 195, DrinkType.GreenTruckPetitiSyrah },
                 { 197, DrinkType.ClayhouseRedBlend },
                  { 199, DrinkType.FirstMagnitude72 },
                { 203, DrinkType.EmployeeBeer },
                { 204, DrinkType.SwampHeadBigNoseIpa },
                 { 205, DrinkType.Rose },
                { 207, DrinkType.PilsLagerOrBlondeAle },
                 { 208, DrinkType.YauquenMalbec },
                 { 209, DrinkType.BodegasLaya },
                 { 210, DrinkType.DouglasGreenSb },
                 { 211, DrinkType.NaGenesee },
                { 212,  DrinkType.Beer12Oz },
                { 214, DrinkType.SpecialSoda },
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
                case DrinkCategory.GlassWine:
                    if (GlassWines == null || GlassWines.Count <= 0)
                    {
                        CreateGlassWines();
                    }
                    return GlassWines;
                case DrinkCategory.BottleWine:
                    if (BottleWines == null || BottleWines.Count <= 0)
                    {
                        CreateBottleWines();
                    }
                   return BottleWines;
                //case DrinkCategory.HouseWine:
                //    if (HouseWines == null || HouseWines.Count <= 0)
                //    {
                //        CreateHouseWines();
                //    }
                //    return HouseWines;
                //case DrinkCategory.HotDrink:
                //    if (HotDrinks == null || HotDrinks.Count <= 0)
                //    {
                //        CreateHotDrinks();
                //    }
                //    return HotDrinks;
            }
            return new List<Drink>();
        }

        private static void CreateSoftDrinks()
        {
            SoftDrinks = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string[]> drinks in DisplayNames.DisplaySoftDrinkNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value[0],
                    ShortName = drinks.Value[1],
                    DrinkCategory = DrinkCategory.SoftDrink,
                    DrinkSize = DrinkSize.JustOneSize,
                    DbItemId = MenuDrinks.GetDbItemId(drinks.Key)
                    
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
            var pintBeers = new List<Drink>();
            DraftBeers = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string[]> drinks in DisplayNames.DisplayDraftBeerNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                   DrinkCategory = DrinkCategory.DraftBeer
                };
                if (drinks.Key == DrinkType.Beer12Oz)
                {
                    thisDrink.ItemName = drinks.Value[0];
                    thisDrink.ShortName = drinks.Value[1];
                    thisDrink.DrinkSize = DrinkSize.JustOneSize;
                    PopulateDbInfo(ref thisDrink);
                    pintBeers.Add(thisDrink);
                    DraftBeers.Add(thisDrink);
                }
                else
                {
                    thisDrink.ItemName = drinks.Value[0];
                    thisDrink.ShortName = drinks.Value[1];
                    thisDrink.DrinkSize = DrinkSize.Pint;
                    PopulateDbInfo(ref thisDrink);
                    pintBeers.Add(thisDrink);
                    DraftBeers.Add(thisDrink);
                    
                    
                }
            }
            foreach (var beer in pintBeers)
            {
                if (beer.DrinkType != DrinkType.Beer12Oz)
                {
                    Drink pitcherDrink = new Drink(beer.DrinkType)
                    {
                    ItemName = beer.ItemName,
                    ShortName = beer.ShortName,
                    DrinkCategory = DrinkCategory.DraftBeer,
                    DrinkSize = DrinkSize.Pitcher
                    };
                    pitcherDrink.PricePerItemIncludingToppings *= 3;
                    PopulateDbInfo(ref pitcherDrink);
                    DraftBeers.Add(pitcherDrink);
                }
            }
        }

        private static void CreateBottledBeers()
        {
            BottledBeers = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string[]> drinks in DisplayNames.DisplayBottledBeerNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    ItemName = drinks.Value[0],
                    ShortName = drinks.Value[1],
                    DrinkCategory = DrinkCategory.BottledBeer,
                    DrinkSize = DrinkSize.JustOneSize
                };
                PopulateDbInfo(ref thisDrink);
                BottledBeers.Add(thisDrink);
            }
        }

        private static void CreateGlassWines()
        {
            GlassWines = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string[]> drinks in DisplayNames.DisplayGlassWineNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    DrinkCategory = DrinkCategory.GlassWine,
                    ItemName = drinks.Value[0],
                    ShortName = drinks.Value[1],
                    DrinkSize = DrinkSize.Glass
                };
               
                PopulateDbInfo(ref thisDrink);
                GlassWines.Add(thisDrink);
            }
        }

        private static void CreateBottleWines()
        {
            BottleWines = new List<Drink>();
            foreach (KeyValuePair<DrinkType, string[]> drinks in DisplayNames.DisplayBottleWineNameDictionary)
            {
                Drink thisDrink = new Drink(drinks.Key)
                {
                    DrinkCategory = DrinkCategory.BottleWine,
                    ItemName = drinks.Value[0],
                    ShortName = drinks.Value[1],
                    DrinkSize = DrinkSize.Bottle
                };

                thisDrink.PricePerItemIncludingToppings *= 3;
                PopulateDbInfo(ref thisDrink);
                BottleWines.Add(thisDrink);
            }
        }

        //private static void CreateRedWines()
        //{
        //    RedWines = new List<Drink>();
        //    foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayRedWineNameDictionary)
        //    {
        //        Drink thisDrink = new Drink(drinks.Key)
        //        {  
        //            DrinkCategory = DrinkCategory.RedWine
        //        };
        //        if (drinks.Key == DrinkType.LeeseFitchCab ||
        //            drinks.Key == DrinkType.AlverdiSangiovese)
        //        {
        //            thisDrink.ItemName = drinks.Value +" - GLASS";
        //            thisDrink.DrinkSize = DrinkSize.Glass;
        //            PopulateDbInfo(ref thisDrink);
        //            RedWines.Add(thisDrink);

        //            Drink bottleDrink = new Drink(drinks.Key)
        //            {
        //                ItemName = drinks.Value + " - BOTTLE",
        //                DrinkCategory = DrinkCategory.RedWine
        //            };
        //            bottleDrink.DrinkSize = DrinkSize.Bottle;
        //            bottleDrink.PricePerItemIncludingToppings *= 3;
        //            PopulateDbInfo(ref bottleDrink);
        //            RedWines.Add(bottleDrink);
        //        }
        //        else
        //        {
        //            thisDrink.ItemName = drinks.Value + " - BOTTLE";
        //            thisDrink.DrinkSize = DrinkSize.Bottle;
        //            PopulateDbInfo(ref thisDrink);
        //            RedWines.Add(thisDrink);
        //        }
        //    }
        //}
        //private static void CreateWhiteWines()
        //{
        //    WhiteWines = new List<Drink>();
        //    foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayWhiteWineNameDictionary)
        //    {
        //        Drink thisDrink = new Drink(drinks.Key)
        //        {
        //            DrinkCategory = DrinkCategory.WhiteWine
        //        };
        //        if (drinks.Key == DrinkType.DouglasGreenSb)
        //        {
        //            thisDrink.ItemName = drinks.Value + " - BOTTLE";
        //            thisDrink.DrinkSize = DrinkSize.Bottle;
        //            PopulateDbInfo(ref thisDrink);
        //            WhiteWines.Add(thisDrink);
        //        }
        //        else
        //        {
        //            thisDrink.ItemName = drinks.Value + " - GLASS";
        //            thisDrink.DrinkSize = DrinkSize.Glass;
        //            PopulateDbInfo(ref thisDrink);
        //            WhiteWines.Add(thisDrink);

        //            Drink bottleDrink = new Drink(drinks.Key)
        //            {
        //                ItemName = drinks.Value + " - BOTTLE",
        //                DrinkCategory = DrinkCategory.WhiteWine,
        //                DrinkSize = DrinkSize.Bottle
        //            };
        //            bottleDrink.PricePerItemIncludingToppings *= 3;
        //            PopulateDbInfo(ref bottleDrink);
        //            WhiteWines.Add(bottleDrink);
        //        }
        //    }
        //}
        //private static void CreateHouseWines()
        //{
        //    HouseWines = new List<Drink>();
        //    foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayHouseWineNameDictionary)
        //    {
        //        Drink thisDrink = new Drink(drinks.Key)
        //        {
        //            ItemName = drinks.Value,
        //            DrinkCategory = DrinkCategory.HouseWine,
        //            DrinkSize = DrinkSize.JustOneSize
        //        };
        //        PopulateDbInfo(ref thisDrink);
        //        HouseWines.Add(thisDrink);
        //    }
        //}
        //private static void CreateHotDrinks()
        //{
        //    HotDrinks = new List<Drink>();
        //    foreach (KeyValuePair<DrinkType, string> drinks in DisplayNames.DisplayHotDrinkNameDictionary)
        //    {
        //        Drink thisDrink = new Drink(drinks.Key)
        //        {
        //            ItemName = drinks.Value,
        //            DrinkCategory = DrinkCategory.HotDrink,
        //            DrinkSize = DrinkSize.JustOneSize
        //        };
        //        PopulateDbInfo(ref thisDrink);
        //        HotDrinks.Add(thisDrink);
        //    }
        //}

        public static void CreateAllDrinks()
        {
            CreateSoftDrinks();
            CreateGlassWines();
            CreateBottleWines();
            CreateDraftBeers();
            CreateBottledBeers();
        }
    }
}
