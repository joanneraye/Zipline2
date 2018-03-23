using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PizzaBasePage : BasePage
    {
        private string PizzaBaseSelection;
        public PizzaBasePage()
        {
            InitializeComponent();
            BindingContext = new PizzaBasePageModel();
        }

        private void BaseItemTapped(object sender, ItemTappedEventArgs e)
        {
            PizzaBaseSelection = e.Item.ToString();
            OrderItem thisItem = OrderManager.GetInstance().OrderItemInProgress;
            Pizza thisPizza;
            if (thisItem is Pizza)
            {
                thisPizza = thisItem as Pizza;
            }
            else
            {
                return;
            }
            if (PizzaBaseSelection.Contains("Pesto"))
            {
                thisPizza.Base = BusinessLogic.Enums.PizzaBase.Pesto;
            }
            else
            {
                thisPizza.Base = BusinessLogic.Enums.PizzaBase.White;
            }

        }
        private void CookItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }
}