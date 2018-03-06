using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.Interfaces
{
    //Can only be used by a Pizza object.  
    public interface ISpecialtyBase
    {
        decimal GetSpecialtyPrice(OrderItem item);
    }
}
