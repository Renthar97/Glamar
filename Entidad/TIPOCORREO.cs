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
    
    public partial class TIPOCORREO
    {
        public int TipoCorreoId { get; set; }
        public int CorreoId { get; set; }
        public string TipoCorreo1 { get; set; }
    
        public virtual CORREO CORREO { get; set; }
    }
}
