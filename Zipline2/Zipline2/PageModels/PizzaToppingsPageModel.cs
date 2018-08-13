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
    public class PizzaToppingsPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class ToppingDisplayItem : BasePageModel
        {
            #region Whole Side A Side B fields/properties:
            
            private bool areWholeHalfColumnsVisible;
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

            public System.Windows.Input.ICommand AButtonCommand { get; set; }
            public System.Windows.Input.ICommand BButtonCommand { get; set; }
            public System.Windows.Input.ICommand WButtonCommand { get; set; }

            #endregion

            private PizzaToppingsPageModel parentToppingsPageModel;
            private bool listItemIsSelected;
            private Color selectionColor;
         
            public ICommand ToppingSelectedCommand { get; set; }

            #region Properties
            public Topping ListTopping { get; set; }

            public int SelectionIndex;

          
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
           
            #endregion

            #region Constructor
            public ToppingDisplayItem(PizzaToppingsPageModel referenceToParentClass)
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

        public string AddToOrderText { get; set; }

        public event EventHandler NavigateToPizzaPage;

        #endregion

        #region Constructor
        public PizzaToppingsPageModel(Pizza currentPizza)
        {
            try
            {
                if (currentPizza.PizzaType == PizzaType.LunchSpecialSlice)
                {
                    AddToOrderText = "Add Lunch Special To Order";
                }
                else
                {
                    AddToOrderText = "Add Pizza To Order";
                }
                ThisPizza = currentPizza;
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
                    if (ThisPizza.PizzaType != PizzaType.Indy &&
                        toppingsList[i].ForIndyOnly)
                    {
                        continue;
                    }
                    var toppingSelection = new ToppingDisplayItem(this);

                    bool toppingisAlreadyOnThisPizza = false;
                    if (ThisPizza != null && ThisPizza.Toppings != null)
                    {
                        foreach (var topping in ThisPizza.Toppings.CurrentToppings)
                        {
                            if (topping.ToppingName == toppingsList[i].ToppingName)
                            {
                                toppingisAlreadyOnThisPizza = true;
                                toppingSelection.ListTopping = topping;
                                if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfA)
                                {
                                        toppingSelection.ButtonASelected = true;
                                }
                                else if (topping.ToppingWholeHalf == ToppingWholeHalf.HalfB)
                                {
                                    toppingSelection.ButtonBSelected = true;
                                }
                                toppingSelection.ListItemIsSelected = true;
                                toppingSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                                break;
                            }
                        }
                    }
                    if (!toppingisAlreadyOnThisPizza)
                    {
                        Topping newTopping = toppingsList[i];

                        //Initialize variable items in Topping object:
                        newTopping.ToppingDisplayName = DisplayNames.GetToppingDisplayName(newTopping.ToppingName);
                        newTopping.ToppingModifier = ToppingModifierType.None;
                        newTopping.ToppingWholeHalf = ToppingWholeHalf.Whole;
                        newTopping.SequenceSelected = 0;
                        newTopping.Count = 1;
                        toppingSelection.ListTopping = newTopping;
                        toppingSelection.ListItemIsSelected = false;
                        toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    }

                    toppingSelection.SelectionIndex = toppingSelectionIndex;
                    toppingSelectionIndex++;  
                   
                    toppingSelection.ButtonWVisible = true;
                    if (toppingsList[i].ToppingName == ToppingName.HalfMajor)
                    {
                        toppingSelection.ButtonWVisible = false;
                    }

                    ToppingSelectionsList.Add(toppingSelection);

                    //If the pizza type is a slice, don't display whole/halfa/halfb options.

                    toppingSelection.AreWholeHalfColumnsVisible = true;

                    if (ThisPizza.PizzaType == PizzaType.ThinSlice ||
                        ThisPizza.PizzaType == PizzaType.LunchSpecialSlice ||
                        ThisPizza.PizzaType == PizzaType.PanSlice)
                    {
                        toppingSelection.AreWholeHalfColumnsVisible = false;
                    }
                }

                if (ThisPizza != null && ThisPizza.Toppings != null)
                {
                    if (ThisPizza.MajorMamaInfo == MajorOrMama.Major && ThisPizza.Toppings.CurrentToppings.Count == 0)
                    {
                        SelectMajorToppings();
                        ThisPizza.Toppings.AddMajorToppings();
                    }
                }
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
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
                    if (ThisPizza.PizzaType != PizzaType.LunchSpecialSlice &&
                        ThisPizza.PizzaType != PizzaType.ThinSlice &&
                        ThisPizza.PizzaType != PizzaType.PanSlice)
                    {
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
            if (thisSelection.ListTopping.ToppingName == ToppingName.Major)
            {
                ProcessMajorToppingSelection(thisSelection);
               
            }
            //else if (thisSelection.ListTopping.ToppingName == ToppingName.HalfMajor)
            //{
            //    ProcessHalfMajorToppingSelection(thisSelection);
            //}
            else
            {
                if (ToppingFooterPageModel.ExtraToppingSelected)
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

                if (thisSelection.ListItemIsSelected)
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

            }

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


        private void ProcessMajorToppingSelection(ToppingDisplayItem majorSelection)
        {
            if (majorSelection.ListItemIsSelected)
            {
                majorSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                if (majorSelection.ButtonASelected || majorSelection.ButtonBSelected)
                {
                    ProcessHalfMajorSelectionOfSide(majorSelection);
                }
                else
                {
                    majorSelection.ButtonWSelected = true;
                    ThisPizza.MajorMamaInfo = MajorOrMama.Major;
                    ThisPizza.PopulateDisplayName();  //Updates to show MAJOR
                    SelectMajorToppings();
                    ThisPizza.Toppings.AddMajorToppings();
                }
            }
            else
            {
                majorSelection.SelectionColor = Xamarin.Forms.Color.Black;
                majorSelection.ButtonWSelected = false;
                majorSelection.ButtonASelected = false;
                majorSelection.ButtonBSelected = false;
                ThisPizza.MajorMamaInfo = MajorOrMama.Neither;
                ThisPizza.PopulateDisplayName();  //Updates to remove MAJOR
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
                        toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    }
                }
               
            }
        }


        //For selection or deselection of the Half Major topping.
        private void ProcessHalfMajorToppingSelection(ToppingDisplayItem halfMajorSelection)
        {
            if (halfMajorSelection.ListItemIsSelected)  
            {
                SelectMajorToppings(halfMajorSelection.ListTopping.ToppingWholeHalf);
                ThisPizza.Toppings.AddMajorToppingsToHalf(ToppingWholeHalf.HalfA);

                halfMajorSelection.ListItemIsSelected = true;
                halfMajorSelection.ButtonASelected = true;
            }
            else
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

           
            if (!thisItemSelected.ListItemIsSelected)  //toggle selection
            {
                thisItemSelected.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                thisItemSelected.ListItemIsSelected = true;
            }

           

            //The topping may already have been added, but is being changed to half.
            //If the topping has not already been added, will need to add it (for half).
            bool toppingAlreadyAdded = false;
            foreach (Topping topping in thisPizza.Toppings.CurrentToppings)
            {
                if (topping.ToppingName == thisItemSelected.ListTopping.ToppingName)
                {
                    toppingAlreadyAdded = true;
                        
                    break;
                }
            }
            if (toppingAlreadyAdded)
            {
                if (thisItemSelected.ListTopping.ToppingName == ToppingName.Major)
                {
                    thisPizza.Toppings.ChangeMajorToppingsHalf(thisItemSelected.ListTopping.ToppingWholeHalf);
                }
                else
                {
                    thisPizza.Toppings.ChangeToppingToHalf(thisItemSelected.ListTopping.ToppingName, wholeOrHalf);
                }                
            }
            else
            {
                if (thisItemSelected.ListTopping.ToppingName == ToppingName.Major)
                {
                    ProcessHalfMajorSelectionOfSide(thisItemSelected);
                }
                else
                {
                    thisItemSelected.ListTopping.SequenceSelected = thisPizza.Toppings.CurrentToppings.Count + 1;
                    thisPizza.Toppings.AddTopping(thisItemSelected.ListTopping);
                }
              
            }
           
            ChangeButtonSelection(thisItemSelected, wholeOrHalf);
        }

       
        private void ProcessHalfMajorSelectionOfSide(ToppingDisplayItem thisItemSelected)
        {
            if (thisItemSelected.ListItemIsSelected)
            {
                thisItemSelected.ListItemIsSelected = true;
                thisItemSelected.SelectionColor = Color.CornflowerBlue;
                ChangeButtonSelection(thisItemSelected, thisItemSelected.ListTopping.ToppingWholeHalf);
            }

            thisPizza.Toppings.AddMajorToppings();
            thisPizza.Toppings.ChangeMajorToppingsHalf(thisItemSelected.ListTopping.ToppingWholeHalf);
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
            if (ThisPizza.PartOfCombo)
            {
                OrderManager.Instance.UpdateSpecialItemInProgress(ThisPizza);
                OrderManager.Instance.AddSpeciaItemsToOrder();
            }
            else
            {
                OrderManager.Instance.UpdateItemInProgress(ThisPizza);
                OrderManager.Instance.AddItemInProgressToOrder();
            }
           
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
