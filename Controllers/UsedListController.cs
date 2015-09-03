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
    public class UsedListController : Controller
    {
        private Context db = new Context();

        //
        // GET: /UsedList/

        public ViewResult Index(string UsedChemicals, string strSearch)
        {
            var iupac = from j in db.UsedLists.Include(c => c.Chemicals)
                        select j;

            var ChemicalsUsedList = from c in iupac
                                        orderby c.Chemicals.ChemicalName
                                        select c.Chemicals.ChemicalName;

            ViewBag.ChemicalUsedListNames = new SelectList(ChemicalsUsedList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName.Contains(strSearch));

            if (!string.IsNullOrEmpty(UsedChemicals))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName == UsedChemicals);

            return View(iupac);

        }


        // 
        // Report

        public ViewResult Report(string UsedChemicals, string strSearch, DateTime? startDate, DateTime? endDate)
        {
            var iupac = from j in db.UsedLists.Include(c => c.Chemicals)
                        select j;

            var ChemicalsUsedList = from c in iupac
                                    orderby c.Chemicals.ChemicalName
                                    select c.Chemicals.ChemicalName;

            ViewBag.ChemicalUsedListNames = new SelectList(ChemicalsUsedList.Distinct());

            if (!string.IsNullOrEmpty(strSearch))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName.Contains(strSearch));

            if (!string.IsNullOrEmpty(UsedChemicals))
                iupac = iupac.Where(m => m.Chemicals.ChemicalName == UsedChemicals);

            if (startDate != null)
                iupac = iupac.Where(m => m.UsedDate >= startDate);

            if (endDate != null)
                iupac = iupac.Where(m => m.UsedDate <= endDate);

            return View(iupac);

        }

        //
        // GET: /UsedList/Details/5

        public ActionResult Details(int id = 0)
        {
            UsedListsModel usedlistsmodel = db.UsedLists.Find(id);
            if (usedlistsmodel == null)
            {
                return HttpNotFound();
            }
            return View(usedlistsmodel);
        }

        //
        // GET: /UsedList/Create

        public ActionResult Create()
        {
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName");
            return View();
        }

        //
        // POST: /UsedList/Create

        [HttpPost]
        public ActionResult Create(UsedListsModel usedlistsmodel)
        {
            if (ModelState.IsValid)
            {

                db.UsedLists.Add(usedlistsmodel);
                db.SaveChanges();

                ChemicalsModel sd = db.Chemicals.Find(usedlistsmodel.ChemicalID);
                sd.StockCount = sd.StockCount - usedlistsmodel.UsedQuantity;
                db.Entry(sd).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", usedlistsmodel.ChemicalID);
            return View(usedlistsmodel);
        }

        //
        // GET: /UsedList/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UsedListsModel usedlistsmodel = db.UsedLists.Find(id);
            if (usedlistsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", usedlistsmodel.ChemicalID);
            return View(usedlistsmodel);
        }

        //
        // POST: /UsedList/Edit/5

        [HttpPost]
        public ActionResult Edit(UsedListsModel usedlistsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usedlistsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChemicalID = new SelectList(db.Chemicals, "ChemicalID", "ChemicalName", usedlistsmodel.ChemicalID);
            return View(usedlistsmodel);
        }

        //
        // GET: /UsedList/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UsedListsModel usedlistsmodel = db.UsedLists.Find(id);
            if (usedlistsmodel == null)
            {
                return HttpNotFound();
            }
            return View(usedlistsmodel);
        }

        //
        // POST: /UsedList/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UsedListsModel usedlistsmodel = db.UsedLists.Find(id);
            db.UsedLists.Remove(usedlistsmodel);
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