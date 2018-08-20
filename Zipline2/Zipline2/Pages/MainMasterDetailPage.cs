using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Models;

namespace Zipline2.Pages
{
	public class MainMasterDetailPage : MasterDetailPage
    {
		public MainMasterDetailPage()
		{
            Master = new MasterPage()
            {
                BackgroundColor = Color.Black,
                Title = "Satchel's Pizza",
                Icon = "hamburger.png"
            };
           
            Detail = new NavigationPage(new TablesPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!Users.Instance.IsUserLoggedIn)
            {
                if (WcfServicesProxy.Instance.ServerConnectionProblem)
                {
                    DisplayFatalAlert();
                }
                else
                {
                    Navigation.PushModalAsync(new LoginPage());
                }
               
            }
        }

        async private Task DisplayFatalAlert()
        {
            await DisplayAlert("Server Error", "Cannot connect to server.  If you are not at Satchel's, you can test creating orders only.  If you are at Satchel's, please let Joanne know there is a server connection issue.", "OK");
        }
    }
}