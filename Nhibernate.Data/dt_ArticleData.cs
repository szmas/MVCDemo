using Nhibernate.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate.Data
{
    public class dt_ArticleData
    {
        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<dt_Article> GetCustomerList(Expression<Func<dt_Article, bool>> where)
        {
            try
            {
                NHibernateHelper nhibernateHelper = new NHibernateHelper();
                ISession session = nhibernateHelper.GetSession();
                return session.Query<dt_Article>().Where(where).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
