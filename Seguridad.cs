using System.Security.Cryptography;

namespace Diegod
{
    /// <summary>Guarda contraseñas de forma segura (nunca en texto plano) y las verifica.</summary>
    internal static class Seguridad
    {
        private const string Prefijo = "pbkdf2$";
        private const int Vueltas = 100_000;

        public static string Hashear(string clave)
        {
            byte[] sal = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(clave, sal, Vueltas, HashAlgorithmName.SHA256, 32);
            return Prefijo + Convert.ToBase64String(sal) + "$" + Convert.ToBase64String(hash);
        }

        /// <summary>Acepta claves guardadas con hash y también las viejas en texto plano (usuario genérico).</summary>
        public static bool Verificar(string clave, string guardada)
        {
            if (guardada == null) return false;
            if (!guardada.StartsWith(Prefijo)) return clave == guardada;
            var partes = guardada.Substring(Prefijo.Length).Split('$');
            if (partes.Length != 2) return false;
            byte[] sal = Convert.FromBase64String(partes[0]);
            byte[] esperado = Convert.FromBase64String(partes[1]);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(clave, sal, Vueltas, HashAlgorithmName.SHA256, esperado.Length);
            return CryptographicOperations.FixedTimeEquals(hash, esperado);
        }
    }
}
