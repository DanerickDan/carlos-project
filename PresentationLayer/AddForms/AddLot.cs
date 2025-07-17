
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using BusinessLayer.InvoiceManagment;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using FontAwesome.Sharp;

namespace PresentationLayer.AddForms
{
    public partial class AddLot : Form
    {
        private readonly INcfService _nfcService;
        private DateTimeFormater _dateFormater;
        public AddLot()
        {
            InitializeComponent();
            _nfcService = new NcfService();
            _dateFormater = new();
            expiration_date.Validating += textBoxFecha_Validating;
            initial_secuence_txt.KeyPress += ValidarSoloNumeros;
            final_secuence_txt.KeyPress += ValidarSoloNumeros;
            ncf_tipe_combo.Items.Add("B01");
            ncf_tipe_combo.SelectedItem = "B01";
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            string tipoNCF = ncf_tipe_combo.SelectedItem?.ToString();
            string secuenciaInicial = tipoNCF + initial_secuence_txt.Texts.Trim();
            string secuenciaFinal = tipoNCF + final_secuence_txt.Texts.Trim();
            DateTime fechaExpiracion = expiration_date.Value;

            // Validar tipo de NCF seleccionado
            if (string.IsNullOrWhiteSpace(tipoNCF))
            {
                MessageBox.Show("Debe seleccionar un tipo de NCF.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar longitud de las secuencias
            if (secuenciaInicial.Substring(3).Length != 8 || secuenciaFinal.Substring(3).Length != 8)
            {
                MessageBox.Show("Las secuencias deben tener exactamente 8 caracteres.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que ambas secuencias comiencen con el mismo tipo NCF
            if (!secuenciaInicial.StartsWith(tipoNCF) || !secuenciaFinal.StartsWith(tipoNCF))
            {
                MessageBox.Show($"Ambas secuencias deben comenzar con el tipo de NCF seleccionado ({tipoNCF}).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la parte numérica tenga solo dígitos
            string numInicioStr = secuenciaInicial.Substring(3);
            string numFinalStr = secuenciaFinal.Substring(3);

            if (!numInicioStr.All(char.IsDigit) || !numFinalStr.All(char.IsDigit))
            {
                MessageBox.Show("Las secuencias deben terminar en 8 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que secuencia inicial sea menor o igual a la final
            long numInicio = long.Parse(numInicioStr);
            long numFinal = long.Parse(numFinalStr);

            if (numFinal < numInicio)
            {
                MessageBox.Show("La secuencia final debe ser mayor o igual a la inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que la fecha de expiración sea futura
            if (fechaExpiracion <= DateTime.Today)
            {
                MessageBox.Show("La fecha de expiración debe ser futura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!aviable_check.Checked)
            {
                DialogResult result = MessageBox.Show(
                    "¿Está seguro que desea agregar un lote marcado como *no disponible*?",
                    "Confirmación",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Cancel)
                {
                    // El usuario canceló, se detiene el proceso
                    return;
                }

                // Si el usuario presionó OK, el flujo continúa normalmente
            }

            // Validación pasada, guardar
            NcfLotDTO nuevoLote = new NcfLotDTO
            {
                TipoNCF = tipoNCF,
                SecuenciaInicio = Convert.ToInt32(secuenciaInicial.Substring(3)),
                SecuenciaFin = Convert.ToInt32(secuenciaFinal.Substring(3)),
                SecuenciaActual = Convert.ToInt32(secuenciaInicial.Substring(3)),
                FechaExpiracion = fechaExpiracion,
                PrefijoNCF = tipoNCF,
                Disponible = true
            };

            try
            {
                _nfcService.AddLot(nuevoLote);
                MessageBox.Show("Lote de NCF guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // o limpia el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el lote: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBoxFecha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Obtiene el texto del TextBox
            string fechaTexto = expiration_date.Value.ToString("dd/MM/yyyy");

            // Valida la fecha
            if (!_dateFormater.ValidarFecha(fechaTexto))
            {
                // Muestra un mensaje de error si la fecha no es válida
                MessageBox.Show("El formato de la fecha debe ser dd/MM/yyyy y debe ser una fecha válida.", "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela el evento de validación
            }
        }

        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite la entrada de teclas numéricas y el retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si la tecla presionada no es un dígito ni una tecla de retroceso, se bloquea
                e.Handled = true;
                // Muestra un mensaje de error si se desea
                MessageBox.Show("Este campo solo debe contener números.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
