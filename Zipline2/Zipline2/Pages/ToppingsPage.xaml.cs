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
        private Toppings toppings;
        private Pizza thisPizza;
        private int CarouselSelectedPosition { get; set; }
        #endregion

        #region Constructor
        public ToppingsPage (PizzaType toppingType)
		{
            ToppingsPageModel = new ToppingsPageModel(toppingType);
            InitializeComponent ();
            BindingContext = ToppingsPageModel;
            toppings = new Toppings(toppingType);
            //BasePicker.SelectedIndex = 0;
            //CookPicker.SelectedIndex = 0;
            var currentOrderItem = OrderManager.GetInstance().OrderItemInProgress;
            thisPizza = (Pizza)currentOrderItem;

            if (thisPizza.MajorMamaInfo == MajorOrMama.Major)
            {
                //TODO:  Combine the two following?
                ToppingsPageModel.SelectMajorToppings();
                toppings.AddMajorToppings();
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
                    toppings.RemoveTopping(thisSelection.ListTopping.ToppingName);
                }
                else
                {
                    thisSelection.ListTopping.SequenceSelected = toppings.CurrentToppings.Count + 1;
                    toppings.AddTopping(thisSelection.ListTopping);
                }
                thisSelection.ListItemIsSelected = !thisSelection.ListItemIsSelected;
                //Appearance...
                if (thisSelection.ListItemIsSelected)
                {
                    thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                    thisSelection.WColor = Xamarin.Forms.Color.CornflowerBlue;
                }
                else
                {
                    thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    thisSelection.ButtonASelected = false;
                   // thisSelection.AColor = Xamarin.Forms.Color.Black;
                    thisSelection.BColor = Xamarin.Forms.Color.Black;
                    thisSelection.WColor = Xamarin.Forms.Color.Black;
                }
            }
           
            //NOTE:  Modifying ToppingsPageModel.Toppings directly instead of 
            //explicitly setting it here does not trigger bindings.
            ToppingsPageModel.Toppings = toppings;
        }

        //For selection or deselection of the Half Major topping.
        private void ProcessHalfMajorToppingSelection(ToppingSelection halfMajorSelection)
        {
            if (halfMajorSelection.ListItemIsSelected)   //If selected, toggle to unselect...
            {
                toppings.RemoveTopping(ToppingName.Mushrooms, false);
                toppings.RemoveTopping(ToppingName.BlackOlives, false);
                toppings.RemoveTopping(ToppingName.GreenPeppers, false);
                toppings.RemoveTopping(ToppingName.Onion, false);
                toppings.RemoveTopping(ToppingName.Pepperoni, false);
                toppings.RemoveTopping(ToppingName.Sausage, false);
                toppings.UpdateToppingsTotal();

                foreach (var toppingSelection in ToppingsPageModel.ToppingSelectionsList)
                {
                    if (toppingSelection.ListTopping.ToppingName == ToppingName.Mushrooms ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.GreenPeppers ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Onion ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Pepperoni ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.Sausage ||
                        toppingSelection.ListTopping.ToppingName == ToppingName.BlackOlives)
                    {
                        toppingSelection.WColor = Xamarin.Forms.Color.Black;
                        toppingSelection.ButtonASelected = false;
                        //toppingSelection.AColor = Xamarin.Forms.Color.Black;
                        toppingSelection.BColor = Xamarin.Forms.Color.Black;
                        toppingSelection.SelectionColor = Xamarin.Forms.Color.Black;
                    }
                }
                halfMajorSelection.SelectionColor = Xamarin.Forms.Color.Black;
                halfMajorSelection.ButtonASelected = false;
                //halfMajorSelection.AColor = Xamarin.Forms.Color.Black;
                halfMajorSelection.BColor = Xamarin.Forms.Color.Black;
                halfMajorSelection.WColor = Xamarin.Forms.Color.Black;

            }
            else
            {
                ToppingsPageModel.SelectMajorToppings(halfMajorSelection.ListTopping.ToppingWholeHalf);
                toppings.AddMajorToppingsToHalf(ToppingWholeHalf.HalfA);
                
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
        }

        private void CookPickerTapped(object sender, EventArgs e)
        {
            CookPicker.Focus();
        }

        private void OnCookPickerSelectionChanged(object sender, EventArgs e)
        {
            CookPickerLabel.Text = CookPicker.Items[CookPicker.SelectedIndex];
        }

        private void OtherPickerTapped(object sender, EventArgs e)
        {
            OtherPicker.Focus();
        }

        private void OnOtherPickerSelectionChanged(object sender, EventArgs e)
        {
            OtherPickerLabel.Text = OtherPicker.Items[OtherPicker.SelectedIndex];
        }
        #endregion
    }
}