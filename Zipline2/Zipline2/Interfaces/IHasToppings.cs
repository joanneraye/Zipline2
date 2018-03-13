using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.Interfaces
{
    interface IHasToppings
    {
        void AddToppings(CustomerSelections guiData);
    }
}
