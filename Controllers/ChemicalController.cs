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
    public class ChemicalController : Controller
    {
        private Context db = new Context();

        //
        // GET: /Chemical/

        /*
        public ActionResult Index()
        {
            return View(db.Chemicals.ToList());
        }
        */

        public ViewResult Index(string nameSearch, string strSearch)
        {
            //Select all Chemicals Names records
            var iupac = from i in db.Chemicals
                select i;
            var iupachem = from j in db.ChemicalsInventory.Include(c => c.Chemicals)
                        select j;

            var iupacChem = from j in db.ChemicalsInventory.Include(c => c.Chemicals)
                            select j;

            //Get list of Chemical Names
            var chemicalList = from c in iupac
                orderby c.ChemicalName
                select c.ChemicalName;

            //Set distinct list of Chemicalname in ViewBag property
            ViewBag.ChemicalNames = new SelectList(chemicalList.Distinct());

            //Search records by Chemical Name 
            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Formula.Contains(strSearch));

            //Search records by Publisher
            if (!string.IsNullOrEmpty(nameSearch))
                iupac = iupac.Where(m => m.ChemicalName.Contains(nameSearch));
            return View(iupac);


        }

        //
        // GET: /Chemical/Details/5

        public ActionResult Details(int id = 0)
        {
            ChemicalsModel chemicalsmodel = db.Chemicals.Find(id);
            if (chemicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(chemicalsmodel);
        }

        //
        // GET: /Chemical/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chemical/Create

        [HttpPost]
        public ActionResult Create(ChemicalsModel chemicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Chemicals.Add(chemicalsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chemicalsmodel);
        }

        //
        // GET: /Chemical/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChemicalsModel chemicalsmodel = db.Chemicals.Find(id);
            if (chemicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(chemicalsmodel);
        }

        //
        // POST: /Chemical/Edit/5

        [HttpPost]
        public ActionResult Edit(ChemicalsModel chemicalsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chemicalsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chemicalsmodel);
        }

        //
        // GET: /Chemical/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChemicalsModel chemicalsmodel = db.Chemicals.Find(id);
            if (chemicalsmodel == null)
            {
                return HttpNotFound();
            }
            return View(chemicalsmodel);
        }

        //
        // POST: /Chemical/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChemicalsModel chemicalsmodel = db.Chemicals.Find(id);
            db.Chemicals.Remove(chemicalsmodel);
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