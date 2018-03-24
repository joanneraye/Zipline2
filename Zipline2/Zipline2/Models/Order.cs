using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;

namespace Zipline2.Models
{
    /// <summary>
    /// An Order class represents a customer ticket.  It includes OrderItem class objects
    /// and order information such as order subtotal, tax and total as well as a reference to 
    /// the table for the order.
    /// </summary>
    [Table("order")]
    public class Order
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int OrderNumberId { get; set; }

        public List<OrderItem> OrderItems { get; private set; }

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
            if (item != null)
            {
                SubTotal += item.Total;
                Total = SubTotal + HelperMethods.GetTaxAmount(SubTotal);
                OrderItems.Add(item);
            }
        }

    }
}
