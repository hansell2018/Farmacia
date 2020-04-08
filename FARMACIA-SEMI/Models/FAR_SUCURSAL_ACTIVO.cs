
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_SUCURSAL_ACTIVO
    {
        [Display(Name = "PRODUCTO")]
        public decimal ID_ARTICULO { get; set; }
        [Display(Name = "SUCURSAL")]
        public decimal ID_SUCURSAL { get; set; }
        [Display(Name = "PRECIO")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> COSTO_ACTIVO { get; set; }
        [Display(Name = "CODIGO")]
        public string COMENTARIO { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_ALTA { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_BAJA { get; set; }
    
        public virtual FAR_ARTICULO FAR_ARTICULO { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
    }
}
