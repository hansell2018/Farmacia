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
    public class FAR_SUCURSAL_ACTIVOController : Controller
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
            var fAR_SUCURSAL_ACTIVO = db.FAR_SUCURSAL_ACTIVO.Include(f => f.FAR_ARTICULO).Include(f => f.FAR_SUCURSAL);
            return View(fAR_SUCURSAL_ACTIVO.ToList());
        }

        // GET: FAR_SUCURSAL_ACTIVO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO = db.FAR_SUCURSAL_ACTIVO.Find(id);
            if (fAR_SUCURSAL_ACTIVO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_SUCURSAL_ACTIVO);
        }

        // GET: FAR_SUCURSAL_ACTIVO/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTICULO,ID_SUCURSAL,COSTO_ACTIVO,COMENTARIO,FECHA_ALTA,FECHA_BAJA")] FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO)
        {
            if (ModelState.IsValid)
            {
                db.FAR_SUCURSAL_ACTIVO.Add(fAR_SUCURSAL_ACTIVO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_SUCURSAL_ACTIVO.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_SUCURSAL_ACTIVO.ID_SUCURSAL);
            return View(fAR_SUCURSAL_ACTIVO);
        }

        // GET: FAR_SUCURSAL_ACTIVO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO = db.FAR_SUCURSAL_ACTIVO.Find(id);
            if (fAR_SUCURSAL_ACTIVO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_SUCURSAL_ACTIVO.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_SUCURSAL_ACTIVO.ID_SUCURSAL);
            return View(fAR_SUCURSAL_ACTIVO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTICULO,ID_SUCURSAL,COSTO_ACTIVO,COMENTARIO,FECHA_ALTA,FECHA_BAJA")] FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_SUCURSAL_ACTIVO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTICULO = new SelectList(db.FAR_ARTICULO, "ID_ARTICULO", "DESC_ARTICULO", fAR_SUCURSAL_ACTIVO.ID_ARTICULO);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_SUCURSAL_ACTIVO.ID_SUCURSAL);
            return View(fAR_SUCURSAL_ACTIVO);
        }

        // GET: FAR_SUCURSAL_ACTIVO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO = db.FAR_SUCURSAL_ACTIVO.Find(id);
            if (fAR_SUCURSAL_ACTIVO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_SUCURSAL_ACTIVO);
        }

        // POST: FAR_SUCURSAL_ACTIVO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_SUCURSAL_ACTIVO fAR_SUCURSAL_ACTIVO = db.FAR_SUCURSAL_ACTIVO.Find(id);
            db.FAR_SUCURSAL_ACTIVO.Remove(fAR_SUCURSAL_ACTIVO);
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
