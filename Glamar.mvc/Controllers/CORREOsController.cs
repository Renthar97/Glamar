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
    public class CORREOsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: CORREOs
        public ActionResult Index()
        {
            return View(db.Correos.ToList());
        }

        // GET: CORREOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO cORREO = db.Correos.Find(id);
            if (cORREO == null)
            {
                return HttpNotFound();
            }
            return View(cORREO);
        }

        // GET: CORREOs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CORREOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CorreoId,IdCliente,Correo1")] CORREO cORREO)
        {
            if (ModelState.IsValid)
            {
                db.Correos.Add(cORREO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cORREO);
        }

        // GET: CORREOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO cORREO = db.Correos.Find(id);
            if (cORREO == null)
            {
                return HttpNotFound();
            }
            return View(cORREO);
        }

        // POST: CORREOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CorreoId,IdCliente,Correo1")] CORREO cORREO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cORREO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cORREO);
        }

        // GET: CORREOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CORREO cORREO = db.Correos.Find(id);
            if (cORREO == null)
            {
                return HttpNotFound();
            }
            return View(cORREO);
        }

        // POST: CORREOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CORREO cORREO = db.Correos.Find(id);
            db.Correos.Remove(cORREO);
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
