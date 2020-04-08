
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_PLANILLA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_PLANILLA()
        {
            this.FAR_PAGO_PLANILLA = new HashSet<FAR_PAGO_PLANILLA>();
        }
    
        public decimal Id { get; set; }
        [Display(Name = "INICIO")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        [Display(Name = "FIN")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public Nullable<System.DateTime> FECHA_FIN { get; set; }
        public string duracion
        {
            get { return (FECHA_INICIO + " - " + FECHA_FIN); }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_PAGO_PLANILLA> FAR_PAGO_PLANILLA { get; set; }
    }
}
