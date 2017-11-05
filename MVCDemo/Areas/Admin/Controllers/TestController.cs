using MVCDemo.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    

    /// <summary>
    /// ViewResult--->ViewResultBase--->ActionResult
    /// </summary>
    public class TestController : Controller
    {
        // GET: Admin/Test
        public ActionResult Index()
        {
            return View();
        }

        public string A()
        {
            return "Hello World";
        }

        public int B()
        {
            return 110;
        }

        public decimal C()
        {
            return 11.11m;
        }

        public bool D()
        {
            return true;
        }

        public DateTime E(string t)
        {
            if (t == "utc")
                return DateTime.UtcNow;
            else
                return DateTime.Now;
        }



        /// <summary>
        /// 返回对象时，将调用ToString()方法，返回“NameSpace.ClassName”形式的类名。
        /// </summary>
        /// <returns></returns>
        public Customer F()
        {

            return new Customer();

        }

        

        /// <summary>
        /// 返回指定View
        /// </summary>
        /// <returns></returns>
        public ActionResult G()
        {
            return View("index");
        }


    }
}