using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class BeerOnTap : Drink
    {
        //
        public BeerOnTap(CustomerSelection guiData) : base(guiData)
        {
        }

        public enum BeerSize
        {
            Pint,
            Pitcher
        }
        public BeerSize Size { get; set; }
    }
}
