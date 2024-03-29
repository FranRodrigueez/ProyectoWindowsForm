﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaDeMascotas.Repositorios;

namespace TiendaDeMascotas
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            InitializeLabelEvents();
        }

        private void InitializeLabelEvents()
        {
            Productos.MouseEnter += Label_MouseEnter;
            Productos.MouseLeave += Label_MouseLeave;
            Clientes.MouseEnter += Label_MouseEnter;
            Clientes.MouseLeave += Label_MouseLeave;
            Empleados.MouseEnter += Label_MouseEnter;
            Empleados.MouseLeave += Label_MouseLeave;
            Factura.MouseEnter += Label_MouseEnter;
            Factura.MouseLeave += Label_MouseLeave;
            Salir.MouseEnter += Label_MouseEnter;
            Salir.MouseLeave += Label_MouseLeave;

            Dictionary<string, int> cantidadProductos = HomeRepositorio.ObtenerCantidadProductosPorCategoria();

            if (cantidadProductos.ContainsKey("Perros"))
                label15.Text = cantidadProductos["Perros"].ToString();
            if (cantidadProductos.ContainsKey("Gatos"))
                label5.Text = cantidadProductos["Gatos"].ToString();
            if (cantidadProductos.ContainsKey("Peces"))
                label6.Text = cantidadProductos["Peces"].ToString();
            if (cantidadProductos.ContainsKey("Pájaros"))
                label14.Text = cantidadProductos["Pájaros"].ToString();
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



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Productos_Click(object sender, EventArgs e)
        {
            Productos productosForm = new Productos();
            productosForm.Show();
        }

        private void Clientes_Click(object sender, EventArgs e)
        {
            Clientes clientesForm = new Clientes();
            clientesForm.Show();
        }

        private void Empleados_Click(object sender, EventArgs e)
        {
            Empleadoos empleadosForm = new Empleadoos();
            empleadosForm.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
      
        }
      
        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Factura_Click(object sender, EventArgs e)
        {
            Facturas facturaForm = new Facturas();
            facturaForm.Show();
        }
    }
}
