using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    //This class contains the data neeeded to create an OrderItem from
    //information selected by the Gui.  It provides a separation between 
    //the GUI layer and the business layer.
    public class CustomerSelections
    {
        public MenuCategory MenuItemGeneralCategory { get; set; }

        public PizzaSize PizzaSize { get; set; }

        public PizzaType PizzaType { get; set; }

        public MajorOrMama MajorOrMama { get; set; }

        public int NumberOfItems { get; set; }




    }
}
