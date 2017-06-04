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
    public class TIPOCORREOsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: TIPOCORREOs
        public ActionResult Index()
        {
            var tCorreos = db.TCorreos.Include(t => t.CORREO);
            return View(tCorreos.ToList());
        }

        // GET: TIPOCORREOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCORREO tIPOCORREO = db.TCorreos.Find(id);
            if (tIPOCORREO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCORREO);
        }

        // GET: TIPOCORREOs/Create
        public ActionResult Create()
        {
            ViewBag.CorreoId = new SelectList(db.Correos, "CorreoId", "Correo1");
            return View();
        }

        // POST: TIPOCORREOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoCorreoId,CorreoId,TipoCorreo1")] TIPOCORREO tIPOCORREO)
        {
            if (ModelState.IsValid)
            {
                db.TCorreos.Add(tIPOCORREO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CorreoId = new SelectList(db.Correos, "CorreoId", "Correo1", tIPOCORREO.CorreoId);
            return View(tIPOCORREO);
        }

        // GET: TIPOCORREOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCORREO tIPOCORREO = db.TCorreos.Find(id);
            if (tIPOCORREO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CorreoId = new SelectList(db.Correos, "CorreoId", "Correo1", tIPOCORREO.CorreoId);
            return View(tIPOCORREO);
        }

        // POST: TIPOCORREOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoCorreoId,CorreoId,TipoCorreo1")] TIPOCORREO tIPOCORREO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOCORREO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CorreoId = new SelectList(db.Correos, "CorreoId", "Correo1", tIPOCORREO.CorreoId);
            return View(tIPOCORREO);
        }

        // GET: TIPOCORREOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOCORREO tIPOCORREO = db.TCorreos.Find(id);
            if (tIPOCORREO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOCORREO);
        }

        // POST: TIPOCORREOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOCORREO tIPOCORREO = db.TCorreos.Find(id);
            db.TCorreos.Remove(tIPOCORREO);
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
