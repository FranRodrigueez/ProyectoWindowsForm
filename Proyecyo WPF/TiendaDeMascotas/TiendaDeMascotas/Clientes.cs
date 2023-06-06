using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaDeMascotas.Clases;
using TiendaDeMascotas.Repositorios;

namespace TiendaDeMascotas
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
            MostrarClientes();
            InitializeLabelEvents();

            // Asignar el evento SelectionChanged al GunaDataGridView
            ClientesDGV.SelectionChanged += ClientesDGV_SelectionChanged;
        }

        private void InitializeLabelEvents()
        {
            Inicio.MouseEnter += Label_MouseEnter;
            Inicio.MouseLeave += Label_MouseLeave;
            Productos.MouseEnter += Label_MouseEnter;
            Productos.MouseLeave += Label_MouseLeave;
            Empleados.MouseEnter += Label_MouseEnter;
            Empleados.MouseLeave += Label_MouseLeave;
            //Facturas.MouseEnter += Label_MouseEnter;
            //Facturas.MouseLeave += Label_MouseLeave;
            Salir.MouseEnter += Label_MouseEnter;
            Salir.MouseLeave += Label_MouseLeave;
        }

        private void Label_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Cursor = Cursors.Hand;
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Cursor = Cursors.Default;
        }

        private void ClientesDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (ClientesDGV.SelectedRows.Count > 0)
            {
                // Obtener los datos del empleado seleccionado
                string nombre = ClientesDGV.SelectedRows[0].Cells["ClienteNombre"].Value.ToString();
                string direccion = ClientesDGV.SelectedRows[0].Cells["ClienteDireccion"].Value.ToString();
                string telefono = ClientesDGV.SelectedRows[0].Cells["ClienteTelefono"].Value.ToString();

                // Mostrar los datos en los cuadros de texto
                ClienteNombre.Text = nombre;
                ClienteDireccion.Text = direccion;
                ClienteTelefono.Text = telefono;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MostrarClientes()
        {
            try
            {
                // Obtener la conexión a la base de datos
                using (SqlConnection conn = ClienteRepositorio.ObtenerConexion())
                {
                    // Consultar los productos en la base de datos
                    string selectQuery = "SELECT ClienteID, ClienteNombre, ClienteDireccion, ClienteTelefono FROM Clientes";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crear una tabla temporal para almacenar los datos de los productos
                    DataTable clientesTable = new DataTable();
                    clientesTable.Load(reader);

                    // Asignar la tabla temporal como origen de datos del GunaDataGridView
                    ClientesDGV.DataSource = clientesTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los clientes: " + ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            Empleadoos empleadoForm = new Empleadoos();
            empleadoForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Clientes ClienteForm = new Clientes();
            ClienteForm.Show();
        }

        private void Productos_Click(object sender, EventArgs e)
        {
            Productos productoForm = new Productos();
            productoForm.Show();
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            Home inicioForm = new Home();
            inicioForm.Show();
        }

        private void ClienteNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (ClienteNombre.Text == "" || ClienteDireccion.Text == "" || ClienteTelefono.Text == "")
            {
                MessageBox.Show("Error. Introduzca la información completa");
            }
            else
            {
                try
                {

                    ClassCliente cliente = new ClassCliente();
                    cliente.nombreCliente = ClienteNombre.Text;
                    cliente.direccionCliente = ClienteDireccion.Text;
                    cliente.telefonoCliente = ClienteTelefono.Text;



                    if (ClienteRepositorio.Agregar(cliente) == 1) { MessageBox.Show("Cliente añadido"); } else { MessageBox.Show("error"); }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MostrarClientes();

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (ClientesDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de empleado de la fila seleccionada
                int clienteNum = Convert.ToInt32(ClientesDGV.SelectedRows[0].Cells["ClienteID"].Value);

                // Obtener los datos modificados de las cajas de texto
                string nuevoNombre = ClienteNombre.Text;
                string nuevaDireccion = ClienteDireccion.Text;
                string nuevoTelefono = ClienteTelefono.Text;

                // Actualizar los datos en el GunaDataGridView
                ClientesDGV.SelectedRows[0].Cells["ClienteNombre"].Value = nuevoNombre;
                ClientesDGV.SelectedRows[0].Cells["ClienteDireccion"].Value = nuevaDireccion;
                ClientesDGV.SelectedRows[0].Cells["ClienteTelefono"].Value = nuevoTelefono;

                // Actualizar los datos en la base de datos
                if (ClienteRepositorio.Actualizar(clienteNum, nuevoNombre, nuevaDireccion, nuevoTelefono))
                {
                    MessageBox.Show("Datos actualizados correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al actualizar los datos en la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.");
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (ClientesDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de producto de la fila seleccionada
                int clienteNum = Convert.ToInt32(ClientesDGV.SelectedRows[0].Cells["ClienteID"].Value);

                // Eliminar el producto del GunaDataGridView
                ClientesDGV.Rows.RemoveAt(ClientesDGV.SelectedRows[0].Index);

                // Eliminar el producto de la base de datos
                if (ClienteRepositorio.Eliminar(clienteNum))
                {
                    MessageBox.Show("Cliente eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para borrar.");
            }
        }
    }
}
