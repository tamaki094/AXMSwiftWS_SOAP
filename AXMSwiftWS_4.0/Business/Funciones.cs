using AXMSwiftWS_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AXMSwiftWS_4._0.Business
{
    public static class Funciones
    {
        public static SenderHeader GetSendHeader(string senderHeader)
        {
            ////OPCION 1
            //string temporal = senderHeader.Replace('{', ' ').Replace('}', ' ').Replace('$', ' ');
            //temporal = temporal.Replace(": ", ":");
            //temporal = temporal.Replace("  ", " ");
            //temporal = temporal.Trim();
            //string[] bloques = temporal.Split(' ');

            //OPCION 2

            SenderHeader cabecera = new SenderHeader();

            cabecera.lsB1_Indentificador = senderHeader.Substring(2, 1);
            cabecera.lsB1_Identificador_Aplic = senderHeader.Substring(4, 1);
            cabecera.lsB1_Identificador_Serv = senderHeader.Substring(5, 2);
            cabecera.lsB1_Direccion_Swift = senderHeader.Substring(7, 8);
            cabecera.lsB1_Ind_Aplicacion = senderHeader.Substring(15, 1);
            cabecera.lsB1_Branch_Code = senderHeader.Substring(16, 3);
            cabecera.lsB2_Identificador = senderHeader.Substring(31, 1);
            cabecera.lsB2_Identificador_io = senderHeader.Substring(33, 1);
            cabecera.lsB2_Tipo_Mensaje = senderHeader.Substring(34, 3);
            cabecera.lsB2_Direccion_Swift = senderHeader.Substring(37, 8);
            cabecera.lsB2_Ind_Aplicacion = senderHeader.Substring(45, 1);
            cabecera.lsB2_Branch_Code = senderHeader.Substring(46, 3);
            cabecera.lsB2_Prioridad = senderHeader.Substring(49, 1);
            cabecera.lsB3_Identificador = senderHeader.Substring(52, 1);
            cabecera.lsB3_Tipo_Mensaje = senderHeader.Substring(55, 3);
            cabecera.lsB3_Texto = senderHeader.Substring(59, 16);
            cabecera.lsB4_Identificador = senderHeader.Substring(120, 1);
            cabecera.numero_movimiento = senderHeader.Substring(68, 7);


            return cabecera;
        }

        public static string GetFecha(string cadena)
        {
            if (cadena.Contains("T"))
            {
                string fecha = cadena.Substring(1, 6);
                return "20" + fecha;
            }
            else
            {
                string fecha = cadena.Substring(0, 6);
                return "20" + fecha;
            }
        }

        public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}