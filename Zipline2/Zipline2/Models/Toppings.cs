using System;
using System.Collections.Generic;
using System.Text;
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
                new Topping(ToppingName.ExtraPSauceOS),
                new Topping(ToppingName.ExtraPSauceOP),
                new Topping(ToppingName.ExtraRicottaCalzone),
                new Topping(ToppingName.Feta),
                new Topping(ToppingName.Garlic) ,
                new Topping(ToppingName.GreenOlives),
                new Topping(ToppingName.GreenPeppers),
                new Topping(ToppingName.HalfMajor)
                            { ToppingWholeHalf = ToppingWholeHalf.HalfA},
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
                new Topping(ToppingName.Teese) {SpecialPricingType = SpecialPricingType.AddorSubtractAmount},
                new Topping(ToppingName.TempehBBQ),
                new Topping(ToppingName.TempehOriginal),
                new Topping(ToppingName.Tomatoes),
                new Topping(ToppingName.Zucchini),
                new Topping(ToppingName.LightSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightRicotta) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoButter) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoSauce) {SpecialPricingType = SpecialPricingType.Free}
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
            var regularToppings = new List<Topping>();
            decimal toppingCost = 0M;
            int theyGetAnExtraToppingCount = 0;
            var specialToppings = new List<Topping>();
            foreach (var topping in CurrentToppings)
            {
                if (topping.SpecialPricingType == SpecialPricingType.None)
                {
                    regularToppings.Add(topping);
                }
                else if (topping.SpecialPricingType == SpecialPricingType.GetExtraTopping)
                {
                    theyGetAnExtraToppingCount++;
                }
                else
                {
                    specialToppings.Add(topping);
                }
            }

            decimal toppingCountForPrice = GetToppingCountForPricing(regularToppings);

            if (theyGetAnExtraToppingCount > 0 && toppingCountForPrice > 0)
            {
                toppingCountForPrice -= theyGetAnExtraToppingCount;
            }
           
            if (toppingCountForPrice <= 0)
            {
                return toppingCost;
            }

            int wholeToppingCount = Convert.ToInt32(Math.Floor(toppingCountForPrice));
            int toppingIndex = (wholeToppingCount - 1);
            var thisPizzaToppingPrices = Prices.ToppingsPriceDictionary[PizzaTypeForPricing];
            var lastToppingPriceIndex = thisPizzaToppingPrices.Length - 2;
            var additionalToppingCostIndex = thisPizzaToppingPrices.Length - 1;
            var numberOfExtraToppings = toppingIndex - lastToppingPriceIndex;
            var pricePerAdditionalTopping = thisPizzaToppingPrices[additionalToppingCostIndex];
            if (numberOfExtraToppings > 0)
            { 
                var additionalToppingCost = numberOfExtraToppings * pricePerAdditionalTopping;
                toppingCost = thisPizzaToppingPrices[lastToppingPriceIndex] + additionalToppingCost;
            }
            else
            {
                if (toppingIndex >= 0)
                {
                    toppingCost = thisPizzaToppingPrices[toppingIndex];
                }
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

            if (specialToppings.Count > 0)
            {
                foreach (var topping in specialToppings)
                {
                    //This is just for a topping that says "half" like "Half Major"
                    if (topping.SpecialPricingType == SpecialPricingType.Half)
                    {
                        toppingCost = toppingCost / 2;
                    }
                    else if (topping.SpecialPricingType == SpecialPricingType.AddorSubtractAmount)
                    {
                        toppingCost = toppingCost + topping.SpecialPriceChange;
                    }
                }
            }
            return toppingCost;
        }

        private decimal GetToppingCountForPricing(List<Topping> toppings)
        {
            decimal toppingCount = 0M;
            foreach (var topping in toppings)
            {
                if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                {
                    toppingCount += 1M;
                }
                else
                {
                    toppingCount += .5M;
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
        #endregion
    }
}
