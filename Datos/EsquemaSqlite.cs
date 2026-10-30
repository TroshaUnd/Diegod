// Esquema de la base SQLite. Reproduce las tablas y vistas que la aplicacion
// usaba en SQL Server ("Principal"), deducidas de todas las consultas del codigo.
//
// Tipos declarados con significado para la capa de compatibilidad (SqlCompat.cs):
//   INT / INTEGER -> Int32,  BOOLEAN -> bool,  DATETIME -> DateTime,  DECIMAL -> decimal
namespace Diegod.Datos
{
    internal static class EsquemaSqlite
    {
        public const string Tablas = """
CREATE TABLE IF NOT EXISTS Usuario (
    ID      INTEGER PRIMARY KEY AUTOINCREMENT,
    Usuario TEXT NOT NULL,
    Contra  TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Tipo (
    TipoId INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Provincias (
    id        INTEGER PRIMARY KEY AUTOINCREMENT,
    provincia TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS Localidades (
    Localidad_ID INTEGER PRIMARY KEY AUTOINCREMENT,
    localidad    TEXT NOT NULL,
    id_provincia INT  NOT NULL
);
CREATE INDEX IF NOT EXISTS IX_Localidades_Provincia ON Localidades(id_provincia);

CREATE TABLE IF NOT EXISTS Clientes (
    ID           INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre       TEXT,
    Apellido     TEXT,
    Email        TEXT,
    Telefono     TEXT,
    Direccion    TEXT,
    Cuit         TEXT,
    Observacion  TEXT,
    Localidad_ID INT,
    Empresa      TEXT,
    TipoId       INT DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Empleados (
    ID                 INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre             TEXT,
    Apellido           TEXT,
    Email              TEXT,
    Cargo              TEXT,
    Fecha_Contratacion DATETIME,
    Nacimiento         DATETIME,
    Dni                TEXT,
    Telefono           TEXT,
    Direccion          TEXT,
    Activo             BOOLEAN NOT NULL DEFAULT 1,
    Observacion        TEXT,
    Localidad_ID       INT,
    Empresa            TEXT,
    TipoId             INT DEFAULT 2
);

CREATE TABLE IF NOT EXISTS Proveedor (
    ID            INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre        TEXT,
    Apellido      TEXT,
    Empresa       TEXT,
    Email         TEXT,
    Telefono      TEXT,
    Direccion     TEXT,
    Localidad_ID  INT,
    Observaciones TEXT,
    TipoId        INT DEFAULT 3
);

CREATE TABLE IF NOT EXISTS Prestamista (
    ID          INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre      TEXT,
    Apellido    TEXT,
    Email       TEXT,
    Telefono    TEXT,
    Direccion   TEXT,
    Empresa     TEXT,
    Observacion TEXT,
    TipoId      INT DEFAULT 4
);

CREATE TABLE IF NOT EXISTS Vehiculos (
    ID                   INTEGER PRIMARY KEY AUTOINCREMENT,
    Nombre               TEXT,
    Patente              TEXT,
    Fecha_UltimoServicio DATETIME,
    Observacion          TEXT,
    Activo               BOOLEAN NOT NULL DEFAULT 1
);

CREATE TABLE IF NOT EXISTS Stock (
    ID       INTEGER PRIMARY KEY AUTOINCREMENT,
    Producto TEXT,
    Lugar    TEXT
);

CREATE TABLE IF NOT EXISTS MovimientoStock (
    ID               INTEGER PRIMARY KEY AUTOINCREMENT,
    Stock_ID         INT NOT NULL,
    Fecha_Movimiento DATETIME,
    Tipo_Movimiento  BOOLEAN NOT NULL DEFAULT 1,   -- 1 = Ingreso, 0 = Egreso
    Cantidad         INT NOT NULL DEFAULT 0,
    Precio_Unitario  DECIMAL DEFAULT 0,
    Anulado          BOOLEAN NOT NULL DEFAULT 0,
    Destino          TEXT,
    Precio_Total     DECIMAL DEFAULT 0,
    Proveedor_ID     INT,
    Cambio           BOOLEAN NOT NULL DEFAULT 0
);
CREATE INDEX IF NOT EXISTS IX_Mov_Stock ON MovimientoStock(Stock_ID);

CREATE TABLE IF NOT EXISTS Trabajos (
    ID               INTEGER PRIMARY KEY AUTOINCREMENT,
    Fecha_Pedido     DATETIME,
    Trabajo_Realizar TEXT,
    Presupuesto      TEXT,
    Observacion      TEXT,
    Completado       BOOLEAN NOT NULL DEFAULT 0,
    Lugar_Trabajo    TEXT,
    Fecha_Inicio     DATETIME,
    Fecha_Fin        DATETIME,
    Anulado          BOOLEAN NOT NULL DEFAULT 0,
    Cliente_ID       INT
);

CREATE TABLE IF NOT EXISTS Empleados_Trabajo (
    ID            INTEGER PRIMARY KEY AUTOINCREMENT,
    Empleado_ID   INT NOT NULL,
    Trabajo_ID    INT NOT NULL,
    Valor_Trabajo INT,
    Observaciones TEXT,
    Anulado       BOOLEAN NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Vehiculos_Trabajo (
    ID          INTEGER PRIMARY KEY AUTOINCREMENT,
    Vehiculo_ID INT NOT NULL,
    Trabajo_ID  INT NOT NULL,
    Anulado     BOOLEAN NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Credito (
    ID                INTEGER PRIMARY KEY AUTOINCREMENT,
    Prestamista_ID    INT NOT NULL,
    Monto_Credito     DECIMAL NOT NULL DEFAULT 0,
    Fecha_Credito     DATETIME,
    Fecha_Vencimiento DATETIME,
    Observacion       TEXT,
    Anulado           BOOLEAN NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Pagos_Pendientes (
    ID                INTEGER PRIMARY KEY AUTOINCREMENT,
    CreditoID         INT,
    EmpleadoTrabajoID INT,
    MovimientoStockID INT,
    TrabajoID         INT,
    Anulado           BOOLEAN NOT NULL DEFAULT 0,
    Fecha_Vencimiento DATETIME
);

CREATE TABLE IF NOT EXISTS Historial (
    ID          INTEGER PRIMARY KEY AUTOINCREMENT,
    Pendiente_ID INT NOT NULL,
    Fecha_Pago  DATETIME,
    Monto       DECIMAL NOT NULL DEFAULT 0,
    Anulado     BOOLEAN NOT NULL DEFAULT 0
);
CREATE INDEX IF NOT EXISTS IX_Historial_Pendiente ON Historial(Pendiente_ID);
""";

        // Cantidad disponible = ingresos - egresos de movimientos no anulados.
        // Ultimo movimiento = el movimiento valido mas reciente de cada producto
        // (los "cambios" no tienen precio y se ignoran).
        public const string Vistas = """
DROP VIEW IF EXISTS vwStockCantidad;
CREATE VIEW vwStockCantidad AS
SELECT m.Stock_ID AS Stock_ID,
       SUM(CASE WHEN m.Tipo_Movimiento = 1 THEN m.Cantidad ELSE -m.Cantidad END) AS CantidadTotal
FROM MovimientoStock m
WHERE m.Anulado = 0
GROUP BY m.Stock_ID;

DROP VIEW IF EXISTS vwUltimoMovimiento;
CREATE VIEW vwUltimoMovimiento AS
SELECT m.Stock_ID          AS Stock_ID,
       m.Precio_Unitario   AS Precio_Unitario,
       m.Precio_Total      AS Precio_Total,
       m.Fecha_Movimiento  AS Fecha_Movimiento
FROM MovimientoStock m
WHERE m.Anulado = 0
  AND m.Cambio = 0
  AND m.ID = (SELECT m2.ID
                FROM MovimientoStock m2
               WHERE m2.Stock_ID = m.Stock_ID
                 AND m2.Anulado = 0
                 AND m2.Cambio = 0
               ORDER BY m2.Fecha_Movimiento DESC, m2.ID DESC
               LIMIT 1);
""";

        public const string DatosIniciales = """
INSERT INTO Tipo (TipoId, Nombre)
SELECT * FROM (SELECT 1, 'Cliente' UNION ALL SELECT 2, 'Empleado' UNION ALL SELECT 3, 'Proveedor' UNION ALL SELECT 4, 'Prestamista')
WHERE NOT EXISTS (SELECT 1 FROM Tipo);

INSERT INTO Usuario (Usuario, Contra)
SELECT 'admin', 'admin'
WHERE NOT EXISTS (SELECT 1 FROM Usuario);
""";
    }
}
