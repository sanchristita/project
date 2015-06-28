﻿using System;
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

        public ActionResult Index()
        {
            return View(db.Chemicals.ToList());
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