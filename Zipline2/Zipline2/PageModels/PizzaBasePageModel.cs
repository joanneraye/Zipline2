using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    class PizzaBasePageModel : BasePageModel
    {
        //private Color baseSelectionColor;

        //public Color BaseSelectionColor
        //{
        //    get
        //    {
        //        return baseSelectionColor;
        //    }
        //    set
        //    {
        //        SetProperty(ref baseSelectionColor, value);
        //    }
        //}

        public string[] BaseSelections { get; set; }
        public string[] CookSelections { get; set; }
        public Color BaseSelectionColor { get; set; }
        public Color CookSelectionColor { get; set; }

        public PizzaBasePageModel()
        {
            OrderItem thisItem = OrderManager.GetInstance().OrderItemInProgress;
            string pizzaName = thisItem.ItemName;
            BaseSelections = new string[]
            {
                "Pesto", "White"
            };
            CookSelections = new string[]
           {
                "Pesto", "White"
           };
            BaseSelectionColor = Color.Black;
        }
    }
}
