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
        #region Properties
        public Toppings PizzaToppings { get; set; }
        public MajorOrMama MajorMamaInfo { get; set; }
        public PizzaType PizzaType { get; set; }
        public PizzaCrust Crust { get; set; }
        public PizzaSize Size { get; set; }
        public PizzaBase Base { get; set; }
        #endregion

        #region Constructor
        public Pizza()
        {
            PizzaToppings = new Toppings(this);
        }
        public Pizza(CustomerSelections guiData) : this()
        {
            MajorMamaInfo = guiData.MajorOrMama;
            Crust = guiData.PizzaCrustType;
            Size = guiData.PizzaSize;
            PizzaType = guiData.PizzaType;
            PopulateBasePrice();
        }


        #endregion

        #region Methods

        private void PopulateBasePrice()
        {
            BasePrice = Prices.GetPizzaBasePrice(PizzaType);
        }
        public override void PopulateDisplayName(CustomerSelections guiData)
        {
            ItemName = DisplayNames.GetPizzaDisplayName(guiData.PizzaType);
        }

        public override void PopulatePricePerItem(CustomerSelections guiData)
        {
            PricePerItem = BasePrice + 
                PizzaToppings.ToppingsTotal;
        }

        public void ChangePizzaBase(PizzaBase baseChangeTo)
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
            PopulateBasePrice();
            PizzaToppings.UpdateToppingsTotal();

        }
        public static decimal CalculatePizzaItemCostNoTax(PizzaType pizzaType, int numberOfItems, Toppings toppings = null)
        {
            var basePrice = Prices.GetPizzaBasePrice(pizzaType);
            decimal subtotal = 0M;
            if (toppings != null && toppings.ToppingsTotal != 0)
            {
                subtotal = (basePrice + toppings.ToppingsTotal) * numberOfItems;
            }
            else
            {
                subtotal = basePrice * numberOfItems;
            }
           
            return subtotal;
        }

        public static PizzaType GetPizzaType(PizzaSize size, PizzaCrust crust)
        {
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
        
        public void AddToppings(Toppings toppings)
        {
            PizzaToppings = toppings;
            PopulatePricePerItem(null);
        }
        #endregion
    }
}
