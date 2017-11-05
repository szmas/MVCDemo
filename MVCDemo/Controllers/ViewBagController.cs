using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ViewBagController : Controller
    {
        // GET: ViewBag
        public ActionResult Index()
        {

            /*
             
             Controller的数据怎么就传到View了，我明明只给Controller中的ViewData/ViewBag/TempData/赋值了，或者只把对象传给了View方法。
             View和Controller中都有ViewData/ViewBag/TempData这几个对象，
             在给Controller中这些对象赋值后，Controller会把这些值赋值給View中对应的这几个对象。
             
             
             */

            ///动态类型  dynamic
            ViewBag.Name = "胡歌";


            //动态类型Model

            List<string> li = new List<string>() { "A", "B", "C", "D", "E", "F" };

            return View(li);////存入 ViewData.Model属性
        }
    }
}