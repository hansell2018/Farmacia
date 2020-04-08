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
    public class FAR_USUARIOController : Controller
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
        // GET: FAR_USUARIO
        public ActionResult Index()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            var fAR_USUARIO = db.FAR_USUARIO.Include(f => f.FAR_EMPLEADO).Include(f => f.FAR_ROL).Include(f => f.FAR_SUCURSAL);
            return View(fAR_USUARIO.ToList());
        }

        // GET: FAR_USUARIO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_USUARIO fAR_USUARIO = db.FAR_USUARIO.Find(id);
            if (fAR_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_USUARIO);
        }

        // GET: FAR_USUARIO/Create
        public ActionResult Create()
        {
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto");
            ViewBag.ID_ROL = new SelectList(db.FAR_ROL, "ID_ROL", "DESC_ROL");
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIO,ID_SUCURSAL,ID_ROL,CODIGO_EMP,CONTRASENIA")] FAR_USUARIO fAR_USUARIO)
        {
            if (ModelState.IsValid)
            {
                if (validaciones.ExisteUsuario(fAR_USUARIO.ID_USUARIO))
                {
                    db.FAR_USUARIO.Add(fAR_USUARIO);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "¡EL USUARIO YA FUE REGISTRADO!";

            }

            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto", fAR_USUARIO.CODIGO_EMP);
            ViewBag.ID_ROL = new SelectList(db.FAR_ROL, "ID_ROL", "DESC_ROL", fAR_USUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_USUARIO.ID_SUCURSAL);
            return View(fAR_USUARIO);
        }

        // GET: FAR_USUARIO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_USUARIO fAR_USUARIO = db.FAR_USUARIO.Find(id);
            if (fAR_USUARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto", fAR_USUARIO.CODIGO_EMP);
            ViewBag.ID_ROL = new SelectList(db.FAR_ROL, "ID_ROL", "DESC_ROL", fAR_USUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_USUARIO.ID_SUCURSAL);
            return View(fAR_USUARIO);
        }

        // POST: FAR_USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIO,ID_SUCURSAL,ID_ROL,CODIGO_EMP,CONTRASENIA")] FAR_USUARIO fAR_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAR_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CODIGO_EMP = new SelectList(db.FAR_EMPLEADO, "CODIGO_EMP", "nombreCompleto", fAR_USUARIO.CODIGO_EMP);
            ViewBag.ID_ROL = new SelectList(db.FAR_ROL, "ID_ROL", "DESC_ROL", fAR_USUARIO.ID_ROL);
            ViewBag.ID_SUCURSAL = new SelectList(db.FAR_SUCURSAL, "ID_SUCURSAL", "DESC_SUCURSAL", fAR_USUARIO.ID_SUCURSAL);
            return View(fAR_USUARIO);
        }

        // GET: FAR_USUARIO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAR_USUARIO fAR_USUARIO = db.FAR_USUARIO.Find(id);
            if (fAR_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(fAR_USUARIO);
        }

        // POST: FAR_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FAR_USUARIO fAR_USUARIO = db.FAR_USUARIO.Find(id);
            db.FAR_USUARIO.Remove(fAR_USUARIO);
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
