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
    [Authorize(Users = "admin, labuser")]
    public class EquipmentInventoryController : Controller
    {
        private Context db = new Context();

        //
        // GET: /EquipmentInventory/

        public ViewResult Index(string EquipmentInventories, string strSearch)
        {
            var equip = from j in db.EquipmentsInventory.Include(e => e.Equipments)
                        select j;

            var equipmentInventoryList = from e in equip
                                         orderby e.Equipments.EquipmentName
                                         select e.Equipments.EquipmentName;

            ViewBag.EquipmentInventoryNames = new SelectList(equipmentInventoryList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                equip = equip.Where(m => m.Equipments.EquipmentName.Contains(strSearch));

            if (!string.IsNullOrEmpty(EquipmentInventories))
                equip = equip.Where(m => m.Equipments.EquipmentName == EquipmentInventories);

            return View(equip);

        }

        //
        // Report 

        public ViewResult Report (string strSearch, DateTime? startDate, DateTime? endDate)
        {
            var equip = from j in db.EquipmentsInventory.Include(e => e.Equipments)
                        select j;

            var equipmentInventoryList = from e in equip
                                         orderby e.Equipments.EquipmentName
                                         select e.Equipments.EquipmentName;

            ViewBag.EquipmentInventoryNames = new SelectList(equipmentInventoryList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                equip = equip.Where(m => m.Equipments.EquipmentName.Contains(strSearch));

            if (startDate != null)
                equip = equip.Where(m => m.EquipmentOrderDate >= startDate);

            if (endDate != null)
                equip = equip.Where(m => m.EquipmentOrderDate <= endDate);

            return View(equip);

        }

        //
        // GET: /EquipmentInventory/Details/5

        public ActionResult Details(int id = 0)
        {
            EquipmentsInventoryModel equipmentsinventorymodel = db.EquipmentsInventory.Find(id);
            equipmentsinventorymodel.Equipments = db.Equipments.Find(equipmentsinventorymodel.EquipmentID); //display the name of equipment

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

                // calculate the Total stock for specific equipment

                EquipmentsModel em = db.Equipments.Find(equipmentsinventorymodel.EquipmentID);
                em.EquipmentStockCount = em.EquipmentStockCount + equipmentsinventorymodel.EquipmentQuantity;
                db.Entry(em).State = EntityState.Modified;
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
            equipmentsinventorymodel.Equipments = db.Equipments.Find(equipmentsinventorymodel.EquipmentID);
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