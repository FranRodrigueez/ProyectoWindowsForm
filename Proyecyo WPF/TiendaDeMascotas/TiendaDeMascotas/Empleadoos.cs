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
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

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
                    string selectQuery = "SELECT EmpNombre, EmpDireccion, EmpTelefono, EmpContraseña FROM Empleados";
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

        }
    }
}
