using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diegod
{
    public partial class MovimientoStockPuente
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public bool TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Anulado { get; set; }
        public string Destino { get; set; }
        public decimal PrecioTotal { get; set; }
        public int? ProveedorID { get; set; }
        public bool Cambio { get; set; }
        public MovimientoStockPuente()
        {
            Destino = string.Empty;
        }
        public MovimientoStockPuente(int id,
                                     int stockId,
                                     DateTime fechaMovimiento,
                                     bool tipoMovimiento,
                                     int cantidad,
                                     decimal precioUnitario,
                                     bool anulado,
                                     string destino,
                                     decimal precioTotal,
                                     int? proveedorId,
                                     bool cambio)
        {
            ID = id;
            StockID = stockId;
            FechaMovimiento = fechaMovimiento;
            TipoMovimiento = tipoMovimiento;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Anulado = anulado;
            Destino = destino;
            PrecioTotal = precioTotal;
            ProveedorID = proveedorId;
            Cambio = cambio;
        }
    }


    public class TrabajoPuente
    {
        public int ID { get; set; }
        public DateTime? Fecha_Pedido { get; set; }
        public string Trabajo_Realizar { get; set; }
        public string Presupuesto { get; set; }
        public string Observacion { get; set; }
        public bool? Completado { get; set; }
        public string Lugar_Trabajo { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
        public bool Anulado { get; set; }
        public int Cliente_ID { get; set; }

        public TrabajoPuente() { }

        public TrabajoPuente(DateTime? fechaPedido, string trabajoRealizar, string presupuesto,
                             string observacion, bool? completado, string lugarTrabajo,
                             DateTime fechaInicio, DateTime? fechaFin, bool anulado, int clienteID)
        {
            Fecha_Pedido = fechaPedido;
            Trabajo_Realizar = trabajoRealizar;
            Presupuesto = presupuesto;
            Observacion = observacion;
            Completado = completado;
            Lugar_Trabajo = lugarTrabajo;
            Fecha_Inicio = fechaInicio;
            Fecha_Fin = fechaFin;
            Anulado = anulado;
            Cliente_ID = clienteID;
        }
    }

    public partial class CreditoPuente
    {
        public int ID { get; set; }             
        public int Prestamista_ID { get; set; }       
        public decimal Monto_Credito { get; set; }      
        public DateTime Fecha_Credito { get; set; }        
        public DateTime Fecha_Vencimiento { get; set; }     
        public string Observacion { get; set; }           
        public bool Anulado { get; set; }

        public CreditoPuente() { }
        public CreditoPuente(int prestamistaID, decimal montoCredito, DateTime fechaCredito, DateTime fechaVencimiento, string observacion = null, bool anulado = false)
        {
            Prestamista_ID = prestamistaID;
            Monto_Credito = montoCredito;
            Fecha_Credito = fechaCredito;
            Fecha_Vencimiento = fechaVencimiento;
            Observacion = observacion;
            Anulado = anulado;
        }
    }
    public class EmpleadoTrabajoPuente
    {
        public int ID { get; set; }
        public int Empleado_ID { get; set; }
        public int Trabajo_ID { get; set; }
        public int? Valor_Trabajo { get; set; }
        public string Observaciones { get; set; }
        public bool Anulado { get; set; } // Nuevo campo

        public EmpleadoTrabajoPuente() { }

        public EmpleadoTrabajoPuente(int empleadoID, int trabajoID, int? valorTrabajo, string observaciones, bool anulado = false)
        {
            Empleado_ID = empleadoID;
            Trabajo_ID = trabajoID;
            Valor_Trabajo = valorTrabajo;
            Observaciones = observaciones;
            Anulado = anulado;
        }
    }

    public class VehiculoTrabajoPuente
    {
        public int ID { get; set; }
        public int Vehiculo_ID { get; set; }
        public int Trabajo_ID { get; set; }
        public bool Anulado { get; set; } // Nuevo campo

        public VehiculoTrabajoPuente() { }

        public VehiculoTrabajoPuente(int vehiculoID, int trabajoID, bool anulado = false)
        {
            Vehiculo_ID = vehiculoID;
            Trabajo_ID = trabajoID;
            Anulado = anulado;
        }
    }
}
