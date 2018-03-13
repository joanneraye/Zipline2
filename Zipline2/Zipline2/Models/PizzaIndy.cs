using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    public class PizzaIndy : Pizza, IOrderItem, IHasToppings
    {
        public PizzaIndy(CustomerSelections guiData) : base(guiData)
        {
            MajorMamaInfo = guiData.MajorOrMama;
        }
        
        public void AddToppings(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetPizzaDisplayName(PizzaType.Indy);
            
        }

        public void PopulatePricePerItem()
        {
            PricePerItem = Prices.GetPizzaBasePrice(PizzaType.Indy);
        }
    }
}
