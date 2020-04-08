
namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAR_CLIENTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAR_CLIENTE()
        {
            this.FAR_VENTA = new HashSet<FAR_VENTA>();
        }

        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string NIT { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string NOMBRES { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string APELLIDOS { get; set; }
        [Required(ErrorMessage = "{0} CAMPO REQUERIDO")]
        public string DIRECCION { get; set; }
        public string nombreCompleto
        {
            get { return (NOMBRES+" "+APELLIDOS); }
        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAR_VENTA> FAR_VENTA { get; set; }
    }
}
