using System;
using System.IO;

namespace DataLayer
{

    public static class Logger
    {
        private static string logFilePath = "C:\\Users\\pasantetic\\Desktop\\log.txt"; // Ruta del archivo de registro

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error al escribir en el archivo de registro, puedes manejarlo aquí
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }

        public static void Log(Exception ex, string additionalInfo = "")
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {additionalInfo}");
                    writer.WriteLine($"Exception Message: {ex.Message}");
                    writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                }
            }
            catch (Exception logEx)
            {
                // Maneja el error al escribir en el archivo de registro
                Console.WriteLine($"Error al escribir en el archivo de registro: {logEx.Message}");
            }
        }
    }

}
