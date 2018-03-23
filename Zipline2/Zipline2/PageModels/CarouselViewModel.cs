using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class CarouselViewModel : BasePageModel
    {
        private string[] toppingsCarousel;
        public string[] ToppingsCarousel
        {
            get
            {
                return toppingsCarousel;
            }
            set
            {
                SetProperty(ref toppingsCarousel, value);
            }
        }

        //private int toppingsCarouselIndex;
        //public int ToppingsCarouselIndex
        //{
        //    get
        //    {
        //        return toppingsCarouselIndex;
        //    }
        //    set
        //    {
        //        SetProperty(ref toppingsCarouselIndex, value);
        //    }
        //}

        public int ToppingsCarouselIndex { get; set; }
        public PizzaType PizzaType { get; set; }

        private static CarouselViewModel Instance;
        private CarouselViewModel()
        {
            OrderItem thisItem = OrderManager.GetInstance().OrderItemInProgress;
            string pizzaName = thisItem.ItemName;
            Pizza thisPizza = thisItem as Pizza;
            PizzaType = thisPizza.PizzaType;
            ToppingsCarousel = new string[]
           {
                "Toppings for " + pizzaName,
                "      Base for "  + pizzaName,
                "      Cook for " + pizzaName,
                "      Other for " + pizzaName
           };

            //ToppingsCarouselIndex = index;
        }
        public static CarouselViewModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CarouselViewModel();
            }
            return Instance;
        }
    }
}
