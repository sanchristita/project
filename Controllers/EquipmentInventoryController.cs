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
    public class EquipmentInventoryController : Controller
    {
        private Context db = new Context();

        //
        // GET: /EquipmentInventory/

        public ActionResult Index()
        {
            var equipmentsinventory = db.EquipmentsInventory.Include(e => e.Equipments);
            return View(equipmentsinventory.ToList());
        }

        //
        // GET: /EquipmentInventory/Details/5

        public ActionResult Details(int id = 0)
        {
            EquipmentsInventoryModel equipmentsinventorymodel = db.EquipmentsInventory.Find(id);

            if (equipmentsinventorymodel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentsinventorymodel);
        }

        //
        // GET: /EquipmentInventory/Create

        public ActionResult Create()
        {
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName");
            return View();
        }

        //
        // POST: /EquipmentInventory/Create

        [HttpPost]
        public ActionResult Create(EquipmentsInventoryModel equipmentsinventorymodel)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentsInventory.Add(equipmentsinventorymodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentsinventorymodel.EquipmentID);
            return View(equipmentsinventorymodel);
        }

        //
        // GET: /EquipmentInventory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EquipmentsInventoryModel equipmentsinventorymodel = db.EquipmentsInventory.Find(id);
            if (equipmentsinventorymodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentsinventorymodel.EquipmentID);
            return View(equipmentsinventorymodel);
        }

        //
        // POST: /EquipmentInventory/Edit/5

        [HttpPost]
        public ActionResult Edit(EquipmentsInventoryModel equipmentsinventorymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentsinventorymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", equipmentsinventorymodel.EquipmentID);
            return View(equipmentsinventorymodel);
        }

        //
        // GET: /EquipmentInventory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EquipmentsInventoryModel equipmentsinventorymodel = db.EquipmentsInventory.Find(id);
            if (equipmentsinventorymodel == null)
            {
                return HttpNotFound();
            }
            return View(equipmentsinventorymodel);
        }

        //
        // POST: /EquipmentInventory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentsInventoryModel equipmentsinventorymodel = db.EquipmentsInventory.Find(id);
            db.EquipmentsInventory.Remove(equipmentsinventorymodel);
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