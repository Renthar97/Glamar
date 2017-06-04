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
    public class ALOJAMIENTOesController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: ALOJAMIENTOes
        public ActionResult Index()
        {
            var alojamientos = db.Alojamientos.Include(a => a.HOTEL).Include(a => a.RESERVA);
            return View(alojamientos.ToList());
        }

        // GET: ALOJAMIENTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALOJAMIENTO aLOJAMIENTO = db.Alojamientos.Find(id);
            if (aLOJAMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(aLOJAMIENTO);
        }

        // GET: ALOJAMIENTOes/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(db.Hoteles, "HotelId", "NomHotel");
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado");
            return View();
        }

        // POST: ALOJAMIENTOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlojamientoId,ReservaId,HotelId,nro_Hab")] ALOJAMIENTO aLOJAMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Alojamientos.Add(aLOJAMIENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelId = new SelectList(db.Hoteles, "HotelId", "NomHotel", aLOJAMIENTO.HotelId);
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", aLOJAMIENTO.ReservaId);
            return View(aLOJAMIENTO);
        }

        // GET: ALOJAMIENTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALOJAMIENTO aLOJAMIENTO = db.Alojamientos.Find(id);
            if (aLOJAMIENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelId = new SelectList(db.Hoteles, "HotelId", "NomHotel", aLOJAMIENTO.HotelId);
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", aLOJAMIENTO.ReservaId);
            return View(aLOJAMIENTO);
        }

        // POST: ALOJAMIENTOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlojamientoId,ReservaId,HotelId,nro_Hab")] ALOJAMIENTO aLOJAMIENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLOJAMIENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelId = new SelectList(db.Hoteles, "HotelId", "NomHotel", aLOJAMIENTO.HotelId);
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", aLOJAMIENTO.ReservaId);
            return View(aLOJAMIENTO);
        }

        // GET: ALOJAMIENTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALOJAMIENTO aLOJAMIENTO = db.Alojamientos.Find(id);
            if (aLOJAMIENTO == null)
            {
                return HttpNotFound();
            }
            return View(aLOJAMIENTO);
        }

        // POST: ALOJAMIENTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALOJAMIENTO aLOJAMIENTO = db.Alojamientos.Find(id);
            db.Alojamientos.Remove(aLOJAMIENTO);
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
