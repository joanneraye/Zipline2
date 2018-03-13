using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.DictionaryKeys;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.BusinessLogic
   
{
    public static class Prices
    {

        //public async Task CreateFileAsync()
        //{
        //    IFolder rootFolder = FileSystem.Current.LocalStorage;

        //    IFolder folder = await rootFolder.CreateFolderAsync("SatchelsFiles", CreationCollisionOption.OpenIfExists);

        //    IFile file = await folder.CreateFileAsync("SatchelsPrices", CreationCollisionOption.ReplaceExisting);

        //    await file.
            

        //}
       public static void WritePricesToJsonFile()
        {
            string jsonPrices = JsonConvert.SerializeObject(BasePriceDictionary);
            File.WriteAllText(@"c:\satchelsprices.json", jsonPrices);            
        }

        public static void ReadPricesFromJsonFile()
        {
            PricesFromJsonFile =
                JsonConvert.DeserializeObject<Dictionary<string, decimal>>
                (File.ReadAllText(@"c:\satchelsprices.json"));
        }

        public static Dictionary<string, decimal> PricesFromJsonFile;

        public static Dictionary<PizzaType, decimal> BasePriceDictionary = new Dictionary<PizzaType, decimal>
        {
            { PizzaType.ThinSlice, 3.00M },
            { PizzaType.Medium, 13.00M },
            { PizzaType.Large, 17.00M },
            { PizzaType.Calzone,  9.00M},
            { PizzaType.CalzoneSteakAndCheese, 13.00M },
            { PizzaType.SatchPan, 21.00M },
            { PizzaType.Mfp, 16.00M },
            { PizzaType.Indy, 6.00M }
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

        public static Dictionary<PizzaType, decimal[]> ToppingsPriceDictionary = new Dictionary<PizzaType, decimal[]>
        {
            { PizzaType.ThinSlice, PizzaSliceToppingsPrices },
            { PizzaType.Medium, PizzaMediumToppingsPrices },
            { PizzaType.Large, PizzaLargeToppingsPrices },
            { PizzaType.Calzone, CalzoneToppingsPrices },
            { PizzaType.SatchPan, PizzaSatchPanToppingsPrices },
            { PizzaType.Indy, PizzaIndyToppingsPrices },
            { PizzaType.Mfp, PizzaMfpToppingsPrices }
        };        
    }
}
