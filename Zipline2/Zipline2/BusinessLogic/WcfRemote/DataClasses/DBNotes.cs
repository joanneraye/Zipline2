using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    public class DBNotes
    {
        public DBNotes()
        {
            ID = new List<Decimal>();
            Notes = new List<String>();
        }

        public String this[int Index] { get { return Notes[Index]; } }

        public int Count
        {
            get
            {
                int RV = 0;
                if (Notes != null) RV = Notes.Count;
                return RV;
            }
        }

        public void Add(String iNote)
        {
            Notes.Add(iNote);
        }

        public void AddRange(List<String> iNote)
        {
            Notes.AddRange(iNote);
        }

        /// <summary>
        /// Note ID this is to allow multiple Notes per Order/Check.
        /// this has one ID per line.
        /// to change a line edit the Notes.
        /// the corisponding Index for ID in Notes will be used.
        /// if ID empty or short new IDs will be created.
        /// if Too long IDs will be removed.
        /// </summary>
        [DataMember]
        public List<Decimal> ID;

        /// <summary>
        /// List of single line notes.
        /// </summary>
        [DataMember]
        public List<String> Notes;
    }
}
