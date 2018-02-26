using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{ 
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("userid")]
        public int UserId { get; set; }

        [Column("username"), MaxLengthAttribute(15)]
        public string UserName { get; set; }

        [Column("hasmanagerprivilege")]
        public bool HasManagerPrivilege { get; set; }

        public string UserPin { get; set; }
    }
}
