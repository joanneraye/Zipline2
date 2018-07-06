using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.PageModels;
using static Zipline2.PageModels.DrinksPageModel;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrinksPage : BasePage
	{

        private DrinksPageModel thisDrinksPageModel; 
        public DrinksPage ()
		{
			InitializeComponent ();
            thisDrinksPageModel = new DrinksPageModel();
            BindingContext = thisDrinksPageModel;
            Footer.FooterPageModel.IsDrinkPageDisplayed = true;
            Footer.FooterPageModel.DisplayAddToOrderButton = true;
            Footer.FooterPageModel.AddToOrderButtonText = "Add Drinks To Order";
            Footer.FooterPageModel.ThisDrinksPageModel = thisDrinksPageModel;
            string drinkTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Drinks";
            this.ToolbarItems.Add(new ToolbarItem { Text = drinkTitle });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            thisDrinksPageModel.NavigateToOrderPage += HandleNavigateToOrderPage;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            thisDrinksPageModel.NavigateToOrderPage -= HandleNavigateToOrderPage;
        }

        void HandleNavigateToOrderPage(object sender, EventArgs e)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new OrderPage());
            Application.Current.MainPage = currentMainPage;
        }

    }
}