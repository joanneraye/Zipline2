using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Wine : Drink
    {
        public Wine(CustomerSelection guiData) : base(guiData)
        {
        }

        public enum DrinkSize
        {
            Glass,
            Bottle
        }
        public DrinkSize Size { get; set; }

        public bool IsHouseWine { get; set; }
    }
}
