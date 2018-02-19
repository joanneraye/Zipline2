using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Zipline2
{
    class LoginPageModel : BasePageModel
    {
        //Using the MVVM pattern is confusing and not enough examples out there
        //for me to figure out how to do stuff.

        //private bool isBusy = false;
        //public Command LoginCommand { get; }

        //public INavigation Navigation { get; set; }

        //public bool IsBusy
        //{
        //    get { return isBusy; }
        //    set
        //    {
        //        isBusy = value;
        //        OnPropertyChanged();
        //        LoginCommand.ChangeCanExecute();
        //    }
        //}
        //public LoginPageModel(INavigation navigation)
        //{
        //    this.Navigation = navigation;
        //    LoginCommand = new Command(async () => await Login());
        //}

        //public async Task Login()
        //{
        //    isBusy = true;

        //    var isValid = true;

        //    //Verify login

        //    if (isValid)
        //    {
        //        App.IsUserLoggedIn = true;


        //        //Put login name at top of each screen.

        //        await Navigation.PushAsync(new TableListPage());

        //        isBusy = false;
        //    }
        //    else
        //    {

        //    }
        //}



        //public ICommand _loginCommand;
        //public ICommand LoginUserCommand =>
        //    _loginCommand ?? (_loginCommand =
        //    new Command(async () => await Login()));

        //private async Task Login()
        //{
        //    await CoreMethods.PushPageModel<TableListPageModel>();
        //}
    }
}
