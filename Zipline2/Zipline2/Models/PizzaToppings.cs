using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class PizzaToppings : Toppings
    {
        public PizzaType PizzaTypeForPricing { get; set; }

        public PizzaToppings(PizzaType pizzaTypeForPricing)
        {
            PizzaTypeForPricing = pizzaTypeForPricing;
        }

        protected override decimal GetCurrentToppingsCost()
        {
            decimal specialExtraCost = 0M;
            decimal toppingCost = 0M;
            decimal toppingCountForPrice = GetPizzaToppingCountForPricing(ref specialExtraCost, PizzaTypeForPricing);
            int wholeToppingCount = Convert.ToInt32(Math.Floor(toppingCountForPrice));
            int wholeToppingIndex = (wholeToppingCount - 1);
            var thisPizzaToppingPrices = Prices.GetPizzaToppingsPrices(PizzaTypeForPricing);
            var lastToppingPriceIndex = thisPizzaToppingPrices.Length - 2;
            var additionalToppingCostIndex = thisPizzaToppingPrices.Length - 1;
            var numberOfExtraWholeToppings = wholeToppingIndex - lastToppingPriceIndex;
            var pricePerAdditionalTopping = thisPizzaToppingPrices[additionalToppingCostIndex];
            if (wholeToppingCount <= 0)
            {
                // Whole topping count is <= 0, so topping cost will be zero or a negative number.
                toppingCost = wholeToppingCount * pricePerAdditionalTopping;
                toppingCost += specialExtraCost;
                return toppingCost;
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
            toppingCost += specialExtraCost;
            return toppingCost;
        }

        private decimal GetPizzaToppingCountForPricing(ref decimal specialExtraCost, PizzaType pizzaType)
        {
            decimal toppingCountForPricing = 0M;
            //TODO:  Still have to handle half and whole toppings
            foreach (var topping in CurrentToppings)
            {
                decimal thisToppingCount = 0M;
                //For Pan, Indy, & MFP, and Slice  extra sauce is just like another topping. 
                //Medium and Large Pizzas charge 1.50 extra for extra sauce.
                if (topping.ToppingName == ToppingName.ExtraPSauceOP ||
                    topping.ToppingName == ToppingName.ExtraPSauceOS)
                {
                    if (pizzaType == PizzaType.Medium ||
                       pizzaType == PizzaType.Large)
                    {
                        specialExtraCost = 1.5M;
                        topping.SpecialPricingType = SpecialPricingType.AddSubtractAmount;
                    }
                }
                if (topping.ToppingWholeHalf != ToppingWholeHalf.Whole)
                {
                    topping.SpecialPricingType = SpecialPricingType.AddHalfTopping;
                }

                switch (topping.SpecialPricingType)
                {
                    case SpecialPricingType.Free:
                    case SpecialPricingType.SpecialLogic:
                    case SpecialPricingType.AddSubtractAmount:
                        break;
                    case SpecialPricingType.DefaultOneTopping:
                        thisToppingCount = 1;
                        break;
                    case SpecialPricingType.AddHalfTopping:
                        thisToppingCount = .5M;
                        break;
                    case SpecialPricingType.SubtractTopping:
                        thisToppingCount = -1;
                        break;
                    case SpecialPricingType.DoubleTopping:
                        if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                        {
                            thisToppingCount = 2M;
                        }
                        else
                        {
                            thisToppingCount = 1;
                        }
                        break;
                }
                toppingCountForPricing += (thisToppingCount * topping.Count);
            }
            return toppingCountForPricing;
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
            UpdateToppingsTotal();
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
            UpdateToppingsTotal();
        }

        private void GroupHalfAB()
        {
            List<Topping> sortedToppingList = new List<Topping>();
            List<Topping> halfAToppings = new List<Topping>();
            List<Topping> halfBToppings = new List<Topping>();

            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                {
                    sortedToppingList.Add(topping);
                }
                else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfA)
                {
                    halfAToppings.Add(topping);
                }
                else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfB)
                {
                    halfBToppings.Add(topping);
                }
            }
            if (halfAToppings.Count > 0 || halfBToppings.Count > 0)
            {
                sortedToppingList.AddRange(halfAToppings);
                sortedToppingList.AddRange(halfBToppings);
            }
        }
    }
}
