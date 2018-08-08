using SQLite;
using Staunch.POS.Classes;
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
       
       
        private bool isTakeOut;
       
        #endregion

        #region Properties
        [PrimaryKey, Column("tableid")]
        public decimal TableId { get; set; }

        [Column("tablename")]
        public string TableName { get; set; }

        [Column("indexinalltables")]
        public int IndexInAllTables { get; set; }

        private string tablePageButtonText;
        public string TablePageButtonText
        {
            get
            {
                return tablePageButtonText;
            }
            set
            {
                SetProperty(ref tablePageButtonText, value);
            }
        }

        [Column("isinside")]
        public bool IsInside { get; set; }

        private bool isOccupied;
        [Column("isoccupied")]
        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }
            set
            {
                SetProperty(ref isOccupied, value);
            }
        }

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

        public DBTable DatabaseTable { get; set; }

        public Order OpenOrder { get; set; }

        #endregion

        #region constructor
        public Table()
        {
            //Don't initialize OpenOrder.  We can tell it is not valued if it is null;
        }
        #endregion
    }
}
