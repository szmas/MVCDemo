using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    class 参数默认值
    {
        public static void Print(string name = "Mas", int age = 18)
        {

            Console.WriteLine("姓名：{0},年龄：{1}", name, age);
        }

        public static void Run()
        {
            //默认赋值
            Print("Jack");

            //指定变量赋值
            Print(age: 24);
        }
    }
}
