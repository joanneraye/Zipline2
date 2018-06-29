using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zipline2.ConnectedServices
{
    public interface IWaiterClient
    {
        IPosService GetWaiterClient(string endpointAddress);
    }
}