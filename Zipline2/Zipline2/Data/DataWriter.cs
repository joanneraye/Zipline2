using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;

namespace Zipline2.DataReadWrite
{
    class DataWriter
    {
        List<MenuRecord> Menu { get; set; }

        #region Singleton
        private static DataWriter instance = null;
        private static readonly object padlock = new object();
        private DataWriter()
        {
            CreateMenu();
            WriteMenuToJsonFile("menu.json");
        }
        public static DataWriter Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DataWriter();
                    }
                    return instance;
                }
            }
        }
        #endregion
      
        public void CreateMenu()
        {
            Menu = new List<MenuRecord>();
            int menuItemNumber = 1;
            foreach (var pizzaItem in DisplayNames.DisplayPizzaNameDictionary)
            {
                Menu.Add(new MenuRecord()
                {
                    MenuItemNumber = menuItemNumber,
                    ItemDisplayName = pizzaItem.Value,
                    ItemPrice = Prices.GetPizzaBasePrice(pizzaItem.Key)
                });
                menuItemNumber++;
            }
            AddDrinks(DisplayNames.DisplaySoftDrinkNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayDraftBeerNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayBottledBeerNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayHouseWineNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayRedWineNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayWhiteWineNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayHotDrinkNameDictionary, ref menuItemNumber);
            AddDrinks(DisplayNames.DisplayDraftBeerNameDictionary, ref menuItemNumber);
        }

        private void AddDrinks(Dictionary<DrinkType, string> drinkDictionary, ref int menuItemNumber)
        {
            foreach (var drink in drinkDictionary)
            {
                Menu.Add(new MenuRecord()
                {
                    MenuItemNumber = menuItemNumber,
                    ItemDisplayName = drink.Value,
                    ItemPrice = Prices.GetDrinkPrice(drink.Key)
                });
                menuItemNumber++;
            }
        }

        public void WriteMenuToJsonFile(string fileName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var pathWithFileName = Path.Combine(path, fileName);
            File.WriteAllText(pathWithFileName, JsonConvert.SerializeObject(Menu));            
        }

        //public async Task CreateFileAsync()
        //{
        //    //IFolder rootFolder = FileSystem.Current.LocalStorage;
        //    //IFolder folder = await rootFolder.CreateFolderAsync("SatchelsFiles", CreationCollisionOption.OpenIfExists);
        //    //IFile file = await folder.CreateFileAsync("SatchelsPrices", CreationCollisionOption.ReplaceExisting);
        //    //await file.
        //}

    }
}
