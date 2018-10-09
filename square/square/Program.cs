using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace square
{
    class Program
    {
        static void Main(string[] args)
        {
            bool pom = true;
            int delka = 0;
            int Strana = 0;
            bool side = true; //true = downwords, false = upwards
            Console.WriteLine("Zadejte délku strany");
            while (pom == true)
            {
                string Delka = Console.ReadLine();
                if (int.TryParse(Delka, out delka))
                {
                    delka = Convert.ToInt32(Delka);
                    pom = false;
                }
                else
                {
                    Console.WriteLine("Zadejte čislo");
                }
            }
            Console.Write("Zadejte stranu: \n 1)Vrchní\n 2) Spodní\n");
            pom = true;
            while (pom == true)
            {
                string strana = Console.ReadLine();
                if (int.TryParse(strana, out Strana))
                {
                    Strana = Convert.ToInt32(strana);
                    if (Strana == 2 || Strana == 1)
                    {
                        if(Strana == 1)
                        {
                            side = true;
                        }
                        else
                        {
                            side = false;
                        }
                        pom = false;
                    }
                    else
                    {
                        Console.WriteLine("Neplatná hodnota");
                    }
                    
                }
                else
                {
                    Console.WriteLine("Zadejte čislo");
                }
            }
            VytiskniSquare(delka, side);
        }



        static void VytiskniSquare(int delka, bool Side)
            {
                for (int i = 0; i < delka; i++)
                {
                    for (int u = 0; u < delka; u++)
                    {
                        if (i == 0 || i == delka - 1)
                        {
                            Console.Write("--");
                        }
                        else
                        {
                            if (u == 0)
                            {
                                Console.Write("| ");
                            }
                            else if (u == delka - 1)
                            {
                                Console.Write(" |");
                            }
                            else
                            {
                                if (Side == true)
                                {
                                    if (i + u < delka)
                                    {
                                        Console.Write("* ");
                                    
                                }
                                    else
                                    {
                                        Console.Write("  ");
                                    }
                                }
                                else
                                {

                                    if (i + u > delka - 2)
                                    {
                                        Console.Write("* ");
                                    }
                                    else
                                    {
                                        Console.Write("  ");
                                    }
                                }
                            }
                        }
                    }
                Console.Write("\n");
            }
                
            }
        

    }
}
