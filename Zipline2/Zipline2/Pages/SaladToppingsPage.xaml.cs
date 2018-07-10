using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Models;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaladToppingsPage : BasePage
	{
        SaladToppingsPageModel SaladToppingsPageModel { get; set; }
        public SaladToppingsPage (Salad thisSalad)
		{
            SaladToppingsPageModel = new SaladToppingsPageModel(thisSalad);
            BindingContext = SaladToppingsPageModel;

            InitializeComponent();
            SaladToppingsPageModel.ToppingFooterPageModel = ToppingFooter.ToppingFooterPageModel;
            SaladToppingsListView.ItemSelected += SaladToppingsListView_ItemSelected;
            string saladSizeDisplayName;
            if (thisSalad.SizeOfSalad == BusinessLogic.Enums.SaladSize.LunchSpecial)
            {
                saladSizeDisplayName = "Lunch Special";
            }
            else
            {
                saladSizeDisplayName = thisSalad.SizeOfSalad.ToString();
            }
            string saladToppingsTitle = "TBL " + BusinessLogic.OrderManager.Instance.CurrentTableName + " - Toppings for " + saladSizeDisplayName + " Salad";
            this.ToolbarItems.Add(new ToolbarItem { Text = saladToppingsTitle });
        }

        private void SaladToppingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var letslookate = e;
            return;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SaladToppingsPageModel.NavigateToPizzaPage += HandleNavigateToPizzaPage;

        }

        void HandleNavigateToPizzaPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SaladToppingsPageModel.NavigateToPizzaPage -= HandleNavigateToPizzaPage;
        }

    }
}