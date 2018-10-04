using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Admin : User
    {
        private string masterPassword = "ahoj";
        public List<User> users = new List<User>();

        public User CreateUser(string name)
        {
            return new User()
            {
                Name = name
            };
        }

        public bool DeleteUser (User UserToDelete)
        {
            return true;
        }

        public override bool LogIn(string name, string password)
        {
            if (name == Name && masterPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
