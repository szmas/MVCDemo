using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo
{
    class CRUD
    {

        static PcbEntities db = new PcbEntities();

        /*
         
         
        DBContext封装 .NET Framework 和数据库之间的连接。此类用作“创建”、“读取”、“更新”和“删除”操作的网关。
        DBContext 类为主类，用于与作为对象（这些对象为 EDM 中定义的实体类型的实例）的数据进行交互。
        DBContext 类的实例封装以下内容：

        到数据库的连接，以 EntityConnection 对象的形式封装。
        描述该模型的元数据，以 MetadataWorkspace 对象的形式封装
        用于管理缓存中持久保存的对象的 ObjectStateManager 对象
         
         
         
         */

        static void Insert()
        {


            #region 新增 1.0

            dt_Article _Customers = new dt_Article
            {
                Title = "洛阳西街",
                ClassId = 33,
                AddTime = DateTime.Now
            };
            //方法一
            //db.dt_Article.Add(_Customers);

            //方法二
            DbEntityEntry<dt_Article> entry = db.Entry<dt_Article>(_Customers);
            entry.State = System.Data.Entity.EntityState.Added;

            int result = db.SaveChanges();

            #endregion

        }


        #region 2.1 简单查询 延迟加载


        /*
         
         
         1、 EF本身查询方法 返回的都是 IQueryable接口，此时并未查询数据库；只有当调用接口方法 获取 数据时，才会查询数据库

         2、 【延时加载】，本质原因之一：当前可能通过多个SQO方法 来组合 查询条件，那么每个方法 都只是添加一个查询条件而已，无法确定本次查询条件 是否 已经添加结束  
             所以，没有办法在每个SQO方法的时候确定SQL语句是什么，只能返回一个 包含了所有添加的条件的 DBQuery 对象，  
             当使用这个 DBQuery对象 的时候，才根据所有条件 生成 sql语句，查询数据库
         
         
         */

        static void QueryDelay_01()
        {
            DbQuery<dt_Article> dbQuery = db.dt_Article.Where(u => u.Title == "张学友").OrderBy(u => u.Title).Take(2)
            as System.Data.Entity.Infrastructure.DbQuery<dt_Article>;

            //获得 延迟查询对象后，调用对象的 获取第一个数据方法，此时，【就会根据之前的条件】，生成sql语句，查询数据库了~~！
            dt_Article usr01 = dbQuery.FirstOrDefault();// ToList()......
            Console.WriteLine(usr01.Title);
        }

        //2.1.2【延迟加载】- 针对于 外键实体 的延迟(按需加载)！
        //                  本质原因之二：对于外键属性而言，EF会在用到这个外键属性的时候才去查询 对应的 表。
        static void QueryDelay_02()
        {
            IQueryable<dt_Article> _Orders = db.dt_Article.Where(a => a.Title == "TOMSP");//真实返回的 DbQuery 对象，以接口方式返回

            //a.此时只查询了 地址表


            dt_Article order = _Orders.FirstOrDefault();
            //b.当访问 地址对象 里的 外键实体时，EF会查询 地址对应 的用户表;查询到之后，将数据 装入 这个外键实体

            //Console.WriteLine(order.dt_Channel.Title);



            //c.【延迟加载】按需加载 的缺点：每次调用外键实体时，都会去查询数据库（EF有小优化：相同的外键实体只查一次）
            IQueryable<dt_Article> orderList = db.dt_Article;
            foreach (dt_Article o in orderList)
            {
                //Console.WriteLine(o.Id + ":ContactName=" + o.dt_Channel.Title);
            }
        }
        #endregion


        #region 2.2 根据条件 排序 和查询 + List<dt_Article> GetListBy<TKey>
        /// <summary>
        /// 2.2 根据条件 排序 和查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <param name="orderLambda">排序条件 lambda表达式</param>
        /// <returns></returns>
        public List<dt_Article> GetListBy<TKey>(Expression<Func<dt_Article, bool>> whereLambda, Expression<Func<dt_Article, TKey>> orderLambda)
        {
            return db.dt_Article.Where(whereLambda).OrderBy(orderLambda).ToList();
        }
        #endregion

        #region 2.3 分页查询 + List<P05MODEL.User> GetPagedList<TKey>
        /// <summary>
        /// 2.3 分页查询 + List<Customers> GetPagedList<TKey>
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public List<dt_Article> GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<dt_Article, bool>> whereLambda,
 Expression<Func<dt_Article, TKey>> orderBy)
        {
            // 分页 一定注意： Skip 之前一定要 OrderBy
            return db.dt_Article.Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        #endregion




        #region 3.0 官方推荐的 修改方式（先查询，再修改）
        /// <summary>
        /// 3.0 官方推荐的 修改方式（先查询，再修改）
        /// </summary>
        static void Edit()
        {
            //1.查询出一个 要修改的对象 -- 注意：此时返回的 是 一个 Customers类的 代理类对象（包装类对象）

            dt_Article _Customers = db.dt_Article.Where(u => u.Title == "zhang").FirstOrDefault();
            Console.WriteLine("修改前：" + _Customers.Title);

            //2.修改内容 -- 注意：此时其实操作的 是 代理类对象 的属性，这些属性，会将值设置给内部的 Customers对象对应的属性，同时标记此属性为已修改状态
            _Customers.Title = "刘德华";

            //3.重新保存到数据库 -- 注意：此时 ef上下文，会检查容器内部 所有的对象，找到标记为修改的对象，然后找到标记为修改的对象属性，生成对应的update语句执行！
            db.SaveChanges();
            Console.WriteLine("修改成功：");
            Console.WriteLine(_Customers.Title);
        }
        #endregion

        #region 3.1 自己优化的 修改方式（创建对象，直接修改）
        /// <summary>
        /// 3.1 自己优化的 修改方式（创建对象，直接修改）
        /// </summary>
        static void Edit2()
        {
            //1.查询出一个 要修改的对象
            dt_Article _Customers = new dt_Article()
            {
                Title = "洛阳西街",
                ClassId = 33,
                AddTime = DateTime.Now,
                Id = 33
            };

            //2.将 对象 加入 EF容器,并获取 当前实体对象 的 状态管理对象
            DbEntityEntry<dt_Article> entry = db.Entry<dt_Article>(_Customers);

            //3.设置 该对象 为被修改过
            entry.State = EntityState.Unchanged;

            //4.设置 该对象 的 ContactName属性 为 修改状态，同时 entry.State 被修改为 Modified 状态
            entry.Property("Title").IsModified = true;


            //var u = db.Customers.Attach(_Customers);
            //u.Title = "郭富城";

            //3.重新保存到数据库 -- ef 上下文 会 根据 实体对象的 状态 ，根据 entry.State =Modified 的值 生成 对应的 update sql 语句
            db.SaveChanges();
            Console.WriteLine("修改成功：");
            Console.WriteLine(_Customers.Title);
        }
        #endregion


        #region 4.0 删除 -void Delete()
        /// <summary>
        /// 4.0 删除
        /// </summary>
        static void Delete()
        {
            //4.1创建要删除的 对象
            dt_Article u = new dt_Article() { Id = 33 };
            //4.2附加到 EF中
            db.dt_Article.Attach(u);
            //4.3标记为删除 注意：此方法 就是 起到了 标记 当前对象  为 删除状态 ！
            db.dt_Article.Remove(u);

            /*
                也可以使用 Entry 来附加和 修改
                DbEntityEntry<dt_Article> entry = db.Entry<dt_Article>(u);
                entry.State = System.Data.EntityState.Deleted;
             */

            //4.4执行删除sql
            db.SaveChanges();
            Console.WriteLine("删除成功~~~");
        }
        #endregion




        #region 5.0 批处理 -- 上下文 SaveChanges 方法 的 好处！！！！
        /// <summary>
        /// 批处理 -- 上下文 SaveChanges 方法 的 好处！！！！
        /// </summary>
        static void SaveBatched()
        {
            //5.1新增数据
            dt_Article _Customers = new dt_Article
            {
                Title = "洛阳西街",
                ClassId = 33,
                AddTime = DateTime.Now
            };
            db.dt_Article.Add(_Customers);

            //5.2新增第二个数据
            dt_Article _Customers2 = new dt_Article
            {
                Title = "洛阳西街",
                ClassId = 33,
                AddTime = DateTime.Now
            };
            db.dt_Article.Add(_Customers2);

            //5.3修改数据
            dt_Article usr = new dt_Article() { Title = "zhao", Author = "赵牧" };
            DbEntityEntry<dt_Article> entry = db.Entry<dt_Article>(usr);
            entry.State = EntityState.Unchanged;
            entry.Property("Title").IsModified = true;

            //5.4删除数据
            dt_Article u = new dt_Article() { Id = 33 };
            //4.2附加到 EF中
            db.dt_Article.Attach(u);
            //4.3标记为删除 注意：此方法 就是 起到了 标记 当前对象  为 删除状态 ！
            db.dt_Article.Remove(u);

            db.SaveChanges();
            Console.WriteLine("批处理 完成~~~~~~~~~~~~！");
        }
        #endregion

        #region 5.1 批处理 -- 一次新增 50条数据 -void BatcheAdd()
        /// <summary>
        /// 5.1 批处理 -- 一次新增 50条数据
        /// </summary>
        static void BatcheAdd()
        {
            for (int i = 0; i < 50; i++)
            {
                dt_Article _Customers = new dt_Article
                {
                    Title = "洛阳西街",
                    ClassId = 33,
                    AddTime = DateTime.Now
                };
                db.dt_Article.Add(_Customers);
            }
            db.SaveChanges();
        }
        #endregion


    }
}
