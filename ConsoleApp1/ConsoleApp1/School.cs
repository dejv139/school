using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class School
    {
        public string schoolName;
        public List<Classes> schoolClasses { get; set; } = new List<Classes>();
    }
}
