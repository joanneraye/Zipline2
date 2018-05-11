using System;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    //This class copied from Portable-POS Classes.  Used to format/integrate 
    //new phone apps with existing POS system.
    public class GuestModifier : DBModifier
    {
        //DBModifier fields:
        public decimal ID;

        [DataMember]
        public Decimal
            Multiplier = 1;
        [DataMember]
        public String 
            State="",
            Half="";
        [DataMember]
        public Boolean
            isDefault=false,
            SpecialCount=false;

		

        public GuestModifier() { }

        public GuestModifier(DBModifier iModifier)
        {
            ID = iModifier.ID;
            Name = iModifier.Name;
            BasePrice = iModifier.BasePrice;
            BaseCount = iModifier.BaseCount;
        }

        public GuestModifier(GuestModifier iModifier)
        {
            ID = iModifier.ID;
            Name = iModifier.Name;
            BasePrice = iModifier.BasePrice;
            BaseCount = iModifier.BaseCount;
            Multiplier = iModifier.Multiplier;
            State = iModifier.State;
            Half = iModifier.Half;
            SpecialCount = iModifier.SpecialCount;
            isDefault = iModifier.isDefault;
        }

        public Decimal Count
        {
            get
            {
                Decimal RV = 0;
                RV = ModifierHalfMultiplier * Multiplier * BaseCount;
                if (SpecialCount) RV = 0;
                return RV;
            }
        }

        public Decimal Price
        {
            get
            {
                Decimal RV = 0;
                if (State.ToUpper() != "NO")
                    RV = BasePrice * ModifierHalfMultiplier * Multiplier * BaseCount;
                return RV;
            }
        }

        public enum ModHalf
        {
            Whole = 0,
            Half_A = 1,
            Half_B = 2,
        }
        
        public enum ModState
        {
            Plus = 0,
            No = 1,
            Side = 2,
            Unsellected = 3,
            Light = 4,
        }

        private Decimal ModifierHalfMultiplier
        {
            get
            {
                Decimal RV = 0;
                if (Half == ModHalf.Whole.ToString()) RV = 1;
                if (Half == ModHalf.Half_A.ToString() || Half == ModHalf.Half_B.ToString()) RV = 0.5m;
                return RV;
            }
        }
    }
}
