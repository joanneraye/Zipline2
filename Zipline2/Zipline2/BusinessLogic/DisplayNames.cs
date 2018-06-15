using System;
using System.Collections.Generic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.BusinessLogic
{
    public static class DisplayNames
    {
        public static Dictionary<PizzaType, string> DisplayPizzaNameDictionary = new Dictionary<PizzaType, string>
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
        public static Dictionary<DrinkType, string> DisplaySoftDrinkNameDictionary = new Dictionary<DrinkType, string>
        {
            { DrinkType.Water, "Water" },
            { DrinkType.WaterWithLemon, "Water with Lemon" },
            { DrinkType.WaterNoIce, "Water No Ice" },
            { DrinkType.LolaCola, "Lola Cola" },
            { DrinkType.StevieZ, "Stevie Z-Cal" },
            { DrinkType.LennieLemonLime, "Lennie Lemon Lime" },
            { DrinkType.GinnieGingerAle, "Ginnie Ginger Ale" },
            { DrinkType.RubyRootBeer, "Ruby Root Beer" },
            { DrinkType.AppleJuice, "Apple Juice" },
            { DrinkType.Lemonade, "Lemonade" },
            { DrinkType.SweetTea, "Sweet Tea" },
            { DrinkType.SweetArnoldPalmer, "Sweet Arnold Palmer" },
            { DrinkType.UnsweetArnoldPalmer, "Unsweet Arnold Palmer" },
            { DrinkType.UnsweetTea, "Unsweet Tea" },
            { DrinkType.SodaWater, "Soda Water" },
            { DrinkType.Milk, "Milk" },
            { DrinkType.BottledCoke, "Bottled Coke" },
            { DrinkType.HalfNHalfTea, "Half N Half Tea" },
            { DrinkType.DietCokeCan, "Diet Coke Can" },
            { DrinkType.SodaPitcher, "Soda Pitcher" },
            { DrinkType.Flight, "Flight" },
            { DrinkType.CrystalCreme, "Crystal Creme" }
        };
        public static Dictionary<DrinkType, string> DisplayDraftBeerNameDictionary = new Dictionary<DrinkType, string>
        {
            { DrinkType.Hefeweizen, "Hefeweizen" },
            { DrinkType.FirstMagnitude72, "First Magnitude 72" },
            { DrinkType.EmployeeBeer, "Employee Beer" },
            { DrinkType.SwampHeadBigNoseIpa, "Swamp Head Big Nose Ipa" },
            { DrinkType.PilsLagerOrBlondeAle, "Pils, Lager, Or BlondeAle" },
            { DrinkType.Beer12Oz, "12 Oz. Beer" }
        };
        public static Dictionary<DrinkType, string> DisplayBottledBeerNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.Guinness, "Guinness" },
             { DrinkType.OmissionPaleAle, "Omission Pale Ale" },
             { DrinkType.Bud, "Bud" },
             { DrinkType.BudLight, "Bud Light" },
             { DrinkType.NaGenesee, "NA Genesee" },
             { DrinkType.JaiAlaiIpa, "Jai Alai IPA" }
        };

        public static Dictionary<DrinkType, string> DisplayWhiteWineNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.AlverdiPinotGrigio, "Alverdi Pinot Grigio" },
             { DrinkType.SilverRidgeChardonnay, "Silver Ridge Chardonnay" },
             { DrinkType.RaywoodWhiteZin, "Raywood White Zin" },
             { DrinkType.TheRoseGardenRose, "The Rose Garden Rose" },
             { DrinkType.DouglasGreenSb, "Douglas Green SB" }
        };
        public static Dictionary<DrinkType, string> DisplayRedWineNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.LeeseFitchCab, "Leese Fitch Cab Cabernet" },
             { DrinkType.AlverdiSangiovese, "Alverdi Sangiovese" },
             { DrinkType.CaposaldoChianti, "Caposaldo Chianti" },
             { DrinkType.ClineZinfandel, "Cline Zinfandel" },
             { DrinkType.GreenTruckPetitiSyrah, "Green Truck Petiti Syrah" },
             { DrinkType.ClayhouseRedBlend, "Clayhouse Red Blend" },
             { DrinkType.YauquenMalbec, "Elsa Bianchi Malbec" },
             { DrinkType.BodegasLaya, "Bodegas Laya" }
        };

        public static Dictionary<DrinkType, string> DisplayHotDrinkNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.RegularCoffee, "Regular Coffee" },
             { DrinkType.DecafCoffee, "Decaf Coffee" },
             { DrinkType.HotTea, "Hot Tea" },
             { DrinkType.HotCocoa, "Hot Cocoa" }
        };
        public static Dictionary<DrinkType, string> DisplayHouseWineNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.WineSpecial10, "$10 Wine Special" },
             { DrinkType.WineSpecial12, "$12 Wine Special" },
             { DrinkType.WineSpecial14, "$14 Wine Special" },
             { DrinkType.WineSpecial15, "$15 Wine Special" },
             { DrinkType.CorkageFee, "Corkage Fee" }
        };

        private static Dictionary<ToppingName, string> DisplayToppingNameDictionary = new Dictionary<ToppingName, string>
        {
             { ToppingName.Unknown, "Unknown" },
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
            { ToppingName.ExtraPSauceOP, "Extra Pizza Sauce On Pie" },
            { ToppingName.ExtraPSauceOS, "Extra Pizza Sauce On Side" },
            { ToppingName.ExtraRicottaCalzone, "Extra Ricotta (Calzone)" },
            { ToppingName.Feta, "Feta" },
            { ToppingName.Garlic, "Garlic" },
            { ToppingName.GlutenFreeIndyOnly, "GLUTEN FREE INDY ONLY" },
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
             { ToppingName.RicottaCalzone, "Ricotta Calzone" },
            { ToppingName.RoastedRedPepper, "RRP" },
            { ToppingName.Sausage, "Sausage" },
            { ToppingName.Spinach, "Spinach" },
            { ToppingName.Steak, "Steak" },
            { ToppingName.SundriedTomatoes, "Sun-dried Tomatoes" },
            { ToppingName.Teese, "TEESE" },
            { ToppingName.TempehBBQ, "Tempeh BBQ" },
            { ToppingName.TempehOriginal, "Tempeh Original" },
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

        public static string GetSoftDrinkDisplayName(DrinkType softdrinkName)
        {
            if (DisplaySoftDrinkNameDictionary.ContainsKey(softdrinkName))
            {
                return DisplaySoftDrinkNameDictionary[softdrinkName];
            }
            return "Not in Dictionary Yet";

        }
        public static string GetDraftBeerDisplayName(DrinkType draftBeerName)
        {
            if (DisplayDraftBeerNameDictionary.ContainsKey(draftBeerName))
            {
                return DisplayDraftBeerNameDictionary[draftBeerName];
            }
            return "Not in Dictionary Yet";
        }
        public static string GetBottledBeerDisplayName(DrinkType bottledBeerName)
        {
            if (DisplayBottledBeerNameDictionary.ContainsKey(bottledBeerName))
            {
                return DisplayBottledBeerNameDictionary[bottledBeerName];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetRedWineDisplayName(DrinkType redWineName)
        {
            if (DisplayRedWineNameDictionary.ContainsKey(redWineName))
            {
                return DisplayRedWineNameDictionary[redWineName];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetWhiteWineDisplayName(DrinkType whiteWineName)
        {
            if (DisplayWhiteWineNameDictionary.ContainsKey(whiteWineName))
            {
                return DisplayWhiteWineNameDictionary[whiteWineName];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetHouseWineDisplayName(DrinkType houseWineName)
        {
            if (DisplayHouseWineNameDictionary.ContainsKey(houseWineName))
            {
                return DisplayHouseWineNameDictionary[houseWineName];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetHotDrinksDisplayName(DrinkType hotDrinksName)
        {
            if (DisplayHotDrinkNameDictionary.ContainsKey(hotDrinksName))
            {
                return DisplayHotDrinkNameDictionary[hotDrinksName];
            }
            return "Not in Dictionary Yet";
        }
    }
}
