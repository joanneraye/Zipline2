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
using Zipline2.ConnectedServices.CheckHostReference;

namespace Zipline2.Android.Services
{
    public class CheckClient : ICheckClient
    {
        public ICheckHost GetCheckClient(string endpointAddress)
        {
            CheckHostClientAndroid checkClient = new CheckHostClientAndroid(
                         new BasicHttpBinding(),
                         new EndpointAddress(endpointAddress));
            checkClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);
            return checkClient;
        }
    }
}