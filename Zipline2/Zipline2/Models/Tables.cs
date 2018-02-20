using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Tables
    {
        List<Table> OutsideTables { get; set; }
        List<Table> InsideTables { get; set; }
        int NumSeated { get; set; }
    }
}
