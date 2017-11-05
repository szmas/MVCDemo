using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{

    /// <summary>
    /// 本质就是静态方法
    /// 扩展方法的本质：编译时，直接将 str.WriteSelf(2015) 替换成 StringUtil.WriteSelf(str,2015);
    /// </summary>
    class 扩展方法
    {

        /*
         
         
         
         
         编译器认为一个表达式是要使用一个实例方法,但没有找到,就会检查导入的命名空间和当前命名空间里所有的扩展方法,并匹配到适合的方法.
        注意:1.实例方法优先于扩展方法(允许存在同名实例方法和扩展方法)2.可以在空引用上调用扩展方法!3.可以被继承4.并不是任何方法都能作为扩展方法使用，必须有特征：
        它必须放在一个非嵌套、非泛型的静态类中(的静态方法);
        它至少有一个参数;
        第一个参数必须附加 this 关键字;
        第一个参数不能有任何其他修饰符（out/ref）
        第一个参数不能是指针类型
        看看这两个接口的方法：IEnumerable<T> ，IQueryable<T>
         
         
         
         
         
         
         
         */

        public static void Run()
        {

            "中国深圳".WriteSelf(2015);

        }
    }

    public static class StringUnit
    {

        public static void WriteSelf(this string str, int year)
        {
            Console.WriteLine(str + " " + year);
        }

    }
}
