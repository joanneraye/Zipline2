using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    class PizzaCalzoneSteakAndCheese : PizzaCalzone
    {
        public PizzaCalzoneSteakAndCheese(CustomerSelections guiData) : base(guiData)
        {
            

        }
        public override void AddToppings(CustomerSelections guiData)
        {
            //Add steak and cheese toppings...
            throw new NotImplementedException();
        }
    }
}
