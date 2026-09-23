using System.Data;
using System.Windows.Forms;

namespace sistema_contabilidad.Utilidades
{
    public static class EstiloReporte
    {
        public const string Normal = "";
        public const string Encabezado = "H";
        public const string Grupo = "G";
        public const string Total = "T";
        public const string Resultado = "R";

        public static DataTable CrearTabla()
        {
            var t = new DataTable();
            t.Columns.Add("Detalle", typeof(string));
            t.Columns.Add("Importe", typeof(decimal));
            t.Columns.Add("Estilo", typeof(string));
            return t;
        }

        public static void Agregar(DataTable t, string detalle, decimal? importe, string estilo = "")
        {
            t.Rows.Add(detalle, (object)importe ?? System.DBNull.Value, estilo);
        }

        public static void Formatear(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(33, 71, 115);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(grid.Font, System.Drawing.FontStyle.Bold);

            if (grid.Columns.Contains("Estilo")) grid.Columns["Estilo"].Visible = false;
            if (grid.Columns.Contains("Detalle"))
                grid.Columns["Detalle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (grid.Columns.Contains("Importe"))
            {
                grid.Columns["Importe"].DefaultCellStyle.Format = "N2";
                grid.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grid.Columns["Importe"].Width = 160;
            }

            foreach (DataGridViewRow fila in grid.Rows)
            {
                string estilo = fila.Cells["Estilo"].Value?.ToString() ?? "";
                switch (estilo)
                {
                    case Encabezado:
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(33, 71, 115);
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                        fila.DefaultCellStyle.Font = new System.Drawing.Font(grid.Font, System.Drawing.FontStyle.Bold);
                        break;
                    case Grupo:
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(219, 229, 241);
                        fila.DefaultCellStyle.Font = new System.Drawing.Font(grid.Font, System.Drawing.FontStyle.Bold);
                        break;
                    case Total:
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(238, 243, 249);
                        fila.DefaultCellStyle.Font = new System.Drawing.Font(grid.Font, System.Drawing.FontStyle.Bold);
                        break;
                    case Resultado:
                        fila.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(39, 128, 73);
                        fila.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                        fila.DefaultCellStyle.Font = new System.Drawing.Font(grid.Font.FontFamily, 11F, System.Drawing.FontStyle.Bold);
                        break;
                }
            }
        }
    }
}
