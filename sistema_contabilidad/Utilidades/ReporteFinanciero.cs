using System.Data;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Utilidades
{
    public static class ReporteFinanciero
    {
        public static decimal AgregarGrupo(DataTable t, List<SaldoCuenta> cuentas)
        {
            decimal total = 0;
            var grupos = cuentas.GroupBy(c => c.CodigoGrupo).OrderBy(g => g.Key);

            foreach (var g in grupos)
            {
                var items = g.OrderBy(c => c.Codigo).ToList();
                decimal subtotal = items.Sum(c => c.Saldo);
                total += subtotal;

                bool tieneSubcuentas = items.Exists(c => !string.IsNullOrEmpty(c.CodigoPadre));
                if (tieneSubcuentas)
                {
                    EstiloReporte.Agregar(t, items[0].NombreGrupo, subtotal, EstiloReporte.Grupo);
                    foreach (var c in items)
                        EstiloReporte.Agregar(t, "        " + c.Codigo + "  " + c.Nombre, c.Saldo);
                }
                else
                {
                    foreach (var c in items)
                        EstiloReporte.Agregar(t, c.Codigo + "  " + c.Nombre, c.Saldo, EstiloReporte.Grupo);
                }
            }

            return total;
        }
    }
}
