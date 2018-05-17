using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    public class Tiered
    {
        [DataMember]
        public Decimal ModifierTierID;
        [DataMember]
        public Decimal Size;
        [DataMember]
        public Decimal ModifierCount;
        [DataMember]
        public Decimal PriceAdjustment;

        public Tiered(Decimal iSizeID, Decimal iModifierCount, Decimal iPriceAdjustment)
        {
            Size = iSizeID;
            ModifierCount = iModifierCount;
            PriceAdjustment = iPriceAdjustment;
        }

        public Tiered(Decimal iModifierTierID, Decimal iSizeID, Decimal iModifierCount, Decimal iPriceAdjustment)
        {
            ModifierTierID = iModifierTierID;
            Size = iSizeID;
            ModifierCount = iModifierCount;
            PriceAdjustment = iPriceAdjustment;
        }
    }
}
