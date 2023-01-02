using System;
using System.Diagnostics;
using System.IO;

namespace Dominio.Aplicacion.Implementacion
{
    public static class LogErrores
    {
        public static void Escribir(string fecha, string Mensaje, string proyecto, string ruta, StackTrace trace)
        {
            string rutaArchivo = ruta;
            escribirenArchivo(rutaArchivo, string.Format("LogErrores_{0}_{1}", proyecto, fecha), "***********************************************************");
            for (int i = 0; i < trace.FrameCount; i++)
            {
                StackFrame sf = trace.GetFrame(i);
                if (sf.GetFileLineNumber() > 0)
                {
                    string LineaError = string.Format("Fecha Ejecucion: {4} | Nombre Archivo: {0} | Metodo: {1} | Linea Error: {2} | Error Generado: {3} ",
                        sf.GetFileName(), sf.GetMethod(), sf.GetFileLineNumber(), Mensaje, DateTime.Now);
                    escribirenArchivo(rutaArchivo, string.Format("LogErrores_{0}_{1}", proyecto.ToUpper(), fecha), LineaError);
                }
            }
        }

        public static void escribirenArchivo(string rutaArchivo, string archivo, string textoGuardado)
        {
            using (StreamWriter outputFile = new StreamWriter(rutaArchivo + @"\" + archivo, true))
            {
                outputFile.WriteLine(textoGuardado);
            }
        }
    }
}