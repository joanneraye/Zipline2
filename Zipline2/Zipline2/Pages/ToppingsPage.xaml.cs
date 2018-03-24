using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;
using Zipline2.Models;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.DictionaryKeys;
using Zipline2.BusinessLogic.Enums;
using System.Drawing;
using static Zipline2.PageModels.ToppingsPageModel;
using CarouselView.FormsPlugin.Abstractions;
using Zipline2.Views;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToppingsPage : BasePage
	{
        #region Private Variables
        private ToppingsPageModel ToppingsPageModel;
        private Toppings Toppings;
        private Pizza CurrentPizza;
        private int CarouselSelectedPosition { get; set; }
        private ToppingsOtherPage ToppingsOtherPage { get; set; }
        #endregion

        #region Constructor
        public ToppingsPage (Pizza currentPizza)
		{
            ToppingsPageModel = new ToppingsPageModel(currentPizza);
            InitializeComponent ();
            BindingContext = ToppingsPageModel;
            CurrentPizza = currentPizza;
           
            MenuHeaderModel.GetInstance().PizzaName = currentPizza.ItemName;
            Toppings = new Toppings(currentPizza);
            if (currentPizza.MajorMamaInfo == MajorOrMama.Major)
            {
                //TODO:  Combine the two following?
                ToppingsPageModel.SelectMajorToppings();
                Toppings.AddMajorToppings();
            }
        }
        #endregion

        #region Methods

        private void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            ToppingSelection selectedItem = e.Item as ToppingSelection;
            int indexOfItemSelected = selectedItem.SelectionIndex;

            //Can't change ListView directly - must change underlying data.  Get this data by the index.
            ToppingSelection thisSelection = ToppingsPageModel.ToppingSelectionsList[indexOfItemSelected];
            if (thisSelection.ListTopping.ToppingName == ToppingName.HalfMajor)
            {
                ProcessHalfMajorToppingSelection(thisSelection);
            }
            else
            {
                if (thisSelection.ListItemIsSelected)   //If selected, toggle to unselect...
                {
                    thisSelection.ListTopping.SequenceSelected = 0;
                    Toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
                }
                else
                {
                    thisSelection.ListTopping.SequenceSelected = Toppings.CurrentToppings.Count + 1;
                    Toppings.AddTopping(thisSelection.ListTopping);
                }
                thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;
                //Appearance...
                if (thisSelection.ListItemIsSelected)
                {
                    thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    thisSelection.ButtonWSelected = true;
                }
                else
                {
                    thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    thisSelection.ButtonASelected = false;
                    thisSelection.ButtonBSelected = false;
                    thisSelection.ButtonWSelected = false;
                }
            }
           
            //NOTE:  Modifying ToppingsPageModel.Toppings directly instead of 
            //explicitly setting it here does not trigger bindings.
            ToppingsPageModel.Toppings = Toppings;
        }

        //For selection or deselection of the Half Major topping.
        private void ProcessHalfMajorToppingSelection(ToppingSelection halfMajorSelection)
        {
            if (halfMajorSelection.ListItemIsSelected)   //If selected, toggle to unselect...
            {
                Toppings.RemoveTopping(ToppingName.Mushrooms, false);
                Toppings.RemoveTopping(ToppingName.BlackOlives, false);
                Toppings.RemoveTopping(ToppingName.GreenPeppers, false);
                Toppings.RemoveTopping(ToppingName.Onion, false);
                Toppings.RemoveTopping(ToppingName.Pepperoni, false);
                Toppings.RemoveTopping(ToppingName.Sausage, false);
                Toppings.UpdateToppingsTotal();

                foreach (var toppingSelection in ToppingsPageModel.ToppingSelectionsList)
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
                        toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    }
                }
                halfMajorSelection.SelectionColor = Xamarin.Forms.Color.Black;
                halfMajorSelection.ButtonWSelected = false;
                halfMajorSelection.ButtonASelected = false;
                halfMajorSelection.ButtonBSelected = false;
            }
            else
            {
                ToppingsPageModel.SelectMajorToppings(halfMajorSelection.ListTopping.ToppingWholeHalf);
                Toppings.AddMajorToppingsToHalf(ToppingWholeHalf.HalfA);
                
                halfMajorSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                halfMajorSelection.ButtonASelected = true;
                //halfMajorSelection.AColor = Xamarin.Forms.Color.CornflowerBlue;
            }
            halfMajorSelection.ListItemIsSelected = !halfMajorSelection.ListItemIsSelected;
        }

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
                CurrentPizza.ChangePizzaBase(PizzaBase.Pesto);
            }
            else if (pizzaBaseSelection.Contains("White"))
            {
                CurrentPizza.ChangePizzaBase(PizzaBase.White);
            }
            else
            {
                CurrentPizza.ChangePizzaBase(PizzaBase.Regular);
            }
            Toppings thisPizzaToppings = ToppingsPageModel.Toppings;
            thisPizzaToppings.UpdateToppingsTotal();

            //Must explicitly set so that MenuHeaderModel is updated.
            ToppingsPageModel.Toppings = thisPizzaToppings;
            //MenuHeaderModel.GetInstance().UpdateItemTotal(thisPizza.BasePrice, ToppingsPageModel.Toppings.ToppingsTotal);
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
                Toppings.AddTopping(
                  new Topping(ToppingName.CrispyCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Kid"))
            {
                Toppings.AddTopping(
                  new Topping(ToppingName.KidCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Light"))
            {
                Toppings.AddTopping(
                  new Topping(ToppingName.LightCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            ToppingsPageModel.Toppings = Toppings;
        }

        private async void OtherToppingsTapped(object sender, EventArgs e)
        {
            //Need to pass to ToppingsOtherPage what should already be 
            //selected somehow??  Pass List<Topping> of items already selected?
            //TODO:  Create a list of Topping objects from ToppingPageModel toppings
            //      pertaining to the other toppings.... 
            List<Topping> toppingsAlreadySelected = new List<Topping>();
            foreach (var topping in ToppingsPageModel.Toppings.CurrentToppings)
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
            Toppings.AddToppings(ToppingsOtherPage.SelectedOtherToppings);
            ToppingsPageModel.Toppings = Toppings;
        }
        #endregion
    }
}