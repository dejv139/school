using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Person
    {
        public Bill AcountBill;
        public IPayingStrategy PayingStrategy;
        public int id { get; set; }
        public string name { get; set; }

        public void BuyItem(int price)
        {
            PayingStrategy.Pay(AcountBill, price);
            Console.WriteLine("You have dis much muney " + AcountBill.AccountBalance);
        }
    }
}
