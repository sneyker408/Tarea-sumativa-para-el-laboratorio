using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita los estilos visuales para la aplicación, permitiendo utilizar
            // la apariencia más moderna de los controles estándar de Windows.
            Application.EnableVisualStyles();

            // Establece la compatibilidad de renderizado de texto para los controles.
            // 'false' indica que se utilizará el renderizado de texto de GDI+ en lugar de GDI.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la aplicación y muestra el formulario principal (Form1).
            // La aplicación continuará ejecutándose hasta que este formulario se cierre.
            Application.Run(new Form1());
        }
    }
}
