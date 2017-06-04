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
    public class TELEFONOesController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: TELEFONOes
        public ActionResult Index()
        {
            var telefonos = db.Telefonos.Include(t => t.CLIENTE);
            return View(telefonos.ToList());
        }

        // GET: TELEFONOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONO tELEFONO = db.Telefonos.Find(id);
            if (tELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(tELEFONO);
        }

        // GET: TELEFONOes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente");
            return View();
        }

        // POST: TELEFONOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TelefonoId,ClienteId,numero")] TELEFONO tELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos.Add(tELEFONO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", tELEFONO.ClienteId);
            return View(tELEFONO);
        }

        // GET: TELEFONOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONO tELEFONO = db.Telefonos.Find(id);
            if (tELEFONO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", tELEFONO.ClienteId);
            return View(tELEFONO);
        }

        // POST: TELEFONOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TelefonoId,ClienteId,numero")] TELEFONO tELEFONO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tELEFONO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "nom_Cliente", tELEFONO.ClienteId);
            return View(tELEFONO);
        }

        // GET: TELEFONOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TELEFONO tELEFONO = db.Telefonos.Find(id);
            if (tELEFONO == null)
            {
                return HttpNotFound();
            }
            return View(tELEFONO);
        }

        // POST: TELEFONOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TELEFONO tELEFONO = db.Telefonos.Find(id);
            db.Telefonos.Remove(tELEFONO);
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
