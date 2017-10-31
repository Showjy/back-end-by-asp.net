using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AndroidAPP02.Models;
using AndroidAPP02.Functions;

namespace AndroidAPP02.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Project/
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
        }
        [HttpGet, ActionName("Index")]
        public JsonResult JIndex()
        {
            return Json(db.Projects.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: /Project/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("Details")]
        public JsonResult JDetails(ProjDetailsViewModels para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }
     
            string idnum = para.id;
            Project project = db.Projects.Find(idnum);
            if (project == null)
            {
                return Json(new { MSG = "notfind" + idnum });
            }
            return Json(project);
        }


        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Project/Create
       
        [HttpPost]
        public JsonResult Create(ProjViewModels proj)
        {//[Bind(Include = "Id,Theme,Detail,Requirements,Member,Deadline")] 
            if (ModelState.IsValid)
            {
                Project project = new Project();
                var num = db.Projects.Count();

                IntToStringFun temp = new IntToStringFun();
                string Id = temp.IntToString(num+1);

                project.Id = Id;
                project.Theme = proj.Theme;
                project.Detail = proj.Detail;
                project.Requirements = proj.Requirements;
                project.Member = proj.Member;
                project.Deadline = proj.Deadline;
                project.Author = proj.Author;
                db.Projects.Add(project);
                db.SaveChanges();
                return Json(new { MSG = "create success" });
            }

            return Json(new { MSG = "create failed" });
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: /Project/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "Id,Theme,Detail,Requirements,Member,Deadline,Author")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return Json(project);
            }

            return Json(new { MSG ="failed"});
        }

        [HttpPost]
        public JsonResult MyProject(MyProjectViewModels myproject)
        {
            string author = myproject.Author;
            List<Project> mp = (from p in db.Projects where p.Author == author select p).ToList();
            return Json(mp);
        }

        // GET: /Project/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Project project = db.Projects.Find(id);
        //    if (project == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(project);
        //}

        // POST: /Project/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Project project = db.Projects.Find(id);
        //    db.Projects.Remove(project);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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