using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Merchandise : OrderItem
    {
        public Merchandise(CustomerSelections guiData)
        {

        }

        public override void PopulateDisplayName()
        {
            throw new NotImplementedException();
        }

        public override void PopulatePricePerItem()
        {
            throw new NotImplementedException();
        }
    }
}
