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
                    //empleado.cumpleaños = EmpleadoCumpleaños.Value.Date;


                    if (EmpleadoRepository.Agregar(empleado) == 1) { MessageBox.Show("Usuario añadido"); } else { MessageBox.Show("error"); }
                    //        MessageBox.Show("hola2");
                    //        SqlCommand comando = new SqlCommand(string.Format("INSERT INTO Empleados VALUES ('{0}','{1}','{2}','{3}','{4}')",
                    //            empleado.nombre, empleado.direccion, empleado.telefono, empleado.contraseña, empleado.cumpleaños), conexion); */

                    //        SqlCommand comando = new SqlCommand(string.Format("Select EmplNombre from Empleados"));

                    //        SqlDataReader retorno = comando.ExecuteReader();

                    //        MessageBox.Show("Empleado añadido");

                    //        conexion.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
