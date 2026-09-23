using System.Data;
using System.Text;
using sistema_contabilidad.Datos;
using sistema_contabilidad.Modelos;
using sistema_contabilidad.Utilidades;

namespace sistema_contabilidad.Formularios
{
    public partial class FrmSaludFinanciera : Form
    {
        private readonly ReporteDAL _reporteDAL = new ReporteDAL();

        private static readonly Color Verde = Color.FromArgb(39, 128, 73);
        private static readonly Color Amarillo = Color.FromArgb(196, 145, 20);
        private static readonly Color Rojo = Color.FromArgb(150, 40, 40);

        public FrmSaludFinanciera()
        {
            InitializeComponent();
        }

        private void FrmSaludFinanciera_Load(object sender, EventArgs e)
        {
            dtpHasta.Value = DateTime.Today;
            Analizar();
        }

        private void Analizar()
        {
            List<SaldoCuenta> saldos = _reporteDAL.ObtenerSaldos(dtpHasta.Value, soloConMovimiento: false);
            ResultadoSalud resultado = AnalizadorFinanciero.Analizar(saldos);

            var tabla = new DataTable();
            tabla.Columns.Add("Indicador", typeof(string));
            tabla.Columns.Add("Fórmula", typeof(string));
            tabla.Columns.Add("Valor", typeof(string));
            tabla.Columns.Add("Estado", typeof(string));
            tabla.Columns.Add("Interpretación", typeof(string));
            tabla.Columns.Add("EstadoCod", typeof(int));

            foreach (var ind in resultado.Indicadores)
                tabla.Rows.Add(ind.Nombre, ind.Formula, ind.Valor, TextoEstado(ind.Estado),
                    ind.Interpretacion, (int)ind.Estado);

            dgvIndicadores.DataSource = tabla;
            FormatearIndicadores();

            lblNivel.Text = resultado.Nivel;
            lblScore.Text = Math.Round(resultado.Porcentaje) + "%";
            lblScoreDesc.Text = $"Índice global de salud financiera  ·  {resultado.PuntajeObtenido} de {resultado.PuntajeMaximo} puntos";
            panelScore.BackColor = ColorDe(resultado.NivelColor);

            var sb = new StringBuilder();
            foreach (var reco in resultado.Recomendaciones)
                sb.AppendLine(reco).AppendLine();
            txtRecomendaciones.Text = sb.ToString();
        }

        private void FormatearIndicadores()
        {
            dgvIndicadores.EnableHeadersVisualStyles = false;
            dgvIndicadores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 71, 115);
            dgvIndicadores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvIndicadores.ColumnHeadersDefaultCellStyle.Font = new Font(dgvIndicadores.Font, FontStyle.Bold);
            dgvIndicadores.RowTemplate.Height = 30;

            if (dgvIndicadores.Columns.Contains("EstadoCod"))
                dgvIndicadores.Columns["EstadoCod"].Visible = false;
            dgvIndicadores.Columns["Indicador"].Width = 210;
            dgvIndicadores.Columns["Fórmula"].Width = 250;
            dgvIndicadores.Columns["Valor"].Width = 70;
            dgvIndicadores.Columns["Valor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIndicadores.Columns["Estado"].Width = 90;
            dgvIndicadores.Columns["Interpretación"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            foreach (DataGridViewRow fila in dgvIndicadores.Rows)
            {
                int cod = Convert.ToInt32(fila.Cells["EstadoCod"].Value);
                Color color = ColorDe((Semaforo)cod);
                fila.Cells["Estado"].Style.ForeColor = color;
                fila.Cells["Estado"].Style.Font = new Font(dgvIndicadores.Font, FontStyle.Bold);
            }
        }

        private static string TextoEstado(Semaforo s) => s switch
        {
            Semaforo.Verde => "● Óptimo",
            Semaforo.Amarillo => "● Alerta",
            _ => "● Crítico"
        };

        private static Color ColorDe(Semaforo s) => s switch
        {
            Semaforo.Verde => Verde,
            Semaforo.Amarillo => Amarillo,
            _ => Rojo
        };

        private void btnAnalizar_Click(object sender, EventArgs e) => Analizar();
    }
}
