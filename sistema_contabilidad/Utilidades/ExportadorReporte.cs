using System.Text;
using System.Windows.Forms;

namespace sistema_contabilidad.Utilidades
{
    public static class ExportadorReporte
    {
        public static void ExportarCsv(DataGridView grid, string nombreSugerido)
        {
            if (grid == null || grid.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Exportar",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dlg = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = nombreSugerido + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;

            var sb = new StringBuilder();
            var columnas = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in grid.Columns)
                if (col.Visible) columnas.Add(col);
            columnas.Sort((a, b) => a.DisplayIndex.CompareTo(b.DisplayIndex));

            sb.AppendLine(string.Join(";", columnas.ConvertAll(c => Escapar(c.HeaderText))));

            foreach (DataGridViewRow fila in grid.Rows)
            {
                if (fila.IsNewRow) continue;
                var valores = columnas.ConvertAll(c => Escapar(fila.Cells[c.Index].Value?.ToString() ?? ""));
                sb.AppendLine(string.Join(";", valores));
            }

            System.IO.File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
            MessageBox.Show("Reporte exportado en:\n" + dlg.FileName, "Exportar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static string Escapar(string valor)
        {
            if (valor.Contains(';') || valor.Contains('"') || valor.Contains('\n'))
                return "\"" + valor.Replace("\"", "\"\"") + "\"";
            return valor;
        }
    }
}
