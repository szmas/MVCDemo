using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ValidationModelController : Controller
    {
        // GET: ValidationModel
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {

            if (ModelState.IsValid)
            {
                return View();
            }

            return View();
        }
    }
}