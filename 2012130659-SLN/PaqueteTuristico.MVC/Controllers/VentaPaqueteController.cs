using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Persistence;

namespace PaqueteTuristico.MVC.Controllers
{
    public class VentaPaqueteController : Controller
    {
        private PaqueteTuristicoDbContext db = new PaqueteTuristicoDbContext();

        // GET: VentaPaquete
        public ActionResult Index()
        {
            var ventaPaquetes = db.VentaPaquetes.Include(v => v.ComprobantePago);
            return View(ventaPaquetes.ToList());
        }

        // GET: VentaPaquete/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // GET: VentaPaquete/Create
        public ActionResult Create()
        {
            ViewBag.ComprobantePagoId = new SelectList(db.ComprobantesPago, "ComprobantePagoId", "ComprobantePagoId");
            return View();
        }

        // POST: VentaPaquete/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaPaqueteId,ComprobantePagoId,MediosPago")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                db.VentaPaquetes.Add(ventaPaquete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComprobantePagoId = new SelectList(db.ComprobantesPago, "ComprobantePagoId", "ComprobantePagoId", ventaPaquete.ComprobantePagoId);
            return View(ventaPaquete);
        }

        // GET: VentaPaquete/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComprobantePagoId = new SelectList(db.ComprobantesPago, "ComprobantePagoId", "ComprobantePagoId", ventaPaquete.ComprobantePagoId);
            return View(ventaPaquete);
        }

        // POST: VentaPaquete/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaPaqueteId,ComprobantePagoId,MediosPago")] VentaPaquete ventaPaquete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ventaPaquete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComprobantePagoId = new SelectList(db.ComprobantesPago, "ComprobantePagoId", "ComprobantePagoId", ventaPaquete.ComprobantePagoId);
            return View(ventaPaquete);
        }

        // GET: VentaPaquete/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            if (ventaPaquete == null)
            {
                return HttpNotFound();
            }
            return View(ventaPaquete);
        }

        // POST: VentaPaquete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VentaPaquete ventaPaquete = db.VentaPaquetes.Find(id);
            db.VentaPaquetes.Remove(ventaPaquete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
