using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class Topping
    {
        #region Properties
        public int ToppingId { get; set; }

        //Foreign key with OrderItem table - can include toppings for salad or pizza
        public int OrderItemId { get; set; }
        
        public ToppingName ToppingName { get; set; }

        public string ToppingDisplayName { get; set; }
        
        public ToppingWholeHalf ToppingWholeHalf { get; set; }

        public int SequenceSelected { get; set; }

        public SpecialPricingType SpecialPricingType { get; set; }

        public decimal SpecialPriceChange { get; set; }
        #endregion

        #region Constructor
        public Topping(ToppingName toppingName)
        {
            ToppingName = toppingName;
            ToppingDisplayName = DisplayNames.GetToppingDisplayName(toppingName);
        }
        #endregion
    }
}
