using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class NotMemberPayingStrategy : IPayingStrategy
    {
        public void Pay(Bill bill, int price)
        {
            bill.AccountBalance = bill.AccountBalance - price;
        }
    }
}
