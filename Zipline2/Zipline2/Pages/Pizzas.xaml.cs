using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ButtonCircle;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;

namespace Zipline2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pizzas : BasePage
	{
		public Pizzas (string currentTableNumber)
		{
            InitializeComponent ();
            var cheeseTypes = new List<string>
            {
                CheesePizzaSize.Slice.ToString(),
                CheesePizzaSize.Indy.ToString(),
                CheesePizzaSize.Medium.ToString(),
                CheesePizzaSize.Large.ToString()
            };

            var majorTypes = new List<string>
            {
                "Slice",
                "INDY",
                "Medium",
                "Large",
                "MFP",
                "SATCH-PAN"
            };

            CheesePizzaPicker.ItemsSource = cheeseTypes;
            CheesePizzaPicker.SelectedIndex = 0;
            CheesePizzaPicker.Focus();
            MajorPizzaPicker.ItemsSource = majorTypes;
            MajorPizzaPicker.SelectedIndex = 0;
            TableNumber.Text = "Table: " + currentTableNumber;
		}

        void OnPlusCheesePizza(object sender, EventArgs e)
        {
            
            //See if an order exists.  If it doesn't, create a new order?
            //Can this be done when order added by the Order Class?
            //Do this when select table, then retrieve ??
            Order newOrder = new Order();

            var cheesePizzaSize = (CheesePizzaSize)Enum.Parse(typeof(CheesePizzaSize), 
                                    CheesePizzaPicker.SelectedItem.ToString());

            Pizza newPizzaItem = new Pizza(cheesePizzaSize);   
            
            newOrder.AddItemToOrder(newPizzaItem);

            //TODO:
            //Display price of this item and total of check at top of screen.
            //Save order locally and/or remotely??
        }

        void OnPlusButtonClicked(object sender, EventArgs e)
        {
        }

    }
}