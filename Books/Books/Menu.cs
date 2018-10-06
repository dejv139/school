using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class Menu
    {
        public int Current;
        public string[] MenuContent;

        public void GetMenu(string[] MenuContent)
        {
            do
            {
                Console.Clear();
                ConsoleKeyInfo c = Console.ReadKey(false);
                Console.WriteLine("Pick an option . . .\n");
                for (int i = 0; i < MenuContent.Length; i++)
                {
                    if (Current == i)
                    {
                        Console.Write("<< ");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.Write(MenuContent[i]);
                        Console.ResetColor();
                        Console.Write(" >>");
                    }
                }
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
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        public void GetResult(List<Book> bookArray, int currMenu)
        {
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
                            Console.WriteLine("{0,20}{1,20}{2,20}{3,20}{4,40}",
                            bookArray[i].Name,
                            bookArray[i].author.FristName,
                            bookArray[i].author.LastName,
                            //Issue
                            ((EBook)bookArray[i]).SizeMB + "MB",
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
                            //Issue
                            ((PaperBook)bookArray[i]).Weight + " g",
                            ((PaperBook)bookArray[i]).Stock + " ks"
                            );
                        }
                    }
                    break;
            }
        }

            public int GetCurrent()
       {
            return Current;
        }
    }
}
