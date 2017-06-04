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
    public class VENTAsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: VENTAs
        public ActionResult Index()
        {
            var ventas = db.Ventas.Include(v => v.EMPLEADO).Include(v => v.MONEDA);
            return View(ventas.ToList());
        }

        // GET: VENTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.Ventas.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // GET: VENTAs/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Apellidos");
            ViewBag.MonedaId = new SelectList(db.Monedas, "MonedaId", "descp");
            return View();
        }

        // POST: VENTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VentaId,EmpleadoId,MonedaId,Monto")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Ventas.Add(vENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Apellidos", vENTA.EmpleadoId);
            ViewBag.MonedaId = new SelectList(db.Monedas, "MonedaId", "descp", vENTA.MonedaId);
            return View(vENTA);
        }

        // GET: VENTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.Ventas.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Apellidos", vENTA.EmpleadoId);
            ViewBag.MonedaId = new SelectList(db.Monedas, "MonedaId", "descp", vENTA.MonedaId);
            return View(vENTA);
        }

        // POST: VENTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VentaId,EmpleadoId,MonedaId,Monto")] VENTA vENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "EmpleadoId", "Apellidos", vENTA.EmpleadoId);
            ViewBag.MonedaId = new SelectList(db.Monedas, "MonedaId", "descp", vENTA.MonedaId);
            return View(vENTA);
        }

        // GET: VENTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENTA vENTA = db.Ventas.Find(id);
            if (vENTA == null)
            {
                return HttpNotFound();
            }
            return View(vENTA);
        }

        // POST: VENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VENTA vENTA = db.Ventas.Find(id);
            db.Ventas.Remove(vENTA);
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
