using System;
using Ex1.Types;

namespace Ex1
{
    class Program
    {
        public static void Main(string[] args)
        {
            LoggerService.InitLog();
            UserData.ResetUserData();
            while (true)
            {
                if (Login()) break;
            }
        }

        public static bool Login()
        {
            Console.WriteLine("Email: ");
            string username = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Password: ");
            string password = Console.ReadLine() ?? string.Empty;
            bool auth = LoginValidation.ValidateUserInput(username, password);

            if (auth)
            {
                LoggerService.Log(LogType.Info, $"User {LoginValidation.LoggedUser!.Username} logged in.");
                Console.WriteLine("Logged in!");
                if (MenuService.OpenMenu() == -1) return true;
            }
            else
            {
                Console.WriteLine("No user exists with these credentials, try again");
                return false;
            }
            
            return true;
        }
    }
}