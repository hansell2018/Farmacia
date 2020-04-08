using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FARMACIA_SEMI.Models;

namespace FARMACIA_SEMI.Controllers
{
    public class FAR_PLANILLAController : Controller
    {
        private FARMACIAEntities db = new FARMACIAEntities();
            public Boolean validarSesion()
            {
                FAR_USUARIO usuario = new FAR_USUARIO();
                usuario = Session["usuario"] as FAR_USUARIO;
                Boolean estadoSesion = true;

                if (usuario == null)
                {
                    estadoSesion = false;
                }

                return estadoSesion;
            }

        public ActionResult Index()
        {

            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }
            return View(db.FAR_PLANILLA.ToList());
        }

        // GET: FAR_PLANILLA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PLANILLA fAR_PLANILLA = db.FAR_PLANILLA.Find(id);
            if (fAR_PLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PLANILLA);
        }

        // GET: FAR_PLANILLA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAR_PLANILLA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FECHA_INICIO,FECHA_FIN")] FAR_PLANILLA fAR_PLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_PLANILLA.Add(fAR_PLANILLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAR_PLANILLA);
        }

        // GET: FAR_PLANILLA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PLANILLA fAR_PLANILLA = db.FAR_PLANILLA.Find(id);
            if (fAR_PLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PLANILLA);
        }

        // POST: FAR_PLANILLA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FECHA_INICIO,FECHA_FIN")] FAR_PLANILLA fAR_PLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_PLANILLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAR_PLANILLA);
        }

        // GET: FAR_PLANILLA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PLANILLA fAR_PLANILLA = db.FAR_PLANILLA.Find(id);
            if (fAR_PLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PLANILLA);
        }

        // POST: FAR_PLANILLA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_PLANILLA fAR_PLANILLA = db.FAR_PLANILLA.Find(id);
            db.FAR_PLANILLA.Remove(fAR_PLANILLA);
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
