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
using Zipline2.PageModels;
using Zipline2.MyEventArgs;
//using Zipline2.CustomControls;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PizzaPage : BasePage
	{
        private PizzaPageModel pizzaPageModel;

        #region Constructor
        public PizzaPage()
        {
            pizzaPageModel = new PizzaPageModel();
      
            InitializeComponent();
            string pizzaTitle = OrderManager.Instance.CurrentTableName + " Pizza";
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
            //this.ToolbarItems.Add(new ToolbarItem { Text = "Total $5.00", Priority = 1 });
            BindingContext = pizzaPageModel;
        }
        #endregion

        #region Methods
        protected override void OnAppearing()
        {
            base.OnAppearing();
            pizzaPageModel.NavigateToToppingsPage += HandleNavigateToToppingsPage;
        }
        async void HandleNavigateToToppingsPage(object sender, ToppingsPageEventArgs e)
        {
            await Navigation.PushAsync(new ToppingsPage(e.CurrentPizza));
        }
        #endregion
    }
}