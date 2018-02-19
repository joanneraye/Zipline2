using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class LunchSpecial : OrderItem
    {
        public decimal PricePerPizzaTopping { get; set; }
        public decimal PriceAddToSalad { get; set; }
        public LunchSpecial()
        { 
        }

        public override string ToString()
        {
            return "Lunch Special (slice and salad)";
        }
    }
}
