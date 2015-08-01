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
    public class ClaimController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Claim/

        public ActionResult Index()
        {
            var claims = db.Claims.Include(c => c.equipment);
            return View(claims.ToList());
        }

        //
        // GET: /Claim/Details/5

        public ActionResult Details(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Create

        public ActionResult Create()
        {
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType.Equals(true)), "EquipmentID", "EquipmentName");
            return View();
        }

        //
        // POST: /Claim/Create

        [HttpPost]
        public ActionResult Create(ClaimsModel claimsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(claimsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType.Equals(true)), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType.Equals(true)), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // POST: /Claim/Edit/5

        [HttpPost]
        public ActionResult Edit(ClaimsModel claimsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claimsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType.Equals(true)), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            return View(claimsmodel);
        }

        //
        // POST: /Claim/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            db.Claims.Remove(claimsmodel);
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