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
    [Authorize (Users="admin, labuser")]
    public class BrokeListController : Controller
    {
        private Context db = new Context();

        //
        // GET: /BrokeList/

        public ActionResult Index()
        {
            var brokelists = db.BrokeLists.Include(b => b.Equipments);
            return View(brokelists.ToList());
        }

        //
        // GET: /BrokeList/Details/5

        public ActionResult Details(int id = 0)
        {
            BrokeListsModel brokelistsmodel = db.BrokeLists.Find(id);
            if (brokelistsmodel == null)
            {
                return HttpNotFound();
            }
            return View(brokelistsmodel);
        }

        //
        // GET: /BrokeList/Create

        public ActionResult Create()
        {
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName");
            return View();
        }

        //
        // POST: /BrokeList/Create

        [HttpPost]
        public ActionResult Create(BrokeListsModel brokelistsmodel)
        {
            if (ModelState.IsValid)
            {
                db.BrokeLists.Add(brokelistsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", brokelistsmodel.EquipmentID);
            return View(brokelistsmodel);
        }

        //
        // GET: /BrokeList/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BrokeListsModel brokelistsmodel = db.BrokeLists.Find(id);
            if (brokelistsmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", brokelistsmodel.EquipmentID);
            return View(brokelistsmodel);
        }

        //
        // POST: /BrokeList/Edit/5

        [HttpPost]
        public ActionResult Edit(BrokeListsModel brokelistsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brokelistsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentID = new SelectList(db.Equipments, "EquipmentID", "EquipmentName", brokelistsmodel.EquipmentID);
            return View(brokelistsmodel);
        }

        //
        // GET: /BrokeList/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BrokeListsModel brokelistsmodel = db.BrokeLists.Find(id);
            if (brokelistsmodel == null)
            {
                return HttpNotFound();
            }
            return View(brokelistsmodel);
        }

        //
        // POST: /BrokeList/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            BrokeListsModel brokelistsmodel = db.BrokeLists.Find(id);
            db.BrokeLists.Remove(brokelistsmodel);
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