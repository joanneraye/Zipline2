using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Zipline2.Views;

namespace Zipline2.PageModels
{
    public class ToppingsPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class ToppingSelection : BasePageModel
        {
            #region Private Variables
            private ToppingsPageModel parentToppingsPageModel;
            private bool areWholeHalfColumnsVisible;
            private bool listItemIsSelected = false;
            private Color selectionColor;
            private Color acolor;
            private Color bcolor;
            private Color wcolor;
            private Color wButtonTextColor;
            #endregion

            #region Command Variables
            
            public System.Windows.Input.ICommand AButtonCommand { get; set; }
            public System.Windows.Input.ICommand BButtonCommand { get; set; }
            public System.Windows.Input.ICommand WButtonCommand { get; set; }
            #endregion

            #region Properties
            public Topping ListTopping { get; set; }

            public int SelectionIndex;

            public bool AreWholeHalfColumnsVisible
            {
                get
                {
                    return areWholeHalfColumnsVisible;
                }
                set
                {
                    SetProperty(ref areWholeHalfColumnsVisible, value);
                }
            }

            public bool ListItemIsSelected
            {
                get
                {
                    return listItemIsSelected;
                }
                set
                {
                    SetProperty(ref listItemIsSelected, value);
                }
            }

            public Color SelectionColor
            {
                get
                {
                    return selectionColor;
                }
                set
                {
                    SetProperty(ref selectionColor, value);
                }
            }
            private bool buttonASelected;
            public bool ButtonASelected
            {
                get
                {
                    return buttonASelected;
                }
                set
                {
                    SetProperty(ref buttonASelected, value);
                }
            }

            //public Color AColor
            //{
            //    get
            //    {
            //        return acolor;
            //    }
            //    set
            //    {
            //        SetProperty(ref acolor, value);
            //    }
            //}

            public Color BColor
            {
                get
                {
                    return bcolor;
                }
                set
                {
                    SetProperty(ref bcolor, value);
                }
            }

            public Color WColor
            {
                get
                {
                    return wcolor;
                }
                set
                {
                    SetProperty(ref wcolor, value);
                }
            }

            public Color WButtonTextColor
            {
                get
                {
                    return wButtonTextColor;
                }
                set
                {
                    SetProperty(ref wButtonTextColor, value);
                }
            }
            #endregion

            #region Constructor
            public ToppingSelection(ToppingsPageModel referenceToParentClass)
            {
                parentToppingsPageModel = referenceToParentClass;
                areWholeHalfColumnsVisible = true;
                AButtonCommand = new Xamarin.Forms.Command(OnButtonAClick);
                BButtonCommand = new Xamarin.Forms.Command(OnButtonBClick);
                WButtonCommand = new Xamarin.Forms.Command(OnButtonWClick);
            }

            #endregion

            #region Methods
            private void OnButtonAClick()
            {
                parentToppingsPageModel.SelectButtonWAB(ToppingWholeHalf.HalfA, SelectionIndex);
            }

            private void OnButtonBClick()
            {
                parentToppingsPageModel.SelectButtonWAB(ToppingWholeHalf.HalfB, SelectionIndex);
            }

            private void OnButtonWClick()
            {
                parentToppingsPageModel.SelectButtonWAB(ToppingWholeHalf.Whole, SelectionIndex);
            }
  
            #endregion
        }
        //******************************NOTE IMBEDDED CLASS************************
      
        #region Private Variables
        private ObservableCollection<ToppingSelection> toppingSelectionsList;
        private ToppingSelection selectedToppingItem;
        private Pizza thisPizza;
        private Toppings toppings;
        #endregion

        #region Properties
        
        public Toppings Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                SetProperty(ref toppings, value);
                MenuHeaderModel.GetInstance().ItemTotal = thisPizza.BasePrice + toppings.ToppingsTotal;
            }
        }
        public List<ToppingSelection> SelectedItems = new List<ToppingSelection>();
        public ObservableCollection<ToppingSelection> ToppingSelectionsList
        {
            get
            {
                return toppingSelectionsList;
            }
            set
            {
                SetProperty(ref toppingSelectionsList, value);
            }
        }
      
        public ToppingSelection SelectedToppingItem
        {
            get
            {
                return selectedToppingItem;
            }
            set
            {
                SetProperty(ref selectedToppingItem, value);
            }
        }

        public string[] BaseSelections { get; set; }
        public string[] CookSelections { get; set; }
        public string[] OtherSelections { get; set; }

        #endregion

        #region Constructor
        public ToppingsPageModel(PizzaType pizzaType)
        {      
            OrderItem thisItem = OrderManager.GetInstance().OrderItemInProgress;
            string pizzaName = thisItem.ItemName;

            BaseSelections = new string[]
            {
                "Regular Base", "Pesto Base", "White Base"
            };
            CookSelections = new string[]
            {
                "Regular Cook", "Crispy Cook", "Kid Cook", "Light Cook"
            };
            OtherSelections = new string[]
            {
                "Butter OK",
                "CUT INTO 12",
                "JOINER",
                "KID COOK",
                "NO CUT",
                "OUT FIRST",
                "SALAD WITH ORDER",
                "slice cut in half same plate",
                "slice cut in half separate plate",
                "TAKEOUT-BRING2TABLE",
                "TAKEOUT-KEEPINKITCH"
            };

            var toppingsList = new List<Topping>()
            {
                new Topping(ToppingName.Anchovies),
                new Topping(ToppingName.Artichokes),
                new Topping(ToppingName.Bacon),
                new Topping(ToppingName.BananaPeppers),
                new Topping(ToppingName.Basil),
                new Topping(ToppingName.Beef),
                new Topping(ToppingName.BlackOlives),
                new Topping(ToppingName.Broccoli),
                new Topping(ToppingName.Carrots),
                new Topping(ToppingName.DAIYA) ,
                new Topping(ToppingName.ExtraCheese),
                new Topping(ToppingName.ExtraMozarellaCalzone),
                new Topping(ToppingName.ExtraPSauceOS),
                new Topping(ToppingName.ExtraPSauceOP),
                new Topping(ToppingName.ExtraRicottaCalzone),
                new Topping(ToppingName.Feta),
                new Topping(ToppingName.Garlic) ,
                new Topping(ToppingName.GreenOlives),
                new Topping(ToppingName.GreenPeppers),
                new Topping(ToppingName.HalfMajor)
                            { ToppingWholeHalf = ToppingWholeHalf.HalfA},
                new Topping(ToppingName.Jalapenos),
                new Topping(ToppingName.Meatballs),
                new Topping(ToppingName.Mushrooms),
                new Topping(ToppingName.NoCheese) {SpecialPricingType = SpecialPricingType.GetExtraTopping},
                new Topping(ToppingName.Onion),
                new Topping(ToppingName.PestoTopping) ,
                new Topping(ToppingName.Pepperoni),
                new Topping(ToppingName.Pineapple),
                new Topping(ToppingName.RedOnions),
                new Topping(ToppingName.Ricotta),
                new Topping(ToppingName.RoastedRedPepper),
                new Topping(ToppingName.Sausage),
                new Topping(ToppingName.Spinach),
                new Topping(ToppingName.Steak),
                new Topping(ToppingName.SundriedTomatoes),
                new Topping(ToppingName.Teese) {SpecialPricingType = SpecialPricingType.AddorSubtractAmount},
                new Topping(ToppingName.TempehBBQ),
                new Topping(ToppingName.Tomatoes),
                new Topping(ToppingName.Zucchini),
                new Topping(ToppingName.Cheese),
                new Topping(ToppingName.Deep) {SpecialPricingType = SpecialPricingType.Unknown},
                new Topping(ToppingName.LightSauce) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightMozarella) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.LightRicotta) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoButter) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoSauce) {SpecialPricingType = SpecialPricingType.Free},
            };

                       ToppingSelectionsList = new ObservableCollection<ToppingSelection>();
            for (int i = 0; i < toppingsList.Count; i++)
            {
                var toppingSelection = new ToppingSelection(this);
                toppingSelection.ListTopping = toppingsList[i];
                toppingSelection.SelectionIndex = i;
                toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                //toppingSelection.AColor = Xamarin.Forms.Color.Black;
                toppingSelection.BColor = Xamarin.Forms.Color.Black;
                toppingSelection.WColor = Xamarin.Forms.Color.Black;
                toppingSelection.WButtonTextColor = Color.White;
                toppingSelection.AreWholeHalfColumnsVisible = true;
                if (toppingsList[i].ToppingName == ToppingName.HalfMajor)
                {
                    toppingSelection.WButtonTextColor = Color.Black;
                }
                ToppingSelectionsList.Add(toppingSelection);

                //If the pizza type is a slice, don't display whole/halfa/halfb options.
                
                toppingSelection.AreWholeHalfColumnsVisible = true;
                if (pizzaName.Equals(DisplayNames.GetPizzaDisplayName(PizzaType.ThinSlice)) ||
                    pizzaName.Equals(DisplayNames.GetPizzaDisplayName(PizzaType.PanSlice)))
                {
                    toppingSelection.AreWholeHalfColumnsVisible = false;
                }
            }
            toppings = new Toppings(pizzaType);
            if (thisItem is Pizza)
            {
                thisPizza = (Pizza)thisItem;
                if (thisPizza.MajorMamaInfo == MajorOrMama.Major)
                {
                    SelectMajorToppings();
                    toppings.AddMajorToppings();
                  
                    //MenuHeaderModel.ItemTotal = Pizza.CalculatePizzaItemCostNoTax(pizzaType, 1, Toppings);
                }
            }
            //NOTE:  Modifying Toppings directly instead of 
            //explicitly setting it here does not trigger bindings.
            Toppings = toppings;
        }
        #endregion

        #region Methods
        public void SelectMajorToppings(ToppingWholeHalf toppingWholeHalf = ToppingWholeHalf.Whole)
        {
            foreach (var toppingselection in ToppingSelectionsList)
            {
                if (toppingselection.ListTopping.ToppingName == ToppingName.Pepperoni ||
                    toppingselection.ListTopping.ToppingName == ToppingName.Mushrooms ||
                    toppingselection.ListTopping.ToppingName == ToppingName.Sausage ||
                    toppingselection.ListTopping.ToppingName == ToppingName.GreenPeppers ||
                    toppingselection.ListTopping.ToppingName == ToppingName.Onion ||
                    toppingselection.ListTopping.ToppingName == ToppingName.BlackOlives)
                {
                    toppingselection.ListItemIsSelected = true;
                   
                    toppingselection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    if (toppingWholeHalf == ToppingWholeHalf.Whole)
                    {
                        toppingselection.WColor = Xamarin.Forms.Color.CornflowerBlue;
                    }
                    else if (toppingWholeHalf == ToppingWholeHalf.HalfA)
                    {
                        toppingselection.ButtonASelected = true;
                        //toppingselection.AColor = Xamarin.Forms.Color.CornflowerBlue;
                    }
                    else if (toppingWholeHalf == ToppingWholeHalf.HalfB)
                    {
                        toppingselection.BColor = Xamarin.Forms.Color.CornflowerBlue;
                    }


                }
            }
        }

        public void SelectButtonWAB(ToppingWholeHalf wholeOrHalf, int indexOfSelection)
        {
            var thisItemSelected = ToppingSelectionsList[indexOfSelection];
            thisItemSelected.ListTopping.ToppingWholeHalf = wholeOrHalf; 

            if (thisItemSelected.ListTopping.ToppingName == ToppingName.HalfMajor)
            {
                ProcessHalfMajorSelectionOfSide(thisItemSelected);
            }
            else
            {
                if (!thisItemSelected.ListItemIsSelected)
                {
                    thisItemSelected.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    thisItemSelected.ListItemIsSelected = true;
                }
                bool toppingAlreadyAdded = false;
                foreach (var topping in toppings.CurrentToppings)
                {
                    if (topping.ToppingName == thisItemSelected.ListTopping.ToppingName)
                    {
                        toppingAlreadyAdded = true;
                        break;
                    }
                }
                if (toppingAlreadyAdded)
                {
                    toppings.UpdateToppingsTotal();
                }
                else
                {
                    thisItemSelected.ListTopping.SequenceSelected = toppings.CurrentToppings.Count + 1;
                    toppings.AddTopping(thisItemSelected.ListTopping);
                }
                ChangeButtonSelection(thisItemSelected, wholeOrHalf);
            }
            
            //NOTE:  Modifying Toppings directly instead of 
            //explicitly setting it here does not trigger bindings.
            Toppings = toppings;
        }

        private void ProcessHalfMajorSelectionOfSide(ToppingSelection thisItemSelected)
        {
            if (thisItemSelected.ListTopping.ToppingWholeHalf == ToppingWholeHalf.Whole)
            {
                thisItemSelected.WColor = Color.Black;
                //thisItemSelected.AColor = Color.Black;
                thisItemSelected.ButtonASelected = false;
                thisItemSelected.BColor = Color.Black;
                thisItemSelected.WButtonTextColor = Color.Black;
                return;
            }
            if (!thisItemSelected.ListItemIsSelected)
            {
                thisItemSelected.ListItemIsSelected = true;
                thisItemSelected.SelectionColor = Color.CornflowerBlue;
                ChangeButtonSelection(thisItemSelected, thisItemSelected.ListTopping.ToppingWholeHalf);
            }
           
            toppings.AddMajorToppings();
            switch (thisItemSelected.ListTopping.ToppingWholeHalf)
            {
                case ToppingWholeHalf.HalfA:
                    toppings.ChangeMajorToppingsHalf(ToppingWholeHalf.HalfA);

                    break;
                case ToppingWholeHalf.HalfB:
                    toppings.ChangeMajorToppingsHalf(ToppingWholeHalf.HalfB);
                    break;
            }
            ChangeButtonSelection(thisItemSelected, thisItemSelected.ListTopping.ToppingWholeHalf);
            //find all major toppings in ToppingSelectionsList and call ChangeButtonSelection on them.
            foreach (var toppingSelection in ToppingSelectionsList)
            {
                if (toppingSelection.ListTopping.ToppingName == ToppingName.Mushrooms ||
                    toppingSelection.ListTopping.ToppingName == ToppingName.GreenPeppers ||
                    toppingSelection.ListTopping.ToppingName == ToppingName.Onion ||
                    toppingSelection.ListTopping.ToppingName == ToppingName.Pepperoni ||
                    toppingSelection.ListTopping.ToppingName == ToppingName.Sausage ||
                    toppingSelection.ListTopping.ToppingName == ToppingName.BlackOlives)
                {
                    toppingSelection.SelectionColor = Color.CornflowerBlue;
                    ChangeButtonSelection(toppingSelection, thisItemSelected.ListTopping.ToppingWholeHalf);
                }
            }
        }

        public void ChangeButtonSelection(ToppingSelection thisItemSelected, ToppingWholeHalf wholeOrHalf)
        {
            switch (wholeOrHalf)
            {
                case ToppingWholeHalf.Whole:
                    thisItemSelected.WColor = Color.CornflowerBlue;
                    thisItemSelected.ButtonASelected = false;
                    //thisItemSelected.AColor = Color.Black;
                    thisItemSelected.BColor = Color.Black;
                    break;
                case ToppingWholeHalf.HalfA:
                    thisItemSelected.ButtonASelected = true;
                    //thisItemSelected.AColor = Color.CornflowerBlue;
                    thisItemSelected.BColor = Color.Black;
                    thisItemSelected.WColor = Color.Black;
                    break;
                case ToppingWholeHalf.HalfB:
                    thisItemSelected.BColor = Color.CornflowerBlue;
                    thisItemSelected.ButtonASelected = false;
                    //thisItemSelected.AColor = Color.Black;
                    thisItemSelected.WColor = Color.Black;
                    break;
            }
        }

        
        public List<Topping> GetToppingsSelected()
        {
            return SelectedItems.Where(
                item => item.ListItemIsSelected).Select(
                selectedItem => selectedItem.ListTopping).ToList();
        }
        #endregion
    }
}
