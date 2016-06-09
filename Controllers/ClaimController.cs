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
    public class ClaimController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Claim/

        public ActionResult Index()
        {
            var claims = db.Claims.Include(c => c.Student).Include(c => c.equipment);
            return View(claims.ToList());
        }

        //
        // GET: /Claim/Details/5

        public ActionResult Details(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            StudentsModel sm = db.Students.Find(claimsmodel.StudentID);
            EquipmentsModel em = db.Equipments.Find(claimsmodel.EquipmentID);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Create
        [Authorize(Users = "admin, labuser")]
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "RegistrationNumber");
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType == true), "EquipmentID", "EquipmentName");
            return View();
        }

        //
        // POST: /Claim/Create
        [Authorize(Users = "admin, labuser")]
        [HttpPost]
        public ActionResult Create(ClaimsModel claimsmodel)
        {
            if (ModelState.IsValid)
            {

                db.Claims.Add(claimsmodel);
                db.SaveChanges();

                EquipmentsModel em = db.Equipments.Find(claimsmodel.EquipmentID);
                if (em.ClaimType)
                {
                    claimsmodel.ClaimAmount = claimsmodel.Quantity * em.claimStandardPrice;
                }
                else 
                {
                    claimsmodel.ClaimAmount = 0;
                }

                db.Entry(claimsmodel).State = EntityState.Modified;
                db.SaveChanges();

                
                StudentsModel sm = db.Students.Find(claimsmodel.StudentID);
                sm.TotalClaim = sm.TotalClaim + claimsmodel.ClaimAmount;
                db.Entry(sm).State = EntityState.Modified;
                db.SaveChanges();
                

                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "RegistrationNumber", claimsmodel.StudentID);
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType == true), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Edit/5
        [Authorize(Users = "admin, labuser")]
        public ActionResult Edit(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "RegistrationNumber", claimsmodel.StudentID);
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType == true), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // POST: /Claim/Edit/5
        [Authorize(Users = "admin, labuser")]
        [HttpPost]
        public ActionResult Edit(ClaimsModel claimsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claimsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "RegistrationNumber", claimsmodel.StudentID);
            ViewBag.EquipmentID = new SelectList(db.Equipments.Where(m => m.ClaimType == true), "EquipmentID", "EquipmentName", claimsmodel.EquipmentID);
            return View(claimsmodel);
        }

        //
        // GET: /Claim/Delete/5
        [Authorize(Users = "admin, labuser")]
        public ActionResult Delete(int id = 0)
        {
            ClaimsModel claimsmodel = db.Claims.Find(id);
            StudentsModel sm = db.Students.Find(claimsmodel.StudentID);
            EquipmentsModel em = db.Equipments.Find(claimsmodel.EquipmentID);
            if (claimsmodel == null)
            {
                return HttpNotFound();
            }
            return View(claimsmodel);
        }

        //
        // POST: /Claim/Delete/5
        [Authorize(Users = "admin, labuser")]
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