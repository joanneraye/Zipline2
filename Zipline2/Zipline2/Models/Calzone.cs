using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Data;
using Zipline2.PageModels;

namespace Zipline2.Models
{
    public class Calzone : OrderItem
    {
        public Calzone()
        {
            //MessagingCenter.Subscribe<CalzoneToppings>(this, "CalzoneToppingsTotalUpdated",
            //(sender) => { this.PopulatePricePerItem(); });
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
        public CalzoneToppings Toppings { get; set; }
        public override List<GuestModifier> CreateMods()
        {
            //if the toppings are just major toppings and designated as major, then 
            //don't add toppings. 
            List<Topping> tempToppings = new List<Topping>();

            bool hasOnion = false;
            bool hasGreenPeppers = false;
            bool hasPepperoni = false;
            bool hasSausage = false;
            bool hasMushrooms = false;
            bool hasBlackOlives = false;

            if (MajorMamaInfo == MajorOrMama.Major)
            {
                foreach (var topping in Toppings.CurrentToppings)
                {
                    if (topping.ToppingName == ToppingName.Onion)
                    {
                        hasOnion = true;
                    }
                    else if (topping.ToppingName == ToppingName.GreenPeppers)
                    {
                        hasGreenPeppers = true;
                    }
                    else if (topping.ToppingName == ToppingName.Pepperoni)
                    {
                        hasPepperoni = true;
                    }
                    else if (topping.ToppingName == ToppingName.Sausage)
                    {
                        hasSausage = true;
                    }
                    else if (topping.ToppingName == ToppingName.Mushrooms)
                    {
                        hasMushrooms = true;
                    }
                    else if (topping.ToppingName == ToppingName.BlackOlives)
                    {
                        hasBlackOlives = true;
                    }
                    else
                    {
                        tempToppings.Add(topping);
                    }
                }
            }

            List<GuestModifier> mods = DataConversion.GetDbMods(tempToppings);

            if (MajorMamaInfo == MajorOrMama.Major)
            {
                if (!hasOnion)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Onion)));
                }
                if (!hasGreenPeppers)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.GreenPeppers)));
                }
                if (!hasBlackOlives)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.BlackOlives)));
                }
                if (!hasPepperoni)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Pepperoni)));
                }
                if (!hasSausage)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Sausage)));
                }
                if (!hasMushrooms)
                {
                    mods.Add(DataConversion.GetNoMod(new Topping(ToppingName.Mushrooms)));
                }
            }

            return mods;
        }

        public override Tuple<string, decimal> GetMenuDbItemKeys()
        {
            if (CalzoneType == CalzoneType.Cheese)
            {
                if (MajorMamaInfo == MajorOrMama.Major)
                {
                    return Tuple.Create<string, decimal>("Calzone", 56);
                }
                else
                {
                    return Tuple.Create<string, decimal>("Calzone", 51);
                }
                
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

        public void ChangeCalzoneToSteakAndCheese()
        {
            if (CalzoneType == CalzoneType.Cheese)
            {
                CalzoneType = CalzoneType.SteakAndCheese;
            }
            PopulateBasePrice();
            PopulateDisplayName();
            Toppings.UpdateToppingsTotal();
        }

        public void ChangeCalzoneFromSteakToRegular()
        {
            if (CalzoneType == CalzoneType.SteakAndCheese)
            {
                CalzoneType = CalzoneType.Cheese;
            }
            PopulateBasePrice();
            PopulateDisplayName();
            Toppings.UpdateToppingsTotal();
        }


        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = BasePriceNoToppings +
                Toppings.ToppingsTotal;
        }

        public override OrderDisplayItem PopulateOrderDisplayItem()
        {
            var orderDisplayItem = base.PopulateOrderDisplayItem();
            var toppingsString = new StringBuilder();
            bool toppingNotDisplayed = true;
            for (int i = 0; i < Toppings.CurrentToppings.Count; i++)
            {
                if (Toppings.CurrentToppings[i].ToppingName == ToppingName.SteakNCheeseCalzone ||
                    Toppings.CurrentToppings[i].ToppingName == ToppingName.Major)
                {
                    toppingNotDisplayed = false;
                    continue;
                }
                if (i == 0 || !toppingNotDisplayed)
                {
                    toppingsString.Append("   ");
                    toppingNotDisplayed = true;
                }
                else
                {
                    toppingsString.Append("\n   ");
                }
               
                toppingsString.Append(Toppings.CurrentToppings[i].ToppingDisplayName);
            }

            if (toppingsString.Length != 0)
            {
                orderDisplayItem.Toppings = toppingsString.ToString();
                orderDisplayItem.HasToppings = true;
            }
            return orderDisplayItem;
        }
    }
}
