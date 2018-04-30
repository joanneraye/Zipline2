using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class Drink : OrderItem
    {
        public DrinkCategory DrinkCategory { get; set; }
        public DrinkType DrinkType { get; set; }
        public bool IsDrinkFree { get; set; }
        public Drink()
        {
            PopulatePricePerItem();
        }
        public Drink(CustomerSelection guiData) : this()
        {
            if (guiData is DrinkSelection)
            {
                DrinkSelection drinkSelection = guiData as DrinkSelection;
                drinkSelection.Drink.PopulateDisplayName();
                drinkSelection.Drink.PopulatePricePerItem();
            }
        }

        public override void PopulateDisplayName()
        {
        }

        public override void PopulatePricePerItem()
        {
            if (!IsDrinkFree)
            {
                PricePerItem = 3.00M;
            }
        }
    }
}
