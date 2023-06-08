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
using TiendaDeMascotas.Repositorios;
using TiendaDeMascotas.Clases;

namespace TiendaDeMascotas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            // Configurar el TextBox de la contraseña para mostrar asteriscos
            ContraseñaLogin.PasswordChar = '●';

        }


        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string usuario = UsuarioLogin.Text;
            string contraseña = ContraseñaLogin.Text;

            if (ValidarCredenciales(usuario, contraseña))
            {
                Home homeForm = new Home();
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error. Credenciales incorrectas.");
            }
        }

        private bool ValidarCredenciales(string usuario, string contraseña)
        {
            try
            {
                using (SqlConnection conn = LoginRepositorio.ObtenerConexion())
                {
                    string selectQuery = "SELECT EmpNombre, EmpContraseña FROM Trabajadores WHERE EmpNombre = @Usuario AND EmpContraseña = @Contraseña";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Contraseña", contraseña);

                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar las credenciales: " + ex.Message);
            }

            return false;
        }

        private void UsuarioLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContraseñaLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContraseñaLogin_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
