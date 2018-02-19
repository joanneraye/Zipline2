using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Interfaces
{
    public interface IOrderItem
    {
        void CreateNewOrderItem(IOrderItem orderItem);
    }
}
