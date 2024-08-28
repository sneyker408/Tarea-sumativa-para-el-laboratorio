using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // Para manejar configuraciones desde App.config o Web.config
using System.Xml.Linq;
using System.Data.SqlClient; // Para trabajar con conexiones SQL
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    // Clase que maneja la conexión a la base de datos
    public class DataBase
    {
        // Propiedad estática que obtiene la cadena de conexión desde el archivo de configuración
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión llamada "NWConnection" desde el archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Construye un objeto SqlConnectionStringBuilder basado en la cadena de conexión obtenida
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Si ApplicationName ha sido configurado, lo asigna a la cadena de conexión
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Configura el tiempo de espera de la conexión si se ha definido un valor mayor a 0
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión configurada
                return conexionBuilder.ToString();
            }
        }

        // Propiedad estática que almacena el tiempo de espera para la conexión (en segundos)
        public static int ConnectionTimeout { get; set; }

        // Propiedad estática que almacena el nombre de la aplicación que se conectará a la base de datos
        public static string ApplicationName { get; set; }

        // Método estático para obtener una instancia de SqlConnection abierta
        public static SqlConnection GetSqlConnection()
        {
            // Crea una nueva conexión SQL utilizando la cadena de conexión configurada
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión
            conexion.Open();

            // Devuelve la conexión abierta
            return conexion;
        }
    }
}
