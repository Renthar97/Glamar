//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidad
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOCUMENTO
    {
        public int DocumentoId { get; set; }
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public string tipo { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        public virtual VENTA VENTA { get; set; }
    }
}
