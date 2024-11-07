using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class IEnumerableResponse
    {

        public int Resultados { get; set; }
        public IEnumerable<object> Listado { get; set; }
    }
}
