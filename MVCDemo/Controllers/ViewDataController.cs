using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ViewDataController : Controller
    {
        // GET: ViewData
        public ActionResult Index()
        {
            //弱类型

            //因为ViewData和ViewBag本质上都是【ViewDataDictionary】类型，并且两者之间的数据共享，只不过提供了不同的语法操作方式而已。
            ViewData["Name"] = "胡歌";


           
            return View();
        }
    }
}