using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dedicnost
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal lion = new Animal
            {
                name = "Micka",
                isAlive = true,
                habitat = "savana"
                
            };

            ColdBlooded cobra = new ColdBlooded
            {
                name = "žížala",
                isAlive = true,
                habitat = "jungle",
                tempeture = 30
            };

            lion.Eat();
            lion.Drink();

            cobra.Eat();
            cobra.Drink();
            cobra.sunBath();
        }
    }
}
