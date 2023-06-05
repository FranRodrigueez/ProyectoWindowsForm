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

        static string conexionString = "server = localhost; database = TiendaDeAnimales; integrated security = true";
        SqlConnection conexion = new SqlConnection(conexionString);


        private void GuardarEmpleado_Click(object sender, EventArgs e)
        {
            if(EmpleadoNombre.Text == "" || EmpleadoTelefono.Text == "" || EmpleadoContraseña.Text == "" || EmpleadoCumpleaños.Text == "" || EmpleadoDireccion.Text == "")
            {
                MessageBox.Show("Error. Introduzca la información completa");
            }
            else
            {
                try
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Empleados (EmpNombre, EmpDireccion, EmpCumpleaños, EmpTelefono, EmpContraseña) VALUES (@EN, @ED, @ECu, @ET, @EPC)", conexion);
                    
                    cmd.Parameters.AddWithValue("@EN", EmpleadoNombre.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpleadoDireccion.Text);
                    cmd.Parameters.AddWithValue("@ECu", EmpleadoCumpleaños.Text);
                    cmd.Parameters.AddWithValue("@ET", EmpleadoTelefono.Text);
                    cmd.Parameters.AddWithValue("@EPC",EmpleadoContraseña.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Empleado añadido");

                    conexion.Close();
                    
                }
                catch(Exception ex)
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
