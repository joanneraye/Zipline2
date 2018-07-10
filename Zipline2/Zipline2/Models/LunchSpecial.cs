﻿using Staunch.POS.Classes;
using System;
using System.Collections.Generic;

namespace Zipline2.Models
{
    public class LunchSpecial : OrderItem
    {
        public decimal PricePerPizzaTopping { get; set; }
        public decimal PriceAddToSalad { get; set; }
        public LunchSpecial(CustomerSelection guiData)
        { 
        }

        public override string ToString()
        {
            return "Lunch Special (slice and salad)";
        }
       
        public override void PopulateDisplayName()
        {
            //ItemName = DisplayNames.
        }

        public override void PopulatePricePerItem()
        {
            //BasePrice = Prices.
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            throw new NotImplementedException();
        }


        public override List<GuestModifier> CreateMods()
        {
            return new List<GuestModifier>();
        }

        public override void PopulateBasePrice()
        {
            throw new NotImplementedException();
        }
    }
}
