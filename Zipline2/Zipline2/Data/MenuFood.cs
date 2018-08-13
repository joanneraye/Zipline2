using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Models;

namespace Zipline2.Data
{
    public static class MenuFood
    {
        private static Dictionary<ToppingName, Topping> pizzaToppings;
        public static Dictionary<ToppingName, Topping> PizzaToppings
        {
            get
            {
                if (pizzaToppings == null || pizzaToppings.Count == 0)
                {
                    LoadInitialPizzaToppings();
                }
                return pizzaToppings;
            }
        }
     

        private static Dictionary<ToppingName, Topping> saladToppings;
        public static Dictionary<ToppingName, Topping> SaladToppings
        {
            get
            {
                if (saladToppings == null || saladToppings.Count == 0)
                {
                    LoadInitialSaladToppings();
                }
                return saladToppings;
            }
        }

        private static Dictionary<DessertType, Dessert> dessertDictionary;
        public static Dictionary<DessertType, Dessert> DessertDictionary
        {
            get
            {
                if (dessertDictionary == null)
                {
                    CreateDessertDictionary();
                }
                return dessertDictionary;
            }
        }

        private static Dictionary<DessertType, Dessert> cookieDictionary;
        public static Dictionary<DessertType, Dessert> CookieDictionary
        {
            get
            {
                if (cookieDictionary == null)
                {
                    CreateCookieDictionary();
                }
                return cookieDictionary;
            }
        }

        private static Dictionary<decimal, DessertType> dbIdDessertTypeDictionary;
        public static Dictionary<decimal, DessertType> DbIdDessertTypeDictionary
        {
            get
            {
                if (dbIdDessertTypeDictionary == null)
                {
                    CreateDbIdDessertTypeDictionary();
                }
                return dbIdDessertTypeDictionary;
            }
        }

        private static Dictionary<DessertType, decimal> dessertTypeDbIdDictionary;
        public static Dictionary<DessertType, decimal> DessertTypeDbIdDictionary
        {
            get
            {
                if (dessertTypeDbIdDictionary == null)
                {
                    CreateDessertTypeDbIdDictionary();
                }
                return dessertTypeDbIdDictionary;
            }
        }

        private static Dictionary<decimal, Dessert> dbIdDessertDictionary;
        public static Dictionary<decimal, Dessert> DbIdDessertDictionary
        {
            get
            {
                if (dbIdDessertDictionary == null)
                {
                    dbIdDessertDictionary = new Dictionary<decimal, Dessert>();
                }
                return dbIdDessertDictionary;
            }
        }

        public static void CreateDesserts()
        {
            foreach (var cookie in CookieDictionary)
            {
                var dbId = DessertTypeDbIdDictionary[cookie.Key];
                if (!DbIdDessertDictionary.ContainsKey(dbId))
                {
                    DbIdDessertDictionary.Add(dbId, cookie.Value);
                }
            }

            foreach (var dessert in DessertDictionary)
            {
                var dbId =DessertTypeDbIdDictionary[dessert.Key];
                if (!DbIdDessertDictionary.ContainsKey(dbId))
                {
                    DbIdDessertDictionary.Add(dbId, dessert.Value);
                }
            }
        }

    
        internal static Dessert GetDessertFromMenu(decimal id)
        {
            if (DbIdDessertDictionary.ContainsKey(id))
            {
                return DbIdDessertDictionary[id];
            }
            //TODO:  Display error if drink is not in dictionary!
            return new Dessert();
        }

        public static void PopulateDbInfo(ref Dessert thisDessert)
        {
            thisDessert.DbItemId = GetDbItemId(thisDessert.DessertType);
            if (dbIdDessertDictionary.ContainsKey(thisDessert.DbItemId))
            {
                dbIdDessertDictionary[thisDessert.DbItemId] = thisDessert;
            }
            else
            {
                dbIdDessertDictionary.Add(thisDessert.DbItemId, thisDessert);
            }
        }

        public static void LoadInitialPizzaToppings()
        {
            pizzaToppings = new Dictionary<ToppingName, Topping>();

            pizzaToppings.Add(ToppingName.SatchPan, new Topping(ToppingName.SatchPan) { ForCalzone = false, SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.SteakNCheeseCalzone, new Topping(ToppingName.SteakNCheeseCalzone) { ForCalzone = true, ForPizza = false, SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.Major, new Topping(ToppingName.Major) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.Anchovies, new Topping(ToppingName.Anchovies));
            pizzaToppings.Add(ToppingName.Artichokes, new Topping(ToppingName.Artichokes));
            pizzaToppings.Add(ToppingName.Bacon, new Topping(ToppingName.Bacon));
            pizzaToppings.Add(ToppingName.BananaPeppers, new Topping(ToppingName.BananaPeppers));
            pizzaToppings.Add(ToppingName.Basil, new Topping(ToppingName.Basil));
            pizzaToppings.Add(ToppingName.Beef, new Topping(ToppingName.Beef));
            pizzaToppings.Add(ToppingName.BlackOlives, new Topping(ToppingName.BlackOlives));
            pizzaToppings.Add(ToppingName.Broccoli, new Topping(ToppingName.Broccoli));
            pizzaToppings.Add(ToppingName.Carrots, new Topping(ToppingName.Carrots));
            pizzaToppings.Add(ToppingName.Cheese, new Topping(ToppingName.Cheese));
            pizzaToppings.Add(ToppingName.CrispyCook, new Topping(ToppingName.CrispyCook) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = false, ForPizza = false });
            pizzaToppings.Add(ToppingName.DAIYA, new Topping(ToppingName.DAIYA) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            //pizzaToppings.Add(ToppingName.Deep, new Topping(ToppingName.Deep) { SpecialPricingType = SpecialPricingType.SpecialLogic, ForCalzone = false });
            pizzaToppings.Add(ToppingName.ExtraCheese, new Topping(ToppingName.ExtraCheese));
            pizzaToppings.Add(ToppingName.ExtraMozarellaCalzone, new Topping(ToppingName.ExtraMozarellaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.ExtraPSauceOS, new Topping(ToppingName.ExtraPSauceOS));
            pizzaToppings.Add(ToppingName.ExtraPSauceOP, new Topping(ToppingName.ExtraPSauceOP) { ForCalzone = false });
            pizzaToppings.Add(ToppingName.ExtraRicottaCalzone, new Topping(ToppingName.ExtraRicottaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.Feta, new Topping(ToppingName.Feta));
            pizzaToppings.Add(ToppingName.Garlic, new Topping(ToppingName.Garlic));
            pizzaToppings.Add(ToppingName.GlutenFreeIndyOnly, new Topping(ToppingName.GlutenFreeIndyOnly) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = false, ForIndyOnly = true });
            pizzaToppings.Add(ToppingName.GreenOlives, new Topping(ToppingName.GreenOlives));
            pizzaToppings.Add(ToppingName.GreenPeppers, new Topping(ToppingName.GreenPeppers));
            //pizzaToppings.Add(ToppingName.HalfMajor, new Topping(ToppingName.HalfMajor) { SpecialPricingType = SpecialPricingType.SpecialLogic, ForCalzone = false });
            pizzaToppings.Add(ToppingName.Ham, new Topping(ToppingName.Ham) { ForCalzone = true, ForPizza = true });
            pizzaToppings.Add(ToppingName.Jalapenos, new Topping(ToppingName.Jalapenos));
            pizzaToppings.Add(ToppingName.KidCook, new Topping(ToppingName.KidCook) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = false, ForPizza = false });
            pizzaToppings.Add(ToppingName.LightCook, new Topping(ToppingName.LightCook) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = false, ForPizza = false });
            pizzaToppings.Add(ToppingName.LightSauce, new Topping(ToppingName.LightSauce) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightMozarella, new Topping(ToppingName.LightMozarella) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.LightRicotta, new Topping(ToppingName.LightRicotta) { SpecialPricingType = SpecialPricingType.Free, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.Meatballs, new Topping(ToppingName.Meatballs));
            pizzaToppings.Add(ToppingName.Mushrooms, new Topping(ToppingName.Mushrooms));
            pizzaToppings.Add(ToppingName.NoButter, new Topping(ToppingName.NoButter) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.NoCheese, new Topping(ToppingName.NoCheese) { SpecialPricingType = SpecialPricingType.SubtractTopping });
            pizzaToppings.Add(ToppingName.NoMozarella, new Topping(ToppingName.NoMozarella) { SpecialPricingType = SpecialPricingType.SubtractTopping, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.NoRicotta, new Topping(ToppingName.NoRicotta) { SpecialPricingType = SpecialPricingType.SubtractTopping, ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.NoSauce, new Topping(ToppingName.NoSauce) { SpecialPricingType = SpecialPricingType.Free });
            pizzaToppings.Add(ToppingName.Onion, new Topping(ToppingName.Onion));
            pizzaToppings.Add(ToppingName.PestoTopping, new Topping(ToppingName.PestoTopping));
            pizzaToppings.Add(ToppingName.Pepperoni, new Topping(ToppingName.Pepperoni));
            pizzaToppings.Add(ToppingName.Pineapple, new Topping(ToppingName.Pineapple));
            pizzaToppings.Add(ToppingName.RedOnions, new Topping(ToppingName.RedOnions));
            pizzaToppings.Add(ToppingName.Ricotta, new Topping(ToppingName.Ricotta) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.RicottaCalzone, new Topping(ToppingName.RicottaCalzone) { ForCalzone = true, ForPizza = false });
            pizzaToppings.Add(ToppingName.RoastedRedPepper, new Topping(ToppingName.RoastedRedPepper));
            pizzaToppings.Add(ToppingName.Sausage, new Topping(ToppingName.Sausage));
            pizzaToppings.Add(ToppingName.Spinach, new Topping(ToppingName.Spinach));
            pizzaToppings.Add(ToppingName.Steak, new Topping(ToppingName.Steak));
            pizzaToppings.Add(ToppingName.SundriedTomatoes, new Topping(ToppingName.SundriedTomatoes));
            pizzaToppings.Add(ToppingName.Teese, new Topping(ToppingName.Teese) { SpecialPricingType = SpecialPricingType.DoubleTopping });
            pizzaToppings.Add(ToppingName.TempehBBQ, new Topping(ToppingName.TempehBBQ));
            pizzaToppings.Add(ToppingName.TempehOriginal, new Topping(ToppingName.TempehOriginal));
            pizzaToppings.Add(ToppingName.Tomatoes, new Topping(ToppingName.Tomatoes));
            pizzaToppings.Add(ToppingName.Zucchini, new Topping(ToppingName.Zucchini));
        }

        private static void CreateCookieDictionary()
        {
            cookieDictionary = new Dictionary<DessertType, Dessert>();
            DessertType[] cookieTypes = new DessertType[]
            {
                DessertType.SnickerDoodleCookie,
                DessertType.ChocolateChipCookie,
                DessertType.PeanutButterCookie,
                DessertType.OatmealRaisinCookie,
                DessertType.MexicanWeddingCookie,
                DessertType.PumpkinSpiceCookie,
                DessertType.VeganPumpkinSpiceCookie
            };
            foreach (var cookieType in cookieTypes)
            {
                Dessert newDessert = new Dessert(cookieType);
                cookieDictionary.Add(cookieType, newDessert);
            }
        }


        private static void CreateDessertDictionary()
        {
            dessertDictionary = new Dictionary<DessertType, Dessert>();
            DessertType[] dessertTypes = new DessertType[]
           {
                DessertType.ChocolateCake,
                DessertType.Brownie,
                DessertType.Bonbon,
                DessertType.VanillaCannoli,
                DessertType.ChocolateCannoli,
                DessertType.HalfAndHalfCannoli,
                DessertType.AppleCrumbCheesecake,
                DessertType.WholeCake,
                DessertType.AnyCookie,
                DessertType.VeganDessert,
                DessertType.ThreeDollarDessert
           };
         
            foreach (var dessertType in dessertTypes)
            {
                Dessert newDessert = new Dessert(dessertType);
                dessertDictionary.Add(dessertType, newDessert);
            }
        }

        public static decimal GetDbItemId(DessertType dessertType)
        {
            if (DessertTypeDbIdDictionary.ContainsKey(dessertType))
            {
                return DessertTypeDbIdDictionary[dessertType];
            }
            return 0;
        }

        private static void CreateDbIdDessertTypeDictionary()
        {
            dbIdDessertTypeDictionary = new Dictionary<decimal, DessertType>()
            {
                 {191, DessertType.AnyCookie },
                 {167, DessertType.AppleCrumbCheesecake},
                 {70, DessertType.Bonbon },
                 {64, DessertType.Brownie },
                 {62, DessertType.ChocolateCake },
                 {72, DessertType.ChocolateCannoli },
                { 65, DessertType.ChocolateChipCookie },
                { 73, DessertType.HalfAndHalfCannoli  },
                 {165, DessertType.MexicanWeddingCookie },
                 {69, DessertType.OatmealRaisinCookie },
                {66, DessertType.PeanutButterCookie },
                { 201, DessertType.PumpkinSpiceCookie },
                { 63, DessertType.SnickerDoodleCookie },
                { 213,  DessertType.ThreeDollarDessert },
                { 71, DessertType.VanillaCannoli },
                { 192, DessertType.VeganDessert },
                   { 202, DessertType.VeganPumpkinSpiceCookie },
                      { 169, DessertType.WholeCake }
            };
        }

        private static void CreateDessertTypeDbIdDictionary()
        {
            dessertTypeDbIdDictionary = new Dictionary<DessertType, decimal>()
            {
                 {DessertType.AnyCookie, 191 },
                 {DessertType.AppleCrumbCheesecake, 167 },
                 {DessertType.Bonbon, 70 },
                 {DessertType.Brownie, 64 },
                 {DessertType.ChocolateCake, 62 },
                 {DessertType.ChocolateCannoli, 72 },
                { DessertType.ChocolateChipCookie, 65 },
                { DessertType.HalfAndHalfCannoli, 73 },
                 {DessertType.MexicanWeddingCookie, 165 },
                 {DessertType.OatmealRaisinCookie, 69 },
                {DessertType.PeanutButterCookie, 66 },
                { DessertType.PumpkinSpiceCookie, 201 },
                { DessertType.SnickerDoodleCookie, 63 },
                { DessertType.ThreeDollarDessert, 213 },
                { DessertType.VanillaCannoli, 71 },
                { DessertType.VeganDessert, 192 },
                   { DessertType.VeganPumpkinSpiceCookie, 202 },
                      { DessertType.WholeCake, 169 }
            };
        }





        public static void LoadInitialSaladToppings()
        {

            saladToppings = new Dictionary<ToppingName, Topping>();
            saladToppings.Add(ToppingName.FiftyCentsUpcharge, new Topping(ToppingName.FiftyCentsUpcharge) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = .50M });
            saladToppings.Add(ToppingName.ExtraCheese, new Topping(ToppingName.ExtraCheese) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = .50M });
            saladToppings.Add(ToppingName.ExtraDressingOnSide, new Topping(ToppingName.ExtraDressingOnSide) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.AddSubtractAmount, SpecialPriceChange = 1.50M });
            saladToppings.Add(ToppingName.Feta, new Topping(ToppingName.Feta) { ForPizza = false, ForSalad = true });
            saladToppings.Add(ToppingName.Ham, new Topping(ToppingName.Ham) { ForPizza = false, ForSalad = true });
            saladToppings.Add(ToppingName.Almonds, new Topping(ToppingName.Almonds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Apples, new Topping(ToppingName.Apples) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Carrots, new Topping(ToppingName.Carrots) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Cheese, new Topping(ToppingName.Cheese) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Cucumbers, new Topping(ToppingName.Cucumbers) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.DressingOnSide, new Topping(ToppingName.DressingOnSide) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Joiner, new Topping(ToppingName.Joiner) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Lettuce, new Topping(ToppingName.Lettuce) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoDressing, new Topping(ToppingName.NoDressing) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoNutsNoSeeds, new Topping(ToppingName.NoNutsNoSeeds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.NoNutsSeedsOk, new Topping(ToppingName.NoNutsSeedsOk) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Onion, new Topping(ToppingName.Onion) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.OutFirst, new Topping(ToppingName.OutFirst) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.PecansWalnuts, new Topping(ToppingName.PecansWalnuts) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Seeds, new Topping(ToppingName.Seeds) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.TakeoutBring2Table, new Topping(ToppingName.TakeoutBring2Table) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.TakeoutKeepInKitch, new Topping(ToppingName.TakeoutKeepInKitch) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.Tomatoes, new Topping(ToppingName.Tomatoes) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
            saladToppings.Add(ToppingName.WithOrder, new Topping(ToppingName.WithOrder) { ForPizza = false, ForSalad = true, SpecialPricingType = SpecialPricingType.Free });
        }
    }
}
