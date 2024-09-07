namespace BusinessLayer.Utils
{
    public class FieldValidator
    {
        public bool ValidarEmail(string email)
        {
            // Expresión regular básica para correos electrónicos
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, patron);
        }

        public bool ValidarTelefono(string telefono)
        {
            // Expresión regular para el formato de número de teléfono
            string patron = @"^\d{3}-\d{3}-\d{4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(telefono, patron);
        }
    }
}
