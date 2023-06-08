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
using TiendaDeMascotas.Repositorios;
using TiendaDeMascotas.Clases;

namespace TiendaDeMascotas
{
    public partial class Facturas : Form
    {
        public Facturas()
        {
            InitializeComponent();
            InitializeLabelEvents();
            Load += Facturas_Load; // Suscribir el evento Load al método Facturas_Load
            ProductoDGV.SelectionChanged += ProductosDGV_SelectionChanged; // Suscribir el evento SelectionChanged
            
        }

        private void InitializeLabelEvents()
        {
            Inicio.MouseEnter += Label_MouseEnter;
            Inicio.MouseLeave += Label_MouseLeave;
            Clientes.MouseEnter += Label_MouseEnter;
            Clientes.MouseLeave += Label_MouseLeave;
            Empleados.MouseEnter += Label_MouseEnter;
            Empleados.MouseLeave += Label_MouseLeave;
            Productos.MouseEnter += Label_MouseEnter;
            Productos.MouseLeave += Label_MouseLeave;
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

        private void Facturas_Load(object sender, EventArgs e)
        {
            CargarProductos(); // Cargar los productos en el DataGridView al cargar el formulario
        }

        private void CargarProductos()
        {
            try
            {
                using (SqlConnection conn = FacturaRepositorio.ObtenerConexion())
                {
                    string selectQuery = "SELECT ProductoID, ProductoNombre, ProductoCategoria, ProductoCantidad, ProductoPrecio FROM Productos";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);

                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    ProductoDGV.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos: " + ex.Message);
            }
        }

        private void ProductosDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (ProductoDGV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ProductoDGV.SelectedRows[0];
                string nombreProducto = selectedRow.Cells["ProductoNombre"].Value.ToString();
                string precioProducto = selectedRow.Cells["ProductoPrecio"].Value.ToString();

                ProductoNombre.Text = nombreProducto;
                ProductoPrecio.Text = precioProducto;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            // Acciones del evento
        }

        private void Productos_Click(object sender, EventArgs e)
        {
            Productos productosForm = new Productos();
            productosForm.Show();
        }

        private void ClienteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acciones del evento
        }

        private void ProductoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Acciones del evento
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            Home inicioForm = new Home();
            inicioForm.Show();
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

        private void Factura_Click(object sender, EventArgs e)
        {

        }

        private void Facturas_Load_1(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ProductoNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductoCantidad_TextChanged(object sender, EventArgs e)
        {
         
        }


    }
}

