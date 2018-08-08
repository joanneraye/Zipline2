using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Zipline2.BusinessLogic.Enums;
using Zipline2.PageModels;
using Zipline2.Data;

namespace Zipline2.Models
{
    public class Dessert : OrderItem
    {
        public DessertType DessertType;
        public bool IsCookie;
        public Dessert()
        {
            
        }

        public Dessert(DessertType dessertType)
        {
            DessertType = dessertType;
            DbItemId = MenuFood.GetDbItemId(dessertType);
            ItemName = DisplayNames.GetDessertDisplayName(dessertType);
            PopulateBasePrice();
            PopulatePricePerItem();
        }


        public override List<GuestModifier> CreateMods()
        {
            return new List<GuestModifier>();
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            return Tuple.Create<string, decimal>("Dessert", MenuFood.GetDbItemId(DessertType));
        }

        public override void PopulateBasePrice()
        {
            BasePriceNoToppings = Prices.GetDessertPrice(DessertType);
        }

        internal Dessert GetClone()
        {
            return (Dessert)MemberwiseClone();
        }

      
        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetDessertDisplayName(DessertType);
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
            return base.PopulateOrderDisplayItem();
        }

        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = Prices.GetDessertPrice(DessertType);
        }

    }
}
