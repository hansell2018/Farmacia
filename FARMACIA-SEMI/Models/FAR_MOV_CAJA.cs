
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_MOV_CAJA
    {
        public decimal ID_REGISTRO { get; set; }
        [Display(Name = "SUCURSAL")]
        public decimal ID_SUCURSAL { get; set; }
        [Display(Name = "TRANSACCION")]
        public Nullable<decimal> ID_TRANSACCION { get; set; }
        [Display(Name = "ESTATUS")]
        public Nullable<decimal> ID_ESTATUS { get; set; }
        public string DOCUMENTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> MONTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> SALDO { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA { get; set; }
        public string COMENTARIO { get; set; }
        public string USER_MOD { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_MOD { get; set; }
    
        public virtual FAR_ESTATUS FAR_ESTATUS { get; set; }
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
        public virtual FAR_TTRANSACCION FAR_TTRANSACCION { get; set; }
    }
}
