using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class OrderDisplayItem : BasePageModel
    {
        private OrderItem orderItem;
        public OrderItem OrderItem
        {
            get
            {
                return orderItem;
            }
            set
            {
                SetProperty(ref orderItem, value);
            }
        }

        private string toppings;
        public string Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                SetProperty(ref toppings, value);
            }
        }

    }


}
