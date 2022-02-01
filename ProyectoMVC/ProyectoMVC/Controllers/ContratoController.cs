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
    public class ContratoController : Controller
    {
        private EmpleadosDbContext db = new EmpleadosDbContext();

        // GET: Contrato
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Trabajador);
            return View(contrato.ToList());
        }

        // GET: Contrato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contrato.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // GET: Contrato/Create
        public ActionResult Create()
        {
            ViewBag.TrabajadorId = new SelectList(db.Trabajador, "TrabajadorId", "Identiificacion");
            return View();
        }

        // POST: Contrato/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,NombreEntidad,NumeroContrato,TrabajadorVinculado,FechaInicio,FechaFin,TrabajadorId")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contratos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrabajadorId = new SelectList(db.Trabajador, "TrabajadorId", "Identiificacion", contratos.TrabajadorId);
            return View(contratos);
        }

        // GET: Contrato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contrato.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrabajadorId = new SelectList(db.Trabajador, "TrabajadorId", "Identiificacion", contratos.TrabajadorId);
            return View(contratos);
        }

        // POST: Contrato/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,NombreEntidad,NumeroContrato,TrabajadorVinculado,FechaInicio,FechaFin,TrabajadorId")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrabajadorId = new SelectList(db.Trabajador, "TrabajadorId", "Identiificacion", contratos.TrabajadorId);
            return View(contratos);
        }

        // GET: Contrato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratos contratos = db.Contrato.Find(id);
            if (contratos == null)
            {
                return HttpNotFound();
            }
            return View(contratos);
        }

        // POST: Contrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contratos contratos = db.Contrato.Find(id);
            db.Contrato.Remove(contratos);
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
