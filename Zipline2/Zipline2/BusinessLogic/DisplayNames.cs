using System;
using System.Collections.Generic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.BusinessLogic
{
    public static class DisplayNames
    {
        private static Dictionary<PizzaType, string> DisplayPizzaNameDictionary = new Dictionary<PizzaType, string>
        {
            { PizzaType.ThinSlice, "Pizza Slice" },
            { PizzaType.PanSlice, "Satch-Pan Slice" },
            { PizzaType.Medium, "Medium Pizza" },
            { PizzaType.Large, "Large Pizza" },
            { PizzaType.Calzone, "Calzone" },
            { PizzaType.CalzoneSteakAndCheese, "Calzone - Steak and Cheese" },
            { PizzaType.SatchPan, "Satch-Pan" },
            { PizzaType.Mfp, "Millet Flax Pizza" },
            { PizzaType.Indy, "Indy Pizza" },
            { PizzaType.PestoWhitePan, "Special Base Pan" },
            { PizzaType.PestoWhiteMedium, "Special Base Medium" },
            { PizzaType.PestoWhiteLarge, "Special Base Large" },
        };
        public static Dictionary<SoftDrinkType, string> DisplaySoftDrinkNameDictionary = new Dictionary<SoftDrinkType, string>
        {
            { SoftDrinkType.Water, "Water" },
            { SoftDrinkType.WaterWithLemon, "Water with Lemon" },
            { SoftDrinkType.WaterNoIce, "Water No Ice" },
            { SoftDrinkType.LolaCola, "Lola Cola" },
            { SoftDrinkType.StevieZ, "Stevie Z-Cal" },
            { SoftDrinkType.LennieLemonLime, "Lennie Lemon Lime" },
            { SoftDrinkType.GinnieGingerAle, "Ginnie Ginger Ale" },
            { SoftDrinkType.RubyRootBeer, "Ruby Root Beer" },
            { SoftDrinkType.AppleJuice, "Apple Juice" },
            { SoftDrinkType.Lemonade, "Lemonade" },
            { SoftDrinkType.SweetTea, "Sweet Tea" },
            { SoftDrinkType.SweetArnoldPalmer, "Sweet Arnold Palmer" },
            { SoftDrinkType.UnsweetArnoldPalmer, "Unsweet Arnold Palmer" },
            { SoftDrinkType.UnsweetTea, "Unsweet Tea" },
            { SoftDrinkType.SodaWater, "Soda Water" },
            { SoftDrinkType.Milk, "Milk" },
            { SoftDrinkType.BottledCoke, "Bottled Coke" },
            { SoftDrinkType.HalfNHalfTea, "Half N Half Tea" },
            { SoftDrinkType.DietCokeCan, "Diet Coke Can" },
            { SoftDrinkType.SodaPitcher, "Soda Pitcher" },
            { SoftDrinkType.Flight, "Flight" },
            { SoftDrinkType.CrystalCreme, "Crystal Creme" }
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
            { ToppingName.ExtraPSauceOP, "Extra Pizza Sauce On Pizza" },
            { ToppingName.ExtraPSauceOS, "Extra Pizza Sauce On Side" },
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
            { ToppingName.Deep, "PAN" },
            { ToppingName.LightSauce, "Light Sauce" },
            { ToppingName.LightMozarella, "Light Mozarella" },
            { ToppingName.LightRicotta, "Light Ricotta" },
            { ToppingName.NoButter, "No Butter" },
            { ToppingName.NoSauce, "No Sauce" },
            { ToppingName.LightCook, "Light Cook" },
            { ToppingName.CrispyCook, "Crispy Cook" },
            { ToppingName.KidCook, "Kid Cook" },
            { ToppingName.ButterOk, "Butter OK" },
            { ToppingName.CutInto12, "Cut Into 12" },
            { ToppingName.Joiner, "JOINER" },
            { ToppingName.NoCut, "No Cut" },
            { ToppingName.OutFirst, "Out First" },
            { ToppingName.SaladWithOrder, "Salad With Order" },
            { ToppingName.SliceCutInHalfSamePlate, "Slice cut in half Same Plate" },
            { ToppingName.SliceCutInHalfSepPlate, "Slice cut in half Separate Plate" },
            { ToppingName.TakeoutBring2Table, "Takeout Bring To Table" },
            { ToppingName.TakeoutKeepInKitch, "Takeout Keep In Kitchen" },
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

        public static string GetSoftDrinkDisplayName(SoftDrinkType softdrinkName)
        {
            if (DisplaySoftDrinkNameDictionary.ContainsKey(softdrinkName))
            {
                return DisplaySoftDrinkNameDictionary[softdrinkName];
            }
            return "Not in Dictionary Yet";

        }
    }
}
