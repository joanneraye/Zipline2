using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Interfaces;

namespace Zipline2.Models
{
    [Table("pizza")]
    public class Pizza : OrderItem
    {
        //Don't forget to add item count to this order item when pizza added.
        public Pizza(CheesePizzaSize sizeOfCheesePizza)
        {
            switch (sizeOfCheesePizza)
            {
                case CheesePizzaSize.Slice:
                    ItemName = DisplayNames.PizzaSliceDisplay;
                    PricePerItem = Prices.PizzaSlicePrice;
                    break;

                case CheesePizzaSize.Indy:
                    ItemName = DisplayNames.PizzaIndyDisplay;
                    PricePerItem = Prices.PizzaIndyPrice;
                    break;

                case CheesePizzaSize.Medium:
                    ItemName = DisplayNames.PizzaMediumDisplay;
                    PricePerItem = Prices.PizzaMediumPrice;
                    break;

                case CheesePizzaSize.Large:
                    ItemName = DisplayNames.PizzaIndyDisplay;
                    PricePerItem = Prices.PizzaIndyPrice;
                    break;
                default:
                    break;
            }
            //Next assumes only 1 pizza added.....
            Total = Prices.PizzaSlicePrice;
        }

        public Pizza(MajorType typeOfMajorPizza)
        {
            switch (typeOfMajorPizza)
            {
                case MajorType.Slice:
                    break;
                case MajorType.Indy:
                    break;
                case MajorType.Medium:
                    break;
                case MajorType.Large:
                    break;
                case MajorType.MFP:
                    break;
                case MajorType.SatchPan:
                    break;
            }

        }

        public Pizza(OtherPizzaTypes mfpOrSatchPan)
        {
            switch (mfpOrSatchPan)
            {
                case OtherPizzaTypes.MFP:
                    break;
                case OtherPizzaTypes.SatchPan:
                    break;
            }
        }

        
        
        

       

      
        //The following not needed here - has to do with prices.....

        //[Column("ispartofspecial")]
        //public bool IsPartOfSpecial { get; set; }

        //[Column("specialpricechange")]
        //public decimal SpecialPriceChange { get; set; }

        //[Column("allowtoppings")]
        ////may not need this - all pizzas allow toppings?
        //public bool AllowToppings { get; set; }

        ////Below only used if AllowToppings is true;
        //[Column("numberoftoppings")]
        //public int NumberOfToppings { get; set; }

        //[Column("pricepertopping")]
        //public decimal PricePerTopping { get; set; }

        //[Column("numberoftoppingforpricebreak")]
        //public int NumberOfToppingsPriceBreak { get; set; }

        //[Column("amountofpricebreak")]
        //public decimal AmountOfPriceBreak { get; set; }        
    }
}
