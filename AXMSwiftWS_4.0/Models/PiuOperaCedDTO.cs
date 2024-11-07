using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class PiuOperaCedDTO
    {
        private string cuenta_cliente1;

        public string cuenta_cliente
        {
            get
            {
                return cuenta_cliente1;
            }
            set
            {
                cuenta_cliente1 = value;
            }
        }

        public string entidad_origen { get; set; }
        public string centro_origen { get; set; }
        public string usuario_origen { get; set; }
        public string netname_origen { get; set; }
        public string codigo_operacion { get; set; }
        public string importe_operacion { get; set; }
        public string fecha_operacion { get; set; }
        public string hora_operacion { get; set; }
        public string fecha_contable { get; set; }
        public string tipo_cambio { get; set; }
        public string indicador_retencion { get; set; }
        public string numero_retencion { get; set; }
        public string importe_retencion { get; set; }
        public string numero_anulacion { get; set; }
        public string indicador_origen_ope { get; set; }
        public string divisa { get; set; }
        public string observaciones { get; set; }
        public string referencia_interna { get; set; }
        public string fecha_valor { get; set; }
        public string referencia_traspaso { get; set; }
        public string indicadores { get; set; }
        public int ficha_ced { get; set; }
        public string codigo_error { get; set; }
        public string desc1_error { get; set; }
        public string desc2_error { get; set; }
        public string saldo { get; set; }
        public string numero_movimiento { get; set; }
        public string operacion_piu { get; set; }
        public string producto_contratado { get; set; }

        public PiuOperaCedDTO()
        {

        }


    }
}