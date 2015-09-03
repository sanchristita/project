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
    public class EquipmentController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Equipment/

        public ViewResult Index(string strSearch)
        {

            var equipmentsearch = from i in db.Equipments
                               select i;

            //Get list of Chemical Names
            var equipmentsnames = from c in equipmentsearch
                               orderby c.EquipmentID
                               select c.EquipmentName;

            //Set distinct list of Chemicalname in ViewBag property
            ViewBag.EquipmentNames = new SelectList(equipmentsnames.Distinct());

            //Search records by Chemical Name 
            if (!string.IsNullOrEmpty(strSearch))
                equipmentsearch = equipmentsearch.Where(m => m.EquipmentName.Contains(strSearch));

            return View(equipmentsearch);
        }


        //
        // Report

        public ViewResult Report(string strSearch)
        {
            var equipmentsearch = from i in db.Equipments
                                  select i;

            //Get list of Chemical Names
            var equipmentsnames = from c in equipmentsearch
                                  orderby c.EquipmentID
                                  select c.EquipmentName;

            //Set distinct list of Chemicalname in ViewBag property
            ViewBag.EquipmentNames = new SelectList(equipmentsnames.Distinct());

            //Search records by Chemical Name 
            if (!string.IsNullOrEmpty(strSearch))
                equipmentsearch = equipmentsearch.Where(m => m.EquipmentName.Contains(strSearch));

            return View(equipmentsearch);
        }

        //
        // GET: /Equipment/Details/5

        public ActionResult Details(int id = 0)
        {
            EquipmentsModel equipmentsmodel = db.Equipments.Find(id);
            if (equipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentsmodel);
        }

        //
        // GET: /Equipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Equipment/Create

        [HttpPost]
        public ActionResult Create(EquipmentsModel equipmentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Equipments.Add(equipmentsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipmentsmodel);
        }

        //
        // GET: /Equipment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EquipmentsModel equipmentsmodel = db.Equipments.Find(id);
            if (equipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentsmodel);
        }

        //
        // POST: /Equipment/Edit/5

        [HttpPost]
        public ActionResult Edit(EquipmentsModel equipmentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipmentsmodel);
        }

        //
        // GET: /Equipment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EquipmentsModel equipmentsmodel = db.Equipments.Find(id);
            if (equipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentsmodel);
        }

        //
        // POST: /Equipment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentsModel equipmentsmodel = db.Equipments.Find(id);
            db.Equipments.Remove(equipmentsmodel);
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