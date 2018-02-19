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
    }
}
