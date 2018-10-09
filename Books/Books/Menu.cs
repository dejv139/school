using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Menu
    {
        public int Current = 0 ;
        public string[] MenuContent;
        private bool loopEscape = false;

        public void GetMenu(string[] MenuContent)
        {
            Current = 0;
            do
            {
                Console.Clear();
                ConsoleKeyInfo c = new ConsoleKeyInfo();
                Console.WriteLine("Pick an option . . .\n");
                for (int i = 0; i < MenuContent.Length; i++)
                {
                    if (Current == i)
                    {
                        
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("<< ");
                        Console.Write(MenuContent[i]);
                        Console.Write(" >>");
                        Console.ResetColor();
                        
                        
                    }
                }
                c = Console.ReadKey(false);
                if (c.Key.ToString() == "RightArrow")
                {
                    Current++;
                    if (Current > MenuContent.Length - 1) Current = 0;
                    continue;
                }
                else if (c.Key.ToString() == "LeftArrow")
                {
                    Current--;
                    if (Current < 0) Current = Convert.ToInt16(MenuContent.Length - 1);
                    continue;
                }
                else if (c.Key.ToString() == "Enter")
                {
                    loopEscape = true;
                }

            }
            while (loopEscape == false);
        }

        public int GetCurrent()
        {
            return Current;
        }

        public void GetResult(List<Book> bookArray, int currMenu, string[] authorsArray)
        {
            Current = 0;
            switch (currMenu)
            {
                case 0:
                    Console.WriteLine("{0,20}{1,30}{2,25}{3,20}{4,30}",
                        "\nNázev knihy",
                        "Autor",
                        "",
                        "Velikost",
                        "URI"
                    );
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i <= bookArray.Count - 1; i++)
                    {
                        if (bookArray[i] is EBook)
                        {
                            Console.WriteLine("{0,20}{1,20}{2,25}{3,20}{4,40}",
                                bookArray[i].Name,
                                bookArray[i].author.FristName,
                                bookArray[i].author.LastName,
                                ((EBook)bookArray[i]).SizeMB + " MB",
                                ((EBook)bookArray[i]).URI
                            );
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("{0,20}{1,30}{2,25}{3,20}{4,30}",
                        "\nNázev knihy",
                        "Autor",
                        "",
                        "Váha",
                        "Skladem"
                    );
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i <= bookArray.Count - 1; i++)
                    {
                        if (bookArray[i] is PaperBook)
                        {
                            Console.WriteLine("{0,20}{1,20}{2,25}{3,20}{4,40}",
                                bookArray[i].Name,
                                bookArray[i].author.FristName,
                                bookArray[i].author.LastName,
                                ((PaperBook)bookArray[i]).Weight + " g",
                                ((PaperBook)bookArray[i]).Stock + " ks"
                            );
                        }
                    }
                    break;
                case 2:
                    loopEscape = false;

                    GetMenu(authorsArray);
                    int pom = GetCurrent();
                    Console.WriteLine("Všechny knihy od autora: " + authorsArray[pom]);
                    Console.WriteLine("{0,20}{1,30}{2,45}{3,25}{4,35}",
                        "\nNázev knihy",
                        "Autor",
                        "ISBN",
                        "Velikost/Váha",
                        "URI/Skladem"
                    );
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------");
                    for (int i = 0; i <= bookArray.Count - 1; i++)
                    {
                        string test = bookArray[i].author.FristName + " " + bookArray[i].author.LastName;
                        if (authorsArray[pom] == test)
                        {
                            if (bookArray[i] is EBook)
                            {
                                Console.WriteLine("{0,20}{1,20}{2,25}{3,20}{4,20}{5,40}",
                                    bookArray[i].Name,
                                    bookArray[i].author.FristName,
                                    bookArray[i].author.LastName,
                                    bookArray[i].ISBN,
                                    ((EBook)bookArray[i]).SizeMB + " MB",
                                    ((EBook)bookArray[i]).URI
                                );
                            }else if( bookArray[i] is PaperBook)
                            {
                                Console.WriteLine("{0,20}{1,20}{2,25}{3,20}{4,20}{5,40}",
                                    bookArray[i].Name,
                                    bookArray[i].author.FristName,
                                    bookArray[i].author.LastName,
                                    bookArray[i].ISBN,
                                    ((PaperBook)bookArray[i]).Weight + " g",
                                    ((PaperBook)bookArray[i]).Stock + " ks"
                                );
                            }
                            
                        }
                    }
                    break;

            }
        }

    }
}
