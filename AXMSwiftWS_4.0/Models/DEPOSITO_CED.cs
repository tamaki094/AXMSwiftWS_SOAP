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
    
    public partial class DEPOSITO_CED
    {
        public int operacion { get; set; }
        public string codigo_leyenda { get; set; }
        public string observaciones { get; set; }
        public string referencia { get; set; }
        public Nullable<decimal> tipo_cambio { get; set; }
        public string codigo_operacion { get; set; }
    
        public virtual OPERACION OPERACION1 { get; set; }
    }
}
