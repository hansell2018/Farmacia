﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FARMACIA_SEMI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FARMACIAEntities : DbContext
    {
        public FARMACIAEntities()
            : base("name=FARMACIAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FAR_ARTICULO> FAR_ARTICULO { get; set; }
        public virtual DbSet<FAR_CAT_ARTICULO> FAR_CAT_ARTICULO { get; set; }
        public virtual DbSet<FAR_CLIENTE> FAR_CLIENTE { get; set; }
        public virtual DbSet<FAR_COMPRA> FAR_COMPRA { get; set; }
        public virtual DbSet<FAR_DET_TRASLADO> FAR_DET_TRASLADO { get; set; }
        public virtual DbSet<FAR_DETALLE_COMPRA> FAR_DETALLE_COMPRA { get; set; }
        public virtual DbSet<FAR_DETALLE_VENTA> FAR_DETALLE_VENTA { get; set; }
        public virtual DbSet<FAR_EMP_SUC> FAR_EMP_SUC { get; set; }
        public virtual DbSet<FAR_EMPLEADO> FAR_EMPLEADO { get; set; }
        public virtual DbSet<FAR_ESTATUS> FAR_ESTATUS { get; set; }
        public virtual DbSet<FAR_EXISTENCIA> FAR_EXISTENCIA { get; set; }
        public virtual DbSet<FAR_MARCA> FAR_MARCA { get; set; }
        public virtual DbSet<FAR_MOV_CAJA> FAR_MOV_CAJA { get; set; }
        public virtual DbSet<FAR_PAGO_PLANILLA> FAR_PAGO_PLANILLA { get; set; }
        public virtual DbSet<FAR_PROVEEDOR> FAR_PROVEEDOR { get; set; }
        public virtual DbSet<FAR_PUESTO> FAR_PUESTO { get; set; }
        public virtual DbSet<FAR_ROL> FAR_ROL { get; set; }
        public virtual DbSet<FAR_RUTA> FAR_RUTA { get; set; }
        public virtual DbSet<FAR_SUCURSAL> FAR_SUCURSAL { get; set; }
        public virtual DbSet<FAR_SUCURSAL_ACTIVO> FAR_SUCURSAL_ACTIVO { get; set; }
        public virtual DbSet<FAR_TIPO_PAGO> FAR_TIPO_PAGO { get; set; }
        public virtual DbSet<FAR_TRASLADO> FAR_TRASLADO { get; set; }
        public virtual DbSet<FAR_TTRANSACCION> FAR_TTRANSACCION { get; set; }
        public virtual DbSet<FAR_UNIDAD_MED> FAR_UNIDAD_MED { get; set; }
        public virtual DbSet<FAR_USUARIO> FAR_USUARIO { get; set; }
        public virtual DbSet<FAR_VENTA> FAR_VENTA { get; set; }
        public virtual DbSet<FAR_ZONA> FAR_ZONA { get; set; }
        public virtual DbSet<FAR_PLANILLA> FAR_PLANILLA { get; set; }
    }
}
