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
        public LoginPageModel()
        {
        }

        public ICommand _loginCommand;
        public ICommand LoginUserCommand =>
            _loginCommand ?? (_loginCommand =
            new Command(async () => await Login()));
        
        private async Task Login()
        {
            await CoreMethods.PushPageModel<TableListPageModel>();
        }
    }
}
