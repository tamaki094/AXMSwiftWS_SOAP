using AXMSwiftWS_4._0.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AXMSwiftWS_4._0.Models
{
    public class TransfInternacionalDAO : ITransfInternacional
    {
        public TKEResponse GuardarTransferencia(TransfInternacionalDTO transf, SenderHeader senderHeader)
        {
            try
            {
                SpPiuOperaCedResponse response1 = new SpPiuOperaCedResponse();
                SpPiuOperaCedResponse response2 = new SpPiuOperaCedResponse();
                SpPiuGenRetiroMT103Response respone3 = new SpPiuGenRetiroMT103Response();


                using (TICKETEntities contexto = new TICKETEntities())
                {
                    string cnn = contexto.Database.Connection.ConnectionString;

                    using (SqlConnection sqlcon = new SqlConnection(cnn))
                    {
                        PARAMETRIZACION param_ficha_ced = contexto.PARAMETRIZACION.Where(w => w.codigo == "CED_CONSECUTIVO").FirstOrDefault();
                        int ficha_ced = Int32.Parse(param_ficha_ced.valor) + 1;

                        PiuOperaCedDTO operacion = new PiuOperaCedDTO
                        {

                            cuenta_cliente = transf.senderAccount,
                            entidad_origen = ConfigurationManager.AppSettings["LsEntidad_Origen"],
                            centro_origen = ConfigurationManager.AppSettings["LsCentro_Origen"],
                            usuario_origen = ConfigurationManager.AppSettings["LsUsuario_Origen"],
                            netname_origen = ConfigurationManager.AppSettings["LsNetname_Origen"],
                            codigo_operacion = ConfigurationManager.AppSettings["LsCodigo_Operacion"],
                            fecha_operacion = Funciones.GetFecha(transf.accountHeader),
                            hora_operacion = DateTime.Now.ToString("hhmm"),
                            fecha_contable = Funciones.GetFecha(transf.accountHeader),
                            tipo_cambio = ConfigurationManager.AppSettings["LsTipo_Cambio"],
                            indicador_retencion = ConfigurationManager.AppSettings["LsIndicador_Retencion"],
                            numero_retencion = ConfigurationManager.AppSettings["LsNumero_Retencion"],
                            importe_retencion = ConfigurationManager.AppSettings["LsImporte_Retencion"],
                            numero_anulacion = ConfigurationManager.AppSettings["LsNumero_Anulacion"],
                            indicador_origen_ope = ConfigurationManager.AppSettings["LsIndicador_Origen_Ope"],
                            divisa = "USD",
                            observaciones = "                          USDMB90784 E02",
                            referencia_interna = ConfigurationManager.AppSettings["LsReferencia_Interna"],
                            fecha_valor = Funciones.GetFecha(transf.amountInformation),
                            referencia_traspaso = ConfigurationManager.AppSettings["LsReferencia_Traspaso"],
                            indicadores = ConfigurationManager.AppSettings["LsIndicadores"],
                            ficha_ced = ficha_ced,
                            codigo_error = ConfigurationManager.AppSettings["LsCodigo_Error"],
                            desc1_error = ConfigurationManager.AppSettings["LsDesc1_Error"],
                            desc2_error = ConfigurationManager.AppSettings["LsDesc2_Error"],
                            saldo = ConfigurationManager.AppSettings["LsSaldo"],
                            numero_movimiento = ConfigurationManager.AppSettings["LsNumero_Movimiento"],
                            operacion_piu = ConfigurationManager.AppSettings["LsOperacion_Piu"],
                            producto_contratado = "",
                        };


                        sqlcon.Open();
                        SqlCommand cmd1 = new SqlCommand("sp_piu_opera_ced", sqlcon);

                        //Primer Ejecucion
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@LsCuenta_Cliente", SqlDbType.NVarChar).Value = operacion.cuenta_cliente;
                        cmd1.Parameters.AddWithValue("@LsEntidad_Origen", SqlDbType.NVarChar).Value = operacion.entidad_origen;
                        cmd1.Parameters.AddWithValue("@LsCentro_Origen", SqlDbType.NVarChar).Value = operacion.centro_origen;
                        cmd1.Parameters.AddWithValue("@LsUsuario_Origen", SqlDbType.NVarChar).Value = operacion.usuario_origen;
                        cmd1.Parameters.AddWithValue("@LsNetname_Origen", SqlDbType.NVarChar).Value = operacion.netname_origen;
                        cmd1.Parameters.AddWithValue("@LsCodigo_Operacion", SqlDbType.NVarChar).Value = operacion.codigo_operacion;
                        operacion.importe_operacion = "-" + transf.amountInformation.Replace(" ", "").Substring(9, 14);
                        cmd1.Parameters.AddWithValue("@LsImporte_Operacion", SqlDbType.NVarChar).Value = operacion.importe_operacion;
                        cmd1.Parameters.AddWithValue("@LsFecha_Operacion", SqlDbType.NVarChar).Value = operacion.fecha_operacion;
                        cmd1.Parameters.AddWithValue("@LsHora_Operacion", SqlDbType.NVarChar).Value = operacion.hora_operacion;
                        cmd1.Parameters.AddWithValue("@LsFecha_Contable", SqlDbType.NVarChar).Value = operacion.fecha_contable;
                        cmd1.Parameters.AddWithValue("@LsTipo_Cambio", SqlDbType.NVarChar).Value = operacion.tipo_cambio;
                        cmd1.Parameters.AddWithValue("@LsIndicador_Retencion", SqlDbType.NVarChar).Value = operacion.indicador_retencion;
                        cmd1.Parameters.AddWithValue("@LsNumero_Retencion", SqlDbType.NVarChar).Value = operacion.numero_retencion;
                        cmd1.Parameters.AddWithValue("@LsImporte_Retencion", SqlDbType.NVarChar).Value = operacion.importe_retencion;
                        cmd1.Parameters.AddWithValue("@LsNumero_Anulacion", SqlDbType.NVarChar).Value = operacion.numero_anulacion;
                        cmd1.Parameters.AddWithValue("@LsIndicador_Origen_Ope", SqlDbType.NVarChar).Value = operacion.indicador_origen_ope;
                        cmd1.Parameters.AddWithValue("@LsDivisa", SqlDbType.NVarChar).Value = operacion.divisa;
                        cmd1.Parameters.AddWithValue("@LsObservaciones", SqlDbType.NVarChar).Value = operacion.observaciones;
                        cmd1.Parameters.AddWithValue("@LsReferencia_Interna", SqlDbType.NVarChar).Value = operacion.referencia_interna;
                        cmd1.Parameters.AddWithValue("@LsFecha_Valor", SqlDbType.NVarChar).Value = operacion.fecha_valor;
                        cmd1.Parameters.AddWithValue("@LsReferencia_Traspaso", SqlDbType.NVarChar).Value = operacion.referencia_traspaso;
                        cmd1.Parameters.AddWithValue("@LsIndicadores", SqlDbType.NVarChar).Value = operacion.indicadores;
                        cmd1.Parameters.AddWithValue("@LsFicha_Ced", SqlDbType.NVarChar).Value = operacion.ficha_ced;
                        cmd1.Parameters.AddWithValue("@LsCodigo_Error", SqlDbType.NVarChar).Value = operacion.codigo_error;
                        cmd1.Parameters.AddWithValue("@LsDesc1_Error", SqlDbType.NVarChar).Value = operacion.desc1_error;
                        cmd1.Parameters.AddWithValue("@LsDesc2_Error", SqlDbType.NVarChar).Value = operacion.desc2_error;
                        cmd1.Parameters.AddWithValue("@LsSaldo", SqlDbType.NVarChar).Value = operacion.saldo;
                        cmd1.Parameters.AddWithValue("@LsNumero_Movimiento", SqlDbType.NVarChar).Value = operacion.numero_movimiento;
                        cmd1.Parameters.AddWithValue("@LsOperacion_Piu", SqlDbType.NVarChar).Value = operacion.operacion_piu;
                        cmd1.Parameters.AddWithValue("@LsProducto_Contratado", SqlDbType.NVarChar).Value = operacion.producto_contratado;

                        Log.Escribe("Primera ejecucion sp_piu_opera_ced");
                        Log.Escribe($"EXEC TICKET..sp_piu_opera_ced '{operacion.cuenta_cliente}', '{operacion.entidad_origen}', '{operacion.centro_origen}', '{operacion.usuario_origen}  ', '{operacion.netname_origen}', '{operacion.codigo_operacion}', '{operacion.importe_operacion}', '{operacion.fecha_operacion}', '{operacion.hora_operacion}', '{operacion.fecha_contable}', '{operacion.tipo_cambio}', '{operacion.indicador_retencion}', '{operacion.numero_retencion}', '{operacion.importe_retencion}', '{operacion.numero_anulacion}', '{operacion.indicador_origen_ope}', '{operacion.divisa}', '{operacion.observaciones}', '{operacion.referencia_interna}', '{operacion.fecha_valor}', '{operacion.referencia_traspaso}', '{operacion.indicadores}', '{operacion.ficha_ced}', '{operacion.codigo_error}', '{operacion.desc1_error}', '{operacion.desc2_error}', ' {operacion.saldo}', '{operacion.numero_movimiento}', '{operacion.operacion_piu}', '{operacion.producto_contratado}'");

                        var result1 = cmd1.ExecuteReader();


                        param_ficha_ced.valor = (operacion.ficha_ced + 1).ToString();
                        contexto.SaveChanges();

                        if (result1.FieldCount >= 6)
                        {
                            while (result1.Read())
                            {
                                response1.Codigo = result1[0].ToString();
                                response1.Mensaje1 = result1[1].ToString();
                                response1.Mensaje2 = result1[2].ToString();
                                response1.Saldo = result1[3].ToString();
                                response1.Ticket = result1[4].ToString();
                                response1.Numero = result1[5].ToString();
                            }

                            if (!response1.Codigo.Contains("TKA0000"))
                            {
                                throw new TKEException(response1.Codigo, $"{response1.Mensaje1} {response1.Mensaje2}");
                            }

                            Log.Escribe(response1.ToString());

                            result1.Close();

                            SqlCommand cmd2 = new SqlCommand("sp_piu_opera_ced", sqlcon);

                            //Segunda Ejecucion
                            operacion.indicador_retencion = "3";

                            cmd2.CommandType = CommandType.StoredProcedure;
                            cmd2.Parameters.AddWithValue("@LsCuenta_Cliente", SqlDbType.NVarChar).Value = operacion.cuenta_cliente;
                            cmd2.Parameters.AddWithValue("@LsEntidad_Origen", SqlDbType.NVarChar).Value = operacion.entidad_origen;
                            cmd2.Parameters.AddWithValue("@LsCentro_Origen", SqlDbType.NVarChar).Value = operacion.centro_origen;
                            cmd2.Parameters.AddWithValue("@LsUsuario_Origen", SqlDbType.NVarChar).Value = operacion.usuario_origen;
                            cmd2.Parameters.AddWithValue("@LsNetname_Origen", SqlDbType.NVarChar).Value = operacion.netname_origen;
                            cmd2.Parameters.AddWithValue("@LsCodigo_Operacion", SqlDbType.NVarChar).Value = operacion.codigo_operacion;
                            operacion.importe_operacion = "-" + transf.amountInformation.Replace(" ", "").Substring(9, 14);
                            cmd2.Parameters.AddWithValue("@LsImporte_Operacion", SqlDbType.NVarChar).Value = operacion.importe_operacion;
                            cmd2.Parameters.AddWithValue("@LsFecha_Operacion", SqlDbType.NVarChar).Value = operacion.fecha_operacion;
                            cmd2.Parameters.AddWithValue("@LsHora_Operacion", SqlDbType.NVarChar).Value = operacion.hora_operacion;
                            cmd2.Parameters.AddWithValue("@LsFecha_Contable", SqlDbType.NVarChar).Value = operacion.fecha_contable;
                            cmd2.Parameters.AddWithValue("@LsTipo_Cambio", SqlDbType.NVarChar).Value = operacion.tipo_cambio;
                            cmd2.Parameters.AddWithValue("@LsIndicador_Retencion", SqlDbType.NVarChar).Value = operacion.indicador_retencion;
                            cmd2.Parameters.AddWithValue("@LsNumero_Retencion", SqlDbType.NVarChar).Value = operacion.numero_retencion;
                            cmd2.Parameters.AddWithValue("@LsImporte_Retencion", SqlDbType.NVarChar).Value = operacion.importe_retencion;
                            cmd2.Parameters.AddWithValue("@LsNumero_Anulacion", SqlDbType.NVarChar).Value = response1.Ticket;
                            cmd2.Parameters.AddWithValue("@LsIndicador_Origen_Ope", SqlDbType.NVarChar).Value = operacion.indicador_origen_ope;
                            cmd2.Parameters.AddWithValue("@LsDivisa", SqlDbType.NVarChar).Value = operacion.divisa;
                            cmd2.Parameters.AddWithValue("@LsObservaciones", SqlDbType.NVarChar).Value = operacion.observaciones;
                            cmd2.Parameters.AddWithValue("@LsReferencia_Interna", SqlDbType.NVarChar).Value = operacion.referencia_interna;
                            cmd2.Parameters.AddWithValue("@LsFecha_Valor", SqlDbType.NVarChar).Value = operacion.fecha_valor;
                            cmd2.Parameters.AddWithValue("@LsReferencia_Traspaso", SqlDbType.NVarChar).Value = operacion.referencia_traspaso;
                            cmd2.Parameters.AddWithValue("@LsIndicadores", SqlDbType.NVarChar).Value = operacion.indicadores;
                            cmd2.Parameters.AddWithValue("@LsFicha_Ced", SqlDbType.NVarChar).Value = operacion.ficha_ced;
                            cmd2.Parameters.AddWithValue("@LsCodigo_Error", SqlDbType.NVarChar).Value = operacion.codigo_error;
                            cmd2.Parameters.AddWithValue("@LsDesc1_Error", SqlDbType.NVarChar).Value = operacion.desc1_error;
                            cmd2.Parameters.AddWithValue("@LsDesc2_Error", SqlDbType.NVarChar).Value = operacion.desc2_error;
                            cmd2.Parameters.AddWithValue("@LsSaldo", SqlDbType.NVarChar).Value = response1.Saldo;
                            cmd2.Parameters.AddWithValue("@LsNumero_Movimiento", SqlDbType.NVarChar).Value = response1.Ticket;
                            cmd2.Parameters.AddWithValue("@LsOperacion_Piu", SqlDbType.NVarChar).Value = operacion.operacion_piu;
                            cmd2.Parameters.AddWithValue("@LsProducto_Contratado", SqlDbType.NVarChar).Value = operacion.producto_contratado;

                            Log.Escribe("Segunda ejecucion sp_piu_opera_ced");
                            Log.Escribe($"EXEC TICKET..sp_piu_opera_ced '{operacion.cuenta_cliente}', '{operacion.entidad_origen}', '{operacion.centro_origen}', '{operacion.usuario_origen}  ', '{operacion.netname_origen}', '{operacion.codigo_operacion}', '{operacion.importe_operacion}', '{operacion.fecha_operacion}', '{operacion.hora_operacion}', '{operacion.fecha_contable}', '{operacion.tipo_cambio}', '{operacion.indicador_retencion}', '{operacion.numero_retencion}', '{operacion.importe_retencion}', '{response1.Ticket}', '{operacion.indicador_origen_ope}', '{operacion.divisa}', '{operacion.observaciones}', '{operacion.referencia_interna}', '{operacion.fecha_valor}', '{operacion.referencia_traspaso}', '{operacion.indicadores}', '{operacion.ficha_ced}', '{operacion.codigo_error}', '{operacion.desc1_error}', '{operacion.desc2_error}', ' {response1.Saldo}', '{response1.Ticket}', '{operacion.operacion_piu}', '{operacion.producto_contratado}'");


                            var result2 = cmd2.ExecuteReader();


                            if (result2.FieldCount >= 6)
                            {
                                while (result2.Read())
                                {
                                    response2.Codigo = result2[0].ToString();
                                    response2.Mensaje1 = result2[1].ToString();
                                    response2.Mensaje2 = result2[2].ToString();
                                    response2.Saldo = result2[3].ToString();
                                    response2.Ticket = result2[4].ToString();
                                    response2.Numero = result2[5].ToString();
                                }

                                if (!response2.Codigo.Contains("TKA0000"))
                                {
                                    throw new TKEException(response2.Codigo, $"{response2.Mensaje1} {response2.Mensaje2}");
                                }



                                result2.Close();

                                Log.Escribe(response2.ToString());

                                PiuGenRetiroMT103DTO mt103 = new PiuGenRetiroMT103DTO
                                {
                                    LsB4_Campo_53d_Opt1 = ConfigurationManager.AppSettings["LsB4_Campo_53d_Opt1"],
                                    LsB4_Campo_53d_Desc2 = ConfigurationManager.AppSettings["LsB4_Campo_53d_Desc2"],
                                    LsB4_Campo_53d_Desc3 = ConfigurationManager.AppSettings["LsB4_Campo_53d_Desc3"],
                                    LsB4_Campo_53d_Desc4 = ConfigurationManager.AppSettings["LsB4_Campo_53d_Desc4"],
                                    LsB4_Campo_56d_Opt1 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Opt1"],
                                    LsB4_Campo_56d_Opt2 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Opt2"],
                                    LsB4_Campo_56d_Desc1 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Desc1"],
                                    LsB4_Campo_56d_Desc2 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Desc2"],
                                    LsB4_Campo_56d_Desc3 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Desc3"],
                                    LsB4_Campo_56d_Desc4 = ConfigurationManager.AppSettings["LsB4_Campo_56d_Desc4"],
                                    LsB4_Campo_57d_Opt1 = ConfigurationManager.AppSettings["LsB4_Campo_57d_Opt1"],
                                    LsB4_Campo_57d_Desc3 = ConfigurationManager.AppSettings["LsB4_Campo_57d_Desc3"],
                                    LsB4_Campo_57d_Desc4 = ConfigurationManager.AppSettings["LsB4_Campo_57d_Desc4"],
                                    LsB4_Campo_59_Filler = ConfigurationManager.AppSettings["LsB4_Campo_59_Filler"],
                                    LsB4_Campo_70_Ref3 = ConfigurationManager.AppSettings["LsB4_Campo_70_Ref3"],
                                    LsB4_Campo_70_Ref4 = ConfigurationManager.AppSettings["LsB4_Campo_70_Ref4"]
                                };


                                SqlCommand cmd3 = new SqlCommand("sp_piu_gen_retiro_MT103", sqlcon);
                                cmd3.CommandType = CommandType.StoredProcedure;
                                cmd3.Parameters.AddWithValue("@LsNumero_Movimiento", SqlDbType.NVarChar).Value = response1.Ticket;//senderHeader.numero_movimiento;
                                cmd3.Parameters.AddWithValue("@LsB1_Indentificador", SqlDbType.NVarChar).Value = senderHeader.lsB1_Indentificador;
                                cmd3.Parameters.AddWithValue("@LsB1_Identificador_Aplic", SqlDbType.NVarChar).Value = senderHeader.lsB1_Identificador_Aplic;
                                cmd3.Parameters.AddWithValue("@LsB1_Identificador_Serv", SqlDbType.NVarChar).Value = senderHeader.lsB1_Identificador_Serv;
                                cmd3.Parameters.AddWithValue("@LsB1_Direccion_Swift", SqlDbType.NVarChar).Value = senderHeader.lsB1_Direccion_Swift;
                                cmd3.Parameters.AddWithValue("@LsB1_Ind_Aplicacion", SqlDbType.NVarChar).Value = senderHeader.lsB1_Ind_Aplicacion;
                                cmd3.Parameters.AddWithValue("@LsB1_Branch_Code", SqlDbType.NVarChar).Value = senderHeader.lsB1_Branch_Code;
                                cmd3.Parameters.AddWithValue("@LsB2_Identificador", SqlDbType.NVarChar).Value = senderHeader.lsB2_Identificador;
                                cmd3.Parameters.AddWithValue("@LsB2_Identificador_io", SqlDbType.NVarChar).Value = senderHeader.lsB2_Identificador_io;
                                cmd3.Parameters.AddWithValue("@LsB2_Tipo_Mensaje", SqlDbType.NVarChar).Value = senderHeader.lsB2_Tipo_Mensaje;
                                cmd3.Parameters.AddWithValue("@LsB2_Direccion_Swift", SqlDbType.NVarChar).Value = senderHeader.lsB2_Direccion_Swift;
                                cmd3.Parameters.AddWithValue("@LsB2_Ind_Aplicacion", SqlDbType.NVarChar).Value = senderHeader.lsB2_Ind_Aplicacion;
                                cmd3.Parameters.AddWithValue("@LsB2_Branch_Code", SqlDbType.NVarChar).Value = senderHeader.lsB2_Branch_Code;
                                cmd3.Parameters.AddWithValue("@LsB2_Prioridad", SqlDbType.NVarChar).Value = senderHeader.lsB2_Prioridad;
                                cmd3.Parameters.AddWithValue("@LsB3_Identificador", SqlDbType.NVarChar).Value = senderHeader.lsB3_Identificador;
                                cmd3.Parameters.AddWithValue("@LsB3_Tipo_Mensaje", SqlDbType.NVarChar).Value = senderHeader.lsB3_Tipo_Mensaje;
                                cmd3.Parameters.AddWithValue("@LsB3_Texto", SqlDbType.NVarChar).Value = senderHeader.lsB3_Texto;
                                cmd3.Parameters.AddWithValue("@LsB4_Identificador", SqlDbType.NVarChar).Value = senderHeader.lsB4_Identificador;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_20", SqlDbType.NVarChar).Value = transf.accountHeader;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_23b", SqlDbType.NVarChar).Value = transf.bankOperationCode;
                                string fecha = transf.amountInformation.Substring(0, 6);
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_32a_Fecha", SqlDbType.NVarChar).Value = fecha;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_32a_Moneda", SqlDbType.NVarChar).Value = operacion.divisa;
                                operacion.importe_operacion = operacion.importe_operacion.Insert((operacion.importe_operacion.Length - 2), ",").Replace("-", "");
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_32a_Monto", SqlDbType.NVarChar).Value = operacion.importe_operacion;
                                string cuenta = transf.senderAccount.Insert(0, "/");
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_50k_Cuenta", SqlDbType.NVarChar).Value = cuenta;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_50k_Direc1", SqlDbType.NVarChar).Value = transf.senderName;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_50k_Direc2", SqlDbType.NVarChar).Value = transf.senderMainAddress;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_50k_Direc3", SqlDbType.NVarChar).Value = transf.senderAddressStreet;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_50k_Direc4", SqlDbType.NVarChar).Value = transf.senderAddressZone;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Opt1", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_53d_Opt1;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Opt2", SqlDbType.NVarChar).Value = transf.orderingAccount;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Desc1", SqlDbType.NVarChar).Value = transf.orderingName;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Desc2", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_53d_Desc2;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Desc3", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_53d_Desc3;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_53d_Desc4", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_53d_Desc4;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Opt1", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Opt1;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Opt2", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Opt2;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Desc1", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Desc1;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Desc2", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Desc2;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Desc3", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Desc3;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_56d_Desc4", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_56d_Desc4;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Opt1", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_57d_Opt1;
                                transf.correspondentBankId = transf.correspondentBankId.Insert(0, "/");
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Opt2", SqlDbType.NVarChar).Value = transf.correspondentBankId;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Desc1", SqlDbType.NVarChar).Value = transf.correspondentBankName;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Desc2", SqlDbType.NVarChar).Value = transf.correspondentBankLocation;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Desc3", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_57d_Desc3;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_57d_Desc4", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_57d_Desc4;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Filler", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_59_Filler;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Cta_Benef", SqlDbType.NVarChar).Value = transf.beneficiaryAccount;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Benef1", SqlDbType.NVarChar).Value = transf.beneficiaryName;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Benef2", SqlDbType.NVarChar).Value = transf.beneficiaryMainAddress;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Benef3", SqlDbType.NVarChar).Value = transf.beneficiaryAddressStreet;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_59_Benef4", SqlDbType.NVarChar).Value = transf.beneficiaryAddressZone;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_70_Ref1 ", SqlDbType.NVarChar).Value = transf.beneficiaryCity;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_70_Ref2 ", SqlDbType.NVarChar).Value = transf.senderShortName;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_70_Ref3 ", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_70_Ref3;
                                cmd3.Parameters.AddWithValue("@LsB4_Campo_70_Ref4 ", SqlDbType.NVarChar).Value = mt103.LsB4_Campo_70_Ref4;

                                Log.Escribe("Ejecucion sp_piu_gen_retiro_MT103");
                                Log.Escribe($"EXEC TICKET..sp_piu_gen_retiro_MT103 '{response1.Ticket}', '{senderHeader.lsB1_Indentificador}', '{senderHeader.lsB1_Identificador_Aplic}', '{senderHeader.lsB1_Identificador_Serv}  ', '{senderHeader.lsB1_Direccion_Swift}', '{senderHeader.lsB1_Ind_Aplicacion}', '{senderHeader.lsB1_Branch_Code}', '{senderHeader.lsB2_Identificador}', '{senderHeader.lsB2_Identificador_io}', '{senderHeader.lsB2_Tipo_Mensaje}', '{senderHeader.lsB2_Direccion_Swift}', '{senderHeader.lsB2_Ind_Aplicacion}', '{senderHeader.lsB2_Branch_Code}', '{senderHeader.lsB2_Prioridad}', '{senderHeader.lsB3_Identificador}', '{senderHeader.lsB3_Tipo_Mensaje}', '{senderHeader.lsB3_Texto}', '{senderHeader.lsB4_Identificador}', '{transf.accountHeader}', '{transf.bankOperationCode}', '{fecha}', '{operacion.divisa}', '{operacion.importe_operacion}', '{cuenta}', '{transf.senderName}', '{transf.senderMainAddress}', ' {transf.senderAddressStreet}', '{transf.senderAddressZone}', '{mt103.LsB4_Campo_53d_Opt1}', '{transf.orderingAccount}', '{transf.orderingName}', '{mt103.LsB4_Campo_53d_Desc2}', '{mt103.LsB4_Campo_53d_Desc3}', '{mt103.LsB4_Campo_53d_Desc4}', '{mt103.LsB4_Campo_56d_Opt1}', '{mt103.LsB4_Campo_56d_Opt2}', '{mt103.LsB4_Campo_56d_Desc1}', '{mt103.LsB4_Campo_56d_Desc2}', '{mt103.LsB4_Campo_56d_Desc3}', '{mt103.LsB4_Campo_56d_Desc4}', '{mt103.LsB4_Campo_57d_Opt1}', '{transf.correspondentBankId}', '{transf.correspondentBankName}', '{transf.correspondentBankLocation}', '{mt103.LsB4_Campo_57d_Desc3}', '{mt103.LsB4_Campo_57d_Desc4}', '{ mt103.LsB4_Campo_59_Filler}', '{transf.beneficiaryAccount}', '{ transf.beneficiaryName}' , '{ transf.beneficiaryMainAddress}' , '{transf.beneficiaryAddressStreet}' , '{transf.beneficiaryAddressZone}' , '{transf.beneficiaryCity}' , '{transf.senderShortName}' , '{mt103.LsB4_Campo_70_Ref3}' , '{mt103.LsB4_Campo_70_Ref4}';");


                                SqlCommand cmd4 = new SqlCommand("INSERT into TICKET..HOMOLOGACION_APX_DIST_PROD(TICKET_DIST, TICKET_APX) values(@TICKET_DIST, @TICKET_APX)", sqlcon);
                                cmd4.Parameters.AddWithValue("@TICKET_DIST", response1.Ticket);
                                string ticket_apx = transf.accountHeader.Substring(9, 7);
                                cmd4.Parameters.AddWithValue("@TICKET_APX", ticket_apx);
                                int insertado = cmd4.ExecuteNonQuery();

                                Log.Escribe("Ejecucion INSERT");
                                Log.Escribe($"INSERT into TICKET..HOMOLOGACION_APX_DIST_PROD(TICKET_DIST, TICKET_APX) values({response1.Ticket}, {response1.Ticket})");



                                var result3 = cmd3.ExecuteReader();

                                if (result3.FieldCount >= 3)
                                {
                                    while (result3.Read())
                                    {

                                        respone3.Codigo = result3[0].ToString();
                                        respone3.Mensaje1 = result3[1].ToString();
                                        respone3.Mensaje2 = result3[2].ToString();
                                        respone3.Saldo = result3[3].ToString();

                                    }

                                    if (!respone3.Codigo.Contains("TKA0000"))
                                    {
                                        throw new TKEException(respone3.Codigo, $"{respone3.Mensaje1} {respone3.Mensaje2}");
                                    }

                                    Log.Escribe(respone3.ToString());

                                    result3.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Error en el sp_piu_gen_retiro_MT103 - PRIMERA EJECUCION");
                                    throw new TKEException("-1", "Error en el sp_piu_gen_retiro_MT103 - PRIMERA EJECUCION");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error en el sp_piu_opera_ced - SEGUNDA EJECUCION");
                                throw new TKEException("-1", "Error en el sp_piu_opera_ced - SEGUNDA EJECUCION");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error en el sp_piu_opera_ced - PRIMERA EJECUCION");
                            throw new TKEException("-1", "Error en el sp_piu_opera_ced - PRIMERA EJECUCION");
                        }

                        sqlcon.Close();
                    }
                }
                return new TKEResponse(respone3.Codigo, respone3.Mensaje1 + " " + respone3.Mensaje2);

            }
            catch (TKEException ex)
            {
                AXMException aex = new AXMException(ex.errorcode, ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }
            catch (Exception ex)
            {
                AXMException aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }

        }



        public StatusMT103Request ObtenerStatusOperaciones(StatusMT103Request value)
        {
            try
            {
                string tickets = value.GetTickets();

                using (TICKETEntities contexto = new TICKETEntities())
                {
                    string cnn = contexto.Database.Connection.ConnectionString;

                    using (SqlConnection sqlcon = new SqlConnection(cnn))
                    {
                        string parametros = "";

                        int i = 1;
                        foreach (Tickets ticket in value.tickets)
                        {
                            parametros += "@ticket" + i.ToString() + ",";
                            i++;
                        }

                        parametros = parametros.Remove(parametros.Length - 1);

                        sqlcon.Open();
                        SqlCommand cmd1 = new SqlCommand($@"
                        SELECT 
                            hadp.TICKET_APX
                            , O.operacion
                            , O.status_operacion
                        FROM
                            TICKET.dbo.HOMOLOGACION_APX_DIST_PROD hadp
                        INNER JOIN

                            TICKET.dbo.OPERACION o ON hadp.TICKET_DIST = o.operacion
                        WHERE
                            hadp.TICKET_APX IN ({parametros})", sqlcon);

                        i = 1;
                        StringBuilder sb = new StringBuilder();
                        foreach (Tickets ticket in value.tickets)
                        {
                            //PAMATER
                            cmd1.Parameters.AddWithValue("@ticket" + i.ToString(), ticket.id);
                            i++;
                        }

                        cmd1.Parameters.AddWithValue("@TICKETS_APX", tickets);
                        SqlDataReader dr = cmd1.ExecuteReader();


                        while (dr.Read())
                        {
                            var ticket_apx = dr.GetInt32(0);
                            var ticket_e = dr.GetInt32(1);
                            var status = dr.GetByte(2);

                            string ack = (status == 4) ? "ACK" : "NO_ACK";
                            value.tickets.Where(w => w.id == ticket_apx).FirstOrDefault().ack = ack;
                        }
                        sqlcon.Close();
                    }
                   
                    return value;
                }
            }
            catch (Exception ex)
            {
                AXMException aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }

        }

        public List<OPERACION> OperacionesByFecha(DateTime fechai, DateTime fechaf)
        {
            try
            {
                using (TICKETEntities contexto = new TICKETEntities())
                {
                    contexto.Configuration.ProxyCreationEnabled = false;
                    return contexto.OPERACION.Where(w => w.fecha_captura >= fechai && w.fecha_captura <= fechaf).ToList();
                }
            }
            catch (Exception ex)
            {
                AXMException aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }
          
        }

        public bool ConsultaHomologacionAPXDIST(int ticket_apx)
        {
            try
            {
                using (TICKETEntities contexto = new TICKETEntities())
                {
                    string cnn = contexto.Database.Connection.ConnectionString;
                    using (SqlConnection sqlcon = new SqlConnection(cnn))
                    {
                        sqlcon.Open();
                        SqlCommand cmd1 = new SqlCommand($@"
                        SELECT 
                            hadp.TICKET_APX
                            , O.operacion
                            , O.status_operacion
                        FROM
                            TICKET.dbo.HOMOLOGACION_APX_DIST_PROD hadp
                        INNER JOIN

                            TICKET.dbo.OPERACION o ON hadp.TICKET_DIST = o.operacion
                        WHERE
                            hadp.TICKET_APX = @ticket_apx", sqlcon);

                        cmd1.Parameters.AddWithValue("@ticket_apx", ticket_apx);

                        SqlDataReader dr = cmd1.ExecuteReader();

                        return dr.HasRows;
                    }
                }
            }
            catch (Exception ex)
            {
                AXMException aex = new AXMException("-1", ex.Message);
                throw new FaultException<AXMException>(aex, aex.errormessage);
            }           
        }
    }
}