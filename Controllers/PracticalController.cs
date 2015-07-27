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
    public class PracticalController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Practical/

        public ActionResult Index()
        {
            return View(db.Practicals.ToList());
        }

        //
        // GET: /Practical/Details/5

        public ActionResult Details(int id = 0)
        {
            PracticalModel practicalmodel = db.Practicals.Find(id);
            if (practicalmodel == null)
            {
                return HttpNotFound();
            }
            return View(practicalmodel);
        }

        //
        // GET: /Practical/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Practical/Create

        [HttpPost]
        public ActionResult Create(PracticalModel practicalmodel)
        {
            if (ModelState.IsValid)
            {
                db.Practicals.Add(practicalmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(practicalmodel);
        }

        //
        // GET: /Practical/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PracticalModel practicalmodel = db.Practicals.Find(id);
            if (practicalmodel == null)
            {
                return HttpNotFound();
            }
            return View(practicalmodel);
        }

        //
        // POST: /Practical/Edit/5

        [HttpPost]
        public ActionResult Edit(PracticalModel practicalmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practicalmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practicalmodel);
        }

        //
        // GET: /Practical/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PracticalModel practicalmodel = db.Practicals.Find(id);
            if (practicalmodel == null)
            {
                return HttpNotFound();
            }
            return View(practicalmodel);
        }

        //
        // POST: /Practical/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PracticalModel practicalmodel = db.Practicals.Find(id);
            db.Practicals.Remove(practicalmodel);
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