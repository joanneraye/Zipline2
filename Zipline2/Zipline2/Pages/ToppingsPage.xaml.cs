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

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToppingsPage : BasePage
	{
        ToppingsPageModel ToppingsPageModel;
        private int NumberOfToppings;
		public ToppingsPage ()
		{
            NumberOfToppings = 0;
            ToppingsPageModel = new ToppingsPageModel();
            InitializeComponent ();
            BindingContext = ToppingsPageModel;
        }

        private void ListToppingSelected(object sender, EventArgs e)
        {
            var list = sender as ListView;

            ToppingsPageModel.ToppingSelection toppingSelection = (ToppingsPageModel.ToppingSelection)list.SelectedItem;
            int indexOfItemSelected = toppingSelection.ToppingIndex;
            if (toppingSelection.ListTopping.IsSelected)
            {
                NumberOfToppings--;
                toppingSelection.ListTopping.OrderSelected = 0;
            }
            else
            {
                NumberOfToppings++;
                toppingSelection.ListTopping.OrderSelected = NumberOfToppings;
            }
            
            toppingSelection.ListTopping.IsSelected = !toppingSelection.ListTopping.IsSelected;
            if (toppingSelection.ListTopping.IsSelected)
            {
                toppingSelection.SelectionColor = Color.Orange;
            }
            else
            {
                toppingSelection.SelectionColor = Color.Black;
            }
           
            //ToppingsListView[..index...] - how to highlight this row???
            //Highlight row, Select whole, and turn switch to on, increment
            //or decrement number selected.


            //What is the row index?  Can I get the row and select the 
            //0 index on the picker item?

            //var list = sender as ListView;
            //Topping topping = (Topping)list.SelectedItem;
            //topping.IsSelected = true;
        }
    }
}