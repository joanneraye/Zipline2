using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    class LoginPageModel : BasePageModel
    {

        private string pinEnteredByUser;

        #region Properties
        public User LoggedInUser { get; set; }

        public bool IsPinValidUser { get; set; }
        
        public string PinEnteredByUser
        {
            get
            {
                return pinEnteredByUser;
            }
            set
            {
                if (value != null &&
                    value.Length == 4 &&
                    Users.Instance.AuthenticateUser(value))
                {
                    IsPinValidUser = true;
                }
                else
                {
                    pinEnteredByUser = String.Empty;
                }
            }
        }
        #endregion

        public LoginPageModel()
        {

        }
    }
}
