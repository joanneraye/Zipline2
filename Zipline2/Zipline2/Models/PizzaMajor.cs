using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    public class PizzaMajor : Pizza, IOrderItem, IHasToppings
    {
        public PizzaMajor(CustomerSelections guiData) : base(guiData)
        {
            Toppings.CurrentToppings.Add(new Topping(ToppingName.Pepperoni));
            Toppings.CurrentToppings.Add(new Topping(ToppingName.Mushrooms));
            Toppings.CurrentToppings.Add(new Topping(ToppingName.Sausage));
            Toppings.CurrentToppings.Add(new Topping(ToppingName.GreenPeppers));
            Toppings.CurrentToppings.Add(new Topping(ToppingName.Onion)); ;
            Toppings.CurrentToppings.Add(new Topping(ToppingName.BlackOlives));
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
