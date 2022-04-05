using System;
using System.Collections.Generic;

namespace Ex1.Types
{
    public static class UserData
    {
        public static List<User> Users;

        public static void AddUser(User u)
        {
            Users.Add(u);
        }

        // Also used to initialize the *db* which is the Users list
        public static void ResetUserData()
        {
            Users = new List<User>();
            for (int i = 0; i < 5; i++)
            {
                Users.Add(new User($"uname{i}", $"pw{i}", $"{i}", Role.User));
            }

            Users.Add(new User("admin", "admin", "123z", Role.Admin));
        }

        public static void ChangeUserRole()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine() ?? String.Empty;
            var u = Users.Find(u => u.Username.Equals(username));
            if (u == null)
            {
                Console.WriteLine("No such user.");
                return;
            }

            Console.WriteLine("User found! Available roles:");
            foreach (string role in Enum.GetNames(typeof(Role)))
            {
                Console.WriteLine(role);
            }

            Console.WriteLine("Enter new role: ");
            string roleInput = Console.ReadLine() ?? String.Empty;
            if (roleInput == "Admin") u.Role = Role.Admin;
            else u.Role = Role.User;
            LoggerService.Log(LogType.Info,
                $"User - {LoginValidation.LoggedUser!.Username} changed the role for user {u.Username} to {u.Role}");
        }
    }
}