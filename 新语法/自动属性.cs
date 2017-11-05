using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{

    /// <summary>
    /// 编译器会自动生成所需的成员变量。
    /// </summary>
    class 自动属性
    {
        public int ID { get; set; }

        // 上面的ID属性（自动属性）等同于下面的ID属性

        // private int _id;
        // public int ID
        // {
        //     get { return _id; }
        //     set { _id = value; }
        // }

        public string Name { get; set; }
        public DateTime Time { get; set; }
        public decimal Money { get; set; }
        public bool status { get; set; }

        public int getID { get; private set; }

        public int setID { get; private set; }
    }
}
