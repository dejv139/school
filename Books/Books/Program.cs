using EPPlus.DataExtractor;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
            string[] menuContent = { "Vypiš všechny E-knihy", "Vypiš všechny papírové knihy", "Autoři" , "Vytvořit E-Knihu", "Vytvořit Papírovou knihu"};

            List<User> users = new List<User>();
            User user = new User
            {
                Name = "David"
            };
            users.Add(user);
            users.Add(user.CreateUser("Melichar"));



            

            Menu menu = new Menu();
            menu.MenuContent = menuContent;
            
            Author author1 = new Author { FristName = "Joe", LastName = "Nesbo" };
            Author author2 = new Author { FristName = "Josef", LastName = "Lada" };
            Author author3 = new Author { FristName = "J.D.", LastName = "Sallinger" };

            string[] menuAuthors = 
            {
                author1.FristName + " " + author1.LastName,
                author2.FristName + " " + author2.LastName,
                author3.FristName + " " + author3.LastName,
            };

            PaperBook book1 = new PaperBook { Name = "Snowman", ISBN = 69, author = author1, Weight = 200 , Stock = 420 };
            PaperBook book2 = new PaperBook { Name = "Muj Přítel Švejk", ISBN = 10, author = author2, Weight = 150, Stock = 0 };
            PaperBook book3 = new PaperBook { Name = "Mikeš", ISBN = 14, author = author2, Weight = 200, Stock = 300 };

            EBook book4 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36};
            EBook book5 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36 };
            EBook book6 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author3, URI = "https://www.google.com/", SizeMB = 36 };
            EBook book7 = new EBook { Name = "Catcher's in the Rye", ISBN = 69, author = author2, URI = "https://www.google.com/", SizeMB = 36 };

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
            books.Add(book7);


            var p = new ExcelPackage();
            string url = @"C:\Users\David Motúz\source\repos\school\Knihy.xlsx";
            //A workbook must have at least on cell, so lets add one... 
            var ws = p.Workbook.Worksheets.Add("MySheet");
            //To set values in the spreadsheet use the Cells indexer.

            ws.Cells["A1"].Value = "Type";
            ws.Cells["B1"].Value = "Název knihy";
            ws.Cells["C1"].Value = "Křesní jméno";
            ws.Cells["D1"].Value = "Přijmení";
            ws.Cells["E1"].Value = "ISBN";
            ws.Cells["F1"].Value = "Váha";
            ws.Cells["G1"].Value = "Dostupnost";
            ws.Cells["H1"].Value = "URI";
            ws.Cells["I1"].Value = "Velikost";
            ws.Cells["A1:J1"].Style.Font.Bold = true;
            ws.Cells["A1:H1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            int counter = 2;
            foreach(Book book in books)
            {
                //uložit do prvního sloupce typ
                ws.Cells["B" + counter].Value = book.Name;
                ws.Cells["C" + counter].Value = book.author.FristName + " " + book.author.LastName;
                ws.Cells["D" + counter].Value = book.ISBN;                    
                if(book is PaperBook)
                {
                    ws.Cells["E" + counter].Value = ((PaperBook)book).Weight + " g";
                    ws.Cells["F" + counter].Value = ((PaperBook)book).Stock + " ks";
                }
                else
                {
                    ws.Cells["G" + counter].Value = ((EBook)book).URI;
                    ws.Cells["H" + counter].Value = ((EBook)book).SizeMB + " MB";
                }
                counter++;
            }
            ws.Cells["A1:H"+counter].AutoFitColumns();
            //Save the new workbook. We haven't specified the filename so use the Save as method.
            p.SaveAs(new FileInfo(url));
            List<Book> booksFromExcel = new List<Book>();

            using (var package = new ExcelPackage(new FileInfo(url)))
            {
                booksFromExcel = package.Workbook.Worksheets["MySheet"]
                    .Extract<Book>()
                    .WithProperty(c => c.Name, "B")
                    .WithProperty(c => c.ISBN, "C")
                    .GetData(1, 6)
                    .ToList();
            }

            foreach( Book prvek in booksFromExcel)
            {
                Console.WriteLine(prvek.Name + prvek.ISBN);
            }

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

            Console.WriteLine("Zadejte užvatelské jmeno:");
            string userName = Console.ReadLine();
            Console.WriteLine("Zadejte heslo");
            string password = Console.ReadLine();

            foreach (User uzivatel in users)
            {
                if (uzivatel.LogIn(userName, password) == true)
                {
                    Console.Clear();
                    Console.WriteLine("Vítej uživateli {0}", uzivatel.Name);
                    menu.GetMenu(menu.MenuContent);
                    Console.Clear();
                    if (menu.GetCurrent() == 3)
                    {
                        Console.WriteLine("Zadejte jmeno knihy");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Zadejte ISBN knihy");
                        int bookISBN = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zvolete autora");
                        for (int i = 0; i <= authors.Count - 1; i++)
                        {
                            Console.WriteLine("{0}){1} {2}", i, authors[i].FristName, authors[i].LastName);
                        }
                        int bookAuthor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zadejte URI knihy");
                        string bookURI = Console.ReadLine();
                        Console.WriteLine("Zadejte velikost knihy");
                        int bookSize = Convert.ToInt32(Console.ReadLine());

                        booksFromFile.Add(user.CreateEbook(bookName, bookISBN, authors[bookAuthor], bookURI, bookSize));

                        menu.GetResult(booksFromFile, 0, menuAuthors);

                    }
                    else if (menu.GetCurrent() == 4)
                    {
                        Console.WriteLine("Zadejte jmeno knihy");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Zadejte ISBN knihy");
                        int bookISBN = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zvolete autora");
                        for (int i = 0; i <= authors.Count - 1; i++)
                        {
                            Console.WriteLine("{0}) {1} {2}", i, authors[i].FristName, authors[i].LastName);
                        }
                        int bookAuthor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zadejte dostupnost knihy");
                        int bookStock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Zadejte váhu knihy");
                        int bookWeight = Convert.ToInt32(Console.ReadLine());

                        booksFromFile.Add(user.CreatePaperbook(bookName, bookISBN, authors[bookAuthor], bookStock, bookWeight));

                        menu.GetResult(booksFromFile, 1, menuAuthors);

                    }
                    else
                    {
                        menu.GetResult(booksFromFile, menu.GetCurrent(), menuAuthors);
                        Console.WriteLine("");
                    }
                    ConsoleKeyInfo Continue = Console.ReadKey(false);
                }
                else
                {
                    Console.WriteLine("Zadal jste špatné udaje");
                }



            }

        }


            

            
    }
}
