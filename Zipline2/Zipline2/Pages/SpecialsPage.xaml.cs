using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.PageModels;
using Zipline2.MyEventArgs;
using Zipline2.BusinessLogic;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecialsPage : BasePage
	{
        private SpecialsPageModel thisPageModel;
		public SpecialsPage ()
		{
            thisPageModel = new SpecialsPageModel();
			InitializeComponent ();
            BindingContext = thisPageModel;
            Footer.FooterPageModel.IsSpecialsPageDisplayed = true;
            string specialsTitle = "TBL " + BusinessLogic.OrderManager.Instance.CurrentTableName + " Specials";
            this.ToolbarItems.Add(new ToolbarItem { Text = specialsTitle });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            thisPageModel.NavigateToSaladToppingsPage += HandleNavigateToSaladToppingsPage;
        }

        async void HandleNavigateToSaladToppingsPage(object sender, SaladToppingsPageEventArgs e)
        {
            await Navigation.PushAsync(new SaladToppingsPage(e.CurrentSalad));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            thisPageModel.NavigateToSaladToppingsPage -= HandleNavigateToSaladToppingsPage;
        }
    }
}