using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Zipline2.ConnectedServices;

namespace Zipline2.ConnectedServices.CheckHostReference
{
    public class CheckHostClientNew
    {
        public class PosServiceClientNew
        {
            public PosServiceClientNew()
            {
                ChannelFactory<IPosService> channelFactory = new ChannelFactory<IPosService>("Endpoint_ICheckHost");
                IPosService channel = channelFactory.CreateChannel();
                channel.GetMenu();
            }
           
        }
    }
}
