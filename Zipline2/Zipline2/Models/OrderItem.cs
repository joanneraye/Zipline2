using SQLite;
using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
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
        public int DbOrderId { get; set; }

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
                UpdateItemTotal();
            }
        }
        private decimal pricePerItem;
        [Column("itemprice")]
        public decimal PricePerItemIncludingToppings
        {
            get
            {
                return pricePerItem;
            }
            set
            {
               
                if (pricePerItem != value)
                {
                    OnPricePerItemUpdated(value);
                }
                SetProperty(ref pricePerItem, value);
                UpdateItemTotal();
            }
        }

        private decimal totalPricePerItemTimesCount;
        
        [Column("itemtotal")]
        public decimal TotalPricePerItemTimesCount
        {
            get
            {
                return totalPricePerItemTimesCount;
            }
            set
            {
                SetProperty(ref totalPricePerItemTimesCount, value);
            }
           
        }

        /// <summary>
        /// The base price is the total of an item without toppings
        /// or extras.  The PricePerItem may be calculated starting 
        /// with the BasePrice and making modifications to it.
        /// </summary>
        public decimal BasePriceNoToppings { get; set; }

        public decimal DbItemId { get; set; }

        private bool wasSentToKitchen;
        public bool WasSentToKitchen
        {
            get
            {
                return wasSentToKitchen;
            }
            set
            {
                SetProperty(ref wasSentToKitchen, value);

            }
        }


        #endregion

        #region Constructor
        /// <summary>
        /// Assume only one item unless changed.
        /// </summary>
        public OrderItem()
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Should not need to be changed by derived classes.
        /// </summary>
        public void UpdateItemTotal()
        {
            TotalPricePerItemTimesCount = PricePerItemIncludingToppings * ItemCount;
        }

        /// <summary>
        /// Do any extra calculations or populate any extra fields 
        /// particular to this orderitem.  Such as a base price for pizza or salad 
        /// (which drinks doesn't have for example).
        /// </summary>
        //p/*ublic abstract void CompleteOrderItem();*/

        /// <summary>
        /// Populate the ItemName field as it will be displayed on screen.
        /// </summary>
        public abstract void PopulateDisplayName();

        /// <summary>
        /// Populate the PricePerItemIncludeToppings field.
        /// </summary>
        public abstract void PopulatePricePerItem();

        /// <summary>
        /// Populate the BasePriceNoToppings field.
        /// </summary>
        public abstract void PopulateBasePrice();

        /// <summary>
        /// An OrderDisplayItem is used to populate the Order Summary Page.
        /// It consists of the OrderItem and string called Toppings that
        /// will include the format of any toppings or notes.
        /// </summary>
        /// <returns></returns>
        public virtual OrderDisplayItem PopulateOrderDisplayItem()
        {
            return new OrderDisplayItem
            {
                OrderItem = this,
                Toppings = string.Empty
            };
        }

        protected virtual void OnPricePerItemUpdated(decimal newValue)
        {
            //Publish message -
            // MenuHeaderModel should subscribe and update ItemTotal.
            MessagingCenter.Send<OrderItem, decimal>(this, "ItemPriceUpdated", newValue);
        }

        public abstract Tuple<string, decimal> GetMenuDbItemKeys();

        public abstract List<GuestModifier> CreateMods();

        public virtual GuestItem CreateGuestItem(DBItem dbItem, decimal orderId)
        {           
            var guestItem = new GuestItem()
            {
                Availability = dbItem.Availability,
                BasePrice = PricePerItemIncludingToppings,
                CanBeHalf = dbItem.CanBeHalf,
                Description = dbItem.Description,
                HasAllMods = dbItem.HasAllMods,
                HasRequiredMods = dbItem.HasRequiredMods,
                OrderID = orderId,
                ID = dbItem.ID,
                LongName = dbItem.LongName,
                NonTaxable = dbItem.NonTaxable,
                ShortName = dbItem.ShortName,
                SelectCommand = dbItem.SelectCommand,
                SizeTable = dbItem.SizeTable,
                Stackable = dbItem.Stackable,
                SubCategoryID = dbItem.SubCategoryID,
                SubCategoryName = dbItem.SubCategoryName,
                SuperCategory = dbItem.SuperCategory,
                SuperCategoryID = dbItem.SuperCategoryID,
                TieredPricing = dbItem.TieredPricing,
                OrderSent = false,
                Mods = new List<GuestModifier>(),
                Note = new List<string>()
            };
            return guestItem;
        }
        #endregion
    }
}
