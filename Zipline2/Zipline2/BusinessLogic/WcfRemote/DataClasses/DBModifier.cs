using System;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    public class DBModifier
    {
        [DataMember]
        public Decimal
            ID;
        [DataMember]
        public int BaseCount { get; set; }
        private String
            sName;
        [DataMember]
        public Decimal BasePrice { get; set; }

		[DataMember]
		public Decimal Priority { get; set; }

        public DBModifier() { }

        public DBModifier(Decimal iID, String iName, Decimal iPrice)
        {
            ID = iID;
            sName = iName;
            BasePrice = iPrice;
            BaseCount = 1;
        }

        [DataMember]
        public String Name
        {
            get { return sName; }
            set { sName = value; }
        }

        public Decimal dPrice
        {
            get { return BasePrice * BaseCount; }
        }
    }
}
