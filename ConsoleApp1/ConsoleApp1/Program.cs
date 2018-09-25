using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            School prosek = new School();
            prosek.schoolName = "Střední průmyslová škola na Proseku";
            Classes trida = new Classes();
            trida.name = "3ITA";
            
            People Jiri = new People();
            Jiri.name = "Jiri Melen";
            trida.students.Add(Jiri);
            prosek.schoolClasses.Add(trida);
        }
    }
}
