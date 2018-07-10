using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.Models;
using Zipline2.MyEventArgs;
using Zipline2.PageModels;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SaladsPage : BasePage
	{

        SaladsPageModel thisPageModel;
		public SaladsPage ()
		{
            InitializeComponent();
            thisPageModel = new SaladsPageModel();
            BindingContext = thisPageModel;
            string saladTitle = "TBL " + BusinessLogic.OrderManager.Instance.CurrentTableName + " Salads";
            this.ToolbarItems.Add(new ToolbarItem { Text = saladTitle });
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
    }
}