using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToppingsOtherPage : BasePage
	{
        public List<Topping> SelectedOtherToppings { get; set; }
		public ToppingsOtherPage (List<Topping> toppingsAlreadySelected)
		{
			InitializeComponent ();
            //TODO:  If any of these items are already selected (from toppings in ToppingsPage),
            //  preselect them in ToppingsOtherPageModel?  If receive List<Topping>, those can 
            //  be the new SelectedOtherToppings.  
            BindingContext = new ToppingsOtherPageModel(toppingsAlreadySelected);
            SelectedOtherToppings = new List<Topping>();
        }

        private void ToppingsOtherItemTapped(object sender, ItemTappedEventArgs e)
        {
            //TODO:  Determine if selected or de-selected....
            var selectedItem = e.Item;
            if (selectedItem is ToppingsOtherPageModel.OtherToppingSelection)
            {
                ToppingsOtherPageModel.OtherToppingSelection thisSelection = selectedItem as ToppingsOtherPageModel.OtherToppingSelection;
                thisSelection.IsOtherToppingItemSelected = !thisSelection.IsOtherToppingItemSelected;
                SelectedOtherToppings.Add(thisSelection.OtherToppingsListTopping);
            }
        }

        private async void OnDoneClicked(object sender, ClickedEventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnCancelClicked(object sender, ClickedEventArgs e)
        {
            SelectedOtherToppings = new List<Topping>();
            await Navigation.PopModalAsync();
        }

    }
}