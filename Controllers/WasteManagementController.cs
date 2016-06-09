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
    public class WasteManagementController : Controller
    {
        private Context db = new Context();

        //
        // GET: /WasteManagement/

        public ActionResult Index()
        {
            return View(db.WasteManagements.ToList());
        }

        //
        // GET: add to waste management

        public ActionResult Manage(int id = 0)
        {
            return View();
        }

        //
        // POST: expired chemical details add to wastemanagement and remove from chemicalinventory

        [HttpPost, ActionName("Manage")]
        public ActionResult ManageConfirm(int id)
        {
            ChemicalsInventoryModel inventorymodel = db.ChemicalsInventory.Find(id);

            if (ModelState.IsValid)
            {
                var wastemanagement = db.WasteManagements.Create();

                ChemicalsModel chemicalmodel = db.Chemicals.Find(inventorymodel.ChemicalID);

                // data from the chemical model
                wastemanagement.ChemicalName = chemicalmodel.ChemicalName;
                wastemanagement.HazardousWaste = chemicalmodel.HazardousWaste;

                // data from the chemical inventory model
                wastemanagement.ChemicalID = inventorymodel.ChemicalsInventoryID;
                wastemanagement.Date = inventorymodel.Date;
                wastemanagement.OrderNo = inventorymodel.OrderNo;
                wastemanagement.SupplierName = inventorymodel.SupplierName;
                wastemanagement.Quantity = inventorymodel.Quantity;
                wastemanagement.Unit = inventorymodel.Unit;
                wastemanagement.UnitPrice = inventorymodel.UnitPrice;
                wastemanagement.Amount = inventorymodel.Amount;
                wastemanagement.ExpiredDate = inventorymodel.ExpiredDate;
                wastemanagement.GRN_No = inventorymodel.GRN_No;

                db.WasteManagements.Add(wastemanagement);
                db.ChemicalsInventory.Remove(inventorymodel);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "ChemicalInventory");
        }

        //
        // Print Waste Label

        public ActionResult PrintLabel(int id = 0)
        {
            WasteManagementModel wastemanagementmodel = db.WasteManagements.Find(id);
            if (wastemanagementmodel == null)
            {
                return HttpNotFound();
            }
            return View(wastemanagementmodel);
        }

        //
        // GET: /WasteManagement/Details/5

        public ActionResult Details(int id = 0)
        {
            WasteManagementModel wastemanagementmodel = db.WasteManagements.Find(id);
            if (wastemanagementmodel == null)
            {
                return HttpNotFound();
            }
            return View(wastemanagementmodel);
        }

        //
        // GET: /WasteManagement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            WasteManagementModel wastemanagementmodel = db.WasteManagements.Find(id);
            if (wastemanagementmodel == null)
            {
                return HttpNotFound();
            }
            return View(wastemanagementmodel);
        }

        //
        // POST: /WasteManagement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            WasteManagementModel wastemanagementmodel = db.WasteManagements.Find(id);
            db.WasteManagements.Remove(wastemanagementmodel);
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