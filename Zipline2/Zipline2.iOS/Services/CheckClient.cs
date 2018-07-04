using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceModel;
using System.Text;

using Foundation;
using UIKit;
using Zipline2.ConnectedServices;
using Zipline2.ConnectedServices.CheckHostReference;

namespace Zipline2.iOS.Services
{
    public class CheckClient : ICheckClient
    {
        public ICheckHost GetCheckClient(string endpointAddress)
        {
            CheckHostClient checkClient = new CheckHostClient(
                            new BasicHttpBinding(),
                            new EndpointAddress(endpointAddress));
            checkClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);
            return checkClient;
        }
    }
}