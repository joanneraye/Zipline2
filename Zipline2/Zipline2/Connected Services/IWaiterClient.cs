using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zipline2.ConnectedServices.PosServiceReference;

namespace Zipline2.ConnectedServices
{
    public interface IWaiterClient
    {
        IPosService GetWaiterClient(string endpointAddress);
    }
}