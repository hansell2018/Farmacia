using FARMACIA_SEMI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace FARMACIA.Controllers
{
    public class FacturacionController : Controller
    {

        FARMACIAEntities db = new FARMACIAEntities();

        [HttpGet]
        public ActionResult Facturacion()
        {

            if (!validarSesion())
            {
                return RedirectToAction("Index", "Login", null);
            }

            Factura factura = new Factura();
            factura.far_venta = new FAR_VENTA();
            factura.far_det_venta = new List<FAR_DETALLE_VENTA>();
            factura.far_articulo = new List<FAR_ARTICULO>();
            factura.far_cliente = new List<FAR_CLIENTE>();
            factura.far_tpago = new List<FAR_TIPO_PAGO>();

            Session["factura"] = factura;

            llenarListas(UtilsFactura.getTotalFac(factura.far_det_venta));
            return View(factura);
        }

        private void llenarListas(decimal vTotal)
        {
            FARMACIAEntities db = new FARMACIAEntities();
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            var list4 = from c in db.FAR_ARTICULO
                        from p in db.FAR_EXISTENCIA
                        where p.ID_ARTICULO == c.ID_ARTICULO &&
                                p.ID_SUCURSAL == usuario.ID_SUCURSAL &&
                                c.ID_CAT != 1
                        select new { c.ID_ARTICULO, c.DESC_ARTICULO, p.ID_SUCURSAL, p.EXISTENCIA };

            list4 = list4.Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL && s.EXISTENCIA > 0);

            Factura factura = Session["factura"] as Factura;

            if (factura.far_venta.NIT == null)
            {
                //var list = db.FAR_SUCURSAL.ToList();
                var list = db.FAR_SUCURSAL.ToList().Where(s => s.ID_SUCURSAL == usuario.ID_SUCURSAL);
                var list2 = db.FAR_TIPO_PAGO.ToList();
                var list3 = db.FAR_CLIENTE.ToList();
                ViewBag.ID_SUCURSAL = new SelectList(list, "ID_SUCURSAL", "DESC_SUCURSAL");
                ViewBag.NIT = new SelectList(list3, "NIT", "nombreCompleto");
                ViewBag.ID_TPAGO = new SelectList(list2, "ID_TPAGO", "DESC_TPAGO");
            }
            else {
                //var vNit = int.Parse(Request["NIT"]);
                var list = db.FAR_SUCURSAL.Where(s => s.ID_SUCURSAL == factura.far_venta.ID_SUCURSAL).ToList();
                var list2 = db.FAR_TIPO_PAGO.Where(s => s.ID_TPAGO == factura.far_venta.ID_TPAGO).ToList();
                var list3 = db.FAR_CLIENTE.Where(s => s.NIT == factura.far_venta.NIT).ToList();
                ViewBag.ID_SUCURSAL = new SelectList(list, "ID_SUCURSAL", "DESC_SUCURSAL");
                ViewBag.NIT = new SelectList(list3, "NIT", "nombreCompleto");
                ViewBag.ID_TPAGO = new SelectList(list2, "ID_TPAGO", "DESC_TPAGO");
            }


            ViewBag.ID_ARTICULO = new SelectList(list4, "ID_ARTICULO", "DESC_ARTICULO");
            ViewBag.FECHA = DateTime.Today;
            ViewBag.TOTAL = vTotal;

        }

        [HttpPost]
        public ActionResult Facturacion(Factura factura)
        {
            factura = new Factura();
            FAR_USUARIO usuario = new FAR_USUARIO();
            usuario = Session["usuario"] as FAR_USUARIO;

            string v_idFac = "FACE-EGRE0" + UtilsFactura.getFactura(db.FAR_VENTA.ToList());//.Concat(Utils.getFactura(db.FAR_VENTA.ToList()));
            factura = Session["factura"] as Factura;

            decimal v_idSucursal = usuario.ID_SUCURSAL.Value;
            string v_idCliente = Request["NIT"];
            int v_tpago = int.Parse(Request["ID_TPAGO"]);
            var vNit = int.Parse(Request["NIT"]);
            if (factura.far_det_venta.Count() > 0) {

                FAR_VENTA newFactura = new FAR_VENTA
                {
                    ID_SUCURSAL = v_idSucursal,
                    FACTURA = v_idFac,
                    NIT = v_idCliente,
                    ID_TPAGO = v_tpago,
                    FECHA = DateTime.Today
                };

                factura.far_venta = newFactura;
                db.FAR_VENTA.Add(newFactura);
                db.SaveChanges();

                foreach (var I in factura.far_det_venta)
                {
                    FAR_DETALLE_VENTA detalle_fac = new FAR_DETALLE_VENTA()
                    {
                        ITEM = I.ITEM,
                        FACTURA = v_idFac,
                        ID_ARTICULO = I.ID_ARTICULO,
                        CANTIDAD = I.CANTIDAD,
                        COSTO_U = I.COSTO_U,
                    };

                    db.FAR_DETALLE_VENTA.Add(detalle_fac);
                    db.SaveChanges();
                }
            }

            llenarListas(UtilsFactura.getTotalFac(factura.far_det_venta));
            //Session.Remove("factura");
            //factura = new Factura();
            //factura.far_det_venta = new List<FAR_DETALLE_VENTA>();
            //factura.far_venta = new FAR_VENTA();
            //Session["factura"] = factura;
            return View("Facturacion", null, factura);
        }


        [HttpGet]
        public ActionResult agregarProducto()
        {
            FARMACIAEntities db = new FARMACIAEntities();
            Factura factura = new Factura();
            factura = Session["factura"] as Factura;
            //var list4 = db.FAR_ARTICULO.ToList();
            llenarListas(UtilsFactura.getTotalFac(factura.far_det_venta));
            return View();
        }

        [HttpPost]
        public ActionResult agregarProducto(FAR_DETALLE_VENTA fac)
        {

            FARMACIAEntities db = new FARMACIAEntities();
            Factura factura = new Factura();
            FAR_ARTICULO producto = new FAR_ARTICULO();
            FAR_UNIDAD_MED medida = new FAR_UNIDAD_MED();
            FAR_EXISTENCIA exis_prod = new FAR_EXISTENCIA();

            factura = Session["factura"] as Factura;
            int v_id_articulo = int.Parse(Request["id_articulo"]);
            producto = db.FAR_ARTICULO.Find(v_id_articulo);
            exis_prod = db.FAR_EXISTENCIA.Find(1, v_id_articulo);
            medida = db.FAR_UNIDAD_MED.Find(producto.ID_MEDIDA);
            string desc_prod = producto.DESC_ARTICULO;
            decimal v_cantidad = decimal.Parse(Request["CANTIDAD"]);


            if (exis_prod == null || exis_prod.EXISTENCIA < v_cantidad || v_cantidad <= 0)
            {
                ViewBag.Error = "NO HAY EXISTENCIA SUFICIENTE PARA EL PRODUCTO SELECCIONADO";
                llenarListas(UtilsFactura.getTotalFac(factura.far_det_venta));
                return View("Facturacion", factura);
            }

            decimal v_subtotal = exis_prod.COSTO_MEDIO.Value * v_cantidad;

            fac = new FAR_DETALLE_VENTA()
            {
                ID_ARTICULO = v_id_articulo,
                DESCRIPCION = desc_prod,
                COSTO_U = exis_prod.COSTO_MEDIO,
                DES_MEDIDA = medida.DESC_MEDIDA,
                CANTIDAD = v_cantidad,
                SUBTOTAL = v_subtotal
            };

            factura.far_det_venta.Add(fac);
            factura.TOTAL = UtilsFactura.getTotalFac(factura.far_det_venta);
            UtilsFactura.LlenarItems(factura);

            llenarListas(factura.TOTAL);
            return View("Facturacion", factura);
        }

        //[HttpPost]
        public ActionResult EliminarItem(string id)
        {
            Factura listProducto = Session["factura"] as Factura;

            for (int i = 0; i < listProducto.far_det_venta.Count; i++)
            {
                listProducto.far_det_venta.RemoveAll(x => x.ITEM == Convert.ToInt32(id));
            }

            Session["factura"] = listProducto;

            listProducto.TOTAL = UtilsFactura.getTotalFac(listProducto.far_det_venta);
            UtilsFactura.LlenarItems(listProducto);

            llenarListas(listProducto.TOTAL);

            return View("Facturacion", listProducto);
        }

        public ActionResult ImprimirFac()
        {

            FARMACIAEntities db = new FARMACIAEntities();
            Factura factura = new Factura();
            FAR_USUARIO usuario = new FAR_USUARIO();

            usuario = Session["usuario"] as FAR_USUARIO;
            factura = Session["factura"] as Factura;

            //if (factura.far_det_venta.Count() == 0)
            //{
            //    return View("Facturacion", factura);
            //}

            String vPath = "C:\\prueba\\" + factura.far_venta.FACTURA + ".pdf";
            var vCliente = db.FAR_CLIENTE.Find(factura.far_venta.NIT);

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(vPath, FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            Paragraph subtitle = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            subtitle.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("CADENA DE FARMACIAS LA SELECTA, S.A.");
            subtitle.Add("7ma Avenida 4ta Calle zona 1 Escuinta, Escuintla");
            doc.Add(title);
            doc.Add(subtitle);

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("CLIENTE     : " + factura.far_venta.NIT + "   " + vCliente.nombreCompleto));
            doc.Add(new Paragraph("DIRECCION : " + vCliente.DIRECCION));
            doc.Add(new Paragraph("FECHA         : " + factura.far_venta.FECHA));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);


            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblDetFac = new PdfPTable(6);
            tblDetFac.WidthPercentage = 100;
            float[] medidaCeldas = { 0.75f, 0.75f, 2f, 0.75f, 0.75f, 0.75f };
            tblDetFac.SetWidths(medidaCeldas);

            // Configuramos el título de las columnas de la tabla
            PdfPCell cItem = new PdfPCell(new Phrase("ITEM"));
            cItem.BorderWidth = 0;
            cItem.BorderWidthBottom = 0.75f;

            PdfPCell cCodigo = new PdfPCell(new Phrase("CODIGO"));
            cCodigo.BorderWidth = 0;
            cCodigo.BorderWidthBottom = 0.75f;

            PdfPCell cDescripcion = new PdfPCell(new Phrase("DESCRIPCION"));
            cDescripcion.BorderWidth = 0;
            cDescripcion.BorderWidthBottom = 0.75f;

            PdfPCell cCantidad = new PdfPCell(new Phrase("CANTIDAD"));
            cCantidad.BorderWidth = 0;
            cCantidad.BorderWidthBottom = 0.75f;

            PdfPCell cPrecio = new PdfPCell(new Phrase("PRECIO"));
            cPrecio.BorderWidth = 0;
            cPrecio.BorderWidthBottom = 0.75f;

            PdfPCell cSubtotal = new PdfPCell(new Phrase("SUBTOTAL"));
            cSubtotal.BorderWidth = 0;
            cSubtotal.BorderWidthBottom = 0.75f;


            // Añadimos las celdas a la tabla
            tblDetFac.AddCell(cItem);
            tblDetFac.AddCell(cCodigo);
            tblDetFac.AddCell(cDescripcion);
            tblDetFac.AddCell(cCantidad);
            tblDetFac.AddCell(cPrecio);
            tblDetFac.AddCell(cSubtotal);


            foreach (var item in factura.far_det_venta.ToList())
            { 
                //se cargan los datos
                cItem = new PdfPCell(new Phrase(item.ITEM.ToString()));                     cItem.BorderWidth = 0; tblDetFac.AddCell(cItem);
                cCodigo = new PdfPCell(new Phrase(item.ID_ARTICULO.ToString()));            cCodigo.BorderWidth = 0; tblDetFac.AddCell(cCodigo);
                cDescripcion = new PdfPCell(new Phrase(item.DESCRIPCION));                  cDescripcion.BorderWidth = 0; tblDetFac.AddCell(cDescripcion);
                cCantidad = new PdfPCell(new Phrase(item.CANTIDAD.ToString()));             cCantidad.BorderWidth = 0; tblDetFac.AddCell(cCantidad);
                cPrecio = new PdfPCell(new Phrase(item.COSTO_U.ToString()));                cPrecio.BorderWidth = 0; tblDetFac.AddCell(cPrecio);
                cSubtotal = new PdfPCell(new Phrase(item.SUBTOTAL.ToString()));             cSubtotal.BorderWidth = 0; tblDetFac.AddCell(cSubtotal);
            }

            cItem = new PdfPCell(new Phrase(" ")); cItem.BorderWidth = 0; tblDetFac.AddCell(cItem);
            cCodigo = new PdfPCell(new Phrase(" ")); cCodigo.BorderWidth = 0; tblDetFac.AddCell(cCodigo);
            cDescripcion = new PdfPCell(new Phrase(" ")); cDescripcion.BorderWidth = 0; tblDetFac.AddCell(cDescripcion);
            cCantidad = new PdfPCell(new Phrase(" ")); cCantidad.BorderWidth = 0; tblDetFac.AddCell(cCantidad);
            cPrecio = new PdfPCell(new Phrase(" ")); cPrecio.BorderWidth = 0; tblDetFac.AddCell(cPrecio);
            cSubtotal = new PdfPCell(new Phrase(" ")); cSubtotal.BorderWidth = 0; tblDetFac.AddCell(cSubtotal);

            cItem = new PdfPCell(new Phrase("TOTAL ")); cItem.BorderWidth = 0; tblDetFac.AddCell(cItem);
            cCodigo = new PdfPCell(new Phrase("")); cCodigo.BorderWidth = 0; tblDetFac.AddCell(cCodigo);
            cDescripcion = new PdfPCell(new Phrase("")); cDescripcion.BorderWidth = 0; tblDetFac.AddCell(cDescripcion);
            cCantidad = new PdfPCell(new Phrase("")); cCantidad.BorderWidth = 0; tblDetFac.AddCell(cCantidad);
            cPrecio = new PdfPCell(new Phrase("")); cPrecio.BorderWidth = 0; tblDetFac.AddCell(cPrecio);
            cSubtotal = new PdfPCell(new Phrase(factura.TOTAL.ToString())); cSubtotal.BorderWidth = 0; tblDetFac.AddCell(cSubtotal);


            doc.Add(tblDetFac);
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Paragraph("!GRACIAS POR SU COMPRA!"));
            doc.Add(new Paragraph("LE ATENDIO  " + usuario.FAR_EMPLEADO.nombreCompleto));

            doc.Close();

            descargarFile(factura.far_venta.FACTURA.ToString() + ".pdf");

            llenarListas(UtilsFactura.getTotalFac(factura.far_det_venta));
            Session.Remove("factura");
            factura = new Factura();
            factura.far_det_venta = new List<FAR_DETALLE_VENTA>();
            factura.far_venta = new FAR_VENTA();
            Session["factura"] = factura;
            llenarListas(factura.TOTAL);
            return View("Facturacion", factura);
        }

        public void descargarFile(string filename)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";

            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", filename));

            Response.TransmitFile(@"C:\\prueba\\"+ filename);

            Response.End();
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