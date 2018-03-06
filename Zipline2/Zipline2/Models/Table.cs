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
        public const string OpenTableIconName = "orange_square.png";
        public const string OccupiedTableIconName = "blue_square.png";
        public const string TakeoutIconName = "pink_square.png";
        private bool isOccupied;
        private bool isTakeOut;
        [PrimaryKey, Column("tableid")]
        public int TableId { get; set; }

        [Column("tablename")]
        public string TableName { get; set; }

        [Column("indexinalltables")]
        public int IndexInAllTables { get; set; }

        [Column("isinside")]
        public bool IsInside { get; set; }

        [Column("isoccupied")]
        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }
            set
            {
                isOccupied = value;
                if (value)
                {
                    ImageName = OccupiedTableIconName;
                }
                else
                { 
                    ImageName = OpenTableIconName;
                }
            }
        }

        [Column("hasunsentorder")]
        public bool HasUnsentOrder { get; set; }

        public bool IsTakeOut
        {
            get
            {
                return isTakeOut;
            }
            set
            {
                if (value)
                {
                    isTakeOut = value;
                    ImageName = TakeoutIconName;
                }
            }
        }

        private string imageName;
        public string ImageName
        {
            get
            {
                return imageName;
            }
            set
            {
                imageName = value;
            }
        }

        public LayoutOptions TableHorizOptions { get; set; }

        public Table(bool isTakeOut = false)
        {
            if (isTakeOut)
            {
                ImageName = TakeoutIconName;
                TableHorizOptions = LayoutOptions.Center;
            }
            else
            {
                ImageName = OpenTableIconName;
                TableHorizOptions = LayoutOptions.Start;
            }
        }
    }
}
