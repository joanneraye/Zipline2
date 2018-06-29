using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using Foundation;
using UIKit;
using Zipline2.ConnectedServices;

namespace Zipline2.iOS.Services
{
    public class WaiterClient : IWaiterClient
    {
        public IPosService GetWaiterClient(string endpointAddress)
        {
            PosServiceClientIos WaiterClient = new PosServiceClientIos(
               new BasicHttpBinding(),
               new EndpointAddress(endpointAddress));
            WaiterClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 30, 0);
            return WaiterClient;
        }
    }
}