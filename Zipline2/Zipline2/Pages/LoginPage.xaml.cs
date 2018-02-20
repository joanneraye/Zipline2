using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zipline2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : BasePage
	{
		public LoginPage ()
		{
            InitializeComponent();
            //BindingContext = new LoginPageModel();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var isValid = true;
            string userName = "Joanne";

            //Verify login

            if (isValid)
            {
                Application.Current.Properties["UserName"] = userName;
                App.IsUserLoggedIn = true;
                LoginButton.IsEnabled = false;

                //Put login name at top of each screen.

                await Navigation.PushAsync(new TablesPage());
                LoginButton.IsEnabled = true;
            }
            else
            {

            }
        }
    }
}