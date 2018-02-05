using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zipline2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : BasePage
	{
		public LoginPage ()
		{
            InitializeComponent();
        }
        
        async void OnLoginButtonClicked (object sender, EventArgs e)
        {
            var isValid = true;

            //Verify login

            if (isValid)
            {
               
                App.IsUserLoggedIn = true;

                //Put login name at top of each screen.
                await Navigation.PushAsync(new TableListPage());
              
            }
            else
            {

            }
        }
    }
}