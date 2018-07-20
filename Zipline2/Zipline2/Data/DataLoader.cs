using Staunch.POS.Classes;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Data;
using System.IO;
using Newtonsoft.Json;
using Zipline2.BusinessLogic;

namespace Zipline2.Data
{
    static class DataLoader
    {
        public static void LoadMenuFromFileOrServer(string fileName = "WaiterClientMenu.json")
        {
            string writeFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var pathWithFileName = Path.Combine(writeFilePath, fileName);
            if (File.Exists(pathWithFileName))
            {
                DataBaseDictionaries.MenuDictionary = JsonConvert.DeserializeObject<Dictionary<string, List<DBItem>>>(File.ReadAllText(pathWithFileName));
            }
            else
            {
                WcfServicesProxy.Instance.GetMenu();
                File.WriteAllText(pathWithFileName, JsonConvert.SerializeObject(DataBaseDictionaries.MenuDictionary));
            }
        }

        public static void LoadToppingsFromFileOrServer()
        {
            string pizzaToppingsFileName = "WaiterClientPizzaToppings.json";
            string saladToppingsFileName = "WaiterClientSaladToppings.json";

            string writeFilePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var pizzaTopPathWithFileName = Path.Combine(writeFilePath, pizzaToppingsFileName);
            var saladTopPathWithFileName = Path.Combine(writeFilePath, saladToppingsFileName);

            if (File.Exists(pizzaTopPathWithFileName))
            {
                DataBaseDictionaries.PizzaToppingsDictionary = JsonConvert.DeserializeObject<Dictionary<decimal, DBModifier>>(File.ReadAllText(pizzaTopPathWithFileName));
            }
            else
            {
                DataBaseDictionaries.LoadPizzaToppingsFromServer();
                File.WriteAllText(pizzaTopPathWithFileName, JsonConvert.SerializeObject(DataBaseDictionaries.PizzaToppingsDictionary));
            }

            if (File.Exists(saladTopPathWithFileName))
            {
                DataBaseDictionaries.SaladToppingsDictionary = JsonConvert.DeserializeObject<Dictionary<decimal, DBModifier>>(File.ReadAllText(saladTopPathWithFileName));
            }
            else
            {
                DataBaseDictionaries.LoadSaladToppingsFromServer();
                File.WriteAllText(saladTopPathWithFileName, JsonConvert.SerializeObject(DataBaseDictionaries.SaladToppingsDictionary));
            }

        }
    }
}



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
