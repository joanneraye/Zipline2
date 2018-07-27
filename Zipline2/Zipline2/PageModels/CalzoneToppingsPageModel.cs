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
    public class CalzoneToppingsPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class CalzoneToppingDisplayItem : BasePageModel
        {
            private CalzoneToppingsPageModel parentToppingsPageModel;
            private bool listItemIsSelected;
         
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
            #endregion

            #region Constructor
            public CalzoneToppingDisplayItem(CalzoneToppingsPageModel referenceToParentClass)
            {
                parentToppingsPageModel = referenceToParentClass;
                ToppingSelectedCommand = new Command(OnToppingSelected);
            }

            #endregion

            #region Methods
           
            private void OnToppingSelected()
            {
                parentToppingsPageModel.SelectTopping(SelectionIndex);
            }

            #endregion
        }
        //******************************NOTE IMBEDDED CLASS************************

        #region Private Variables
        private ObservableCollection<CalzoneToppingDisplayItem> toppingSelectionsList;
        private CalzoneToppingDisplayItem selectedToppingItem;
        private Calzone thisCalzone;
        #endregion

        #region Properties
        public Calzone ThisCalzone
        {
            get
            {
                return thisCalzone;
            }
            private set
            {
                SetProperty(ref thisCalzone, value);
            }
        }

        public List<CalzoneToppingDisplayItem> SelectedItems = new List<CalzoneToppingDisplayItem>();
        public ObservableCollection<CalzoneToppingDisplayItem> ToppingSelectionsList
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
      
        public CalzoneToppingDisplayItem SelectedToppingItem
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

        public string[] CookSelections { get; set; }
        public ToppingFooterPageModel ToppingFooterPageModel { get; set; }

        public ICommand AddCalzoneToOrderCommand { get; set; }

        public event EventHandler NavigateToCalzonePage;

        #endregion

        #region Constructor
        public CalzoneToppingsPageModel(Calzone thisCalzone)
        { 
            ThisCalzone = thisCalzone;
            string calzoneName = ThisCalzone.ItemName;
            AddCalzoneToOrderCommand = new Command(OnAddCalzoneToOrder);
          
            CookSelections = new string[]
            {
                "Crispy Cook", "Kid Cook", "Light Cook", "Regular Cook"
            };

            var toppingsList = MenuFood.PizzaToppings.Values.ToList();
            ToppingSelectionsList = new ObservableCollection<CalzoneToppingDisplayItem>();
            int toppingSelectionIndex = 0;
            for (int i = 0; i < toppingsList.Count; i++)
            {
                if (!toppingsList[i].ForCalzone)
                {
                    continue;
                }
                var toppingSelection = new CalzoneToppingDisplayItem(this);

                bool toppingIsAlreadyOnThisCalzone = false;
                if (ThisCalzone != null && ThisCalzone.Toppings != null)
                {
                    foreach (var topping in ThisCalzone.Toppings.CurrentToppings)
                    {
                        if (topping.ToppingName == toppingsList[i].ToppingName)
                        {
                            toppingIsAlreadyOnThisCalzone = true;
                            toppingSelection.ListTopping = topping;
                            toppingSelection.ListItemIsSelected = true;
                            break;
                        }
                    }
                }

                if (!toppingIsAlreadyOnThisCalzone)
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
                }

                toppingSelection.SelectionIndex = toppingSelectionIndex;
                toppingSelectionIndex++;
               
                ToppingSelectionsList.Add(toppingSelection);
            }
           
            if (ThisCalzone != null)
            {
                if (ThisCalzone.MajorMamaInfo == MajorOrMama.Major)
                {
                    SelectMajorToppings();
                    ThisCalzone.Toppings.AddMajorToppings();
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
                }
            }
        }

        public void SelectTopping(int selectionIndex)
        {
            //Can't change ListView directly - must change underlying data.  Get this data by the index.
            CalzoneToppingDisplayItem thisSelection = ToppingSelectionsList[selectionIndex];
            if (!ToppingFooterPageModel.ExtraToppingSelected || 
                (ToppingFooterPageModel.ExtraToppingSelected && !thisSelection.ListItemIsSelected))
            {
                thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;  //toggle topping selection.
            }
               
            thisSelection.ListTopping.ToppingModifier = ToppingFooterPageModel.GetToppingModifierType();

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
                ThisCalzone.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
            }
            
            if  (thisSelection.ListItemIsSelected)
            {
                if (ToppingFooterPageModel.ExtraToppingSelected &&
                    thisSelection.ListTopping.Count > 1 &&
                    ThisCalzone.Toppings.IsToppingAlreadyAdded(thisSelection.ListTopping.ToppingName))
                {
                    ThisCalzone.Toppings.UpdateToppingsTotal();
                }
                else
                {
                    thisSelection.ListTopping.SequenceSelected = ThisCalzone.Toppings.CurrentToppings.Count + 1;
                    ThisCalzone.Toppings.AddTopping(thisSelection.ListTopping);
                }
               
            }
            else
            {
                thisSelection.ListTopping.SequenceSelected = 0;
                thisSelection.ListTopping.ToppingModifier = ToppingModifierType.None;
                thisSelection.ListTopping.Count = 0;
                ThisCalzone.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
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
        }

       

       
        private void OnAddCalzoneToOrder()
        {
            OrderManager.Instance.UpdateItemInProgress(ThisCalzone);
            OrderManager.Instance.AddItemInProgressToOrder();
            OnNavigateToCalzonePage();
        }

        private void OnNavigateToCalzonePage()
        {
            NavigateToCalzonePage?.Invoke(this, EventArgs.Empty);
        }
       
        #endregion
    }
}
