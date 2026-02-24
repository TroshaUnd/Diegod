using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Diegod
{
    public static class BaseDatos
    {
        private static readonly string DefaultCadena =
            @"Data Source=DESKTOP-2LRIE6M\SQLEXPRESS;Initial Catalog=Principal;Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True;Application Name=DiegodApp;TrustServerCertificate=True";

        private static readonly string CadenaConexion;

        static BaseDatos()
        {
            // 1) Probar todas las cadenas del App.config (si existen)
            try
            {
                var settings = ConfigurationManager.ConnectionStrings;
                if (settings != null)
                {
                    foreach (ConnectionStringSettings cs in settings)
                    {
                        if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString)) continue;
                        if (ProbarConexionCorta(cs.ConnectionString))
                        {
                            CadenaConexion = BuildFullFromExisting(cs.ConnectionString);
                            return;
                        }
                    }
                }
            }
            catch
            {
                // continuar con la búsqueda automática si algo falla leyendo el config
            }

            // 2) Probar servidores/instancias comunes
            string machine = Environment.MachineName ?? "localhost";
            string[] servidores = new[]
            {
                @"DESKTOP-2LRIE6M\SQLEXPRESS",
                @"localhost\SQLEXPRESS",
                @".\SQLEXPRESS",
                $@"{machine}\SQLEXPRESS",
                @"localhost",
                @".",
                machine
            };

            string[] bases = new[] { "Principal", "master" };

            foreach (var srv in servidores)
            {
                foreach (var db in bases)
                {
                    // cadena de prueba con timeout corto para no bloquear
                    string probe = $@"Data Source={srv};Initial Catalog={db};Integrated Security=True;Connect Timeout=3;TrustServerCertificate=True";
                    if (ProbarConexionCorta(probe))
                    {
                        // Si nos conectamos a master, verificar si existe Principal
                        if (db.Equals("master", StringComparison.OrdinalIgnoreCase))
                        {
                            try
                            {
                                using (var con = new SqlConnection(probe))
                                {
                                    con.Open();
                                    using (var cmd = new SqlCommand("SELECT database_id FROM sys.databases WHERE name = @name", con))
                                    {
                                        cmd.Parameters.AddWithValue("@name", "Principal");
                                        var obj = cmd.ExecuteScalar();
                                        if (obj != null && obj != DBNull.Value)
                                        {
                                            CadenaConexion = BuildFullConnectionString(srv, "Principal");
                                            return;
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                // ignorar y seguir probando
                            }
                        }
                        else
                        {
                            // si nos conectamos directo al servidor con la DB solicitada -> usarla
                            CadenaConexion = BuildFullConnectionString(srv, db);
                            return;
                        }
                    }
                }
            }

            // 3) Fallback final
            CadenaConexion = DefaultCadena;
        }

        /// <summary>
        /// Prueba una conexión rápidamente (timeout corto). Devuelve true si puede abrir.
        /// </summary>
        private static bool ProbarConexionCorta(string cadena)
        {
            try
            {
                using (var con = new SqlConnection(cadena))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Normaliza/ensambla una cadena completa a partir de servidor y base (para uso definitivo).
        /// </summary>
        private static string BuildFullConnectionString(string server, string database)
        {
            return $@"Data Source={server};Initial Catalog={database};Integrated Security=True;Connect Timeout=30;MultipleActiveResultSets=True;Application Name=DiegodApp;TrustServerCertificate=True";
        }

        /// <summary>
        /// Si la cadena hallada en el config ya es completa, la utiliza tal cual;
        /// si no tiene ciertos parámetros mínimos, intenta devolverla con los parámetros "amistosos".
        /// </summary>
        private static string BuildFullFromExisting(string existing)
        {
            // Si la cadena ya contiene Initial Catalog y Data Source, devolverla tal cual
            if (existing.IndexOf("Data Source=", StringComparison.OrdinalIgnoreCase) >= 0 &&
                existing.IndexOf("Initial Catalog=", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return existing;
            }

            // Si no, intentar parsear servidor y base y reconstruir (fallback simple)
            // No hacemos un parser completo; si falta, devolvemos DefaultCadena
            return DefaultCadena;
        }

        public static SqlConnection ObtenerConexion()
        {
            var conexion = new SqlConnection(CadenaConexion);
            conexion.Open();
            return conexion;
        }

        public static void CerrarConexion(SqlConnection conexion)
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
