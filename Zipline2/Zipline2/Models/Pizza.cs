using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.DictionaryKeys;
using Zipline2.Interfaces;
using Zipline2.Pages;

namespace Zipline2.Models
{
    [Table("pizza")]
    public class Pizza : OrderItem
    {
        public Pizza(CustomerSelections guiData)
        {
            switch (guiData.MajorOrMama)
            {
                case MajorOrMama.Neither:
                    switch (guiData.PizzaType)
                    {
                        case PizzaType.RegularThin:
                            StartPizza(guiData.PizzaSize);
                            break;
                        case PizzaType.SatchPan:
                            StartSatchPan();
                            break;
                        case PizzaType.Mfp:
                            StartMfp();
                            break;
                    }
                    break;
                case MajorOrMama.Major:
                    CreateMajorOrMama(MajorOrMama.Major, guiData.PizzaSize, guiData.PizzaType);
                    break;
                case MajorOrMama.Mama:
                    CreateMajorOrMama(MajorOrMama.Mama, guiData.PizzaSize, guiData.PizzaType);
                    break;
            }
            
            ItemCount = guiData.NumberOfItems;
            Total = PricePerItem * ItemCount;
        }
        
        //Don't forget to add item count to this order item when pizza added.
        public void StartPizza(PizzaSize sizeOfCheesePizza)
        {
            switch (sizeOfCheesePizza)
            {
                case PizzaSize.Slice:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_SLICE];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_SLICE];
                    break;

                case PizzaSize.Indy:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_INDY];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_INDY];
                    break;

                case PizzaSize.Medium:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_MEDIUM];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_MEDIUM];
                    break;

                case PizzaSize.Large:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_LARGE];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_LARGE];
                    break;
                default:
                    break;
            }
        }

        public void StartSatchPan()
        {
        }
        public void CreateMajorOrMama(MajorOrMama majorOrMama, PizzaSize sizeOfMajorPizza, PizzaType typeOfMajorPizza)
        {
            int toppingPriceIndex;
            if (majorOrMama == MajorOrMama.Major)
            {
                toppingPriceIndex = 5;
            }
            else
            {
                toppingPriceIndex = 3;
            }
            //NOTE:  Major is 6 toppings. 
            switch (sizeOfMajorPizza)
            {
                //TODO:  Add MAJOR TO THESE names
                case PizzaSize.Slice:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_SLICE] + "\n  MAJOR";
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_SLICE] +
                        + Prices.ToppingsPriceDictionary[Key.SLICE_TOPPINGS][toppingPriceIndex];
                    break;
                case PizzaSize.Indy:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_INDY];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_INDY] +
                       + Prices.ToppingsPriceDictionary[Key.INDY_TOPPINGS][toppingPriceIndex];
                    break;
                case PizzaSize.Medium:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_MEDIUM];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_MEDIUM] +
                       + Prices.ToppingsPriceDictionary[Key.MEDIUM_TOPPINGS][toppingPriceIndex];
                    break;
                case PizzaSize.Large:
                    ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_LARGE];
                    PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_LARGE] +
                       + Prices.ToppingsPriceDictionary[Key.LARGE_TOPPINGS][toppingPriceIndex];
                    break;
                case PizzaSize.OneSize:
                    switch (typeOfMajorPizza)
                    {
                        case PizzaType.Mfp:
                            ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_MFP];
                            PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_MFP] +
                               + Prices.ToppingsPriceDictionary[Key.MFP_TOPPINGS][toppingPriceIndex];
                            break;
                        case PizzaType.SatchPan:
                            ItemName = DisplayNames.DisplayNameDictionary[Key.PIZZA_SATCHPAN];
                            PricePerItem = Prices.BasePriceDictionary[Key.PIZZA_SATCHPAN] +
                               + Prices.ToppingsPriceDictionary[Key.SATCHPAN_TOPPINGS][toppingPriceIndex];
                            break;
                    }
                    break;
            }
        }

     
        private void StartMfp()
        {

        }
    }
}
