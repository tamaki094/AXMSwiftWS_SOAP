//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AXMSwiftWS_4._0.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPOSITO_DIRECTO
    {
        public int operacion { get; set; }
        public string referencia { get; set; }
        public string narrativa1 { get; set; }
        public string narrativa2 { get; set; }
        public string narrativa3 { get; set; }
        public string narrativa4 { get; set; }
        public Nullable<int> tipo_movimiento { get; set; }
        public string grupo_usuario { get; set; }
        public Nullable<int> numero_secuencia { get; set; }
    
        public virtual OPERACION OPERACION1 { get; set; }
    }
}
