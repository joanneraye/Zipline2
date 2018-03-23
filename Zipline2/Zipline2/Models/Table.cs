using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.Models
{
    [Table("table")]
    public class Table
    {
        #region Constants and Private Variables
       
        private bool isOccupied;
        private bool isTakeOut;
        private string 
            
            imageName;
        #endregion

        #region Properties
        [PrimaryKey, Column("tableid")]
        public int TableId { get; set; }

        [Column("tablename")]
        public string TableName { get; set; }

        [Column("indexinalltables")]
        public int IndexInAllTables { get; set; }

        [Column("isinside")]
        public bool IsInside { get; set; }

        [Column("isoccupied")]
        public bool IsOccupied { get; set; }

        [Column("hasunsentorder")]
        public bool HasUnsentOrder { get; set; }
       
        #endregion

        #region constructor
        public Table()
        {
           
        }
        #endregion
    }
}
