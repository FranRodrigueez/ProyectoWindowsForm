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

namespace TiendaDeMascotas
{
    public partial class Empleadoos : Form
    {
        public Empleadoos()
        {
            InitializeComponent();          
            MostrarEmpleados();

            // Configurar la columna para mostrar el número de empleado
            EmpleadoDGV.Columns["EmpNum"].Visible = true;

            // Asignar el evento SelectionChanged al GunaDataGridView
            EmpleadoDGV.SelectionChanged += EmpleadoDGV_SelectionChanged;

            InitializeLabelEvents();

        }
        private void InitializeLabelEvents()
        {
            Inicio.MouseEnter += Label_MouseEnter;
            Inicio.MouseLeave += Label_MouseLeave;
            Productos.MouseEnter += Label_MouseEnter;
            Productos.MouseLeave += Label_MouseLeave;
            Clientes.MouseEnter += Label_MouseEnter;
            Clientes.MouseLeave += Label_MouseLeave;           
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

        private void EmpleadoDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (EmpleadoDGV.SelectedRows.Count > 0)
            {
                // Obtener los datos del empleado seleccionado
                string nombre = EmpleadoDGV.SelectedRows[0].Cells["EmpNombre"].Value.ToString();
                string direccion = EmpleadoDGV.SelectedRows[0].Cells["EmpDireccion"].Value.ToString();
                string telefono = EmpleadoDGV.SelectedRows[0].Cells["EmpTelefono"].Value.ToString();
                string contraseña = EmpleadoDGV.SelectedRows[0].Cells["EmpContraseña"].Value.ToString();

                // Mostrar los datos en los cuadros de texto
                EmpleadoNombre.Text = nombre;
                EmpleadoDireccion.Text = direccion;
                EmpleadoTelefono.Text = telefono;
                EmpleadoContraseña.Text = contraseña;
            }
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (EmpleadoDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de empleado de la fila seleccionada
                int empNum = Convert.ToInt32(EmpleadoDGV.SelectedRows[0].Cells["EmpNum"].Value);

                // Eliminar el empleado del GunaDataGridView
                EmpleadoDGV.Rows.RemoveAt(EmpleadoDGV.SelectedRows[0].Index);

                // Eliminar el empleado de la base de datos
                if (EmpleadoRepository.Eliminar(empNum))
                {
                    MessageBox.Show("Empleado eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el empleado de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para borrar.");
            }
        }

        private void GuardarEmpleado_Click(object sender, EventArgs e)
        {
            if (EmpleadoNombre.Text == "" || EmpleadoTelefono.Text == "" || EmpleadoContraseña.Text == "" || EmpleadoDireccion.Text == "")
            {
                MessageBox.Show("Error. Introduzca la información completa");
            }
            else
            {
                try
                {

                    ClassEmpleado empleado = new ClassEmpleado();
                    empleado.nombre = EmpleadoNombre.Text;
                    empleado.direccion = EmpleadoDireccion.Text;
                    empleado.telefono = EmpleadoTelefono.Text;
                    empleado.contraseña = EmpleadoContraseña.Text;
                   


                    if (EmpleadoRepository.Agregar(empleado) == 1) { MessageBox.Show("Usuario añadido"); } else { MessageBox.Show("error"); }                   

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MostrarEmpleados();
        }

        private void MostrarEmpleados()
        {
            try
            {
                // Obtener la conexión a la base de datos
                using (SqlConnection conn = EmpleadoRepository.ObtenerConexion())
                {
                    // Consultar los empleados en la base de datos
                    string selectQuery = "SELECT EmpNum, EmpNombre, EmpDireccion, EmpTelefono, EmpContraseña FROM Empleados";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crear una tabla temporal para almacenar los datos de los empleados
                    DataTable empleadosTable = new DataTable();
                    empleadosTable.Load(reader);

                    // Asignar la tabla temporal como origen de datos del GunaDataGridView
                    EmpleadoDGV.DataSource = empleadosTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los empleados: " + ex.Message);
            }
        }
    
        private void EmpleadoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpleadoCumpleaños_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EditarEmpleado_Click(object sender, EventArgs e)
        {
            if (EmpleadoDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de empleado de la fila seleccionada
                int empNum = Convert.ToInt32(EmpleadoDGV.SelectedRows[0].Cells["EmpNum"].Value);

                // Obtener los datos modificados de las cajas de texto
                string nuevoNombre = EmpleadoNombre.Text;
                string nuevaDireccion = EmpleadoDireccion.Text;
                string nuevoTelefono = EmpleadoTelefono.Text;
                string nuevaContraseña = EmpleadoContraseña.Text;

                // Actualizar los datos en el GunaDataGridView
                EmpleadoDGV.SelectedRows[0].Cells["EmpNombre"].Value = nuevoNombre;
                EmpleadoDGV.SelectedRows[0].Cells["EmpDireccion"].Value = nuevaDireccion;
                EmpleadoDGV.SelectedRows[0].Cells["EmpTelefono"].Value = nuevoTelefono;
                EmpleadoDGV.SelectedRows[0].Cells["EmpContraseña"].Value = nuevaContraseña;

                // Actualizar los datos en la base de datos
                if (EmpleadoRepository.Actualizar(empNum, nuevoNombre, nuevaDireccion, nuevoTelefono, nuevaContraseña))
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

        private void EmpleadoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Productos_Click(object sender, EventArgs e)
        {
            Productos productosForm = new Productos();
            productosForm.Show();
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            Home inicioForm = new Home();
            inicioForm.Show();
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            Clientes clienteForm = new Clientes();
            clienteForm.Show();
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            Empleadoos empleadoForm = new Empleadoos();
            empleadoForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
