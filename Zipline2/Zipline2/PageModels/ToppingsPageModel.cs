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
using Zipline2.Data;

namespace Zipline2.PageModels
{
    public class ToppingsPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class ToppingDisplayItem : BasePageModel
        {
            #region Private Variables
            private ToppingsPageModel parentToppingsPageModel;
            private bool areWholeHalfColumnsVisible;
            private bool listItemIsSelected;
            private Color selectionColor;
            #endregion

            
            #region Command Variables
            public System.Windows.Input.ICommand AButtonCommand { get; set; }
            public System.Windows.Input.ICommand BButtonCommand { get; set; }
            public System.Windows.Input.ICommand WButtonCommand { get; set; }
            public ICommand ToppingSelectedCommand { get; set; }
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

            //NOTE:  Could not get this to populate based on ListItemIsSelected above
            //and using converter like I did with ButtonASelected, etc.  Maybe it is because
            //tapping the item is not connected to a Command in the ViewModel?
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
            private bool buttonWVisible;
            public bool ButtonWVisible
            {
                get
                {
                    return buttonWVisible;
                }
                set
                {
                    SetProperty(ref buttonWVisible, value);
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

            private bool buttonBSelected;
            public bool ButtonBSelected
            {
                get
                {
                    return buttonBSelected;
                }
                set
                {
                    SetProperty(ref buttonBSelected, value);
                }
            }

            private bool buttonWSelected;
            public bool ButtonWSelected
            {
                get
                {
                    return buttonWSelected;
                }
                set
                {
                    SetProperty(ref buttonWSelected, value);
                }
            }
          
            #endregion

            #region Constructor
            public ToppingDisplayItem(ToppingsPageModel referenceToParentClass)
            {
                parentToppingsPageModel = referenceToParentClass;
                areWholeHalfColumnsVisible = true;
                AButtonCommand = new Xamarin.Forms.Command(OnButtonAClick);
                BButtonCommand = new Xamarin.Forms.Command(OnButtonBClick);
                WButtonCommand = new Xamarin.Forms.Command(OnButtonWClick);
                ToppingSelectedCommand = new Command(OnToppingSelected);
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

            private void OnToppingSelected()
            {
                parentToppingsPageModel.SelectTopping(SelectionIndex);
            }

            #endregion
        }
        //******************************NOTE IMBEDDED CLASS************************

        #region Private Variables
        private ObservableCollection<ToppingDisplayItem> toppingSelectionsList;
        private ToppingDisplayItem selectedToppingItem;
        private Pizza thisPizza;
        #endregion

        #region Properties
        public Pizza ThisPizza
        {
            get
            {
                return thisPizza;
            }
            private set
            {
                SetProperty(ref thisPizza, value);
            }
        }

        public List<ToppingDisplayItem> SelectedItems = new List<ToppingDisplayItem>();
        public ObservableCollection<ToppingDisplayItem> ToppingSelectionsList
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
      
        public ToppingDisplayItem SelectedToppingItem
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
        public ToppingFooterPageModel ToppingFooterPageModel { get; set; }

        public ICommand AddPizzaToOrderCommand { get; set; }

        public event EventHandler NavigateToPizzaPage;

        #endregion

        #region Constructor
        public ToppingsPageModel(Pizza currentPizza)
        { 
            ThisPizza = currentPizza;
            string pizzaName = ThisPizza.ItemName;
            AddPizzaToOrderCommand = new Command(OnAddPizzaToOrder);
            BaseSelections = new string[]
            {
                "Pesto Base", "White Base", "Regular Base"
            };
            CookSelections = new string[]
            {
                "Crispy Cook", "Kid Cook", "Light Cook", "Regular Cook"
            };

            var toppingsList = MenuFood.PizzaToppings.Values.ToList();
            ToppingSelectionsList = new ObservableCollection<ToppingDisplayItem>();
            int toppingSelectionIndex = 0;
            for (int i = 0; i < toppingsList.Count; i++)
            {
                if (!toppingsList[i].ForPizza)
                {
                    continue;
                }
                var toppingSelection = new ToppingDisplayItem(this);
                toppingSelection.ListTopping = toppingsList[i];
                toppingSelection.SelectionIndex = toppingSelectionIndex;
                toppingSelectionIndex++;
                toppingSelection.ListItemIsSelected = false;
                toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                toppingSelection.ButtonWVisible = true;
                toppingSelection.AreWholeHalfColumnsVisible = true;
                if (toppingsList[i].ToppingName == ToppingName.HalfMajor)
                {
                    toppingSelection.ButtonWVisible = false;
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
           
            if (ThisPizza != null)
            {
                if (ThisPizza.MajorMamaInfo == MajorOrMama.Major)
                {
                    SelectMajorToppings();
                    ThisPizza.Toppings.AddMajorToppings();
                }
            }
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
                        toppingselection.ButtonWSelected = true;
                    }
                    else if (toppingWholeHalf == ToppingWholeHalf.HalfA)
                    {
                        toppingselection.ButtonASelected = true;
                    }
                    else if (toppingWholeHalf == ToppingWholeHalf.HalfB)
                    {
                        toppingselection.ButtonBSelected = true;
                    }
                }
            }
        }

        public void SelectTopping(int selectionIndex)
        {
            //Can't change ListView directly - must change underlying data.  Get this data by the index.
            ToppingDisplayItem thisSelection = ToppingSelectionsList[selectionIndex];
            if (!ToppingFooterPageModel.ExtraToppingSelected || 
                (ToppingFooterPageModel.ExtraToppingSelected && !thisSelection.ListItemIsSelected))
            {
                thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;  //toggle topping selection.
            }
               
            thisSelection.ListTopping.ToppingModifier = ToppingFooterPageModel.GetToppingModifierType();

            if (thisSelection.ListTopping.ToppingName == ToppingName.HalfMajor)
            {
                ProcessHalfMajorToppingSelection(thisSelection);
            }
            else if (ToppingFooterPageModel.ExtraToppingSelected)
            {
                if (thisSelection.ListTopping.Count == 0)
                {
                    thisSelection.ListTopping.Count = 1;
                }
                thisSelection.ListTopping.Count++;
            }          
            else if (ToppingFooterPageModel.NoToppingSelected)
            {
                thisPizza.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
            }
            
            if  (thisSelection.ListItemIsSelected)
            {
                if (ToppingFooterPageModel.ExtraToppingSelected &&
                    thisSelection.ListTopping.Count > 1 &&
                    ThisPizza.Toppings.IsToppingAlreadyAdded(thisSelection.ListTopping.ToppingName))
                {
                    ThisPizza.Toppings.UpdateToppingsTotal();
                    //ThisPizza.UpdateItemTotal();
                    thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    thisSelection.ButtonWSelected = true;
                }
                else
                {
                    thisSelection.ListTopping.SequenceSelected = ThisPizza.Toppings.CurrentToppings.Count + 1;
                    ThisPizza.Toppings.AddTopping(thisSelection.ListTopping);
                    //ThisPizza.UpdateItemTotal();
                    thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    thisSelection.ButtonWSelected = true;
                }
               
            }
            else
            {
                thisSelection.ListTopping.SequenceSelected = 0;
                thisSelection.ButtonWSelected = true;
                thisSelection.ButtonASelected = false;
                thisSelection.ButtonBSelected = false;
                thisSelection.ListTopping.ToppingModifier = ToppingModifierType.None;
                thisSelection.ListTopping.Count = 0;
                ThisPizza.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
                //ThisPizza.UpdateItemTotal();
                thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
                thisSelection.ButtonASelected = false;
                thisSelection.ButtonBSelected = false;
                thisSelection.ButtonWSelected = false;
            }

            //Modifier buttons only work if selected before the topping is selected.  At this point,
            //all should be reset back to black/unselected.
            ToppingFooterPageModel.ExtraToppingSelected = false;
            ToppingFooterPageModel.LiteToppingSelected = false;
            ToppingFooterPageModel.NoToppingSelected = false;
            ToppingFooterPageModel.OnSideToppingSelected = false;

            //Can't remember why I might need this....
            //if (thisSelection.ListTopping.ToppingName == ToppingName.Cheese)
            //{
            //    if (App.AllToppings.ContainsKey(ToppingName.NoCheese))
            //    {
            //        thisPizza.Toppings.AddTopping(App.AllToppings[ToppingName.NoCheese]);
            //    }
            //}
            //else if (thisSelection.ListTopping.ToppingName == ToppingName.RicottaCalzone ||
            //    thisSelection.ListTopping.ToppingName == ToppingName.Ricotta)
            //{
            //    if (App.AllToppings.ContainsKey(ToppingName.NoRicotta))
            //    {
            //        thisPizza.Toppings.AddTopping(App.AllToppings[ToppingName.NoRicotta]);
            //    }
            //}
        }

        //For selection or deselection of the Half Major topping.
        private void ProcessHalfMajorToppingSelection(ToppingDisplayItem halfMajorSelection)
        {
            if (halfMajorSelection.ListItemIsSelected)   //If selected, toggle to unselect...
            {
                ThisPizza.Toppings.RemoveToppings(new List<ToppingName>
                {
                    ToppingName.Mushrooms,
                    ToppingName.BlackOlives,
                    ToppingName.GreenPeppers,
                    ToppingName.Onion,
                    ToppingName.Pepperoni,
                    ToppingName.Sausage
                });

                foreach (var toppingSelection in ToppingSelectionsList)
                {
                    if (toppingSelection.ListTopping.ToppingName == ToppingName.Mushrooms ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.GreenPeppers ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Onion ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Pepperoni ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Sausage ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.BlackOlives)
                    {
                        toppingSelection.ButtonWSelected = false;
                        toppingSelection.ButtonASelected = false;
                        toppingSelection.ButtonBSelected = false;
                        toppingSelection.ListItemIsSelected = false;
                    }
                }
                halfMajorSelection.ListItemIsSelected = false;
                halfMajorSelection.ButtonWSelected = false;
                halfMajorSelection.ButtonASelected = false;
                halfMajorSelection.ButtonBSelected = false;
            }
            else
            {
                SelectMajorToppings(halfMajorSelection.ListTopping.ToppingWholeHalf);
                ThisPizza.Toppings.AddMajorToppingsToHalf(ToppingWholeHalf.HalfA);

                halfMajorSelection.ListItemIsSelected = true;
                halfMajorSelection.ButtonASelected = true;
            }
            halfMajorSelection.ListItemIsSelected = !halfMajorSelection.ListItemIsSelected;
        }

        /// <summary>
        /// Marks the item in the list as being selected if it hasn't
        /// been selected previously (which will
        /// higlight the item), changes the item to indicate change to
        /// whole, half a, or half b, handles the special case of the topping
        /// called "Half Major", and marks the sequence the item was selected.
        /// </summary>
        /// <param name="wholeOrHalf"></param>
        /// <param name="indexOfSelection"></param>
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

                //The topping may already have been added, but is being changed to half.
                //If the topping has not already been added, will need to add it (for half).
                bool toppingAlreadyAdded = false;
                foreach (var topping in thisPizza.Toppings.CurrentToppings)
                {
                    if (topping.ToppingName == thisItemSelected.ListTopping.ToppingName)
                    {
                        toppingAlreadyAdded = true;
                        break;
                    }
                }
                if (toppingAlreadyAdded)
                {
                    //TODO:  This may not be needed if done automatically????
                    thisPizza.Toppings.UpdateToppingsTotal();
                }
                else
                {
                    thisItemSelected.ListTopping.SequenceSelected = thisPizza.Toppings.CurrentToppings.Count + 1;
                    thisPizza.Toppings.AddTopping(thisItemSelected.ListTopping);
                }
                //thisPizza.UpdateItemTotal();
                ChangeButtonSelection(thisItemSelected, wholeOrHalf);
            }
        }

        private void ProcessHalfMajorSelectionOfSide(ToppingDisplayItem thisItemSelected)
        {
            if (thisItemSelected.ListTopping.ToppingWholeHalf == ToppingWholeHalf.Whole)
            {
                thisItemSelected.ButtonWSelected = false;
                thisItemSelected.ButtonASelected = false;
                thisItemSelected.ButtonBSelected = false;
                thisItemSelected.ButtonWVisible = false;
                return;
            }
            if (!thisItemSelected.ListItemIsSelected)
            {
                thisItemSelected.ListItemIsSelected = true;
                thisItemSelected.SelectionColor = Color.CornflowerBlue;
                ChangeButtonSelection(thisItemSelected, thisItemSelected.ListTopping.ToppingWholeHalf);
            }

            thisPizza.Toppings.AddMajorToppings();
            switch (thisItemSelected.ListTopping.ToppingWholeHalf)
            {
                case ToppingWholeHalf.HalfA:
                    thisPizza.Toppings.ChangeMajorToppingsHalf(ToppingWholeHalf.HalfA);

                    break;
                case ToppingWholeHalf.HalfB:
                    thisPizza.Toppings.ChangeMajorToppingsHalf(ToppingWholeHalf.HalfB);
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
                    toppingSelection.ListItemIsSelected = true;
                    toppingSelection.SelectionColor = Color.CornflowerBlue;
                    ChangeButtonSelection(toppingSelection, thisItemSelected.ListTopping.ToppingWholeHalf);
                }
            }
        }

        /// <summary>
        /// Makes sure only W or A or B (one and only one) may be 
        /// selected at a time.
        /// </summary>
        /// <param name="thisItemSelected"></param>
        /// <param name="wholeOrHalf"></param>
        public void ChangeButtonSelection(ToppingDisplayItem thisItemSelected, ToppingWholeHalf wholeOrHalf)
        {
            switch (wholeOrHalf)
            {
                case ToppingWholeHalf.Whole:
                    thisItemSelected.ButtonWSelected = true;
                    thisItemSelected.ButtonASelected = false;
                    thisItemSelected.ButtonBSelected = false;
                    break;
                case ToppingWholeHalf.HalfA:
                    thisItemSelected.ButtonASelected = true;
                    thisItemSelected.ButtonBSelected = false;
                    thisItemSelected.ButtonWSelected = false;
                    break;
                case ToppingWholeHalf.HalfB:
                    thisItemSelected.ButtonBSelected = true;
                    thisItemSelected.ButtonASelected = false;
                    thisItemSelected.ButtonWSelected = false;
                    break;
            }
        }

        private void OnAddPizzaToOrder()
        {
            OrderManager.Instance.AddItemInProgressToOrder();
            OnNavigateToPizzaPage();
        }

        private void OnNavigateToPizzaPage()
        {
            NavigateToPizzaPage?.Invoke(this, EventArgs.Empty);
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
