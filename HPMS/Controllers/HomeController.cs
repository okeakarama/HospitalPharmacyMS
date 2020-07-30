using HPMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HPMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MainDBContext db = new MainDBContext();

        public ActionResult index()
        {
            return View();
        }

        public ActionResult proceed()
        {
            return View();
        }

        public ActionResult dashboard()
        {
            return View();
        }

        public ActionResult drug()
        {
            var alldrugs = db.Drugs.OrderByDescending(m => m.DrugID);
            return View(alldrugs.ToList());
        }

        public ActionResult createdrug()
        {

            return View();
        }

        [HttpPost]
        public ActionResult createdrug(Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Drugs.Add(drug);
                db.SaveChanges();
                TempData["save"] = drug.Name + " " + "has been succesfully added to list";
                return RedirectToAction("drug");
            }
            return View();
        }

        public ActionResult patient()
        {
            var allpatient = db.Patients.OrderByDescending(m => m.PatientID);
            return View(allpatient.ToList());
        }

        public ActionResult createpatient()
        {

            return View();
        }

        [HttpPost]
        public ActionResult createpatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                TempData["save"] = patient.Surname + " " + "has been succesfully registered";
                return RedirectToAction("patient");
            }
            return View();
        }

        public ActionResult restockalert()
        {
            if(ModelState.IsValid)
            {
                var finisheddrugs = db.Drugs.OrderByDescending(d=>d.DrugID).Where(d=>d.Quantity<10);
                return View(finisheddrugs.ToList());
            }
            return View();
        }

        public ActionResult dispensary()
        {
            var alldrugs = db.Drugs.OrderBy(d => d.Name);
            return View(alldrugs.ToList());
        }

        public ActionResult dispense(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dispense(Drug drug)
        {
            var drugqty = drug.Quantity;
            --drugqty;
            drug.Quantity = drugqty;
            db.Entry(drug).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("dispensary");
        }

        public ActionResult editdrug(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editdrug(Drug drug)
        {
            db.Entry(drug).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("drug");
        }

        public ActionResult deletedrug(int id = 0)
        {
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        //
        // POST: /post/Delete/5

        [HttpPost, ActionName("deletedrug")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug drug = db.Drugs.Find(id);
            db.Drugs.Remove(drug);
            db.SaveChanges();
            return RedirectToAction("drug");
        }

        public ActionResult editpatient(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult editpatient(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("patient");
        }

        public ActionResult deletepatient(int id = 0)
        {
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //
        // POST: /post/Delete/5

        [HttpPost, ActionName("deletepatient")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletepConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("patient");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //////////index partial views

        public ActionResult drugindex()
        {
            var drugs = db.Drugs.OrderBy(d => d.DrugID);
            ViewBag.Drugs = drugs.ToList().Take(5);
            return PartialView();
        }

        public ActionResult patientindex()
        {
            var patients = db.Patients.OrderBy(s => s.PatientID);
            ViewBag.Patients = patients.ToList().Take(5);
            return PartialView();
        }

        public ActionResult menu()
        {
            return PartialView();
        }
        




        //public ActionResult SearchIndex(string currentFilter, string searchString, int? page)
        //{
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = currentFilter;

        //    var drugs = db.Drugs.Where(x => x.Name.ToUpper().Contains(searchString.ToUpper()));

        //    if (String.IsNullOrEmpty(searchString))
        //    {
        //        ViewBag.SearchString = "Empty";
        //    }
        //    else if (drugs.Count() == 0)
        //    {
        //        TempData["error"] = "Search Result not found.";
        //    }

        //    int pageSize = 10;
        //    int pageNumber = (page ?? 1);
        //    return View(drugs.OrderByDescending(x => x.DrugID).ToPagedList(pageNumber, pageSize));
        //}
    }
}