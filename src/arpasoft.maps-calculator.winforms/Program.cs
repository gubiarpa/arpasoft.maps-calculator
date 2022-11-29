using arpasoft.maps_calculator.infrastructure.Services;
using arpasoft.maps_calculator.winforms.Utils;

namespace arpasoft.maps_calculator.winforms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmMain(new MapService<Coordinate>()));
        }
    }
}