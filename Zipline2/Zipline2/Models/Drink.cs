using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2.Models
{
    public class Drink : OrderItem
    {
        public DrinkCategory DrinkCategory { get; set; }
        public DrinkType DrinkType { get; set; }
        public DrinkSize DrinkSize { get; set; }

        public Drink GetClone()
        {
            return (Drink)MemberwiseClone();
        }
    

         public Drink() 
         {
            DrinkType = DrinkType.Water;
         }

        public Drink(DrinkType drinkType)
        {
            DrinkType = drinkType;
            DbItemId = Drinks.GetDbItemId(drinkType);
            PopulatePricePerItem();
        }


       // public override void CompleteOrderItem()
       //{
       //     if (ItemCount > 0 && OrderManager.Instance.OrderInProgress.OrderItems.Count <= 0)
       //     {
       //         OrderManager.Instance.MarkCurrentTableUnsentOrder(true);
       //     }
       // }

       
        //public Drink(CustomerSelection guiData)
        //{
        //    if (guiData is DrinkSelection)
        //    {
        //        DrinkSelection drinkSelection = guiData as DrinkSelection;
        //        drinkSelection.Drink.PopulateDisplayName();
        //        drinkSelection.Drink.PopulatePricePerItem();
        //    }
        //}

        public override void PopulateDisplayName()
        {
            //Done when drink created according to drink category.
        }


        
        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = Prices.GetDrinkPrice(DrinkType);

            //TODO:  What is this about???
            //if (ItemCount > 0 && OrderManager.Instance.OrderInProgress.OrderItems.Count <= 0)
            //{
            //    OrderManager.Instance.MarkCurrentTableUnsentOrder(true);
            //}
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            return Tuple.Create<string, decimal>("Beverages", Drinks.GetDbItemId(DrinkType));
        }

        public override GuestItem CreateGuestItem(DBItem dbItem, decimal orderId)
        {
            GuestItem item = base.CreateGuestItem(dbItem, orderId);
            switch (DrinkSize)
            {
                case DrinkSize.Pint:
                    item.SelectSizeID = 1;
                    break;
                case DrinkSize.Pitcher:
                    item.SelectSizeID = 2;
                    break;
                case DrinkSize.Glass:
                    item.SelectSizeID = 3;
                    break;
                case DrinkSize.Bottle:
                    item.SelectSizeID = 6;
                    break;
            }
            return item;
        }

        public override List<GuestModifier> CreateMods()
        {
            return new List<GuestModifier>();
        }

        public override void PopulateBasePrice()
        {
            BasePriceNoToppings = Prices.GetDrinkPrice(DrinkType);
        }
    }
}
