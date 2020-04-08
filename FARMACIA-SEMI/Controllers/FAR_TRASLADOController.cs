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
    public class FAR_TRASLADOController : Controller
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
        // GET: FAR_TRASLADO
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_TRASLADO = db.FAR_TRASLADO.Include(f => f.FAR_EMPLEADO).Include(f => f.FAR_SUCURSAL).Include(f => f.FAR_SUCURSAL1);
            return View(fAR_TRASLADO.ToList());
        }

        // GET: FAR_TRASLADO/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_TRASLADO fAR_TRASLADO = db.FAR_TRASLADO.Find(id);
            if (fAR_TRASLADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_TRASLADO);
        }

        // GET: FAR_TRASLADO/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES");
            ViewBag.ID_ORIGEN = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.ID_DESTINO = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRASLADO,ID_ORIGEN,ID_DESTINO,CODIGO_EMP,FECHA")] FAR_TRASLADO fAR_TRASLADO)
        {
            if (ModelState.IsValid)
            {
                db.FAR_TRASLADO.Add(fAR_TRASLADO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES", fAR_TRASLADO.CODIGO_EMP);
            ViewBag.ID_ORIGEN = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_ORIGEN);
            ViewBag.ID_DESTINO = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_DESTINO);
            return View(fAR_TRASLADO);
        }

        // GET: FAR_TRASLADO/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_TRASLADO fAR_TRASLADO = db.FAR_TRASLADO.Find(id);
            if (fAR_TRASLADO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES", fAR_TRASLADO.CODIGO_EMP);
            ViewBag.ID_ORIGEN = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_ORIGEN);
            ViewBag.ID_DESTINO = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_DESTINO);
            return View(fAR_TRASLADO);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRASLADO,ID_ORIGEN,ID_DESTINO,CODIGO_EMP,FECHA")] FAR_TRASLADO fAR_TRASLADO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_TRASLADO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES", fAR_TRASLADO.CODIGO_EMP);
            ViewBag.ID_ORIGEN = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_ORIGEN);
            ViewBag.ID_DESTINO = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_TRASLADO.ID_DESTINO);
            return View(fAR_TRASLADO);
        }

        // GET: FAR_TRASLADO/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_TRASLADO fAR_TRASLADO = db.FAR_TRASLADO.Find(id);
            if (fAR_TRASLADO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_TRASLADO);
        }

        // POST: FAR_TRASLADO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_TRASLADO fAR_TRASLADO = db.FAR_TRASLADO.Find(id);
            db.FAR_TRASLADO.Remove(fAR_TRASLADO);
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
