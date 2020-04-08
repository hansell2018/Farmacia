using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FARMACIA_SEMI.Models
{
    public class Det_Traslado
    {
        public string DESCRIPCION { get; set; }
        [Display(Name = "MEDIDA")]
        public string DES_MEDIDA { get; set; }
        public decimal SUBTOTAL { get; set; }
    }
}