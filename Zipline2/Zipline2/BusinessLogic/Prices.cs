using Newtonsoft.Json;
using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.DictionaryKeys;

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

        public static Dictionary<string, decimal> BasePriceDictionary = new Dictionary<string, decimal>
        {
            { Key.PIZZA_SLICE, 3.00M },
            { Key.PIZZA_MEDIUM, 13.00M },
            { Key.PIZZA_LARGE, 17.00M },
            { Key.CALZONE,  9.00M},
            { Key.CALZONE_STEAKANDCHEESE, 13.00M },
            { Key.PIZZA_SATCHPAN, 21.00M },
            { Key.PIZZA_MFP, 16.00M },
            { Key.PIZZA_INDY, 6.00M }
        };

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

        public static Dictionary<string, decimal[]> ToppingsPriceDictionary = new Dictionary<string, decimal[]>
        {
            { Key.SLICE_TOPPINGS, PizzaSliceToppingsPrices },
            { Key.MEDIUM_TOPPINGS, PizzaMediumToppingsPrices },
            { Key.LARGE_TOPPINGS, PizzaLargeToppingsPrices },
            { Key.CALZONE_TOPPINGS, CalzoneToppingsPrices },
            { Key.SATCHPAN_TOPPINGS, PizzaSatchPanToppingsPrices },
            { Key.INDY_TOPPINGS, PizzaIndyToppingsPrices },
            { Key.MFP_TOPPINGS, PizzaMfpToppingsPrices }
        };        
    }
}
