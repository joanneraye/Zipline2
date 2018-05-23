using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public static class Tables
    {
        //#region Singleton Class 
        //private static Tables instance = null;
        //private static readonly object padlock = new object();
        //private Tables()
        //{
        //    AllTables = new List<Table>();
        //}
        //public static Tables Instance
        //{
        //    get
        //    {
        //        lock (padlock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new Tables();
        //            }
        //            return instance;
        //        }
        //    }
        //}
        //#endregion (

        #region Properties
        private static List<Table> allTables;
        public static List<Table> AllTables
        {
            get
            {
                if (allTables == null)
                {
                    allTables = new List<Table>();
                }
                return allTables;
            }
            set
            {
                allTables = value;
            }
       
        }

        public static int NumSeated { get; set; } = 0;
        #endregion

        #region Methods
        public static void LoadInitialTableData()
        {
            AllTables = new List<Table>
                { 
                    new Table {TableName = "1", IsInside = true, TableId = 1},
                    new Table {TableName = "2", IsInside = true, TableId = 2},
                    new Table {TableName = "3", IsInside = true, TableId = 3},
                    new Table {TableName = "4a", IsInside = true, TableId = 4},
                    new Table {TableName = "4b", IsInside = true, TableId = 5},
                    new Table {TableName = "5", IsInside = true, TableId = 6},
                    new Table {TableName = "7a", IsInside = true, TableId = 7},
                    new Table {TableName = "7b", IsInside = true, TableId = 8},
                    new Table {TableName = "8a", IsInside = true, TableId = 9},
                    new Table {TableName = "8b", IsInside = true, TableId = 10},
                    new Table {TableName = "10", IsInside = true, TableId = 11},
                    new Table {TableName = "11", IsInside = true, TableId = 12},
                    new Table {TableName = "12", IsInside = true, TableId = 13},
                    new Table {TableName = "Cash", IsInside = true, TableId = 14},
                    new Table {TableName = "Paris", IsInside = true, TableId = 15},
                    new Table {TableName = "Waldo", IsInside = true, TableId = 16},
                    new Table { TableName = "Alpha", TableId = 20},
                    new Table { TableName = "Beta", TableId = 21},
                    new Table { TableName = "Charlie", TableId = 22},
                    new Table { TableName = "Snoopy", TableId = 23},
                    new Table { TableName = "Delta", TableId = 24},
                    new Table { TableName = "Elvis", TableId = 25},
                    new Table { TableName = "Van A", TableId = 27},
                    new Table { TableName = "Van B", TableId = 28},
                    new Table { TableName = "X-Ray", TableId = 29},
                    new Table { TableName = "Yoda", TableId = 30},
                    new Table { TableName = "Zulu", TableId = 31},
                    new Table { TableName = "Rocky 1", TableId = 33},
                    new Table { TableName = "Rocky 2", TableId = 34},
                    new Table { TableName = "Rocky 3", TableId = 35},
                    new Table { TableName = "Rocky 4", TableId = 36},
                    new Table { TableName = "Rocky 5", TableId = 38},
                };

            for (int i = 0; i < AllTables.Count; i++)
            {
                AllTables[i].IndexInAllTables = i;
            }
        }
        #endregion
    }
}
