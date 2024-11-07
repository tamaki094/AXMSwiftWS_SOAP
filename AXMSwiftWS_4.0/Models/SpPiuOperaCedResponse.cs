using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class SpPiuOperaCedResponse
    {
        public string Codigo { get; set; }
        public string Mensaje1 { get; set; }
        public string Mensaje2 { get; set; }
        public string Saldo { get; set; }
        public string Ticket { get; set; }
        public string Numero { get; set; }

        public override string ToString()
        {
            return $@"
             Codigo => {Codigo}
             Mensaje1 => {Mensaje1}
             Mensaje2 => {Mensaje2}
             Saldo => {Saldo}
             Ticket => {Ticket}
             Numero => {Numero}
            ";
        }

    }
}