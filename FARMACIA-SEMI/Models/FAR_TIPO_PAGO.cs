
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_TIPO_PAGO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_TIPO_PAGO()
        {
            this.FAR_COMPRA = new HashSet<FAR_COMPRA>();
            this.FAR_VENTA = new HashSet<FAR_VENTA>();
        }
        
        [Display(Name = "CODIGO PAGO")]
        public decimal ID_TPAGO { get; set; }
        [Display(Name = "PAGO")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_TPAGO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_COMPRA> FAR_COMPRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_VENTA> FAR_VENTA { get; set; }
    }
}
