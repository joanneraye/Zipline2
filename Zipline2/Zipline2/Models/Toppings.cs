using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;

namespace Zipline2.Models
{
    /// <summary>
    /// A Toppings class object should always be contained in a Pizza
    /// class because it is always associated with a particular pizza.
    /// </summary>
    public class Toppings
    {
        #region Properties
        
        public List<Topping> CurrentToppings { get; private set; }

        
        public PizzaType PizzaTypeForPricing { get; set; }
        private decimal toppingsTotal;
        public decimal ToppingsTotal
        {
            get
            {
                return toppingsTotal;
            }
            private set
            {
                toppingsTotal = value;
                MessagingCenter.Send<Toppings>(this, "ToppingsTotalUpdated");
            }
        }

        

        #endregion

        #region constructor

        /// <summary>
        /// Toppings should always be associated with a particular pizza already chosen.
        /// </summary>
        /// <param name="pizzaWithTheseToppings"></param>
        public Toppings(PizzaType pizzaTypeForPricing)
        {
            CurrentToppings = new List<Topping>();
            PizzaTypeForPricing = pizzaTypeForPricing;
        }
        #endregion

        #region Methods
       
        /// <summary>
        /// Method should be called when the topping prices need to be updated
        /// but a topping has not been added.  (When a topping is added or removed, this will
        /// be done automatically in this class.)  Example would be when the base type changes, 
        /// topping prices can be different.  Or when the topping has been added
        /// but is changed to half of the pizza.
        /// </summary>
        public void UpdateToppingsTotal()
        {
            ToppingsTotal = GetCurrentToppingsCost();
        }
            
        public bool CurrentToppingsHas(ToppingName toppingName)
        {
            foreach (var topping in CurrentToppings) 
            {
                if (toppingName == topping.ToppingName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddTopping(Topping toppingToAdd, bool calculateTotal = true)
        {
            CurrentToppings.Add(toppingToAdd);
            if (calculateTotal)
            {
                UpdateToppingsTotal();
            }
        }

        public void AddToppings(List<Topping> toppingsToAdd)
        {
            foreach (var topping in toppingsToAdd)
            {
                if (CurrentToppingsHas(topping.ToppingName))
                {
                    RemoveTopping(topping.ToppingName, false);
                }
                AddTopping(topping, false);
            }

            UpdateToppingsTotal();
        }


        public void ChangeToppingToHalf(ToppingName toppingName, ToppingWholeHalf toppingHalf)
        {
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == toppingName)
                {
                    topping.ToppingWholeHalf = toppingHalf;
                    break;
                }
            }
            UpdateToppingsTotal();
        }
        public void RemoveTopping(ToppingName toppingName, bool calculateTotal = true)
        {
            int indexToRemove = 99;
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == toppingName)
                {
                    //Can't remove an item from a list you are currently iterating through.
                    indexToRemove = CurrentToppings.IndexOf(topping);
                    break;
                }
            }
            if (indexToRemove != 99)
            {
                CurrentToppings.RemoveAt(indexToRemove);
            } 
            if (calculateTotal)
            {
                ToppingsTotal = GetCurrentToppingsCost();
            }
        }

        public void RemoveToppings(List<ToppingName> toppingNames)
        {
            foreach (var toppingName in toppingNames)
            {
                RemoveTopping(toppingName, false);
            }
            UpdateToppingsTotal();
        }

        private decimal GetCurrentToppingsCost()
        {
            decimal toppingCost = 0M;
            decimal toppingCountForPrice = GetToppingCountForPricing();
            int wholeToppingCount = Convert.ToInt32(Math.Floor(toppingCountForPrice));
            int wholeToppingIndex = (wholeToppingCount - 1);
            var thisPizzaToppingPrices = Prices.ToppingsPriceDictionary[PizzaTypeForPricing];
            var lastToppingPriceIndex = thisPizzaToppingPrices.Length - 2;
            var additionalToppingCostIndex = thisPizzaToppingPrices.Length - 1;
            var numberOfExtraWholeToppings = wholeToppingIndex - lastToppingPriceIndex;
            var pricePerAdditionalTopping = thisPizzaToppingPrices[additionalToppingCostIndex];
            if (wholeToppingCount <= 0)
            {
                // Whole topping count is <= 0, so topping cost will be zero or a negative number.
                return wholeToppingCount * pricePerAdditionalTopping;
            }
            else if (numberOfExtraWholeToppings > 0)
            {
                var additionalToppingCost = numberOfExtraWholeToppings * pricePerAdditionalTopping;
                toppingCost = thisPizzaToppingPrices[lastToppingPriceIndex] + additionalToppingCost;
            }
            else
            {
                toppingCost = thisPizzaToppingPrices[wholeToppingIndex];
             
            }

            if ((toppingCountForPrice % 1) > 0)      //Includes 1/2 a topping
            {
                int roundUpToppingCount = Convert.ToInt32(Math.Ceiling(toppingCountForPrice));
                int nextHigherToppingIndex = roundUpToppingCount - 1;
                var toppingCostWithHalfTopping = toppingCost + (pricePerAdditionalTopping / 2);
                if (nextHigherToppingIndex <= lastToppingPriceIndex &&
                    toppingCostWithHalfTopping > thisPizzaToppingPrices[nextHigherToppingIndex])
                {
                    toppingCost = thisPizzaToppingPrices[nextHigherToppingIndex];
                }
                else
                {
                    toppingCost = toppingCostWithHalfTopping;
                }
            }
            
            return toppingCost;
        }

        private decimal GetToppingCountForPricing()
        {
            decimal toppingCount = 0M;
            //TODO:  Still have to handle half and whole toppings
            foreach (var topping in CurrentToppings)
            { 
                switch (topping.SpecialPricingType)
                {
                    case SpecialPricingType.Free:
                        break;
                    case SpecialPricingType.None:
                        if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                        {
                            toppingCount++;
                        }
                        else
                        {
                            toppingCount += .5M; ;
                        }
                        break;
                    case SpecialPricingType.AddHalfTopping: 
                        toppingCount += .5M;
                        break;
                    case SpecialPricingType.SubtractTopping:
                    case SpecialPricingType.GetExtraTopping:
                        toppingCount--;
                        break;
                    case SpecialPricingType.DoubleTopping:
                        if (topping.ToppingWholeHalf == ToppingWholeHalf.Whole)
                        {
                            toppingCount += 2M;
                        }
                        else
                        {
                            toppingCount++;
                        }
                        break;
                }
            }
            return toppingCount;
        }
      
        public void AddMajorToppings()
        {
            var majorToppings = new List<Topping>();
            majorToppings.Add(new Topping(ToppingName.Pepperoni));
            majorToppings.Add(new Topping(ToppingName.Mushrooms));
            majorToppings.Add(new Topping(ToppingName.Sausage));
            majorToppings.Add(new Topping(ToppingName.GreenPeppers));
            majorToppings.Add(new Topping(ToppingName.Onion)); ;
            majorToppings.Add(new Topping(ToppingName.BlackOlives));
            AddToppings(majorToppings);
        }

        public void AddMajorToppingsToHalf(ToppingWholeHalf whichHalf)
        {
            var majorToppings = new List<Topping>();
            majorToppings.Add(new Topping(ToppingName.Pepperoni, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Mushrooms, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Sausage, whichHalf));
            majorToppings.Add(new Topping(ToppingName.GreenPeppers, whichHalf));
            majorToppings.Add(new Topping(ToppingName.Onion, whichHalf)); ;
            majorToppings.Add(new Topping(ToppingName.BlackOlives, whichHalf));
            AddToppings(majorToppings);
        }

        public void ChangeMajorToppingsHalf(ToppingWholeHalf whichHalf)
        {
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == ToppingName.Pepperoni ||
                    topping.ToppingName == ToppingName.Mushrooms ||
                    topping.ToppingName == ToppingName.Sausage ||
                    topping.ToppingName == ToppingName.GreenPeppers ||
                    topping.ToppingName == ToppingName.Onion ||
                    topping.ToppingName == ToppingName.BlackOlives)
                {
                    topping.ToppingWholeHalf = whichHalf;
                }
            }
            ToppingsTotal = GetCurrentToppingsCost();
        }

        public static decimal GetDbItemId(ToppingName toppingName)
        {
            if (DataBaseDictionaries.ToppingDbIdDictionary.ContainsKey(toppingName))
            {
                return DataBaseDictionaries.ToppingDbIdDictionary[toppingName];
            }
            return 0;
        }

        

        #endregion
    }
}
