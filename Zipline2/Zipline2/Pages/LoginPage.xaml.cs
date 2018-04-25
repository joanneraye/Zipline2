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
        private const string YES = "Yup";
        private const string NO = "No Way Jose";
        LoginPageModel LoginPageModel;
        Users Users = Users.Instance;
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
                PinEnteredByUser.Text = "";
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            LoginButton.IsEnabled = false;
            if (IsValidUser(PinEnteredByUser.Text)) 
            {
                Users.IsUserLoggedIn = true;
                await Navigation.PopModalAsync();
            }
            //TODO: See this example....
            //Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Save Failed", message, "OK"));
            await DisplayAlert("Oops", "Sorry that PIN is not in our system as belonging to anyone.", "OK");
            PinEnteredByUser.Text = "";
            LoginButton.IsEnabled = true;
        }

        private bool IsValidUser(string pin)
        {
            if (Users.AuthenticateUser(pin))
            {
               return true;
            }
            return false;
        }

        async void OnChangePinButtonClicked(object sender, EventArgs e)
        {
            if (IsValidUser(PinEnteredByUser.Text))
            {
                Users.IsUserLoggedIn = true;
                var isYes = await DisplayAlert("Hi!", "Are you " +
                    Users.GetUserName(Users.LoggedInUser.UserPin) + "?", YES, NO);
                if (isYes)
                {
                    PinEnteredByUser.Text = "";
                    await Navigation.PushAsync(new AddUserPage());
                }
                else
                {
                    PinEnteredByUser.Text = "";
                    await DisplayAlert("Could you have used the wrong PIN?", "Try signing in again.", "OK");
                }
            }
            else
            {
                await DisplayAlert("Oops", "Sorry that PIN is not in our system as belonging to anyone.", "OK");
                PinEnteredByUser.Text = "";
            }
        }
    }
}