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
                MessagingCenter.Send<Toppings>(this, "ToppingsTotalUpdated");
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
            ToppingsTotal = GetCurrentToppingsCost();
            if (ToppingsTotal < 0)
            {
                ToppingsTotal = 0;
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

        

        #endregion
    }
}
