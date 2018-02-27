using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using Zipline2.BusinessLogic;

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
                PizzaSize.Slice.ToString(),
                PizzaSize.Indy.ToString(),
                PizzaSize.Medium.ToString(),
                PizzaSize.Large.ToString()
            };

            var majorTypes = new List<string>
            {
                MajorPizzaType.Slice.ToString(),
                MajorPizzaType.Indy.ToString(),
                MajorPizzaType.Medium.ToString(),
                MajorPizzaType.Large.ToString(),
                MajorPizzaType.Mfp.ToString(),
                MajorPizzaType.SatchPan.ToString()
            };

            CheesePizzaPicker.ItemsSource = cheeseTypes;
            CheesePizzaPicker.SelectedIndex = 0;
            CheesePizzaPicker.Focus();
            MajorPizzaPicker.ItemsSource = majorTypes;
            MajorPizzaPicker.SelectedIndex = 0;            
		}

        async Task DisplayToppingsPage()
        {
            //Update the current table to indicate it is occupied.
            Table currentTable = OrderManager.GetInstance().GetCurrentTable();
            currentTable.IsOccupied = true;
            OrderManager.GetInstance().UpdateCurrentTable(currentTable);
            await Navigation.PushAsync(new ToppingsPage());
        }

        async Task OnPlusCheesePizza(object sender, EventArgs e)
        {
            //Get size chosen from picker.
            var pizzaSize = (PizzaSize)Enum.Parse(typeof(PizzaSize), 
                                    CheesePizzaPicker.SelectedItem.ToString());

            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = pizzaSize,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);
            
            await DisplayToppingsPage();
        }

      
        async void OnPlusMajorPizza(object sender, EventArgs e)
        {
            //Get size chosen from picker.
            var majorPizzaType = (MajorPizzaType)Enum.Parse(typeof(MajorPizzaType),
                                    MajorPizzaPicker.SelectedItem.ToString());

            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                MajorOrMama = MajorOrMama.Major,
                NumberOfItems = 1
            };

            switch (majorPizzaType)
            {
                case MajorPizzaType.Indy:
                    guiData.PizzaSize = PizzaSize.Indy;
                    guiData.PizzaType = PizzaType.RegularThin;
                    break;
                case MajorPizzaType.Large:
                    guiData.PizzaSize = PizzaSize.Large;
                    guiData.PizzaType = PizzaType.RegularThin;
                    break;
                case MajorPizzaType.Medium:
                    guiData.PizzaSize = PizzaSize.Large;
                    guiData.PizzaType = PizzaType.RegularThin;
                    break;
                case MajorPizzaType.Mfp:
                    guiData.PizzaSize = PizzaSize.Large;
                    guiData.PizzaType = PizzaType.Mfp;
                    break;
                case MajorPizzaType.SatchPan:
                    guiData.PizzaSize = PizzaSize.Large;
                    guiData.PizzaType = PizzaType.SatchPan;
                    break;
                case MajorPizzaType.Slice:
                    guiData.PizzaSize = PizzaSize.Slice;
                    guiData.PizzaType = PizzaType.RegularThin;
                    break;
            }

            OrderManager.GetInstance().HandleOrderItem(guiData);
           
            //Allow user to modify Major pizza
            await DisplayToppingsPage();

        }

        async Task OnMfpPizza(object sender, EventArgs e)
        {
            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                PizzaType = PizzaType.Mfp,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);

            await DisplayToppingsPage();
        }

        async Task OnSatchPanPizza(object sender, EventArgs e)
        {
            //Send info to OrderManager
            var guiData = new CustomerSelections
            {
                MenuItemGeneralCategory = MenuCategory.Pizza,
                PizzaSize = PizzaSize.OneSize,
                PizzaType = PizzaType.SatchPan,
                NumberOfItems = 1
            };

            OrderManager.GetInstance().HandleOrderItem(guiData);

            await DisplayToppingsPage();
        }
    }
}