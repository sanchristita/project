using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemisTrackCrud.Models;
using System.Dynamic;

namespace ChemisTrackCrud.Controllers
{
    [Authorize(Users = "admin, labuser")]
    public class ChemicalInventoryController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Chemical/

        public ViewResult Index(string ChemicalInventoryNames, string strSearch)
        {
            var iupac = from j in db.ChemicalsInventory.Include(c =>c.Chemicals)
                        select j;

            var chemicalInventoryList = from c in iupac
                                        orderby c.Chemicals.ChemicalID
                                        select c.Chemicals.ChemicalID;

            ViewBag.ChemicalInventoryNames = new SelectList(chemicalInventoryList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName.Contains(strSearch));

            if (!string.IsNullOrEmpty(ChemicalInventoryNames))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName == ChemicalInventoryNames);

            return View(iupac);

        }

        public ViewResult Report(string ChemicalInventoryNames, string strSearch, DateTime? startDate, DateTime? endDate)
        {
            var iupac = from j in db.ChemicalsInventory.Include(c => c.Chemicals)
                        select j;

            var chemicalInventoryList = from c in iupac
                                        orderby c.Chemicals.ChemicalName
                                        select c.Chemicals.ChemicalID;

            ViewBag.ChemicalInventoryNames = new SelectList(chemicalInventoryList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName.Contains(strSearch));

            if (!string.IsNullOrEmpty(ChemicalInventoryNames))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName == ChemicalInventoryNames);

            if (startDate != null)
                iupac = iupac.Where(m => m.Date >= startDate);

            if (endDate != null)
                iupac = iupac.Where(m => m.Date <= endDate);

            return View(iupac);

        }

        //
        // GET: /ChemicalInventory/Details/5

        public ActionResult Details(int id = 0)
        {
            ChemicalsInventoryModel chemicalsinventorymodel = db.ChemicalsInventory.Find(id);
            chemicalsinventorymodel.Chemicals = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID); //display the name of chemical

            if (chemicalsinventorymodel == null)
            {
                return HttpNotFound();
            }
            return View(chemicalsinventorymodel);
        }


        //
        // GET: /ChemicalInventory/Create

        public ActionResult Create()
        {
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName");
            return View();
        }

        //
        // POST: /ChemicalInventory/Create

        [HttpPost]
        public ActionResult Create(ChemicalsInventoryModel chemicalsinventorymodel)
        {
            if (ModelState.IsValid)
            {
                db.ChemicalsInventory.Add(chemicalsinventorymodel);
                db.SaveChanges();

                // calculate the Total stock for specific chemical
                ChemicalsModel cm = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID);
                cm.StockCount = cm.StockCount + chemicalsinventorymodel.Quantity;
                db.Entry(cm).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", chemicalsinventorymodel.ChemicalID);
            return View(chemicalsinventorymodel);
        }

        //
        // GET: /ChemicalInventory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChemicalsInventoryModel chemicalsinventorymodel = db.ChemicalsInventory.Find(id);
            if (chemicalsinventorymodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", chemicalsinventorymodel.ChemicalID);
            return View(chemicalsinventorymodel);
        }

        //
        // POST: /ChemicalInventory/Edit/5

        [HttpPost]
        public ActionResult Edit(ChemicalsInventoryModel chemicalsinventorymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemicalsinventorymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", chemicalsinventorymodel.ChemicalID);
            return View(chemicalsinventorymodel);
        }

        //
        // GET: /ChemicalInventory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChemicalsInventoryModel chemicalsinventorymodel = db.ChemicalsInventory.Find(id);
            chemicalsinventorymodel.Chemicals = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID); //display the name of chemical

            if (chemicalsinventorymodel == null)
            {
                return HttpNotFound();
            }
            return View(chemicalsinventorymodel);
        }

        //
        // POST: /ChemicalInventory/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChemicalsInventoryModel chemicalsinventorymodel = db.ChemicalsInventory.Find(id);
            db.ChemicalsInventory.Remove(chemicalsinventorymodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public object chemicalsinventorymodel { get; set; }
    }
}