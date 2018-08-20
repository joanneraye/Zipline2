using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    //This class copied from Portable-POS Classes.  Used to format/integrate 
    //new phone apps with existing POS system.
    public class Guest_DB
    {
        [DataMember]
        public Decimal ID { get; set; }
        [DataMember]
        public Decimal TableID { get; set; }
        [DataMember]
        public List<GuestItem> Items { get; set; }
        [DataMember]
        public List<GuestComboItem> ComboItems { get; set; }
        [DataMember]
        public Boolean CheckedOut { get; set; }
        [DataMember]
        public Boolean IsWhole { get; set; }

        public Guest_DB()
        {
            IsWhole = false;
        }
        
        public int GetComboIndex(Decimal OrderComboID)
        {
            int RV = -1;
            for (int Index = 0; Index < ComboItems.Count; Index++) if (ComboItems[Index].OrderComboID == OrderComboID) RV = Index;
            return RV;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iID"></param>
        /// <param name="iTableID"></param>
        /// <param name="iCheckedOut"></param>
        public Guest_DB(Decimal iID, Decimal iTableID, Boolean iCheckedOut)
        {
            ID = iID;
            TableID = iTableID;
            CheckedOut = iCheckedOut;
            Items = new List<GuestItem>();
            ComboItems = new List<GuestComboItem>();
            IsWhole = false;
        }

        public decimal SubTotal()
        {
            return 0;
        }
    }
}
