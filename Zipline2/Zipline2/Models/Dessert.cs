using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class Dessert : OrderItem
    {
        DessertType DessertType; 
        public Dessert(CustomerSelection guiData)
        {
            
        }

        public override void PopulateDisplayName()
        {
           //ItemName = DisplayNames.Get????PopulateDisplayName...
        }

        public override void PopulatePricePerItem()
        {
            //BasePrice = Prices.GetDessertPrice(DessertType);
        }
    }
}
