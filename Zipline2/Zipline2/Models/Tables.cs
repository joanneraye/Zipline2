using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public static class Tables
    {
        
        public static List<Table> OutsideTables { get; set; }
        public static List<Table> InsideTables { get; set; }
        public static int NumSeated { get; set; }

        public static void LoadInitialTableData()
        {
            OutsideTables = new List<Table>
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
                    new Table { TableName = "Rocky 5" }
                };

            InsideTables = new List<Table>
                {
                    new Table {TableName = "1"},
                    new Table {TableName = "2"},
                    new Table {TableName = "3"},
                    new Table {TableName = "4a"},
                    new Table {TableName = "4b"},
                    new Table {TableName = "5"},
                    new Table {TableName = "7a"},
                    new Table {TableName = "7b"},
                    new Table {TableName = "8a"},
                    new Table {TableName = "8b"},
                    new Table {TableName = "10"},
                    new Table {TableName = "11"},
                    new Table {TableName = "12"},
                    new Table {TableName = "Cash"},
                    new Table {TableName = "Paris"},
                    new Table {TableName = "Waldo"}
                };
        }
        
    }
}
