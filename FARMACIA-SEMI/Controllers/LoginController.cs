using FARMACIA_SEMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARMACIA_SEMI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.Remove("usuario");
            return View();
        }

        [HttpPost]
        public ActionResult Index( FAR_USUARIO pUsuario)
        {

            FARMACIAEntities db = new FARMACIAEntities();

            var user = db.FAR_USUARIO.Find(pUsuario.ID_USUARIO/* pUsuario.CODIGO_EMP, pUsuario.ID_ROL*/);

            if (user == null || pUsuario.CONTRASENIA != user.CONTRASENIA)
            {
                return View();
            }

            Session["usuario"] = user;

            return RedirectToAction("Index","Home",null);
        }
    }
}