using AXMSwiftWS_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AXMSwiftWS_SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMT103Service" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMT103Service
    {
        [OperationContract]
        [WebGet]   
        IEnumerable<OPERACION> GetOperaciones();

        [OperationContract]
        [WebGet]     
        TKEResponse SendMessageDeliverySwift(TransfInternacionalDTO param);

        [OperationContract]
        [FaultContract(typeof(AXMException))]
        [WebGet]      
        StatusMT103Request GetStatusMessageSwift(StatusMT103Request param);

    }
}
