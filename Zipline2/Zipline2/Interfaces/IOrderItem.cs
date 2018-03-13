using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Interfaces
{
    interface IOrderItem
    {
        void PopulateDisplayName();
        void PopulatePricePerItem();
        void CalculateItemTotal();
    }
}
