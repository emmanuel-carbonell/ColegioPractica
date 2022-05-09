using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ColegioPractica.Models;

namespace ColegioPractica.Controllers
{
    public class Empleados_AdministrativosController : Controller
    {
        private ColegioPracticaEntities db = new ColegioPracticaEntities();

        // GET: Empleados_Administrativos
        public ActionResult Index()
        {
            return View(db.Empleados_Administrativos.ToList());
        }

        // GET: Empleados_Administrativos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Administrativos empleados_Administrativos = db.Empleados_Administrativos.Find(id);
            if (empleados_Administrativos == null)
            {
                return HttpNotFound();
            }
            return View(empleados_Administrativos);
        }

        // GET: Empleados_Administrativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados_Administrativos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Cargo,Departamento,Edad")] Empleados_Administrativos empleados_Administrativos)
        {
            if (ModelState.IsValid)
            {
                db.Empleados_Administrativos.Add(empleados_Administrativos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleados_Administrativos);
        }

        // GET: Empleados_Administrativos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Administrativos empleados_Administrativos = db.Empleados_Administrativos.Find(id);
            if (empleados_Administrativos == null)
            {
                return HttpNotFound();
            }
            return View(empleados_Administrativos);
        }

        // POST: Empleados_Administrativos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Cargo,Departamento,Edad")] Empleados_Administrativos empleados_Administrativos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleados_Administrativos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleados_Administrativos);
        }

        // GET: Empleados_Administrativos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleados_Administrativos empleados_Administrativos = db.Empleados_Administrativos.Find(id);
            if (empleados_Administrativos == null)
            {
                return HttpNotFound();
            }
            return View(empleados_Administrativos);
        }

        // POST: Empleados_Administrativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleados_Administrativos empleados_Administrativos = db.Empleados_Administrativos.Find(id);
            db.Empleados_Administrativos.Remove(empleados_Administrativos);
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
