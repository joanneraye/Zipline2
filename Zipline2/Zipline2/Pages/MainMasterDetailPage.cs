using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
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
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}