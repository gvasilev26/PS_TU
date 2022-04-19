using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            private set { }
        }

        public static User? IsUserPassCorrect(string username, string password)
        {
            if (_testUsers == null) ResetTestUserData();
            return (from testUser in _testUsers
                where testUser.Username == username
                select testUser.Password == password ? testUser : null)
                .FirstOrDefault();
        }

        private static void ResetTestUserData()
        {
            if (_testUsers != null) return;
            _testUsers = new List<User>
            {
                new User("Georgi", "Test123!", "121219040", UserRoles.Admin),
                new User("Sasho", "test234", "121219234", UserRoles.Student),
            };
        }

        public static void SetUserActiveTo(string username, DateTime date)
        {
            foreach (var testUser in _testUsers)
                if (testUser.Username == username)
                {
                    testUser.ValidDate = date;
                    Logger.LogActivity("Changed active date for " + username + " to " + date);
                    return;
                }
        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (var user in _testUsers)
                if (user.Username == username)
                {
                    user.Role = role;
                    Logger.LogActivity("Changed role for " + username + " to " + role);
                    return;
                }
        }

        public static void ListUsers()
        {
            foreach (var user in _testUsers)
                Console.WriteLine(user);
        }
    }
}