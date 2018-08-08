using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.Data
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
                    new Table {TableName = "1", IsInside = true, TableId = 1, TablePageButtonText = "1"},
                    new Table {TableName = "2", IsInside = true, TableId = 2, TablePageButtonText = "2"},
                    new Table {TableName = "3", IsInside = true, TableId = 3, TablePageButtonText = "3"},
                    new Table {TableName = "Cash", IsInside = true, TableId = 14, TablePageButtonText = "$"},
                     new Table {TableName = "Paris", IsInside = true, TableId = 15, TablePageButtonText = "P"},
                    new Table {TableName = "4a", IsInside = true, TableId = 4, TablePageButtonText = "4a"},
                    new Table {TableName = "4b", IsInside = true, TableId = 5, TablePageButtonText = "4b"},
                    new Table {TableName = "5", IsInside = true, TableId = 6, TablePageButtonText = "5"},
                    new Table {TableName = "7a", IsInside = true, TableId = 7, TablePageButtonText = "7a"},
                    new Table {TableName = "7b", IsInside = true, TableId = 8, TablePageButtonText = "7b" },
                    new Table {TableName = "8a", IsInside = true, TableId = 9, TablePageButtonText = "8a" },
                    new Table {TableName = "8b", IsInside = true, TableId = 10, TablePageButtonText = "8b"},
                     new Table {TableName = "Waldo", IsInside = true, TableId = 16, TablePageButtonText = "W"},
                    new Table {TableName = "10", IsInside = true, TableId = 11, TablePageButtonText = "10"},
                    new Table {TableName = "11", IsInside = true, TableId = 12, TablePageButtonText = "11"},
                    new Table {TableName = "12", IsInside = true, TableId = 13, TablePageButtonText = "12"},
                    
                   
                   
                     new Table { TableName = "Van A", TableId = 27, TablePageButtonText = "Va"},
                    new Table { TableName = "Van B", TableId = 28, TablePageButtonText = "Vb"},
                    new Table { TableName = "Alpha", TableId = 20, TablePageButtonText = "A"},
                    new Table { TableName = "Beta", TableId = 21, TablePageButtonText = "B"},
                    new Table { TableName = "Charlie", TableId = 22, TablePageButtonText = "C"},
                    new Table { TableName = "Snoopy", TableId = 23, TablePageButtonText = "S"},
                    new Table { TableName = "Delta", TableId = 24, TablePageButtonText = "D"},
                    new Table { TableName = "Elvis", TableId = 25, TablePageButtonText = "E"},
                   
                    new Table { TableName = "X-Ray", TableId = 29, TablePageButtonText = "X"},
                    new Table { TableName = "Yoda", TableId = 30, TablePageButtonText = "Y"},
                    new Table { TableName = "Zulu", TableId = 31, TablePageButtonText = "Z"},
                    new Table { TableName = "Rocky 1", TableId = 33, TablePageButtonText = "R1"},
                    new Table { TableName = "Rocky 2", TableId = 34, TablePageButtonText = "R2"},
                    new Table { TableName = "Rocky 3", TableId = 35, TablePageButtonText = "R3"},
                    new Table { TableName = "Rocky 4", TableId = 36, TablePageButtonText = "R4"},
                    new Table { TableName = "Rocky 5", TableId = 38, TablePageButtonText = "R5"},
                };

            for (int i = 0; i < AllTables.Count; i++)
            {
                AllTables[i].IndexInAllTables = i;
            }
        }
        #endregion
    }
}
