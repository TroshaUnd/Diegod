using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Trabajo : Form
    {
        public Trabajo()
        {
            InitializeComponent();

            // Suscribir eventos para EmpleadosTrabajo
            DGViewEmpleadosTrabajo.DataBindingComplete += DGViewEmpleadosTrabajo_DataBindingComplete;
            DGViewEmpleadosTrabajo.CellFormatting += DGViewEmpleadosTrabajo_CellFormatting;
            DGViewEmpleadosTrabajo.CellContentClick += DGViewEmpleadosTrabajo_CellContentClick;
            DGViewEmpleadosTrabajo.CurrentCellDirtyStateChanged += DGViewEmpleadosTrabajo_CurrentCellDirtyStateChanged;
            DGViewEmpleadosTrabajo.CellValueChanged += DGViewEmpleadosTrabajo_CellValueChanged;

            DGViewVehiculosTrabajo.DataBindingComplete += DGViewVehiculosTrabajo_DataBindingComplete;
            DGViewVehiculosTrabajo.CellFormatting += DGViewVehiculosTrabajo_CellFormatting;
            DGViewVehiculosTrabajo.CellContentClick += DGViewVehiculosTrabajo_CellContentClick;
            DGViewVehiculosTrabajo.CurrentCellDirtyStateChanged += DGViewVehiculosTrabajo_CurrentCellDirtyStateChanged;
            DGViewVehiculosTrabajo.CellValueChanged += DGViewVehiculosTrabajo_CellValueChanged;

            DGViewTrabajos.DataBindingComplete += DGViewTrabajos_DataBindingComplete;
            DGViewTrabajos.CellFormatting += DGViewTrabajos_CellFormatting;
            DGViewTrabajos.CellContentClick += DGViewTrabajos_CellContentClick;
            DGViewTrabajos.CurrentCellDirtyStateChanged += DGViewTrabajos_CurrentCellDirtyStateChanged;
            DGViewTrabajos.CellValueChanged += DGViewTrabajos_CellValueChanged;

            // --- Ya tenías estos para EmpleadosTrabajo y VehiculosTrabajo ---
            DGViewEmpleadosTrabajo.DataBindingComplete += DGViewEmpleadosTrabajo_DataBindingComplete;
            HideAllNewRows();
        }
        private void CargarVehiculosTrabajo(int trabajoId)
        {
            var dt = TrabajoFunciones.GetVehiculosPorTrabajo(trabajoId);
            DGViewVehiculosTrabajo.DataSource = dt;
            FormatearGridVehiculosTrabajo();
        }
        private void HideAllNewRows()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is DataGridView dgv)
                    dgv.AllowUserToAddRows = false;
            }
        }

        private void FormatearGridVehiculosTrabajo()
        {
            var grid = DGViewVehiculosTrabajo;
            if (grid.Columns.Count == 0) return;

            // Agregar columna "Anulado" enlazada si no existe
            if (!grid.Columns.Contains("Anulado"))
            {
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = "Anulado",
                    HeaderText = "Anulado",
                    DataPropertyName = "Anulado",
                    TrueValue = true,
                    FalseValue = false
                };
                grid.Columns.Insert(0, chk);
            }

            // Sólo esa columna editable
            foreach (DataGridViewColumn col in grid.Columns)
                col.ReadOnly = col.Name != "Anulado";

            // Opcional: ocultar FK y reordenar
            grid.Columns["Vehiculo_ID"].Visible = false;
            grid.Columns["ID"].DisplayIndex = 1;

            grid.ClearSelection();
        }

        // 1) Limpia selección
        private void DGViewVehiculosTrabajo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewVehiculosTrabajo.ClearSelection();
        }

        // 2) Formateo de color
        private void DGViewVehiculosTrabajo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGViewVehiculosTrabajo.Columns[e.ColumnIndex].Name == "Anulado")
            {
                bool anul = e.Value != null && Convert.ToBoolean(e.Value);
                DGViewVehiculosTrabajo.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    anul ? Color.Gray : Color.Gold;
            }
        }

        // 3) Commit al hacer clic
        private void DGViewVehiculosTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                DGViewVehiculosTrabajo.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            DGViewVehiculosTrabajo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 4) Commit al cambiar estado sucio
        private void DGViewVehiculosTrabajo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewVehiculosTrabajo.IsCurrentCellDirty &&
                DGViewVehiculosTrabajo.CurrentCell.OwningColumn.Name == "Anulado")
            {
                DGViewVehiculosTrabajo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 5) Al cambiar valor, actualiza BD y repinta fila
        private void DGViewVehiculosTrabajo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                DGViewVehiculosTrabajo.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewVehiculosTrabajo.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anul = Convert.ToBoolean(row.Cells["Anulado"].Value);

            // Llama al método de datos
            TrabajoFunciones.ActualizarAnuladoVehiculoTrabajo(id, anul);

            // Refresca estilo
            DGViewVehiculosTrabajo.InvalidateRow(e.RowIndex);
        }
        private void CargarEmpleadosTrabajo(int trabajoId)
        {
            var dt = TrabajoFunciones.GetEmpleadosPorTrabajo(trabajoId);
            DGViewEmpleadosTrabajo.DataSource = dt;
            FormatearGridEmpleadosTrabajo();
        }

        private void FormatearGridEmpleadosTrabajo()
        {
            var grid = DGViewEmpleadosTrabajo;
            if (grid.Columns.Count == 0) return;

            // Agregar columna "Anulado" enlazada si no existe
            if (!grid.Columns.Contains("Anulado"))
            {
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = "Anulado",
                    HeaderText = "Anulado",
                    DataPropertyName = "Anulado",
                    TrueValue = true,
                    FalseValue = false
                };
                grid.Columns.Insert(0, chk);
            }

            // Sólo esa columna editable
            foreach (DataGridViewColumn col in grid.Columns)
                col.ReadOnly = col.Name != "Anulado";

            // Para ordenar/ocultar, si lo deseas:
            grid.Columns["ID"].DisplayIndex = 1;
            grid.Columns["Empleado_ID"].Visible = false;

            grid.ClearSelection();
        }

        // 1) Limpia selección
        private void DGViewEmpleadosTrabajo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewEmpleadosTrabajo.ClearSelection();
        }

        // 2) Formateo de color
        private void DGViewEmpleadosTrabajo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGViewEmpleadosTrabajo.Columns[e.ColumnIndex].Name == "Anulado")
            {
                bool anul = e.Value != null && Convert.ToBoolean(e.Value);
                DGViewEmpleadosTrabajo.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    anul ? Color.Gray : Color.Gold;
            }
        }

        // 3) Commit al hacer clic
        private void DGViewEmpleadosTrabajo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                DGViewEmpleadosTrabajo.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            DGViewEmpleadosTrabajo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 4) Commit al cambiar estado sucio
        private void DGViewEmpleadosTrabajo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewEmpleadosTrabajo.IsCurrentCellDirty &&
                DGViewEmpleadosTrabajo.CurrentCell.OwningColumn.Name == "Anulado")
            {
                DGViewEmpleadosTrabajo.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 5) Al cambiar valor, actualiza BD y repinta fila
        private void DGViewEmpleadosTrabajo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 ||
                DGViewEmpleadosTrabajo.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewEmpleadosTrabajo.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anul = Convert.ToBoolean(row.Cells["Anulado"].Value);

            // Llama al método de datos
            TrabajoFunciones.ActualizarAnuladoEmpleadoTrabajo(id, anul);

            // Refresca estilo
            DGViewEmpleadosTrabajo.InvalidateRow(e.RowIndex);
        }
        // 1) Limpia la selección después de bindear
        private void DGViewTrabajos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewTrabajos.ClearSelection();
        }
        
        // 2) Pinta la fila gris si Anulado = true
        private void DGViewTrabajos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGViewTrabajos.Columns[e.ColumnIndex].Name == "Anulado")
            {
                bool an = e.Value != null && Convert.ToBoolean(e.Value);
                DGViewTrabajos.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    an ? Color.Gray : Color.Gold;
            }
        }

        // 3) Commit al hacer clic en el checkbox
        private void DGViewTrabajos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewTrabajos.Columns[e.ColumnIndex].Name != "Anulado")
                return;
            DGViewTrabajos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // 4) Commit al cambiar estado sucio de la celda
        private void DGViewTrabajos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewTrabajos.IsCurrentCellDirty &&
                DGViewTrabajos.CurrentCell.OwningColumn.Name == "Anulado")
            {
                DGViewTrabajos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 5) Al cambiar el valor, actualiza la BD y repinta la fila
        private void DGViewTrabajos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewTrabajos.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewTrabajos.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);

            // Aquí llamas a tu método de datos
            TrabajoFunciones.ActualizarAnulado(id, anulado);

            // Fuerza el repintado para aplicar el estilo
            DGViewTrabajos.InvalidateRow(e.RowIndex);
        }
        // En tu Form (Trabajo.cs)
        // En Trabajo.cs (el Form)
        private void FormatearGridTrabajos()
        {
            var grid = DGViewTrabajos;
            if (grid.Columns.Count == 0) return;

            // 1) Añadir columna "Anulado" si no existe
            if (!grid.Columns.Contains("Anulado"))
            {
                var chk = new DataGridViewCheckBoxColumn
                {
                    Name = "Anulado",
                    HeaderText = "Anulado",
                    DataPropertyName = "Anulado",
                    TrueValue = true,
                    FalseValue = false
                };
                grid.Columns.Insert(0, chk);
            }

            // Helpers seguros
            void SafeIndex(string col, int idx)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].DisplayIndex = idx;
            }
            void SafeHeader(string col, string text)
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].HeaderText = text;
            }

            // 2) Orden y encabezados
            SafeIndex("Anulado", 0);
            SafeIndex("ID", 1);

            SafeIndex("Fecha_Pedido", 2);
            SafeHeader("Fecha_Pedido", "Fecha Pedido");

            SafeIndex("Cliente_ID", 3);   // interno, luego queda oculto
            SafeHeader("Cliente_ID", "Cliente ID");

            SafeIndex("Cliente_Nombre", 4);
            SafeHeader("Cliente_Nombre", "Cliente");

            SafeIndex("Trabajo_Realizar", 5);
            SafeHeader("Trabajo_Realizar", "Trabajo Realizar");

            SafeIndex("Presupuesto", 6);
            SafeHeader("Presupuesto", "Presupuesto");

            SafeIndex("Observacion", 7);
            SafeHeader("Observacion", "Observación");

            SafeIndex("Lugar_Trabajo", 8);
            SafeHeader("Lugar_Trabajo", "Lugar de Trabajo");

            SafeIndex("Completado", 9);
            SafeHeader("Completado", "Completado");

            SafeIndex("Fecha_Inicio", 10);
            SafeHeader("Fecha_Inicio", "Fecha Inicio");

            SafeIndex("Fecha_Fin", 11);
            SafeHeader("Fecha_Fin", "Fecha Fin");

            // 3) Ocultar Cliente_ID para el usuario
            if (grid.Columns.Contains("Cliente_ID"))
                grid.Columns["Cliente_ID"].Visible = false;

            // 4) Sólo "Anulado" editable
            foreach (DataGridViewColumn c in grid.Columns)
                c.ReadOnly = c.Name != "Anulado";

            // 5) Refrescar formateo
            grid.CellFormatting -= DGViewTrabajos_CellFormatting;
            grid.CellFormatting += DGViewTrabajos_CellFormatting;

            // 6) Limpiar selección
            grid.ClearSelection();


        }
        // Cargar lista general de empleados
        private void CargarEmpleados()
        {
            var dt = TrabajoFunciones.BuscarEmpleadosPorNombre(txtEmpleado.Text.Trim());
            DGViewEmpleados.DataSource = dt;   // sólo trae Activo = 1
            DGViewEmpleados.ClearSelection();
        }

        // Cargar lista general de vehículos
        private void CargarVehiculos()
        {
            var dt = TrabajoFunciones.BuscarVehiculosPorNombre(txtVehiculo.Text.Trim());
            DGViewVehiculos.DataSource = dt;   // sólo trae Activo = 1
            DGViewVehiculos.ClearSelection();
        }
        private void DGViewTrabajos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = DGViewTrabajos.Rows[e.RowIndex];

            txtID.Text = fila.Cells["ID"].Value?.ToString();

            dtpFechaPedido.Value = fila.Cells["Fecha_Pedido"].Value != DBNull.Value
                ? Convert.ToDateTime(fila.Cells["Fecha_Pedido"].Value)
                : DateTime.Now;

            txtTrabajoRealizar.Text = fila.Cells["Trabajo_Realizar"].Value?.ToString();
            txtPresupuesto.Text = fila.Cells["Presupuesto"].Value?.ToString();
            txtObservacion.Text = fila.Cells["Observacion"].Value?.ToString();

            bool completado = fila.Cells["Completado"].Value != DBNull.Value &&
                              Convert.ToBoolean(fila.Cells["Completado"].Value);
            chkCompletado.Checked = completado;

            txtLugarTrabajo.Text = fila.Cells["Lugar_Trabajo"].Value?.ToString();

            dtpFechaInicio.Value = fila.Cells["Fecha_Inicio"].Value != DBNull.Value
                ? Convert.ToDateTime(fila.Cells["Fecha_Inicio"].Value)
                : DateTime.Now;

            dtpFechaFin.Value = (completado && fila.Cells["Fecha_Fin"].Value != DBNull.Value)
                ? Convert.ToDateTime(fila.Cells["Fecha_Fin"].Value)
                : dtpFechaInicio.Value;

            // Verificación correcta de columnas existentes
            if (DGViewTrabajos.Columns.Contains("Cliente_ID"))
                txtClienteID.Text = fila.Cells["Cliente_ID"].Value?.ToString();
            if (DGViewTrabajos.Columns.Contains("Cliente_Nombre"))
                txtCliente.Text = fila.Cells["Cliente_Nombre"].Value?.ToString();

            if (int.TryParse(txtID.Text, out int trabajoId))
            {
                CargarEmpleadosTrabajo(trabajoId);
                CargarVehiculosTrabajo(trabajoId);
            }
        }
        private void CargarTrabajos()
        {
            DGViewTrabajos.DataSource = TrabajoFunciones.RegistroTrabajo();
            FormatearGridTrabajos();
        }
      
   
        // txtEmpleado → Nombre **o** Apellido
        private void BttnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            var texto = txtEmpleado.Text.Trim();
            DGViewEmpleados.DataSource = TrabajoFunciones.BuscarEmpleadosPorNombre(texto);
            DGViewEmpleados.ClearSelection();
        }

        // txtVehiculo → Patente
        private void BttnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            var texto = txtVehiculo.Text.Trim();
            DGViewVehiculos.DataSource = TrabajoFunciones.BuscarVehiculosPorPatente(texto);
            DGViewVehiculos.ClearSelection();
        }
        private void BttnBuscar_Click(object sender, EventArgs e)
        {
            DataTable resultado;

            // 1) Si txtBuscarID es numérico → filtrar por ID de trabajo
            if (int.TryParse(txtBuscarID.Text.Trim(), out int idTrabajo) && idTrabajo > 0)
            {
                resultado = TrabajoFunciones.BuscarTrabajos(id: idTrabajo,
                                                           clienteId: null,
                                                           fechaPedido: null);
            }
            // 2) Si txtBuscarClienteID tiene texto → buscar clientes por nombre/apellido
            else if (!string.IsNullOrWhiteSpace(txtBuscarClienteID.Text))
            {
                // 2.1) Obtener clientes que coincidan
                var dtClientes = TrabajoFunciones.BuscarClientesPorNombre(txtBuscarClienteID.Text.Trim());
                if (dtClientes.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron clientes con ese texto.",
                                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resultado = new DataTable();
                }
                else
                {
                    // 2.2) Para cada cliente encontrado, llamar a BuscarTrabajos pasando su ID
                    resultado = new DataTable();
                    bool primera = true;
                    foreach (DataRow cli in dtClientes.Rows)
                    {
                        int cliId = Convert.ToInt32(cli["ID"]);
                        var dtTrab = TrabajoFunciones.BuscarTrabajos(id: null,
                                                                    clienteId: cliId,
                                                                    fechaPedido: null);
                        if (primera)
                        {
                            // Al primer merge, clonar estructura
                            resultado = dtTrab.Clone();
                            primera = false;
                        }
                        resultado.Merge(dtTrab);
                    }
                }
            }
            // 3) Si hay fecha seleccionada → filtrar por Fecha_Pedido
            else if (dtpBuscarFecha.Checked)
            {
                resultado = TrabajoFunciones.BuscarTrabajos(id: null,
                                                           clienteId: null,
                                                           fechaPedido: dtpBuscarFecha.Value.Date);
            }
            // 4) Ningún filtro → mostrar todos
            else
            {
                resultado = TrabajoFunciones.RegistroTrabajo();
            }

            DGViewTrabajos.DataSource = resultado;
            FormatearGridTrabajos();
        }
        private void Trabajo_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarClientes();
            CargarEmpleados();
            CargarVehiculos();
            CargarTrabajos();
        }
        private void BttnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarTrabajos();
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            dtpFechaPedido.Value = DateTime.Now;
            txtTrabajoRealizar.Clear();
            txtPresupuesto.Clear();
            txtObservacion.Clear();
            chkCompletado.Checked = false;
            txtLugarTrabajo.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtCliente.Clear();
            txtClienteID.Clear();
            DGViewClientes.ClearSelection();
            txtEmpleado.Clear();
            txtEmpleadoID.Clear();
            txtValorEmpleado.Clear();
            txtObservacionEmpleado.Clear();
            DGViewEmpleados.ClearSelection();
            txtVehiculo.Clear();
            txtVehiculoID.Clear();
            DGViewVehiculos.ClearSelection();
            txtBuscarClienteID.Clear();
            dtpBuscarFecha.Value = DateTime.Now;
            DGViewTrabajos.ClearSelection();
        }

        private void DGViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = DGViewClientes.Rows[e.RowIndex];
            txtClienteID.Text = fila.Cells["ID"].Value?.ToString();
            txtCliente.Text = $"{fila.Cells["Nombre"].Value} {fila.Cells["Apellido"].Value}";
            DGViewClientes.ClearSelection();
        }

        private void DGViewEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = DGViewEmpleados.Rows[e.RowIndex];
            txtEmpleadoID.Text = fila.Cells["ID"].Value?.ToString();
            txtEmpleado.Text = $"{fila.Cells["Nombre"].Value} {fila.Cells["Apellido"].Value}";
            DGViewEmpleados.ClearSelection();
        }

        private void DGViewVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = DGViewVehiculos.Rows[e.RowIndex];
            txtVehiculoID.Text = fila.Cells["ID"].Value?.ToString();
            txtVehiculo.Text = $"{fila.Cells["Nombre"].Value} - {fila.Cells["Patente"].Value}";
            DGViewVehiculos.ClearSelection();
        }
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnVolver_Click(object sender, EventArgs e)
        {
            var frmMenu = new Menu();
            this.Hide();
            frmMenu.Show();
        }
        private void bttnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtClienteID.Text))
                {
                    MessageBox.Show("Seleccione un cliente.");
                    return;
                }
                var trabajo = new TrabajoPuente
                {
                    Fecha_Pedido = dtpFechaPedido.Value,
                    Trabajo_Realizar = txtTrabajoRealizar.Text,
                    Presupuesto = txtPresupuesto.Text,
                    Observacion = txtObservacion.Text,
                    Completado = chkCompletado.Checked,
                    Lugar_Trabajo = txtLugarTrabajo.Text,
                    Fecha_Inicio = dtpFechaInicio.Value,
                    Fecha_Fin = chkCompletado.Checked ? dtpFechaFin.Value : (DateTime?)null,
                    Cliente_ID = int.Parse(txtClienteID.Text)
                };
                int result;
                if (string.IsNullOrEmpty(txtID.Text))
                {
                    result = TrabajoFunciones.AgregarTrabajo(trabajo);
                    MessageBox.Show(result > 0 ? "Trabajo agregado con éxito." : "Error al agregar el trabajo.");
                }
                else
                {
                    trabajo.ID = int.Parse(txtID.Text);
                    result = TrabajoFunciones.ModificarTrabajo(trabajo);
                    MessageBox.Show(result > 0 ? "Trabajo modificado con éxito." : "Error al modificar el trabajo.");
                }
                LimpiarCampos();
                CargarTrabajos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CargarClientes()
        {
            try
            {
                var dt = TrabajoFunciones.BuscarClientesPorNombre(txtCliente.Text.Trim());
                DGViewClientes.DataSource = dt;
                DGViewClientes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
        private void BttnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int trabajoId) || trabajoId <= 0)
            {
                MessageBox.Show("Seleccione primero un trabajo válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtEmpleadoID.Text, out int empId) || empId <= 0)
            {
                MessageBox.Show("Seleccione primero un empleado válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int valor = int.TryParse(txtValorEmpleado.Text, out var v) ? v : 0;
            string obs = txtObservacionEmpleado.Text.Trim();

            try
            {
                int filas = TrabajoFunciones.AgregarEmpleadoATrabajo(trabajoId, empId, valor, obs);
                MessageBox.Show(
                    filas > 0
                      ? "Empleado vinculado correctamente al trabajo."
                      : "No se vinculó ningún registro.",
                    "Resultado",
                    MessageBoxButtons.OK,
                    filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );
                DGViewEmpleadosTrabajo.DataSource = TrabajoFunciones.VerEmpleadosTrabajo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al vincular empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarEmpleadosTrabajo()
        {
            DGViewEmpleadosTrabajo.DataSource = TrabajoFunciones.VerEmpleadosTrabajo();
            DGViewEmpleadosTrabajo.ClearSelection();
        }
        private void BttnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtID.Text, out int trabajoId) || trabajoId <= 0)
            {
                MessageBox.Show("Seleccione primero un trabajo válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtVehiculoID.Text, out int vehId) || vehId <= 0)
            {
                MessageBox.Show("Seleccione primero un vehículo válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int filas = TrabajoFunciones.AgregarVehiculoATrabajo(trabajoId, vehId);
                MessageBox.Show(
                    filas > 0
                      ? "Vehículo vinculado correctamente al trabajo."
                      : "No se vinculó ningún registro.",
                    "Resultado",
                    MessageBoxButtons.OK,
                    filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error
                );
                DGViewVehiculosTrabajo.DataSource = TrabajoFunciones.VerVehiculosTrabajo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al vincular vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarVehiculosTrabajo()
        {
            DGViewVehiculosTrabajo.DataSource = TrabajoFunciones.VerVehiculosTrabajo();
            DGViewVehiculosTrabajo.ClearSelection();
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
