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
        [PrimaryKey, Column("tablename")]
        public string TableName { get; set; }

        [Column("isoccupied")]
        public bool IsOccupied
        {
            get
            {
                return isOccupied;
            }
            set
            {
                if (value)
                {
                    ImageName = OccupiedTableIconName;
                }
                else
                {
                    isOccupied = value;
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

        public string ImageName { get; private set; }

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
