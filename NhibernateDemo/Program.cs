using Nhibernate.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            dt_ArticleBusiness customersBusiness = new dt_ArticleBusiness();

            var result = customersBusiness.GetCustomerList(c=>true);

            foreach (var item in result)
            {
                Console.WriteLine("ID={0},title={1}", item.Id, item.Title);
            }
        }
    }
}
