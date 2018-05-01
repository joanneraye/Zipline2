﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.BusinessLogic
   
{
    public static class Prices
    {
        //TODO:  Put prices in a file that if it exists is read in and replaces
        //       current data.  Can make another program for this file to be edited
        //       by the restaurant to change pricing.

        //public async Task CreateFileAsync()
        //{
        //    IFolder rootFolder = FileSystem.Current.LocalStorage;
        //    IFolder folder = await rootFolder.CreateFolderAsync("SatchelsFiles", CreationCollisionOption.OpenIfExists);
        //    IFile file = await folder.CreateFileAsync("SatchelsPrices", CreationCollisionOption.ReplaceExisting);
        //    await file.
        //}

       //public static void WritePricesToJsonFile()
       // {
       //     string jsonPrices = JsonConvert.SerializeObject(BasePriceDictionary);
       //     File.WriteAllText(@"c:\satchelsprices.json", jsonPrices);            
       // }

        //public static void ReadPricesFromJsonFile()
        //{
        //    PricesFromJsonFile =
        //        JsonConvert.DeserializeObject<Dictionary<string, decimal>>
        //        (File.ReadAllText(@"c:\satchelsprices.json"));
        //}

        //public static Dictionary<string, decimal> PricesFromJsonFile;

            //TODO:  PRICES AREN'T FINISHED!!
        public static Dictionary<DrinkType, decimal> DrinkTypeDictionary = new Dictionary<DrinkType, decimal>
        {
            { DrinkType.Water, 0M },
            { DrinkType.WaterWithLemon, 0M },
            { DrinkType.WaterNoIce, 0M },
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
            { DrinkType.SodaWater, 0M },
            { DrinkType.Milk, 3.00M },
            { DrinkType.BottledCoke, 3.00M },
            { DrinkType.HalfNHalfTea, 3.00M },
            { DrinkType.DietCokeCan, 3.00M },
            { DrinkType.SodaPitcher, 0M },
            { DrinkType.Flight, 5.00M },
            { DrinkType.CrystalCreme, 3.00M },
            { DrinkType.Hefeweizen, 0M },
            { DrinkType.FirstMagnitude72,  0M },
            { DrinkType.EmployeeBeer,  0M },
            { DrinkType.SwampHeadBigNoseIpa,  0M },
            { DrinkType.PilsLagerOrBlondeAle,  0M },
            { DrinkType.Beer12Oz,  0M },
            { DrinkType.Guinness,  0M },
             { DrinkType.OmissionPaleAle,  0M },
             { DrinkType.Bud,  0M },
             { DrinkType.BudLight,  0M },
             { DrinkType.NaGenesee,  0M },
             { DrinkType.JaiAlaiIpa,  0M },
             { DrinkType.AlverdiPinotGrigio,  0M },
             { DrinkType.SilverRidgeChardonnay,  0M },
             { DrinkType.PinkTruckPinkWine,  0M },
             { DrinkType.TheRoseGardenRose,  0M },
             { DrinkType.DouglasGreenSb,  0M },       
             { DrinkType.LeeseFitchCab, 0M },
             { DrinkType.AlverdiSangiovese,  0M },
             { DrinkType.CaposaldoChianti,  0M },
             { DrinkType.ClineZinfandel,  0M },
             { DrinkType.GreenTruckPetitiSyrah,  0M },
             { DrinkType.ClayhouseRedBlend,  0M },
             { DrinkType.ElsaBianchiMalbec,  0M },
             { DrinkType.BodegasLaya,  0M },       
             { DrinkType.RegularCoffee,  0M },
             { DrinkType.DecafCoffee,  0M },
             { DrinkType.HotTea,  0M },
             { DrinkType.HotCocoa, 3.00M },
             { DrinkType.WineSpecial10, 10.00M },
             { DrinkType.WineSpecial12, 12.00M },
             { DrinkType.WineSpecial14, 14.00M },
             { DrinkType.WineSpecial15, 15.00M },
             { DrinkType.CorkageFee, 0M }
        };

        public static Dictionary<PizzaType, decimal> BasePriceDictionary = new Dictionary<PizzaType, decimal>
        {
            { PizzaType.ThinSlice, 3.00M },
            { PizzaType.Medium, 13.00M },
            { PizzaType.Large, 17.00M },
            { PizzaType.Calzone,  9.00M},
            { PizzaType.CalzoneSteakAndCheese, 13.00M },
            { PizzaType.SatchPan, 21.00M },
            { PizzaType.Mfp, 16.00M },
            { PizzaType.Indy, 6.00M },
            { PizzaType.PestoWhitePan, 24.00M },
            { PizzaType.PestoWhiteMedium, 16.00M },
            { PizzaType.PestoWhiteLarge, 20.00M }
        };

        public static decimal GetPizzaBasePrice(PizzaType typeOfPizza)
        {
            if (BasePriceDictionary.ContainsKey(typeOfPizza))
            {
                return BasePriceDictionary[typeOfPizza];
            }
            else
            {
                return 0M;
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

        public static Dictionary<PizzaType, decimal[]> ToppingsPriceDictionary = new Dictionary<PizzaType, decimal[]>
        {
            { PizzaType.ThinSlice, PizzaSliceToppingsPrices },
            { PizzaType.Medium, PizzaMediumToppingsPrices },
            { PizzaType.Large, PizzaLargeToppingsPrices },
            { PizzaType.Calzone, CalzoneToppingsPrices },
            { PizzaType.SatchPan, PizzaSatchPanToppingsPrices },
            { PizzaType.PestoWhitePan, PizzaSatchPanToppingsPrices },
            { PizzaType.Indy, PizzaIndyToppingsPrices },
            { PizzaType.Mfp, PizzaMfpToppingsPrices },
            { PizzaType.PestoWhiteMedium, PizzaPestoWhiteMediumToppingsPrices },
            { PizzaType.PestoWhiteLarge, PizzaPestoWhiteLargeToppingsPrices}
        };
        
    }
}
