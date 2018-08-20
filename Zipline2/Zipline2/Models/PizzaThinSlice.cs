using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    public class PizzaThinSlice : PizzaThin, IOrderItem, IHasToppings
    {
        public PizzaThinSlice(CustomerSelections guiData) : base(guiData)
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
