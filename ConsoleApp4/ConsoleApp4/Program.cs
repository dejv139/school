using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Person NonMember = new Person
            {
                AcountBill = new Bill { AccountBalance = 1000 },
                PayingStrategy = new NotMemberPayingStrategy(),
                id = 1,
                name = "Person 1"               
            };
            Person GoldMember = new Person
            {
                AcountBill = new Bill { AccountBalance = 1000 },
                PayingStrategy = new GoldMemberPayingStrategy(),
                id = 1,
                name = "Person 1"
            };

            NonMember.BuyItem(100);
            GoldMember.BuyItem(100);
        }
    }
}
