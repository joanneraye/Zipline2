﻿using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.Data;
using Zipline2.BusinessLogic.Enums;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    public class Salad : OrderItem
    {
        public SaladSize SizeOfSalad { get; set; }

        public SaladToppings Toppings { get; set; }

        public Salad(SaladSize sizeOfSalad)
        {
            SizeOfSalad = sizeOfSalad;
            Toppings = new SaladToppings(SizeOfSalad, this);
            //MessagingCenter.Subscribe<SaladToppings>(this, "SaladToppingsTotalUpdated",
            // (sender) => { this.PopulatePricePerItem(); });
        }

        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetSaladDisplayName(SizeOfSalad);
        }

        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = BasePriceNoToppings + Toppings.ToppingsTotal;
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            return Tuple.Create<string, decimal>("Salads", 50);
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
           
            OrderDisplayItem displayItem = base.PopulateOrderDisplayItem();
            var toppingsString = new StringBuilder();
            for (int i = 0; i < Toppings.CurrentToppings.Count; i++)
            {
                if (SizeOfSalad == SaladSize.LunchSpecial)
                {
                    toppingsString.Append("   ");
                }
                if (i == 0)
                {
                    toppingsString.Append("   ");
                }
                else
                {
                    toppingsString.Append("\n   ");
                }
                toppingsString.Append(Toppings.CurrentToppings[i].ToppingDisplayName);
            }
            if (toppingsString.Length != 0)
            {
                displayItem.Toppings = toppingsString.ToString();
                displayItem.HasToppings = true;
            }
                
            return displayItem;
        }

        public override GuestItem CreateGuestItem(DBItem dbItem, decimal orderId)
        {
            GuestItem guestItem = base.CreateGuestItem(dbItem, orderId);
            switch (SizeOfSalad)
            {
                case SaladSize.LunchSpecial:
                    guestItem.SelectSizeID = 14;
                    break;
                case SaladSize.Small:
                    guestItem.SelectSizeID = 7;
                    break;
                case SaladSize.Large:
                    guestItem.SelectSizeID = 8;
                    break;
            }
            return guestItem;
        }

        public override List<GuestModifier> CreateMods()
        {
            //Turn topping modifications into mods for the server.
            return new List<GuestModifier>();
        }

        public override void PopulateBasePrice()
        {
            BasePriceNoToppings = Prices.GetSaladPrice(SizeOfSalad);
        }
    }
}
