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
    public class FAR_CLIENTEController : Controller
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

        // GET: FAR_CLIENTE
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            return View(db.FAR_CLIENTE.ToList());
        }

        // GET: FAR_CLIENTE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_CLIENTE fAR_CLIENTE = db.FAR_CLIENTE.Find(id);
            if (fAR_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(fAR_CLIENTE);
        }

        // GET: FAR_CLIENTE/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NIT,NOMBRES,APELLIDOS,DIRECCION")] FAR_CLIENTE fAR_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                if (validaciones.ExisteCliente(fAR_CLIENTE.NIT))
                {
                    db.FAR_CLIENTE.Add(fAR_CLIENTE);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "¡EL PROVEEDOR YA FUE REGISTRADO!";

            }

            return View(fAR_CLIENTE);
        }

        // GET: FAR_CLIENTE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_CLIENTE fAR_CLIENTE = db.FAR_CLIENTE.Find(id);
            if (fAR_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(fAR_CLIENTE);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NIT,NOMBRES,APELLIDOS,DIRECCION")] FAR_CLIENTE fAR_CLIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_CLIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAR_CLIENTE);
        }

        // GET: FAR_CLIENTE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_CLIENTE fAR_CLIENTE = db.FAR_CLIENTE.Find(id);
            if (fAR_CLIENTE == null)
            {
                return HttpNotFound();
            }
            return View(fAR_CLIENTE);
        }

        // POST: FAR_CLIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FAR_CLIENTE fAR_CLIENTE = db.FAR_CLIENTE.Find(id);
            db.FAR_CLIENTE.Remove(fAR_CLIENTE);
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
