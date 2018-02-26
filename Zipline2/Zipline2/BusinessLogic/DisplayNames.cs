using System;
using System.Collections.Generic;
using Zipline2.BusinessLogic.DictionaryKeys;
using System.Text;

namespace Zipline2.BusinessLogic
{
    public static class DisplayNames
    {
        public static Dictionary<string, string> DisplayNameDictionary = new Dictionary<string, string>
        {
            { Key.PIZZA_SLICE, "Pizza Slice" },
            { Key.PIZZA_MEDIUM, "Medium Pizza" },
            { Key.PIZZA_LARGE, "Large Pizza" },
            { Key.CALZONE, "Calzone" },
            { Key.PIZZA_SATCHPAN, "Satch-Pan" },
            { Key.PIZZA_MFP, "Millet Flax Pizza" },
            { Key.PIZZA_INDY, "Indy Pizza" }
        };
    }
}
