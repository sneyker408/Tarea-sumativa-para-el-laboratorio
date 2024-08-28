using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms; // Espacio de nombres para trabajar con formularios en Windows

namespace DataSourceDemo
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread] // Atributo que indica que el modelo de subprocesamiento COM de la aplicación es STA (Single-Threaded Apartment)
        static void Main()
        {
            // Habilita estilos visuales para la aplicación. Esto hace que los controles de Windows Forms tengan la apariencia visual actual del sistema operativo.
            Application.EnableVisualStyles();

            // Establece si el motor de renderizado de texto utilizado por los controles coincide con la configuración de compatibilidad. False usa el motor de renderizado predeterminado.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la ejecución de la aplicación y muestra el formulario principal. Aquí se especifica Form2 como el formulario que se mostrará al iniciar la aplicación.
            Application.Run(new Form2());
        }
    }
}
