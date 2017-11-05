using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{
    /// <summary>
    /// 定义一个委托
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    delegate int AddDel(int a, int b);
    class Lambda表达式
    {

        /*
         

         
         
            Lambda表达式的本质就是匿名函数，Lambda表达式基于数学中的λ演算得名，直接对应于其中的lambda抽象(lambda abstraction)，是一个匿名函数，即没有函数名的函数。“Lambda 表达式”是一个匿名函数，它可以包含表达式和语句，并且可用于创建委托或表达式树类型。 
            Lambda 表达式的运算符 =>，该运算符读为“goes to”。
            => 运算符具有与赋值运算符 (=) 相同的优先级
            Lambda的基本形式：(input parameters) => expression
            只有在 Lambda 有一个输入参数时，括号才是可选的；否则括号是必需的。 两个或更多输入参数由括在括号中的逗号分隔： (x, y) => x == y
            有时，编译器难于或无法推断输入类型。 如果出现这种情况，您可以按以下示例中所示方式显式指定类型： (int x, string s) => s.Length > x 
            使用空括号指定零个输入参数： () => SomeMethod()
            最常用的场景：Ienumable和Iqueryable接口的Where<>(c=>c.Id>3) 
         
         
         */

        public static void Run()
        {
            AddDel del = new AddDel(delegate(int a, int b)
            {
                return a + b;
            });

            del = delegate(int a, int b)
           {
               return a + b;
           };

            del = (int a, int b) =>
            {
                return a + b;
            };

            del = (int a, int b) => a + b;

            del = (a, b) => a + b;

        }
    }
}
