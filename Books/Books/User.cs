using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class User
    {
        public string Name { get; set; }

        private string password { get; set; } = "123";

        public virtual bool LogIn(string name, string pasword)
        {
            if (name == Name && pasword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void changePassword(string pasword)
        {
            password = pasword;
        }

        public EBook CreateEbook(string name, int isbn, Author author, string uri, int sizemb)
        {
            return new EBook()
            {
                Name = name,
                ISBN = isbn,
                author = author,
                URI = uri,
                SizeMB = sizemb
            };
        }

        public PaperBook CreatePaperbook(string name, int isbn, Author author, int stock, int weight)
        {
            return new PaperBook()
            {
                Name = name,
                ISBN = isbn,
                author = author,
                Stock = stock,
                Weight = weight
            };
        }

        public User CreateUser(string name)
        {
            return new User()
            {
                Name = name
            };
        }
    }
}
