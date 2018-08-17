using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;
using Zipline2.Models;
using Zipline2.BusinessLogic.Enums;
using static Zipline2.PageModels.PizzaToppingsPageModel;
using Zipline2.BusinessLogic;
using System.Windows.Input;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalzoneToppingsPage : BasePage
	{
     
        #region Private Variables
        private CalzoneToppingsPageModel ToppingsPageModel;
        private ToppingsOtherPage ToppingsOtherPage { get; set; }
        private Calzone ThisCalzone { get; set; }

        #endregion

        #region Constructor
        public CalzoneToppingsPage(Calzone thisCalzone)
        {
            ToppingsPageModel = new CalzoneToppingsPageModel(thisCalzone);
            MenuHeaderModel.Instance.ShowPlusMinus = true;
            ThisCalzone = thisCalzone;
            InitializeComponent();
            BindingContext = ToppingsPageModel;
            ToppingsPageModel.ToppingFooterPageModel = ToppingFooter.ToppingFooterPageModel;
            ToppingsListView.ItemSelected += ToppingsListView_ItemSelected;
            this.ToolbarItems.Clear();
            string calzoneTitle = thisCalzone.ItemName + " Toppings";
            this.ToolbarItems.Add(new ToolbarItem { Text = calzoneTitle, Priority = 0 });
            //this.ToolbarItems.Add(new ToolbarItem { Text = string.Format("{0:C}", currentPizza.PricePerItem), Priority = 1 });

            if (thisCalzone.MajorMamaInfo == MajorOrMama.Major)
            {
                ToppingsPageModel.SelectMajorToppings();
                ToppingsPageModel.ThisCalzone.Toppings.AddMajorToppings();
            }
            MessagingCenter.Subscribe<MenuHeaderModel>(this, "HeaderMinusClicked",
            (sender) => { OnHeaderMinusClicked(); });
            MessagingCenter.Subscribe<MenuHeaderModel>(this, "HeaderPlusClicked",
             (sender) => { OnHeaderPlusClicked(); });
        }

        private void OnHeaderPlusClicked()
        {
            if ( ThisCalzone != null)
            {
            ThisCalzone.ItemCount++;
            }
        }

        private void OnHeaderMinusClicked()
        {
            if (ThisCalzone != null)
            {
            ThisCalzone.ItemCount--;
            }
        }

        private void ToppingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ToppingsListView.SelectedItem = null;
        }
        #endregion

        #region Methods


        private void CookPickerTapped(object sender, EventArgs e)
        {
            CookPicker.Focus();
        }

        private void OnCookPickerSelectionChanged(object sender, EventArgs e)
        {
            CookPickerLabel.Text = CookPicker.Items[CookPicker.SelectedIndex];
            CookPickerLabel.BackgroundColor = Xamarin.Forms.Color.CornflowerBlue;
            if (CookPickerLabel.Text.Contains("Crispy"))
            {
                ToppingsPageModel.ThisCalzone.Toppings.AddTopping(
                  new Topping(ToppingName.CrispyCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Kid"))
            {
                ToppingsPageModel.ThisCalzone.Toppings.AddTopping(
                  new Topping(ToppingName.KidCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
            else if (CookPickerLabel.Text.Contains("Light"))
            {
                ToppingsPageModel.ThisCalzone.Toppings.AddTopping(
                  new Topping(ToppingName.LightCook)
                  { SpecialPricingType = SpecialPricingType.Free }, false);
            }
        }

        private async void OtherToppingsTapped(object sender, EventArgs e)
        {
            List<Topping> toppingsAlreadySelected = new List<Topping>();
            foreach (var topping in ToppingsPageModel.ThisCalzone.Toppings.CurrentToppings)
            {
                if (topping.ToppingName == ToppingName.ButterOk ||
                    topping.ToppingName == ToppingName.CutInto12 ||
                    topping.ToppingName == ToppingName.Joiner ||
                    topping.ToppingName == ToppingName.NoCut ||
                    topping.ToppingName == ToppingName.OutFirst ||
                    topping.ToppingName == ToppingName.KidCook ||
                    topping.ToppingName == ToppingName.SaladWithOrder ||
                    topping.ToppingName == ToppingName.SliceCutInHalfSamePlate ||
                    topping.ToppingName == ToppingName.SliceCutInHalfSepPlate ||
                    topping.ToppingName == ToppingName.TakeoutBring2Table ||
                    topping.ToppingName == ToppingName.TakeoutKeepInKitch)
                {
                    toppingsAlreadySelected.Add(topping);
                }
            }
           
            ToppingsOtherPage = new ToppingsOtherPage(toppingsAlreadySelected);
            ToppingsOtherPage.Disappearing += (newSender, newE) => { this.OnAppearing(); };
          
            await Navigation.PushModalAsync(ToppingsOtherPage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (ToppingsOtherPage != null && ToppingsOtherPage.SelectedOtherToppings.Count > 0)
            {
                ToppingsPageModel.ThisCalzone.Toppings.AddToppings(ToppingsOtherPage.SelectedOtherToppings);
            }
            ToppingsPageModel.NavigateToPizzaPage += HandleNavigateToPizzaPage;
            ToppingsPageModel.ChangeHeadingCalzoneName += ChangeCalzoneHeading;

        }
       
        public void HandleNavigateToPizzaPage(object sender, EventArgs e)
        {
            var currentMainPage = (Application.Current.MainPage as MasterDetailPage);
            currentMainPage.Detail = new NavigationPage(new PizzaPage());
            Application.Current.MainPage = currentMainPage;
        }

        public void ChangeCalzoneHeading(object sender, EventArgs e)
        {
            this.ToolbarItems.Clear();
            string calzoneTitle = ThisCalzone.ItemName + " Toppings";
            this.ToolbarItems.Add(new ToolbarItem { Text = calzoneTitle, Priority = 0 });
        }

        protected override void OnDisappearing()
        {
            try
            {
                base.OnDisappearing();
                ToppingsPageModel.NavigateToPizzaPage -= HandleNavigateToPizzaPage;
                ToppingsPageModel.ChangeHeadingCalzoneName -= ChangeCalzoneHeading;
                MessagingCenter.Unsubscribe<string>(this, "HeaderMinusClicked");
                MessagingCenter.Unsubscribe<string>(this, "HeaderPlusClicked");
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
        }
        #endregion
    }
}