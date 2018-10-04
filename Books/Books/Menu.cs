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
                ConsoleKeyInfo c = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Pick an option . . .");
                for (int i = 0; i < MenuContent.Length; i++)
                {
                    if (Current == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(">>");
                        Console.WriteLine(MenuContent[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(MenuContent[i]);
                    }
                }



                if (c.Key.ToString() == "DownArrow")
                {
                    Current++;
                    if (Current > MenuContent.Length - 1) Current = 0;
                }
                else if (c.Key.ToString() == "UpArrow")
                {
                    Current--;
                    if (Current < 0) Current = Convert.ToInt16(MenuContent.Length - 1);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Enter);
        }

        public int GetCurrent()
        {
            return Current;
        }
    }
}
