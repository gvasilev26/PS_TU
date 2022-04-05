using System;
using Ex1.Types;

namespace Ex1
{
    public class LoginValidation
    {
        // Somewhat of an auth service :D 
        public static User? LoggedUser;

        public static bool ValidateUserInput(string username, string password)
        {
            try
            {
                // No hashing/encrypting on password
                LoggedUser = UserData.Users.Find(u => u.Username.Equals(username) && u.Password.Equals(password));
                if (LoggedUser != null)
                {
                    LoggedUser.ActivityDate = DateTime.Now;
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException e)
            {
                LoggerService.Log(LogType.Error, e.Message);
                return false;
            }
        }
    }
}