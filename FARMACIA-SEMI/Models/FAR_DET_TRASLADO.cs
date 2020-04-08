
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_DET_TRASLADO : Det_Traslado
    {
        public decimal ID_TRASLADO { get; set; }
        public decimal ITEM { get; set; }
        [Display(Name = "PRODUCTO")]
        public Nullable<decimal> ID_ARTICULO { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<decimal> CANTIDAD { get; set; }
        public string COMENTARIO { get; set; }
    
        public virtual FAR_ARTICULO FAR_ARTICULO { get; set; }
        public virtual FAR_TRASLADO FAR_TRASLADO { get; set; }
    }
}
