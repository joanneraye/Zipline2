using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Users
    {
        //This is a singleton class:
        private static readonly Lazy<Users> lazy =
            new Lazy<Users>(() => new Users());
        public static Users Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private Users()
        {

        }

        public static List<User> AllUsers { get; set; }
        
        public static User LoggedInUser { get; set; }

        public static bool AuthenticateUser(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            foreach (var user in Users.AllUsers)
            {
                if (user.UserPin == value.Trim())
                {
                    Users.LoggedInUser = user;
                    return true;
                }
            }
            return false;
        }

        public static bool PinAlreadyUsed(string newUserPin)
        {
            if (string.IsNullOrEmpty(newUserPin))
            {
                return false;
            }
            foreach (var user in Users.AllUsers)
            {
                if (user.UserPin == newUserPin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
