using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{

    /// <summary>
    /// 它其实是使用默认的构造函数生成了一个对象。
    /// </summary>
    class 对象集合初始化器
    {
        public static void Run()
        {

            var pro = new Product() { Title = "小米手机", Price = 2000, status = true, AddTime = DateTime.Now, Type = "3C" };

            var liPro = new List<Product>() { new Product() { Title = "小米手机", Price = 2000, status = true, AddTime = DateTime.Now, Type = "3C" } ,
                                            new Product() { Title = "小米手机", Price = 2000, status = true, AddTime = DateTime.Now, Type = "3C" },
                                            new Product() { Title = "小米手机", Price = 2000, status = true, AddTime = DateTime.Now, Type = "3C" }
            };


            var arr = new string[] { "A", "B", "C" };
            string[] arr2 = { "A", "B", "C", "D" };
        }
    }
}
