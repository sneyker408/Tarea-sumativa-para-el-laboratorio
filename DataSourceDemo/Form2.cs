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
    public partial class Form2 : Form
    {
        // Constructor del formulario
        public Form2()
        {
            InitializeComponent(); // Inicializa los componentes del formulario (generado automáticamente por el diseñador de Windows Forms)
        }

        // Evento que se dispara cuando se hace clic en el botón de guardar en el BindingNavigator
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate(); // Valida los datos en los controles asociados al formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición en el origen de datos BindingSource
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Guarda todos los cambios en el DataSet "northwindDataSet" a la base de datos
        }

        // Evento que se dispara cuando el formulario se carga
        private void Form2_Load(object sender, EventArgs e)
        {
            // Carga datos en la tabla "Customers" del DataSet "northwindDataSet". 
            // Esta línea es generada por el diseñador y se puede mover o eliminar según las necesidades.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Evento que se dispara cuando se hace clic en el control de texto (TextBox) "cajaTextoID"
        private void cajaTextoID_Click(object sender, EventArgs e)
        {
            // Este método está vacío; podría usarse para manejar el clic en el TextBox si es necesario
        }

        // Evento que se dispara cuando se presiona una tecla en el TextBox "cajaTextoID"
        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es Enter (código 13)
            if (e.KeyChar == (char)13)
            {
                // Busca en el BindingSource el índice del registro que coincide con el valor de "customerID" en "cajaTextoID"
                var index = customersBindingSource.Find("customerID", cajaTextoID);

                // Si el índice es válido, posiciona el BindingSource en el registro encontrado
                if (index > -1)
                {
                    customersBindingSource.Position = index;
                    return;
                }
                else
                {
                    // Si no se encuentra el elemento, muestra un mensaje
                    MessageBox.Show("Elemento no encontrado");
                }
            }
        }
    }
}
