using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.PageModels
{
    public class MenuHeaderModel : BasePageModel
    {
        private decimal itemTotal;
        private decimal orderTotal;

        public decimal ItemTotal
        {
            get
            {
                return itemTotal;
            }
            set
            {
                //if (App.PizzaInProgress != null)
                //{
                //    itemTotal = App.PizzaInProgress.Total;
                //}

                SetProperty(ref itemTotal, value);
            }
        }

        public decimal OrderTotal
        {
            get
            {
                return orderTotal;
            }
            set
            {
                SetProperty(ref orderTotal, value);
            }
        }
    }
}
