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


        #region Properties
        private List<User> AllUsers { get; set; }
        public bool IsUserLoggedIn { get; set; }

        public User LoggedInUser { get; set; }
        #endregion

        #region Methods
        public void AddNewUser(User newUser)
        {
            AllUsers.Add(newUser);
        }

        public void ChangeLoggedInUser(User changedUser)
        {
            AllUsers.Remove(LoggedInUser);
            AllUsers.Add(changedUser);
            LoggedInUser = changedUser;
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

        public string GetUserName(string userPin)
        {
            string username = string.Empty;
            
            foreach (var user in AllUsers)
            {
                if (user.UserPin == userPin)
                {
                    username = user.UserName;
                }
                break;
            }
            return username;
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
        #endregion
    }
}
