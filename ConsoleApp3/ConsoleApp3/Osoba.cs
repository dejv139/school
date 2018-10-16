using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Osoba
    {
        public string fName { get; set; } = String.Empty;
        public string lName { get; set; } = String.Empty;
        public string gender { get; set; } = String.Empty;
        public bool alive = true;
        public int bornYear { get; set; } = 0;


        public Osoba(string name, string surname, string Gender, bool isAlive, int birthYear)
        {
            fName = name;
            lName = surname;
            gender = Gender;
            alive = isAlive;
            bornYear = birthYear;
        }

        public int getAge(int Year)
        {
            return (Year - bornYear);
        }
    }
}
