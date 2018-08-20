using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Interfaces;


namespace Zipline2.Models
{
    public class PizzaCalzone : Pizza, IHasToppings, IOrderItem
    {
        public PizzaCalzone(CustomerSelections guiData) : base(guiData)
        {
            
        }

        //May be overridden by PizzaCalzoneSteakAndCheese
        public virtual void AddToppings(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetPizzaDisplayName(PizzaType.Calzone);
        }

        public void PopulatePricePerItem()
        {
            PricePerItem = Prices.BasePriceDictionary[PizzaType.Calzone];
        }
    }
}
