using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    //This class contains the data neeeded to create an OrderItem from
    //information selected by the Gui.  It provides a separation between 
    //the GUI layer and the business layer.  (The GUI only has to populate
    //an object of this class in order to communicate with the business logic.
    public class CustomerSelections
    {
        //TODO:  Make a more generic CustomerSelections class and then
        //      this will be a derived class for Pizza Gui Data.
        public MenuCategory MenuItemGeneralCategory { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public PizzaCrust PizzaCrustType { get; set; }

        public PizzaType PizzaType { get; private set; }

        public MajorOrMama MajorOrMama { get; set; }

        public int NumberOfItems { get; set; }

        public CustomerSelections(PizzaType pizzatype)
        {
            PizzaType = pizzatype;
        }
    }
}
