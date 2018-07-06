using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Zipline2.BusinessLogic;
using Zipline2.BusinessLogic.WcfRemote;
using Zipline2.Models;

namespace Zipline2.PageModels
{
    class LoginPageModel : BasePageModel
    {

        private string pinEnteredByUser;

        #region Properties
        public User LoggedInUser { get; set; }

        public bool IsPinValidUser { get; set; }

        public string TestingNote { get; set; }


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
           
            if (DataBaseDictionaries.MenuDictionary?.Count > 0 &&
                DataBaseDictionaries.DbTablesDictionary?.Count > 0 &&
                DataBaseDictionaries.PizzaToppingsDictionary?.Count > 0)
            {
                TestingNote = "Note to Joanne:  Server data seems to have been loaded.";
            }
            else
            {
                TestingNote = "Note to Joanne:  Some or all server data did not load.";
            }
            
        }
    }
}
