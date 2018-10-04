using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class MasterPassword
    {
        private string password = "ahoj";

        public bool LogAdminIn(string pass)
        {
            if(pass == password) 
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
