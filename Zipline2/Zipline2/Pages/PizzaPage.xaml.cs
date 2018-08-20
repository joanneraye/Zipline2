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
            MenuHeaderModel.Instance.ShowPlusMinus = false;
            string pizzaTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Pizza";
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
            BindingContext = pizzaPageModel;
            Footer.FooterPageModel.IsPizzaPageDisplayed = true;
            Footer.FooterPageModel.DisplayAddToOrderButton = false;
        }
       
        #endregion

        #region Methods
       
        protected override void OnAppearing()
        {
            base.OnAppearing();
            pizzaPageModel.NavigateToToppingsPage += HandleNavigateToToppingsPage;
            pizzaPageModel.NavigateToCalzoneToppingsPage += HandleNavigateToCalzoneToppingsPage;

        }
        async void HandleNavigateToToppingsPage(object sender, ToppingsPageEventArgs e)
        {
            await Navigation.PushAsync(new PizzaToppingsPage(e.CurrentPizza));
        }

        async void HandleNavigateToCalzoneToppingsPage(object sender, CalzoneToppingsPageEventArgs e)
        {
            await Navigation.PushAsync(new CalzoneToppingsPage(e.CurrentCalzone));
        }

        //void HandleNavigateToPizzaPage(object sender, EventArgs e)
        //{
        //    var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
        //    currentMainPage.Detail = new NavigationPage(new PizzaPage());
        //    Application.Current.MainPage = currentMainPage;
        //}


        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            pizzaPageModel.NavigateToToppingsPage -= HandleNavigateToToppingsPage;
            pizzaPageModel.NavigateToCalzoneToppingsPage -= HandleNavigateToCalzoneToppingsPage;
        }
        #endregion
    }
}