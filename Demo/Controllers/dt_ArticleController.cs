using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo;

namespace Demo.Controllers
{
    public class dt_ArticleController : Controller
    {
        private pengchengbeiEntities db = new pengchengbeiEntities();

        // GET: dt_Article
        public ActionResult Index()
        {
            return View(db.dt_Article.ToList());
        }

        // GET: dt_Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dt_Article dt_Article = db.dt_Article.Find(id);
            if (dt_Article == null)
            {
                return HttpNotFound();
            }
            return View(dt_Article);
        }

        // GET: dt_Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dt_Article/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,Title,Author,Form,Keyword,Description,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,ver,filepath,SortId,Download,SubTitle,BigImgUrl,IndexImgUrl,Editor,Herf,HerfFlag,htmlpath,ImgUrl5,Spell")] dt_Article dt_Article)
        {
            if (ModelState.IsValid)
            {
                db.dt_Article.Add(dt_Article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dt_Article);
        }

        // GET: dt_Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dt_Article dt_Article = db.dt_Article.Find(id);
            if (dt_Article == null)
            {
                return HttpNotFound();
            }
            return View(dt_Article);
        }

        // POST: dt_Article/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,Title,Author,Form,Keyword,Description,Daodu,ImgUrl,Content,Click,IsMsg,IsTop,IsRed,IsHot,IsSlide,IsLock,AddTime,ver,filepath,SortId,Download,SubTitle,BigImgUrl,IndexImgUrl,Editor,Herf,HerfFlag,htmlpath,ImgUrl5,Spell")] dt_Article dt_Article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dt_Article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dt_Article);
        }

        // GET: dt_Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dt_Article dt_Article = db.dt_Article.Find(id);
            if (dt_Article == null)
            {
                return HttpNotFound();
            }
            return View(dt_Article);
        }

        // POST: dt_Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dt_Article dt_Article = db.dt_Article.Find(id);
            db.dt_Article.Remove(dt_Article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
