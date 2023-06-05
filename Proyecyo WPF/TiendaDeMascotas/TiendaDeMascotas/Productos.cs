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

namespace TiendaDeMascotas
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MostrarProductos()
        {
            try
            {
                // Obtener la conexión a la base de datos
                using (SqlConnection conn = ProductoRepository.ObtenerConexion())
                {
                    // Consultar los productos en la base de datos
                    string selectQuery = "SELECT ProductoID, ProductoNombre, ProductoCategoria, ProductoCantidad, ProductoPrecio FROM Productos";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    SqlDataReader reader = comando.ExecuteReader();

                    // Crear una tabla temporal para almacenar los datos de los productos
                    DataTable productosTable = new DataTable();
                    productosTable.Load(reader);

                    // Asignar la tabla temporal como origen de datos del GunaDataGridView
                    ProductoDGV.DataSource = productosTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar los productos: " + ex.Message);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (ProductoNombre.Text == "" || ProductoCategoria.Text == "" || ProductoCantidad.Text == "" || ProductoPrecio.Text == "")
            {
                MessageBox.Show("Error. Introduzca la información completa");
            }
            else
            {
                try
                {

                    ClassProducto producto = new ClassProducto();
                    producto.nombreProducto = ProductoNombre.Text;
                    producto.categoriaProducto = ProductoCategoria.Text;
                    producto.cantidadProducto = ProductoCantidad.Text;
                    producto.precioProducto = ProductoPrecio.Text;



                    if (ProductoRepository.Agregar(producto) == 1) { MessageBox.Show("Producto añadido"); } else { MessageBox.Show("error"); }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MostrarProductos();

            }
        }
    }
}
