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
	public partial class DessertPage : BasePage
	{
        private DessertPageModel ThisDessertPageModel;
        private bool isEditingDrink;

        public DessertPage(Dessert dessertForEdit = null)
		{
            if (dessertForEdit == null)
            {
                ThisDessertPageModel = new DessertPageModel();
            }
            else
            {
                isEditingDrink = true;
                ThisDessertPageModel = new DessertPageModel(dessertForEdit);
            }
            InitializeComponent();
            BindingContext = ThisDessertPageModel;
            Footer.FooterPageModel.IsDessertPageDisplayed = true;
            Footer.FooterPageModel.DisplayAddToOrderButton = true;
            Footer.FooterPageModel.AddToOrderButtonText = "Add Desserts";
            Footer.FooterPageModel.ThisDessertPageModel = ThisDessertPageModel;
            string dessertTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Desserts";
            this.ToolbarItems.Add(new ToolbarItem { Text = dessertTitle });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ThisDessertPageModel.NavigateToOrderPage += HandleNavigateToOrderPage;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ThisDessertPageModel.NavigateToOrderPage -= HandleNavigateToOrderPage;
        }

        private void OnDessertRowSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedObject = e.SelectedItem;
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }

        void HandleNavigateToOrderPage(object sender, EventArgs e)
        {
            try
            {
                var currentMainPage = Application.Current.MainPage as MasterDetailPage;
                currentMainPage.Detail = new NavigationPage(new OrderPage());
                Application.Current.MainPage = currentMainPage;
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
          
        }
    }
}