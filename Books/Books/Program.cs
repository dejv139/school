using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuContent = { "Vypiš všechny E-knihy", "ahoj", "ahoj2" };

            Menu menu = new Menu();
            menu.MenuContent = menuContent;
            
            Author author1 = new Author { FristName = "Joe", LastName = "Nesbo" };
            Author author2 = new Author { FristName = "Josef", LastName = "Lada" };
            Author author3 = new Author { FristName = "J.D.", LastName = "Sallinger" };

            PaperBook book1 = new PaperBook { Name = "Snowman", ISBN = 69, author = author1, Weight = 200 , Stock = 420 };
            PaperBook book2 = new PaperBook { Name = "Muj Přítel Švejk", ISBN = 10, author = author2, Weight = 150, Stock = 0 };
            PaperBook book3 = new PaperBook { Name = "Mikeš", ISBN = 14, author = author2, Weight = 200, Stock = 300 };

            EBook book4 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36};
            EBook book5 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36 };
            EBook book6 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36 };

            List<Author> authors = new List<Author>();
            authors.Add(author1);
            authors.Add(author2);
            authors.Add(author3);

            List<Book> books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            books.Add(book3);
            books.Add(book4);
            books.Add(book5);
            books.Add(book6);

            List<PaperBook> DiscontinuousBooks = new List<PaperBook>();

            // Aby zustaly zděděné classy ( musí se vždy napsat při serializaci/deserializaci )
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects
            };

            string json = JsonConvert.SerializeObject(books, settings);
            File.WriteAllText("jsonFile.json", json);
            string jsonFromFile = File.ReadAllText("jsonFile.json");
            List<Book> booksFromFile = JsonConvert.DeserializeObject<List<Book>>(jsonFromFile, settings);
            //

            Console.WriteLine("Press any key to continue");

            menu.GetMenu(menu.MenuContent);
            menu.GetResult(booksFromFile, menu.GetCurrent());
            
        }
    }
}
