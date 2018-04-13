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
                    new Table {TableName = "1", IsInside = true},
                    new Table {TableName = "2", IsInside = true},
                    new Table {TableName = "3", IsInside = true},
                    new Table {TableName = "4a", IsInside = true},
                    new Table {TableName = "4b", IsInside = true},
                    new Table {TableName = "5", IsInside = true},
                    new Table {TableName = "7a", IsInside = true},
                    new Table {TableName = "7b", IsInside = true},
                    new Table {TableName = "8a", IsInside = true},
                    new Table {TableName = "8b", IsInside = true},
                    new Table {TableName = "10", IsInside = true},
                    new Table {TableName = "11", IsInside = true},
                    new Table {TableName = "12", IsInside = true},
                    new Table {TableName = "Cash", IsInside = true},
                    new Table {TableName = "Paris", IsInside = true},
                    new Table {TableName = "Waldo", IsInside = true},
                    new Table { TableName = "Alpha" },
                    new Table { TableName = "Beta" },
                    new Table { TableName = "Charlie" },
                    new Table { TableName = "Snoopy" },
                    new Table { TableName = "Delta" },
                    new Table { TableName = "Elvis" },
                    new Table { TableName = "Van A" },
                    new Table { TableName = "Van B" },
                    new Table { TableName = "X-Ray" },
                    new Table { TableName = "Yoda" },
                    new Table { TableName = "Zulu" },
                    new Table { TableName = "Rocky 1" },
                    new Table { TableName = "Rocky 2" },
                    new Table { TableName = "Rocky 3" },
                    new Table { TableName = "Rocky 4" },
                    new Table { TableName = "Rocky 5" },
                };

            for (int i = 0; i < AllTables.Count; i++)
            {
                AllTables[i].IndexInAllTables = i;
            }
        }
        #endregion
    }
}
