using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Data;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class SaladToppingsPageModel : BasePageModel
    {
        public class SaladToppingDisplayItem : BasePageModel
        {
            private Topping saladTopping;
            public Topping SaladTopping
            {
                get
                {
                    return saladTopping;
                }
                set
                {
                    SetProperty(ref saladTopping, value);
                }
            }

            public ICommand SaladToppingSelectedCommand { get; set; }

            private SaladToppingsPageModel parentToppingsPageModel;

            public int SaladSelectionIndex { get; set; }

            private bool saladToppingIsSelected;
            public bool SaladToppingIsSelected
            {
                get
                {
                    return saladToppingIsSelected;
                }
                set
                {
                    SetProperty(ref saladToppingIsSelected, value);
                }
            }

            public SaladToppingDisplayItem(SaladToppingsPageModel referenceToParentClass)
            {
                parentToppingsPageModel = referenceToParentClass;
                SaladToppingSelectedCommand = new Command(OnToppingSelected);
            }
            public void OnToppingSelected()
            {
                parentToppingsPageModel.SelectTopping(SaladSelectionIndex);
            }
        }

        //*************************end of SaladToppingDisplayItem class****************************

        //private string addButtonText;
        public string AddButtonText { get; set; }
        //{
        //    get
        //    {
        //        return addButtonText;
        //    }
        //    set
        //    {
        //        SetProperty(ref addButtonText, value);
        //    }
        //}

        public ICommand NextPageCommand { get; set; }
        public ICommand AddToOrderCommand { get; set; }

        private Salad currentSalad;

        public Salad CurrentSalad
        {
            get
            {
                return currentSalad;
            }
            set
            {
                SetProperty(ref currentSalad, value);
            }
        }

        public event EventHandler NavigateToPizzaPage;
        public event EventHandler NavigateToPizzaToppingsPage;
        public ToppingFooterPageModel ToppingFooterPageModel { get; set; }

        private ObservableCollection<SaladToppingDisplayItem> saladToppingSelectionsList;
        public ObservableCollection<SaladToppingDisplayItem> SaladToppingSelectionsList
        {
            get
            {
                return saladToppingSelectionsList;
            }
            set
            {
                SetProperty(ref saladToppingSelectionsList, value);
            }
        }
        public SaladToppingsPageModel(Salad currentSalad)
        {
            CurrentSalad = currentSalad;
            //if (CurrentSalad.PartOfCombo)
            //{
            //    AddButtonText = "Add Lunch Special To Order";
            //}
            //else
            //{
            //    AddButtonText = "Add Salad To Order";
            //}
            //If don't need the above can hard code the AddButtonText...
            //Currently the add button text is hidden if part of a special.
            AddButtonText = "Add Salad To Order";

            LoadSaladDisplayItems();
            NextPageCommand = new Command(OnNextPage);
            AddToOrderCommand = new Command(OnAddToOrder);
        }

        private void OnAddToOrder()
        {
            //If the salad is part of a combo, will go on to pizza toppings page.
            //If the salad is by itself, will be adding the salad to the order.
            if (CurrentSalad.PartOfCombo)
            {
                //NOTE - THIS IS NOT USED CURRENTLY SINCE THIS BUTTON IS HIDDEN.
                OrderManager.Instance.UpdateSpecialItemInProgress(CurrentSalad);
                OrderManager.Instance.AddSpeciaItemsToOrder();
            }
            else
            {
                OrderManager.Instance.UpdateItemInProgress(CurrentSalad);
                OrderManager.Instance.AddItemInProgressToOrder();
                
            }
            OnNavigateToPizzaPage();

        }

        private void OnNextPage()
        {
            OrderManager.Instance.UpdateSpecialItemInProgress(CurrentSalad);
            OnNavigateToPizzaToppingsPage();
        }

        private void OnNavigateToPizzaPage()
        {
            NavigateToPizzaPage?.Invoke(this, EventArgs.Empty);
        }

        private void OnNavigateToPizzaToppingsPage()
        {
           
            NavigateToPizzaToppingsPage?.Invoke(this, EventArgs.Empty);
        }


        private void LoadSaladDisplayItems()
        {
            var toppingsList = MenuFood.SaladToppings.Values.ToList();
            SaladToppingSelectionsList = new ObservableCollection<SaladToppingDisplayItem>();
            int toppingSelectionIndex = 0;
            for (int i = 0; i < toppingsList.Count; i++)
            {
                if (!toppingsList[i].ForSalad)
                {
                    continue;
                }
                var toppingSelection = new SaladToppingDisplayItem(this);

                bool toppingAlreadyOnSalad = false;
                if (CurrentSalad != null && CurrentSalad.Toppings != null)
                {
                    foreach (var topping in CurrentSalad.Toppings.CurrentToppings)
                    {
                        if (topping.ToppingName == toppingsList[i].ToppingName)
                        {
                            toppingAlreadyOnSalad = true;
                            toppingSelection.SaladTopping = topping;
                            toppingSelection.SaladToppingIsSelected = true;
                            break;
                        }
                    }
                }
                if (!toppingAlreadyOnSalad)
                {
                    Topping newTopping = toppingsList[i];
                    //Initialize variable items in Topping object:
                    newTopping.ToppingDisplayName = DisplayNames.GetToppingDisplayName(newTopping.ToppingName);
                    newTopping.ToppingModifier = ToppingModifierType.None;
                    newTopping.ToppingWholeHalf = ToppingWholeHalf.Whole;
                    newTopping.SequenceSelected = 0;
                    newTopping.Count = 1;
                    toppingSelection.SaladTopping = newTopping;
                    toppingSelection.SaladToppingIsSelected = false;
                }

                toppingSelection.SaladSelectionIndex = toppingSelectionIndex;
                toppingSelectionIndex++;               

                SaladToppingSelectionsList.Add(toppingSelection);
            }
        }

        

        public void SelectTopping(int selectionIndex)
        {
            SaladToppingDisplayItem thisSelection = SaladToppingSelectionsList[selectionIndex];
            if (!ToppingFooterPageModel.ExtraToppingSelected ||
                (ToppingFooterPageModel.ExtraToppingSelected && !thisSelection.SaladToppingIsSelected))
            {
                thisSelection.SaladToppingIsSelected = !thisSelection.SaladToppingIsSelected;  //toggle topping selection.
            }

            thisSelection.SaladTopping.ToppingModifier = ToppingFooterPageModel.GetToppingModifierType();
            if (thisSelection.SaladTopping.ToppingModifier == ToppingModifierType.ExtraTopping)
            {
                if (thisSelection.SaladTopping.Count == 0)
                {
                    thisSelection.SaladTopping.Count = 1;
                }
                thisSelection.SaladTopping.Count++;
            }
            else if (thisSelection.SaladTopping.ToppingModifier == ToppingModifierType.NoTopping)
            {
                CurrentSalad.Toppings.RemoveTopping(thisSelection.SaladTopping.ToppingName);
            }

            if (thisSelection.SaladToppingIsSelected)
            {
                if (ToppingFooterPageModel.ExtraToppingSelected &&
                    thisSelection.SaladTopping.Count > 1 &&
                    CurrentSalad.Toppings.IsToppingAlreadyAdded(thisSelection.SaladTopping.ToppingName))
                {
                    CurrentSalad.Toppings.UpdateToppingsTotal();
                    //CurrentSalad.UpdateItemTotal();
                }
                else
                {
                    thisSelection.SaladTopping.SequenceSelected = CurrentSalad.Toppings.CurrentToppings.Count + 1;
                    CurrentSalad.Toppings.AddTopping(thisSelection.SaladTopping);
                    //CurrentSalad.UpdateItemTotal();
                }

            }
            else
            {
                thisSelection.SaladTopping.SequenceSelected = 0;
                thisSelection.SaladTopping.ToppingModifier = ToppingModifierType.None;
                thisSelection.SaladTopping.Count = 0;
                CurrentSalad.Toppings.RemoveTopping(thisSelection.SaladTopping.ToppingName);
                //CurrentSalad.UpdateItemTotal();
            }

            //Modifier buttons only work if selected before the topping is selected.  At this point,
            //all should be reset back to black/unselected.
            ToppingFooterPageModel.ExtraToppingSelected = false;
            ToppingFooterPageModel.LiteToppingSelected = false;
            ToppingFooterPageModel.NoToppingSelected = false;
            ToppingFooterPageModel.OnSideToppingSelected = false;
        }

    }
}
