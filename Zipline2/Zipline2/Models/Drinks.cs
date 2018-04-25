using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;

namespace Zipline2.Models
{
    public static class Drinks
    {
        private static List<SoftDrink> softDrinks;
        public static List<SoftDrink> SoftDrinks
        {
            get
            {
                return softDrinks;
            }
        }

        public static void LoadSoftDrinks()
        {
            softDrinks = new List<SoftDrink>();
            foreach (var drinkType in DisplayNames.DisplaySoftDrinkNameDictionary.Keys)
            {
                var drink = new SoftDrink()
                {
                    ItemName = DisplayNames.GetSoftDrinkDisplayName(drinkType),
                    ItemCount = 0,
                    DrinkType = BusinessLogic.Enums.DrinkType.SoftDrinks,
                    SoftDrinkType = drinkType
                };
                softDrinks.Add(drink);
            }
        }
        
    }
}
