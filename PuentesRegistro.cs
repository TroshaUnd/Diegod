using System;

namespace Diegod
{
    public class VehiculosPuente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Patente { get; set; } = string.Empty;
        public DateTime? Fecha_UltimoServicio { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public bool Activo { get; set; }

        // Constructor por defecto
        public VehiculosPuente()
        {
            Activo = true;
        }

        // Constructor completo
        public VehiculosPuente(int id, string nombre, string patente, DateTime? fechaUltimoServicio, string observacion, bool activo)
        {
            ID = id;
            Nombre = nombre ?? string.Empty;
            Patente = patente ?? string.Empty;
            Fecha_UltimoServicio = fechaUltimoServicio;
            Observacion = observacion ?? string.Empty;
            Activo = activo;
        }
    }


    public class ProveedorPuente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public int? Localidad_ID { get; set; }
        public string Observaciones { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;

        public ProveedorPuente() { }

        public ProveedorPuente(int id, string nombre, string apellido, string empresa,
                               string email, string telefono, string direccion, int? localidad_ID,
                               string observaciones, string localidad, string provincia)
        {
            ID = id;
            Nombre = nombre ?? string.Empty;
            Apellido = apellido ?? string.Empty;
            Empresa = empresa ?? string.Empty;
            Email = email ?? string.Empty;
            Telefono = telefono ?? string.Empty;
            Direccion = direccion ?? string.Empty;
            Localidad_ID = localidad_ID;
            Observaciones = observaciones ?? string.Empty;
            Localidad = localidad ?? string.Empty;
            Provincia = provincia ?? string.Empty;
        }
    }
    public class StockPuente
    {
        public int ID { get; set; }
        public string Producto { get; set; } = string.Empty;
        public string Lugar { get; set; } = string.Empty;

        public StockPuente() { }

        public StockPuente(int id, string producto, string lugar)
        {
            ID = id;
            Producto = producto ?? string.Empty;
            Lugar = lugar ?? string.Empty;
        }
    }
    public class PrestamistaPuente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public string Empresa { get; set; } = string.Empty; // Nueva propiedad

        public PrestamistaPuente() { }

        public PrestamistaPuente(int id, string nombre, string apellido,
                                  string email, string telefono, string direccion,
                                  string observacion, string empresa) // Constructor actualizado
        {
            ID = id;
            Nombre = nombre ?? string.Empty;
            Apellido = apellido ?? string.Empty;
            Email = email ?? string.Empty;
            Telefono = telefono ?? string.Empty;
            Direccion = direccion ?? string.Empty;
            Observacion = observacion ?? string.Empty;
            Empresa = empresa ?? string.Empty;
        }
    }


    public class EmpleadosPuente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public DateTime? Fecha_Contratacion { get; set; }
        public DateTime? Nacimiento { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public string Observacion { get; set; } = string.Empty;
        public int? Localidad_ID { get; set; }
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;

        public EmpleadosPuente()
        {
            Activo = true;
        }

        public EmpleadosPuente(int id, string nombre, string apellido, string email, string cargo,
                                DateTime? fechaContratacion, DateTime? nacimiento, string dni,
                                string telefono, string direccion, bool activo,
                                string observacion, int? localidad_ID,
                                string localidad, string provincia)
        {
            ID = id;
            Nombre = nombre ?? string.Empty;
            Apellido = apellido ?? string.Empty;
            Email = email ?? string.Empty;
            Cargo = cargo ?? string.Empty;
            Fecha_Contratacion = fechaContratacion;
            Nacimiento = nacimiento;
            Dni = dni ?? string.Empty;
            Telefono = telefono ?? string.Empty;
            Direccion = direccion ?? string.Empty;
            Activo = activo;
            Observacion = observacion ?? string.Empty;
            Localidad_ID = localidad_ID;
            Localidad = localidad ?? string.Empty;
            Provincia = provincia ?? string.Empty;
        }
    }

    public class ClientesPuente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Cuit { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
        public int? Localidad_ID { get; set; }
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;

        public ClientesPuente() { }

        public ClientesPuente(int id, string nombre, string apellido, string email,
                               string telefono, string direccion, string cuit,
                               string observacion, int? localidad_ID,
                               string localidad, string provincia)
        {
            ID = id;
            Nombre = nombre ?? string.Empty;
            Apellido = apellido ?? string.Empty;
            Email = email ?? string.Empty;
            Telefono = telefono ?? string.Empty;
            Direccion = direccion ?? string.Empty;
            Cuit = cuit ?? string.Empty;
            Observacion = observacion ?? string.Empty;
            Localidad_ID = localidad_ID;
            Localidad = localidad ?? string.Empty;
            Provincia = provincia ?? string.Empty;
        }
    }
}