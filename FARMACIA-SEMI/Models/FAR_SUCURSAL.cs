
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_SUCURSAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_SUCURSAL()
        {
            this.FAR_COMPRA = new HashSet<FAR_COMPRA>();
            this.FAR_EMP_SUC = new HashSet<FAR_EMP_SUC>();
            this.FAR_EXISTENCIA = new HashSet<FAR_EXISTENCIA>();
            this.FAR_MOV_CAJA = new HashSet<FAR_MOV_CAJA>();
            this.FAR_PAGO_PLANILLA = new HashSet<FAR_PAGO_PLANILLA>();
            this.FAR_RUTA = new HashSet<FAR_RUTA>();
            this.FAR_SUCURSAL_ACTIVO = new HashSet<FAR_SUCURSAL_ACTIVO>();
            this.FAR_TRASLADO = new HashSet<FAR_TRASLADO>();
            this.FAR_TRASLADO1 = new HashSet<FAR_TRASLADO>();
            this.FAR_USUARIO = new HashSet<FAR_USUARIO>();
            this.FAR_VENTA = new HashSet<FAR_VENTA>();
        }
        
        public decimal ID_SUCURSAL { get; set; }
        [Display(Name = "SUCURSAL")]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DESC_SUCURSAL { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_ALTA { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FECHA_BAJA { get; set; }
        public string ESTATUS { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DIRECCION { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<decimal> TELEFONO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_COMPRA> FAR_COMPRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_EMP_SUC> FAR_EMP_SUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_EXISTENCIA> FAR_EXISTENCIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_MOV_CAJA> FAR_MOV_CAJA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_PAGO_PLANILLA> FAR_PAGO_PLANILLA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_RUTA> FAR_RUTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_SUCURSAL_ACTIVO> FAR_SUCURSAL_ACTIVO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_TRASLADO> FAR_TRASLADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_TRASLADO> FAR_TRASLADO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_USUARIO> FAR_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_VENTA> FAR_VENTA { get; set; }
    }
}
