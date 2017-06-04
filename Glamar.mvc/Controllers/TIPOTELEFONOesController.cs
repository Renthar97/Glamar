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
    public class TIPOTELEFONOesController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: TIPOTELEFONOes
        public ActionResult Index()
        {
            var tTelefonos = db.TTelefonos.Include(t => t.TELEFONO);
            return View(tTelefonos.ToList());
        }

        // GET: TIPOTELEFONOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOTELEFONO tIPOTELEFONO = db.TTelefonos.Find(id);
            if (tIPOTELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOTELEFONO);
        }

        // GET: TIPOTELEFONOes/Create
        public ActionResult Create()
        {
            ViewBag.TelefonoId = new SelectList(db.Telefonos, "TelefonoId", "numero");
            return View();
        }

        // POST: TIPOTELEFONOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoTelefonoId,TelefonoId,tipoTelefono1")] TIPOTELEFONO tIPOTELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.TTelefonos.Add(tIPOTELEFONO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TelefonoId = new SelectList(db.Telefonos, "TelefonoId", "numero", tIPOTELEFONO.TelefonoId);
            return View(tIPOTELEFONO);
        }

        // GET: TIPOTELEFONOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOTELEFONO tIPOTELEFONO = db.TTelefonos.Find(id);
            if (tIPOTELEFONO == null)
            {
                return HttpNotFound();
            }
            ViewBag.TelefonoId = new SelectList(db.Telefonos, "TelefonoId", "numero", tIPOTELEFONO.TelefonoId);
            return View(tIPOTELEFONO);
        }

        // POST: TIPOTELEFONOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoTelefonoId,TelefonoId,tipoTelefono1")] TIPOTELEFONO tIPOTELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOTELEFONO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TelefonoId = new SelectList(db.Telefonos, "TelefonoId", "numero", tIPOTELEFONO.TelefonoId);
            return View(tIPOTELEFONO);
        }

        // GET: TIPOTELEFONOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOTELEFONO tIPOTELEFONO = db.TTelefonos.Find(id);
            if (tIPOTELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(tIPOTELEFONO);
        }

        // POST: TIPOTELEFONOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOTELEFONO tIPOTELEFONO = db.TTelefonos.Find(id);
            db.TTelefonos.Remove(tIPOTELEFONO);
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
