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
	public class DBCheck
	{
		[DataMember]
		public List<GuestItem> Items { get; set; }
		[DataMember]
		public List<GuestComboItem> ComboItems { get; set; }
		[DataMember]
		public List<Decimal> GuestIDs { get; set; }
		[DataMember]
		public Decimal ID { get; set; }
		[DataMember]
		public Boolean IsPaidFor { get; set; }

		
		
		//[DataMember]
		//public Decimal NonTaxable { get; set; }
		[DataMember]
		public Decimal AmountPaid { get; set; }
		[DataMember]
		public Decimal Gratuity { get; set; }
		[DataMember]
		public List<OrderDiscount> Discounts { get; set; }
		[DataMember]
		public DBNotes Notes { get; set; }

		[DataMember]
		public Decimal _tax;

		[DataMember]
		public Decimal ChangeDue { get; set; }

		[DataMember]
		public DateTime LastPaymentDate { get; set; }

		[DataMember]
		public String Name { get; set; }

		public Decimal TaxPayed { get; set; }

		public DBCheck()
		{
			Items = new List<GuestItem>();
			ComboItems = new List<GuestComboItem>();
			GuestIDs = new List<decimal>();
			ID = -1;
			IsPaidFor = false;
			//SubTotal = 0;
			_tax = 0;
			Gratuity = 0;
			Discounts = new List<OrderDiscount>();
			ChangeDue = 0;
			AmountPaid = 0;
			TaxPayed = 0;
		}

		public DBCheck(decimal id, Boolean isPaidFor = false)
		{
			Items = new List<GuestItem>();
			ComboItems = new List<GuestComboItem>();
			GuestIDs = new List<decimal>();
			ID = id;
			IsPaidFor = isPaidFor;
		   // SubTotal = 0;
			_tax = 0;
			Gratuity = 0;
			Discounts = new List<OrderDiscount>();
			ChangeDue = 0;
			AmountPaid = 0;
			TaxPayed = 0;
		}

		public DBCheck( decimal id, Boolean isPaidFor, 
			List<GuestItem> items, List<GuestComboItem> combos, 
			List<decimal> guestIDs, decimal subTotal, decimal tax, decimal gratuity, List<OrderDiscount> discounts, decimal changeDue )
		{
			Items = items;
			ComboItems = combos;
			GuestIDs = guestIDs;
			ID = id;
			IsPaidFor = isPaidFor;
			//SubTotal = subTotal;
			_tax = tax;
			Gratuity = gratuity;
			Discounts = discounts;
			ChangeDue = changeDue;
			AmountPaid = 0;
			TaxPayed = 0;
		}

		public decimal Tax
		{
			get
			{
				return _tax;//Math.Round( SubTotal * _tax, 2 );
			}
			set
			{
				_tax = value;
			}
		}

		public Decimal SubTotal
		{
			get
			{
				decimal RV = 0m;
				foreach ( GuestItem item in Items )
					RV += item.Price;
				foreach (GuestComboItem combo in ComboItems)
					RV += combo.Price;
				return RV.Round(2, MidpointRounding.AwayFromZero);
			}
		}

		[DataMember]
		public decimal OrderTax { get; set; }


		public Decimal TotalPrice
		{
			get
			{
				Decimal RV = SubTotal + /*NonTaxable +*/ OrderTax + Gratuity;
				//foreach ( OrderDiscount disco in Discounts )
				//	RV += disco.Amount;
				return RV.Round(2, MidpointRounding.AwayFromZero);//Math.Round( RV, 2 );
			}
			
		}

		public Decimal AmountDue
		{
			get
			{
				return (TotalPrice - AmountPaid).Round(2, MidpointRounding.AwayFromZero); //Math.Round( TotalPrice - AmountPaid, 2 );
			}
		}

		

	}

	//[DataContract]
	//public class Discount
	//{
	//    [DataMember]
	//    public String Name { get; set; }
	//    [DataMember]
	//    public Decimal Amount { get; set; }
	//}



	[DataContract]
	public class OrderDiscount
	{
		[DataMember]
		public Decimal ID { get; set; }
		[DataMember]
		public String Type { get; set; }
		[DataMember]
		public String Reason { get; set; }
		[DataMember]
		public Decimal Amount { get; set; }
		[DataMember]
		public Decimal UserID { get; set; }
		[DataMember]
		public Decimal OrderID { get; set; }
		[DataMember]
		public Decimal CheckID { get; set; }
		[DataMember]
		public DateTime DTG { get; set; }
	}

	public enum MidpointRounding
	{
		ToEven,
		AwayFromZero
	}

	public static class MathExt
	{
		public static Decimal Round(this Decimal d, MidpointRounding mode)
		{
			return d.Round(0, mode);
		}

		/// <summary>
		/// Rounds using arithmetic (5 rounds up) symmetrical (up is away from zero) rounding
		/// </summary>
		/// <param name="d">A Decimal number to be rounded.</param>
		/// <param name="decimals">The number of significant fractional digits (precision) in the return value.</param>
		/// <returns>The number nearest d with precision equal to decimals. If d is halfway between two numbers, then the nearest whole number away from zero is returned.</returns>
		public static Decimal Round(this Decimal d, Int32 decimals, MidpointRounding mode)
		{
			if (mode == MidpointRounding.ToEven)
			{
				return Decimal.Round(d, decimals);
			}
			else
			{
				Decimal factor = Convert.ToDecimal(Math.Pow(10, decimals));
				Int32 sign = Math.Sign(d);
				return Decimal.Truncate(d * factor + 0.5m * sign) / factor;
			}
		}
	}
}
