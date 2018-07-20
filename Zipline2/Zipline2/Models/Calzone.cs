﻿using System;
using System.Collections.Generic;
using System.Text;
using Staunch.POS.Classes;
using Xamarin.Forms;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Data;

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
            List<Topping> tempToppings = Toppings.CurrentToppings;

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
        }

        public override void PopulatePricePerItem()
        {
            PricePerItemIncludingToppings = BasePriceNoToppings +
                Toppings.ToppingsTotal;
        }
    }
}
