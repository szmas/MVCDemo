using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class _ToDictionary
    {

        public static void Run()
        {
            var ticketlist = _ToLookup.GetList();


            //循环操作
            Dictionary<int, List<Ticket>> dic = new Dictionary<int, List<Ticket>>();
            foreach (var item in ticketlist)
            {
                if (dic.ContainsKey(item.OrderID))
                {
                    dic[item.OrderID].Add(item);
                }
                else
                {
                    dic.Add(item.OrderID, new List<Ticket>() { item });
                }
            }


            foreach (KeyValuePair<int, List<Ticket>> keyvalue in dic)
            {
                Console.WriteLine("订单号:" + keyvalue.Key);
                foreach (var item in keyvalue.Value)
                {
                    Console.WriteLine("\t\t" + item.TicketNo + " " + item.Description);
                }
            }



            //dictionary中key是不能重复的，然而ToDictionary中并没有给我们做key的重复值判断，
            //那也就侧面说明ToDictionary在kv中只能是 “一对一”的关系

            //ticketlist.ToDictionary(g => g.OrderID);

            // key -->value  是一对一的关系

            var list = new List<Ticket>() { 
                 new Ticket(){ TicketNo="999-12311",OrderID=79121281,Description="改签"},
                 new Ticket(){ TicketNo="999-24572",OrderID=29321289,Description="退票"},
                 new Ticket(){ TicketNo="999-68904",OrderID=19321289,Description="成交"},
            };

            var data = list.ToDictionary(g => g.OrderID);

        }
    }
}
