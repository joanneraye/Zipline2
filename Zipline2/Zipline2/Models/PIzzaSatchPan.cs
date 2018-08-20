using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    public class PizzaSatchPan : Pizza, IOrderItem, IHasToppings
    {
        public PizzaSatchPan(CustomerSelections guiData) : base(guiData)
        {

        }

        public void AddToppings(CustomerSelections guiData)
        {
            throw new NotImplementedException();
        }

        public void PopulateDisplayName()
        {
            throw new NotImplementedException();
        }

        public void PopulatePricePerItem()
        {
            throw new NotImplementedException();
        }
    }
}
