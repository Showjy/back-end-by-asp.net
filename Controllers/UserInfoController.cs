using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndroidAPP02.Models;

namespace AndroidAPP02.Controllers
{
    public class UserInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UserInfo/
        public ActionResult Index()
        {
            return View(db.UserInfoes.ToList());
        }
        [HttpGet, ActionName("Index")]
        public JsonResult JIndex()
        {
            return Json(db.UserInfoes.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: /UserInfo/Details/5
        public JsonResult Details(string id)
        {
            if (id == null)
            {
                return Json(new { ID="null"});
            }
            UserInfo userinfo = db.UserInfoes.Find(id);
            if (userinfo == null)
            {
                return  Json(new { MSG="no such id"});
            }
            return Json(userinfo,JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ActionName("Details")]
        public JsonResult JDetails(UserDetailsViewModels para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }
            
            string idnum = para.id;
            UserInfo project = db.UserInfoes.Find(idnum);
            if (project == null)
            {
                return Json(new { MSG = "notfind" + idnum });
            }
            return Json(project);
        }
        // GET: /UserInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserInfo/Create
       
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include="id,name,email,major,resume,experience")] UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                UserInfo temp = db.UserInfoes.Find(userinfo.id);
                if(temp!=null)
                {
                    db.UserInfoes.Remove(temp);
                }
                
                db.UserInfoes.Add(userinfo);
                db.SaveChanges();
                return Json(new { MSG = "success" });
                //return Json(userinfo);
            }

            return Json(new{MSG="failed"});
        }
        //UserInfo  以下功能由Create覆盖
        // GET: /UserInfo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userinfo = db.UserInfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: /UserInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,email,major,resume,experience")] UserInfo userinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userinfo);
        }

        // GET: /UserInfo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userinfo = db.UserInfoes.Find(id);
            if (userinfo == null)
            {
                return HttpNotFound();
            }
            return View(userinfo);
        }

        // POST: /UserInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserInfo userinfo = db.UserInfoes.Find(id);
            db.UserInfoes.Remove(userinfo);
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
