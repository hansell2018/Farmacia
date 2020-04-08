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
    public class FAR_MOV_CAJAController : Controller
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

            llenarLista();

            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;
            //var list = db.FAR_SUCURSAL.ToList().Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL);
            var fAR_MOV_CAJA = db.FAR_MOV_CAJA.Include(f => f.FAR_SUCURSAL).Include(f => f.FAR_TTRANSACCION);
            return View(fAR_MOV_CAJA.ToList().Where(a=> a.ID_SUCURSAL == usuario.ID_SUCURSAL));
        }
        

        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_MOV_CAJA fAR_MOV_CAJA = db.FAR_MOV_CAJA.Find(id);
            if (fAR_MOV_CAJA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_MOV_CAJA);
        }
        

        public ActionResult Create()
        {
            llenarLista();
            //ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.ID_TRANSACCION = new SelectList(db.FAR_TTRANSACCION, "ID_TRANSACCION", "DESC_TANSACCION");
            return View();
        }

        public void llenarLista()
        {
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;
            var vSucursal = db.FAR_SUCURSAL.ToList().Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL);
            ViewBag.ID_SUCURSAL = new SelectList(vSucursal, "ID_SUCURSAL", "DESC_SUCURSAL");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REGISTRO,ID_SUCURSAL,ID_TRANSACCION,MONTO,SALDO,FECHA,COMENTARIO,USER_MOD,FECHA_MOD")] FAR_MOV_CAJA fAR_MOV_CAJA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_MOV_CAJA.Add(fAR_MOV_CAJA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_MOV_CAJA.ID_SUCURSAL);
            ViewBag.ID_TRANSACCION = new SelectList(db.FAR_TTRANSACCION, "ID_TRANSACCION", "DESC_TANSACCION", fAR_MOV_CAJA.ID_TRANSACCION);
            return View(fAR_MOV_CAJA);
        }
        

        public ActionResult Edit(decimal id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_MOV_CAJA fAR_MOV_CAJA = db.FAR_MOV_CAJA.Find(id);
            if (fAR_MOV_CAJA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_MOV_CAJA.ID_SUCURSAL);
            ViewBag.ID_TRANSACCION = new SelectList(db.FAR_TTRANSACCION, "ID_TRANSACCION", "DESC_TANSACCION", fAR_MOV_CAJA.ID_TRANSACCION);
            return View(fAR_MOV_CAJA);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REGISTRO,ID_SUCURSAL,ID_TRANSACCION,MONTO,SALDO,FECHA,COMENTARIO,USER_MOD,FECHA_MOD")] FAR_MOV_CAJA fAR_MOV_CAJA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_MOV_CAJA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_MOV_CAJA.ID_SUCURSAL);
            ViewBag.ID_TRANSACCION = new SelectList(db.FAR_TTRANSACCION, "ID_TRANSACCION", "DESC_TANSACCION", fAR_MOV_CAJA.ID_TRANSACCION);
            return View(fAR_MOV_CAJA);
        }


        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_MOV_CAJA fAR_MOV_CAJA = db.FAR_MOV_CAJA.Find(id);
            if (fAR_MOV_CAJA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_MOV_CAJA);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_MOV_CAJA fAR_MOV_CAJA = db.FAR_MOV_CAJA.Find(id);
            db.FAR_MOV_CAJA.Remove(fAR_MOV_CAJA);
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
