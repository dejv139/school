using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    class Animal
    {
        public string name { get; set; }
        public bool isAlive { get; set; }
        public string habitat { get; set; }

        public void Eat()
        {
            Console.WriteLine("{0} just ate.", name);
        }

        public void Drink()
        {
            Console.WriteLine("{0} just drank.", name);
        }
    }
}
