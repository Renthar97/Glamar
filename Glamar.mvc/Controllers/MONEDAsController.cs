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
    public class MONEDAsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: MONEDAs
        public ActionResult Index()
        {
            return View(db.Monedas.ToList());
        }

        // GET: MONEDAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONEDA mONEDA = db.Monedas.Find(id);
            if (mONEDA == null)
            {
                return HttpNotFound();
            }
            return View(mONEDA);
        }

        // GET: MONEDAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MONEDAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonedaId,descp")] MONEDA mONEDA)
        {
            if (ModelState.IsValid)
            {
                db.Monedas.Add(mONEDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mONEDA);
        }

        // GET: MONEDAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONEDA mONEDA = db.Monedas.Find(id);
            if (mONEDA == null)
            {
                return HttpNotFound();
            }
            return View(mONEDA);
        }

        // POST: MONEDAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonedaId,descp")] MONEDA mONEDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mONEDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mONEDA);
        }

        // GET: MONEDAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MONEDA mONEDA = db.Monedas.Find(id);
            if (mONEDA == null)
            {
                return HttpNotFound();
            }
            return View(mONEDA);
        }

        // POST: MONEDAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MONEDA mONEDA = db.Monedas.Find(id);
            db.Monedas.Remove(mONEDA);
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
