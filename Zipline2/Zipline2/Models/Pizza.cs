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
    public class Pizza : OrderItem, IHasToppings
    {
        #region Properties
        public Toppings PizzaToppings { get; set; }
        public MajorOrMama MajorMamaInfo { get; set; }
        public PizzaType PizzaType { get; set; }

        public PizzaCrust Crust { get; set; }

        public PizzaSize Size { get; set; }
        #endregion

        #region Constructor
        public Pizza(CustomerSelections guiData)
        {
            MajorMamaInfo = guiData.MajorOrMama;
            PizzaToppings = new Toppings(guiData.PizzaType);
            Crust = guiData.PizzaCrustType;
            Size = guiData.PizzaSize;
            PizzaType = guiData.PizzaType;
            BasePrice = Prices.GetPizzaBasePrice(guiData.PizzaType);
            //TODO:  Is this needed?  Will I ever add a pizza with toppings already there?
            if (guiData.Toppings.CurrentToppings.Count > 0)
            {
                AddToppings(guiData);
            }
        }
        #endregion

        #region Methods
        public override void PopulateDisplayName(CustomerSelections guiData)
        {
            ItemName = DisplayNames.GetPizzaDisplayName(guiData.PizzaType);
        }

        public override void PopulatePricePerItem(CustomerSelections guiData)
        {
            PricePerItem = BasePrice + 
                PizzaToppings.ToppingsTotal;
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

        public void AddToppings(CustomerSelections guiData)
        {
            PizzaToppings = guiData.Toppings; 
        }
        #endregion
    }
}
