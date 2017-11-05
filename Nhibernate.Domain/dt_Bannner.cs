using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nhibernate.Domain
{
    public class dt_Bannner
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual int ClassId { get; set; }
        //public virtual dt_Article dt_Article { get; set; }
    }
}
