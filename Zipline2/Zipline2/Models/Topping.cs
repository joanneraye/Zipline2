using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    public class Topping : BasePageModel
    {
        #region Properties
        public decimal DbItemId { get; set; } 

        //Foreign key with OrderItem table - can include toppings for salad or pizza
        public int OrderItemId { get; set; }

        private ToppingName toppingName;
        public ToppingName ToppingName
        {
            get
            {
                return toppingName;
            }
            set
            {
                SetProperty(ref toppingName, value);
                ToppingDisplayName = DisplayNames.GetToppingDisplayName(toppingName);
            }
        }

        private string toppingDisplayName;
        public string ToppingDisplayName
        {
            get
            {
                return toppingDisplayName;
            }
            set
            {
                SetProperty(ref toppingDisplayName, value);
            }
        }
        
        public ToppingWholeHalf ToppingWholeHalf { get; set; }

        public int Count { get; set; }

        public int SequenceSelected { get; set; }

        public SpecialPricingType SpecialPricingType { get; set; }

        public decimal SpecialPriceChange { get; set; }

       
        #endregion

        #region Constructor
        public Topping(ToppingName toppingName, ToppingWholeHalf toppingWholeHalf = ToppingWholeHalf.Whole)
        {
            ToppingName = toppingName;
            DbItemId = Toppings.GetDbItemId(toppingName);
            ToppingWholeHalf = toppingWholeHalf;
        }
        #endregion
    }
}
