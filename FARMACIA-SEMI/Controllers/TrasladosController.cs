using FARMACIA_SEMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARMACIA_SEMI.Controllers
{
    public class TrasladosController : Controller
    {
        FARMACIAEntities db = new FARMACIAEntities();
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

        [HttpGet]
        public ActionResult Traslados()
        {
            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            Traslado traslado = new Traslado();
            traslado.far_articulo = new List<FAR_ARTICULO>();
            traslado.far_det_traslado = new List<FAR_DET_TRASLADO>();
            traslado.far_empleado = new List<FAR_EMPLEADO>();
            traslado.far_sucursal = new List<FAR_SUCURSAL>();
            traslado.far_traslado = new FAR_TRASLADO();

            Session["traslado"] = traslado;
            llenarListas();
            return View(traslado);
        }

        private void llenarListas()
        {
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            var list = from c in db.FAR_ARTICULO
                        from p in db.FAR_EXISTENCIA
                        where p.ID_ARTICULO == c.ID_ARTICULO &&
                                p.ID_SUCURSAL == usuario.ID_SUCURSAL &&
                                c.ID_CAT != 1
                        select new { c.ID_ARTICULO, c.DESC_ARTICULO, p.ID_SUCURSAL, p.EXISTENCIA };

            list = list.Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL && s.EXISTENCIA > 0);


            //var list = db.FAR_ARTICULO.ToList();
            var list2 = db.FAR_EMPLEADO.ToList().Where(s => s.CODIGO_EMP == usuario.CODIGO_EMP);
            var list3 = db.FAR_SUCURSAL.ToList().Where(s => s.ID_SUCURSAL != usuario.ID_SUCURSAL); 
            var origen = db.FAR_SUCURSAL.ToList().Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL);

            ViewBag.ID_ARTICULO = new SelectList(list, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.CODIGO_EMP = new SelectList(list2, "CODIGO_EMP", "NOMBRES");
            ViewBag.ID_ORIGEN  = new SelectList(origen, "ID_SUCURSAL", "DESC_SUCURSAL"); ;
            ViewBag.ID_DESTINO = new SelectList(list3, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.FECHA = DateTime.Today;
        }

        [HttpPost]
        public ActionResult Traslados(Traslado traslado)
        {

            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            int v_idFac = db.FAR_TRASLADO.ToList().Count()+1;
            traslado = Session["traslado"] as Traslado;
            decimal v_idSucursal = usuario.ID_SUCURSAL.Value;
            int v_idSucursal2 = int.Parse(Request["ID_DESTINO"]);
            int v_empleado    = int.Parse(Request["CODIGO_EMP"]);
            DateTime v_fecha  = DateTime.Today;

            if (traslado.far_det_traslado.Count() > 0)
            {

                FAR_TRASLADO newTraslado = new FAR_TRASLADO
                {
                    ID_TRASLADO = v_idFac,
                    ID_ORIGEN   = v_idSucursal,
                    ID_DESTINO  = v_idSucursal2,
                    CODIGO_EMP  = v_empleado,
                    FECHA = v_fecha
                };
                db.FAR_TRASLADO.Add(newTraslado);
                db.SaveChanges();

                foreach (var I in traslado.far_det_traslado)
                {
                    FAR_DET_TRASLADO detalle_traslado = new FAR_DET_TRASLADO
                    {
                        ID_TRASLADO = v_idFac,
                        ITEM = I.ITEM,
                        ID_ARTICULO = I.ID_ARTICULO,
                        CANTIDAD = I.CANTIDAD
                    };

                    db.FAR_DET_TRASLADO.Add(detalle_traslado);
                    db.SaveChanges();
                }
            }
            llenarListas();
            Session.Remove("traslado");
            traslado = new Traslado();
            traslado.far_det_traslado = new List<FAR_DET_TRASLADO>();
            traslado.far_traslado = new FAR_TRASLADO();
            Session["traslado"] = traslado;
            return View("Traslados", null, traslado);
        }


        [HttpGet]
        public ActionResult agregarProducto()
        {
            FARMACIAEntities db = new FARMACIAEntities();

            Traslado traslado = new Traslado();
            traslado = Session["traslado"] as Traslado;
            var list4 = db.FAR_ARTICULO.ToList();
            ViewBag.ID_ARTICULO = new SelectList(list4, "ID_ARTICULO", "DESC_ARTICULO");
            llenarListas();
            return View();
        }

        [HttpPost]
        public ActionResult agregarProducto(FAR_DET_TRASLADO fac)
        {
            FARMACIAEntities db = new FARMACIAEntities();
            Traslado traslado = new Traslado();
            FAR_ARTICULO producto = new FAR_ARTICULO();
            FAR_UNIDAD_MED medida = new FAR_UNIDAD_MED();
            FAR_EXISTENCIA exis_prod = new FAR_EXISTENCIA();
            traslado = Session["traslado"] as Traslado;

            int v_id_articulo        = int.Parse(Request["ID_ARTICULO"]);
            producto                 = db.FAR_ARTICULO.Find(v_id_articulo);
            exis_prod                = db.FAR_EXISTENCIA.Find(1, v_id_articulo);
            medida                   = db.FAR_UNIDAD_MED.Find(producto.ID_MEDIDA);
            string desc_prod         = producto.DESC_ARTICULO;
            decimal v_cantidad       = decimal.Parse(Request["CANTIDAD"]);

            if (exis_prod == null || exis_prod.EXISTENCIA < v_cantidad || v_cantidad <=0)
            {
                //MENSAJE A MODAL
                llenarListas();
                return View("Traslados", traslado);
            }

            decimal v_subtotal       = exis_prod.COSTO_MEDIO.Value * v_cantidad;

            fac = new FAR_DET_TRASLADO()
            {
                ID_ARTICULO = v_id_articulo,
                DESCRIPCION = desc_prod,
                DES_MEDIDA = medida.DESC_MEDIDA,
                CANTIDAD = v_cantidad,
                SUBTOTAL = v_subtotal
            };

            traslado.far_det_traslado.Add(fac);
            UtilsTraslado.LlenarItems(traslado);

            llenarListas();
            return View("Traslados", traslado);
        }



        public ActionResult EliminarItem(string id)
        {
            Traslado listProducto = Session["traslado"] as Traslado;

            for (int i = 0; i < listProducto.far_det_traslado.Count; i++)
            {
                listProducto.far_det_traslado.RemoveAll(x => x.ITEM == Convert.ToInt32(id));
            }

            Session["traslado"] = listProducto;

            llenarListas();

            return View("Traslados", listProducto);
        }
    }
}