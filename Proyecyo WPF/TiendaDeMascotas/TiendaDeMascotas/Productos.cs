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
            MostrarProductos();
            InitializeLabelEvents();

            // Asignar el evento SelectionChanged al GunaDataGridView
            ProductoDGV.SelectionChanged += ProductoDGV_SelectionChanged;
        }

        private void InitializeLabelEvents()
        {
            Inicio.MouseEnter += Label_MouseEnter;
            Inicio.MouseLeave += Label_MouseLeave;
            Clientes.MouseEnter += Label_MouseEnter;
            Clientes.MouseLeave += Label_MouseLeave;
            Empleados.MouseEnter += Label_MouseEnter;
            Empleados.MouseLeave += Label_MouseLeave;
            Factura.MouseEnter += Label_MouseEnter;
            Factura.MouseLeave += Label_MouseLeave;
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

        private void ProductoDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (ProductoDGV.SelectedRows.Count > 0)
            {
                // Obtener los datos del empleado seleccionado
                string nombre = ProductoDGV.SelectedRows[0].Cells["ProductoNombre"].Value.ToString();
                string categoria = ProductoDGV.SelectedRows[0].Cells["ProductoCategoria"].Value.ToString();
                string cantidad = ProductoDGV.SelectedRows[0].Cells["ProductoCantidad"].Value.ToString();
                string precio = ProductoDGV.SelectedRows[0].Cells["ProductoPrecio"].Value.ToString();

                // Mostrar los datos en los cuadros de texto
                ProductoNombre.Text = nombre;
                ProductoCategoria.Text = categoria;
                ProductoCantidad.Text = cantidad;
                ProductoPrecio.Text = precio;
            }
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (ProductoDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de empleado de la fila seleccionada
                int prodNum = Convert.ToInt32(ProductoDGV.SelectedRows[0].Cells["ProductoID"].Value);

                // Obtener los datos modificados de las cajas de texto
                string nuevoNombre = ProductoNombre.Text;
                string nuevaCategoria = ProductoCategoria.Text;
                string nuevoCantidad = ProductoCantidad.Text;
                string nuevoPrecio = ProductoPrecio.Text;

                // Actualizar los datos en el GunaDataGridView
                ProductoDGV.SelectedRows[0].Cells["ProductoNombre"].Value = nuevoNombre;
                ProductoDGV.SelectedRows[0].Cells["ProductoCategoria"].Value = nuevaCategoria;
                ProductoDGV.SelectedRows[0].Cells["ProductoCantidad"].Value = nuevoCantidad;
                ProductoDGV.SelectedRows[0].Cells["ProductoPrecio"].Value = nuevoPrecio;

                // Actualizar los datos en la base de datos
                if (ProductoRepository.Actualizar(prodNum, nuevoNombre, nuevaCategoria, nuevoCantidad, nuevoPrecio))
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (ProductoDGV.SelectedRows.Count > 0)
            {
                // Obtener el número de producto de la fila seleccionada
                int prodNum = Convert.ToInt32(ProductoDGV.SelectedRows[0].Cells["ProductoID"].Value);

                // Eliminar el producto del GunaDataGridView
                ProductoDGV.Rows.RemoveAt(ProductoDGV.SelectedRows[0].Index);

                // Eliminar el producto de la base de datos
                if (ProductoRepository.Eliminar(prodNum))
                {
                    MessageBox.Show("Producto eliminado correctamente.");
                }
                else
                {
                    MessageBox.Show("Error al eliminar el producto de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para borrar.");
            }
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

        private void Factura_Click(object sender, EventArgs e)
        {
            Facturas facturaForm = new Facturas();
            facturaForm.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
