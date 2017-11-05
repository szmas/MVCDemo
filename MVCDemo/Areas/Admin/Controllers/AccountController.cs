using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewBag.LoginState = "登陆前";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            ViewBag.LoginState = "登陆后,邮箱：" + fc["email"] + ",密码：" + fc["password"];
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}