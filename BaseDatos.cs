using System;
using System.IO;
using Diegod.Datos;
using Microsoft.Data.Sqlite;

namespace Diegod
{
    /// <summary>
    /// Acceso a la base de datos local (SQLite). El archivo se crea solo la primera vez.
    ///  - Instalacion normal : %LocalAppData%\Diegod\diegod.db
    ///  - Modo portable      : si existe el archivo "Diegod.portable" junto al .exe,
    ///                         se usa la carpeta "Datos" junto al .exe.
    ///  - Variable de entorno DIEGOD_DB: ruta completa a un archivo .db (opcional).
    /// </summary>
    public static class BaseDatos
    {
        private static readonly object _candado = new object();
        private static bool _inicializada;
        private static string _rutaBase;
        private static string _cadena;

        public static string RutaBaseDatos
        {
            get { Inicializar(); return _rutaBase; }
        }

        public static string CarpetaDatos => Path.GetDirectoryName(RutaBaseDatos);

        /// <summary>Crea el archivo y el esquema si hace falta. Es seguro llamarlo varias veces.</summary>
        public static void Inicializar()
        {
            if (_inicializada) return;
            lock (_candado)
            {
                if (_inicializada) return;

                _rutaBase = ResolverRuta();
                Directory.CreateDirectory(Path.GetDirectoryName(_rutaBase));

                // Pooling desactivado: cada conexion se cierra de verdad y el archivo queda libre.
                _cadena = new SqliteConnectionStringBuilder
                {
                    DataSource = _rutaBase,
                    Mode = SqliteOpenMode.ReadWriteCreate,
                    Pooling = false,
                    DefaultTimeout = 30
                }.ToString();

                CrearEsquemaYDatos();
                _inicializada = true;
            }
        }

        private static string ResolverRuta()
        {
            string env = Environment.GetEnvironmentVariable("DIEGOD_DB");
            if (!string.IsNullOrWhiteSpace(env)) return Path.GetFullPath(env);

            string exe = AppContext.BaseDirectory;
            if (File.Exists(Path.Combine(exe, "Diegod.portable")))
                return Path.Combine(exe, "Datos", "diegod.db");

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(appData, "Diegod", "diegod.db");
        }

        private static void CrearEsquemaYDatos()
        {
            using (var cn = new SqliteConnection(_cadena))
            {
                cn.Open();

                using (var tran = cn.BeginTransaction())
                {
                    Ejecutar(cn, tran, EsquemaSqlite.Tablas);
                    Ejecutar(cn, tran, EsquemaSqlite.Vistas);
                    Ejecutar(cn, tran, EsquemaSqlite.DatosIniciales);
                    CargarGeografia(cn, tran);
                    tran.Commit();
                }
            }
        }

        private static void Ejecutar(SqliteConnection cn, SqliteTransaction tran, string sql)
        {
            using (var cmd = cn.CreateCommand())
            {
                cmd.Transaction = tran;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        private static void CargarGeografia(SqliteConnection cn, SqliteTransaction tran)
        {
            using (var cuenta = cn.CreateCommand())
            {
                cuenta.Transaction = tran;
                cuenta.CommandText = "SELECT COUNT(*) FROM Provincias";
                if (Convert.ToInt64(cuenta.ExecuteScalar()) > 0) return;
            }

            foreach (var (provincia, localidades) in SemillaGeografica.ProvinciasYLocalidades)
            {
                long idProvincia;
                using (var ins = cn.CreateCommand())
                {
                    ins.Transaction = tran;
                    ins.CommandText = "INSERT INTO Provincias (provincia) VALUES ($p); SELECT last_insert_rowid();";
                    ins.Parameters.AddWithValue("$p", provincia);
                    idProvincia = Convert.ToInt64(ins.ExecuteScalar());
                }

                foreach (string loc in localidades)
                {
                    using (var insL = cn.CreateCommand())
                    {
                        insL.Transaction = tran;
                        insL.CommandText = "INSERT INTO Localidades (localidad, id_provincia) VALUES ($l, $p)";
                        insL.Parameters.AddWithValue("$l", loc);
                        insL.Parameters.AddWithValue("$p", idProvincia);
                        insL.ExecuteNonQuery();
                    }
                }
            }
        }

        public static SqlConnection ObtenerConexion()
        {
            Inicializar();
            var conexion = new SqlConnection(_cadena);
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
