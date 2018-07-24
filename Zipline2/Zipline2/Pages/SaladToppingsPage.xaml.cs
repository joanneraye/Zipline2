using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Models;
using Zipline2.MyEventArgs;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaladToppingsPage : BasePage
	{
        SaladToppingsPageModel SaladToppingsPageModel { get; set; }
        Salad ThisSalad { get; set; }

        public SaladToppingsPage (Salad thisSalad)
		{
            ThisSalad = thisSalad;
            string saladSizeDisplayName;
            if (thisSalad.SizeOfSalad == BusinessLogic.Enums.SaladSize.LunchSpecial)
            {
                saladSizeDisplayName = "Lunch Special";
                //button on bottom should say add special to order instead of add salad to order.
            }
            else
            {
                saladSizeDisplayName = thisSalad.SizeOfSalad.ToString();
            }
            SaladToppingsPageModel = new SaladToppingsPageModel(thisSalad);
            BindingContext = SaladToppingsPageModel;
            InitializeComponent();
            SaladToppingsPageModel.ToppingFooterPageModel = ToppingFooter.ToppingFooterPageModel;
            SaladToppingsListView.ItemSelected += SaladToppingsListView_ItemSelected;
           
            string saladToppingsTitle = "TBL " + BusinessLogic.OrderManager.Instance.CurrentTableName + " - Toppings for " + saladSizeDisplayName + " Salad";
            this.ToolbarItems.Add(new ToolbarItem { Text = saladToppingsTitle });
        }

        private void SaladToppingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SaladToppingsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SaladToppingsPageModel.NavigateToPizzaPage += HandleNavigateToPizzaPage;
            SaladToppingsPageModel.NavigateToPizzaToppingsPage += HandleNavigateToPizzaToppingsPage;

        }

        void HandleNavigateToPizzaPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }

        async void HandleNavigateToPizzaToppingsPage(object sender, EventArgs e)
        {
            Pizza lunchSpecialPizza = OrderManager.Instance.GetSpecialSliceWithSalad(ThisSalad.ComboId);
            await Navigation.PushAsync(new PizzaToppingsPage(lunchSpecialPizza));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SaladToppingsPageModel.NavigateToPizzaPage -= HandleNavigateToPizzaPage;
        }

    }
}