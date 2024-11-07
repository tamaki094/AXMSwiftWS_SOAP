using AXMSwiftWS_4._0.Business;
using AXMSwiftWS_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Routing;

namespace AXMSwiftWS_SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MT103Service" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MT103Service.svc o MT103Service.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MT103Service : IMT103Service
    {

        TransfInternacionalDAO dao;
        public MT103Service()
        {
            Log.RutaLog = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs");
            Log.EscribeLog = true;
            Log.Escribe("Inicia WS");

            dao = new TransfInternacionalDAO();

            //RouteTable.Routes.Add(new ServiceRoute("mysvc", new WebServiceHostFactory(), typeof(MT103Service)));

        }

        //[OperationContract]
        //[FaultContract(typeof(AXMException))]
        public IEnumerable<OPERACION> GetOperaciones()
        {
            List<OPERACION> operaciones = new List<OPERACION>();
            try
            {
                Log.Escribe("Se hace una peticion GetOperaciones()");
                operaciones = dao.OperacionesByFecha(new DateTime(2024, 1, 1), new DateTime(2024, 12, 1));
            }
            catch (Exception ex)
            {
                Log.Escribe(ex);
            }
           
            return operaciones;
        }

        //[OperationContract]
        //[FaultContract(typeof(AXMException))]
        public TKEResponse SendMessageDeliverySwift(TransfInternacionalDTO param)
        {
            AXMException aex;

            try
            {
                Log.Escribe("Se hace una peticion SendMessageDeliverySwift()");

                if (param.amountInformation.Contains(DateTime.Now.ToString("yyMMdd")))
                {
                    int ticket_apx = Int32.Parse(param.accountHeader.Substring(9, 7));

                    if (!dao.ConsultaHomologacionAPXDIST(ticket_apx))
                    {
                        var respuesta = dao.GuardarTransferencia(param, Funciones.GetSendHeader(param.senderHeader));
                        return new TKEResponse(respuesta.code, respuesta.message);
                    }
                    else
                    {
                        aex = new AXMException("-1", "El ticket APX ya fue usado");
                        throw new FaultException<AXMException>(aex, aex.errormessage);
                    }


                }
                else
                {
                    aex = new AXMException("-1", "La fecha de la operacion no es de hoy");
                    throw new FaultException<AXMException>(aex, aex.errormessage);
                }
            }
            catch (Exception ex)
            {
                aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }
        }

        public StatusMT103Request GetStatusMessageSwift(StatusMT103Request param)
        {
            AXMException aex;
            try
            {

                foreach (Tickets ticket in param.tickets)
                {
                    if (ticket.id.ToString().Length < 7)
                    {
                        aex = new AXMException("-1", $"Formato del ticket {ticket.id} incorrecto");
                        throw new FaultException<AXMException>(aex, aex.errormessage);
                    }
                }

                Log.Escribe("Se hace una peticion GetStatusMessageSwift()");

                param = dao.ObtenerStatusOperaciones(param);

                return param;
            }
            catch (Exception ex)
            {
                aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }
             
         }  
    }
}
