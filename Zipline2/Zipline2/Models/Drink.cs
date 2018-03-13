using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Drink : OrderItem
    {
        public Drink(CustomerSelections guiData)
        {

        }

        public override void PopulateDisplayName(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public override void PopulatePricePerItem(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

    }
}
