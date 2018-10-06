using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    class EBook : Book
    {
        public string URI { get; set; }

        public int SizeMB { get; set; }

        public int getSize()
        {
            return SizeMB;
        }
    }
}
