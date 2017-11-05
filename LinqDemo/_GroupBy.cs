using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class _GroupBy
    {


        public static void Run()
        {
            var ticketlist = _ToLookup.GetList();

            var data = ticketlist.GroupBy(g => g.OrderID);
            var data2 = ticketlist.GroupBy(g => g.OrderID, c => "\t\t" + c.TicketNo + "  " + c.Description);

            foreach (var item in data)
            {
                Console.WriteLine("订单号:" + item.Key);
                foreach (var subItem in item)
                {
                    Console.WriteLine("\t\t" + subItem.TicketNo + "  " + subItem.Description);
                }
            }

            Console.WriteLine("=========================================");

            foreach (var item in data2)
            {
                Console.WriteLine("订单号:" + item.Key);
                foreach (var subItem in item)
                {
                    Console.WriteLine(subItem);
                }
            }
        }
    }
}
