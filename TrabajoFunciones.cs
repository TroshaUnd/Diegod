using System;
using System.Data;
using Diegod.Datos;
using System.Windows.Forms;

namespace Diegod
{
    public static class TrabajoFunciones
    {
        // Agrega un nuevo trabajo y devuelve el ID generado
        public static int AgregarTrabajo(TrabajoPuente trabajo)
        {
            const string sqlInsertTrabajo = @"
        INSERT INTO Trabajos
            (Fecha_Pedido, Trabajo_Realizar, Presupuesto, Observacion, Completado,
             Lugar_Trabajo, Fecha_Inicio, Fecha_Fin, Anulado, Cliente_ID)
        VALUES
            (@F, @T, @P, @O, @C, @L, @I, @F2, @A, @CL);
        SELECT last_insert_rowid();";

            const string sqlInsertPago = @"
        INSERT INTO Pagos_Pendientes
            (TrabajoID)
        VALUES
            (@TrabajoID);";

            using (var conn = BaseDatos.ObtenerConexion())
            using (var tran = conn.BeginTransaction())
            {
                // 1) Insertar el trabajo y obtener su ID
                int newTrabajoId;
                using (var cmd = new SqlCommand(sqlInsertTrabajo, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@F", trabajo.Fecha_Pedido ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@T", trabajo.Trabajo_Realizar ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@P", trabajo.Presupuesto ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@O", trabajo.Observacion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@C", trabajo.Completado ?? false);
                    cmd.Parameters.AddWithValue("@L", trabajo.Lugar_Trabajo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@I", trabajo.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@F2", trabajo.Fecha_Fin ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@A", trabajo.Anulado);
                    cmd.Parameters.AddWithValue("@CL", trabajo.Cliente_ID);

                    newTrabajoId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2) Insertar Pago_Pendiente con ese TrabajoID
                using (var cmdPago = new SqlCommand(sqlInsertPago, conn, tran))
                {
                    cmdPago.Parameters.AddWithValue("@TrabajoID", newTrabajoId);
                    cmdPago.ExecuteNonQuery();
                }

                // 3) Confirmar ambas operaciones
                tran.Commit();

                return newTrabajoId;
            }
        }
        public static DataTable GetVehiculosPorTrabajo(int trabajoId)
        {
            var dt = new DataTable();
            const string sql = @"
    SELECT 
        vt.ID,
        vt.Vehiculo_ID,
        vt.Anulado,                 -- ← importante traer este bit
        v.Nombre,
        v.Patente
      FROM Vehiculos_Trabajo vt
      JOIN Vehiculos v 
        ON vt.Vehiculo_ID = v.ID
     WHERE vt.Trabajo_ID = @Trab
       AND v.Activo = 1;
    ";
            using var conn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Trab", trabajoId);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Actualizar el campo Anulado
        public static int ActualizarAnuladoVehiculoTrabajo(int id, bool anulado)
        {
            const string sql = @"
    UPDATE Vehiculos_Trabajo
       SET Anulado = @A
     WHERE ID      = @ID;
    ";
            using var conn = BaseDatos.ObtenerConexion();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@A", anulado);
            cmd.Parameters.AddWithValue("@ID", id);
            return cmd.ExecuteNonQuery();
        }
        public static DataTable GetEmpleadosPorTrabajo(int trabajoId)
        {
            var dt = new DataTable();
            const string sql = @"
    SELECT 
        et.ID,
        et.Empleado_ID,
        et.Anulado,                 -- ← importante traer este bit
        e.Nombre,
        e.Apellido,
        et.Valor_Trabajo,
        et.Observaciones
      FROM Empleados_Trabajo et
      JOIN Empleados e 
        ON et.Empleado_ID = e.ID
     WHERE et.Trabajo_ID = @Trab
       AND e.Activo = 1;
    ";
            using var conn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Trab", trabajoId);
            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Actualizar el campo Anulado
        public static int ActualizarAnuladoEmpleadoTrabajo(int id, bool anulado)
        {
            const string sql = @"
    UPDATE Empleados_Trabajo
       SET Anulado = @A
     WHERE ID      = @ID;
    ";
            using var conn = BaseDatos.ObtenerConexion();
            if (conn.State != ConnectionState.Open)
                conn.Open();

            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@A", anulado);
            cmd.Parameters.AddWithValue("@ID", id);
            return cmd.ExecuteNonQuery();
        }
        // Buscar empleados por nombre (para DGViewEmpleados y búsquedas)
        public static DataTable BuscarEmpleadosPorNombre(string texto)
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT ID, Nombre, Apellido, Cargo
          FROM Empleados
         WHERE (Nombre LIKE @N OR Apellido LIKE @N)
           AND Activo = 1;                            -- <<-- filtrar activos
    ";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@N", "%" + texto + "%");
                da.Fill(dt);
            }
            return dt;
        }

        // Buscar vehículos por patente (para DGViewVehiculos y búsquedas)
        public static DataTable BuscarVehiculosPorPatente(string texto)
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT ID, Nombre, Patente
          FROM Vehiculos
         WHERE Patente LIKE @P
           AND Activo = 1;                            -- <<-- filtrar activos
    ";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@P", "%" + texto + "%");
                da.Fill(dt);
            }
            return dt;
        }

        // (Opcional) Si usás BuscarVehiculosPorNombre en CargarVehiculos:
        public static DataTable BuscarVehiculosPorNombre(string nombre)
        {
            var dt = new DataTable();
            const string sql = @"
        SELECT ID, Nombre, Patente
          FROM Vehiculos
         WHERE Nombre LIKE @N
           AND Activo = 1;                            -- <<-- filtrar activos
    ";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@N", "%" + nombre + "%");
                da.Fill(dt);
            }
            return dt;
        }
        // Obtener vehículos vinculados a un trabajo (DGViewVehiculosTrabajo)
        
        public static DataTable RegistroTrabajo()
        {
            const string sql = @"
    SELECT
        t.Anulado,
        t.ID,
        t.Fecha_Pedido,
        t.Cliente_ID,
        COALESCE(c.Nombre || ' ' || c.Apellido, '') AS Cliente_Nombre,  -- alias corregido
        t.Trabajo_Realizar,
        t.Presupuesto,
        t.Observacion,
        t.Lugar_Trabajo      AS Lugar_Trabajo,
        t.Completado,
        t.Fecha_Inicio,
        t.Fecha_Fin
    FROM Trabajos t
    LEFT JOIN Clientes c 
      ON t.Cliente_ID = c.ID
    ORDER BY t.Fecha_Inicio DESC;
    ";

            var dt = new DataTable();
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarTrabajos(int? id, int? clienteId, DateTime? fechaPedido)
        {
            var dt = new DataTable();
            using var cn = BaseDatos.ObtenerConexion();
            var sql = @"
    SELECT
        t.ID,
        t.Fecha_Pedido,
        t.Cliente_ID,
        COALESCE(c.Nombre || ' ' || c.Apellido, '') AS Cliente_Nombre,  -- alias corregido
        t.Trabajo_Realizar,
        t.Presupuesto,
        t.Observacion,
        t.Lugar_Trabajo,
        t.Completado,
        t.Fecha_Inicio,
        t.Fecha_Fin,
        t.Anulado
    FROM Trabajos t
    LEFT JOIN Clientes c 
      ON t.Cliente_ID = c.ID
    WHERE 1=1";

            if (id.HasValue) sql += " AND t.ID = @ID";
            if (clienteId.HasValue) sql += " AND t.Cliente_ID = @CliID";
            if (fechaPedido.HasValue) sql += " AND date(t.Fecha_Pedido) = date(@FP)";

            sql += " ORDER BY t.Anulado DESC, t.Fecha_Pedido DESC;";

            using var cmd = new SqlCommand(sql, cn);
            if (id.HasValue) cmd.Parameters.AddWithValue("@ID", id.Value);
            if (clienteId.HasValue) cmd.Parameters.AddWithValue("@CliID", clienteId.Value);
            if (fechaPedido.HasValue) cmd.Parameters.AddWithValue("@FP", fechaPedido.Value.Date);

            using var da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        // Modifica un trabajo existente, devuelve filas afectadas
        public static int ModificarTrabajo(TrabajoPuente trabajo)
        {
            const string sql = @"
                UPDATE Trabajos SET
                    Fecha_Pedido     = @F,
                    Trabajo_Realizar = @T,
                    Presupuesto      = @P,
                    Observacion      = @O,
                    Completado       = @C,
                    Lugar_Trabajo    = @L,
                    Fecha_Inicio     = @I,
                    Fecha_Fin        = @F2,
                    Anulado          = @A,
                    Cliente_ID       = @CL
                WHERE ID = @ID;";

            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@F", trabajo.Fecha_Pedido ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@T", trabajo.Trabajo_Realizar ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@P", trabajo.Presupuesto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@O", trabajo.Observacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@C", trabajo.Completado ?? false);
                cmd.Parameters.AddWithValue("@L", trabajo.Lugar_Trabajo ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@I", trabajo.Fecha_Inicio);
                cmd.Parameters.AddWithValue("@F2", trabajo.Fecha_Fin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@A", trabajo.Anulado);
                cmd.Parameters.AddWithValue("@CL", trabajo.Cliente_ID);
                cmd.Parameters.AddWithValue("@ID", trabajo.ID);

                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable BuscarClientesPorNombre(string texto)
        {
            var dt = new DataTable();
            const string sql = @"
            SELECT ID, Nombre, Apellido
              FROM Clientes
             WHERE Nombre LIKE @C
                OR Apellido LIKE @C;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@C", "%" + texto + "%");
                da.Fill(dt);
            }
            return dt;
        }
        // Actualiza el campo Anulado
        public static int ActualizarAnulado(int id, bool anulado)
        {
            const string sql = "UPDATE Trabajos SET Anulado = @A WHERE ID = @ID;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@A", anulado);
                cmd.Parameters.AddWithValue("@ID", id);
                return cmd.ExecuteNonQuery();
            }
        }
        public static int AgregarEmpleadoATrabajo(int trabajoId, int empleadoId, int valorTrabajo, string observaciones)
        {
            const string sqlInsert = @"
        INSERT INTO Empleados_Trabajo
            (Empleado_ID, Trabajo_ID, Valor_Trabajo, Observaciones)
        VALUES
            (@Emp, @Trab, @Val, @Obs);
        SELECT last_insert_rowid();";

            const string sqlPendiente = @"
        INSERT INTO Pagos_Pendientes (EmpleadoTrabajoID)
        VALUES (@EmpleadoTrabajoID);";

            using (var conn = BaseDatos.ObtenerConexion())
            using (var tran = conn.BeginTransaction())
            {
                int empleadoTrabajoID;

                // 1) Insertar en Empleados_Trabajo
                using (var cmd = new SqlCommand(sqlInsert, conn, tran))
                {
                    cmd.Parameters.AddWithValue("@Emp", empleadoId);
                    cmd.Parameters.AddWithValue("@Trab", trabajoId);
                    cmd.Parameters.AddWithValue("@Val", valorTrabajo);
                    cmd.Parameters.AddWithValue("@Obs", string.IsNullOrEmpty(observaciones)
                                                       ? DBNull.Value
                                                       : observaciones);

                    empleadoTrabajoID = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2) Insertar en Pagos_Pendientes
                using (var cmd2 = new SqlCommand(sqlPendiente, conn, tran))
                {
                    cmd2.Parameters.AddWithValue("@EmpleadoTrabajoID", empleadoTrabajoID);
                    cmd2.ExecuteNonQuery();
                }

                // 3) Confirmar transacción
                tran.Commit();

                return empleadoTrabajoID;
            }
        }

        // Inserta en Vehiculos_Trabajo
        public static int AgregarVehiculoATrabajo(int trabajoId, int vehiculoId)
        {
            const string sql = @"
                INSERT INTO Vehiculos_Trabajo
                    (Vehiculo_ID, Trabajo_ID)
                VALUES
                    (@Veh, @Trab);";

            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Veh", vehiculoId);
                cmd.Parameters.AddWithValue("@Trab", trabajoId);
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable VerClientesConTrabajos()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT 
                    c.ID, 
                    c.Nombre, 
                    c.Apellido, 
                    COUNT(t.ID) AS Trabajos_Realizados
                  FROM Clientes c
                  LEFT 
                  JOIN Trabajos t 
                    ON c.ID = t.Cliente_ID 
                   AND t.Completado = 1
               GROUP 
                  BY c.ID, c.Nombre, c.Apellido;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable VerEmpleadosConTrabajo()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT 
                    et.ID,
                    et.Empleado_ID,
                    e.Nombre,
                    e.Apellido,
                    et.Trabajo_ID,
                    et.Valor_Trabajo,
                    et.Observaciones,
                    t.Trabajo_Realizar AS Trabajo
                  FROM Empleados_Trabajo et
                  JOIN Empleados e 
                    ON et.Empleado_ID = e.ID
                  JOIN Trabajos t 
                    ON et.Trabajo_ID = t.ID
                 WHERE t.Completado = 0;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable VerVehiculosConTrabajo()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT 
                    v.ID, 
                    v.Nombre, 
                    v.Patente, 
                    t.Trabajo_Realizar AS Trabajo
                  FROM Vehiculos_Trabajo vt
                  JOIN Vehiculos v 
                    ON vt.Vehiculo_ID = v.ID
                  JOIN Trabajos t 
                    ON vt.Trabajo_ID = t.ID
                 WHERE t.Completado = 0;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable VerEmpleadosTrabajo()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT
                    et.ID,
                    et.Empleado_ID,
                    e.Nombre,
                    e.Apellido,
                    et.Trabajo_ID,
                    et.Valor_Trabajo,
                    et.Observaciones
                  FROM Empleados_Trabajo et
                  JOIN Empleados e 
                    ON et.Empleado_ID = e.ID;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public static DataTable VerVehiculosTrabajo()
        {
            var dt = new DataTable();
            const string sql = @"
                SELECT
                    vt.ID,
                    vt.Vehiculo_ID,
                    v.Nombre,
                    v.Patente,
                    vt.Trabajo_ID
                  FROM Vehiculos_Trabajo vt
                  JOIN Vehiculos v 
                    ON vt.Vehiculo_ID = v.ID;";
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}

