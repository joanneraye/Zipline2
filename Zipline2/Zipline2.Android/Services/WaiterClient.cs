using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Zipline2.ConnectedServices;
using Zipline2.ConnectedServices.PosServiceReference;

namespace Zipline2.Android.Services
{
    public class WaiterClient : IWaiterClient
    {
        public IPosService GetWaiterClient(string endpointAddress)
        {
            PosServiceClientAndroid waiterClient = new PosServiceClientAndroid(
                         new BasicHttpBinding(),
                         new EndpointAddress(endpointAddress));
            waiterClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 15);
            return waiterClient;
        }
    }
}