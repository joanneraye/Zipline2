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

        private string customHeader;
        public string CustomHeader
        {
            get
            {
                return customHeader;
            }
            set
            {
                SetProperty(ref customHeader, value);
            }
        }

        private bool useCustomHeader;
        public bool UseCustomHeader
        {
            get
            {
                return useCustomHeader;
            }
            set
            {
                SetProperty(ref useCustomHeader, value);
            }
        }

        private bool hasToppings;
        public bool HasToppings
        {
            get
            {
                return hasToppings;
            }
            set
            {
                SetProperty(ref hasToppings, value);
            }
        }

    }


}
