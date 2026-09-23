using System.Globalization;
using System.Text;

namespace sistema_contabilidad.Utilidades
{
    public static class Numero
    {
        public static decimal ParsearMonto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return 0;

            var sb = new StringBuilder();
            foreach (char c in texto)
                if (char.IsDigit(c) || c == '.' || c == ',' || c == '-')
                    sb.Append(c);
            texto = sb.ToString();
            if (texto.Length == 0) return 0;

            bool negativo = texto.StartsWith("-");
            texto = texto.Replace("-", "");
            if (texto.Length == 0) return 0;

            int ultimoPunto = texto.LastIndexOf('.');
            int ultimaComa = texto.LastIndexOf(',');
            string normalizado;

            if (ultimoPunto >= 0 && ultimaComa >= 0)
            {
                char dec = ultimoPunto > ultimaComa ? '.' : ',';
                char mil = dec == '.' ? ',' : '.';
                normalizado = texto.Replace(mil.ToString(), "").Replace(dec, '.');
            }
            else if (ultimoPunto >= 0 || ultimaComa >= 0)
            {
                char sep = ultimoPunto >= 0 ? '.' : ',';
                int idx = texto.LastIndexOf(sep);
                int veces = texto.Count(c => c == sep);
                int digitosDespues = texto.Length - idx - 1;

                if (veces > 1 || digitosDespues == 3)
                    normalizado = texto.Replace(sep.ToString(), "");
                else
                    normalizado = texto.Replace(sep, '.');
            }
            else
            {
                normalizado = texto;
            }

            if (!decimal.TryParse(normalizado, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal valor))
                return 0;

            if (negativo) valor = -valor;
            return Math.Round(valor, 2);
        }
    }
}
