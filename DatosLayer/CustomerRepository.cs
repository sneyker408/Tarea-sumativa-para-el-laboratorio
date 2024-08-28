﻿using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    // Repositorio para manejar las operaciones relacionadas con la entidad "Customers"
    public class CustomerRepository
    {
        // Método para obtener todos los registros de la tabla "Customers"
        public List<Customers> ObtenerTodos()
        {
            // Abre una conexión a la base de datos utilizando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL para seleccionar todas las columnas de la tabla "Customers"
                String selectFrom = "";
                selectFrom = selectFrom + "SELECT [CustomerID] " + "\n";
                selectFrom = selectFrom + "      ,[CompanyName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactName] " + "\n";
                selectFrom = selectFrom + "      ,[ContactTitle] " + "\n";
                selectFrom = selectFrom + "      ,[Address] " + "\n";
                selectFrom = selectFrom + "      ,[City] " + "\n";
                selectFrom = selectFrom + "      ,[Region] " + "\n";
                selectFrom = selectFrom + "      ,[PostalCode] " + "\n";
                selectFrom = selectFrom + "      ,[Country] " + "\n";
                selectFrom = selectFrom + "      ,[Phone] " + "\n";
                selectFrom = selectFrom + "      ,[Fax] " + "\n";
                selectFrom = selectFrom + "  FROM [dbo].[Customers]";

                // Ejecuta la consulta SQL
                using (SqlCommand comando = new SqlCommand(selectFrom, conexion))
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    List<Customers> Customers = new List<Customers>();

                    // Lee cada fila de la consulta y la agrega a la lista de clientes
                    while (reader.Read())
                    {
                        var customers = LeerDelDataReader(reader);
                        Customers.Add(customers);
                    }
                    return Customers;
                }
            }
        }

        // Método para obtener un cliente por su ID
        public Customers ObtenerPorID(string id)
        {

            // Abre una conexión a la base de datos utilizando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {

                // Cadena SQL para seleccionar un cliente específico por su ID
                String selectForID = "";
                selectForID = selectForID + "SELECT [CustomerID] " + "\n";
                selectForID = selectForID + "      ,[CompanyName] " + "\n";
                selectForID = selectForID + "      ,[ContactName] " + "\n";
                selectForID = selectForID + "      ,[ContactTitle] " + "\n";
                selectForID = selectForID + "      ,[Address] " + "\n";
                selectForID = selectForID + "      ,[City] " + "\n";
                selectForID = selectForID + "      ,[Region] " + "\n";
                selectForID = selectForID + "      ,[PostalCode] " + "\n";
                selectForID = selectForID + "      ,[Country] " + "\n";
                selectForID = selectForID + "      ,[Phone] " + "\n";
                selectForID = selectForID + "      ,[Fax] " + "\n";
                selectForID = selectForID + $"  Where CustomerID = @customerId";

                // Ejecuta la consulta SQL
                using (SqlCommand comando = new SqlCommand(selectForID, conexion))
                {
                    // Agrega el parámetro de ID a la consulta
                    comando.Parameters.AddWithValue("customerId", id);

                    var reader = comando.ExecuteReader();
                    Customers customers = null;

                    // Si se encuentra un registro, se convierte en un objeto Customers
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader);
                    }
                    return customers;
                }
            }
        }

        // Método para mapear los datos de un SqlDataReader a un objeto Customers
        public Customers LeerDelDataReader(SqlDataReader reader)
        {

            Customers customers = new Customers();
            // Mapea cada columna del lector a una propiedad del objeto Customers, verificando si es DBNull
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];
            return customers;
        }

        // Método para insertar un nuevo cliente en la base de datos
        public int InsertarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos utilizando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL para insertar un nuevo registro en la tabla "Customers"
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Ejecuta la consulta SQL
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    // Llama al método para agregar parámetros y ejecutar la consulta
                    int insertados = parametrosCliente(customer, comando);
                    return insertados;
                }
            }
        }

        // Método para actualizar un cliente existente en la base de datos
        public int ActualizarCliente(Customers customer)
        {
            // Abre una conexión a la base de datos utilizando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL para actualizar un registro en la tabla "Customers" basado en su ID
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";

                // Ejecuta la consulta SQL
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    // Llama al método para agregar parámetros y ejecutar la consulta
                    int actualizados = parametrosCliente(customer, comando);
                    return actualizados;
                }
            }
        }

        // Método para agregar parámetros a la consulta SQL y ejecutarla
        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactName);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer

.City);
            var insertados = comando.ExecuteNonQuery(); // Ejecuta la consulta y devuelve el número de filas afectadas
            return insertados;
        }

        // Método para eliminar un cliente de la base de datos por su ID
        public int EliminarCliente(string id)
        {
            // Abre una conexión a la base de datos utilizando un método de la clase DataBase
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Cadena SQL para eliminar un registro en la tabla "Customers" basado en su ID
                String EliminarCliente = "";
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n";
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID";

                // Ejecuta la consulta SQL
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    // Agrega el parámetro de ID a la consulta
                    comando.Parameters.AddWithValue("@CustomerID", id);
                    int elimindos = comando.ExecuteNonQuery(); // Ejecuta la consulta y devuelve el número de filas eliminadas
                    return elimindos;
                }
            }
        }
    }
}