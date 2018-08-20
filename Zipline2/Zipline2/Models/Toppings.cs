using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;

namespace Zipline2.Models
{
    /// <summary>
    /// A Toppings class object should always be contained in a Salad
    /// or Pizza class.
    public abstract class Toppings
    {
        #region Properties
                
        public List<Topping> CurrentToppings { get; set; }
      
        private decimal toppingsTotal;
        public decimal ToppingsTotal
        {
            get
            {
                return toppingsTotal;
            }
            set
            {
                toppingsTotal = value;                
            }
        }
        

        #endregion

        #region constructor

        /// <summary>
        /// Toppings should always be associated with a particular pizza already chosen.
        /// </summary>
        /// <param name="pizzaWithTheseToppings"></param>
        public Toppings()
        {
            CurrentToppings = new List<Topping>();
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
        public virtual void UpdateToppingsTotal()
        {
            try
            {
                ToppingsTotal = GetCurrentToppingsCost();
                if (ToppingsTotal < 0)
                {
                    ToppingsTotal = 0;
                }
            }
            catch (Exception ex)
            {
                var whatsthis = ex.InnerException;
                throw;
            }
           
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
            CurrentToppings.Add(toppingToAdd.GetClone());
            if (calculateTotal)
            {
                CheckForMajor();
                UpdateToppingsTotal();
            }
        }

        public abstract void CheckForMajor();

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
                if (calculateTotal)
                {
                    CheckForMajor();
                    UpdateToppingsTotal();
                }
            } 
        }

        public bool IsToppingAlreadyAdded(ToppingName toppingName)
        {
            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == toppingName)
                {
                    return true;
                }
            }
            return false;
        }


        public void RemoveToppings(List<ToppingName> toppingNames)
        {
            foreach (var toppingName in toppingNames)
            {
                RemoveTopping(toppingName, false);
            }
            UpdateToppingsTotal();
        }

        protected abstract decimal GetCurrentToppingsCost();

        public static decimal GetDbItemId(ToppingName toppingName)
        {
            if (DataBaseDictionaries.ToppingDbIdDictionary.ContainsKey(toppingName))
            {
                return DataBaseDictionaries.ToppingDbIdDictionary[toppingName];
            }
            Console.WriteLine("***Debug JOANNE***TOPPINGS DICTIONARY ITEM NOT FOUND: " + toppingName);
            return 0;
        }

        public bool IsMajorToppings()
        {
            bool hasOnion = false;
            bool hasGreenPeppers = false;
            bool hasPepperoni = false;
            bool hasSausage = false;
            bool hasMushrooms = false;
            bool hasBlackOlives = false;

            foreach (var topping in CurrentToppings)
            {
                if (topping.ToppingName == ToppingName.Onion)
                {
                    hasOnion = true;
                }
                else if (topping.ToppingName == ToppingName.GreenPeppers)
                {
                    hasGreenPeppers = true;
                }
                else if (topping.ToppingName == ToppingName.Pepperoni)
                {
                    hasPepperoni = true;
                }
                else if (topping.ToppingName == ToppingName.Sausage)
                {
                    hasSausage = true;
                }
                else if (topping.ToppingName == ToppingName.Mushrooms)
                {
                    hasMushrooms = true;
                }
                else if (topping.ToppingName == ToppingName.BlackOlives)
                {
                    hasBlackOlives = true;
                }
                else
                {
                    return false;
                }
            }
            if (hasBlackOlives &&
                   hasOnion &&
                   hasGreenPeppers &&
                   hasPepperoni &&
                   hasSausage &&
                   hasMushrooms)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreToppingsTheSame(List<Topping> otherToppingsToCompare)
        {
            if (CurrentToppings.Count != otherToppingsToCompare.Count)
            {
                return false;
            }
            foreach (var topping in CurrentToppings)
            {
                var toppingFound = false;
                foreach (var compareTopping in otherToppingsToCompare)
                {
                    if (compareTopping.ToppingName == topping.ToppingName &&
                        compareTopping.ToppingModifier == topping.ToppingModifier &&
                        compareTopping.ToppingWholeHalf == topping.ToppingWholeHalf)
                    {
                        toppingFound = true;
                        break;
                    }
                }
                if (!toppingFound)
                {
                    return false;
                }
            }

            foreach (var compareTopping2 in otherToppingsToCompare)
            {
                var toppingFound = false;
                foreach (var topping2 in CurrentToppings)
                {
                    if (compareTopping2.ToppingName == topping2.ToppingName &&
                       compareTopping2.ToppingModifier == topping2.ToppingModifier &&
                       compareTopping2.ToppingWholeHalf == topping2.ToppingWholeHalf)
                    {
                        toppingFound = true;
                        break;
                    }
                }
                if (!toppingFound)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
