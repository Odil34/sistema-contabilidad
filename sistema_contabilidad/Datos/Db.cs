using System.Data;
using System.Data.Common;
using System.Globalization;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace sistema_contabilidad.Datos
{
    public static class Db
    {
        public static bool EsSqlServer { get; set; } = true;
        public static string RutaSqlite { get; private set; }

        public static string Proveedor => EsSqlServer ? "SQL Server (LocalDB)" : "SQLite (local)";

        public static void UsarSqlite()
        {
            EsSqlServer = false;
            string dir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "SistemaContabilidad");
            Directory.CreateDirectory(dir);
            RutaSqlite = Path.Combine(dir, "SistemaContabilidad.db");
        }

        public static DbConnection Abrir()
        {
            if (EsSqlServer)
            {
                var con = new SqlConnection(ConexionBD.CadenaConexion);
                con.Open();
                return con;
            }

            var sqlite = new SqliteConnection("Data Source=" + RutaSqlite);
            sqlite.Open();
            using (var pragma = sqlite.CreateCommand())
            {
                pragma.CommandText = "PRAGMA foreign_keys = ON;";
                pragma.ExecuteNonQuery();
            }
            return sqlite;
        }

        public static DbCommand Cmd(string sql, DbConnection con, DbTransaction tran = null)
        {
            var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            if (tran != null) cmd.Transaction = tran;
            return cmd;
        }

        public static void P(DbCommand cmd, string nombre, object valor)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = nombre;
            p.Value = valor ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        public static object Fecha(DateTime fecha)
            => EsSqlServer ? (object)fecha.Date : fecha.ToString("yyyy-MM-dd");

        public static DataTable Tabla(DbCommand cmd)
        {
            var t = new DataTable();
            using var dr = cmd.ExecuteReader();
            t.Load(dr);
            return t;
        }

        public static string Str(DbDataReader dr, int i) => dr.IsDBNull(i) ? null : Convert.ToString(dr.GetValue(i));
        public static int Int(DbDataReader dr, int i) => Convert.ToInt32(dr.GetValue(i));
        public static bool Bool(DbDataReader dr, int i) => Convert.ToBoolean(dr.GetValue(i));
        public static DateTime Fecha(DbDataReader dr, int i) => Convert.ToDateTime(dr.GetValue(i), CultureInfo.InvariantCulture);

        public static decimal Dec(DbDataReader dr, int i)
        {
            if (dr.IsDBNull(i)) return 0m;
            return Convert.ToDecimal(dr.GetValue(i), CultureInfo.InvariantCulture);
        }
    }
}
