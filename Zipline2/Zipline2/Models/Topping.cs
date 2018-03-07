using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class Topping
    {
        public int ToppingId { get; set; }

        //Foreign key with OrderItem table - can include toppings for salad or pizza
        public int OrderItemId { get; set; }

        public string ToppingName { get; set; }

        public bool IsSelected { get; set; }

        public ToppingWholeHalf ToppingWholeHalf { get; set; }

        public int OrderSelected { get; set; }

        public bool IsFree { get; set; }
    }
}
