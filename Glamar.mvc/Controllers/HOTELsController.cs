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
    public class HOTELsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: HOTELs
        public ActionResult Index()
        {
            var hoteles = db.Hoteles.Include(h => h.CIUDAD);
            return View(hoteles.ToList());
        }

        // GET: HOTELs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.Hoteles.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // GET: HOTELs/Create
        public ActionResult Create()
        {
            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "Nombre");
            return View();
        }

        // POST: HOTELs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelId,CiudadId,NomHotel")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.Hoteles.Add(hOTEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "Nombre", hOTEL.CiudadId);
            return View(hOTEL);
        }

        // GET: HOTELs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.Hoteles.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "Nombre", hOTEL.CiudadId);
            return View(hOTEL);
        }

        // POST: HOTELs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotelId,CiudadId,NomHotel")] HOTEL hOTEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOTEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudades, "CiudadId", "Nombre", hOTEL.CiudadId);
            return View(hOTEL);
        }

        // GET: HOTELs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOTEL hOTEL = db.Hoteles.Find(id);
            if (hOTEL == null)
            {
                return HttpNotFound();
            }
            return View(hOTEL);
        }

        // POST: HOTELs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOTEL hOTEL = db.Hoteles.Find(id);
            db.Hoteles.Remove(hOTEL);
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
