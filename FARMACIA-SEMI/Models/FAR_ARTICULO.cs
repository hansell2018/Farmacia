
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_ARTICULO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_ARTICULO()
        {
            this.FAR_DETALLE_COMPRA = new HashSet<FAR_DETALLE_COMPRA>();
            this.FAR_DET_TRASLADO = new HashSet<FAR_DET_TRASLADO>();
            this.FAR_DETALLE_VENTA = new HashSet<FAR_DETALLE_VENTA>();
            this.FAR_EXISTENCIA = new HashSet<FAR_EXISTENCIA>();
            this.FAR_SUCURSAL_ACTIVO = new HashSet<FAR_SUCURSAL_ACTIVO>();
        }
        
        [Display(Name ="CODIGO PRODUCTO")]
        public decimal ID_ARTICULO { get; set; }
        [Display(Name = "MARCA")]
        public Nullable<decimal> ID_MARCA { get; set; }
        [Display(Name = "CATEGORIA")]
        public Nullable<decimal> ID_CAT { get; set; }
        [Display(Name = "MEDIDA")]
        public Nullable<decimal> ID_MEDIDA { get; set; }
        [Display(Name = "PRODUCTO")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_ARTICULO { get; set; }
    
        public virtual FAR_CAT_ARTICULO FAR_CAT_ARTICULO { get; set; }
        public virtual FAR_MARCA FAR_MARCA { get; set; }
        public virtual FAR_UNIDAD_MED FAR_UNIDAD_MED { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_DETALLE_COMPRA> FAR_DETALLE_COMPRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_DET_TRASLADO> FAR_DET_TRASLADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_DETALLE_VENTA> FAR_DETALLE_VENTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_EXISTENCIA> FAR_EXISTENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_SUCURSAL_ACTIVO> FAR_SUCURSAL_ACTIVO { get; set; }
    }
}
