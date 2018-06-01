using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    [Table("pizza")]
    public class Pizza : OrderItem
    {
        #region Properties
        public Toppings Toppings { get; set; }
        public MajorOrMama MajorMamaInfo { get; set; }
        public PizzaType PizzaType { get; set; }
        //public PizzaCrust Crust { get; set; }
        //public PizzaSize Size { get; set; }
        public PizzaBase Base { get; set; }

        #endregion

        #region Constructor
        public Pizza()
        {
            Toppings = new Toppings(PizzaType);
        }



      
        #endregion

        #region Methods

        public override void CompleteOrderItem()
        {
            //TODO:  Are these already done?
            //MajorMamaInfo = pizzaGuiData.MajorOrMama;
            //Crust = pizzaGuiData.PizzaCrustType;
            //Size = pizzaGuiData.PizzaSize;
            //PizzaType = pizzaGuiData.PizzaType;
           
            PopulateBasePrice();
            MessagingCenter.Subscribe<Toppings>(this, "ToppingsTotalUpdated",
              (sender) => { this.PopulatePricePerItem(); });
        }
        public void PopulateBasePrice()
        {
            BasePrice = Prices.GetPizzaBasePrice(PizzaType);
        }
        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetPizzaDisplayName(PizzaType);
        }

        public override void PopulatePricePerItem()
        {
            PricePerItem = BasePrice + 
                Toppings.ToppingsTotal;
        }

        public void ChangePizzaToDeep()
        {
            switch (PizzaType)
            {
                case PizzaType.ThinSlice:
                    PizzaType = PizzaType.PanSlice;
                    break;
                case PizzaType.Large:
                case PizzaType.Medium:
                    PizzaType = PizzaType.SatchPan;
                    break;
                case PizzaType.PestoWhiteLarge:
                case PizzaType.PestoWhiteMedium:
                    PizzaType = PizzaType.PestoWhitePan;
                    break;
            }
            PopulateBasePrice();
            Toppings.UpdateToppingsTotal();
        }

        public void ChangePizzaBase(PizzaBase baseChangeTo, bool updateTotals = true)
        {
            Base = baseChangeTo;
            if (Base == PizzaBase.Regular)
            {
                if (PizzaType == PizzaType.PestoWhitePan)
                {
                    PizzaType = PizzaType.SatchPan;
                }
                else if (PizzaType == PizzaType.PestoWhiteMedium)
                {
                    PizzaType = PizzaType.Medium;
                }
                else if (PizzaType == PizzaType.PestoWhiteLarge)
                {
                    PizzaType = PizzaType.Large;
                }
            } 
            else
            {
                if (PizzaType == PizzaType.SatchPan)
                {
                    PizzaType = PizzaType.PestoWhitePan;
                }
                else if (PizzaType == PizzaType.Medium)
                {
                    PizzaType = PizzaType.PestoWhiteMedium;
                }
                else if (PizzaType == PizzaType.Large)
                {
                    PizzaType = PizzaType.PestoWhiteLarge;
                }
            }

            //Base price and toppings price will change due to the base change.
            if (updateTotals)
            {
                PopulateBasePrice();
                Toppings.UpdateToppingsTotal();
            }
        }
       
        //The PizzaType is used for pricing and so is combination of crust, size, base, etc.
        public static PizzaType GetPizzaType(PizzaSize size, PizzaCrust crust, PizzaBase pizzaBase = PizzaBase.Regular)
        {
            switch (pizzaBase)
            {
                case PizzaBase.Regular:
                    break;
                case PizzaBase.Pesto:
                case PizzaBase.White:
                    if (crust == PizzaCrust.SatchPan)
                    {
                        return PizzaType.PestoWhitePan;
                    }
                    else if (size == PizzaSize.Medium)
                    {
                        return PizzaType.PestoWhiteMedium;
                    }
                    else if (size == PizzaSize.Large)
                    {
                        return PizzaType.PestoWhiteLarge;
                    }
                    break;
            }
            switch (size)
            {
                case PizzaSize.Indy:
                    return PizzaType.Indy;
                case PizzaSize.Slice:
                    if (crust == PizzaCrust.RegularThin)
                    {
                        return PizzaType.ThinSlice;
                    }
                    else
                    {
                        return PizzaType.PanSlice;
                    }
                case PizzaSize.Medium:
                    return PizzaType.Medium;
                case PizzaSize.Large:
                    return PizzaType.Large;
            }
            switch (crust)
            {
                case PizzaCrust.Calzone:
                    return PizzaType.Calzone;
                case PizzaCrust.Mfp:
                    return PizzaType.Mfp;
                case PizzaCrust.SatchPan:
                    return PizzaType.SatchPan;
            }
            return PizzaType.None;
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            return Tuple.Create<string, decimal>("Pizza", 57);
        }

        public override GuestItem CreateGuestItem(DBItem dbItem, decimal orderId)
        {
            GuestItem guestItem = base.CreateGuestItem(dbItem, orderId);
            switch (PizzaType)
            {
                //TODO: GuestComboItems
                case PizzaType.Medium:
                    guestItem.SelectSizeID = 11;
                    break;
                case PizzaType.Large:
                    guestItem.SelectSizeID = 12;
                    break;
                case PizzaType.ThinSlice:
                    guestItem.SelectSizeID = 9;
                    break;
                case PizzaType.Indy:
                    guestItem.SelectSizeID = 10;
                    break;
            }
            return guestItem;
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
            var orderDisplayItem = base.PopulateOrderDisplayItem();
            var toppingsString = new StringBuilder();
            for (int i = 0; i < Toppings.CurrentToppings.Count; i++)
            {
                if (i > 0)
                {
                    toppingsString.Append(", ");
                }
                toppingsString.Append(Toppings.CurrentToppings[i].ToppingDisplayName);


            orderDisplayItem.Toppings = toppingsString.ToString();
            }
            return orderDisplayItem;
        }

        #endregion

    }
}
