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
    public class FAR_PAGO_PLANILLAController : Controller
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

            var fAR_PAGO_PLANILLA = db.FAR_PAGO_PLANILLA.Include(f => f.FAR_EMPLEADO).Include(f => f.FAR_SUCURSAL).Include(f => f.FAR_PLANILLA);
            return View(fAR_PAGO_PLANILLA.ToList());
        }

        // GET: FAR_PAGO_PLANILLA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA = db.FAR_PAGO_PLANILLA.Find(id);
            if (fAR_PAGO_PLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PAGO_PLANILLA);
        }

        // GET: FAR_PAGO_PLANILLA/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.ID_PLANILLA = new SelectList(db.FAR_PLANILLA, "Id", "duracion");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLANILLA,CODIGO_EMP,ID_SUCURSAL,DIAS_LAB,SUELDO_NETO,BONIFICACION,IGSS,DESCUENTOS,LIQUIDO,USR_MOD,FECHA_MOD")] FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA)
        {
            if (ModelState.IsValid)
            {
                if (validaciones.ExisteEnPlanilla(fAR_PAGO_PLANILLA.CODIGO_EMP, fAR_PAGO_PLANILLA.ID_PLANILLA))
                {
                    db.FAR_PAGO_PLANILLA.Add(fAR_PAGO_PLANILLA);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "EMPLEADO YA APARECE EN PLANILLA";
            }

            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto", fAR_PAGO_PLANILLA.CODIGO_EMP);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_PAGO_PLANILLA.ID_SUCURSAL);
            ViewBag.ID_PLANILLA = new SelectList(db.FAR_PLANILLA, "Id", "duracion", fAR_PAGO_PLANILLA.ID_PLANILLA);
            return View(fAR_PAGO_PLANILLA);
        }

        // GET: FAR_PAGO_PLANILLA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA = db.FAR_PAGO_PLANILLA.Find(id);
            if (fAR_PAGO_PLANILLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES", fAR_PAGO_PLANILLA.CODIGO_EMP);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_PAGO_PLANILLA.ID_SUCURSAL);
            ViewBag.ID_PLANILLA = new SelectList(db.FAR_PLANILLA, "Id", "duracion", fAR_PAGO_PLANILLA.ID_PLANILLA);
            return View(fAR_PAGO_PLANILLA);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLANILLA,CODIGO_EMP,ID_SUCURSAL,DIAS_LAB,SUELDO_NETO,BONIFICACION,IGSS,DESCUENTOS,LIQUIDO,USR_MOD,FECHA_MOD")] FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_PAGO_PLANILLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "NOMBRES", fAR_PAGO_PLANILLA.CODIGO_EMP);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_PAGO_PLANILLA.ID_SUCURSAL);
            ViewBag.ID_PLANILLA = new SelectList(db.FAR_PLANILLA, "Id", "duracion", fAR_PAGO_PLANILLA.ID_PLANILLA);
            return View(fAR_PAGO_PLANILLA);
        }

        // GET: FAR_PAGO_PLANILLA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA = db.FAR_PAGO_PLANILLA.Find(id);
            if (fAR_PAGO_PLANILLA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PAGO_PLANILLA);
        }

        // POST: FAR_PAGO_PLANILLA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_PAGO_PLANILLA fAR_PAGO_PLANILLA = db.FAR_PAGO_PLANILLA.Find(id);
            db.FAR_PAGO_PLANILLA.Remove(fAR_PAGO_PLANILLA);
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
