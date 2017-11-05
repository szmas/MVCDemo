using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    /// <summary>
    /// 应用场合：var主要用途是表示一个LINQ查询的结果。
    /// 这个结果可能是ObjectQuery<>或IQueryable<>类型的对象，也可能是一个简单的实体类型的对象。
    /// 这时使用var声明这个对象可以节省很多代码书写上的时间。
    /// </summary>
    class 隐式推断类型
    {



        public static void Run()
        {

            /*
             
             
             * 在C#中使用var声明一个对象时，编译器会自动根据其赋值语句推断这个局部变量的类型。
             * 赋值以后，这个变量的类型也就确定而不可以再进行更改。
             * 另外var关键字也用于匿名类的声明。
             

            1.被声明的变量是一个局部变量，而不是静态或实例字段；
            2.变量必须在声明的同时被初始化；编译器要根据初始化值推断类型
            3.初始化不能是一个匿名函数；
            4.初始化表达式不能是 null；
            5.语句中只声明一次变量，声明后不能更改类型；
            6.赋值的数据类型必须是可以在编译时确定的类型；
             */


            var num = 10;

            var str = "hello";

            var date = DateTime.Now;
        }
    }
}
