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
        public enum OrderType           //IS THIS NEEDED???
        {
            Pizza,
            Calzone,
            Drink,
            LunchSpecial,
            Salad,
            Merchandise
        }
        [PrimaryKey, AutoIncrement, Column("id")]
        public int OrderNumberId { get; set; }

        //When I new OrderItem is added, subtotal, tax, and total are 
        //automatically updated.
        public List<OrderItem> OrderItems { get; private set; }
       
        public decimal SubTotal { get; private set; }
        [Column("total")]
        public decimal Total { get; private set; }

        public decimal Tax { get; private set; }

        public bool IsTakeout { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
            IsTakeout = false;
        }

        public void AddItemToOrder(OrderItem item)
        {
            SubTotal += item.Total;
            Tax = SubTotal * HelperMethods.GetTaxAmount(SubTotal);  //TODO:  Round this???
            Total = SubTotal + Tax;
            OrderItems.Add(item);
        }

    }
}
