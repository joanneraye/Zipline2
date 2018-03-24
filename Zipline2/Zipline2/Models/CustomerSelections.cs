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
        public MenuCategory MenuItemGeneralCategory { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public PizzaCrust PizzaCrustType { get; set; }

        private PizzaType pizzaType;
        public PizzaType PizzaType
        {
            get
            {
                return pizzaType;
            }
        }

        public MajorOrMama MajorOrMama { get; set; }

        public int NumberOfItems { get; set; }

        public CustomerSelections(PizzaType pizzatype)
        {
            pizzaType = pizzatype;
        }
    }
}
