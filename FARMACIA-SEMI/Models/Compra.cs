using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class Compra
    {
        public FAR_COMPRA far_compra { get; set; }
        public List<FAR_DETALLE_COMPRA> far_det_compra { get; set; }
        public List<FAR_CLIENTE> far_cliente { get; set; }
        public List<FAR_ARTICULO> far_articulo { get; set; }
        public List<FAR_TIPO_PAGO> far_tpago { get; set; }
        public decimal TOTAL { get; set; }
        public decimal DESCUENTO { get; set; }
        public decimal EFCTIVO { get; set; }
        public decimal CAMBIO { get; set; }
    }
}