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
    public class OrderDefectEquipmentController : Controller
    {
        private Context db = new Context();

        //
        // GET: /OrderDefectEquipment/

        public ActionResult Index()
        {
            return View(db.OrderDefectEquipments.ToList());
        }

        //
        // GET: /OrderDefectEquipment/Details/5

        public ActionResult Details(int id = 0)
        {
            OrderDefectEquipmentsModel orderdefectequipmentsmodel = db.OrderDefectEquipments.Find(id);
            if (orderdefectequipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(orderdefectequipmentsmodel);
        }

        //
        // GET: /OrderDefectEquipment/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderDefectEquipment/Create

        [HttpPost]
        public ActionResult Create(OrderDefectEquipmentsModel orderdefectequipmentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.OrderDefectEquipments.Add(orderdefectequipmentsmodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderdefectequipmentsmodel);
        }

        //
        // GET: /OrderDefectEquipment/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrderDefectEquipmentsModel orderdefectequipmentsmodel = db.OrderDefectEquipments.Find(id);
            if (orderdefectequipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(orderdefectequipmentsmodel);
        }

        //
        // POST: /OrderDefectEquipment/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderDefectEquipmentsModel orderdefectequipmentsmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdefectequipmentsmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderdefectequipmentsmodel);
        }

        //
        // GET: /OrderDefectEquipment/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrderDefectEquipmentsModel orderdefectequipmentsmodel = db.OrderDefectEquipments.Find(id);
            if (orderdefectequipmentsmodel == null)
            {
                return HttpNotFound();
            }
            return View(orderdefectequipmentsmodel);
        }

        //
        // POST: /OrderDefectEquipment/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDefectEquipmentsModel orderdefectequipmentsmodel = db.OrderDefectEquipments.Find(id);
            db.OrderDefectEquipments.Remove(orderdefectequipmentsmodel);
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