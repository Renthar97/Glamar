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
    public class LOGINsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: LOGINs
        public ActionResult Index()
        {
            return View(db.Logins.ToList());
        }

        // GET: LOGINs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.Logins.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOGINs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoginId,contraseña")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(lOGIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOGIN);
        }

        // GET: LOGINs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.Logins.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoginId,contraseña")] LOGIN lOGIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOGIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOGIN);
        }

        // GET: LOGINs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOGIN lOGIN = db.Logins.Find(id);
            if (lOGIN == null)
            {
                return HttpNotFound();
            }
            return View(lOGIN);
        }

        // POST: LOGINs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOGIN lOGIN = db.Logins.Find(id);
            db.Logins.Remove(lOGIN);
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
