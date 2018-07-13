using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;

namespace Zipline2.Models
{
    public class Calzone : OrderItem
    {
        public Calzone()
        {
            MessagingCenter.Subscribe<Toppings>(this, "ToppingsTotalUpdated",
            (sender) => { this.PopulatePricePerItem(); });
        }
        public MajorOrMama MajorMamaInfo { get; set; }
        private CalzoneType calzoneType;
        public CalzoneType CalzoneType
        {
            get
            {
                return calzoneType;
            }
            set
            {
                calzoneType = value;
                if (Toppings == null)
                {
                    Toppings = new CalzoneToppings(calzoneType, this);
                }
                else
                {
                    Toppings.CalzoneType = calzoneType;
                }
            }
        }
        CalzoneToppings Toppings { get; set; }
        public override List<GuestModifier> CreateMods()
        {
            throw new NotImplementedException();
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            if (CalzoneType == CalzoneType.RicottaMozarella)
            {
                return Tuple.Create<string, decimal>("Calzone", 51);
            }
            else if (CalzoneType == CalzoneType.HotRope)
            {
                return Tuple.Create<string, decimal>("Calzone", 52);
            }
            else if (CalzoneType == CalzoneType.PBJ)
            {
                return Tuple.Create<string, decimal>("Calzone", 53);
            }
            else if (CalzoneType == CalzoneType.SteakAndCheese)
            {
                return Tuple.Create<string, decimal>("Calzone", 54);
            }
            else if (CalzoneType == CalzoneType.Major)
            {
                return Tuple.Create<string, decimal>("Calzone", 56);
            }
            return Tuple.Create<string, decimal>("Calzone", 51);
        }

        public override void PopulateBasePrice()
        {
            BasePriceNoToppings = Prices.GetCalzoneBasePrice(CalzoneType);
        }

        public override void PopulateDisplayName()
        {
            ItemName = DisplayNames.GetCalzoneDisplayName(CalzoneType);
            if (MajorMamaInfo == MajorOrMama.Major)
            {
                ItemName += " - MAJOR";
            }
        }

        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = BasePriceNoToppings +
                Toppings.ToppingsTotal;
        }
    }
}
