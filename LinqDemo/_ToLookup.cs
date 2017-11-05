using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Ticket
    {
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Description { get; set; }
    }
    class _ToLookup
    {

        public static List<Ticket> GetList()
        {
            return new List<Ticket>()
            {
                 new Ticket(){ TicketNo="999-12311",OrderID=79121281,Description="改签"},
                 new Ticket(){ TicketNo="999-24572",OrderID=29321289,Description="退票"},
                 new Ticket(){ TicketNo="999-68904",OrderID=19321289,Description="成交"},
                 new Ticket(){ TicketNo="999-24172",OrderID=64321212,Description="未使用"},
                 new Ticket(){ TicketNo="999-24579",OrderID=19321289,Description="退票"},
                 new Ticket(){ TicketNo="999-21522",OrderID=79121281,Description="未使用"},
                 new Ticket(){ TicketNo="999-24902",OrderID=79121281,Description="退票"},
                 new Ticket(){ TicketNo="999-04571",OrderID=29321289,Description="改签"},
                 new Ticket(){ TicketNo="999-23572",OrderID=96576289,Description="改签"},
                 new Ticket(){ TicketNo="999-24971",OrderID=99321289,Description="成交"}
            };
        }

        public static void Run()
        {
            var ticketlist = GetList();


            //oDictionary的加强版，你也可以认为是一种新的字典数据结构，它就避免了这
            //种“一对一”的关系，采用“一对多”的实现。
            var dic = ticketlist.ToLookup(i => i.OrderID);
            var dic2 = ticketlist.ToLookup(i => i.OrderID, j => { return "\t\t" + j.TicketNo + "  " + j.Description; });


            foreach (var item in dic)
            {
                Console.WriteLine("订单号:" + item.Key);

                foreach (var item1 in item)
                {
                    Console.WriteLine("\t\t" + item1.TicketNo + "  " + item1.Description);
                }
            }

            Console.WriteLine("=========================================");

            foreach (var item in dic2)
            {
                Console.WriteLine("订单号:" + item.Key);

                foreach (var item1 in item)
                {
                    Console.WriteLine(item1);
                }
            }
        }

    }
}
