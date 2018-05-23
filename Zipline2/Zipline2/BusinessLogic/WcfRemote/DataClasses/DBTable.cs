using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    //This class copied from Portable-POS Classes.  Used to format/integrate 
    //new phone apps with existing POS system.
    public class DBTable
    {
        private Decimal
            dID,
            dStandardSize,
            dMaxSize;
        private String
            sShape,
            sName;
        private Boolean
            bisMain,
            bisSub;
        private List<decimal> lSections;

        [DataMember]
        public Boolean IsClear { get; set; }
        [DataMember]
        public List<int> JoinedTableIDs { get; set; }
        [DataMember]
        public bool Joined { get; set; }
        [DataMember]
        public bool IsSplit { get; set; }
        [DataMember]
        public List<decimal> SplitTableIDs { get; set; }
        [DataMember]
        public List<Guest_DB> Guests { get; set; }

        public DBTable() { }

        public DBTable(Decimal iID, String iShape, Decimal iStandarSize, Decimal iMaxSize, Boolean iIsMain, Boolean iIsSub)
        {
            dID = iID;
            sShape = iShape;
            dStandardSize = iStandarSize;
            dMaxSize = iMaxSize;
            bisMain = iIsMain;
            bisSub = iIsSub;
        }

        public Boolean CanBeSplit
        {
            get
            {
                Boolean RV = false;
                if (bisMain && !IsSplit)
                        if (SplitTableIDs != null)
                            if (SplitTableIDs.Count > 0) RV = true;
                return RV;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                if (sName == null || sName == "")
                    return ("Table " + (int)dID);
                else
                    return sName;
            }
            set
            {
                sName = value;
                // update DB
            }
        }

        [DataMember]
        public Boolean IsMain
        {
            get
            {
                return bisMain;
            }
            set
            {
                bisMain = value;
                // update DB.
            }
        }

        [DataMember]
        public Boolean IsSub
        {
            get
            {
                return bisSub;
            }
            set
            {
                bisSub = value;
                // update DB.
            }
        }

        [DataMember]
        public Decimal ID
        {
            get
            {
                return dID;
            }
            set
            {
                dID = value;
                // update DB.
            }
        }

        [DataMember]
        public Decimal MaxSize
        {
            get
            {
                return dMaxSize;
            }
            set
            {
                dMaxSize = value;
                // update DB.
            }
        }

        [DataMember]
        public Decimal StandardSize
        {
            get
            {
                return dStandardSize;
            }
            set
            {
                dStandardSize = value;
                // update DB.
            }
        }

        [DataMember]
        public String Shape
        {
            get
            {
                return sShape;
            }
            set
            {
                sShape = value;
                // update DB.
            }
        }

        [DataMember]
        public List<decimal> Sections
        {
            get { return lSections; }
            set { lSections = value; /*update DB */ }
        }
    }
}
