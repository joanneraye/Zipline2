using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public abstract class PizzaThin : Pizza
    {
        public PizzaThin(CustomerSelections guiData) : base(guiData)
        {

        }
    }
}
