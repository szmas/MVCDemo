using Nhibernate.Data;
using Nhibernate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate.Business
{
    public class dt_ArticleBusiness
    {
        private dt_ArticleData _customersData;
        public dt_ArticleBusiness()
        {
            _customersData = new dt_ArticleData();
        }
        /// <summary>
        /// 根据条件得到客户信息集合
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns>客户信息集合</returns>
        public IList<dt_Article> GetCustomerList(Expression<Func<dt_Article, bool>> where)
        {
            return _customersData.GetCustomerList(where);
        }
    }
}
