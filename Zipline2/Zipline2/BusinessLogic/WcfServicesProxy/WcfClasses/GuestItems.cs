using System;
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace Zipline2.BusinessLogic
{
	[DataContract]
    //This class copied from Portable-POS Classes.  Used to format/integrate 
    //new phone apps with existing POS system.
    public class GuestItem : DBItem
	{
       
        [DataMember]
		public List<GuestModifier> Mods;
		[DataMember]
		public List<GuestModifier> Sides;

		[DataMember]
		public List<GuestModifier> DefaultModifiers = new List<GuestModifier>();

		[DataMember]
		public Decimal
			OrderID,
			SelectSizeID,
			BasePrice,
			PlateID;
			//CatagoryID;

		[DataMember]
		public List<String> Note { get; set; }

		[DataMember]
		public bool OrderSent { get; set; }

		public GuestItem() { }

		public Decimal Price
		{
			get
			{
				Decimal RV = BasePrice;
				if (Mods != null)
				{
					List<Decimal> NoModifiers = new List<Decimal>();
					List<GuestModifier> SideMods = new List<GuestModifier>();
					foreach (GuestModifier nextMod in Mods)
					{
						if (nextMod.State.ToUpper() == "NO")
						{
							NoModifiers.Add(nextMod.ID);
							if (nextMod.Half != GuestModifier.ModHalf.Whole.ToString())
							{
								GuestModifier temp = new GuestModifier(nextMod);
								temp.State = GuestModifier.ModState.Plus.ToString();
								RV += temp.Price;
							}
						}
						if (nextMod.State.ToUpper() == "SIDE")
						{
						   // SideMods.Add(nextMod);
							//see if the sideMod is in DefaultModifiers
							bool isDefault = false;
							foreach (GuestModifier defMod in DefaultModifiers)
								if (defMod.ID == nextMod.ID)
								{
									isDefault = true;
									break;
								}
							//if it is, subtract 1 from the SideMod's multiplier and then add sideMod.Price to RV
							if (isDefault)
							{
								nextMod.Multiplier -= 1;
								if (nextMod.Price > 0)
									RV += nextMod.Price;
								nextMod.Multiplier += 1;
							}
							else
								RV += nextMod.Price;
						}
						else
							RV += nextMod.Price;
						
					}
					foreach (GuestModifier nextMod in DefaultModifiers)
					{
						Boolean isNo = false;
						foreach (Decimal testID in NoModifiers)
							if (nextMod.ID == testID)
							{
								isNo = true;
								break;
							}
						if (!isNo) RV += nextMod.Price;
					}


					RV += TieredPriceAdjustment;
				}
				return RV.Round(2, MidpointRounding.AwayFromZero);//Math.Round(RV, 2);
			}
		}

		public Decimal TieredPriceAdjustment
		{
			get
			{
				Decimal RV = 0;
				if (TieredPricing != null)
				{
					Decimal mCount = ModCount;
					foreach (Tiered nextTier in TieredPricing)
						if (nextTier.Size == SelectSizeID)
							if (mCount >= nextTier.ModifierCount) RV += nextTier.PriceAdjustment;
				}
				return RV.Round(2, MidpointRounding.AwayFromZero);
			}
		}

		public Decimal ModCount
		{
			get
			{
				Decimal RV = 0;
				if (Mods != null)
				{
					List<GuestModifier> NoModifiers = new List<GuestModifier>();
					foreach (GuestModifier nextMod in Mods)
					{
						if (nextMod.State.ToUpper() == "NO")
							NoModifiers.Add(nextMod);
						else
							RV += nextMod.Count;
					}
					foreach (GuestModifier nextMod in DefaultModifiers)
					{
						Boolean isNo = false;
						foreach (GuestModifier noMod in NoModifiers)
						{
							if (nextMod.ID == noMod.ID)
							{
								isNo = true;
								if (noMod.Half.ToUpper() != "WHOLE")
									RV += noMod.Count;
								break;
							}
						}
						if (!isNo) 
								RV += nextMod.Count;
						}
					}
				return RV;
			}
		}

		public GuestItem(Decimal iID, String iShortName, String iLongName)
		{
			ID = iID;
			ShortName = iShortName;
			LongName = iLongName;
		}

		public GuestItem(DBItem newItem)
		{
            base.ID = newItem.ID;
            base.ShortName = newItem.ShortName;
            base.LongName = newItem.LongName;
			base.SuperCategory = newItem.SuperCategory;
			base.SuperCategoryID = newItem.SuperCategoryID;
			base.SubCategoryID = newItem.SubCategoryID;
			base.Description = newItem.Description;
			base.Availability = newItem.Availability;
			base.CanBeHalf = newItem.CanBeHalf;
			base.SizeTable = newItem.SizeTable;
			base.HasAllMods = newItem.HasAllMods;
			base.HasRequiredMods = newItem.HasRequiredMods;
			base.TieredPricing = newItem.TieredPricing;
			base.NonTaxable = newItem.NonTaxable;
		}
	}
}
