﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Salad : OrderItem
    {
        public enum SaladSize
        {
            LunchSpecial,
            Small,
            Large
        }
        public SaladSize SizeOfSalad { get; set; }

        public Salad()
        {

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
