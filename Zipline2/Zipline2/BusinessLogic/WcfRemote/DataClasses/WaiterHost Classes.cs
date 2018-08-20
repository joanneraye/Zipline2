using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zipline2.BusinessLogic
{
    [DataContract]
    public class ManagerSettings
    {
        //whether or not order get sent to the kitchen right away
        //or if a waiter has to manually send them
        [DataMember]
        public bool AutoSendOrders { get; set; }
        /// <summary>
        /// Default Seat when going to Menu the first time.
        /// will equal 0 for whole table.
        /// </summary>
        [DataMember]
        public int DefaultSeat { get; set; }

        [DataMember]
        public Dictionary<TimeSpan, String> TakeoutEscalation { get; set; }

        //The increament in minutes for the Slider.
        [DataMember]
        public int SliderIncreaments { get; set; }
        [DataMember]
        public int SliderMin { get; set; }
        [DataMember]
        public int SliderMax { get; set; }

        //what the name of Combos appears as (Combo, Special, etc.)
        [DataMember]
        public string ComboName { get; set; }

        //whether or not to show a label with the following numbers
        [DataMember]
        public bool ShowTableNum { get; set; }
        [DataMember]
        public bool ShowGuestNum { get; set; }
        [DataMember]
        public bool ShowSeatNum { get; set; }

        // the font size of the labels reffered to above
        // let's restrict these to "Small", "Medium", "Large", 
        // so that we can use the built in Phone Font sizes
        [DataMember]
        public string TableFontSize { get; set; }
        [DataMember]
        public string GuestFontSize { get; set; }
        [DataMember]
        public string SeatFontSize { get; set; }

        [DataMember]
        public decimal TaxRate { get; set; }

        [DataMember]
        public List<string> CategoryOrder { get; set; }

		[DataMember]
		public Decimal MenuVersion { get; set; }

    }

    [DataContract]
    public class ItemInfo
    {
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public PictureFile Picture { get; set; }
    }

    [DataContract]
    public class PictureFile
    {
        [DataMember]
        public string PictureName { get; set; }

        [DataMember]
        public byte[] PictureStream { get; set; }
    }

    [DataContract]
    public partial class UserPOS
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PinNumber { get; set; }
        [DataMember]
        public decimal ID { get; set; }
        [DataMember]
        public decimal Section { get; set; }
    }

    [DataContract]
    public class SizeData
    {
        [DataMember]
        public decimal ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ReceiptName { get; set; }
        [DataMember]
        public decimal Price { get; set; }

        public SizeData() { }
        public SizeData(decimal SizeID, string iName, decimal iPrice) 
        {
            ID = SizeID;
            Name = iName;
            Price = iPrice;
        }

        public SizeData(decimal SizeID, string iName, string iReceiptName, decimal iPrice)
        {
            ReceiptName = iReceiptName;
            ID = SizeID;
            Name = iName;
            Price = iPrice;
        }
    }
}
