using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{

    /// <summary>
    /// 标准查询运算符(SQO)
    /// </summary>
    class 标准查询运算符
    {

        /*
         
         
         
         
         
         
         
         
         标准查询运算符：定义在System.Linq.Enumerable类中的50多个为IEnumerable<T>准备的扩展方法,这些方法用来对它操作的集合进行查询筛选.

        筛选集合Where：需要提供一个带bool返回值的“筛选器”，从而表明集合中某个元素是否应该被返回。
        查询投射,返回新对象集合 IEnumerable<TSource> Select()
        统计数量int Count()
        多条件排序 OrderBy().ThenBy().ThenBy()
        集合连接 Join()
        ......
        延迟加载：Where
        即时加载：FindAll

        SQO缺点：语句太庞大复杂
         
         
         
         
         
         
         
         */


        public static void Run()
        {
            var li = new List<string>() { "A", "B", "C", "D", "E", "F" };

            var data = li.Where(g => g != "A").OrderBy(g => g);
        }
    }
}
