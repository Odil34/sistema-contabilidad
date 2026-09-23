using System.Data;
using sistema_contabilidad.Modelos;

namespace sistema_contabilidad.Datos
{
    public class CuentaDAL
    {
        public List<Cuenta> ListarTodas() => Listar(null);

        public List<Cuenta> ListarDetalle() => Listar("WHERE c.EsDetalle = 1");

        private List<Cuenta> Listar(string filtro)
        {
            var lista = new List<Cuenta>();
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT c.Codigo, c.Nombre, c.CodigoPadre, c.EsDetalle, COALESCE(p.Nombre, '')
                  FROM Cuentas c
                  LEFT JOIN Cuentas p ON p.Codigo = c.CodigoPadre " + (filtro ?? "") +
                  " ORDER BY c.Codigo", con);
            using var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string padre = Db.Str(dr, 4);
                lista.Add(new Cuenta
                {
                    Codigo = Db.Str(dr, 0),
                    Nombre = Db.Str(dr, 1),
                    CodigoPadre = Db.Str(dr, 2),
                    EsDetalle = Db.Bool(dr, 3),
                    NombrePadre = string.IsNullOrEmpty(padre) ? null : padre
                });
            }
            return lista;
        }

        public DataTable ObtenerTabla()
        {
            using var con = Db.Abrir();
            using var cmd = Db.Cmd(
                @"SELECT c.Codigo AS [Código],
                         c.Nombre AS [Nombre],
                         CASE WHEN c.CodigoPadre IS NULL THEN 'Principal' ELSE 'Subcuenta' END AS [Nivel],
                         COALESCE(p.Nombre, '') AS [Cuenta Principal],
                         CASE c.Tipo WHEN 1 THEN 'Activo' WHEN 2 THEN 'Pasivo' WHEN 3 THEN 'Capital'
                                     WHEN 4 THEN 'Costos y Gastos' WHEN 5 THEN 'Ingresos' ELSE 'Otro' END AS [Clasificación],
                         c.Naturaleza AS [Naturaleza]
                  FROM Cuentas c
                  LEFT JOIN Cuentas p ON p.Codigo = c.CodigoPadre
                  ORDER BY c.Codigo", con);
            return Db.Tabla(cmd);
        }
    }
}
