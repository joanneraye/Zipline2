using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    /// <summary>
    /// The Toppings class may be used alone while creating a pizza
    /// with toppings before the pizza has been added to the 
    /// order.  It can also be used as a part of the OrderItem
    /// once the pizza has been added to the order by the OrderManager.
    /// </summary>
    public class Toppings
    {
        #region Properties
        public List<Topping> CurrentToppings { get; set; }
        public PizzaType PizzaTypeForPricing { get; set; }
        public decimal ToppingsTotal { get; set; } = 0M;
        #endregion

        #region constructor
        /// <summary>
        /// Since the price of toppings is dependent on the 
        /// type of pizza to which the toppings are being
        /// aded, this type is required in the constructor.
        /// </summary>
        /// <param name="pizzaTypeForPricing"></param>
        public Toppings(PizzaType pizzaTypeForPricing) 
        {
            CurrentToppings = new List<Topping>();
            PizzaTypeForPricing = pizzaTypeForPricing;            
        }
        #endregion

        #region Methods

        public void UpdateToppingsTotal()
        {
            ToppingsTotal = GetCurrentToppingsCost();
        }
        public void AddToppings(List<Topping> toppingsToAdd)
        {
            CurrentToppings.AddRange(toppingsToAdd);
            ToppingsTotal = GetCurrentToppingsCost();
        }
       
        public void AddTopping(Topping toppingToAdd)
        {
            CurrentToppings.Add(toppingToAdd);
            ToppingsTotal = GetCurrentToppingsCost();
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
            ToppingsTotal = GetCurrentToppingsCost();
        }
        public void RemoveTopping(ToppingName toppingName)
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
           
            ToppingsTotal = GetCurrentToppingsCost();
        }

        public decimal GetCurrentToppingsCost()
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
                toppingCost = thisPizzaToppingPrices[toppingIndex];
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
        #endregion
    }
}
