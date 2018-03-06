using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;

namespace Zipline2.Models
{
    [Table("order")]
    public class Order
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int OrderNumberId { get; set; }

        private List<OrderItem> OrderItems;

        [Column("subtotal")]
        public decimal SubTotal { get; private set; }

        [Column("total")]
        public decimal Total { get; private set; }

        [Column("tax")]
        public decimal Tax { get; private set; }

        [Column("istakeout")]
        public bool IsTakeout { get; set; }

        [Column("tableid")]
        public int TableId { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            IsTakeout = false;
        }

        //When a new OrderItem is added, subtotal, tax, and total are 
        //automatically updated.
        public void AddItemToOrder(OrderItem item)
        {
            SubTotal += item.Total;
            Tax = SubTotal * HelperMethods.GetTaxAmount(SubTotal);  
            Total = SubTotal + Tax;
            OrderItems.Add(item);
        }

    }
}
