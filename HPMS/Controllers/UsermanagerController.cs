using HPMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPMS.Controllers
{
    public class UsermanagerController : Controller
    {
        //
        // GET: /Usermanager/
        private MainDBContext db = new MainDBContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var users = from s in db.UserProfiles.OrderBy(x => x.UserName)
                        select s;
            ViewBag.Roles = System.Web.Security.Roles.GetAllRoles();

            return View(users.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Roles()
        {
            ViewBag.User = "active-menu";
            var roles = System.Web.Security.Roles.GetAllRoles();

            return View(roles);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddRole(string rolename)
        {
            System.Web.Security.Roles.CreateRole(rolename);
            var roles = System.Web.Security.Roles.GetAllRoles();

            return View("Roles", roles);
        }

        [HttpPost]
        public ActionResult UserToRole(string rolename, string username, bool? ischecked)
        {
            if (ischecked.HasValue && ischecked.Value)
            {
                System.Web.Security.Roles.AddUserToRole(username, rolename);
            }
            else
            {
                System.Web.Security.Roles.RemoveUserFromRole(username, rolename);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Usermanager/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /Usermanager/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usermanager/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.UserProfiles.Add(userprofile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userprofile);
        }

        //
        // GET: /Usermanager/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Usermanager/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserProfile userprofile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userprofile);
        }

        //
        // GET: /Usermanager/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /Usermanager/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userprofile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
