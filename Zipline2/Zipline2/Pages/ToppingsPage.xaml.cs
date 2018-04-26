﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using static Zipline2.PageModels.ToppingsPageModel;
using Zipline2.BusinessLogic;
using System.Windows.Input;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToppingsPage : BasePage
	{
     
        #region Private Variables
        private ToppingsPageModel ToppingsPageModel;
        private int CarouselSelectedPosition { get; set; }
        private ToppingsOtherPage ToppingsOtherPage { get; set; }
        #endregion

        #region Constructor
        public ToppingsPage (Pizza currentPizza)
		{
            ToppingsPageModel = new ToppingsPageModel(currentPizza);
            InitializeComponent ();
            BindingContext = ToppingsPageModel;
            ToppingsListView.ItemSelected += ToppingsListView_ItemSelected;

            string pizzaTitle = currentPizza.ItemName + " Toppings";
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
            //this.ToolbarItems.Add(new ToolbarItem { Text = string.Format("{0:C}", currentPizza.PricePerItem), Priority = 1 });
          
            if (currentPizza.MajorMamaInfo == MajorOrMama.Major)
            {
                //TODO:  Combine the two following?
                ToppingsPageModel.SelectMajorToppings();
                ToppingsPageModel.ThisPizza.Toppings.AddMajorToppings();
            }
        }

        private void ToppingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            return;
            //if (e.SelectedItem != null)
            //{
            //    ToppingDisplayItem thisSelection = e.SelectedItem as ToppingDisplayItem;
            //    if (thisSelection.ListTopping.ToppingName == ToppingName.HalfMajor)
            //    {
            //        ProcessHalfMajorToppingSelection(thisSelection);
            //    }
            //    else
            //    {
            //        thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;
            //        if (thisSelection.ListItemIsSelected)
            //        {
            //            thisSelection.ListTopping.SequenceSelected = ToppingsPageModel.ThisPizza.Toppings.CurrentToppings.Count + 1;
            //            ToppingsPageModel.ThisPizza.Toppings.AddTopping(thisSelection.ListTopping);
            //            thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
            //            thisSelection.ButtonWSelected = true;
            //        }
            //        else
            //        {
            //            thisSelection.ListTopping.SequenceSelected = 0;
            //            ToppingsPageModel.ThisPizza.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
            //            thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
            //            thisSelection.ButtonASelected = false;
            //            thisSelection.ButtonBSelected = false;
            //            thisSelection.ButtonWSelected = false;
            //        }
            //    }
            //}
        }
        #endregion

        #region Methods


        //private void ListItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var listView = sender as ListView;
        //    ToppingDisplayItem selectedItem = listView.SelectedItem as ToppingDisplayItem;
        //    int indexOfItemSelected = selectedItem.SelectionIndex;

        //    //Can't change ListView directly - must change underlying data.  Get this data by the index.
        //    ToppingDisplayItem thisSelection = ToppingsPageModel.ToppingSelectionsList[indexOfItemSelected];

        //    if (thisSelection.ListTopping.ToppingName == ToppingName.HalfMajor)
        //    {
        //        ProcessHalfMajorToppingSelection(thisSelection);
        //    }
        //    else
        //    {
        //        thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;
        //        if (thisSelection.ListItemIsSelected)
        //        {
        //            thisSelection.ListTopping.SequenceSelected = ToppingsPageModel.ThisPizza.Toppings.CurrentToppings.Count + 1;
        //            ToppingsPageModel.ThisPizza.Toppings.AddTopping(thisSelection.ListTopping);
        //            thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
        //            thisSelection.ButtonWSelected = true;
        //        }
        //        else
        //        {
        //            thisSelection.ListTopping.SequenceSelected = 0;
        //            ToppingsPageModel.ThisPizza.Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
        //            thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
        //            thisSelection.ButtonASelected = false;
        //            thisSelection.ButtonBSelected = false;
        //            thisSelection.ButtonWSelected = false;
        //        }
        //    }
        //}

        ////For selection or deselection of the Half Major topping.
        //private void ProcessHalfMajorToppingSelection(ToppingDisplayItem halfMajorSelection)
        //{
        //    if (halfMajorSelection.ListItemIsSelected)   //If selected, toggle to unselect...
        //    {
        //        ToppingsPageModel.ThisPizza.Toppings.RemoveToppings(new List<ToppingName>
        //        {
        //            ToppingName.Mushrooms,
        //            ToppingName.BlackOlives,
        //            ToppingName.GreenPeppers,
        //            ToppingName.Onion,
        //            ToppingName.Pepperoni,
        //            ToppingName.Sausage
        //        });

        //        foreach (var toppingSelection in ToppingsPageModel.ToppingSelectionsList)
        //        {
        //            if (toppingSelection.ListTopping.ToppingName == ToppingName.Mushrooms ||
        //                toppingSelection.ListTopping.ToppingName == ToppingName.GreenPeppers ||
        //                toppingSelection.ListTopping.ToppingName == ToppingName.Onion ||
        //                toppingSelection.ListTopping.ToppingName == ToppingName.Pepperoni ||
        //                toppingSelection.ListTopping.ToppingName == ToppingName.Sausage ||
        //                toppingSelection.ListTopping.ToppingName == ToppingName.BlackOlives)
        //            {
        //                toppingSelection.ButtonWSelected = false;
        //                toppingSelection.ButtonASelected = false;
        //                toppingSelection.ButtonBSelected = false;
        //                toppingSelection.ListItemIsSelected = false;
        //            }
        //        }
        //        halfMajorSelection.ListItemIsSelected = false;
        //        halfMajorSelection.ButtonWSelected = false;
        //        halfMajorSelection.ButtonASelected = false;
        //        halfMajorSelection.ButtonBSelected = false;
        //    }
        //    else
        //    {
        //        ToppingsPageModel.SelectMajorToppings(halfMajorSelection.ListTopping.ToppingWholeHalf);
        //        ToppingsPageModel.ThisPizza.Toppings.AddMajorToppingsToHalf(ToppingWholeHalf.HalfA);

        //        halfMajorSelection.ListItemIsSelected = true;
        //        halfMajorSelection.ButtonASelected = true;
        //    }
        //    halfMajorSelection.ListItemIsSelected = !halfMajorSelection.ListItemIsSelected;

        //}

        private void BasePickerTapped(object sender, EventArgs e)
        {
            BasePicker.Focus();
        }

        private void OnBasePickerSelectionChanged(object sender, EventArgs e)
        {
            BasePickerLabel.Text = BasePicker.Items[BasePicker.SelectedIndex];
            BasePickerLabel.BackgroundColor = Xamarin.Forms.Color.CornflowerBlue;
            string pizzaBaseSelection = BasePickerLabel.Text;
           
            if (pizzaBaseSelection.Contains("Pesto"))
            {
                ToppingsPageModel.ThisPizza.ChangePizzaBase(PizzaBase.Pesto);
            }
            else if (pizzaBaseSelection.Contains("White"))
            {
                ToppingsPageModel.ThisPizza.ChangePizzaBase(PizzaBase.White);
            }
            else
            {
                ToppingsPageModel.ThisPizza.ChangePizzaBase(PizzaBase.Regular);
            }
            //NOT SURE WHAT OF THIS IS STILL NEEDED AFTER REwork
            //Toppings thisPizzaToppings = ToppingsPageModel.Toppings;

            ////Must explicitly set so that MenuHeaderModel is updated.
            //ToppingsPageModel.Toppings = thisPizzaToppings;
            ////MenuHeaderModel.GetInstance().UpdateItemTotal(thisPizza.BasePrice, ToppingsPageModel.Toppings.ToppingsTotal);
        }


        private void CookPickerTapped(object sender, EventArgs e)
        {
            CookPicker.Focus();
        }

        private void OnCookPickerSelectionChanged(object sender, EventArgs e)
        {
            CookPickerLabel.Text = CookPicker.Items[CookPicker.SelectedIndex];
            CookPickerLabel.BackgroundColor = Xamarin.Forms.Color.CornflowerBlue;
            if (CookPickerLabel.Text.Contains("Crispy"))
            {
                ToppingsPageModel.ThisPizza.Toppings.AddTopping(
                  new Topping(ToppingName.CrispyCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Kid"))
            {
                ToppingsPageModel.ThisPizza.Toppings.AddTopping(
                  new Topping(ToppingName.KidCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Light"))
            {
                ToppingsPageModel.ThisPizza.Toppings.AddTopping(
                  new Topping(ToppingName.LightCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
        }

        private async void OtherToppingsTapped(object sender, EventArgs e)
        {
            List<Topping> toppingsAlreadySelected = new List<Topping>();
            foreach (var topping in ToppingsPageModel.ThisPizza.Toppings.CurrentToppings)
            {
                if (topping.ToppingName == ToppingName.ButterOk ||
                    topping.ToppingName == ToppingName.CutInto12 ||
                    topping.ToppingName == ToppingName.Joiner ||
                    topping.ToppingName == ToppingName.NoCut ||
                    topping.ToppingName == ToppingName.OutFirst ||
                    topping.ToppingName == ToppingName.KidCook ||
                    topping.ToppingName == ToppingName.SaladWithOrder ||
                    topping.ToppingName == ToppingName.SliceCutInHalfSamePlate ||
                    topping.ToppingName == ToppingName.SliceCutInHalfSepPlate ||
                    topping.ToppingName == ToppingName.TakeoutBring2Table ||
                    topping.ToppingName == ToppingName.TakeoutKeepInKitch)
                {
                    toppingsAlreadySelected.Add(topping);
                }
            }
           
            ToppingsOtherPage = new ToppingsOtherPage(toppingsAlreadySelected);
            ToppingsOtherPage.Disappearing += (newSender, newE) => { this.OnAppearing(newSender, newE); };
          
            await Navigation.PushModalAsync(ToppingsOtherPage);
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            if (ToppingsOtherPage != null && ToppingsOtherPage.SelectedOtherToppings.Count > 0)
            {
                ToppingsPageModel.ThisPizza.Toppings.AddToppings(ToppingsOtherPage.SelectedOtherToppings);
            }
    
            //not sure if needed...
            //ToppingsPageModel.Toppings = Toppings;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ToppingsListView.ItemSelected -= ToppingsListView_ItemSelected;
        }
        #endregion
    }
}