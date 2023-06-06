using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaDeMascotas
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

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
    }
}
