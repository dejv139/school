using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    class ColdBlooded : Animal
    {
        public int tempeture { get; set; }

        public void sunBath()
        {
            tempeture = tempeture + 5;
            Console.WriteLine("{0} is sunbathing.", name);
        }

 
    }
}
