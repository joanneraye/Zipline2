using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Interfaces;


namespace Zipline2.Models
{
    public class LunchSpecial : OrderItem, IHasToppings
    {
        public decimal PricePerPizzaTopping { get; set; }
        public decimal PriceAddToSalad { get; set; }
        public LunchSpecial(CustomerSelections guiData)
        { 
        }

        public override string ToString()
        {
            return "Lunch Special (slice and salad)";
        }

        public void AddToppings(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public override void PopulateDisplayName(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public override void PopulatePricePerItem(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }
    }
}
