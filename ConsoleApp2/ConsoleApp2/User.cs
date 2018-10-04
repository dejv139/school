using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class User
    {
        public string Name { get; set; }

        private string password { get; set; } = "pass";

        public virtual bool LogIn(string name, string pasword)
        {
            if(name == Name && pasword == password)
            {
                return true;
            }
            else
            {
                return false;
            }     
        }

        public void changePassword(string pasword)
        {
            password = pasword;
        }
    }
}
