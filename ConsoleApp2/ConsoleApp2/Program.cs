using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();

            Admin admin = new Admin()
            {
                Name = "admin"
            };

            users.Add(admin.CreateUser("Pavel"));

            admin.LogIn("admin", "ahoj");
            
            users[0].changePassword("ahojky");

            for(int i = 0; i <= users.Count; i++)
            {
                if (users[i].LogIn("Pavel", "puss") == true)
                {
                    Console.WriteLine(":)");
                }
                else
                {
                    Console.WriteLine(":(");
                }
            }

        }
    }
}
