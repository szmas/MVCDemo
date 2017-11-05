using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{

    public class PostDataController : Controller
    {
        // GET: PostData
        public ActionResult Index()
        {

            //控制器将处理后的数据“传”给视图的方式

            //ViewData/ViewBag/TempData/Model

            return View();
        }



        /// <summary>
        /// 通过Request.Form["name"] 逐个获取 表单提交的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Post()
        {
            string name = Request.Form["name"];
            string age = Request.Form["age"];

            return Content(name + ":" + age);
        }


        /// <summary>
        /// 通过 FormCollection form逐个获取 表单提交的数据
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Post2(FormCollection form)
        {
            string name = form["name"];
            string age = form["age"];

            return Content(name + ":" + age);
        }


        /// <summary>
        /// 通过 实体对象 一次性获取 表单元素的数据，
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public ActionResult Post3(UserModel UserModel)
        {
            string name = UserModel.name;
            string age = UserModel.age;

            return Content(name + ":" + age);
        }

        public ActionResult Post4(string name, string age)
        {
            return Content(name + ":" + age);
        }



    }
}