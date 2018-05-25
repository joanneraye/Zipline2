using System;
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
    }
}
