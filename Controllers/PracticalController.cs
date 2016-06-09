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
    [Authorize]
    public class PracticalController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Practical/

        public ActionResult Index()
        {
            var practicals = db.Practicals.Include(p => p.chemicalmodel).Include(q => q.Equipmentmodel);
            return View(practicals.ToList());
        }

        //
        // GET: /Practical/Details/5

        public ActionResult Details(int id = 0)
        {
            PracticalsModel practicalsmodel = db.Practicals.Find(id);
            if (practicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(practicalsmodel);
        }

        //
        // GET: /Practical/Create
        [Authorize(Users = "admin, labuser")]
        public ActionResult Create()
        {
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName");
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName");
            return View();
        }

        //
        // POST: /Practical/Create
        [Authorize(Users = "admin, labuser")]
        [HttpPost]
        public ActionResult Create(PracticalsModel practicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Practicals.Add(practicalsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", practicalsmodel.ChemicalID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", practicalsmodel.EquipmentID);
            return View(practicalsmodel);
        }

        //
        // GET: /Practical/Edit/5
        [Authorize(Users = "admin, labuser")]
        public ActionResult Edit(int id = 0)
        {
            PracticalsModel practicalsmodel = db.Practicals.Find(id);
            if (practicalsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", practicalsmodel.ChemicalID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", practicalsmodel.EquipmentID);
            return View(practicalsmodel);
        }

        //
        // POST: /Practical/Edit/5
        [Authorize(Users = "admin, labuser")]
        [HttpPost]
        public ActionResult Edit(PracticalsModel practicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practicalsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", practicalsmodel.ChemicalID);
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", practicalsmodel.EquipmentID);
            return View(practicalsmodel);
        }

        //
        // GET: /Practical/Delete/5
        [Authorize(Users = "admin, labuser")]
        public ActionResult Delete(int id = 0)
        {
            PracticalsModel practicalsmodel = db.Practicals.Find(id);
            if (practicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(practicalsmodel);
        }

        //
        // POST: /Practical/Delete/5
        [Authorize(Users = "admin, labuser")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PracticalsModel practicalsmodel = db.Practicals.Find(id);
            db.Practicals.Remove(practicalsmodel);
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