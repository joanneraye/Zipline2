using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Zipline2.BusinessLogic.Enums;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    public class ToppingsOtherPageModel : BasePageModel
    {
        //******************************NOTE IMBEDDED CLASS************************
        public class OtherToppingSelection : BasePageModel
        {
            private bool isOtherToppingItemSelected;
            public Topping OtherToppingsListTopping { get; set; }
            public bool IsOtherToppingItemSelected
            {
                get
                {
                    return isOtherToppingItemSelected;
                }
                set
                {
                    SetProperty(ref isOtherToppingItemSelected, value);
                }
            }
        }
        //******************************NOTE IMBEDDED CLASS ABOVE******************
        public List<Topping> ToppingsOtherList { get; set; }
        private OtherToppingSelection selectedOtherToppingItem;
        public OtherToppingSelection SelectedOtherToppingItem
        {
            get
            {
                return selectedOtherToppingItem;
            }
            set
            {
                SetProperty(ref selectedOtherToppingItem, value);
            }
        }


        private ObservableCollection<OtherToppingSelection> otherToppingsSelectionsList;
        public ObservableCollection<OtherToppingSelection> OtherToppingsSelectionsList
        {
            get
            {
                return otherToppingsSelectionsList;
            }
            set
            {
                SetProperty(ref otherToppingsSelectionsList, value);
            }
        }


        public ToppingsOtherPageModel(List<Topping> toppingsAlreadySelected)
        {
            ToppingsOtherList = new List<Topping>()
            {
                new Topping(ToppingName.ButterOk) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.CutInto12) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.Joiner) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.KidCook) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.NoCut) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.OutFirst) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.SaladWithOrder) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.SliceCutInHalfSamePlate) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.SliceCutInHalfSepPlate) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.TakeoutBring2Table) {SpecialPricingType = SpecialPricingType.Free},
                new Topping(ToppingName.TakeoutKeepInKitch) {SpecialPricingType = SpecialPricingType.Free},
            };

            OtherToppingsSelectionsList = new ObservableCollection<OtherToppingSelection>();
            //TODO:: Preselect items below that are in the SelectedOtherToppings (List<Topping>) 
            //      passed in from ToppingsPage:  toppingsAlreadySelected
            foreach (var topping in ToppingsOtherList)
            {
                OtherToppingSelection newSelection = new OtherToppingSelection();
                newSelection.OtherToppingsListTopping = topping;
                foreach (var preselectedTopping in toppingsAlreadySelected)
                {
                    if (topping.ToppingName == preselectedTopping.ToppingName)
                    {
                        newSelection.IsOtherToppingItemSelected = true;
                        break;
                    }
                }
                OtherToppingsSelectionsList.Add(newSelection);
            }
           
            //TODO:  Create an other toppings selection list containing the above items and
            //      also containing the IsSelected (converter used to change background
            //      color).  Then (as is done in ToppingsPageModel), iterate through the
            //      above list to create these selection items, using the IsSelected property
            //      to pre-select items already selected for this pizza.
        }
    }
}
