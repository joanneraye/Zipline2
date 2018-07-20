using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;

namespace Zipline2.Models
{
    public class SaladToppings : Toppings
    {

        public SaladSize SaladSizeForPricing { get; set; }
        public decimal SaladToppingPrice { get; set; }

        public Salad ThisSalad { get; set; }

        public SaladToppings(SaladSize saladSizeForPricing, Salad thisSalad)
        {
            SaladSizeForPricing = saladSizeForPricing;
            SaladToppingPrice = Prices.GetSaladToppingPrice(saladSizeForPricing);
            ThisSalad = thisSalad;
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
                    toppingsTotal += (SaladToppingPrice * topping.Count);
                }
            }
            return toppingsTotal;
        }
        public override void UpdateToppingsTotal()
        {
            base.UpdateToppingsTotal();
            ThisSalad.PopulatePricePerItem();
            //MessagingCenter.Send<SaladToppings>(this, "SaladToppingsTotalUpdated");
        }
    }
      
}
