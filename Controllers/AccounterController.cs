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
    public class AccounterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Project/
        public ActionResult Index()
        {
            return View(db.Accounters.ToList());
        }

        //Post /Accounter/Login
        [HttpPost]
        public JsonResult Login(Accounter loger)
        {
            if (loger == null)
            {
                return Json(new { MSG = "failed" });
            }
            //List<Accounter> check = (from p in db.Accounters where p.id == loger.id && p.password == loger.password select p).ToList();
            var check = (from p in db.Accounters 
                         where p.id == loger.id 
                         && p.password == loger.password 
                         select p);
            //if (check.Count()==0)
            if (check==null)
            {
                return Json(new { MSG = "no such loger" });
            }
            return Json(new { MSG = "success" });
        }




        //Post /Accounter/Regist
        [HttpPost]
        public JsonResult Regist(RegisterViewModel Register)
        {
            if (Register == null)
            {
                return Json(new { MSG = "failed" });
            }
            if (Register.Password != Register.ConfirmPassword)
            {
                return Json(new { MSG = "please confirm password" });
            }
            List<Accounter> check = (from p in db.Accounters where p.id == Register.UserName select p).ToList(); ;
            if (check.Count()>0)
            {
                return Json(new { MSG = "already regist" });
            }
            Accounter rg = new Accounter();
            rg.id = Register.UserName;
            rg.password = Register.Password;

            db.Accounters.Add(rg);

            UserInfo ui = new UserInfo();
            ui.email = "";
            ui.experience = "";
            ui.id = Register.UserName;
            ui.major = "";
            ui.name = "";
            ui.resume = "";

            db.UserInfoes.Add(ui);
            db.SaveChanges();

            return Json(new { MSG = "success" });

        }





        // POST: /Accounter/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([Bind(Include = "id,password")] Accounter accounter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounter).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { MSG = "success" });
            }
            return Json(new { MSG = "failed" });
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
