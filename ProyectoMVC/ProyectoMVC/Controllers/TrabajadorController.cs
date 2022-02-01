using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMVC.Models;
using ProyectoMVC.Models.DBContext;

namespace ProyectoMVC.Controllers
{
    public class TrabajadorController : Controller
    {
        private EmpleadosDbContext db = new EmpleadosDbContext();

        // GET: Trabajador
        public ActionResult Index()
        {
            var trabajador = db.Trabajador.Include(t => t.TipoIdentificacion);
            return View(trabajador.ToList());
        }

        // GET: Trabajador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajador.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // GET: Trabajador/Create
        public ActionResult Create()
        {
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion");
            return View();
        }

        // POST: Trabajador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajadorId,TipoIdentificacionId,Identiificacion,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Edad")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.Add(trabajadores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", trabajadores.TipoIdentificacionId);
            return View(trabajadores);
        }

        // GET: Trabajador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajador.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", trabajadores.TipoIdentificacionId);
            return View(trabajadores);
        }

        // POST: Trabajador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajadorId,TipoIdentificacionId,Identiificacion,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,Edad")] Trabajadores trabajadores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajadores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", trabajadores.TipoIdentificacionId);
            return View(trabajadores);
        }

        // GET: Trabajador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajadores trabajadores = db.Trabajador.Find(id);
            if (trabajadores == null)
            {
                return HttpNotFound();
            }
            return View(trabajadores);
        }

        // POST: Trabajador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajadores trabajadores = db.Trabajador.Find(id);
            db.Trabajador.Remove(trabajadores);
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
