// ---------------------------------------------------------------------------
//  Capa de compatibilidad: expone SqlConnection / SqlCommand / SqlDataAdapter /
//  SqlDataReader (los mismos nombres y metodos que usaba System.Data.SqlClient)
//  pero trabaja sobre SQLite embebido (Microsoft.Data.Sqlite).
//  Asi los formularios y las clases *Funciones siguen funcionando sin cambios
//  de logica y la aplicacion ya no necesita SQL Server.
// ---------------------------------------------------------------------------
#nullable disable
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace Diegod.Datos
{
    // ------------------------------------------------------------------ Conexion
    public sealed class SqlConnection : IDisposable
    {
        internal SqliteConnection Inner { get; private set; }
        private readonly string _cadena;

        public SqlConnection(string cadenaConexion)
        {
            _cadena = cadenaConexion;
            Inner = new SqliteConnection(cadenaConexion);
        }

        public ConnectionState State => Inner.State;

        public void Open()
        {
            if (Inner.State == ConnectionState.Open) return;
            Inner.Open();
            FuncionesSql.Registrar(Inner);
        }

        public void Close()
        {
            if (Inner.State != ConnectionState.Closed) Inner.Close();
        }

        public SqlCommand CreateCommand() => new SqlCommand(string.Empty, this);

        public SqlTransaction BeginTransaction() => new SqlTransaction(this, Inner.BeginTransaction());

        public void Dispose() => Inner.Dispose();
    }

    public sealed class SqlTransaction : IDisposable
    {
        internal SqliteTransaction Inner { get; }
        public SqlConnection Connection { get; }

        internal SqlTransaction(SqlConnection cn, SqliteTransaction inner)
        {
            Connection = cn;
            Inner = inner;
        }

        public void Commit() => Inner.Commit();
        public void Rollback() => Inner.Rollback();
        public void Dispose() => Inner.Dispose();
    }

    // ---------------------------------------------------------------- Parametros
    public sealed class SqlParameter
    {
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public SqlDbType SqlDbType { get; set; }

        public SqlParameter(string nombre, object valor)
        {
            ParameterName = nombre;
            Value = valor;
        }

        internal object ValorSqlite()
        {
            object v = Value;
            if (v == null) return DBNull.Value;
            // decimal se guardaria como TEXT en SQLite: se convierte a REAL para poder sumar/comparar.
            if (v is decimal d) return (double)d;
            return v;
        }
    }

    public sealed class SqlParameterCollection : IEnumerable<SqlParameter>
    {
        private readonly List<SqlParameter> _lista = new List<SqlParameter>();

        public int Count => _lista.Count;

        public SqlParameter AddWithValue(string nombre, object valor)
        {
            var p = new SqlParameter(nombre, valor);
            _lista.Add(p);
            return p;
        }

        public SqlParameter Add(string nombre, SqlDbType tipo)
        {
            var p = new SqlParameter(nombre, null) { SqlDbType = tipo };
            _lista.Add(p);
            return p;
        }

        public SqlParameter Add(string nombre, SqlDbType tipo, int tamano) => Add(nombre, tipo);

        public void Clear() => _lista.Clear();

        public IEnumerator<SqlParameter> GetEnumerator() => _lista.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => _lista.GetEnumerator();
    }

    // ------------------------------------------------------------------- Comando
    public sealed class SqlCommand : IDisposable
    {
        public string CommandText { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }
        public SqlParameterCollection Parameters { get; } = new SqlParameterCollection();

        public SqlCommand() { CommandText = string.Empty; }
        public SqlCommand(string texto) { CommandText = texto; }
        public SqlCommand(string texto, SqlConnection cn) { CommandText = texto; Connection = cn; }
        public SqlCommand(string texto, SqlConnection cn, SqlTransaction tran)
        {
            CommandText = texto;
            Connection = cn;
            Transaction = tran;
        }

        internal SqliteCommand Construir()
        {
            if (Connection == null) throw new InvalidOperationException("El comando no tiene conexion.");
            if (Connection.State != ConnectionState.Open) Connection.Open();

            SqliteCommand c = Connection.Inner.CreateCommand();
            c.CommandText = CommandText ?? string.Empty;
            if (Transaction != null) c.Transaction = Transaction.Inner;
            foreach (SqlParameter p in Parameters)
                c.Parameters.AddWithValue(p.ParameterName, p.ValorSqlite());
            return c;
        }

        public int ExecuteNonQuery()
        {
            using (SqliteCommand c = Construir())
                return c.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            using (SqliteCommand c = Construir())
                return c.ExecuteScalar();
        }

        public SqlDataReader ExecuteReader()
        {
            SqliteCommand c = Construir();
            try
            {
                return new SqlDataReader(c, c.ExecuteReader());
            }
            catch
            {
                c.Dispose();
                throw;
            }
        }

        public void Dispose() { }
    }

    // -------------------------------------------------------------------- Lector
    public sealed class SqlDataReader : IDisposable
    {
        private readonly SqliteCommand _cmd;
        private readonly SqliteDataReader _r;

        internal SqlDataReader(SqliteCommand cmd, SqliteDataReader r)
        {
            _cmd = cmd;
            _r = r;
        }

        public bool Read() => _r.Read();
        public bool NextResult() => _r.NextResult();
        public bool HasRows => _r.HasRows;
        public int FieldCount => _r.FieldCount;
        public bool IsClosed => _r.IsClosed;

        public int GetOrdinal(string nombre) => _r.GetOrdinal(nombre);
        public string GetName(int i) => _r.GetName(i);
        public bool IsDBNull(int i) => _r.IsDBNull(i);
        public object GetValue(int i) => _r.GetValue(i);
        public Type GetFieldType(int i) => _r.GetFieldType(i);

        public string GetString(int i) => _r.GetString(i);
        public int GetInt32(int i) => _r.GetInt32(i);
        public long GetInt64(int i) => _r.GetInt64(i);
        public double GetDouble(int i) => _r.GetDouble(i);
        public bool GetBoolean(int i) => _r.GetInt64(i) != 0;
        public decimal GetDecimal(int i) => Convert.ToDecimal(_r.GetValue(i), CultureInfo.InvariantCulture);

        public DateTime GetDateTime(int i)
        {
            object v = _r.GetValue(i);
            if (v is DateTime dt) return dt;
            return DateTime.Parse(Convert.ToString(v, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
        }

        public object this[int i] => _r.GetValue(i);
        public object this[string nombre] => _r.GetValue(_r.GetOrdinal(nombre));

        public void Close() => _r.Close();

        public void Dispose()
        {
            _r.Dispose();
            _cmd.Dispose();
        }
    }

    // ------------------------------------------------------------------- Adaptador
    public sealed class SqlDataAdapter : IDisposable
    {
        private static readonly Regex RxFecha =
            new Regex(@"^\d{4}-\d{2}-\d{2}([ T]\d{2}:\d{2}(:\d{2}(\.\d+)?)?)?$", RegexOptions.Compiled);

        public SqlCommand SelectCommand { get; set; }
        public MissingSchemaAction MissingSchemaAction { get; set; }

        public SqlDataAdapter() { }
        public SqlDataAdapter(SqlCommand cmd) { SelectCommand = cmd; }

        /// <summary>Compatibilidad: el esquema se arma directamente en Fill().</summary>
        public DataTable[] FillSchema(DataTable tabla, SchemaType tipo) => new[] { tabla };

        public int Fill(DataTable tabla)
        {
            if (SelectCommand == null) throw new InvalidOperationException("Falta SelectCommand.");

            using (SqliteCommand c = SelectCommand.Construir())
            using (SqliteDataReader r = c.ExecuteReader())
            {
                int n = r.FieldCount;
                string[] nombres = new string[n];
                string[] declarado = new string[n];
                for (int i = 0; i < n; i++)
                {
                    nombres[i] = r.GetName(i);
                    try { declarado[i] = r.GetDataTypeName(i); } catch { declarado[i] = null; }
                }

                var filas = new List<object[]>();
                while (r.Read())
                {
                    var v = new object[n];
                    r.GetValues(v);
                    filas.Add(v);
                }

                bool crear = tabla.Columns.Count == 0;
                var tipos = new Type[n];
                for (int i = 0; i < n; i++)
                {
                    if (crear)
                    {
                        tipos[i] = DeterminarTipo(nombres[i], declarado[i], filas, i);
                        string nombreCol = nombres[i];
                        int sufijo = 1;
                        while (tabla.Columns.Contains(nombreCol)) nombreCol = nombres[i] + "_" + (++sufijo);
                        tabla.Columns.Add(nombreCol, tipos[i]);
                    }
                    else
                    {
                        tipos[i] = tabla.Columns.Contains(nombres[i]) ? tabla.Columns[nombres[i]].DataType : typeof(string);
                    }
                }

                tabla.BeginLoadData();
                try
                {
                    foreach (object[] fila in filas)
                    {
                        DataRow dr = tabla.NewRow();
                        for (int i = 0; i < n; i++)
                        {
                            string col = crear ? tabla.Columns[i].ColumnName : nombres[i];
                            if (!tabla.Columns.Contains(col)) continue;
                            dr[col] = Convertir(fila[i], tipos[i]);
                        }
                        tabla.Rows.Add(dr);
                    }
                }
                finally
                {
                    tabla.EndLoadData();
                }
                return filas.Count;
            }
        }

        // Tipos declarados en el esquema (ver EsquemaSqlite): INT, BOOLEAN, DATETIME, DECIMAL.
        // Todo lo demas (expresiones, COALESCE, CASE...) se deduce de los valores.
        private static Type DeterminarTipo(string nombre, string declarado, List<object[]> filas, int col)
        {
            string d = (declarado ?? string.Empty).ToUpperInvariant();
            if (d == "BOOLEAN") return typeof(bool);
            if (d == "DATETIME") return typeof(DateTime);
            if (d == "DECIMAL") return typeof(decimal);
            if (d == "INT") return typeof(int);

            bool hayLong = false, hayDouble = false, hayTexto = false, hayOtro = false, todasFecha = true;
            bool cabeInt = true, hayValores = false;
            foreach (object[] f in filas)
            {
                object v = f[col];
                if (v == null || v is DBNull) continue;
                hayValores = true;
                if (v is long l)
                {
                    hayLong = true;
                    if (l < int.MinValue || l > int.MaxValue) cabeInt = false;
                    todasFecha = false;
                }
                else if (v is double) { hayDouble = true; todasFecha = false; }
                else if (v is string s)
                {
                    hayTexto = true;
                    if (!RxFecha.IsMatch(s)) todasFecha = false;
                }
                else { hayOtro = true; todasFecha = false; }
            }

            bool nombreFecha = nombre != null && nombre.StartsWith("Fecha", StringComparison.OrdinalIgnoreCase);

            if (!hayValores) return nombreFecha ? typeof(DateTime) : (d == "INTEGER" ? typeof(int) : typeof(string));
            if (hayOtro) return typeof(object);
            if (hayTexto && (hayLong || hayDouble)) return typeof(string);
            if (hayTexto) return (nombreFecha && todasFecha) ? typeof(DateTime) : typeof(string);
            if (hayDouble) return typeof(decimal);
            return cabeInt ? typeof(int) : typeof(long);
        }

        private static object Convertir(object v, Type tipo)
        {
            if (v == null || v is DBNull) return DBNull.Value;
            try
            {
                if (tipo == typeof(bool))
                {
                    if (v is long l) return l != 0;
                    if (v is double dd) return dd != 0;
                    if (v is string sb)
                    {
                        if (long.TryParse(sb, out long lb)) return lb != 0;
                        return bool.Parse(sb);
                    }
                }
                if (tipo == typeof(DateTime))
                {
                    if (v is DateTime) return v;
                    return DateTime.Parse(Convert.ToString(v, CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                }
                if (tipo == typeof(decimal)) return Convert.ToDecimal(v, CultureInfo.InvariantCulture);
                if (tipo == typeof(int)) return Convert.ToInt32(v, CultureInfo.InvariantCulture);
                if (tipo == typeof(long)) return Convert.ToInt64(v, CultureInfo.InvariantCulture);
                if (tipo == typeof(string)) return Convert.ToString(v, CultureInfo.InvariantCulture);
                return v;
            }
            catch
            {
                return tipo == typeof(string) ? (object)Convert.ToString(v, CultureInfo.InvariantCulture) : DBNull.Value;
            }
        }

        public void Dispose() { }
    }

    // ------------------------------------------- Funciones SQL propias de la app
    // Reemplazan FORMAT(...) y CAST(... AS nvarchar) de T-SQL.
    internal static class FuncionesSql
    {
        private static readonly CultureInfo EsAr = CrearCultura("es-AR");

        private static CultureInfo CrearCultura(string nombre)
        {
            try { return new CultureInfo(nombre); }
            catch { return CultureInfo.InvariantCulture; }
        }

        private static decimal? ADecimal(object v)
        {
            if (v == null || v is DBNull) return null;
            if (v is long l) return l;
            if (v is double d) return (decimal)d;
            if (v is decimal m) return m;
            if (decimal.TryParse(Convert.ToString(v, CultureInfo.InvariantCulture), NumberStyles.Any,
                                 CultureInfo.InvariantCulture, out decimal r)) return r;
            return null;
        }

        public static void Registrar(SqliteConnection cn)
        {
            // fmt_n0(x)      -> "1,500"      (equivale a FORMAT(x,'N0'))
            cn.CreateFunction("fmt_n0", (object v) =>
            {
                decimal? m = ADecimal(v);
                return m.HasValue ? m.Value.ToString("N0", CultureInfo.InvariantCulture) : null;
            });

            // fmt_moneda(x)  -> "$ 1.500,00" (equivale a FORMAT(x,'C','es-AR'))
            cn.CreateFunction("fmt_moneda", (object v) =>
            {
                decimal? m = ADecimal(v);
                return m.HasValue ? "$" + m.Value.ToString("#,##0.##", EsAr) : null;
            });

            // fmt_pesos(x)   -> "$1.500" / "$1.500,5" (formato unico de dinero para todo el programa)
            cn.CreateFunction("fmt_pesos", (object v) =>
            {
                decimal? m = ADecimal(v);
                return "$" + (m ?? 0m).ToString("#,##0.##", EsAr);
            });

            // fmt_txt(x)     -> "1500" / "1500.5" (numero como texto, sin ceros sobrantes)
            cn.CreateFunction("fmt_txt", (object v) =>
            {
                decimal? m = ADecimal(v);
                if (m.HasValue) return m.Value.ToString("0.##", CultureInfo.InvariantCulture);
                return v == null || v is DBNull ? null : Convert.ToString(v, CultureInfo.InvariantCulture);
            });
        }
    }
}
