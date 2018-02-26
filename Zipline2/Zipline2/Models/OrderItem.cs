using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    public class OrderItem
    {
        [PrimaryKey, AutoIncrement, Column("orderitemid")]
        public int OrderItemId { get; set; }

        [Column("ordernumber")]
        //Must correspond to an order on the Order table (foreign key)
        public int OrderNumberId { get; set; }

        [MaxLength(100), Column("itemname")]
        public string ItemName { get; set; }

        [Column("itemcount")]
        public int ItemCount { get; set; }

        [Column("itemprice")]
        public decimal PricePerItem { get; set; }

        [Column("itemtotal")]
        public decimal Total { get; set; }
    }
}
