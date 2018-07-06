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
	public partial class OrderPage : BasePage
	{
        OrderPageModel orderPageModel;
		public OrderPage ()
		{
            orderPageModel = new OrderPageModel();
            InitializeComponent();
            BindingContext = orderPageModel;
            Footer.FooterPageModel.IsOrderPageDisplayed = true;
            Footer.FooterPageModel.DisplayAddToOrderButton = false;
            Footer.FooterPageModel.ThisOrderPageModel = orderPageModel;
            string pizzaTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Order";
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem { Text = pizzaTitle, Priority = 0 });
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            orderPageModel.NavigateToTablesPage += HandleNavigateToTablesPage;

        }
        void HandleNavigateToTablesPage(object sender, EventArgs e)
        {
            if (OrderManager.Instance.OrderInProgress.OrderItems.Count == 0)
            {
                Tables.AllTables[OrderManager.Instance.CurrentTableIndex].IsOccupied = false;
            }
            else
            {
                DisplayAlert("NOTE:", "During this phase of testing, no orders are being sent to the server or kitchen.", "OK");
            }
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new TablesPage());
            Application.Current.MainPage = currentMainPage;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            orderPageModel.NavigateToTablesPage -= HandleNavigateToTablesPage;
        }
    }
}