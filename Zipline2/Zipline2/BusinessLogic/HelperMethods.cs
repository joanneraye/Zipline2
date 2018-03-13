using System;
using System.Collections.Generic;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.BusinessLogic
{
    public static class HelperMethods
    {

        //Can change this to helper class with different kinds of methods and 
        //change class name to be more generic.
        public static readonly decimal TaxMultiplier = 0.065M;

        
        public static decimal GetTaxAmount(decimal subTotal = 0)
        {
            return (subTotal * TaxMultiplier); 
        }

        
    }
}
