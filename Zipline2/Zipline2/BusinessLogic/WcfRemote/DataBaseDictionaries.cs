using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.BusinessLogic.WcfRemote
{
    public static class DataBaseDictionaries
    {
        public static Dictionary<string, DBItem[]> MenuDictionary { get; set; }

        public static Dictionary<decimal, DBModifier> PizzaToppingsDictionary { get; set; }
    }
}
