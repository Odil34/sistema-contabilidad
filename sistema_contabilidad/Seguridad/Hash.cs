using System.Security.Cryptography;
using System.Text;

namespace sistema_contabilidad.Seguridad
{
    public static class Hash
    {
        public static string GenerarSalt()
        {
            byte[] bytes = RandomNumberGenerator.GetBytes(16);
            return Convert.ToBase64String(bytes);
        }

        public static string Calcular(string clave, string salt)
        {
            using var sha = SHA256.Create();
            byte[] datos = Encoding.UTF8.GetBytes(salt + clave);
            byte[] hash = sha.ComputeHash(datos);
            var sb = new StringBuilder();
            foreach (byte b in hash) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        public static bool Verificar(string clave, string salt, string hashGuardado)
        {
            return Calcular(clave, salt) == hashGuardado;
        }
    }
}
