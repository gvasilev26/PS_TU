using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Ex1.Types;

namespace Ex1
{
    public static class MenuService
    {
        public static int OpenMenu()
        {
            while (LoginValidation.LoggedUser?.Username != null)
            {
                Console.WriteLine(PrintMenu(LoginValidation.LoggedUser.Role));
                Console.WriteLine("Command: ");
                string cmd = Console.ReadLine() ?? string.Empty;
                int res = HandleCommand(cmd);
                if (res == -1) return res;
            }

            return -1;
        }

        private static string PrintMenu(Role r)
        {
            switch (r)
            {
                case Role.Admin:
                    return
                        "\n0: Exit\n1: Edit an user's role\n2: Edit an user's activity\n3: List users\n4: Review activity log\n5: Review current activity";
                case Role.User:
                    return "Sorry, no commands for normal users available just yet";
                default:
                    LoggerService.Log(LogType.Error, "Unrecognized user role when accessing the menu");
                    return "Unrecognized role";
            }
        }

        private static int HandleCommand(string cmd)
        {
            switch (cmd)
            {
                case "0":
                    return -1;
                case "1":
                    UserData.ChangeUserRole();
                    return 0;
                case "3":
                    UserData.Users.ForEach(u => Console.WriteLine("User: " + JsonSerializer.Serialize(u)));
                    LoggerService.Log(LogType.Info, $"User {LoginValidation.LoggedUser!.Username} listed all users through the menu");
                    return 0;
                case "4":
                    LoggerService.DumpLog();
                    LoggerService.Log(LogType.Info, $"User {LoginValidation.LoggedUser!.Username} dumped the log through the menu");
                    return 0;
                default:
                    return 0;
            }
        }
    }
}