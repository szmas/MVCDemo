using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    class Fruit
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }
    class Apple : Fruit
    {

        public void Print()
        {
            Console.WriteLine("名称：{0}，价格：{1}", "苹果", 4.5);
        }
    }
}
