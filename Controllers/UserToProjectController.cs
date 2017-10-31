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
    public class UserToProjectController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UserToProject/
        public ActionResult Index()
        {
            return View(db.UserToProjects.ToList());
        }
        [HttpGet, ActionName("Index")]
        public JsonResult JIndex()
        {
            return Json(db.UserToProjects.ToList(), JsonRequestBehavior.AllowGet);
        }
        // GET: /UserToProject/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToProject usertoproject = db.UserToProjects.Find(id);
            if (usertoproject == null)
            {
                return HttpNotFound();
            }
            return View(usertoproject);
        }
        
        
        
        [HttpPost]
        public JsonResult DetailsForId( UserToProjectViewModels1 para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }
          
            string idnum = para.id;
            UserToProject project = db.UserToProjects.Find(idnum);
            if (project == null)
            {
                return Json(new { MSG = "notfind" + idnum });
            }
            return Json(project);
        }

        
        //bug  !!!!!!!
        //here

        [HttpPost]
        public JsonResult DetailsForUserId(UserToProjectViewModels2 para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }
            
            string idnum = para.UserId;

            List<UserToProject> project = (from p in db.UserToProjects where p.UserId == idnum select p).ToList();

            List<Project> pjlist = new List<Project>();


            
            for (int i = 0; i < project.Count(); i++)
            {
                string idnum2 = project[i].ProjectId;
                List<Project> temp = (from p in db.Projects where p.Id == idnum2 select p).ToList();
                           //select new
                           //{
                           //    pr.Author,
                           //    pr.Deadline,
                           //    pr.Detail,
                           //    pr.Id,
                           //    pr.Member,
                           //    pr.Requirements,
                           //    pr.Theme

                           //});
                
               
                   Project pj = new Project();
                   pj.Author = temp[0].Author;
                   pj.Deadline = temp[0].Deadline;
                   pj.Detail = temp[0].Detail;
                   pj.Id = temp[0].Id;
                   pj.Member = temp[0].Member;
                   pj.Requirements = temp[0].Requirements;
                   pj.Theme = temp[0].Theme;
                   pjlist.Add(pj);

               
               
                
                    
                    
                    
                
            }
            
            if (pjlist.Count==0)
            {
               return Json(new { MSG = "notfind " + idnum});
            }
            return Json(pjlist);
        }


        [HttpPost]
        public JsonResult DetailsForProjectId(UserToProjectViewModels3 para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }

            string idnum = para.ProjectId;

            List<UserToProject> project = (from p in db.UserToProjects where p.ProjectId == idnum select p).ToList();

            if (project == null)
            {
                return Json(new { MSG = "notfind" + idnum });
            }
            return Json(project);
        }

        [HttpPost]
        public JsonResult DetailsForBothId(UserToProjectViewModels4 para)
        {
            if (para == null)
            {
                return Json(new { MSG = para });
            }
            
            string idnum1 = para.UserId;
            string idnum2 = para.ProjectId;

            List<UserToProject> project = (from p in db.UserToProjects where p.UserId==idnum1 && p.ProjectId == idnum2 select p).ToList();

            if (project == null)
            {
                return Json(new { MSG = "notfind" + idnum1 + "+" + idnum2 });
            }
            return Json(project);
        }

        // GET: /UserToProject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /UserToProject/Create
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(UserToProjectViewModels4 usertoproject)
        {
            if (ModelState.IsValid)
            {
                UserToProject u2p = new UserToProject();
                var num = db.UserToProjects.Count();

                IntToStringFun temp = new IntToStringFun();
                string Id = temp.IntToString(num+1);
                
                u2p.id = Id;
                u2p.UserId = usertoproject.UserId;
                u2p.ProjectId = usertoproject.ProjectId;
                u2p.status = "waiting";
                db.UserToProjects.Add(u2p);
                db.SaveChanges();
                return Json(new { MSG = "create successed" });
            }

            return Json(new { MSG = "create failed" });
        }

        // GET: /UserToProject/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserToProject usertoproject = db.UserToProjects.Find(id);
            if (usertoproject == null)
            {
                return HttpNotFound();
            }
            return View(usertoproject);
        }

        // POST: /UserToProject/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include="id,UserId,ProjectId,status")] UserToProject usertoproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usertoproject).State = EntityState.Modified;
                db.SaveChanges();
                return Json(usertoproject);
            }
            return Json(new { MSG="Edit failed"});
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
