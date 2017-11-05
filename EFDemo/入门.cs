using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class 入门
    {

        public static void Run()
        {


            PcbEntities db = new PcbEntities();
            dt_Article customer = new dt_Article { Title = "东海五彩金轮", ClassId = 27, Author = "楚留香", AddTime = DateTime.Now };
            db.dt_Article.Add(customer); //这里只相当于构造sql语句
            db.SaveChanges(); //这里才进行数据库操作，相当于按F5执行


            //简单查询
            var result = from c in db.dt_Article select c;

            //linq写法
            var d1 = from c in db.dt_Article where c.Title == "才" select c;


            //Lambda表达式写法
            db.dt_Article.Where(g => g.Title == "才");


            // 排序分页写法：
            db.dt_Article.OrderBy(g => g.Id).Skip(0).Take(10);



            #region 左连接，右连接，全连接，笛卡儿积

            //左外连接：可以的连接有Join 和 GroupJoin 方法。
            //GroupJoin组联接等效于左外部联接，它返回第一个（左侧）数据源的每个元素（即使其他数据源中没有关联元素）。


            //inner join
            var d2 = from a in db.dt_Article
                     join b in db.dt_Channel
                     on a.ClassId equals b.Id
                     select new
                     {
                         article = a,
                         channelName = b.Title
                     };

            foreach (var item in d2)
            {
                Console.WriteLine(item.article.Title + "" + item.channelName);
            }

            /*
             
            SELECT 
            [Extent1].*, 
            [Extent2].[Title] AS [Title1]
            FROM  [dbo].[dt_Article] AS [Extent1]
            INNER JOIN [dbo].[dt_Channel] AS [Extent2] ON [Extent1].[ClassId] = [Extent2].[Id]
             
             */



            //left join    
            var d3 = from a in db.dt_Article
                     join b in db.dt_Channel
                     on a.ClassId equals b.Id into g
                     from c in g.DefaultIfEmpty()
                     select new
                     {
                         article = a,
                         channelName = (c == null ? String.Empty : c.Title)
                     };

            /*
             
            SELECT Extent1.*,
            [Extent2].[Title] AS [Title1]
            FROM  [dbo].[dt_Article] AS [Extent1]
            LEFT OUTER JOIN [dbo].[dt_Channel] AS [Extent2] ON [Extent1].[ClassId] = [Extent2].[Id]
             
             */

            foreach (var item in d3)
            {
                Console.WriteLine(item.article.Title + "" + item.channelName);
            }


            //right join    
            var d4 = from b in db.dt_Channel
                     join a in db.dt_Article
                     on b.Id equals a.ClassId into g
                     from c in g.DefaultIfEmpty()
                     select new
                     {
                         article = c,
                         channelName = b.Title
                     };

            /*
             
            SELECT Extent2.*,
            [Extent1].[Title] AS [Title1]
            FROM  [dbo].[dt_Channel] AS [Extent1]
            LEFT OUTER JOIN [dbo].[dt_Article] AS [Extent2] ON [Extent1].[Id] = [Extent2].[ClassId]
             
             */

            foreach (var item in d4)
            {
                if (item.article != null)
                {
                    Console.WriteLine(item.article.Title + "" + item.channelName);
                }
            }


            //full join 

            var d5 = d3.Concat(d4);



            var d6 = from a in db.dt_Article
                     from b in db.dt_Channel
                     select new
                     {
                         article = a,
                         channelName = b.Title
                     };



            // 笛卡儿积(cross join)

            /*
             
             SELECT 
            [Extent1].*, 
            [Extent2].[Title] AS [Title1]
            FROM  [dbo].[dt_Article] AS [Extent1]
            CROSS JOIN [dbo].[dt_Channel] AS [Extent2]
             
             */

            foreach (var item in d6)
            {
                Console.WriteLine(item.article.Title + "" + item.channelName);
            }


            #endregion



            //可使用的聚合运算符有Average、Count、Max、Min 和 Sum。

            var total = db.dt_Article.Sum(g => g.SortId);




            //不支持在查询中引用非标量闭包（如实体）。在执行这类查询时，会引发 NotSupportedException 异常，
            //并显示消息“无法创建类型为“结束类型”的常量值。此上下文中仅支持基元类型(‘如 Int32、String 和 Guid’)



            //延迟加载

            //延迟加载：又称作懒加载。也就是Linq To EF并不是直接将数据查询出来，而是要用到具体数据的时候才会加载到内存



            #region IQueryable接口与IEnumberable接口的区别

            /*
         
            IQueryable接口与IEnumberable接口的区别：  
         
            IEnumerable<T> 泛型类在调用自己的SKip 和 Take 等扩展方法之前数据就已经加载在本地内存里了，
            而IQueryable<T> 是将Skip ,take 这些方法表达式翻译成T-SQL语句之后再向SQL服务器发送命令。
            也是延迟在我要真正显示数据的时候才执行。

            linq to ef中使用Ienumberable与Iqueryable的区别，要用到的SQL Server Profiler工具
         
          
             */

            #endregion

            /*

            Include是将关联实体一块加载

            ToList等可以直接将数据加载到内存

            使用机制的选择

            关于上下文使用注意事项

            不同的上下文实例来直接控制对应的实体
            实体只能由一个上下文跟踪管理
            EF上下文的ObjectStateMagner管理实体
            批量操作时提交数据库的选择
            延迟加载机制的选择
            查询Distinct的使用数据量大小适时的选择是在内存中操作还是在数据库中操作


             */

        }
    }
}
