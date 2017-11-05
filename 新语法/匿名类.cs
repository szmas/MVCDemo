using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{

    /// <summary>
    /// 匿名类是只读的
    /// </summary>
    class 匿名类
    {

        /*
         
         
         
         
         
         在编译后会生成一个【泛型类】，包含：

        a. 获取所有初始值的构造函数，顺序与属性顺序一样；

        b.公有的只读属性，属性不能为null/匿名函数/指针；

        c.属性的私有只读字段；

        d.重写的Equals,GetHashCode,ToString()方法
        用处：

        a.避免过度的数据累积

        b.为一种情况特别进行的数据封装 

        c.避免进行单调重复的编码

        应用场合：当直接使用select new { object initializer }这样的语法就是将一个LINQ查询的结果返回到一个匿名类中。

        注意：

        1. 当出现“相同”的匿名类的时候，编译器只会创建一个匿名类

        2. 编译器如何区分匿名类是否相同？

        根据：属性名，属性值（因为这些属性是根据值来确定类型的），属性个数，属性的顺序。

        3、匿名类的属性是只读的，可放心传递，可用在线程间共享数据
         
         
         
         
         
         
         
         
         */

        public static void Run()
        {

            //匿名类
            //属性名字和顺序不同会生成不同类
            var date = new { ID = 1, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m };


            //匿名数组
            var arrDate = new[]{
                            new { ID = 1, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m },
                            new { ID = 2, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m },
                            new { ID = 3, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m },
                            new { ID = 4, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m },
                            new { ID = 5, Name = "Mas", AddTime = DateTime.Now, Status = true, Money = 1.4m }
            };

        }
    }
}
