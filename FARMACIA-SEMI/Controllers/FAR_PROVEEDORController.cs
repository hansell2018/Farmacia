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
    public class FAR_PROVEEDORController : Controller
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

        // GET: FAR_PROVEEDOR
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            return View(db.FAR_PROVEEDOR.ToList());
        }

        // GET: FAR_PROVEEDOR/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PROVEEDOR fAR_PROVEEDOR = db.FAR_PROVEEDOR.Find(id);
            if (fAR_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PROVEEDOR);
        }

        // GET: FAR_PROVEEDOR/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIT,DESC_NIT,NOM_CONTACTO,TEL_CONTACTO,TEL_PROVEEDOR")] FAR_PROVEEDOR fAR_PROVEEDOR)
        {
            if (ModelState.IsValid && fAR_PROVEEDOR != null)
            {

               if (validaciones.ExisteProveedor(fAR_PROVEEDOR.NIT))
                {
                    db.FAR_PROVEEDOR.Add(fAR_PROVEEDOR);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "¡EL USUARIO YA FUE REGISTRADO!";

            }

            return View(fAR_PROVEEDOR);
        }

        // GET: FAR_PROVEEDOR/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PROVEEDOR fAR_PROVEEDOR = db.FAR_PROVEEDOR.Find(id);
            if (fAR_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PROVEEDOR);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIT,DESC_NIT,NOM_CONTACTO,TEL_CONTACTO,TEL_PROVEEDOR")] FAR_PROVEEDOR fAR_PROVEEDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_PROVEEDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAR_PROVEEDOR);
        }

        // GET: FAR_PROVEEDOR/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_PROVEEDOR fAR_PROVEEDOR = db.FAR_PROVEEDOR.Find(id);
            if (fAR_PROVEEDOR == null)
            {
                return HttpNotFound();
            }
            return View(fAR_PROVEEDOR);
        }

        // POST: FAR_PROVEEDOR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FAR_PROVEEDOR fAR_PROVEEDOR = db.FAR_PROVEEDOR.Find(id);
            db.FAR_PROVEEDOR.Remove(fAR_PROVEEDOR);
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
