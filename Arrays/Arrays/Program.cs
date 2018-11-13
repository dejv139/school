using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pole = new int[]{ 1, 2, 3 };

            int[] append(int[] pom)
            {
                for(int i = 0; i <= pom.Length; i++)
                {
                    if (i == pom.Length)
                    {
                        pom[i + 1] = 5;
                        pom[i + 2] = 5;
                    }
                 
                }
                return pom;
            }

            append(pole);
            foreach(int i in pole)
            {
                Console.WriteLine(i);
            }
        }
    }
}
