﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AXMSwiftWS_4._0.Business
{
    public class Log
    {
        public static bool EscribeLog;
        public static string RutaLog;
        public static Exception error;

        public static void Escribe(string vData, string tipo = "Mensaje")
        {
            try
            {
                if (!Directory.Exists(RutaLog))
                {
                    Directory.CreateDirectory(RutaLog);
                }

                StackTrace trace = new StackTrace(StackTrace.METHODS_TO_SKIP + 2);
                StackFrame frame = trace.GetFrame(0);
                MethodBase caller = frame.GetMethod();

                string clase = "AXMSwiftWS";
                string funcion = caller.Name;
                //clase = "";

                string nombre_archivo = DateTime.Now.ToString("ddMMyyyy") + "-" + clase + ".log";


                if (EscribeLog)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(RutaLog, nombre_archivo), append: true))
                    {
                        vData = $"[{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}]  {tipo} desde {funcion}:  {vData}";
                        outputFile.WriteLine(vData);
                    }

                }
            }
            catch (IOException ex)
            {
                error = ex;
            }

        }

        public static void Escribe(Exception ex, string tipo = "Error")
        {
            try
            {
                if (!Directory.Exists(RutaLog))
                {
                    Directory.CreateDirectory(RutaLog);
                }

                StackTrace trace = new StackTrace(StackTrace.METHODS_TO_SKIP + 2);
                StackFrame frame = trace.GetFrame(0);
                MethodBase caller = frame.GetMethod();

                string clase = caller.ReflectedType.Name;
                string funcion = caller.Name;
                string vData = "";
                //clase = "";

                string nombre_archivo = DateTime.Now.ToString("ddMMyyyy") + "-" + clase + ".log";

                if (EscribeLog)
                {
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(RutaLog, nombre_archivo), append: true))
                    {
                        vData = $"[{DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss")}] {(char)13}" +
                            $"*{tipo} desde {funcion}:  {ex.Message} {(char)13}" +
                            $"*InnerException: {ex.InnerException} {(char)13}" +
                            $"*Source: {ex.Source}  {(char)13}" +
                            $"*Data: {ex.Data}  {(char)13}" +
                            $"*HelpLink: {ex.HelpLink}  {(char)13}" +
                            $"*StackTrace: {ex.StackTrace}  {(char)13}" +
                            //$"*HResult: {ex.HResult}  {(char)13}" +
                            $"*TargetSite: {ex.TargetSite}  {(char)13}";
                        outputFile.WriteLine(vData);
                    }

                }
            }
            catch (IOException e)
            {
                error = e;
            }

        }


    }
}
