using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class SenderHeader
    {
        public string lsB1_Indentificador { get; set; }
        public string lsB1_Identificador_Aplic { get; set; }
        public string lsB1_Identificador_Serv { get; set; }
        public string lsB1_Direccion_Swift { get; set; }
        public string lsB1_Ind_Aplicacion { get; set; }
        public string lsB1_Branch_Code { get; set; }
        public string lsB2_Identificador { get; set; }
        public string lsB2_Identificador_io { get; set; }
        public string lsB2_Tipo_Mensaje { get; set; }
        public string lsB2_Direccion_Swift { get; set; }
        public string lsB2_Ind_Aplicacion { get; set; }
        public string lsB2_Branch_Code { get; set; }
        public string lsB2_Prioridad { get; set; }
        public string lsB3_Identificador { get; set; }
        public string lsB3_Tipo_Mensaje { get; set; }
        public string lsB3_Texto { get; set; }
        public string lsB4_Identificador { get; set; }
        public string numero_movimiento { get; set; }

    }
}