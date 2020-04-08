using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class Factura
    {
        public FAR_VENTA far_venta { get; set; }
        public List<FAR_DETALLE_VENTA> far_det_venta { get; set; }
        public List<FAR_CLIENTE> far_cliente { get; set; }
        public List<FAR_ARTICULO> far_articulo { get; set; }
        public List<FAR_TIPO_PAGO> far_tpago { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TOTAL { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal DESCUENTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal EFCTIVO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal CAMBIO { get; set; }
    }
}