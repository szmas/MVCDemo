using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhibernate.Data
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public NHibernateHelper()
        {
            //创建ISessionFactory
            _sessionFactory = GetSessionFactory();
        }

        /// <summary>
        /// 创建ISessionFactory
        /// </summary>
        /// <returns></returns>
        public ISessionFactory GetSessionFactory()
        {
            //配置ISessionFactory
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        /// <summary>
        /// 打开ISession
        /// </summary>
        /// <returns></returns>
        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
