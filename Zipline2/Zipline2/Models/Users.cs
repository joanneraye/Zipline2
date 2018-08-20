using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Zipline2.Models
{
    public sealed class Users
    {
        #region Singleton Class
        private static Users instance = null;
        private static readonly object padlock = new object();
        private Users()
        {
            AllUsers = new List<User>();
        }
        public static Users Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Users();
                    }
                    return instance;
                }
            }
        }
        #endregion


        #region Properties
        private List<User> AllUsers { get; set; }
        public bool IsUserLoggedIn { get; set; }
        private User loggedInUser;
        public User LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
            set
            {
                loggedInUser = value;
                MessagingCenter.Send(this, "UserLoggedIn", loggedInUser.UserName);
            }
        }
        #endregion

        #region Methods
        public void AddNewUser(User newUser)
        {
            AllUsers.Add(newUser);
        }

        /// <summary>
        /// Used for user to change PIN and/or name.
        /// </summary>
        /// <param name="changedUser"></param>
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
