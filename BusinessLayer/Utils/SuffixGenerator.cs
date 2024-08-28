namespace BusinessLayer.Utils
{
    public class SuffixGenerator
    {
        public string GenerarSufijoAleatorio(int longitud)
        {
            // Crear una instancia de la clase Random para generar números aleatorios
            Random random = new Random();
            // Crear un array de caracteres para almacenar las letras generadas
            char[] sufijo = new char[longitud];

            // Recorrer la longitud especificada y generar letras aleatorias
            for (int i = 0; i < longitud; i++)
            {
                // Generar un número aleatorio entre 0 y 25 (incluyendo ambos)
                int num = random.Next(0, 26);
                // Convertir el número en una letra (A-Z) sumando el valor ASCII de 'A' (65)
                sufijo[i] = (char)('A' + num);
            }

            // Convertir el array de caracteres en una cadena y devolverla
            return new string(sufijo);
        }
    }
}
