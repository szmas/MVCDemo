using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhibernate.Domain
{
   public class dt_Channel
    { 
        /// <summary>
        /// ID of the Employee, in Database its a primary key.
        /// </summary>
        public virtual int Id { get; set; }
        /// <summary>
        /// Name of the Employee
        /// </summary>
        public virtual string Title { get; set; }
    }
}
