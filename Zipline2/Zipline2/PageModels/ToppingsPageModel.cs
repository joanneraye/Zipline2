using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;
using System.Linq;
using System.Collections.ObjectModel;

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

            public Color AColor
            {
                get
                {
                    return acolor;
                }
                set
                {
                    SetProperty(ref acolor, value);
                }
            }

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
        private string pizzaName;
        #endregion

        #region Properties
        public Toppings Toppings { get; set; }
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

        public string PizzaName
        {
            get
            {
                return pizzaName;
            }
            set
            {
                SetProperty(ref pizzaName, value);
            }
        }
        #endregion

        #region Constructor
        public ToppingsPageModel(PizzaType pizzaType)
        {
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
                            { SpecialPricingType = SpecialPricingType.Half},
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

            OrderItem thisItem = OrderManager.GetInstance().OrderItemInProgress;
            pizzaName = thisItem.ItemName;
            ToppingSelectionsList = new ObservableCollection<ToppingSelection>();
            for (int i = 0; i < toppingsList.Count; i++)
            {
                var toppingSelection = new ToppingSelection(this);
                toppingSelection.ListTopping = toppingsList[i];
                toppingSelection.SelectionIndex = i;
                toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                toppingSelection.AColor = Xamarin.Forms.Color.Black;
                toppingSelection.BColor = Xamarin.Forms.Color.Black;
                toppingSelection.WColor = Xamarin.Forms.Color.Black;
                toppingSelection.AreWholeHalfColumnsVisible = true;
                ToppingSelectionsList.Add(toppingSelection);

                //If the pizza type is a slice, don't display whole/halfa/halfb options.
                
                toppingSelection.AreWholeHalfColumnsVisible = true;
                if (pizzaName.Equals(DisplayNames.GetPizzaDisplayName(PizzaType.ThinSlice)) ||
                    pizzaName.Equals(DisplayNames.GetPizzaDisplayName(PizzaType.PanSlice)))
                {
                    toppingSelection.AreWholeHalfColumnsVisible = false;
                }
            }
            Toppings = new Toppings(pizzaType);
            if (thisItem is Pizza)
            {
                thisPizza = (Pizza)thisItem;
                if (thisPizza.MajorMamaInfo == MajorOrMama.Major)
                {
                    SelectMajorToppings();
                    Toppings.AddMajorToppings();
                    MenuHeaderModel.GetInstance().ItemTotal = 
                        Pizza.CalculatePizzaItemCostNoTax(pizzaType, 1, Toppings);
                }
            }
        }
        #endregion

        #region Methods
        public void SelectMajorToppings()
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
                    toppingselection.WColor = Xamarin.Forms.Color.CornflowerBlue;
                   
                }
            }
        }

        public void SelectButtonWAB(ToppingWholeHalf wholeOrHalf, int indexOfSelection)
        {
            var thisItemSelected = ToppingSelectionsList[indexOfSelection];
            thisItemSelected.ListTopping.ToppingWholeHalf = wholeOrHalf;
            Toppings.UpdateToppingsTotal();
            
            //TODO:  Possibly this should be stored outside of ToppingsPage....
            MenuHeaderModel.GetInstance().ItemTotal = Pizza.CalculatePizzaItemCostNoTax(thisPizza.PizzaType, 1, Toppings);
            switch (wholeOrHalf)
            {
                case ToppingWholeHalf.Whole:
                    thisItemSelected.WColor = Color.CornflowerBlue;
                    thisItemSelected.AColor = Color.Black;
                    thisItemSelected.BColor = Color.Black;
                    break;
                case ToppingWholeHalf.HalfA:
                    //Need to do the following for the toppings variable on the ToppingsPage
                    //toppings.UpdateToppingsTotal();
                    thisItemSelected.AColor = Color.CornflowerBlue;
                    thisItemSelected.BColor = Color.Black;
                    thisItemSelected.WColor = Color.Black;
                    break;
                case ToppingWholeHalf.HalfB:
                    //Need to do the following for the toppings variable on the ToppingsPage
                    //toppings.UpdateToppingsTotal();
                    thisItemSelected.BColor = Color.CornflowerBlue;
                    thisItemSelected.AColor = Color.Black;
                    thisItemSelected.WColor = Color.Black;
                    break;
            }
            if (!thisItemSelected.ListItemIsSelected)
            {
                thisItemSelected.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                thisItemSelected.ListItemIsSelected = true;
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
