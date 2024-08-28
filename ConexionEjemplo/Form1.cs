using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;

namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Instancia del repositorio de clientes para manejar las operaciones con la base de datos
        CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se dispara cuando se hace clic en el botón de cargar
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Carga todos los clientes desde el repositorio y los asigna al DataGridView
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        // Evento que se dispara cuando el texto del textbox de filtro cambia
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Se comentaron líneas para aplicar un filtro a la lista de clientes en función del texto ingresado
        }

        // Evento que se dispara cuando el formulario se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Se comenta código relacionado con la configuración de la base de datos
        }

        // Evento que se dispara cuando se hace clic en el botón de buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente por su ID y muestra los detalles en los textbox correspondientes
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Evento para el clic en una etiqueta, sin lógica implementada
        }

        // Evento que se dispara cuando se hace clic en el botón de insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            // Crea un nuevo cliente basado en los datos ingresados en los textbox
            var nuevoCliente = ObtenerNuevoCliente();

            // Si todos los campos están completos, intenta insertar el nuevo cliente
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + " Filas modificadas = " + resultado);
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método que valida si algún campo del objeto pasado como parámetro está vacío
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if ((string)value == "")
                {
                    return true;
                }
            }
            return false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Evento para el clic en una etiqueta, sin lógica implementada
        }

        // Evento que se dispara cuando se hace clic en el botón de modificar
        private void btModificar_Click(object sender, EventArgs e)
        {
            // Actualiza los datos del cliente en la base de datos
            var actualizarCliente = ObtenerNuevoCliente();
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Método que crea y retorna un nuevo objeto de tipo Customers con los datos de los textbox
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;
        }

        // Evento que se dispara cuando se hace clic en el botón de eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Elimina el cliente de la base de datos según el ID ingresado
            int elimindas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + elimindas);
        }
    }
}
