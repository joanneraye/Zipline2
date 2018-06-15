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

        private ToppingModifierType toppingModifier;
        public ToppingModifierType ToppingModifier
        {
            get
            {
                return toppingModifier;
            }
            set
            {
                toppingModifier = value;
                if (toppingModifier == ToppingModifierType.None)
                {
                    ToppingDisplayName = DisplayNames.GetToppingDisplayName(ToppingName);
                }
                else
                {
                    if (toppingModifier == ToppingModifierType.ExtraTopping)
                    {
                        ToppingDisplayName = "Extra " + DisplayNames.GetToppingDisplayName(ToppingName);
                    }
                    else if (toppingModifier == ToppingModifierType.LightTopping)
                    {
                        ToppingDisplayName = "Light " + DisplayNames.GetToppingDisplayName(ToppingName);
                    }
                    else if (toppingModifier == ToppingModifierType.ToppingOnSide)
                    {
                        ToppingDisplayName = DisplayNames.GetToppingDisplayName(ToppingName) + " On Side";
                    }
                    else if (toppingModifier == ToppingModifierType.NoTopping)
                    {
                        ToppingDisplayName = "No " + DisplayNames.GetToppingDisplayName(ToppingName);
                        SpecialPricingType = SpecialPricingType.SubtractTopping;
                    }
                }
                
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
            toppingModifier = ToppingModifierType.None;
            ToppingWholeHalf = toppingWholeHalf;
            Count = 1;
            if (toppingWholeHalf != ToppingWholeHalf.Whole)
            {
                ChangeToppingDisplayNameHalf(toppingWholeHalf);
            }
            DbItemId = Toppings.GetDbItemId(toppingName);
            SpecialPricingType = SpecialPricingType.DefaultOneTopping;
        }

        public Topping GetClone()
        {
            return (Topping)MemberwiseClone();
        }

        

        public void ChangeToppingDisplayNameHalf(ToppingWholeHalf whichHalf)
        {
            if (whichHalf == ToppingWholeHalf.HalfA)
            {
                ToppingDisplayName = "Half A - " + ToppingDisplayName;
            }
            else if (whichHalf == ToppingWholeHalf.HalfB)
            {
                ToppingDisplayName = "Half B - " + ToppingDisplayName;
            }
        }
        #endregion
    }
}
