using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.MyEventArgs
{
    public class DrinksPageEventArgs : EventArgs
    {
        public int DrinkIndexForEdit { get; private set; }

        public DrinksPageEventArgs(int indexForEdit)
        {
            DrinkIndexForEdit = indexForEdit;
        }

    }
}
