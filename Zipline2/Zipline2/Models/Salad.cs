using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Zipline2.PageModels;

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

        public override void PopulateDisplayName()
        {
            throw new NotImplementedException();
        }

        public override void PopulatePricePerItem()
        {
            throw new NotImplementedException();
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            throw new NotImplementedException();
        }

        public override void CompleteOrderItem()
        {
            throw new NotImplementedException();
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
            throw new NotImplementedException();
        }

        public override List<GuestModifier> CreateMods()
        {
            return new List<GuestModifier>();
        }
    }
}
