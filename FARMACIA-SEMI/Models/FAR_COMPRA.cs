
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_COMPRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_COMPRA()
        {
            this.FAR_DETALLE_COMPRA = new HashSet<FAR_DETALLE_COMPRA>();
        }
    
        public string FACTURA { get; set; }
        [Display(Name = "SUCURSAL")]
        public Nullable<decimal> ID_SUCURSAL { get; set; }
        [Display(Name = "ESTATUS")]
        public Nullable<decimal> ID_ESTATUS { get; set; }
        [Display(Name = "PROVEEDOR")]
        public string NIT { get; set; }
        [Display(Name = "PAGO")]
        public Nullable<decimal> ID_TPAGO { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA { get; set; }
    
        public virtual FAR_SUCURSAL FAR_SUCURSAL { get; set; }
        public virtual FAR_PROVEEDOR FAR_PROVEEDOR { get; set; }
        public virtual FAR_TIPO_PAGO FAR_TIPO_PAGO { get; set; }
        public virtual FAR_ESTATUS FAR_ESTATUS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_DETALLE_COMPRA> FAR_DETALLE_COMPRA { get; set; }
    }
}
