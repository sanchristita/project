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
    public class ChemicalInventoryController : Controller
    {
        private Context db = new Context();

        

        //
        // GET: /ChemicalInventory/

        /*
        public ActionResult Index()
        {
            var chemicalsinventory = db.ChemicalsInventory.Include(c => c.Chemicals);
            return View(chemicalsinventory.ToList());
        }
        * */

        

        public ViewResult Index(string ChemicalInventoryNames, string strSearch)
        {
            var iupac = from j in db.ChemicalsInventory.Include(c => c.Chemicals)
                        select j;

            var chemicalInventoryList = from c in iupac
                                        orderby c.Chemicals.ChemicalName
                                        select c.Chemicals.ChemicalName;

            ViewBag.ChemicalInventoryNames = new SelectList(chemicalInventoryList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName.Contains(strSearch));

            if (!string.IsNullOrEmpty(ChemicalInventoryNames))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName == ChemicalInventoryNames);

            return View(iupac);

        }

        //
        // GET: /ChemicalInventory/Details/5

        public ActionResult Details(int id = 0)
        {
            ChemicalsInventoryModel chemicalsinventorymodel = db.ChemicalsInventory.Find(id);
            chemicalsinventorymodel.Chemicals = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID);
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

                ChemicalsModel sd = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID);
                sd.StockCount = sd.StockCount + chemicalsinventorymodel.Quantity;
                db.Entry(sd).State = EntityState.Modified;
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
            chemicalsinventorymodel.Chemicals = db.Chemicals.Find(chemicalsinventorymodel.ChemicalID);
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