using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Data;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class CalzoneToppings : Toppings
    {
        public CalzoneType CalzoneType { get; set; }
        private Calzone ThisCalzone { get; set; }


        public CalzoneToppings(CalzoneType calzoneType, Calzone thisCalzone)
        {
            ThisCalzone = thisCalzone;
            CalzoneType = calzoneType;
        }

        public override void UpdateToppingsTotal()
        {
            base.UpdateToppingsTotal();
            if (ToppingsTotal < 0)
            {
                ToppingsTotal = 0;
            }
        }

        protected override decimal GetCurrentToppingsCost()
        {
            decimal toppingCost = 0M;
            //    decimal toppingCountForPrice = GetPizzaToppingCountForPricing(ref specialExtraCost, PizzaTypeForPricing);
            //    int wholeToppingCount = Convert.ToInt32(Math.Floor(toppingCountForPrice));
            //    int wholeToppingIndex = (wholeToppingCount - 1);
            //    var thisPizzaToppingPrices = Prices.GetPizzaToppingsPrices(PizzaTypeForPricing);
            //    var lastToppingPriceIndex = thisPizzaToppingPrices.Length - 2;
            //    var additionalToppingCostIndex = thisPizzaToppingPrices.Length - 1;
            //    var numberOfExtraWholeToppings = wholeToppingIndex - lastToppingPriceIndex;
            //    if (numberOfExtraWholeToppings < 0)
            //    {
            //        numberOfExtraWholeToppings = 0;
            //    }
            //    var pricePerAdditionalTopping = thisPizzaToppingPrices[additionalToppingCostIndex];

            //    switch (toppingCountForPrice)
            //    {
            //        case 0M:
            //        case -1M:
            //        case -.5M:
            //            return ((toppingCountForPrice * pricePerAdditionalTopping) + specialExtraCost);
            //        case .5M:
            //            return ((pricePerAdditionalTopping / 2) + specialExtraCost);
            //    }

            //    //Topping count is >= 1:
            //    //First calculate whole toppings cost:
            //    if (numberOfExtraWholeToppings > 0)
            //    {
            //        var additionalToppingCost = numberOfExtraWholeToppings * pricePerAdditionalTopping;
            //        toppingCost = thisPizzaToppingPrices[lastToppingPriceIndex] + additionalToppingCost;
            //    }
            //    else
            //    {
            //        toppingCost = thisPizzaToppingPrices[wholeToppingIndex];
            //    }

            //    //Next add partial topping if it exists:
            //    if ((toppingCountForPrice % 1) > 0)       
            //    {
            //        int roundUpToppingCount = Convert.ToInt32(Math.Ceiling(toppingCountForPrice));
            //        int nextHigherToppingIndex = roundUpToppingCount - 1;
            //        var toppingCostWithHalfTopping = toppingCost + (pricePerAdditionalTopping / 2);
            //        if (nextHigherToppingIndex <= lastToppingPriceIndex &&
            //            toppingCostWithHalfTopping > thisPizzaToppingPrices[nextHigherToppingIndex])
            //        {
            //            toppingCost = thisPizzaToppingPrices[nextHigherToppingIndex];
            //        }
            //        else
            //        {
            //            toppingCost = toppingCostWithHalfTopping;
            //        }
            //    }
            //    toppingCost += specialExtraCost;
            return toppingCost;
        }

        //private decimal GetPizzaToppingCountForPricing(ref decimal specialExtraCost, PizzaType pizzaType)
        //{
        //    decimal toppingCountForPricing = 0M;
        //    //TODO:  Still have to handle half and whole toppings
        //    foreach (var topping in CurrentToppings)
        //    {
        //        decimal thisToppingCount = 0M;
        //        //For Pan, Indy, & MFP, and Slice  extra sauce is just like another topping. 
        //        //Medium and Large Pizzas charge 1.50 extra for extra sauce.
        //        if (topping.ToppingName == ToppingName.ExtraPSauceOP ||
        //            topping.ToppingName == ToppingName.ExtraPSauceOS)
        //        {
        //            if (pizzaType == PizzaType.Medium ||
        //               pizzaType == PizzaType.Large)
        //            {
        //                specialExtraCost = 1.5M;
        //                topping.SpecialPricingType = SpecialPricingType.AddSubtractAmount;
        //            }
        //        }
        //        if (topping.ToppingWholeHalf != ToppingWholeHalf.Whole)
        //        {
        //            topping.SpecialPricingType = SpecialPricingType.AddHalfTopping;
        //        }

        //        switch (topping.SpecialPricingType)
        //        {
        //            case SpecialPricingType.Free:
        //            case SpecialPricingType.SpecialLogic:
        //            case SpecialPricingType.AddSubtractAmount:
        //                break;
        //            case SpecialPricingType.DefaultOneTopping:
        //                thisToppingCount = 1;
        //                break;
        //            case SpecialPricingType.AddHalfTopping:
        //                thisToppingCount = .5M;
        //                break;
        //            case SpecialPricingType.SubtractTopping:
        //                thisToppingCount = -1;
        //                break;
        //            case SpecialPricingType.DoubleTopping:
        //                if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
        //                {
        //                    thisToppingCount = 2M;
        //                }
        //                else
        //                {
        //                    thisToppingCount = 1;
        //                }
        //                break;
        //        }

        //        toppingCountForPricing += (thisToppingCount * topping.Count);
        //    }
        //    return toppingCountForPricing;
        //}


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


    }
}
