using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCDemo.Models
{
    public interface IPageOfList
    {
        long CurrentStart { get; }
        int PageIndex { get; set; }
        int PageSize { get; set; }
        int PageTotal { get; }
        long RecordTotal { get; set; }
    }
}
