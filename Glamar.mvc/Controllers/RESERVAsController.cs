using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entidad;
using Negocio;

namespace Glamar.mvc.Controllers
{
    public class RESERVAsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: RESERVAs
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.VENTA);
            return View(reservas.ToList());
        }

        // GET: RESERVAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.Reservas.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // GET: RESERVAs/Create
        public ActionResult Create()
        {
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId");
            return View();
        }

        // POST: RESERVAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservaId,VentaId,Estado")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(rESERVA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", rESERVA.VentaId);
            return View(rESERVA);
        }

        // GET: RESERVAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.Reservas.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", rESERVA.VentaId);
            return View(rESERVA);
        }

        // POST: RESERVAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservaId,VentaId,Estado")] RESERVA rESERVA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VentaId = new SelectList(db.Ventas, "VentaId", "VentaId", rESERVA.VentaId);
            return View(rESERVA);
        }

        // GET: RESERVAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVA rESERVA = db.Reservas.Find(id);
            if (rESERVA == null)
            {
                return HttpNotFound();
            }
            return View(rESERVA);
        }

        // POST: RESERVAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVA rESERVA = db.Reservas.Find(id);
            db.Reservas.Remove(rESERVA);
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
