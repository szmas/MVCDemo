using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    /// <summary>
    /// C#3.0新语法：查询表达式，和SQL风格接近的代码
    /// 
    /// 最后：LINQ 查询语句 编译后会转成 标准查询运算符
    /// </summary>
    class LINQ
    {

        public static void Run()
        {

            var li = new List<string>() { "A", "B", "C", "D", "E", "F" };

            var data = from item in li
                       where item != "A"
                       let d = new { Name = item }
                       orderby item
                       select item;
            //select new { title = item };

            //以"from"开始，以"select 或 group by子句"结尾。输出是一个 IEnumerable<T> 或 IQueryable<T> 集合；


            //LINQ分组：
            li = new List<string>() { "A", "B", "C", "D", "E", "F", "A", "B", "C", };

            var data2 = from item in li
                        group item
                        by item;


            foreach (var item in data2)
            {
                Console.WriteLine("名称：" + item.Key + "，次数：" + item.Count());
                foreach (var subItme in item)
                {
                    Console.WriteLine(subItme);
                }
            }

            var liPro = new List<Product>() { new Product() { Title = "小米手机A", Price = 2000, status = true, AddTime = DateTime.Now, Type = "3C" } ,
                                            new Product() { Title = "小米手机B", Price = 3000, status = true, AddTime = DateTime.Now, Type = "3C" },
                                            new Product() { Title = "小米手机C", Price = 4000, status = true, AddTime = DateTime.Now, Type = "3C" }
            };

            var data3 = from item in liPro
                        group item
                        by item.Price;

            foreach (var item in data3)
            {
                Console.WriteLine("名称：" + item.Key + "，次数：" + item.Count());
                foreach (var subItme in item)
                {
                    Console.WriteLine(subItme.Title);
                }
            }

            //
            IEnumerable<IGrouping<string, string>> listGroup = li.ToLookup(c => c);

            foreach (var item in listGroup)
            {
                Console.WriteLine("名称：" + item.Key + "，次数：" + item.Count());
            }


            //就采用了一个ToDictionary的加强版，你也可以认为是一种新的字典数据结构，
            //它就避免了这种“一对一”的关系，采用“一对多”的实现。
            var listGroup2 = liPro.ToLookup(f => f.Price);


            foreach (var item in listGroup2)
            {
                Console.WriteLine("名称：" + item.Key + "，次数：" + item.Count());
                foreach (var subItem in item)
                {
                    Console.WriteLine(subItem.Title);
                }
            }


            //此外，我建议大家多使用reflector工具来查看C#源码和IL语言，
            //reflector就像一面照妖镜，任何C#语法糖在它面前都将原形毕露。

        }
    }
}
