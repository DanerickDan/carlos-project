namespace BusinessLayer.Utils
{
    public class DateTimeFormater
    {
        public bool ValidarFecha(string fechaTexto)
        {
            DateTime fecha;
            // Define el formato esperado de la fecha
            string formato = "dd/MM/yyyy";
            // Define la cultura para el formato de fecha
            var cultura = System.Globalization.CultureInfo.InvariantCulture;

            // Intenta convertir la cadena a una fecha usando el formato especificado
            bool esValido = DateTime.TryParseExact(fechaTexto, formato, cultura, System.Globalization.DateTimeStyles.None, out fecha);

            // Devuelve true si la conversión fue exitosa, de lo contrario, false
            return esValido;
        }
    }
}
