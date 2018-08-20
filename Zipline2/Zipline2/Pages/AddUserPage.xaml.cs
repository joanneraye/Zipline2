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
	public partial class AddUserPage : BasePage
	{
        AddUserPageModel AddUserPageModel;
        string[] InvalidPins = new string[]
        {
            "0000", "1111", "2222", "3333", "4444", "5555", "6666", "7777", 
            "8888", "9999", "0123", "1234", "2345", "3456", "4567", "5678", 
            "6789"
        };
        public AddUserPage (bool changeExistingPin = false)
		{
			InitializeComponent ();
            NewUserName.Focus();
            AddUserPageModel = new AddUserPageModel();
            BindingContext = AddUserPageModel;
            if (changeExistingPin)
            {
                ChangeExistingUserPin();
            }

		}

        private async Task ChangeExistingUserPin()
        {
            User newUser = new User(AddUserPageModel.NewUserName,
                    false, AddUserPageModel.NewUserPin);

            Users.Instance.ChangeLoggedInUser(newUser);

            //TODO:  Whenever a user is changed, write to file.

            await Navigation.PopAsync();
        }

        async Task OnAddUserButtonClicked(object sender, EventArgs e)
        {
            if (InvalidPins.Contains(AddUserPageModel.NewUserPin))
            {
                await DisplayAlert("Oops", "PIN cannot be all the same number or consecutive numbers", "OK");
            }
            else if (Users.Instance.PinAlreadyUsed(AddUserPageModel.NewUserPin))
            {
                await DisplayAlert("Oops", "Sorry, this PIN is already being used.  Since it will identify you, it must not be the same as any other Satchel's employee.", "OK");
            }
            else if (AddUserPageModel.NewUserPin.Length != 4)
            {
                await DisplayAlert("Oops", "Your PIN must be 4 digits", "OK");
            }
            else
            {
                User newUser = new User(AddUserPageModel.NewUserName,
                    false, AddUserPageModel.NewUserPin);

                Users.Instance.AddNewUser(newUser);

                //TODO:  Whenever a new user is added, write to file.
                
                await Navigation.PopAsync();
            }
        }
    }
}