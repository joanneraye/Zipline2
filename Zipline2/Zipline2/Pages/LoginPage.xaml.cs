using Staunch.POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.ConnectedServices;
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
            //ZiplineLogoImage.Source = ImageSource.FromResource("Zipline2.Images.zipline_logo.jpg");
            //if (Device.RuntimePlatform == Device.Android)
            //{
            //    ZiplineLogoImage.Source = "zipline_logo.jpg";

            //}
            ////No problem with this code, but if I put the file in the 
            ////ios Resources folder, I get a compiler error that the file
            ////doesn't exist!!
            //else    //Logo doesn't show up but at least it compiles....
            //{
            //    ZiplineLogoImage.Source = ImageSource.FromFile("ZiplineLogo");
            //}
            ZiplineLogoImage.Aspect = Aspect.AspectFit;
            PinEnteredByUser.Focus();
            LoginPageModel = new LoginPageModel();
            BindingContext = LoginPageModel;
        }

        //private void OnLiveServerClick()
        //{
        //    ServerButtonToggle = !ServerButtonToggle;
        //    if (ServerButtonToggle)
        //    {
        //        LiveServerButton.BackgroundColor = Color.LightBlue;
        //        WcfServicesProxy.Instance.MakeLiveServerConnection();
        //    }
        //    else
        //    {
        //        LiveServerButton.BackgroundColor = Color.Black;
        //        WcfServicesProxy.Instance.MakeTestEnvironmentConnection();
        //    }

        //}


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
            else
            {
                //TODO: See this example....
                //Device.BeginInvokeOnMainThread(async () => await DisplayAlert("Save Failed", message, "OK"));
                await DisplayAlert("Oops", "Sorry that PIN is not in our system as belonging to anyone.", "OK");
                PinEnteredByUser.Text = "";
                LoginButton.IsEnabled = true;
            }
        }

        private bool IsValidUser(string pin)
        {
            DBUser user = WcfServicesProxy.Instance.GetUser(pin);
            if (user.ID != -1)
            {
                //Users.Instance.LoggedInUser = new Zipline2.Models.User("Employee", false, "1111");
                Users.Instance.LoggedInUser = new Zipline2.Models.User(user.Name, false, user.Pin);
                return true;
            }
            return false;



            //DO NOT DELETE - MAY BE USED IN FUTURE.
            //FOR NOW THOUGH, USE EXISTING USERIDS....
            //if (Users.AuthenticateUser(pin))
            //{
            //   return true;
            //}
            //return false;


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