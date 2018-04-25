using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class SoftDrink : Drink
    {
        public SoftDrinkType SoftDrinkType;

        public SoftDrink()
        {

        }
        public SoftDrink(CustomerSelection guiData) 
        { 
            if (guiData is DrinkSelection)
            {
                var thisDrink = (guiData as DrinkSelection).Drink;
                if (thisDrink is SoftDrink)
                {
                    SoftDrinkType = (thisDrink as SoftDrink).SoftDrinkType;
                }
            }
        }

        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetSoftDrinkDisplayName(SoftDrinkType);
        }       
    }
}
