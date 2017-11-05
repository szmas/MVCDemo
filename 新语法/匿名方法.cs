using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    class 匿名方法
    {
        /// <summary>
        /// 委托
        /// </summary>
        /// <param name="name"></param>
        public delegate void Print(string name);

        public static void PrintName(string name)
        {
            Console.WriteLine(name);
        }

        public static void Run()
        {


            /*
             
             
             函数式编程的最大特点之一：把方法作为参数和返回值。 
             DGShowMsg -> MulticastDelegate(intPtr[]) -> Delegate(object,intPtr)
             匿名方法：编译后会生成委托对象，生成方法，然后把方法装入委托对象，最后赋值给 声明的委托变量。
             匿名方法可以省略参数：编译的时候 会自动为这个方法 按照 委托签名的参数 添加参数
             
             
             
             */


            Print print = new Print(PrintName);
            print("Mas");


            //匿名委托
            Print print2 = delegate(string name)
            {
                Console.WriteLine(name);
            };

            print2("Jack");


            //简化
            Print print3 = (name) =>
            {
                Console.WriteLine(name);
            };

            print3("Rose");


            //Lambda表达式
            Print print4 = g => Console.WriteLine(g);

            print4("Vivian");

        }
    }
}
