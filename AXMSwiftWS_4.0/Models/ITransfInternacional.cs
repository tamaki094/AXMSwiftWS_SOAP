using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public interface ITransfInternacional
    {
        TKEResponse GuardarTransferencia(TransfInternacionalDTO p1, SenderHeader p2);
        StatusMT103Request ObtenerStatusOperaciones(StatusMT103Request value);
        List<OPERACION> OperacionesByFecha(DateTime fechai, DateTime fechaf);
    }
}