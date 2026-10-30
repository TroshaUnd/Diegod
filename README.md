# Diegod

Aplicación de escritorio para Windows (WinForms, .NET 8) para gestionar clientes, empleados,
proveedores, prestamistas, stock, vehículos, trabajos, créditos, pagos pendientes e historial.

## Qué cambió respecto a la versión anterior

La app original necesitaba un **SQL Server Express** instalado, con una base `Principal` cuyo esquema
no estaba en el repositorio, y la cadena de conexión apuntaba a una PC concreta (`DESKTOP-2LRIE6M`).
Ahora es un programa **autónomo**:

- La base de datos es un archivo **SQLite** (`diegod.db`) que se crea solo la primera vez, con todas
  las tablas y vistas necesarias.
- No hay que instalar SQL Server ni .NET (el `.exe` es autocontenido).
- Los formularios no cambiaron: una capa de compatibilidad (`Datos/SqlCompat.cs`) conserva los nombres
  `SqlConnection`, `SqlCommand`, `SqlDataAdapter`… pero trabaja sobre SQLite. Solo se tradujo el T-SQL
  (`SCOPE_IDENTITY`, `FORMAT`, `ISNULL`, `CAST(... AS DATE)`, concatenación con `+`, `dbo.`).

## Uso

| Dato | Valor |
|---|---|
| Usuario inicial | `admin` |
| Contraseña inicial | `admin` |
| Base de datos | `%LocalAppData%\Diegod\diegod.db` |
| Registro de errores | `%LocalAppData%\Diegod\errores.log` |

- **Modo portable:** si junto al `.exe` existe un archivo vacío llamado `Diegod.portable`, los datos se
  guardan en la carpeta `Datos` junto al `.exe` (útil para llevarlo en un pendrive).
- **Otra ubicación:** definir la variable de entorno `DIEGOD_DB` con la ruta completa de un `.db`.
- **Copia de seguridad:** basta copiar `diegod.db` con la aplicación cerrada.
- Para cambiar la contraseña hay que editar la tabla `Usuario` con cualquier visor SQLite
  (p. ej. *DB Browser for SQLite*); la app todavía no tiene pantalla para eso.

## Compilar y generar el instalador

Requisitos: Windows, [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) y, opcionalmente,
[Inno Setup 6](https://jrsoftware.org/isinfo.php) para el instalador.

```powershell
.\publicar.ps1
```

Genera:

- `publicar\win-x64\Diegod.exe` – ejecutable único, listo para usar.
- `publicar\Diegod-portable-win-x64.zip` – versión portable.
- `instalador\salida\Diegod-Setup.exe` – instalador (acceso directo en escritorio y menú Inicio).

El workflow de GitHub Actions (`.github/workflows/build.yml`) hace lo mismo en cada *push* y deja el
instalador y el zip como artefactos; al subir una etiqueta `vX.Y.Z` los adjunta a un *Release*.

## Notas y límites conocidos

- El esquema se **dedujo de las consultas del código**; las dos vistas (`vwStockCantidad`,
  `vwUltimoMovimiento`) se reconstruyeron con la lógica evidente (ingresos − egresos no anulados; último
  movimiento válido con precio).
- Se cargan las 24 jurisdicciones y las localidades principales de cada una, **no** el padrón completo.
  Se pueden agregar filas a la tabla `Localidades`.
- **No se migran datos** de una base SQL Server anterior; la base nueva arranca vacía.
- `LIKE` en SQLite ignora mayúsculas/minúsculas solo para letras ASCII (no para tildes).
