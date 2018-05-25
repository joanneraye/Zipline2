using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    [Table("table")]
    public class Table : BasePageModel
    {
        #region Constants and Private Variables
       
        private bool isOccupied;
        private bool isTakeOut;
       
        #endregion

        #region Properties
        [PrimaryKey, Column("tableid")]
        public decimal TableId { get; set; }

        [Column("tablename")]
        public string TableName { get; set; }

        [Column("indexinalltables")]
        public int IndexInAllTables { get; set; }

        [Column("isinside")]
        public bool IsInside { get; set; }

        [Column("isoccupied")]
        public bool IsOccupied { get; set; }

        private bool hasUnsentOrder;
        public bool HasUnsentOrder
        {
            get
            {
                return hasUnsentOrder;
            }
            set
            {
                SetProperty(ref hasUnsentOrder, value);
            }
        }

        public List<Order> OpenOrders { get; set; }

        #endregion

        #region constructor
        public Table()
        {
            OpenOrders = new List<Order>();
        }
        #endregion
    }
}
