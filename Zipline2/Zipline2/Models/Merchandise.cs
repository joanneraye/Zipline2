using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Merchandise : OrderItem
    {
        public Merchandise(CustomerSelection guiData)
        {

        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            throw new NotImplementedException();
        }

        public override void PopulateDisplayName()
        {
            throw new NotImplementedException();
        }

      

        public override void PopulatePricePerItem()
        {
            throw new NotImplementedException();
        }

        public override List<GuestModifier> CreateMods()
        {
            return new List<GuestModifier>();
        }

        public override void PopulateBasePrice()
        {
            throw new NotImplementedException();
        }
    }
}
