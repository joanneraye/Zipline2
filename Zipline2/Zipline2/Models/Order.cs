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
      
        public int OrderNumberId { get; set; }

        public List<OrderItem> OrderItems { get; private set; }
        
        public decimal SubTotal { get; set; }
       
        public decimal Tax { get; set; }
       
        public decimal Total { get; set; }

     
        public bool IsTakeout { get; set; }

        public bool WasSentToKitchen { get; set; }

       
        public decimal TableId { get; set; }

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
                Tax = HelperMethods.GetTaxAmount(SubTotal);
                Total = SubTotal + Tax;
                OrderItems.Add(item);
            }
        }

        public void AddItemsToOrder(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                OrderItems.Add(item);
                SubTotal += item.Total;
            }

            Tax = HelperMethods.GetTaxAmount(SubTotal);
            Total = SubTotal + Tax;
        }

    }
}
