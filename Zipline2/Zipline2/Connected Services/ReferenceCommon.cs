using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Connected_Services
{
   
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "GuestComboItem", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        public partial class GuestComboItem : object, System.Runtime.Serialization.IExtensibleDataObject
        {

            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private decimal BasePriceField;

            private GuestItem[] ComboGuestItemsField;

            private decimal IDField;

            private string NameField;

            private decimal OrderComboIDField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal BasePrice
            {
                get
                {
                    return this.BasePriceField;
                }
                set
                {
                    this.BasePriceField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public GuestItem[] ComboGuestItems
            {
                get
                {
                    return this.ComboGuestItemsField;
                }
                set
                {
                    this.ComboGuestItemsField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ID
            {
                get
                {
                    return this.IDField;
                }
                set
                {
                    this.IDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Name
            {
                get
                {
                    return this.NameField;
                }
                set
                {
                    this.NameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal OrderComboID
            {
                get
                {
                    return this.OrderComboIDField;
                }
                set
                {
                    this.OrderComboIDField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "GuestItem", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        public partial class GuestItem : DBItem
        {

            private decimal BasePriceField;

            private GuestModifier[] DefaultModifiersField;

            private List<GuestModifier> ModsField;

            private List<string> NoteField;

            private decimal OrderIDField;

            private bool OrderSentField;

            private decimal PlateIDField;

            private decimal SelectSizeIDField;

            private GuestModifier[] SidesField;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal BasePrice
            {
                get
                {
                    return this.BasePriceField;
                }
                set
                {
                    this.BasePriceField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public GuestModifier[] DefaultModifiers
            {
                get
                {
                    return this.DefaultModifiersField;
                }
                set
                {
                    this.DefaultModifiersField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<GuestModifier> Mods
            {
                get
                {
                    return this.ModsField;
                }
                set
                {
                    this.ModsField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public List<string> Note
            {
                get
                {
                    return this.NoteField;
                }
                set
                {
                    this.NoteField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal OrderID
            {
                get
                {
                    return this.OrderIDField;
                }
                set
                {
                    this.OrderIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool OrderSent
            {
                get
                {
                    return this.OrderSentField;
                }
                set
                {
                    this.OrderSentField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal PlateID
            {
                get
                {
                    return this.PlateIDField;
                }
                set
                {
                    this.PlateIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal SelectSizeID
            {
                get
                {
                    return this.SelectSizeIDField;
                }
                set
                {
                    this.SelectSizeIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public GuestModifier[] Sides
            {
                get
                {
                    return this.SidesField;
                }
                set
                {
                    this.SidesField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "DBItem", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        [System.Runtime.Serialization.KnownTypeAttribute(typeof(ComboDBItem))]
        [System.Runtime.Serialization.KnownTypeAttribute(typeof(GuestItem))]
        public partial class DBItem : object, System.Runtime.Serialization.IExtensibleDataObject
        {

        public override string ToString()
        {
            Console.WriteLine("THIS IS DBITEM OBJECT VALUES***************************");
            Console.WriteLine("Availability is " + Availability.ToString());
            Console.WriteLine("HasAllMods is " + HasAllMods.ToString());
            Console.WriteLine("HasRequiredModsField is " + HasRequiredModsField.ToString());
            Console.WriteLine("ID is " + ID.ToString());
            Console.WriteLine("LongName is " + LongName.ToString());
            Console.WriteLine("NonTaxable is " + NonTaxable.ToString()); Console.WriteLine("IDField is " + IDField.ToString());
            Console.WriteLine("SelectCommand is " + SelectCommand.ToString());
            Console.WriteLine("ShortName is " + ShortName.ToString());
            Console.WriteLine("Stackable is " + Stackable.ToString());
            Console.WriteLine("SubCategoryID is " + SubCategoryID.ToString());
            Console.WriteLine("SubCategoryName is " + SubCategoryName.ToString());
            Console.WriteLine("SuperCategoryID is " + SuperCategoryID.ToString());
            Console.WriteLine("SuperCategory is " + SuperCategory.ToString());
            Console.WriteLine("SIZETABLE:");
            if (SizeTable == null)
            {
                Console.WriteLine("SizeTable is null");
            }
            else
            {
                foreach (var item in SizeTable)
                {
                    Console.WriteLine("Key is " + item.Key.ToString());
                    Console.Write("SizeData object is " + item.Value.Name);
                    Console.WriteLine("   : " + item.Value.Price.ToString());
                }
            }
         
            if (TieredPricingField == null)
            {
                Console.WriteLine("TieredPricingField is null");
            }
            else
            {
                foreach (var tiered in TieredPricingField)
                {
                    Console.Write("Tier " + tiered.Size);
                    Console.WriteLine("  " + tiered.PriceAdjustment);
                }
            }
           

            Console.WriteLine("END OF DBITEM***************************");


            return base.ToString();
        }

        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private bool AvailabilityField;

            private bool CanBeHalfField;

            private string DescriptionField;

            private bool HasAllModsField;

            private bool HasRequiredModsField;

            private decimal IDField;

            private string LongNameField;

            private bool NonTaxableField;

            private string SelectCommandField;

            private string ShortNameField;

            private System.Collections.Generic.Dictionary<decimal, SizeData> SizeTableField;

            private bool StackableField;

            private decimal SubCategoryIDField;

            private string SubCategoryNameField;

            private string SuperCategoryField;

            private decimal SuperCategoryIDField;

            private Tiered[] TieredPricingField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool Availability
            {
                get
                {
                    return this.AvailabilityField;
                }
                set
                {
                    this.AvailabilityField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool CanBeHalf
            {
                get
                {
                    return this.CanBeHalfField;
                }
                set
                {
                    this.CanBeHalfField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Description
            {
                get
                {
                    return this.DescriptionField;
                }
                set
                {
                    this.DescriptionField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool HasAllMods
            {
                get
                {
                    return this.HasAllModsField;
                }
                set
                {
                    this.HasAllModsField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool HasRequiredMods
            {
                get
                {
                    return this.HasRequiredModsField;
                }
                set
                {
                    this.HasRequiredModsField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ID
            {
                get
                {
                    return this.IDField;
                }
                set
                {
                    this.IDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string LongName
            {
                get
                {
                    return this.LongNameField;
                }
                set
                {
                    this.LongNameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool NonTaxable
            {
                get
                {
                    return this.NonTaxableField;
                }
                set
                {
                    this.NonTaxableField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string SelectCommand
            {
                get
                {
                    return this.SelectCommandField;
                }
                set
                {
                    this.SelectCommandField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string ShortName
            {
                get
                {
                    return this.ShortNameField;
                }
                set
                {
                    this.ShortNameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public System.Collections.Generic.Dictionary<decimal, SizeData> SizeTable
            {
                get
                {
                    return this.SizeTableField;
                }
                set
                {
                    this.SizeTableField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool Stackable
            {
                get
                {
                    return this.StackableField;
                }
                set
                {
                    this.StackableField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal SubCategoryID
            {
                get
                {
                    return this.SubCategoryIDField;
                }
                set
                {
                    this.SubCategoryIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string SubCategoryName
            {
                get
                {
                    return this.SubCategoryNameField;
                }
                set
                {
                    this.SubCategoryNameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string SuperCategory
            {
                get
                {
                    return this.SuperCategoryField;
                }
                set
                {
                    this.SuperCategoryField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal SuperCategoryID
            {
                get
                {
                    return this.SuperCategoryIDField;
                }
                set
                {
                    this.SuperCategoryIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public Tiered[] TieredPricing
            {
                get
                {
                    return this.TieredPricingField;
                }
                set
                {
                    this.TieredPricingField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "SizeData", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        public partial class SizeData : object, System.Runtime.Serialization.IExtensibleDataObject
        {

            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private decimal IDField;

            private string NameField;

            private decimal PriceField;

            private string ReceiptNameField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ID
            {
                get
                {
                    return this.IDField;
                }
                set
                {
                    this.IDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Name
            {
                get
                {
                    return this.NameField;
                }
                set
                {
                    this.NameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal Price
            {
                get
                {
                    return this.PriceField;
                }
                set
                {
                    this.PriceField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string ReceiptName
            {
                get
                {
                    return this.ReceiptNameField;
                }
                set
                {
                    this.ReceiptNameField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "Tiered", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        public partial class Tiered : object, System.Runtime.Serialization.IExtensibleDataObject
        {

            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private decimal ModifierCountField;

            private decimal ModifierTierIDField;

            private decimal PriceAdjustmentField;

            private decimal SizeField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ModifierCount
            {
                get
                {
                    return this.ModifierCountField;
                }
                set
                {
                    this.ModifierCountField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ModifierTierID
            {
                get
                {
                    return this.ModifierTierIDField;
                }
                set
                {
                    this.ModifierTierIDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal PriceAdjustment
            {
                get
                {
                    return this.PriceAdjustmentField;
                }
                set
                {
                    this.PriceAdjustmentField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal Size
            {
                get
                {
                    return this.SizeField;
                }
                set
                {
                    this.SizeField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "GuestModifier", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        public partial class GuestModifier : DBModifier
        {

            private string HalfField;

            private decimal MultiplierField;

            private bool SpecialCountField;

            private string StateField;

            private bool isDefaultField;

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Half
            {
                get
                {
                    return this.HalfField;
                }
                set
                {
                    this.HalfField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal Multiplier
            {
                get
                {
                    return this.MultiplierField;
                }
                set
                {
                    this.MultiplierField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool SpecialCount
            {
                get
                {
                    return this.SpecialCountField;
                }
                set
                {
                    this.SpecialCountField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string State
            {
                get
                {
                    return this.StateField;
                }
                set
                {
                    this.StateField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public bool isDefault
            {
                get
                {
                    return this.isDefaultField;
                }
                set
                {
                    this.isDefaultField = value;
                }
            }
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
        [System.Runtime.Serialization.DataContractAttribute(Name = "DBModifier", Namespace = "http://schemas.datacontract.org/2004/07/Staunch.POS.Classes")]
        [System.Runtime.Serialization.KnownTypeAttribute(typeof(GuestModifier))]
        public partial class DBModifier : object, System.Runtime.Serialization.IExtensibleDataObject
        {

            private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

            private int BaseCountField;

            private decimal BasePriceField;

            private decimal IDField;

            private string NameField;

            private decimal PriorityField;

            public System.Runtime.Serialization.ExtensionDataObject ExtensionData
            {
                get
                {
                    return this.extensionDataField;
                }
                set
                {
                    this.extensionDataField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public int BaseCount
            {
                get
                {
                    return this.BaseCountField;
                }
                set
                {
                    this.BaseCountField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal BasePrice
            {
                get
                {
                    return this.BasePriceField;
                }
                set
                {
                    this.BasePriceField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal ID
            {
                get
                {
                    return this.IDField;
                }
                set
                {
                    this.IDField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public string Name
            {
                get
                {
                    return this.NameField;
                }
                set
                {
                    this.NameField = value;
                }
            }

            [System.Runtime.Serialization.DataMemberAttribute()]
            public decimal Priority
            {
                get
                {
                    return this.PriorityField;
                }
                set
                {
                    this.PriorityField = value;
                }
            }
        }
}
