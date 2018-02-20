using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    [Table("table")]
    public class Table
    {
        [PrimaryKey, Column("tablename")]
        public string TableName { get; set; }

        [Column("isoccupied")]
        public bool IsOccupied { get; set; }

        [Column("hasunsentorder")]
        public bool HasUnsentOrder { get; set; }
    }
}
