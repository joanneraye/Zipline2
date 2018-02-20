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
                if (Application.Current.Properties.ContainsKey("CurrentUser"))
                {
                    Application.Current.Properties["CurrentUser"] = userName;
                }
                else
                {
                    Application.Current.Properties.Add("CurrentUser", userName);
                }
               
                await Application.Current.SavePropertiesAsync();

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