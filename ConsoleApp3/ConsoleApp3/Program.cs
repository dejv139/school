using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int currYear = 2018;

            List<Osoba> persons = new List<Osoba>()
            {
                new Osoba("David", "Motuz", "Muž", true, 2001),
                new Osoba("David", "Motuz", "Muž", true, 1990),
                new Osoba("David", "Motuz", "Žena", false, 2004),
                new Osoba("David", "Motuz", "Muž", true, 2007),
                new Osoba("David", "Motuz", "Žena", true, 1999)
            };

            int personsCounter = 0;
            int femaleCounter = 0;
            int maleCounter = 0;
            int Sum = 0;

            for (int i = 0; i < persons.Count(); i++)
            {
                personsCounter++;
                Sum += persons[i].getAge(currYear);

                if (persons[i].gender == "Muž")
                {
                    maleCounter++;
                }else if(persons[i].gender == "Žena"){
                    femaleCounter++;
                }
            }

            Console.WriteLine("Je tu {0} mužů, {1} žen", maleCounter, femaleCounter);
            Console.WriteLine("Průměrný věk je {0}", (Sum / personsCounter));





        }
    }
}
