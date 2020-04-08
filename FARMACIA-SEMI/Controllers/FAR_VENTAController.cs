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
    public class FAR_VENTAController : Controller
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
        // GET: FAR_VENTA
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_VENTA = db.FAR_VENTA.Include(f => f.FAR_CLIENTE).Include(f => f.FAR_SUCURSAL).Include(f => f.FAR_TIPO_PAGO);
            return View(fAR_VENTA.ToList());
        }

        // GET: FAR_VENTA/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_VENTA fAR_VENTA = db.FAR_VENTA.Find(id);
            if (fAR_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_VENTA);
        }

        // GET: FAR_VENTA/Create
        public ActionResult Create()
        {
            ViewBag.NIT = new SelectList(db.FAR_CLIENTE, "NIT", "nombreCompleto");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO");
            return View();
        }

        // POST: FAR_VENTA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SUCURSAL,FACTURA,NIT,ID_TPAGO,FECHA")] FAR_VENTA fAR_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.FAR_VENTA.Add(fAR_VENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NIT = new SelectList(db.FAR_CLIENTE, "NIT", "NOMBRES", fAR_VENTA.NIT);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_VENTA.ID_SUCURSAL);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_VENTA.ID_TPAGO);
            return View(fAR_VENTA);
        }

        // GET: FAR_VENTA/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_VENTA fAR_VENTA = db.FAR_VENTA.Find(id);
            if (fAR_VENTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.NIT = new SelectList(db.FAR_CLIENTE, "NIT", "NOMBRES", fAR_VENTA.NIT);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_VENTA.ID_SUCURSAL);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_VENTA.ID_TPAGO);
            return View(fAR_VENTA);
        }

        // POST: FAR_VENTA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SUCURSAL,FACTURA,NIT,ID_TPAGO,FECHA")] FAR_VENTA fAR_VENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_VENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NIT = new SelectList(db.FAR_CLIENTE, "NIT", "NOMBRES", fAR_VENTA.NIT);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_VENTA.ID_SUCURSAL);
            ViewBag.ID_TPAGO = new SelectList(db.FAR_TIPO_PAGO, "ID_TPAGO", "DESC_TPAGO", fAR_VENTA.ID_TPAGO);
            return View(fAR_VENTA);
        }

        // GET: FAR_VENTA/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_VENTA fAR_VENTA = db.FAR_VENTA.Find(id);
            if (fAR_VENTA == null)
            {
                return HttpNotFound();
            }
            return View(fAR_VENTA);
        }

        // POST: FAR_VENTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FAR_VENTA fAR_VENTA = db.FAR_VENTA.Find(id);
            db.FAR_VENTA.Remove(fAR_VENTA);
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
