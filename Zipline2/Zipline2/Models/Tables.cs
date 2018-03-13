using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Tables
    {
        #region Singleton Class Setup (Lazy reference needed?)
        //This is a singleton class:
        private static readonly Lazy<Tables> lazy =
            new Lazy<Tables>(() => new Tables());
        public static Tables Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private Tables()
        {

        }
        #endregion (

        #region Properties
        public static List<Table> AllTables { get; set; }
       
        public static int NumSeated { get; set; }
        #endregion

        #region Methods
        public static void LoadInitialTableData()
        {
            AllTables = new List<Table>
                {
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
                    new Table {TableName = "Waldo", IsInside = true}
                };

            for (int i = 0; i < AllTables.Count; i++)
            {
                AllTables[i].IndexInAllTables = i;
            }
        }
        #endregion
    }
}
