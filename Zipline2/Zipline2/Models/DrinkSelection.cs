using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class DrinkSelection : CustomerSelection
    {
        public DrinkType DrinkType { get; set; }

        public DrinkName DrinkName { get; set; }

    }
}
