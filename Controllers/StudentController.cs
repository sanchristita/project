using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemisTrackCrud.Models;

namespace ChemisTrackCrud.Controllers
{
    public class StudentController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Student/

        public ViewResult Index(string strSearch)
        {

            var studentsearch = from i in db.Students
                                  select i;

            //Get list of Chemical Names
            var studentsnames = from c in studentsearch
                                  orderby c.StudentID
                                  select c.RegistrationNumber;

            //Set distinct list of Chemicalname in ViewBag property
            ViewBag.students = new SelectList(studentsnames.Distinct());

            //Search records by Chemical Name 
            if (!string.IsNullOrEmpty(strSearch))
                studentsearch = studentsearch.Where(m => m.RegistrationNumber.Contains(strSearch));

            return View(studentsearch);
        }

        //
        // Report

        public ViewResult Report(string strSearch)
        {

            var studentsearch = from i in db.Students
                                select i;

            //Get list of Chemical Names
            var studentsnames = from c in studentsearch
                                orderby c.StudentID
                                select c.RegistrationNumber;

            //Set distinct list of Chemicalname in ViewBag property
            ViewBag.students = new SelectList(studentsnames.Distinct());

            //Search records by Chemical Name 
            if (!string.IsNullOrEmpty(strSearch))
                studentsearch = studentsearch.Where(m => m.RegistrationNumber.Contains(strSearch));

            return View(studentsearch);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            StudentsModel studentsmodel = db.Students.Find(id);
            if (studentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(studentsmodel);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        public ActionResult Create(StudentsModel studentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentsmodel);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            StudentsModel studentsmodel = db.Students.Find(id);
            if (studentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(studentsmodel);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        public ActionResult Edit(StudentsModel studentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentsmodel);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            StudentsModel studentsmodel = db.Students.Find(id);
            if (studentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(studentsmodel);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsModel studentsmodel = db.Students.Find(id);
            db.Students.Remove(studentsmodel);
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