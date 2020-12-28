using Indicador_de_acciones_Calidad.Vistas;
using System;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Separador());
        }
    }
}
