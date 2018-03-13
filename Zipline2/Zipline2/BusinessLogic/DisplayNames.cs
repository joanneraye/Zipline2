using System;
using System.Collections.Generic;
using Zipline2.BusinessLogic.DictionaryKeys;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.BusinessLogic
{
    public static class DisplayNames
    {
        private static Dictionary<PizzaType, string> DisplayPizzaNameDictionary = new Dictionary<PizzaType, string>
        {
            { PizzaType.ThinSlice, "Pizza Slice" },
            { PizzaType.Medium, "Medium Pizza" },
            { PizzaType.Large, "Large Pizza" },
            { PizzaType.Calzone, "Calzone" },
            { PizzaType.SatchPan, "Satch-Pan" },
            { PizzaType.Mfp, "Millet Flax Pizza" },
            { PizzaType.Indy, "Indy Pizza" }
        };

        private static Dictionary<ToppingName, string> DisplayToppingNameDictionary = new Dictionary<ToppingName, string>
        {
            { ToppingName.Anchovies, "Anchovies" },
            { ToppingName.Artichokes, "Artichokes" },
            { ToppingName.Bacon, "Bacon" },
            { ToppingName.BananaPeppers, "Banana Peppers" },
            { ToppingName.Basil, "Basil" },
            { ToppingName.Beef, "Beef" },
            { ToppingName.BlackOlives, "Black Olives" },
            { ToppingName.Broccoli, "Broccoli" },
            { ToppingName.Carrots, "Carrots" },
            { ToppingName.DAIYA, "DAIYA" },
            { ToppingName.ExtraCheese, "Extra Cheese" },
            { ToppingName.ExtraMozarellaCalzone, "Extra Mozarella (Calzone)" },
            { ToppingName.ExtraPSauceOP, "Extra Pasta Sauce On Pizza" },
            { ToppingName.ExtraPSauceOS, "Extra Pasta Sauce On Side" },
            { ToppingName.ExtraRicottaCalzone, "Extra Ricotta (Calzone)" },
            { ToppingName.Feta, "Feta" },
            { ToppingName.Garlic, "Garlic" },
            { ToppingName.GreenOlives, "Green Olives" },
            { ToppingName.GreenPeppers, "Green Peppers" },
            { ToppingName.HalfMajor, "Half Major" },
            { ToppingName.Jalapenos, "Jalapenos" },
            { ToppingName.Meatballs, "Meatballs" },
            { ToppingName.Mushrooms, "Mushrooms" },
            { ToppingName.NoCheese, "No Cheese" },
            { ToppingName.Onion, "Onion" },
            { ToppingName.PestoTopping, "Pesto Topping" },
            { ToppingName.Pepperoni, "Pepperoni" },
            { ToppingName.Pineapple, "Pineapple" },
            { ToppingName.RedOnions, "RedOnions" },
            { ToppingName.Ricotta, "Ricotta" },
            { ToppingName.RoastedRedPepper, "RRP" },
            { ToppingName.Sausage, "Sausage" },
            { ToppingName.Spinach, "Spinach" },
            { ToppingName.Steak, "Steak" },
            { ToppingName.SundriedTomatoes, "Sun-dried Tomatoes" },
            { ToppingName.Teese, "TEESE" },
            { ToppingName.TempehBBQ, "Tempeh BBQ" },
            { ToppingName.Tomatoes, "Tomatoes" },
            { ToppingName.Zucchini, "Zucchini" },
            { ToppingName.Cheese, "Cheese" },
            { ToppingName.Deep, "Deep" },
            { ToppingName.LightSauce, "Light Sauce" },
            { ToppingName.LightMozarella, "Light Mozarella" },
            { ToppingName.LightRicotta, "Light Ricotta" },
            { ToppingName.NoButter, "No Butter" },
            { ToppingName.NoSauce, "No Sauce" }
        };

        public static string GetPizzaDisplayName(PizzaType displayDictionaryKey)
        {
            if (DisplayPizzaNameDictionary.ContainsKey(displayDictionaryKey))
            {
                return DisplayPizzaNameDictionary[displayDictionaryKey];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetToppingDisplayName(ToppingName toppingName)
        {
            if (DisplayToppingNameDictionary.ContainsKey(toppingName))
            {
                return DisplayToppingNameDictionary[toppingName];
            }
            return "Not in Dictionary Yet";
        }
    }
}
