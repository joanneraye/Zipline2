using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.Data;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    [Table("pizza")]
    public class Pizza : OrderItem
    {
        #region Properties
        public PizzaToppings Toppings { get; set; }
        private bool getsLunchSpecialDiscount;
        public bool GetsLunchSpecialDiscount
        {
            get
            {
                return getsLunchSpecialDiscount;
            }
            set
            {
                if (value != getsLunchSpecialDiscount)
                {
                    ChangeLunchSpecialDiscount(value);
                }
                getsLunchSpecialDiscount = value;

            }
        }

        public MajorOrMama MajorMamaInfo { get; set; }
        private PizzaType pizzaType;
        public PizzaType PizzaType
        {
            get
            {
                return pizzaType;
            }
            set
            {
                pizzaType = value;
                if (Toppings == null)
                {
                    Toppings = new PizzaToppings(pizzaType, this);
                }
                else
                {
                    Toppings.PizzaTypeForPricing = pizzaType;
                }
            }
        }

        //public PizzaCrust Crust { get; set; }
        //public PizzaSize Size { get; set; }
        public PizzaBase Base { get; set; }

        #endregion

        #region Constructor
        public Pizza()
        {
            MessagingCenter.Subscribe<Toppings>(this, "ToppingsTotalUpdated",
             (sender) => { this.PopulatePricePerItem(); });
        }



      
        #endregion

        #region Methods

        //public override void CompleteOrderItem()
        //{
        //    //TODO:  Are these already done?
        //    //MajorMamaInfo = pizzaGuiData.MajorOrMama;
        //    //Crust = pizzaGuiData.PizzaCrustType;
        //    //Size = pizzaGuiData.PizzaSize;
        //    //PizzaType = pizzaGuiData.PizzaType;
           
        //    PopulateBasePrice();
        //    MessagingCenter.Subscribe<Toppings>(this, "ToppingsTotalUpdated",
        //      (sender) => { this.PopulatePricePerItem(); });
        //}
        public override void PopulateBasePrice()
        {
            BasePriceNoToppings = Prices.GetPizzaBasePrice(PizzaType);
        }
        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetPizzaDisplayName(PizzaType);
            if (MajorMamaInfo == MajorOrMama.Major)
            {
                ItemName += " - MAJOR";
            }
        }

        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = BasePriceNoToppings + 
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
        //public static PizzaType GetPizzaType(PizzaSize size, PizzaCrust crust, PizzaBase pizzaBase = PizzaBase.Regular)
        //{
        //    switch (pizzaBase)
        //    {
        //        case PizzaBase.Regular:
        //            break;
        //        case PizzaBase.Pesto:
        //        case PizzaBase.White:
        //            if (crust == PizzaCrust.SatchPan)
        //            {
        //                return PizzaType.PestoWhitePan;
        //            }
        //            else if (size == PizzaSize.Medium)
        //            {
        //                return PizzaType.PestoWhiteMedium;
        //            }
        //            else if (size == PizzaSize.Large)
        //            {
        //                return PizzaType.PestoWhiteLarge;
        //            }
        //            break;
        //    }
        //    switch (size)
        //    {
        //        case PizzaSize.Indy:
        //            return PizzaType.Indy;
        //        case PizzaSize.Slice:
        //            if (crust == PizzaCrust.RegularThin)
        //            {
        //                return PizzaType.ThinSlice;
        //            }
        //            else
        //            {
        //                return PizzaType.PanSlice;
        //            }
        //        case PizzaSize.Medium:
        //            return PizzaType.Medium;
        //        case PizzaSize.Large:
        //            return PizzaType.Large;
        //    }
        //    switch (crust)
        //    {
        //        case PizzaCrust.Calzone:
        //            return PizzaType.Calzone;
        //        case PizzaCrust.Mfp:
        //            return PizzaType.Mfp;
        //        case PizzaCrust.SatchPan:
        //            return PizzaType.SatchPan;
        //    }
        //    return PizzaType.None;
        //}

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            if (MajorMamaInfo == MajorOrMama.Major)
            {
                return Tuple.Create<string, decimal>("Pizza", 59);
            }
            if (PizzaType == PizzaType.Mfp)
            {
                return Tuple.Create<string, decimal>("Pizza", 60);
            }
            else if (PizzaType == PizzaType.SatchPan)
            {
                return Tuple.Create<string, decimal>("Pizza", 61);
            }
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
                    if (MajorMamaInfo == MajorOrMama.Major)
                    {
                        guestItem.SelectSizeID = 9;
                    }
                    else
                    {
                        guestItem.SelectSizeID = 24;
                    }
                    
                    break;
                case PizzaType.Indy:
                    guestItem.SelectSizeID = 10;
                    break;
                case PizzaType.Mfp:
                    if (MajorMamaInfo == MajorOrMama.Major)
                    {
                        guestItem.SelectSizeID = 22;
                    }
                    else
                    {
                        guestItem.SelectSizeID = 60;
                    }
                    break;
                case PizzaType.SatchPan:
                    if (MajorMamaInfo == MajorOrMama.Major)
                    {
                        guestItem.SelectSizeID = 23;
                    }
                    else
                    {
                        guestItem.SelectSizeID = 15;
                    }                   
                    break;

            }
            return guestItem;
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
            var orderDisplayItem = base.PopulateOrderDisplayItem();
            var toppingsString = new StringBuilder();

            //First just sort toppings....

            List<Topping> wholeToppingsList = new List<Topping>();
            List<Topping> halfAToppings = new List<Topping>();
            List<Topping> halfBToppings = new List<Topping>();

            foreach (var topping in Toppings.CurrentToppings)
            {
                if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                {
                    wholeToppingsList.Add(topping);
                }
                else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfA)
                {
                    topping.ToppingDisplayName = DisplayNames.GetToppingDisplayName(topping.ToppingName);
                    halfAToppings.Add(topping);
                }
                else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfB)
                {
                    topping.ToppingDisplayName = DisplayNames.GetToppingDisplayName(topping.ToppingName);
                    halfBToppings.Add(topping);
                }
            }
           
            Toppings.CurrentToppings = new List<Topping>();
            Toppings.CurrentToppings.AddRange(wholeToppingsList);
            Toppings.CurrentToppings.AddRange(halfAToppings);
            Toppings.CurrentToppings.AddRange(halfBToppings);

            //Next loop through toppings again and insert Half A and Half B as needed.
            bool halfATitlePrinted = false;
            bool halfBTitlePrinted = false;
            for (int i = 0; i < Toppings.CurrentToppings.Count; i++)
            {
                if (i > 0 && Toppings.CurrentToppings[i].ToppingWholeHalf == ToppingWholeHalf.Whole)
                {
                    toppingsString.Append(", ");
                }
                if (Toppings.CurrentToppings[i].ToppingWholeHalf == ToppingWholeHalf.HalfA)
                {
                    if (!halfATitlePrinted)
                    {
                        if (wholeToppingsList.Count > 0)
                        {
                            toppingsString.Append("\n");
                        }
                        toppingsString.Append("HALF A: \n   ");
                        halfATitlePrinted = true;
                    }
                    else
                    {
                        toppingsString.Append("\n   ");
                    }
                    

                }
                else if (Toppings.CurrentToppings[i].ToppingWholeHalf == ToppingWholeHalf.HalfB && !halfBTitlePrinted)
                {
                    if (!halfBTitlePrinted)
                    {
                        if (wholeToppingsList.Count > 0 || halfAToppings.Count > 0)
                        {
                            toppingsString.Append("\n");
                        }
                        toppingsString.Append("HALF B: \n   ");
                        halfBTitlePrinted = true;
                    }
                    else
                    {
                        toppingsString.Append("\n   ");
                    }
                }
                toppingsString.Append(Toppings.CurrentToppings[i].ToppingDisplayName);            
            }
            if (toppingsString.Length != 0)
            {
                orderDisplayItem.Toppings = toppingsString.ToString();
                orderDisplayItem.HasToppings = true;
            }
            return orderDisplayItem;
        }

        
        public override List<GuestModifier> CreateMods()
        {
            //if the toppings are just major toppings and designated as major, then 
            //don't add toppings. 
            List<Topping> tempToppings = Toppings.CurrentToppings;

            bool hasOnion = false;
            bool hasGreenPeppers = false;
            bool hasPepperoni = false;
            bool hasSausage = false;
            bool hasMushrooms = false;
            bool hasBlackOlives = false;
            ToppingWholeHalf onionWholeHalf = ToppingWholeHalf.Whole;
            ToppingWholeHalf grpepWholeHalf = ToppingWholeHalf.Whole;
            ToppingWholeHalf pepWholeHalf = ToppingWholeHalf.Whole;
            ToppingWholeHalf sausWholeHalf = ToppingWholeHalf.Whole;
            ToppingWholeHalf mushWholeHalf = ToppingWholeHalf.Whole;
            ToppingWholeHalf blackolWholeHalf = ToppingWholeHalf.Whole;

            if (MajorMamaInfo == MajorOrMama.Major)
            {
                foreach (var topping in Toppings.CurrentToppings)
                {
                    if (topping.ToppingName == ToppingName.Onion)
                    {
                        hasOnion = true;
                        onionWholeHalf = topping.ToppingWholeHalf;
                    }
                    else if (topping.ToppingName == ToppingName.GreenPeppers)
                    {
                        hasGreenPeppers = true;
                        grpepWholeHalf = topping.ToppingWholeHalf;
                    }
                    else if (topping.ToppingName == ToppingName.Pepperoni)
                    {
                        hasPepperoni = true;
                        pepWholeHalf = topping.ToppingWholeHalf;
                    }
                    else if (topping.ToppingName == ToppingName.Sausage)
                    {
                        hasSausage = true;
                        sausWholeHalf = topping.ToppingWholeHalf;
                    }
                    else if (topping.ToppingName == ToppingName.Mushrooms)
                    {
                        hasMushrooms = true;
                        mushWholeHalf = topping.ToppingWholeHalf;
                    }
                    else if (topping.ToppingName == ToppingName.BlackOlives)
                    {
                        hasBlackOlives = true;
                        blackolWholeHalf = topping.ToppingWholeHalf;
                    }
                    else
                    {
                        tempToppings.Add(topping);
                    }
                }
            }

            List<GuestModifier> mods = DataConversion.GetDbMods(tempToppings);

            if (MajorMamaInfo == MajorOrMama.Major)
            {
                if (!hasOnion)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Onion)));
                }
                if (!hasGreenPeppers)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.GreenPeppers)));
                }
                if (!hasBlackOlives)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.BlackOlives)));
                }
                if (!hasPepperoni)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Pepperoni)));
                }
                if (!hasSausage)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Sausage)));
                }
                if (!hasMushrooms)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Mushrooms)));
                }
                if (hasOnion && onionWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.Onion, onionWholeHalf)));
                }
                if (hasGreenPeppers && grpepWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.GreenPeppers, grpepWholeHalf)));
                }
                if (hasBlackOlives && blackolWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.BlackOlives, blackolWholeHalf)));
                }
                if (hasMushrooms && mushWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.Mushrooms, mushWholeHalf)));
                }
                if (hasPepperoni && pepWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.Pepperoni, pepWholeHalf)));
                }
                if (hasSausage && sausWholeHalf != ToppingWholeHalf.Whole)
                {
                    mods.Add(DataConversion.GetMod(new Topping(ToppingName.Sausage, sausWholeHalf)));
                }
            }

            return mods;
        }

        private void ChangeLunchSpecialDiscount(bool giveDiscount)
        {
            if (giveDiscount)
            {
                if (Toppings.ToppingsTotal > 0)
                {
                    decimal lunchDiscount = Prices.GetLunchSpecialDiscount();
                    ItemName = "Lunch Special Pizza Slice";
                    Toppings.ToppingsTotal -= lunchDiscount;
                    Toppings.ToppingsDiscount = lunchDiscount;
                }
            }
            else
            {
                ItemName = DisplayNames.GetPizzaDisplayName(PizzaType);
                Toppings.ToppingsDiscount = 0M;
                Toppings.UpdateToppingsTotal();
            }
        }

        #endregion

    }
}
