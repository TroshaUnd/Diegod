using System;
namespace Diegod
{
    public class PagosPendientesPuente
    {
        public int ID { get; set; }
        public int CreditoID { get; set; }
        public int? EmpleadoTrabajoID { get; set; }
        public int? MovimientoStockID { get; set; }
        public int? TrabajoID { get; set; }
        public bool Anulado { get; set; }
        public DateTime? Fecha_Vencimiento { get; set; }  // Nueva propiedad

        public PagosPendientesPuente() { }

        public PagosPendientesPuente
        (
            int id,
            int creditoID,
            int? empleadoTrabajoID,
            int? movimientoStockID,
            int? trabajoID,
            bool anulado,
            DateTime? fechaVencimiento
        )
        {
            ID = id;
            CreditoID = creditoID;
            EmpleadoTrabajoID = empleadoTrabajoID;
            MovimientoStockID = movimientoStockID;
            TrabajoID = trabajoID;
            Anulado = anulado;
            Fecha_Vencimiento = fechaVencimiento;
        }
    }

    public class HistorialPuente
    {
        public int ID { get; set; }
        public int DeudaID { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Monto { get; set; }
        public bool Anulado { get; set; }
        public HistorialPuente() { }

        public HistorialPuente
            (
            int id,
            int deudaID,
            DateTime fechaPago,
            decimal monto,
            bool anulado
            )
        {
            ID = id;
            DeudaID = deudaID;
            FechaPago = fechaPago;
            Monto = monto;
            Anulado = anulado;
        }
    }
}
