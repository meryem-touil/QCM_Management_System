using QCM_Management_System.Models;
using System;

namespace QCM_Management_System.Utils
{
    public static class SessionManager
    {
        public static User CurrentUser { get; private set; }

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsAuthenticated()
        {
            return CurrentUser != null;
        }

        public static bool IsAdmin()
        {
            return CurrentUser != null && CurrentUser.Role == "Admin";
        }

        public static bool IsUser()
        {
            return CurrentUser != null && CurrentUser.Role == "User";
        }
    }
}