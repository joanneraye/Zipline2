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

        public ICommand AddSaladToOrderCommand { get; set; }

        public Salad CurrentSalad { get; set; }

        public event EventHandler NavigateToPizzaPage;
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
            LoadSaladDisplayItems();
            AddSaladToOrderCommand = new Command(OnAddSaladToOrder);
        }

        private void OnAddSaladToOrder()
        {
            OrderManager.Instance.AddItemInProgressToOrder();
            OnNavigateToPizzaPage();
        }

        private void OnNavigateToPizzaPage()
        {
            NavigateToPizzaPage?.Invoke(this, EventArgs.Empty);
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
                toppingSelection.SaladTopping = toppingsList[i];
                toppingSelection.SaladSelectionIndex = toppingSelectionIndex;
                toppingSelectionIndex++;
                toppingSelection.SaladToppingIsSelected = false;

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
