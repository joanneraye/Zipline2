﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using Zipline2.ConnectedServices;
using Zipline2.Models;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.ConnectedServices.PosServiceReference;
using Zipline2.ConnectedServices.CheckHostReference;
using Zipline2.Data;

namespace Zipline2.BusinessLogic.WcfRemote
{
    
    public class WcfServicesProxy : IGetWcfData, IUpdateWcfData
    {
        public enum ServiceCallConfigType
        {
            AllServiceCallsOn,
            AllServiceCallsOff,
            UpdateServicesNoSend

        }

        public bool ServerConnectionProblem = false;
        public ServiceCallConfigType ServiceCallConfig;
        private string endpointIpAddressPart1;
        private const string waiterIpAddressPart2 = "/WP7Waiter/POServiceHost.svc";
        private const string checkIpAddressPart2 = "/CheckHost/CheckHost.svc";


        #region Singleton
        private static WcfServicesProxy instance = null;
        private static readonly object padlock = new object();
      
        public static WcfServicesProxy Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new WcfServicesProxy();
                    }
                    return instance;
                }
            }
        }


        #endregion

        //The current Windows Phone app has a Service Reference folder with references
        //to the services.  When the services are added, the classes with references
        //are autogenerated. Then the phone app just has the following:

        private IPosService waiterClient;
        public IPosService WaiterClient
        {
            get
            {
                if (waiterClient == null)
                {
                    CreateWaiterClient();
                }
                return waiterClient;
            }
        }

        private ICheckHost checkClient;
        public ICheckHost CheckClient
        {
            get
            {
                if (checkClient == null)
                {
                    CreateCheckClient();
                }
                return checkClient;
            }
        }

        

        //public Dictionary<decimal, DBItem> MenuItemsPizza { get; private set; }
        //public Dictionary<decimal, DBItem> MenuItemsCalzone { get; private set; }
        //public Dictionary<decimal, DBItem> MenuItemsSalads { get; private set; }
        //public Dictionary<decimal, DBItem> MenuItemsBeverages { get; private set; }
        //public Dictionary<decimal, DBItem> MenuItemsDessert { get; private set; }
        private decimal UserIdDecimal;

        private WcfServicesProxy()
        {
            ServiceCallConfig = ServiceCallConfigType.UpdateServicesNoSend;

            endpointIpAddressPart1 = "http://192.168.1.26";      //Dev environment

             //endpointIpAddressPart1 = "http://192.168.1.21";   //Live server
            // endpointIpAddressPart1 = "http://192.168.1.122";   //Backup server
            //endpointIpAddressPart1 = "http://192.168.1";      //BAD

            if (Users.Instance.LoggedInUser != null)
            {
                UserIdDecimal = Users.Instance.LoggedInUser.UserId;
            }

            if (ServiceCallConfig != ServiceCallConfigType.AllServiceCallsOff)
            {
                try
                {
                    CreateWaiterClient();
                    CreateCheckClient();
                }

                catch (Exception ex)
                {
                    ServiceCallConfig = ServiceCallConfigType.AllServiceCallsOff;
                    ServerConnectionProblem = true;
                }
            }
        }

       
        private void CreateWaiterClient()
        {
          
            waiterClient = DependencyService.Get<IWaiterClient>().GetWaiterClient(endpointIpAddressPart1 + waiterIpAddressPart2, new TimeSpan(0, 0, 10));

            int pingResult = 0;
            try
            {
                pingResult = waiterClient.Ping(0);
            }

            catch (Exception ex)
            {
                ServiceCallConfig = ServiceCallConfigType.AllServiceCallsOff;
                ServerConnectionProblem = true;

            }
            
            if (pingResult == 10)
            {
                waiterClient = DependencyService.Get<IWaiterClient>().GetWaiterClient(endpointIpAddressPart1 + waiterIpAddressPart2, new TimeSpan(0, 10, 0));
            }
           
            //waiterClient = new PosServiceClient(
            //             new BasicHttpBinding(),
            //             new EndpointAddress(endpointIpAddressPart1 + waiterIpAddressPart2));
            //waiterClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);

        }

        private void CreateCheckClient()
        {
           
            checkClient = DependencyService.Get<ICheckClient>().GetCheckClient(endpointIpAddressPart1 + checkIpAddressPart2, new TimeSpan(0, 10, 0));

            //The following won't work and don't know why.
            //if (checkClient.Ping() == 9001)
            //{
            //    CheckClientConnected = true;
            //}
            //checkClient = new CheckHostClient(
            //            new BasicHttpBinding(),
            //            new EndpointAddress(endpointIpAddressPart1 + checkIpAddressPart2));
            //checkClient.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0);
        }

        #region Regular methods (synchronous)

        //GET METHODS
        public List<DBModGroup> GetPizzaToppings()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBModGroup>();
            }

            return WaiterClient.GetAllMods(57M, 0M);

        }

        public List<DBModGroup> GetSaladToppings()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBModGroup>();
            }

            return WaiterClient.GetAllMods(50M, 0M);

        }

        public void UpdateTable(DBTable currentTable)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            List<DBTable> tablesToUpdate = new List<DBTable> { currentTable };
            waiterClient.UpdateTables(tablesToUpdate, (decimal)Users.Instance.LoggedInUser.UserId);
        }

        public DBTable GetTable(int tableNum)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBTable();
            }
            try
            {
                return waiterClient.GetTable(tableNum);
            }
            catch (Exception e)
            {
                waiterClient.GetTablesForSection(1);
                Exception error = e;
                throw;
            }
        }

        public void GetTables()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return;
            }
            DataBaseDictionaries.DbTablesDictionary = new Dictionary<decimal, DBTable>();
            List<DBTable> tablesSection1 = waiterClient.GetTablesForSection(1M);
            foreach (var item1 in tablesSection1)
            {
                DataBaseDictionaries.DbTablesDictionary.Add(item1.ID, item1);
            }
            List<DBTable> tablesSection2 = waiterClient.GetTablesForSection(2M);
            foreach (var item2 in tablesSection2)
            {
                DataBaseDictionaries.DbTablesDictionary.Add(item2.ID, item2);
            }
        }


        public void GetMenu()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return;
            }
            try
            {
                DataBaseDictionaries.MenuDictionary = waiterClient.GetMenu();
              
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public decimal GetNextGuestId()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return 0;
            }
            List<decimal> ids = waiterClient.GetNextGuestIDs(1, UserIdDecimal);
            if (ids.Count > 0)
            {
                return ids[0];
            }
            return 0;
        }

        public async void UpdateOrder(Order orderToUpdate)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            DBTable dbTableCurrent = await ConvertOrderToDbTableAsync(orderToUpdate, false);

            //Update the database table with built DBTable in order to obtain new OrderID.
            //await UpdateTableAsync(dbTableCurrent);
            UpdateTable(dbTableCurrent);
        }

        //Since called from method already awaited, so this sync method is called since need to wait on result.

        public List<decimal> GetGuestIds(decimal tableId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<decimal>() { 0 };
            }
            DBTable thisTable = GetTable((int)tableId);
            List<decimal> guestIds = new List<decimal>();
            if (thisTable.Guests.Count > 1)
            {
                guestIds.Add(thisTable.Guests[0].ID);
                guestIds.Add(thisTable.Guests[1].ID);
            }
            else
            {
                guestIds = waiterClient.GetNextGuestIDs((2), UserIdDecimal);
            }
            return guestIds;
        }


        public List<DBTable> GetTableInfo()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBTable>();
            }
            //Don't call async method because need to wait in order to display correct table info.
            return waiterClient.GetTableSummary();
        }

        //public Task PrepareAndSendOrder(Order orderToSend)
        //{
        //    if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
        //        ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
        //    {
        //        return;
        //    }
        //    DBTable dbTableCurrent = ConvertOrderToDbTable(orderToSend, true);

        //    //Update the database table with built DBTable in order to obtain new OrderID.
        //    //await UpdateTableAsync(dbTableCurrent);
        //    UpdateTable(dbTableCurrent);

        //    //Get the table just updated - will contain new OrderID.
        //    DBTable updatedTable = GetTable((int)dbTableCurrent.ID);

        //    //See if outstanding checks for this table.
        //    //Cannot call a synchronous method in Zipline2.
        //    List<DBCheck> checks = GetOpenChecks(dbTableCurrent.ID);
        //    decimal checkId = -1;
        //    if (checks.Count > 0)
        //    {
        //        checkId = checks[0].ID;
        //    }

        //    DBCheck newDbCheck = new DBCheck(checkId);


        //    List<decimal> orderIDs = new List<decimal>();

        //    //Get items for check from updated Table just retrieved.
        //    foreach (GuestItem item in updatedTable.Guests[0].Items)
        //    {
        //        if (!item.OrderSent)
        //        {
        //            orderIDs.Add(item.OrderID);
        //            newDbCheck.Items.Add(item);
        //        }
        //    }
        //    foreach (GuestComboItem combo in updatedTable.Guests[0].ComboItems)
        //    {
        //        bool first = true;
        //        foreach (GuestItem gItem in combo.ComboGuestItems)
        //        {
        //            if (!gItem.OrderSent)
        //            {
        //                orderIDs.Add(gItem.OrderID);
        //                if (first)
        //                {
        //                    first = false;
        //                    newDbCheck.ComboItems.Add(combo);
        //                }
        //            }
        //        }
        //    }

        //    //Create and add check to database.
        //    CreateCheck(newDbCheck);
        //    SendOrders(orderIDs, UserIdDecimal);
        //}

        public DBUser GetUser(string pin)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBUser();
            }
            DBUser thisUser = waiterClient.GetUser(pin);
            return thisUser;
        }

        public void SendOrders(List<decimal> orderIds, decimal userId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            waiterClient.SendOrders(orderIds, userId);
        }

        //public List<DBCheck> GetOpenChecks(decimal tableId)
        //{
        //    if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
        //    {
        //        return new List<DBCheck>();
        //    }
        //    //return checkClient.GetOpenChecks(tableId);
        //}

        public void CreateCheck(DBCheck dbCheck)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            var dbChecks = new List<DBCheck>()
            {
                dbCheck
            };
            try
            {
                checkClient.CreateChecks(dbChecks, UserIdDecimal, false);
            }
            catch (Exception ex)
            {
                var errormessage = ex;
                throw;
            }
        }

        //CONVERSION METHODS

        internal DBTable ConvertOrderToDbTable(Order orderToSend, bool sendOrderToKitchen = false)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBTable();
            }
            List<decimal> guestIds = GetGuestIds(orderToSend.TableId);
            //List<decimal> guestIds = await GetGuestIdsAsync(orderToSend.TableId);

            //Get stored DBTable.
            DBTable newTable = DataBaseDictionaries.DbTablesDictionary[orderToSend.TableId];
            if (newTable.Guests.Count == 0)
            {
                bool first = true;
                foreach (decimal id in guestIds)
                {
                    Staunch.POS.Classes.Guest_DB guest = new Staunch.POS.Classes.Guest_DB();
                    guest.ID = id;
                    guest.CheckedOut = false;
                    guest.Items = new List<GuestItem>();
                    guest.ComboItems = new List<GuestComboItem>();
                    guest.TableID = orderToSend.TableId;

                    if (first)
                    {
                        guest.IsWhole = true;
                        first = false;
                    }

                    newTable.Guests.Add(guest);
                }
            }

            if (DataBaseDictionaries.MenuDictionary != null &&
                DataBaseDictionaries.MenuDictionary.Count > 0)
            {
                //Create DBItems for Guest_DB object.
                foreach (var orderItem in orderToSend.OrderItems)
                {
                    var keysTuple = orderItem.GetMenuDbItemKeys();
                    var dbItem = new DBItem();
                    bool menuItemFound = false;

                    //Use the item from the Database Dictionary.                    
                    foreach (var menuItem in DataBaseDictionaries.MenuDictionary[keysTuple.Item1])
                    {
                        if (menuItem.ID == keysTuple.Item2)
                        {
                            dbItem = menuItem;
                            menuItemFound = true;
                            break;
                        }
                    }
                    if (orderItem.DbOrderId <= 0)
                    {
                        orderItem.DbOrderId = -1;
                    }
                    if (menuItemFound)
                    {
                        GuestItem guestItem = orderItem.CreateGuestItem(dbItem, orderItem.DbOrderId);
                        guestItem.Mods = orderItem.CreateMods();
                        guestItem.OrderSent = sendOrderToKitchen;
                        newTable.Guests[0].Items.Add(guestItem);
                        //Pricing check - TODO:  Take out for production??
                        //Had to comment out in testing because wouldn't process - says mismatch with service but can't find problem.
                        //GuestItem databaseGuestItem = checkClient.PriceOrder(guestItem);
                        //if (databaseGuestItem.Price != guestItem.Price)
                        //{
                        //    Console.WriteLine("JOANNE LOG:  price differs for " + guestItem.ShortName);
                        //}
                    }
                }
            }
            return newTable;
        }

        #endregion


        #region Async Methods
        internal async Task<DBTable> ConvertOrderToDbTableAsync(Order orderToSend, bool sendOrderToKitchen = false)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBTable();
            }
            List<decimal> guestIds = await GetGuestIdsAsync(orderToSend.TableId);

            //Get stored DBTable.
            DBTable newTable = DataBaseDictionaries.DbTablesDictionary[orderToSend.TableId];
            if (newTable.Guests.Count == 0)
            {
                bool first = true;
                foreach (decimal id in guestIds)
                {
                    Staunch.POS.Classes.Guest_DB guest = new Staunch.POS.Classes.Guest_DB();
                    guest.ID = id;
                    guest.CheckedOut = false;
                    guest.Items = new List<GuestItem>();
                    guest.ComboItems = new List<GuestComboItem>();
                    guest.TableID = orderToSend.TableId;

                    if (first)
                    {
                        guest.IsWhole = true;
                        first = false;
                    }

                    newTable.Guests.Add(guest);
                }
            }

            if (DataBaseDictionaries.MenuDictionary != null &&
                DataBaseDictionaries.MenuDictionary.Count > 0)
            {
                //Create DBItems for Guest_DB object.
                foreach (var orderItem in orderToSend.OrderItems)
                {
                    var keysTuple = orderItem.GetMenuDbItemKeys();
                    var dbItem = new DBItem();
                    bool menuItemFound = false;

                    //Use the item from the Database Dictionary.                    
                    foreach (var menuItem in DataBaseDictionaries.MenuDictionary[keysTuple.Item1])
                    {
                        if (menuItem.ID == keysTuple.Item2)
                        {
                            dbItem = menuItem;
                            menuItemFound = true;
                            break;
                        }
                    }
                    if (orderItem.DbOrderId <= 0)
                    {
                        orderItem.DbOrderId = -1;
                    }
                    if (menuItemFound)
                    {
                        GuestItem guestItem = orderItem.CreateGuestItem(dbItem, orderItem.DbOrderId);
                        guestItem.Mods = orderItem.CreateMods();
                        guestItem.OrderSent = sendOrderToKitchen;
                        newTable.Guests[0].Items.Add(guestItem);
                        //Pricing check - TODO:  Take out for production??
                        //Had to comment out in testing because wouldn't process - says mismatch with service but can't find problem.
                        //GuestItem databaseGuestItem = checkClient.PriceOrder(guestItem);
                        //if (databaseGuestItem.Price != guestItem.Price)
                        //{
                        //    Console.WriteLine("JOANNE LOG:  price differs for " + guestItem.ShortName);
                        //}
                    }
                }
            }
            return newTable;
        }

        async public Task<List<DBModGroup>> GetSaladToppingsAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBModGroup>();
            }
           
            return await Task.Factory.FromAsync(
               WaiterClient.BeginGetAllMods,
               WaiterClient.EndGetAllMods,
               50M, 0M,
               TaskCreationOptions.None);

        }


        async public Task<DBUser> GetUserAsync(string pin)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBUser();
            }
           
            return await Task.Factory.FromAsync(
              WaiterClient.BeginGetUser,
              WaiterClient.EndGetUser,
              pin,
              TaskCreationOptions.None);
        }


        async public Task UpdateOrderAsync(Order orderToUpdate)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return;
            }

            if (ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                if (DataBaseDictionaries.DbTablesDictionary.ContainsKey(orderToUpdate.TableId))
                {
                    var thisTable = DataBaseDictionaries.DbTablesDictionary[orderToUpdate.TableId];
                    Tables.AllTables[orderToUpdate.TableIndexInAllTables].OpenOrder = orderToUpdate;
                }
            }
            //decimal guestId = await GetGuestIdAsync(orderToUpdate.TableId);
            DBTable dbTableCurrent = await ConvertOrderToDbTableAsync(orderToUpdate, false);

            //Update the database table with built DBTable in order to obtain new OrderID.
            await UpdateTableAsync(dbTableCurrent);
        }

        async public Task PrepareAndSendOrderAsync(Order orderToSend)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            { 
                if (Tables.AllTables.Count > orderToSend.TableIndexInAllTables)
                {
                    Tables.AllTables[orderToSend.TableIndexInAllTables].OpenOrder = orderToSend;
                }
                return;
            }
            DBTable dbTableCurrent = await ConvertOrderToDbTableAsync(orderToSend, true);

            //Update the database table with built DBTable in order to obtain new OrderID.
            //await UpdateTableAsync(dbTableCurrent);
            await UpdateTableAsync(dbTableCurrent);

            //Get the table just updated - will contain new OrderID.
            DBTable updatedTable = await GetTableAsync((int)dbTableCurrent.ID);

            //See if outstanding checks for this table.
            List<DBCheck> checks = await GetOpenChecksAsync(dbTableCurrent.ID);
            decimal checkId = -1;
            if (checks.Count > 0)
            {
                checkId = checks[0].ID;
            }

            DBCheck newDbCheck = new DBCheck(checkId);

            List<decimal> orderIDs = new List<decimal>();

            //Get items for check from updated Table just retrieved.
            foreach (GuestItem item in updatedTable.Guests[0].Items)
            {
                if (!item.OrderSent)
                {
                    orderIDs.Add(item.OrderID);
                    newDbCheck.Items.Add(item);
                }
            }
            foreach (GuestComboItem combo in updatedTable.Guests[0].ComboItems)
            {
                bool first = true;
                foreach (GuestItem gItem in combo.ComboGuestItems)
                {
                    if (!gItem.OrderSent)
                    {
                        orderIDs.Add(gItem.OrderID);
                        if (first)
                        {
                            first = false;
                            newDbCheck.ComboItems.Add(combo);
                        }
                    }
                }
            }          
        }
        
        async public Task UpdateTableAsync(DBTable currentTable)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            List<DBTable> tablesToUpdate = new List<DBTable> { currentTable };
            await Task.Factory.FromAsync(
                WaiterClient.BeginUpdateTables,
                WaiterClient.EndUpdateTables,
                tablesToUpdate,
                (decimal)Users.Instance.LoggedInUser.UserId,
                TaskCreationOptions.None);
        }

        async public Task GetTablesAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return;
            }
            DataBaseDictionaries.DbTablesDictionary = new Dictionary<decimal, DBTable>();
            List<DBTable> tablesSection1 = await Task.Factory.FromAsync(
                   WaiterClient.BeginGetTablesForSection,
                   WaiterClient.EndGetTablesForSection,
                   1M,
                   TaskCreationOptions.None);

          
            foreach (var item1 in tablesSection1)
            {
                DataBaseDictionaries.DbTablesDictionary.Add(item1.ID, item1);
            }
            List<DBTable> tablesSection2 = await Task.Factory.FromAsync(
                    WaiterClient.BeginGetTablesForSection,
                    WaiterClient.EndGetTablesForSection,
                    2M,
                    TaskCreationOptions.None);

            foreach (var item2 in tablesSection2)
            {
                DataBaseDictionaries.DbTablesDictionary.Add(item2.ID, item2);
            }
        }

        async public Task<DBTable> GetTableAsync(int tableNum)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new DBTable();
            }
            return await Task.Factory.FromAsync(
                    WaiterClient.BeginGetTable,
                    WaiterClient.EndGetTable,
                    tableNum,
                    TaskCreationOptions.None);
        }

        async public Task<List<DBModGroup>> GetPizzaToppingsAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBModGroup>();
            }
           
            return await Task.Factory.FromAsync(
                WaiterClient.BeginGetAllMods,
                WaiterClient.EndGetAllMods,
                (decimal)57,
                (decimal)0,
                TaskCreationOptions.None);

        }

        

        async public Task GetMenuAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return;
            }                       
            DataBaseDictionaries.MenuDictionary = new Dictionary<string, List<DBItem>>();
            try                           
            {
                DataBaseDictionaries.MenuDictionary = await Task.Factory.FromAsync(
                    WaiterClient.BeginGetMenu,
                    WaiterClient.EndGetMenu,
                    null,
                    TaskCreationOptions.None);
            }
            catch (Exception ex)
            {
                var errormessage = ex;
                throw;
            }
        }

        async public Task<decimal> GetNextGuestIdAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return 0;
            }
            List<decimal> ids = await Task.Factory.FromAsync(
                WaiterClient.BeginGetNextGuestIDs,
                WaiterClient.EndGetNextGuestIDs,
                1,
                UserIdDecimal,
                TaskCreationOptions.None);
            if (ids.Count > 0)
            {
                return ids[0];
            }
            return 0;
        }

        async public void SendOrdersAsync(List<decimal> orderIds, decimal userId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            await Task.Factory.FromAsync(
                WaiterClient.BeginSendOrders,
                WaiterClient.EndSendOrders,
                orderIds,
                userId,
                TaskCreationOptions.None);
        }

        async public Task<List<decimal>> GetGuestIdsAsync(decimal tableId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<decimal>() { 0 };
            }
            DBTable thisTable = await GetTableAsync((int)tableId);
            List<decimal> guestIds = new List<decimal>();
            if (thisTable.Guests.Count > 1)
            {
                guestIds.Add(thisTable.Guests[0].ID);
                guestIds.Add(thisTable.Guests[1].ID);
            }
            else
            {
                guestIds = waiterClient.GetNextGuestIDs((2), UserIdDecimal);
                await Task.Factory.FromAsync(
                    WaiterClient.BeginGetNextGuestIDs,
                    WaiterClient.EndGetNextGuestIDs,
                    2, UserIdDecimal,
                    TaskCreationOptions.None);
            }
            return guestIds;
        }

       
        async public Task CreateCheckAsync(DBCheck dbCheck)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff ||
                ServiceCallConfig == ServiceCallConfigType.UpdateServicesNoSend)
            {
                return;
            }
            var dbChecks = new List<DBCheck>()
            {
                dbCheck
            };
            try
            {
                var result = await Task.Factory.FromAsync(
                    CheckClient.BeginCreateChecks,
                    CheckClient.EndCreateChecks,
                    dbChecks, UserIdDecimal, false,
                    TaskCreationOptions.None);
            }
            catch (Exception ex)
            {
                var errormessage = ex;
                throw;
            }
        }

        async public Task<List<DBCheck>> GetOpenChecksAsync(decimal tableId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBCheck>();
            }
            return await Task.Factory.FromAsync(
                CheckClient.BeginGetOpenChecks,
                CheckClient.EndGetOpenChecks,
                tableId,
                TaskCreationOptions.None);
        }

        //async public Task<DBUser> GetUserAsync(string pin)
        //{
        //    return await Task.Factory.FromAsync(
        //            waiterClient.BeginGetUser,
        //            waiterClient.EndGetUser,
        //            pin,
        //            TaskCreationOptions.None);
        //}

        async public Task<List<DBTable>> GetTablesForSectionAsync(decimal sectionID)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBTable>();
            }
            return await Task.Factory.FromAsync(
                WaiterClient.BeginGetTablesForSection,
                WaiterClient.EndGetTablesForSection,
                sectionID,
                TaskCreationOptions.None);
        }

        async public Task<bool> HasOpenChecksAsync(decimal tableId)
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return false;
            }
            return await Task.Factory.FromAsync(
                CheckClient.BeginHasOpenChecks,
                CheckClient.EndHasOpenChecks,
                tableId,
                TaskCreationOptions.None);

        }

        async public Task<List<DBTable>> GetTableInfoAsync()
        {
            if (ServiceCallConfig == ServiceCallConfigType.AllServiceCallsOff)
            {
                return new List<DBTable>();
            }
            return await Task.Factory.FromAsync(
              WaiterClient.BeginGetTableSummary,
              WaiterClient.EndGetTableSummary,
              null,
              TaskCreationOptions.None);
        }
        #endregion



       
    }
}
