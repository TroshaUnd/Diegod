namespace Diegod
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Un solo Diegod abierto a la vez (evita dos ventanas escribiendo la misma base).
            using var mutex = new Mutex(true, @"Local\Diegod.App.SingleInstance", out bool esPrimera);
            if (!esPrimera)
            {
                MessageBox.Show("Diegod ya está abierto.", "Diegod",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => MostrarError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => MostrarError(e.ExceptionObject as Exception);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Crea la base de datos local (diegod.db) y sus tablas la primera vez.
                BaseDatos.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo preparar la base de datos local:\n\n" + ex.Message +
                                "\n\nRuta: " + (Environment.GetEnvironmentVariable("DIEGOD_DB") ?? "%LocalAppData%\\Diegod\\diegod.db"),
                                "Diegod", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }

        private static void MostrarError(Exception? ex)
        {
            try
            {
                string carpeta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Diegod");
                Directory.CreateDirectory(carpeta);
                File.AppendAllText(Path.Combine(carpeta, "errores.log"),
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex}\r\n\r\n");
            }
            catch { /* el log nunca debe impedir mostrar el error */ }

            MessageBox.Show("Ocurrió un error inesperado:\n\n" + (ex?.Message ?? "desconocido"),
                            "Diegod", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
