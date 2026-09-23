using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Utilidades
{
    public enum Semaforo { Verde, Amarillo, Rojo }

    public class Indicador
    {
        public string Nombre { get; set; }
        public string Formula { get; set; }
        public string Valor { get; set; }
        public Semaforo Estado { get; set; }
        public string Interpretacion { get; set; }
        public int Puntos { get; set; }
    }

    public class ResultadoSalud
    {
        public List<Indicador> Indicadores { get; } = new List<Indicador>();
        public List<string> Recomendaciones { get; } = new List<string>();
        public int PuntajeObtenido { get; set; }
        public int PuntajeMaximo { get; set; }
        public double Porcentaje => PuntajeMaximo == 0 ? 0 : (double)PuntajeObtenido / PuntajeMaximo * 100.0;
        public string Nivel { get; set; }
        public Semaforo NivelColor { get; set; }
    }

    public static class AnalizadorFinanciero
    {
        public static ResultadoSalud Analizar(List<SaldoCuenta> saldos)
        {
            decimal activoTotal = Suma(saldos, s => s.Tipo == 1);
            decimal activoCorriente = Suma(saldos, s => s.Tipo == 1 && s.Codigo.StartsWith("11"));
            decimal inventarios = Suma(saldos, s => s.Codigo == "1103");
            decimal pasivoTotal = Suma(saldos, s => s.Tipo == 2);
            decimal pasivoCorriente = Suma(saldos, s => s.Tipo == 2 && s.Codigo.StartsWith("21") && s.Codigo != "2102");
            decimal capital = Suma(saldos, s => s.Tipo == 3);
            decimal ingresos = Suma(saldos, s => s.Tipo == 5);
            decimal gastos = Suma(saldos, s => s.Tipo == 4);
            decimal utilidad = ingresos - gastos;
            decimal capitalContable = capital + utilidad;

            var r = new ResultadoSalud();

            r.Indicadores.Add(Evaluar(
                "Razón Corriente (Liquidez)", "Activo Corriente / Pasivo Corriente",
                Razon(activoCorriente, pasivoCorriente), pasivoCorriente == 0,
                v => v >= 1.5m, v => v >= 1.0m,
                "Buena capacidad para cubrir las deudas de corto plazo.",
                "Liquidez ajustada: vigile el pago de obligaciones corrientes.",
                "Liquidez insuficiente para cubrir el pasivo corriente."));

            r.Indicadores.Add(Evaluar(
                "Prueba Ácida", "(Activo Corriente - Inventarios) / Pasivo Corriente",
                Razon(activoCorriente - inventarios, pasivoCorriente), pasivoCorriente == 0,
                v => v >= 1.0m, v => v >= 0.8m,
                "Cubre sus deudas de corto plazo aun sin vender inventario.",
                "Depende parcialmente del inventario para cubrir deudas.",
                "Sin vender inventario no alcanza a cubrir el pasivo corriente."));

            r.Indicadores.Add(Evaluar(
                "Razón de Endeudamiento", "Pasivo Total / Activo Total",
                Razon(pasivoTotal, activoTotal), activoTotal == 0,
                v => v <= 0.5m, v => v <= 0.7m,
                "Nivel de deuda sano frente a los activos.",
                "Endeudamiento moderado: evite tomar más deuda.",
                "Alto endeudamiento: los activos están muy comprometidos."));

            r.Indicadores.Add(Evaluar(
                "Margen de Utilidad Neta", "Utilidad / Ingresos",
                Razon(utilidad, ingresos), ingresos == 0,
                v => v >= 0.10m, v => v >= 0.0m,
                "La operación genera una utilidad saludable sobre las ventas.",
                "Margen bajo: revise costos y gastos.",
                "La operación está generando pérdidas."));

            r.Indicadores.Add(Evaluar(
                "Rentabilidad del Capital (ROE)", "Utilidad / Capital Contable",
                Razon(utilidad, capitalContable), capitalContable == 0,
                v => v >= 0.15m, v => v >= 0.0m,
                "Buen rendimiento para los socios.",
                "Rendimiento bajo sobre el capital invertido.",
                "El capital de los socios está perdiendo valor."));

            r.Indicadores.Add(Evaluar(
                "Autonomía Financiera", "Capital Contable / Activo Total",
                Razon(capitalContable, activoTotal), activoTotal == 0,
                v => v >= 0.5m, v => v >= 0.3m,
                "La empresa se financia principalmente con recursos propios.",
                "Dependencia moderada de financiamiento externo.",
                "La empresa depende demasiado de terceros."));

            foreach (var ind in r.Indicadores)
            {
                r.PuntajeObtenido += ind.Puntos;
                r.PuntajeMaximo += 2;
                if (ind.Estado != Semaforo.Verde)
                    r.Recomendaciones.Add($"• {ind.Nombre}: {ind.Interpretacion}");
            }

            double pct = r.Porcentaje;
            if (pct >= 75) { r.Nivel = "SALUDABLE"; r.NivelColor = Semaforo.Verde; }
            else if (pct >= 50) { r.Nivel = "EN OBSERVACIÓN"; r.NivelColor = Semaforo.Amarillo; }
            else { r.Nivel = "EN RIESGO"; r.NivelColor = Semaforo.Rojo; }

            if (r.Recomendaciones.Count == 0)
                r.Recomendaciones.Add("• Todos los indicadores están en verde. La situación financiera es sólida; mantenga el control.");

            return r;
        }

        private static decimal Suma(List<SaldoCuenta> saldos, Func<SaldoCuenta, bool> filtro)
            => saldos.Where(filtro).Sum(s => s.Saldo);

        private static decimal? Razon(decimal numerador, decimal denominador)
            => denominador == 0 ? (decimal?)null : numerador / denominador;

        private static Indicador Evaluar(string nombre, string formula, decimal? valor, bool sinDenominador,
            Func<decimal, bool> verde, Func<decimal, bool> amarillo,
            string okTxt, string medioTxt, string malTxt)
        {
            if (sinDenominador || valor == null)
                return new Indicador
                {
                    Nombre = nombre, Formula = formula, Valor = "N/D",
                    Estado = Semaforo.Amarillo, Puntos = 1,
                    Interpretacion = "Sin datos suficientes para evaluar este indicador."
                };

            decimal v = valor.Value;
            Semaforo estado = verde(v) ? Semaforo.Verde : amarillo(v) ? Semaforo.Amarillo : Semaforo.Rojo;
            return new Indicador
            {
                Nombre = nombre, Formula = formula,
                Valor = v.ToString("N2"),
                Estado = estado,
                Puntos = estado == Semaforo.Verde ? 2 : estado == Semaforo.Amarillo ? 1 : 0,
                Interpretacion = estado == Semaforo.Verde ? okTxt : estado == Semaforo.Amarillo ? medioTxt : malTxt
            };
        }
    }
}
