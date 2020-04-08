
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_EXISTENCIA
    {
        public decimal ID_SUCURSAL { get; set; }
        public decimal ID_ARTICULO { get; set; }
        public Nullable<decimal> EXISTENCIA { get; set; }
        [Display(Name = "PRECIO")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> COSTO_MEDIO { get; set; }
        public string USR_MOD { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_MOD { get; set; }
    
        public virtual FAR_ARTICULO FAR_ARTICULO { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
    }
}
