﻿using SQLite;
using System;
using Xamarin.Forms;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    /// <summary>
    /// The OrderItem is a critical class object because the purpose
    /// of Zipline is to create Orders by creating OrderItems.
    /// </summary>

    public abstract class OrderItem : BasePageModel
    {
        #region Class Properties
        [PrimaryKey, AutoIncrement, Column("orderitemid")]
        public int OrderItemId { get; set; }

        [Column("ordernumber")]
        //Must correspond to an order on the Order table (foreign key)
        public int OrderNumberId { get; set; }

        [MaxLength(100), Column("itemname")]
        public string ItemName { get; set; }

        /// <summary>
        /// The item count is not the number of the general item (such
        /// as the number of medium pizzas) but the number of this 
        /// exact item (such as medium thin with anchovies).
        /// </summary>
        private int itemCount;
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                SetProperty(ref itemCount, value);
            }
        }
        private decimal pricePerItem;
        [Column("itemprice")]
        public decimal PricePerItem
        {
            get
            {
                return pricePerItem;
            }
            set
            {
                if (value != pricePerItem)
                {
                    pricePerItem = value;
                    OnPricePerItemUpdated();
                }
            }
        }

        [Column("itemtotal")]
        public decimal Total { get; set; }
        
        /// <summary>
        /// The base price is the total of an item without toppings
        /// or extras.  The PricePerItem may be calculated starting 
        /// with the BasePrice and making modifications to it.
        /// </summary>
        public decimal BasePrice { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Assume only one item unless changed.
        /// </summary>
        public OrderItem()
        {
            ItemCount = 1;
            MessagingCenter.Subscribe<Toppings>(this, "ToppingsTotalUpdated",
                (sender) => { this.PopulatePricePerItem(); });
        }
        #endregion

        #region Methods
        /// <summary>
        /// Because this is virtual, this method will be used by the 
        /// derived classes unless the derrived class overrides this
        /// implementation.
        /// </summary>
        public virtual void UpdateItemTotal()
        {
            Total = PricePerItem * ItemCount;
        }

        /// <summary>
        /// A derived class must populate its display name.
        /// </summary>
        public abstract void PopulateDisplayName();

        /// <summary>
        /// A derived class must populate its price.
        /// </summary>
        public abstract void PopulatePricePerItem();

        protected virtual void OnPricePerItemUpdated()
        {
            //Publish message -
            // MenuHeaderModel should subscribe and update ItemTotal.
            MessagingCenter.Send<OrderItem, decimal>(this, "ItemPriceUpdated", PricePerItem);
        }
            #endregion
    }
}
