using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.MyEventArgs;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalzonePage : BasePage
	{
        CalzonePageModel CalzonePageModel { get; set; }
		public CalzonePage ()
		{
            try
            { 
                CalzonePageModel = new CalzonePageModel();
                InitializeComponent();
                BindingContext = CalzonePageModel;
                string calzoneTitle = "TBL " + OrderManager.Instance.CurrentTableName + " Calzone";
                this.ToolbarItems.Clear();
                this.ToolbarItems.Add(new ToolbarItem { Text = calzoneTitle, Priority = 0 });
                Footer.FooterPageModel.IsCalzonePageDisplayed = true;
                Footer.FooterPageModel.DisplayAddToOrderButton = false;
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
         
        }

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                CalzonePageModel.NavigateToCalzoneToppingsPage += HandleNavigateToCalzoneToppingsPage;
            }
            catch (Exception ex)
            {
                var whatisthis = ex.InnerException;
                throw;
            }
          

        }
        async void HandleNavigateToCalzoneToppingsPage(object sender, CalzoneToppingsPageEventArgs e)
        {
            await Navigation.PushAsync(new CalzoneToppingsPage(e.CurrentCalzone));
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CalzonePageModel.NavigateToCalzoneToppingsPage -= HandleNavigateToCalzoneToppingsPage;
        }
    }
}