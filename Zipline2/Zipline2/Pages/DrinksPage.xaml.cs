using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.Models;
using Zipline2.MyEventArgs;
using Zipline2.PageModels;
using static Zipline2.PageModels.DrinksPageModel;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DrinksPage : BasePage
	{

        private DrinksPageModel thisDrinksPageModel;
        private bool isEditingDrink;
        public DrinksPage (Drink drinkForEdit = null)
		{
            try
            {
                if (drinkForEdit == null)
                {
                    thisDrinksPageModel = new DrinksPageModel();
                }
                else
                {
                    isEditingDrink = true;
                    thisDrinksPageModel = new DrinksPageModel(drinkForEdit);
                }

                try
                {
                    InitializeComponent();
                }
                catch (Exception ex)
                {
                    var error = ex.InnerException;
                    throw;
                }
              

                BindingContext = thisDrinksPageModel;

                Footer.FooterPageModel.IsDrinkPageDisplayed = true;
                Footer.FooterPageModel.DisplayAddToOrderButton = true;
                Footer.FooterPageModel.AddToOrderButtonText = "Add Drinks";
                Footer.FooterPageModel.ThisDrinksPageModel = thisDrinksPageModel;
                string drinkTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Drinks";
                this.ToolbarItems.Add(new ToolbarItem { Text = drinkTitle });
                thisDrinksPageModel.ScrollToTopOfList += HandleScrollToTopOfList;
                MenuScrollView.Scrolled += MenuScrollView_Scrolled;
            }
            catch (Exception ex)
            {
                var error = ex.InnerException;
                throw;
            }
        }

        private void MenuScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollX > 200)
            {
                thisDrinksPageModel.OnDrinksSelected(BusinessLogic.Enums.DrinkCategory.BottleWine);
            }
            else if (e.ScrollX > 150)
            {
                thisDrinksPageModel.OnDrinksSelected(BusinessLogic.Enums.DrinkCategory.GlassWine);
            }
            else if (e.ScrollX > 100)
            {
                thisDrinksPageModel.OnDrinksSelected(BusinessLogic.Enums.DrinkCategory.BottledBeer);
            }
           
            else if (e.ScrollX > 50)
            {
                thisDrinksPageModel.OnDrinksSelected(BusinessLogic.Enums.DrinkCategory.DraftBeer);
            }
            else
            {
                thisDrinksPageModel.OnDrinksSelected(BusinessLogic.Enums.DrinkCategory.SoftDrink);
            }
        }

           
        protected override void OnAppearing()
        {
            base.OnAppearing();
            thisDrinksPageModel.NavigateToOrderPage += HandleNavigateToOrderPage;
            if (isEditingDrink)
            {
                HandleScrollToItem();
            }
        }

        private void OnDrinkRowSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedObject = e.SelectedItem;
            if (sender is ListView)
            {
                ((ListView)sender).SelectedItem = null;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            thisDrinksPageModel.NavigateToOrderPage -= HandleNavigateToOrderPage;
        }

        private void HandleScrollToTopOfList(object sender, EventArgs e)
        {
            //DrinksListView.ScrollTo(thisDrinksPageModel.DrinkDisplayItems[0], ScrollToPosition.MakeVisible, false);
            //DrinksListView.ScrollTo(null, ScrollToPosition.Start, false);
        }

       
        async private void HandleScrollToItem()
        {
            //Wait so that list renders.
            await Task.Delay(500);
            DrinkDisplayRow scrollToThisItem = thisDrinksPageModel.DrinkDisplayItems[thisDrinksPageModel.DrinkForEditIndex];
            //DrinksListView.ScrollTo(scrollToThisItem, ScrollToPosition.MakeVisible, false);
        }

        void HandleNavigateToOrderPage(object sender, EventArgs e)
        {
            var currentMainPage = Application.Current.MainPage as MasterDetailPage;
            currentMainPage.Detail = new NavigationPage(new OrderPage());
            Application.Current.MainPage = currentMainPage;
        }

    }
}