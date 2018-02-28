using System;
using System.Collections.Generic;
using System.Text;

namespace Zipline2.Models
{
    public class Users
    {
        #region Singleton Class Logic
        //This is a singleton class:
        private static Users Instance;

        private Users()
        {
            AllUsers = new List<User>();
        }

        public static Users GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Users();
            }

            return Instance;
        }

        #endregion 
        
        private List<User> AllUsers { get; set; }

        public User LoggedInUser { get; set; }

        
        public void AddNewUser(User newUser)
        {
            AllUsers.Add(newUser);
        }

        public bool AuthenticateUser(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            foreach (var user in AllUsers)
            {
                if (user.UserPin == value.Trim())
                {
                    LoggedInUser = user;
                    return true;
                }
            }
            return false;
        }

        public bool PinAlreadyUsed(string newUserPin)
        {
            if (string.IsNullOrEmpty(newUserPin))
            {
                return false;
            }
            foreach (var user in AllUsers)
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
