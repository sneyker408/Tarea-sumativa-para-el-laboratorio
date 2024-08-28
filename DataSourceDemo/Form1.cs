using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // Espacio de nombres para trabajar con formularios en Windows

namespace DataSourceDemo
{
    public partial class Form1 : Form
    {
        // Constructor del formulario
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario (generado automáticamente por el diseñador de Windows Forms)
        }

        // Evento que se dispara cuando se hace clic en el botón de guardar en el BindingNavigator
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            GuardarDatos(); // Llama al método que valida, finaliza la edición y guarda los cambios
        }

        // Otro evento para guardar, puede estar asignado a un diferente botón o acción
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            GuardarDatos(); // Llama al método para guardar los datos
        }

        // Un tercer evento para guardar, posiblemente un duplicado o asignado por error
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            GuardarDatos(); // Llama al mismo método de guardado
        }

        // Método que contiene la lógica común para guardar datos
        private void GuardarDatos()
        {
            this.Validate(); // Valida los datos en los controles asociados al formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición en el origen de datos BindingSource
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Guarda todos los cambios en el DataSet "northwindDataSet" a la base de datos
        }

        // Evento que se dispara cuando el formulario se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla "Customers" del DataSet "northwindDataSet". 
            // Esta línea es generada por el diseñador y se puede mover o eliminar según las necesidades.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Evento que se dispara cuando se hace clic en una celda del DataGridView "customersDataGridView"
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este método está vacío; podría usarse para manejar clics en celdas específicas si es necesario
        }
    }
}
