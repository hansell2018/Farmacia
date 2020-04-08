
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_DETALLE_COMPRA : DetCompra
    {
        public string FACTURA { get; set; }
        public decimal ITEM { get; set; }
        [Display(Name = "PRODUCTO")]
        public Nullable<decimal> ID_ARTICULO { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<decimal> CANTIDAD { get; set; }
        [Display(Name = "PRECIO")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> COSTO_U { get; set; }
    
        public virtual FAR_ARTICULO FAR_ARTICULO { get; set; }
        public virtual FAR_COMPRA FAR_COMPRA { get; set; }
    }
}
