
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_EMPLEADO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_EMPLEADO()
        {
            this.FAR_EMP_SUC = new HashSet<FAR_EMP_SUC>();
            this.FAR_PAGO_PLANILLA = new HashSet<FAR_PAGO_PLANILLA>();
            this.FAR_TRASLADO = new HashSet<FAR_TRASLADO>();
            this.FAR_USUARIO = new HashSet<FAR_USUARIO>();
        }

        [Display(Name = "EMPLEADO")]
        public decimal CODIGO_EMP { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string NOMBRES { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string APELLIDOS { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<System.DateTime> FECHA_NAC { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DPI { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DIRECCION { get; set; }
        public string nombreCompleto
        {
            get { return (NOMBRES + " " + APELLIDOS); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_EMP_SUC> FAR_EMP_SUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_PAGO_PLANILLA> FAR_PAGO_PLANILLA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_TRASLADO> FAR_TRASLADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_USUARIO> FAR_USUARIO { get; set; }
    }
}
