using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{ 
    [DataContract]
    public class DBItem
    {
        private Decimal
            dID,
            dSuperCategoryID,
            dSubCategoryID;

        private String
            sShortName,
            sLongName,
            sDescription,
            sSuperCategory,
            sSubCategoryName;

        private Boolean
            bAvailability,
            bCanBeHalf,
            bStackable;

        [DataMember]
        public Boolean HasRequiredMods { get; set; }
        [DataMember]
        public Boolean HasAllMods { get; set; }

        [DataMember]
        public Dictionary<decimal, SizeData> SizeTable = new Dictionary<decimal, SizeData>();
        [DataMember]
        public List<Tiered> TieredPricing;

        [DataMember]
        public bool NonTaxable { get; set; }

        public DBItem() { }

        public DBItem(Decimal iID, String iShortName, String iLongName)
        {
            dID = iID;
            sShortName = iShortName;
            sLongName = iLongName;
        }

        [DataMember]
        public String SelectCommand
        {
            get { return "SELECT [ItemID], [ShortName], [LongName], [SubCategoryID] FROM [SD_POS].[dbo].[tblItems] Where [ItemID] = '" + ID.ToString() + "' ORDER BY [ItemID]"; }
            set {  }
        }

        [DataMember]
        public decimal ID
        {
            get { return dID; }
            set { dID = value; }
        }

        [DataMember]
        public decimal SuperCategoryID
        {
            get { return dSuperCategoryID; }
            set { dSuperCategoryID = value; }
        }

        [DataMember]
        public string SuperCategory
        {
            get { return sSuperCategory; }
            set { sSuperCategory = value; }
        }

        [DataMember]
        public decimal SubCategoryID
        {
            get { return dSubCategoryID; }
            set { dSubCategoryID = value; }
        }

        [DataMember]
        public string SubCategoryName
        {
            get { return sSubCategoryName; }
            set { sSubCategoryName = value; }
        }

        [DataMember]
        public string Description
        {
            get { return sDescription; }
            set { sDescription = value; }
        }

        [DataMember]
        public bool Availability
        {
            get { return bAvailability; }
            set { bAvailability = value; }
        }

        [DataMember]
        public bool CanBeHalf
        {
            get { return bCanBeHalf; }
            set { bCanBeHalf = value; }
        }

        [DataMember]
        public bool Stackable
        {
            get { return bStackable; }
            set { bStackable = value; }
        }

        [DataMember]
        public String ShortName
        {
            get
            {
                return sShortName;
            }
            set
            {
                sShortName = value;
            }
        }

        [DataMember]
        public String LongName
        {
            get
            {
                return sLongName;
            }
            set
            {
                sLongName = value;
            }
        }
    }
}
