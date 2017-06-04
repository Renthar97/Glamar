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
    public class ITINERARIOsController : Controller
    {
        private GlamarDbContext db = new GlamarDbContext();

        // GET: ITINERARIOs
        public ActionResult Index()
        {
            var itinerarios = db.Itinerarios.Include(i => i.RESERVA);
            return View(itinerarios.ToList());
        }

        // GET: ITINERARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.Itinerarios.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            return View(iTINERARIO);
        }

        // GET: ITINERARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado");
            return View();
        }

        // POST: ITINERARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ITINERARIOId,ReservaId,origen,destino,fec_Salida,fec_Retorno,distancia")] ITINERARIO iTINERARIO)
        {
            if (ModelState.IsValid)
            {
                db.Itinerarios.Add(iTINERARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", iTINERARIO.ReservaId);
            return View(iTINERARIO);
        }

        // GET: ITINERARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.Itinerarios.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", iTINERARIO.ReservaId);
            return View(iTINERARIO);
        }

        // POST: ITINERARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ITINERARIOId,ReservaId,origen,destino,fec_Salida,fec_Retorno,distancia")] ITINERARIO iTINERARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTINERARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReservaId = new SelectList(db.Reservas, "ReservaId", "Estado", iTINERARIO.ReservaId);
            return View(iTINERARIO);
        }

        // GET: ITINERARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITINERARIO iTINERARIO = db.Itinerarios.Find(id);
            if (iTINERARIO == null)
            {
                return HttpNotFound();
            }
            return View(iTINERARIO);
        }

        // POST: ITINERARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITINERARIO iTINERARIO = db.Itinerarios.Find(id);
            db.Itinerarios.Remove(iTINERARIO);
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
