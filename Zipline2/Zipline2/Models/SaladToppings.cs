using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class SaladToppings : Toppings
    {

        public SaladSize SaladSizeForPricing { get; set; }
        public decimal SaladToppingPrice { get; set; }

        public SaladToppings(SaladSize saladSizeForPricing)
        {
            SaladSizeForPricing = saladSizeForPricing;
            SaladToppingPrice = Prices.GetSaladToppingPrice(saladSizeForPricing);
        }

        protected override decimal GetCurrentToppingsCost()
        {
            decimal toppingsTotal = 0;
            foreach (var topping in CurrentToppings)
            {
                if (topping.SpecialPricingType == SpecialPricingType.AddSubtractAmount)
                {
                    toppingsTotal += topping.SpecialPriceChange;
                }
                else if (topping.SpecialPricingType == SpecialPricingType.DefaultOneTopping)
                {
                    toppingsTotal += SaladToppingPrice;
                }
            }
            return toppingsTotal;
        }
    }
      
}
