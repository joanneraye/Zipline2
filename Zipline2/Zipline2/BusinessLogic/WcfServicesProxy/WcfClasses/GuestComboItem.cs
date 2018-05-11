using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    //This class copied from Portable-POS Classes.  Used to format/integrate 
    //new phone apps with existing POS system.
    public class GuestComboItem
    {
        [DataMember]
        public List<GuestItem> ComboGuestItems { get; set; }

        [DataMember]
        public decimal ID { get; set; }
        [DataMember]
        public decimal OrderComboID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public decimal BasePrice { get; set; }

        public GuestComboItem()
        {
            ID = -1;
            OrderComboID = -1;
        }

        public Decimal Price
        {
            get
            {
                Decimal RV = BasePrice;
                if (ComboGuestItems != null)
                    foreach (GuestItem nextItem in ComboGuestItems) RV += nextItem.Price;
                return RV;
            }
        }
    }
}
