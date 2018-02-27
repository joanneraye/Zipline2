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
    public partial class LoginPage : BasePage
    {
        LoginPageModel LoginPageModel;
        public LoginPage()
        {
            InitializeComponent();
            PinEnteredByUser.Focus();
            LoginPageModel = new LoginPageModel();
            BindingContext = LoginPageModel;
        }

        async void OnAddNewUserButtonClicked(object sender, EventArgs e)
        {
            if (Users.AuthenticateUser(PinEnteredByUser.Text) &&
                Users.LoggedInUser.HasManagerPrivilege)
            {
                PinEnteredByUser.Text = String.Empty;
                await Navigation.PushAsync(new AddUserPage());
            }
            else
            {
                await DisplayAlert("Oops", "Only a Manager PIN can access the Add User button.  Please enter manager PIN.", "OK");
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            LoginButton.IsEnabled = false;
            if (Users.AuthenticateUser(PinEnteredByUser.Text))
            {
                App.IsUserLoggedIn = true;
                await Navigation.PushAsync(new TablesPage());

            }
            else
            {
                await DisplayAlert("Oops", "Sorry that PIN is not in our system as belonging to anyone.", "OK");
            }
            LoginButton.IsEnabled = true;
        }

        async void OnChangePinButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Sorry", "This functionality has not been completed yet.", "OK");
        }
    }
}