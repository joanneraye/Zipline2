using System;
using System.Collections.Generic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Data
{
    public static class DisplayNames
    {
        public static Dictionary<CalzoneType, string> DisplayCalzoneNameDictionary = new Dictionary<CalzoneType, string>
        {
            { CalzoneType.RicottaMozarella, "Calzone Mozzarella Ricotta" },
             { CalzoneType.HotRope, "Calzone Hot Rope" },
              { CalzoneType.PBJ, "Calzone PB&J" },
            { CalzoneType.SteakAndCheese, "Calzone Steak and Cheese" }

        };
        public static Dictionary<PizzaType, string> DisplayPizzaNameDictionary = new Dictionary<PizzaType, string>
        {
            { PizzaType.ThinSlice, "Cheese Slice" },
            { PizzaType.PanSlice, "Satch-Pan Slice" },
            { PizzaType.Medium, "Medium Cheese" },
            { PizzaType.Large, "Large Cheese" },
            { PizzaType.LunchSpecialSlice, "Special Slice" },
             { PizzaType.LunchSpecialPanSlice, "Special SatchPan Slice" },
            //{ PizzaType.Calzone, "Calzone" },
            //{ PizzaType.CalzoneSteakAndCheese, "Calzone - Steak and Cheese" },
            { PizzaType.SatchPan, "Satch Pan" },
            { PizzaType.Mfp, "Millet Flax Pizza" },
            { PizzaType.Indy, "Indy Pizza" },
            { PizzaType.PestoWhitePan, "Special Base Pan" },
            { PizzaType.PestoWhiteMedium, "Special Base Medium" },
            { PizzaType.PestoWhiteLarge, "Special Base Large" },
        };
        public static Dictionary<DrinkType, string[]> DisplaySoftDrinkNameDictionary = new Dictionary<DrinkType, string[]>
        {

            { DrinkType.Water, new string[2] { "Water", " Water" } },
            { DrinkType.SodaWater, new string[2] { "Soda Water", "SodaH20" } },
            { DrinkType.LolaCola, new string[2] { "Lola Cola", "  Cola" } },
            { DrinkType.StevieZ, new string[2] { "Stevie Z-Cal", "StevieZ" } },
            { DrinkType.LennieLemonLime, new string[2] { "Lennie Lemon Lime", "LemLime" } },
            { DrinkType.GinnieGingerAle, new string[2] { "Ginnie Ginger Ale", "GingAle" } },
            { DrinkType.RubyRootBeer, new string[2] { "Ruby Root Beer", "Rt Beer" } },
           
            { DrinkType.SpecialSoda, new string[2] { "Special Soda", "Special" } },
            { DrinkType.Flight, new string[2] { "Flight", " Flight" } },
             { DrinkType.Lemonade, new string[2] { "Lemonade", "Lmonade" } },
            { DrinkType.SweetTea, new string[2] { "Sweet Tea", "Sweet T" } },
            { DrinkType.UnsweetTea, new string[2] { "Unsweet Tea", " UnSw T" } },
            { DrinkType.HalfNHalfTea, new string[2] { "Half N Half Tea", " Half T" } },

            { DrinkType.SweetArnoldPalmer, new string[2] { "Sweet Arnold Palmer", "Sw ArnP" } },
            { DrinkType.UnsweetArnoldPalmer, new string[2] { "Unsweet Arnold Palmer", "UnSw AP" } },
            
            { DrinkType.Milk, new string[2] { "Milk", "  Milk" } },
            { DrinkType.AppleJuice, new string[2] { "Apple Juice", "A Juice" } },
            { DrinkType.DietCokeCan, new string[2] { "Diet Coke Can", "DietCoke" } },
            { DrinkType.SodaPitcher, new string[2] { "Soda Pitcher", "Pitcher" } },
            { DrinkType.RegularCoffee, new string[2] { "Regular Coffee", " Coffee" } },
            { DrinkType.DecafCoffee, new string[2] { "Decaf Coffee", " DeCaf" } },
            { DrinkType.HotTea, new string[2] { "Hot Tea", " HotTea" } },
                { DrinkType.HotCocoa, new string[2] { "Hot Cocoa", "HotChoc" } }

        };
        public static Dictionary<DrinkType, string[]> DisplayDraftBeerNameDictionary = new Dictionary<DrinkType, string[]>
        {
              { DrinkType.Hefeweizen, new string[2] { "Hefeweizen", "   Hef" } },
               { DrinkType.FirstMagnitude72, new string[2] { "First Magnitude 72", "   72" } },
                //{ DrinkType.EmployeeBeer, new string[2] { "Employee Beer", "Hefeweizen" } },
                 { DrinkType.SwampHeadBigNoseIpa, new string[2] { "Swamp Head Big Nose Ipa", "Big Nose" } },
                  { DrinkType.PilsLagerOrBlondeAle, new string[2] { "Pils, Lager, Or BlondeAle", "  Lager" } },
                     { DrinkType.Beer12Oz, new string[2] { "12 Oz. Beer", "   12oz." } }
        };
        public static Dictionary<DrinkType, string[]> DisplayBottledBeerNameDictionary = new Dictionary<DrinkType, string[]>
        {
             { DrinkType.Guinness, new string[2] { "Guinness", "  Guin." } },
              { DrinkType.OmissionPaleAle, new string[2] { "Omission Pale Ale", " Omiss" } },
               { DrinkType.Bud, new string[2] { "Bud", "  Bud" } },
                { DrinkType.BudLight, new string[2] { "Bud Light", "BudLite" } },
                 { DrinkType.NaGenesee, new string[2] { "NA Genesee", "Gens NA" } }
        };

        public static Dictionary<DrinkType, string[]> DisplayGlassWineNameDictionary = new Dictionary<DrinkType, string[]>
        {
            { DrinkType.PinotGrigio, new string[2] { "Pinot Grigio", "Pinot G" } },
              { DrinkType.Chardonnay, new string[2] { "Chardonnay", " Chard" } },
                { DrinkType.WhiteZin, new string[2] { "White Zinfandel", "WhiteZin" } },
                  { DrinkType.Rose, new string[2] { "Rose", "  Rose" } },
                    { DrinkType.LeeseFitchCab, new string[2] { "Cabernet", "  Cab" } },
                      { DrinkType.AlverdiSangiovese, new string[2] { "Sangiovese", "Sangiov" } }
        };

        public static Dictionary<DrinkType, string[]> DisplayBottleWineNameDictionary = new Dictionary<DrinkType, string[]>
        {
           { DrinkType.PinotGrigio, new string[2] { "Pinot Grigio", "Pinot G" } },
              { DrinkType.Chardonnay, new string[2] { "Chardonnay", " Chard" } },
               { DrinkType.SauvBlanc, new string[2] { "Sauv Blanc", "SvBlanc" } },
                { DrinkType.WhiteZin, new string[2] { "White Zinfandel", "WhiteZin" } },
                  { DrinkType.Rose, new string[2] { "Rose", "  Rose" } },
                     { DrinkType.LeeseFitchCab, new string[2] { "Cabernet", "  Cab" } },
                      { DrinkType.AlverdiSangiovese, new string[2] { "Sangiovese", "Sangiov" } },
                       { DrinkType.YauquenMalbec, new string[2] { "Malbec", "Malbec" } },
                        { DrinkType.RedZinfandel, new string[2] { "Red Zinfandel", "Red Zin" } },
                         { DrinkType.Chianti, new string[2] { "Chianti", "Chianti" } },
                          { DrinkType.GreenTruckPetitiSyrah, new string[2] { "Green Truck Petiti Syrah", "GrnTrck" } },
                           { DrinkType.ClayhouseRedBlend, new string[2] { "Clayhouse Red Blend", "Clayhse" } },
                            { DrinkType.BodegasLaya, new string[2] { "Bodegas Laya", "  Laya" } },
                             { DrinkType.CorkageFee, new string[2] { "Corkage Fee", "CorkFee" } }

        };

        public static Dictionary<DrinkType, string> DisplayWhiteWineNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.PinotGrigio, "Alverdi Pinot Grigio" },
             { DrinkType.Chardonnay, "Silver Ridge Chardonnay" },
             { DrinkType.WhiteZin, "Raywood White Zin" },
             { DrinkType.Rose, "The Rose Garden Rose" },
             { DrinkType.DouglasGreenSb, "Douglas Green SB" }
        };



        public static Dictionary<DrinkType, string> DisplayRedWineNameDictionary = new Dictionary<DrinkType, string>
        {
             { DrinkType.LeeseFitchCab, "Leese Fitch Cab Cabernet" },
             { DrinkType.AlverdiSangiovese, "Alverdi Sangiovese" },
             { DrinkType.Chianti, "Caposaldo Chianti" },
             { DrinkType.RedZinfandel, "Cline Zinfandel" },
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
              { ToppingName.Almonds, "Almonds" },
            { ToppingName.Anchovies, "Anchovies" },
             { ToppingName.Apples, "Apples" },
            { ToppingName.Artichokes, "Artichokes" },
            { ToppingName.Bacon, "Bacon" },
            { ToppingName.BananaPeppers, "Banana Peppers" },
            { ToppingName.Basil, "Basil" },
            { ToppingName.Beef, "Beef" },
            { ToppingName.BlackOlives, "Black Olives" },
            { ToppingName.Broccoli, "Broccoli" },
               { ToppingName.ButterOk, "Butter OK" },
            { ToppingName.Carrots, "Carrots" },
            { ToppingName.Cheese, "Cheese" },
            { ToppingName.CrispyCook, "Crispy Cook" },
             { ToppingName.Cucumbers, "Cucumbers" },
                     { ToppingName.CutInto12, "Cut Into 12" },
            { ToppingName.DAIYA, "DAIYA" },
               { ToppingName.DressingOnSide, "Dressing On Side" },
            { ToppingName.ExtraCheese, "Extra Cheese" },
            { ToppingName.ExtraDressingOnSide, "Extra Dressing On Side" },
            { ToppingName.ExtraMozarellaCalzone, "Extra Mozarella" },
            { ToppingName.ExtraPSauceOP, "Extra Pizza Sauce On Pie" },
            { ToppingName.ExtraPSauceOS, "Extra Pizza Sauce On Side" },
            { ToppingName.ExtraRicottaCalzone, "Extra Ricotta" },
            { ToppingName.Feta, "Feta" },
            { ToppingName.FiftyCentsUpcharge, "0.50 Cents Upcharge" },
            { ToppingName.Garlic, "Garlic" },
            { ToppingName.GlutenFreeIndyOnly, "GLUTEN FREE INDY ONLY" },
            { ToppingName.GreenOlives, "Green Olives" },
            { ToppingName.GreenPeppers, "Green Peppers" },
            { ToppingName.HalfMajor, "Half Major" },
             { ToppingName.Ham, "Ham" },
            { ToppingName.Jalapenos, "Jalapenos" },
             { ToppingName.Joiner, "JOINER" },
              { ToppingName.KidCook, "Kid Cook" },
               { ToppingName.Lettuce, "Lettuce" },
            { ToppingName.LightCook, "Light Cook" },
             { ToppingName.LightMozarella, "Light Mozarella" },
            { ToppingName.LightRicotta, "Light Ricotta" },
            { ToppingName.LightSauce, "Light Sauce" },
            { ToppingName.Major, "MAJOR" },
            { ToppingName.Meatballs, "Meatballs" },
            { ToppingName.Mushrooms, "Mushrooms" },
            { ToppingName.NoButter, "No Butter" },
             { ToppingName.NoCheese, "No Cheese" },
               { ToppingName.NoCut, "No Cut" },
                { ToppingName.NoDressing, "No Dressing" },
                 { ToppingName.NoMozarella, "No Mozarella" },
                  { ToppingName.NoNutsNoSeeds, "No Nuts, No Seeds" },
                   { ToppingName.NoNutsSeedsOk, "No Nuts, Seeks OK" },
                  { ToppingName.NoRicotta, "No Ricotta" },
            { ToppingName.NoSauce, "No Sauce" },
            { ToppingName.Onion, "Onion" },
             { ToppingName.OutFirst, "Out First" },
              { ToppingName.PecansWalnuts, "Pecans/Walnuts" },
            { ToppingName.PestoTopping, "Pesto Topping" },
            { ToppingName.Pepperoni, "Pepperoni" },
            { ToppingName.Pineapple, "Pineapple" },
            { ToppingName.RedOnions, "RedOnions" },
            { ToppingName.Ricotta, "Ricotta" },
             { ToppingName.RicottaCalzone, "Ricotta" },
            { ToppingName.RoastedRedPepper, "RRP" },
               { ToppingName.SaladWithOrder, "Salad With Order" },
               { ToppingName.SatchPan, "SATCH PAN" },
            { ToppingName.Sausage, "Sausage" },
            { ToppingName.Seeds, "Seeds" },
             { ToppingName.SliceCutInHalfSamePlate, "Slice cut in half Same Plate" },
            { ToppingName.SliceCutInHalfSepPlate, "Slice cut in half Separate Plate" },
            { ToppingName.Spinach, "Spinach" },
            { ToppingName.Steak, "Steak" },
                  { ToppingName.SteakNCheeseCalzone, "Steak N Cheese Calzone" },
            { ToppingName.SundriedTomatoes, "Sun-dried Tomatoes" },
             { ToppingName.TakeoutBring2Table, "Takeout Bring To Table" },
            { ToppingName.TakeoutKeepInKitch, "Takeout Keep In Kitchen" },
            { ToppingName.Teese, "TEESE" },
            { ToppingName.TempehBBQ, "Tempeh BBQ" },
            { ToppingName.TempehOriginal, "Tempeh Original" },
            { ToppingName.Tomatoes, "Tomatoes" },
            { ToppingName.Zucchini, "Zucchini" },
        };

        public static Dictionary<SaladSize, string> DisplaySaladNameDictionary = new Dictionary<SaladSize, string>
        {
            { SaladSize.LunchSpecial, "Special Salad" },
            { SaladSize.LunchSize, "Special Salad (without slice)" },
            { SaladSize.Small, "Small Salad" },
            { SaladSize.Large, "Large Salad" }
        };

        public static Dictionary<DessertType, string> DisplayDessertNameDictionary = new Dictionary<DessertType, string>
        {
            { DessertType.AnyCookie, "Cookie" },
            { DessertType.AppleCrumbCheesecake, "Apple Crumb Cheesecake" },
            { DessertType.Bonbon, "Bon-bon" },
            { DessertType.Brownie, "Brownie" },
            { DessertType.ChocolateCake, "Chocolate Cake" },
            { DessertType.ChocolateCannoli, "Chocolate Cannoli" },
            { DessertType.ChocolateChipCookie, "Chocolate Chip Cookie" },
            { DessertType.HalfAndHalfCannoli, "Half & Half Cannoli" },
            { DessertType.MexicanWeddingCookie, "Mexican Wedding Cookie" },
            { DessertType.OatmealRaisinCookie, "Oatmeal Raisin Cookie" },
            { DessertType.PeanutButterCookie, "Peanut Butter Cookie" },
            { DessertType.PumpkinSpiceCookie, "Pumpkin Spice Cookie" },
              { DessertType.SnickerDoodleCookie, "Snicker Doodle Cookie" },
               { DessertType.ThreeDollarDessert, "$3 Dollar Dessert" },
                { DessertType.VanillaCannoli, "Vanilla Cannoli" },
                 { DessertType.VeganDessert, "Vegan Dessert" },
                  { DessertType.VeganPumpkinSpiceCookie, "Vegan Pumpkin Spice Cookie" },
                    { DessertType.WholeCake, "Whole Cake" }
        };

        public static string GetSaladDisplayName(SaladSize sizeOfSalad)
        {
            if (DisplaySaladNameDictionary.ContainsKey(sizeOfSalad))
            {
                return DisplaySaladNameDictionary[sizeOfSalad];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetPizzaDisplayName(PizzaType displayDictionaryKey)
        {
            if (DisplayPizzaNameDictionary.ContainsKey(displayDictionaryKey))
            {
                return DisplayPizzaNameDictionary[displayDictionaryKey];
            }
            return "Not in Dictionary Yet";
        }

        public static string GetCalzoneDisplayName(CalzoneType displayDictionaryKey)
        {
            if (DisplayCalzoneNameDictionary.ContainsKey(displayDictionaryKey))
            {
                return DisplayCalzoneNameDictionary[displayDictionaryKey];
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

        public static string[] GetSoftDrinkDisplayName(DrinkType softdrinkName)
        {
            if (DisplaySoftDrinkNameDictionary.ContainsKey(softdrinkName))
            {
                return DisplaySoftDrinkNameDictionary[softdrinkName];
            }
            return new string[2] { "Not in Dictionary Yet", "Not in Dictionary Yet" } ;

        }
        public static string GetDraftBeerDisplayName(DrinkType draftBeerName)
        {
            if (DisplayDraftBeerNameDictionary.ContainsKey(draftBeerName))
            {
                return DisplayDraftBeerNameDictionary[draftBeerName][0];
            }
            return "Not in Dictionary Yet";
        }
        public static string GetBottledBeerDisplayName(DrinkType bottledBeerName)
        {
            if (DisplayBottledBeerNameDictionary.ContainsKey(bottledBeerName))
            {
                return DisplayBottledBeerNameDictionary[bottledBeerName][0];
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

        public static string GetDessertDisplayName(DessertType dessertType)
        {
            if (DisplayDessertNameDictionary.ContainsKey(dessertType))
            {
                return DisplayDessertNameDictionary[dessertType];
            }
            return "Not in Dictionary Yet";
        }
    }
}
