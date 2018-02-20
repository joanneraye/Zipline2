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

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PizzaPage : BasePage
	{
		public PizzaPage ()
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
		}

        async Task OnPlusCheesePizza(object sender, EventArgs e)
        {
            var cheesePizzaSize = (CheesePizzaSize)Enum.Parse(typeof(CheesePizzaSize), 
                                    CheesePizzaPicker.SelectedItem.ToString());

            App.PizzaInProgress = new Pizza(cheesePizzaSize, 1);   
            
            App.OrderInProgress.AddItemToOrder(App.PizzaInProgress);

            await Navigation.PushAsync(new ToppingsPage());

            //TODO:
            //Display price of this item and total of check at top of screen.
            //Save order locally and/or remotely??
        }

        void OnPlusButtonClicked(object sender, EventArgs e)
        {
        }

    }
}