using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class TempDataController : Controller
    {
        // GET: TempData
        public ActionResult Index()
        {

            //只用来临时存储的，存储一次就失效了，不会再共享啊什么的。
            TempData["Name"] = "胡歌";
            return View();
        }
    }
}