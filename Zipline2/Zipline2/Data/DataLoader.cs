using Staunch.POS.Classes;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Data;

namespace Zipline2.BusinessLogic
{
    static class DataLoader
    {

        //static Stopwatch Watch;
        //public static async Task<AggregateException> LoadDataAsync()
        //{
        //    try
        //    {
        //        Watch = System.Diagnostics.Stopwatch.StartNew();

        //        var tableDataTask = LoadTableData();


        //        Watch.Stop();
        //        var timeSoFar = Watch.Elapsed.Milliseconds;
        //        Console.WriteLine("JR tables from server, time " + timeSoFar.ToString());
        //        Watch.Start();

        //        var tablesServerTask = WcfServicesProxy.Instance.GetTablesAsync();

        //        Watch.Stop();
        //        var timeSoFar2 = Watch.Elapsed.Milliseconds;
        //        Console.WriteLine("JR tables from server again, time " + timeSoFar2.ToString());
        //        //Watch.Reset();
        //        //Watch.Start();

        //        //var menuServerTask = WcfServicesProxy.Instance.GetMenuAsync();

        //        //Watch.Stop();
        //        //var timeSoFar3 = Watch.Elapsed.Milliseconds;
        //        //Console.WriteLine("JR got menu, time " + timeSoFar3.ToString());
        //        //Watch.Reset();
        //        //Watch.Start();

        //        //var toppingsServerTask = DataBaseDictionaries.LoadToppingsFromServerAsync();

        //        //Watch.Stop();
        //        //var timeSoFar4 = Watch.Elapsed.Milliseconds;
        //        //Console.WriteLine("JR got toppings, time " + timeSoFar4.ToString());
        //        //Watch.Reset();
        //        //Watch.Start();

        //        //await Task.WhenAll(tableDataTask, tablesServerTask, menuServerTask, toppingsServerTask);

        //        //Watch.Stop();
        //        //var timeSoFar5 = Watch.Elapsed.Milliseconds;
        //        //Console.WriteLine("JR got ALL, time " + timeSoFar5.ToString());

        //        //return tablesServerTask.Exception;
        //    }
        //    catch (Exception ex)
        //    {

        //        return (AggregateException)ex;
        //    }
           
           
        //}


        public static async Task<bool> LoadTableDataAsync()
        {
            DataBaseDictionaries.DbTablesDictionary = new Dictionary<decimal, DBTable>();

            var orderManager = OrderManager.Instance;

            if (orderManager.OrderInProgress != null && orderManager.OrderInProgress.OrderItems.Count > 0)
            {
                Tables.AllTables[orderManager.CurrentTableIndex].OpenOrder = OrderManager.Instance.OrderInProgress;
            }

            DataBaseDictionaries.DbTablesDictionary = new Dictionary<decimal, DBTable>();
            List<DBTable> tables = new List<DBTable>();    

            //TODO:  Need to catch exceptions from the following await.  I can do a try catch, but 
            //how do I pass the error back in the Task?
            tables = await WcfServicesProxy.Instance.GetTableInfoAsync();            
            
            foreach (var table in tables)
            {
                DataBaseDictionaries.DbTablesDictionary.Add(table.ID, table);
                bool hasUnsentItems = false;
                bool tableOccupied = false;
                int indexInAllTables = 0;
                if (DataBaseDictionaries.TableIdAllTablesIndexDictionary.ContainsKey(table.ID))
                {
                    indexInAllTables = DataBaseDictionaries.TableIdAllTablesIndexDictionary[table.ID];
                }
                else
                {
                    Console.WriteLine("***Debug JOANNE***TABLE NOT FOUND FOR TABLE ID: " + table.ID);
                }
                var thisTable = Tables.AllTables[indexInAllTables];
                if (!table.IsClear)
                {
                    tableOccupied = true;
                }
                foreach (var guest in table.Guests)
                {
                    if (guest.Items.Count > 0 || guest.ComboItems.Count > 0)
                    {
                        foreach (var item in guest.Items)
                        {
                            if (!item.OrderSent)
                            {
                                hasUnsentItems = true;
                            }
                        }
                        if (!hasUnsentItems)
                        {
                            foreach (var comboitem in guest.ComboItems)
                            {
                                foreach (var guestitem in comboitem.ComboGuestItems)
                                    if (!guestitem.OrderSent)
                                    {
                                        hasUnsentItems = true;
                                    }
                            }
                        }
                    }
                    //no items from server so use local table saved if one exists.
                    else if (thisTable.OpenOrder != null)
                    {
                        if (thisTable.OpenOrder.OrderItems.Count > 0)
                        {
                            tableOccupied = true;
                        }
                        if (!thisTable.OpenOrder.AllItemsSent)
                        {
                            hasUnsentItems = true;
                        }
                    }
                }


                if (tableOccupied)
                {
                    Tables.AllTables[indexInAllTables].IsOccupied = tableOccupied;

                    if (hasUnsentItems)
                    {
                        Tables.AllTables[indexInAllTables].HasUnsentOrder = hasUnsentItems;
                    }
                }
            }
            return true;
        }
    }
}
