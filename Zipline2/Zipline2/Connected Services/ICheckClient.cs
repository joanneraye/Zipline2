using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.ConnectedServices.CheckHostReference;

namespace Zipline2.ConnectedServices
{
    public interface ICheckClient
    {
        ICheckHost GetCheckClient(string endpointAddress, TimeSpan timeoutTimeSpan);
    }
}
