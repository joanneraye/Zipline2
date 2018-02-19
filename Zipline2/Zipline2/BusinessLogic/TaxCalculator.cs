using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.BusinessLogic
{
    public static class TaxCalculator
    {

        //Can change this to helper class with different kinds of methods and 
        //change class name to be more generic.
        public static readonly decimal TaxMultiplier = 0.065M;

        
        public static decimal GetTaxAmount(decimal subTotal)
        {
            return (subTotal * TaxMultiplier); 
        }
    }
}
