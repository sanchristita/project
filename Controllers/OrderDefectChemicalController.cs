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
    public class OrderDefectChemicalController : Controller
    {
        private Context db = new Context();

        //
        // GET: /OrderDefectChemical/

        public ActionResult Index()
        {
            var orderdefectchemicals = db.OrderDefectChemicals.Include(o => o.chemicals);
            return View(orderdefectchemicals.ToList());
        }

        //
        // GET: /OrderDefectChemical/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderDefectChemicalsModel orderdefectchemicalsmodel = db.OrderDefectChemicals.Find(id);
            orderdefectchemicalsmodel.chemicals = db.Chemicals.Find(orderdefectchemicalsmodel.ChemicalID);

            if (orderdefectchemicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(orderdefectchemicalsmodel);
        }

        //
        // GET: /OrderDefectChemical/Create

        public ActionResult Create()
        {
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName");
            return View();
        }

        //
        // POST: /OrderDefectChemical/Create

        [HttpPost]
        public ActionResult Create(OrderDefectChemicalsModel orderdefectchemicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.OrderDefectChemicals.Add(orderdefectchemicalsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", orderdefectchemicalsmodel.ChemicalID);
            return View(orderdefectchemicalsmodel);
        }

        //
        // GET: /OrderDefectChemical/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderDefectChemicalsModel orderdefectchemicalsmodel = db.OrderDefectChemicals.Find(id);
            if (orderdefectchemicalsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", orderdefectchemicalsmodel.ChemicalID);
            return View(orderdefectchemicalsmodel);
        }

        //
        // POST: /OrderDefectChemical/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderDefectChemicalsModel orderdefectchemicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdefectchemicalsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", orderdefectchemicalsmodel.ChemicalID);
            return View(orderdefectchemicalsmodel);
        }

        //
        // GET: /OrderDefectChemical/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderDefectChemicalsModel orderdefectchemicalsmodel = db.OrderDefectChemicals.Find(id);
            if (orderdefectchemicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(orderdefectchemicalsmodel);
        }

        //
        // POST: /OrderDefectChemical/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDefectChemicalsModel orderdefectchemicalsmodel = db.OrderDefectChemicals.Find(id);
            db.OrderDefectChemicals.Remove(orderdefectchemicalsmodel);
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