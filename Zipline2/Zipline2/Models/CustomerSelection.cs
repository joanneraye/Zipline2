using SQLite;
using System;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    /// <summary>
    /// The OrderItem is a critical class object because the purpose
    /// of Zipline is to create Orders by creating OrderItems.
    /// </summary>

    public class CustomerSelection : BasePageModel
    {
        public MenuCategory MenuItemGeneralCategory { get; set; }
        public string ItemName { get; set; }
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
      
        public CustomerSelection()
        {
            PopulateItemCount();
        }

      
        /// <summary>
        /// Do I even need this since they can just update the ItemCount?
        /// </summary>
        public virtual void PopulateItemCount()
        {
            ItemCount = 1;
        }

    }
}
