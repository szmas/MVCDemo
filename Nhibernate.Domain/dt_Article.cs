using System;

using System.Linq;
using System.Text;

namespace Nhibernate.Domain
{
    /// <summary>
    /// Sample class to demostrate the Load and Save of objects thru NHibernate
    /// </summary>
    public class dt_Article
    {
        /// <summary>
        /// ID of the Employee, in Database its a primary key.
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Name of the Employee
        /// </summary>
        public virtual string Title { get; set; }

        public virtual int ClassId { get; set; }

        //public virtual Iesi.Collections.Generic.ISet<dt_Channel> dt_Channel { get; set; }
    }
}
