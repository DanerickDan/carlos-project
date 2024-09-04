using ClosedXML.Excel;

namespace PresentationLayer.Features
{
    public class CreateCSV
    {

        public void ExportarDataGridViewAExcel(DataGridView dataGridView)
        {
            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    // Crear una nueva hoja de Excel
                    var worksheet = workbook.Worksheets.Add("Datos");

                    // Agregar los encabezados de las columnas
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                    }

                    // Agregar las filas de datos
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = dataGridView.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Mostrar diálogo para guardar el archivo
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Guardar archivo Excel",
                        FileName = "DatosExportados.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Guardar el archivo en la ubicación especificada por el usuario
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Datos exportados exitosamente a Excel", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
