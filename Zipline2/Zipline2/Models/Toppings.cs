using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    /// <summary>
    /// A Toppings class object should always be contained in a Pizza
    /// class because it is always associated with a particular pizza.
    /// </summary>
    public class Toppings
    {
        #region Properties
        
        public List<Topping> CurrentToppings { get; private set; }

        private static List<Topping> allToppings;
        public static List<Topping> AllToppings
        {
            get
            {
                if (allToppings == null || allToppings.Count == 0)
                {
                    LoadInitialToppings();
                }
                return allToppings;
            }
        }
        public PizzaType PizzaTypeForPricing { get; set; }
        private decimal toppingsTotal;
        public decimal ToppingsTotal
        {
            get
            {
                return toppingsTotal;
            }
            private set
            {
                toppingsTotal = value;
                MessagingCenter.Send<Toppings>(this, "ToppingsTotalUpdated");
            }
        }

        private static Dictionary<ToppingName, decimal> toppingDbIdDictionary;
        public static Dictionary<ToppingName, decimal> ToppingDbIdDictionary
        {
            get
            {
                if (toppingDbIdDictionary == null)
                {
                    CreateToppingDbIdDictionary();
                }
                return toppingDbIdDictionary;
            }
        }

        private static Dictionary<decimal, ToppingName> dbIdToppingDictionary;
        public static Dictionary<decimal, ToppingName> DbIdToppingDictionary
        {
            get
            {
                if (dbIdToppingDictionary == null)
                {
                    CreateDbIdToppingDictionary();
                }
                return dbIdToppingDictionary;
            }
        }

        #endregion

        #region constructor

        /// <summary>
        /// Toppings should always be associated with a particular pizza already chosen.
        /// </summary>
        /// <param name="pizzaWithTheseToppings"></param>
        public Toppings(PizzaType pizzaTypeForPricing)
        {
            CurrentToppings = new List<Topping>();
            PizzaTypeForPricing = pizzaTypeForPricing;
        }
        #endregion

        #region Methods
        public static void LoadInitialToppings()
        {
            allToppings = new List<Topping>()
            {
                new Topping(ToppingName.Anchovies),
                new Topping(ToppingName.Artichokes),
                new Topping(ToppingName.Bacon),
                new Topping(ToppingName.BananaPeppers),
                new Topping(ToppingName.Basil),
                new Topping(ToppingName.Beef),
                new Topping(ToppingName.BlackOlives),
                new Topping(ToppingName.Broccoli),
                new Topping(ToppingName.Carrots),
                new Topping(ToppingName.Cheese),
                new Topping(ToppingName.DAIYA),
                new Topping(ToppingName.Deep) {SpecialPricingType = SpecialPricingType.Unknown},
                new Topping(ToppingName.ExtraCheese),
                new Topping(ToppingName.ExtraMozarellaCalzone),
                new Topping(ToppingName.ExtraPSauceOS) { SpecialPricingType = SpecialPricingType.AddHalfTopping },
                new Topping(ToppingName.ExtraPSauceOP) { SpecialPricingType = SpecialPricingType.AddHalfTopping },
                new Topping(ToppingName.ExtraRicottaCalzone),
                new Topping(ToppingName.Feta),
                new Topping(ToppingName.Garlic) ,
                new Topping(ToppingName.GreenOlives),
                new Topping(ToppingName.GreenPeppers),
                new Topping(ToppingName.HalfMajor)
                            { ToppingWholeHalf = ToppingWholeHalf.HalfA },
                new Topping(ToppingName.Jalapenos),
                new Topping(ToppingName.Meatballs),
                new Topping(ToppingName.Mushrooms),
                new Topping(ToppingName.NoCheese) {SpecialPricingType = SpecialPricingType.GetExtraTopping},
                new Topping(ToppingName.Onion),
                new Topping(ToppingName.PestoTopping) ,
                new Topping(ToppingName.Pepperoni),
                new Topping(ToppingName.Pineapple),
                new Topping(ToppingName.RedOnions),
                new Topping(ToppingName.Ricotta),
                new Topping(ToppingName.RoastedRedPepper),
                new Topping(ToppingName.Sausage),
                new Topping(ToppingName.Spinach),
                new Topping(ToppingName.Steak),
                new Topping(ToppingName.SundriedTomatoes),
                new Topping(ToppingName.Teese) {SpecialPricingType = SpecialPricingType.DoubleTopping},
                new Topping(ToppingName.TempehBBQ),
                new Topping(ToppingName.TempehOriginal),
                new Topping(ToppingName.Tomatoes),
                new Topping(ToppingName.Zucchini),
                new Topping(ToppingName.LightSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightRicotta) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoButter) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoRicotta) {SpecialPricingType = SpecialPricingType.SubtractTopping}
            };
        }
        /// <summary>
        /// Method should be called when the topping prices need to be updated
        /// but a topping has not been added.  (When a topping is added or removed, this will
        /// be done automatically in this class.)  Example would be when the base type changes, 
        /// topping prices can be different.  Or when the topping has been added
        /// but is changed to half of the pizza.
        /// </summary>
        public void UpdateToppingsTotal()
        {
            ToppingsTotal = GetCurrentToppingsCost();
        }
            
        public bool CurrentToppingsHas(ToppingName toppingName)
        {
            foreach (var topping in CurrentToppings) 
            {
                if (toppingName == topping.ToppingName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTopping(Topping toppingToAdd, bool calculateTotal = true)
        {
            CurrentToppings.Add(toppingToAdd);
            if (calculateTotal)
            {
                UpdateToppingsTotal();
            }
        }

        public void AddToppings(List<Topping> toppingsToAdd)
        {
            foreach (var topping in toppingsToAdd)
            {
                if (CurrentToppingsHas(topping.ToppingName))
                {
                    RemoveTopping(topping.ToppingName, false);
                }
                AddTopping(topping, false);
            }

            UpdateToppingsTotal();
        }


        public void ChangeToppingToHalf(ToppingName toppingName, ToppingWholeHalf toppingHalf)
        {
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == toppingName)
                {
                    topping.ToppingWholeHalf = toppingHalf;
                    break;
                }
            }
            UpdateToppingsTotal();
        }
        public void RemoveTopping(ToppingName toppingName, bool calculateTotal = true)
        {
            int indexToRemove = 99;
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == toppingName)
                {
                    //Can't remove an item from a list you are currently iterating through.
                    indexToRemove = CurrentToppings.IndexOf(topping);
                    break;
                }
            }
            if (indexToRemove != 99)
            {
                CurrentToppings.RemoveAt(indexToRemove);
            } 
            if (calculateTotal)
            {
                ToppingsTotal = GetCurrentToppingsCost();
            }
        }

        public void RemoveToppings(List<ToppingName> toppingNames)
        {
            foreach (var toppingName in toppingNames)
            {
                RemoveTopping(toppingName, false);
            }
            UpdateToppingsTotal();
        }

        private decimal GetCurrentToppingsCost()
        {
            decimal toppingCost = 0M;
            decimal toppingCountForPrice = GetToppingCountForPricing();
            int wholeToppingCount = Convert.ToInt32(Math.Floor(toppingCountForPrice));
            int wholeToppingIndex = (wholeToppingCount - 1);
            var thisPizzaToppingPrices = Prices.ToppingsPriceDictionary[PizzaTypeForPricing];
            var lastToppingPriceIndex = thisPizzaToppingPrices.Length - 2;
            var additionalToppingCostIndex = thisPizzaToppingPrices.Length - 1;
            var numberOfExtraWholeToppings = wholeToppingIndex - lastToppingPriceIndex;
            var pricePerAdditionalTopping = thisPizzaToppingPrices[additionalToppingCostIndex];
            if (wholeToppingCount <= 0)
            {
                // Whole topping count is <= 0, so topping cost will be zero or a negative number.
                return wholeToppingCount * pricePerAdditionalTopping;
            }
            else if (numberOfExtraWholeToppings > 0)
            {
                var additionalToppingCost = numberOfExtraWholeToppings * pricePerAdditionalTopping;
                toppingCost = thisPizzaToppingPrices[lastToppingPriceIndex] + additionalToppingCost;
            }
            else
            {
                toppingCost = thisPizzaToppingPrices[wholeToppingIndex];
             
            }

            if ((toppingCountForPrice % 1) > 0)      //Includes 1/2 a topping
            {
                int roundUpToppingCount = Convert.ToInt32(Math.Ceiling(toppingCountForPrice));
                int nextHigherToppingIndex = roundUpToppingCount - 1;
                var toppingCostWithHalfTopping = toppingCost + (pricePerAdditionalTopping / 2);
                if (nextHigherToppingIndex <= lastToppingPriceIndex &&
                    toppingCostWithHalfTopping > thisPizzaToppingPrices[nextHigherToppingIndex])
                {
                    toppingCost = thisPizzaToppingPrices[nextHigherToppingIndex];
                }
                else
                {
                    toppingCost = toppingCostWithHalfTopping;
                }
            }
            
            return toppingCost;
        }

        private decimal GetToppingCountForPricing()
        {
            decimal toppingCount = 0M;
            //TODO:  Still have to handle half and whole toppings
            foreach (var topping in CurrentToppings)
            { 
                switch (topping.SpecialPricingType)
                {
                    case SpecialPricingType.Free:
                        break;
                    case SpecialPricingType.None:
                        if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                        {
                            toppingCount++;
                        }
                        else
                        {
                            toppingCount += .5M; ;
                        }
                        break;
                    case SpecialPricingType.AddHalfTopping: 
                        toppingCount += .5M;
                        break;
                    case SpecialPricingType.SubtractTopping:
                    case SpecialPricingType.GetExtraTopping:
                        toppingCount--;
                        break;
                    case SpecialPricingType.DoubleTopping:
                        if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                        {
                            toppingCount += 2M;
                        }
                        else
                        {
                            toppingCount++;
                        }
                        break;
                }
            }
            return toppingCount;
        }
      
        public void AddMajorToppings()
        {
            var majorToppings = new List<Topping>();
            majorToppings.Add(new Topping(ToppingName.Pepperoni));
            majorToppings.Add(new Topping(ToppingName.Mushrooms));
            majorToppings.Add(new Topping(ToppingName.Sausage));
            majorToppings.Add(new Topping(ToppingName.GreenPeppers));
            majorToppings.Add(new Topping(ToppingName.Onion)); ;
            majorToppings.Add(new Topping(ToppingName.BlackOlives));
            AddToppings(majorToppings);
        }

        public void AddMajorToppingsToHalf(ToppingWholeHalf whichHalf)
        {
            var majorToppings = new List<Topping>();
            majorToppings.Add(new Topping(ToppingName.Pepperoni, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Mushrooms, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Sausage, whichHalf));
            majorToppings.Add(new Topping(ToppingName.GreenPeppers, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Onion, whichHalf)); ;
            majorToppings.Add(new Topping(ToppingName.BlackOlives, whichHalf));
            AddToppings(majorToppings);
        }

        public void ChangeMajorToppingsHalf(ToppingWholeHalf whichHalf)
        {
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == ToppingName.Pepperoni ||
                    topping.ToppingName == ToppingName.Mushrooms ||
                    topping.ToppingName == ToppingName.Sausage ||
                    topping.ToppingName == ToppingName.GreenPeppers ||
                    topping.ToppingName == ToppingName.Onion ||
                    topping.ToppingName == ToppingName.BlackOlives)
                {
                    topping.ToppingWholeHalf = whichHalf;
                }
            }
            ToppingsTotal = GetCurrentToppingsCost();
        }

        public static decimal GetDbItemId(ToppingName toppingName)
        {
            if (ToppingDbIdDictionary.ContainsKey(toppingName))
            {
                return ToppingDbIdDictionary[toppingName];
            }
            return 0;
        }

        private static void CreateDbIdToppingDictionary()
        {
            dbIdToppingDictionary = new Dictionary<decimal, ToppingName>
            {
                 { 1, ToppingName.ExtraPSauceOS },
             
                { 9, ToppingName.Lettuce },
                 { 11, ToppingName.ExtraCheese  },
                   { 12, ToppingName.Pepperoni },
                   { 13, ToppingName.GreenPeppers },
                { 14, ToppingName.Ham },
                   { 15, ToppingName.Feta },
                  { 16, ToppingName.ExtraPSauceOP },
                 { 17, ToppingName.Basil },
                {18, ToppingName.Major },
                  { 20, ToppingName.Meatballs  },
                   { 21, ToppingName.SundriedTomatoes },
                   { 23, ToppingName.BlackOlives },
                     { 26, ToppingName.GreenOlives },
                                 { 27, ToppingName.Anchovies },
                                   { 28, ToppingName.Tomatoes },
                                 { 29, ToppingName.RoastedRedPepper },
                                  { 30, ToppingName.Steak },
                { 31, ToppingName.Artichokes },
                 { 32, ToppingName.BananaPeppers },
                   { 33, ToppingName.Zucchini },
                  { 34, ToppingName.Broccoli },
                    { 36, ToppingName.TempehOriginal },
                   { 37, ToppingName.TempehBBQ },
                   { 38, ToppingName.Jalapenos },
                    { 39, ToppingName.Pineapple },
                  { 40, ToppingName.Carrots },
                    { 42, ToppingName.Spinach },
                { 43, ToppingName.Bacon },
                { 44, ToppingName.Onion },
                   { 47, ToppingName.Garlic },
                    { 48, ToppingName.RedOnions },
                       { 52, ToppingName.LightCook  },
                { 53, ToppingName.CrispyCook },
                { 24, ToppingName.Beef  },
                { 61, ToppingName.DAIYA },
                 { 62, ToppingName.Teese },
                  { 67, ToppingName.PestoTopping },
                     { 75, ToppingName.ButterOk },
                   { 76, ToppingName.NoButter },
                   { 82, ToppingName.Ricotta },
                  
                    { 90,  ToppingName.Deep },
                      { 93, ToppingName.NoSauce },
                          { 94, ToppingName.LightSauce },
                       { 96, ToppingName.OutFirst },
                       { 97, ToppingName.SliceCutInHalfSamePlate },
                        { 98, ToppingName.SliceCutInHalfSepPlate },
                       { 100, ToppingName.Joiner },
                        { 101, ToppingName.CutInto12 },
                 { 103, ToppingName.NoCheese },
                { 105, ToppingName.Cheese },
                   { 107, ToppingName.SaladWithOrder },
                   {108, ToppingName.NoRicotta },
                {109, ToppingName.NoMozarella },
                { 110, ToppingName.KidCook },
                   { 122, ToppingName.LightRicotta },
                     { 123, ToppingName.LightMozarella },
                      { 124, ToppingName.NoCut },
                       { 126, ToppingName.TakeoutBring2Table },
                  
                 { 132, ToppingName.Mushrooms },
                   { 141, ToppingName.Sausage },
                 { 148, ToppingName.ExtraRicottaCalzone },
                { 149, ToppingName.ExtraMozarellaCalzone  },
                 { 150, ToppingName.TakeoutKeepInKitch },
                { 151, ToppingName.HalfMajor }
            };
        }
        private static void CreateToppingDbIdDictionary()
        {
            toppingDbIdDictionary = new Dictionary<ToppingName, decimal>
            {
                { ToppingName.Anchovies, 27 },
                { ToppingName.Artichokes, 31 },
                { ToppingName.Bacon, 43 },
                { ToppingName.BananaPeppers, 32 },
                { ToppingName.Basil, 17 },
                { ToppingName.Beef, 24 },
                { ToppingName.BlackOlives, 23 },
                { ToppingName.Broccoli, 34 },
                { ToppingName.Carrots, 40 },
                { ToppingName.DAIYA, 61 },
                { ToppingName.ExtraCheese, 11 },
                { ToppingName.ExtraMozarellaCalzone, 149 },
                { ToppingName.ExtraPSauceOP, 16 },
                { ToppingName.ExtraPSauceOS, 1 },
                { ToppingName.ExtraRicottaCalzone, 148 },
                { ToppingName.Feta, 15 },
                { ToppingName.Garlic, 47 },
                { ToppingName.GreenOlives, 26 },
                { ToppingName.GreenPeppers, 13 },
                 { ToppingName.Lettuce, 9 },
                { ToppingName.HalfMajor, 151 },
                { ToppingName.Ham, 14 },
                { ToppingName.Jalapenos, 38 },
                {ToppingName.Major, 18 },
                { ToppingName.Meatballs, 20 },
                { ToppingName.Mushrooms, 132 },
                { ToppingName.NoCheese, 103 },
                { ToppingName.Onion, 44 },
                { ToppingName.PestoTopping, 67 },
                { ToppingName.Pepperoni, 12 },
                { ToppingName.Pineapple, 39 },
                { ToppingName.RedOnions, 48 },
                { ToppingName.Ricotta, 82 },
                { ToppingName.RoastedRedPepper, 29 },
                { ToppingName.Sausage, 141 },
                { ToppingName.Spinach, 42 },
                { ToppingName.Steak, 30 },
                { ToppingName.SundriedTomatoes, 21 },
                { ToppingName.Teese, 62 },
                { ToppingName.TempehBBQ, 37 },
                { ToppingName.TempehOriginal, 36 },
                { ToppingName.Tomatoes, 28 },
                { ToppingName.Zucchini, 33 },
                { ToppingName.Cheese, 105 },
                { ToppingName.Deep, 90 },
                { ToppingName.LightSauce, 94 },
                { ToppingName.LightMozarella, 123 },
                { ToppingName.LightRicotta, 122 },
                { ToppingName.NoButter, 76 },
                { ToppingName.NoSauce, 93 },
                 { ToppingName.NoRicotta, 108 },
                { ToppingName.NoMozarella, 109 },
                { ToppingName.LightCook, 52  },
                { ToppingName.CrispyCook, 53 },
                { ToppingName.KidCook, 110 },
                { ToppingName.ButterOk, 75 },
                { ToppingName.CutInto12, 101 },
                { ToppingName.Joiner, 100 },
                { ToppingName.NoCut, 124 },
                { ToppingName.OutFirst, 96 },
                { ToppingName.SaladWithOrder, 107 },
                { ToppingName.SliceCutInHalfSamePlate, 97 },
                { ToppingName.SliceCutInHalfSepPlate, 98 },
                { ToppingName.TakeoutBring2Table, 126 },
                { ToppingName.TakeoutKeepInKitch, 150 }
            };
        }

        #endregion
    }
}
