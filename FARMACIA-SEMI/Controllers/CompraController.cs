using FARMACIA_SEMI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FARMACIA.Controllers
{
    public class CompraController : Controller
    {
        FARMACIAEntities db = new FARMACIAEntities();

        [HttpGet]
        public ActionResult Compra()
        {
            Compra compra = new Compra();
            compra.far_compra = new FAR_COMPRA();
            compra.far_det_compra= new List<FAR_DETALLE_COMPRA>();
            compra.far_articulo = new List<FAR_ARTICULO>();
            compra.far_cliente = new List<FAR_CLIENTE>();
            compra.far_tpago = new List<FAR_TIPO_PAGO>();

            Session["compra"] = compra;

           
            if (!validarSesion())
            {
               return RedirectToAction("Index", "Login", null);
            }

            llenarListas(UtilsCompra.getTotalFac(compra.far_det_compra));
            return View(compra);
        }

        private void llenarListas(decimal vTotal)
        {
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            var list = db.FAR_SUCURSAL.ToList().Where(s=> s.ID_SUCURSAL == usuario.ID_SUCURSAL);
            var list2 = db.FAR_TIPO_PAGO.ToList();
            var list3 = db.FAR_PROVEEDOR.ToList();
            var list4 = db.FAR_ARTICULO.ToList();

            ViewBag.ID_SUCURSAL = new SelectList(list, "ID_SUCURSAL", "DESC_SUCURSAL");
            ViewBag.NIT = new SelectList(list3, "NIT", "DESC_NIT", "NOM_CONTACTO");
            ViewBag.ID_TPAGO = new SelectList(list2, "ID_TPAGO", "DESC_TPAGO");
            ViewBag.ID_ARTICULO = new SelectList(list4, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.TOTAL = vTotal;
            ViewBag.FECHA = DateTime.Today;
        }

        [HttpPost]
        public ActionResult Compra(Compra compra)
        {
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            string v_idFac ="FACE-0" + UtilsCompra.getFactura(db.FAR_COMPRA.ToList());// Request["FACTURA"]; //
            compra = Session["compra"] as Compra;
            decimal v_idSucursal = usuario.ID_SUCURSAL.Value;
            string v_idCliente = Request["NIT"];
            int v_tpago = int.Parse(Request["ID_TPAGO"]);
            DateTime v_fecha = DateTime.Today;

            if (compra.far_det_compra.Count() > 0)
            {

                FAR_COMPRA newCompra = new FAR_COMPRA
                {
                    ID_SUCURSAL = v_idSucursal,
                    FACTURA = v_idFac,
                    NIT = v_idCliente,
                    ID_TPAGO = v_tpago,
                    FECHA = v_fecha
                };
                db.FAR_COMPRA.Add(newCompra);
                db.SaveChanges();

                foreach (var I in compra.far_det_compra)
                {
                    FAR_DETALLE_COMPRA detalle_compra = new FAR_DETALLE_COMPRA
                    {
                        ITEM = I.ITEM,
                        FACTURA = v_idFac,
                        ID_ARTICULO = I.ID_ARTICULO,
                        CANTIDAD = I.CANTIDAD,
                        COSTO_U = I.COSTO_U,
                    };

                    db.FAR_DETALLE_COMPRA.Add(detalle_compra);
                    db.SaveChanges();
                }
            }

            llenarListas(UtilsCompra.getTotalFac(compra.far_det_compra));
            Session.Remove("compra");
            compra = new Compra();
            compra.far_det_compra = new List<FAR_DETALLE_COMPRA>();
            compra.far_compra = new FAR_COMPRA();
            Session["compra"] = compra;
            return View("Compra", null, compra);
        }


        [HttpGet]
        public ActionResult agregarProducto()
        {
            FARMACIAEntities db = new FARMACIAEntities();
            Compra compra = new Compra(); 

            compra = Session["compra"] as Compra;
            llenarListas(UtilsCompra.getTotalFac(compra.far_det_compra));
            return View();
        }

        [HttpPost]
        public ActionResult agregarProducto(FAR_DETALLE_COMPRA fac)
        {
            FARMACIAEntities db = new FARMACIAEntities();
            Compra compra = new Compra();
            FAR_ARTICULO producto = new FAR_ARTICULO();
            FAR_UNIDAD_MED medida = new FAR_UNIDAD_MED();

            compra = Session["compra"] as Compra;
            int v_id_articulo = int.Parse(Request["ID_ARTICULO"]);
            producto          = db.FAR_ARTICULO.Find(v_id_articulo);
            medida            = db.FAR_UNIDAD_MED.Find(producto.ID_MEDIDA);
            string desc_prod  = producto.DESC_ARTICULO;
            decimal v_cantidad = decimal.Parse(Request["CANTIDAD"]);
            decimal v_costo_u  = decimal.Parse(Request["Costo_U"]);
            decimal v_subtotal = v_costo_u * v_cantidad;

            if ( v_cantidad <= 0 || v_costo_u < 0)
            {
                return View("Compra", compra);
            }

            fac = new FAR_DETALLE_COMPRA()
            {
                ID_ARTICULO = v_id_articulo,
                DESCRIPCION = desc_prod,
                COSTO_U = v_costo_u,
                DES_MEDIDA = medida.DESC_MEDIDA,
                CANTIDAD = v_cantidad,
                SUBTOTAL = v_subtotal
            };

            compra.far_det_compra.Add(fac);
            compra.TOTAL = UtilsCompra.getTotalFac(compra.far_det_compra);
            UtilsCompra.LlenarItems(compra);

            llenarListas(compra.TOTAL);
            return View("Compra", compra);
        }


        public ActionResult EliminarItem(string id)
        {
            Compra listProducto = Session["compra"] as Compra;

            for (int i = 0; i < listProducto.far_det_compra.Count; i++)
            {
                listProducto.far_det_compra.RemoveAll(x => x.ITEM == Convert.ToInt32(id));
            }

            Session["compra"] = listProducto;

            listProducto.TOTAL = UtilsCompra.getTotalFac(listProducto.far_det_compra);
            UtilsCompra.LlenarItems(listProducto);

            llenarListas(listProducto.TOTAL);

            return View("Compra", listProducto);
        }



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
    }
 }