using Newtonsoft.Json;
using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Data
   
{
    public static class Prices
    {
        //TODO:  Put prices in a file that if it exists is read in and replaces
        //       current data.  Can make another program for this file to be edited
        //       by the restaurant to change pricing.

        

        //public static void ReadPricesFromJsonFile()
        //{
        //    PricesFromJsonFile =
        //        JsonConvert.DeserializeObject<Dictionary<string, decimal>>
        //        (File.ReadAllText(@"c:\satchelsprices.json"));
        //}

        //public static Dictionary<string, decimal> PricesFromJsonFile;

        public static decimal GetLunchSpecialDiscount()
        {
            return 0.50M;
        }
        public static decimal GetDrinkPrice(DrinkType drinkType)
        {
            if (DrinkTypeDictionary.ContainsKey(drinkType))
            {
                return DrinkTypeDictionary[drinkType];
            }
            else
            {
                return 0M;
            }
        }

        private static Dictionary<SaladSize, decimal> SaladPriceDictionary = new Dictionary<SaladSize, decimal>
        {
            { SaladSize.LunchSpecial, 4.00M },
            { SaladSize.Small, 8M },
            { SaladSize.Large, 14M }
        };

        public static decimal GetSaladPrice(SaladSize saladSize)
        {
            if (SaladPriceDictionary.ContainsKey(saladSize))
            {
                return SaladPriceDictionary[saladSize];
            }
            else
            {
                return 0M;
            }
        }

        public static decimal GetSaladToppingPrice(SaladSize sizeOfSalad)
        {
            switch (sizeOfSalad)
            {
                case SaladSize.Large:
                    return 3.50M;
                case SaladSize.Small:
                    return 2.00M;
                case SaladSize.LunchSpecial:
                    return 1.50M;
                default:
                    return 0;
            }
        }



        private static Dictionary<DrinkType, decimal> DrinkTypeDictionary = new Dictionary<DrinkType, decimal>
        {
            { DrinkType.Water, 0M },
            { DrinkType.LolaCola, 3.00M },
            { DrinkType.StevieZ, 3.00M },
            { DrinkType.LennieLemonLime, 3.00M },
            { DrinkType.GinnieGingerAle, 3.00M },
            { DrinkType.RubyRootBeer, 3.00M },
            { DrinkType.AppleJuice, 3.00M },
            { DrinkType.Lemonade, 3.00M },
            { DrinkType.SweetTea, 3.00M },
            { DrinkType.SweetArnoldPalmer, 3.00M },
            { DrinkType.UnsweetArnoldPalmer, 3.00M },
            { DrinkType.UnsweetTea, 3.00M },
            { DrinkType.SodaWater, 2.00M },
            { DrinkType.Milk, 3.00M },
            { DrinkType.BottledCoke, 2.50M },
            { DrinkType.HalfNHalfTea, 3.00M },
            { DrinkType.DietCokeCan, 1.50M },
            { DrinkType.SodaPitcher, 12.00M },
            { DrinkType.Flight, 5.00M },
            { DrinkType.CrystalCreme, 3.00M },
            { DrinkType.Hefeweizen, 6.00M },
            { DrinkType.FirstMagnitude72,  6.00M },
            { DrinkType.EmployeeBeer,  1.88M },
            { DrinkType.SwampHeadBigNoseIpa,  6.00M },
            { DrinkType.PilsLagerOrBlondeAle,  6.00M },
            { DrinkType.Beer12Oz,  4.00M },
            { DrinkType.Guinness,  5.00M},
             { DrinkType.OmissionPaleAle,  5.00M },
             { DrinkType.Bud,  3.00M },
             { DrinkType.BudLight,  3.00M },
             { DrinkType.NaGenesee,  3.00M },
             { DrinkType.JaiAlaiIpa,  3.00M },
             { DrinkType.AlverdiPinotGrigio,  5.00M },
             { DrinkType.SilverRidgeChardonnay,  6.00M },
             { DrinkType.RaywoodWhiteZin,  5.00M },
             { DrinkType.TheRoseGardenRose,  6.00M },
             { DrinkType.DouglasGreenSb,  18.00M },       
             { DrinkType.LeeseFitchCab, 6.00M },
             { DrinkType.AlverdiSangiovese,  5.00M },
             { DrinkType.CaposaldoChianti,  18.00M },
             { DrinkType.ClineZinfandel,  18.00M },
             { DrinkType.GreenTruckPetitiSyrah,  18.00M },
             { DrinkType.ClayhouseRedBlend,  18.00M },
             { DrinkType.YauquenMalbec,  18.00M },
             { DrinkType.BodegasLaya,  18.00M },       
             { DrinkType.RegularCoffee,  3.00M },
             { DrinkType.DecafCoffee,  3.00M },
             { DrinkType.HotTea,  3.00M },
             { DrinkType.HotCocoa, 3.00M },
             { DrinkType.WineSpecial10, 10.00M },
             { DrinkType.WineSpecial12, 12.00M },
             { DrinkType.WineSpecial14, 14.00M },
             { DrinkType.WineSpecial15, 15.00M },
             { DrinkType.CorkageFee, 8.00M }
        };

        private static Dictionary<PizzaType, decimal> PizzaBasePriceDictionary = new Dictionary<PizzaType, decimal>
        {
            { PizzaType.ThinSlice, 3.00M },
            { PizzaType.PanSlice, 3.50M },
            { PizzaType.Medium, 13.00M },
            { PizzaType.Large, 17.00M },
            { PizzaType.SatchPan, 21.00M },
            { PizzaType.Mfp, 16.00M },
            { PizzaType.Indy, 6.00M },
            { PizzaType.PestoWhitePan, 24.00M },
            { PizzaType.PestoWhiteMedium, 16.00M },
            { PizzaType.PestoWhiteLarge, 20.00M }
        };

        private static Dictionary<CalzoneType, decimal> CalzoneBasePriceDictionary = new Dictionary<CalzoneType, decimal>
        {
            { CalzoneType.RicottaMozarella, 9.00M  },
             { CalzoneType.HotRope, 13.50M  },
              { CalzoneType.PBJ, 13.50M  },
            { CalzoneType.SteakAndCheese, 13.00M  },
             { CalzoneType.Major, 17.00M }

        };

        public static decimal GetPizzaBasePrice(PizzaType typeOfPizza)
        {
            if (PizzaBasePriceDictionary.ContainsKey(typeOfPizza))
            {
                return PizzaBasePriceDictionary[typeOfPizza];
            }
            else
            {
                return 0M;
            }
        }

        public static decimal GetCalzoneBasePrice(CalzoneType typeOfCalzone)
        {
            if (CalzoneBasePriceDictionary.ContainsKey(typeOfCalzone))
            {
                return CalzoneBasePriceDictionary[typeOfCalzone];
            }
            else
            {
                return 0M;
            }
        }

        public static decimal[] GetPizzaToppingsPrices(PizzaType typeOfPizza)
        {
            if (ToppingsPriceDictionary.ContainsKey(typeOfPizza))
            {
                return ToppingsPriceDictionary[typeOfPizza];
            }
            else
            {
                return new decimal[] { 0M };
            }
        }

        public static readonly decimal[] PizzaSliceToppingsPrices = new decimal[]
        {
            .50M, 1.00M, 1.50M, 2.00M, 2.50M, 3.00M, .50M
        };
        public static readonly decimal[] PizzaMediumToppingsPrices = new decimal[]
       {
           2.00M, 4.00M, 6.00M, 7.00M, 9.00M, 10.00M, 2.00M
       };

        public static readonly decimal[] PizzaLargeToppingsPrices = new decimal[]
        {
           3.00M, 6.00M, 9.00M, 11.00M, 14.00M, 14.00M, 3.00M
        };

        public static readonly decimal[] CalzoneToppingsPrices = new decimal[]
        {
           1.50M, 3.00M, 4.50M, 6.00M, 7.50M, 8.00M, 1.50M
        };

        public static decimal[] GetCalzoneToppingPrices()
        {
            return GetCalzoneToppingPrices();
        }

        public static readonly decimal[] PizzaSatchPanToppingsPrices = new decimal[]
        {
           3.00M, 6.00M, 9.00M, 12.00M, 15.00M, 18.00M, 3.00M
        };

        public static readonly decimal[] PizzaMfpToppingsPrices = new decimal[]
        {
           1.50M, 3.00M, 4.50M, 6.00M, 7.50M, 9.00M, 1.50M
        };

        public static readonly decimal[] PizzaIndyToppingsPrices = new decimal[]
        {
           1.00M, 2.00M, 3.00M, 4.00M, 5.00M, 6.00M, 1.00M
        };

        public static readonly decimal[] PizzaPestoWhiteMediumToppingsPrices = new decimal[]
        {
           2.00M, 4.00M, 6.00M, 7.00M, 9.00M, 11.00M, 2.00M
        };

        public static readonly decimal[] PizzaPestoWhiteLargeToppingsPrices = new decimal[]
        {
           3.00M, 6.00M, 9.00M, 11.00M, 14.00M, 17.00M, 3.00M
        };

        private static Dictionary<PizzaType, decimal[]> ToppingsPriceDictionary = new Dictionary<PizzaType, decimal[]>
        {
            { PizzaType.ThinSlice, PizzaSliceToppingsPrices },
            { PizzaType.PanSlice, PizzaSliceToppingsPrices },
            { PizzaType.Medium, PizzaMediumToppingsPrices },
            { PizzaType.Large, PizzaLargeToppingsPrices },
            { PizzaType.SatchPan, PizzaSatchPanToppingsPrices },
            { PizzaType.PestoWhitePan, PizzaSatchPanToppingsPrices },
            { PizzaType.Indy, PizzaIndyToppingsPrices },
            { PizzaType.Mfp, PizzaMfpToppingsPrices },
            { PizzaType.PestoWhiteMedium, PizzaPestoWhiteMediumToppingsPrices },
            { PizzaType.PestoWhiteLarge, PizzaPestoWhiteLargeToppingsPrices}
        };
        
    }
}
