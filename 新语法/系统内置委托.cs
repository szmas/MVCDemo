using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 新语法
{


    #region  逆变

    interface IFruit<in T>
    {
        void Print(T t);
    }

    class CApple<T> : IFruit<T>
    {
        public void Print(T t)
        {
            Console.WriteLine("");
        }

    }

    #endregion

    #region  协变

    interface IFruit2<out T>
    {
        T Find();
    }

    class CApple2<T> : IFruit2<T> where T : new()
    {

        public T Find()
        {
            return new T();
        }
    }

    #endregion


    class 系统内置委托
    {

        /*
         
         
         
         
         
         
         
         
         
        System.Func 代表有返回类型的委托
        public delegate TResult  Func<out TResult>(); 
        public delegate TResult  Func<in T, out TResult>(T arg); 
        ......
        注：输入泛型参数-in 最多16个，输出泛型参数 -out 只有一个。


        System.Action 代表无返回类型的委托
        public delegate void Action<in T>(T obj);    //list.Foreach
        public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2); 
        ......
        注:参数最多16个


        System.Predicate<T> 代表返回bool类型的委托   - 用作执行表达式
        public delegate bool Predicate<in T>(T obj);  //list.Find
        System.Comparison<T> 代表返回int类型的委托  - 用作比较两个参数的大小
        public delegate int Comparison<in T>(T x, T y); //list.Sort
         
         
         
         
         */

        public static void Run()
        {

            //协变指的是委托方法的返回值类型  直接或间接继承自委托签名的返回值类型，
            //逆变则是参数类型继承自委托方法的参数类型





            #region 协变  返回值从子类到基类  out


            IFruit2<Fruit> Ifruit = new CApple2<Apple>();



            Func<string> fun1 = delegate()
            {
                return "hello";
            };

            //返回值string  签名是object  所以是协变

            //如果某个返回的类型可以由其派生类型替换，那么这个类型就是支持协变的
            Func<object> fun2 = fun1;//string转成了object 所以是协变



            Func<Apple> F_apple = delegate()
            {
                return new Apple();
            };

            Func<Fruit> F_fruit = F_apple; //水果变苹果 协变 out

            #endregion


            #region 逆变 参数从基类到子类     in


            IFruit<Apple> Iapple = new CApple<Fruit>();


            Action<object> test = delegate(object o)
            {
                Console.WriteLine(o);
            };

            //签名方法参数是object 被string替代

            //如果某个参数类型可以由其基类替换，那么这个类型就是支持逆变的。
            Action<string> test2 = test; // object转成了string 所以是逆变

            Action<Fruit> fruit = delegate(Fruit f)
            {
                Console.WriteLine(f.Name);
            };

            Action<Apple> apple = fruit;//苹果变水果  逆变 in

            #endregion


            Predicate<string> test4 = delegate(string username)
            {
                return username == "admin";
            };


            Comparison<string> test5 = delegate(string a, string b)
            {
                return a.CompareTo(b);
            };


            test2("QQ");

            var str = fun2();

            bool flag = test4("admin");


            //值 含义 小于 0 x 小于 y。 0 x 等于 y。 大于 0 x 大于 y。
            int result = test5("mas", "rose");


            var li = new List<string>() { "G", "F", "E", "A", "B", "C", "admin" };


            li.Sort(test5);


            var str2 = li.Find(test4);

        }
    }
}
