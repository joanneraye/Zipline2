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

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ToppingsPage : BasePage
	{
        #region Private Variables
        private Toppings toppings;
        private ToppingsPageModel ToppingsPageModel;
        private Pizza thisPizza;
        #endregion

        #region Constructor
        public ToppingsPage (PizzaType toppingType)
		{
            ToppingsPageModel = new ToppingsPageModel(toppingType);
            InitializeComponent ();
            BindingContext = ToppingsPageModel;
            var currentOrderItem = OrderManager.GetInstance().OrderItemInProgress;
            thisPizza = (Pizza)currentOrderItem;
            toppings = new Toppings(toppingType);
            if (thisPizza.MajorMamaInfo == MajorOrMama.Major)
            {
                ToppingsPageModel.SelectMajorToppings();
                toppings.AddMajorToppings();
            }
            MenuHeaderModel.GetInstance().ItemTotal = Pizza.CalculatePizzaItemCostNoTax(toppingType, 1, toppings);
        }
        #endregion

        #region Methods

        private void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            ToppingSelection selectedItem = e.Item as ToppingSelection;
            int indexOfItemSelected = selectedItem.SelectionIndex;

            //Can't change ListView directly - must change underlying data.  Get this data by the index.
            ToppingSelection thisSelection = ToppingsPageModel.ToppingSelectionsList[indexOfItemSelected];

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

            //TODO:  Possibly this should be stored outside of ToppingsPage....
            MenuHeaderModel.GetInstance().ItemTotal = Pizza.CalculatePizzaItemCostNoTax(thisPizza.PizzaType, 1, toppings);

            if (thisSelection.ListItemIsSelected)
            {
                thisSelection.SelectionColor = Xamarin.Forms.Color.CornflowerBlue;
                thisSelection.WColor = Xamarin.Forms.Color.CornflowerBlue;
            }
            else
            {
                thisSelection.SelectionColor = Xamarin.Forms.Color.Black;
                thisSelection.AColor = Xamarin.Forms.Color.Black;
                thisSelection.BColor = Xamarin.Forms.Color.Black;
                thisSelection.WColor = Xamarin.Forms.Color.Black;

            }

            //Update ToppingsPageModel with latest Toppings.
            ToppingsPageModel.Toppings = toppings;
        }
        #endregion
    }
}