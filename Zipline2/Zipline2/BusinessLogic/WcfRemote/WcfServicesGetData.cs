using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.BusinessLogic.WcfRemote
{
    class WcfServicesGetData
    {

        #region Singleton
        private static WcfServicesGetData instance = null;
        private static readonly object padlock = new object();

        public static WcfServicesGetData Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WcfServicesGetData();
                    }
                    return instance;
                }
            }
        }


        #endregion

        private WcfServicesProxy.ServiceCallConfigType ServiceCallConfig;

        private WcfServicesGetData(WcfServicesProxy.ServiceCallConfigType serviceCallConfig)
        {
            ServiceCallConfig = serviceCallConfig;
        }

        public List<DBModGroup> GetPizzaToppings()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBModGroup>();
            }

            return WaiterClient.GetAllMods(57M, 0M);

        }
    }
}
