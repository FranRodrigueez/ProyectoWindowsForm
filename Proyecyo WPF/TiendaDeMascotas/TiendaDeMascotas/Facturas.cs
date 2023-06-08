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
            Load += Facturas_Load; // Suscribir el evento Load al método Facturas_Load
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

        // Resto del código del formulario

        private void label9_Click(object sender, EventArgs e)
        {
            // Acciones del evento
        }

        private void Productos_Click(object sender, EventArgs e)
        {
            // Acciones del evento
        }

        private void ClienteID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Acciones del evento
        }

        private void ProductoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Acciones del evento
        }
    }
}
