using System;

namespace Ex1.Types
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FacNumber { get; set; }
        public Role Role { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ActivityDate { get; set; }

        public User(string username, string password, string facNumber, Role role)
        {
            Username = username;
            Password = password;
            FacNumber = facNumber;
            Role = role;
            CreationDate = DateTime.Now;
            ActivityDate = DateTime.Now;
        }

        public User()
        {
            Username = "default";
            Password = "default";
            FacNumber = "default";
            Role = Role.User;
        }
    }
}