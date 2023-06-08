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
using Bunifu.Framework.UI;

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
            ClienteID.SelectedIndexChanged += ClienteID_SelectedIndexChanged; // Suscribir el evento SelectedIndexChanged
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
            CargarClientes(); // Cargar los clientes en el ComboBox al cargar el formulario
        }

        private void CargarClientes()
        {
            try
            {
                using (SqlConnection conn = FacturaRepositorio.ObtenerConexion())
                {
                    string selectQuery = "SELECT ClienteID FROM Clientes";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);

                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        int clienteID = reader.GetInt32(reader.GetOrdinal("ClienteID"));
                        ClienteID.Items.Add(clienteID.ToString()); // Convertir el valor entero a cadena
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los clientes: " + ex.Message);
            }
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

                ProductoName.Text = nombreProducto;
                Precio.Text = precioProducto;
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
            string clienteID = ClienteID.SelectedItem?.ToString();
         

            try
            {
                using (SqlConnection conn = FacturaRepositorio.ObtenerConexion())
                {
                    string selectQuery = "SELECT ClienteNombre FROM Clientes WHERE ClienteID = @ClienteID";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    comando.Parameters.AddWithValue("@ClienteID", clienteID);

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        string clienteNombre = reader.GetString(reader.GetOrdinal("ClienteNombre"));
                        NombreCliente.Text = clienteNombre;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el nombre del cliente: " + ex.Message);
            }
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

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private List<int> cantidadesRestadas = new List<int>();
        private decimal totalFactura = 0; // Variable para almacenar el total de la factura

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los labels
            string nombreProducto = ProductoName.Text;
            string precioProducto = Precio.Text;
            string cantidadProducto = Cantidad.Text;

            if (string.IsNullOrEmpty(cantidadProducto))
            {
                MessageBox.Show("Cantidad incorrecta: la cantidad no puede estar vacía.");
                return;
            }

            int cantidad;
            if (!int.TryParse(cantidadProducto, out cantidad))
            {
                MessageBox.Show("Cantidad incorrecta: la cantidad debe ser un número entero.");
                return;
            }

            // Comprobar si el producto existe en la base de datos
            bool productoEncontrado = false;
            using (SqlConnection conn = FacturaRepositorio.ObtenerConexion())
            {
                string selectQuery = "SELECT ProductoID, ProductoNombre, ProductoCantidad FROM Productos WHERE ProductoNombre = @Nombre";
                SqlCommand comando = new SqlCommand(selectQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", nombreProducto);

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    productoEncontrado = true;

                    // Obtener la cantidad del producto en la base de datos
                    int cantidadBaseDatos = reader.GetInt32(reader.GetOrdinal("ProductoCantidad"));

                    if (cantidad > cantidadBaseDatos)
                    {
                        MessageBox.Show("Cantidad incorrecta: la cantidad introducida es mayor a la cantidad disponible en la base de datos.");
                        return;
                    }

                    cantidadesRestadas.Add(cantidad);

                    // Actualizar la cantidad en la base de datos
                    int nuevaCantidad = cantidadBaseDatos - cantidad;
                    reader.Close();

                    string updateQuery = "UPDATE Productos SET ProductoCantidad = @NuevaCantidad WHERE ProductoNombre = @Nombre";
                    SqlCommand updateComando = new SqlCommand(updateQuery, conn);
                    updateComando.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidad);
                    updateComando.Parameters.AddWithValue("@Nombre", nombreProducto);
                    updateComando.ExecuteNonQuery();

                    // Actualizar la cantidad en el DataGridView ProductoDGV
                    if (ProductoDGV.SelectedRows.Count > 0)
                    {
                        DataGridViewRow selectedRow = ProductoDGV.SelectedRows[0];
                        int rowIndex = selectedRow.Index;
                        int cantidadActualizada = cantidadBaseDatos - cantidad;
                        selectedRow.Cells["ProductoCantidad"].Value = cantidadActualizada;
                        ProductoDGV.Rows[rowIndex].Selected = true;
                    }
                }
                reader.Close();
            }

            if (!productoEncontrado)
            {
                MessageBox.Show("Cantidad incorrecta: el producto no existe en la base de datos.");
                return;
            }

            // Calcular el subtotal
            decimal subtotal = cantidad * decimal.Parse(precioProducto);

            // Agregar el subtotal al total de la factura
            totalFactura += subtotal;

            // Crear una nueva fila con los valores obtenidos
            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.CreateCells(ProductosFacturados);
            nuevaFila.Cells[0].Value = nombreProducto;
            nuevaFila.Cells[1].Value = precioProducto;
            nuevaFila.Cells[2].Value = cantidadProducto;

            // Agregar la nueva fila al DataGridView
            ProductosFacturados.Rows.Add(nuevaFila);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            // Vaciar el DataGridView ProductosFacturados
            ProductosFacturados.Rows.Clear();

            // Sumar la cantidad restada de los productos a la base de datos
            for (int i = 0; i < ProductosFacturados.Rows.Count; i++)
            {
                string nombreProducto = ProductosFacturados.Rows[i].Cells[0].Value.ToString();
                string cantidadProducto = ProductosFacturados.Rows[i].Cells[2].Value.ToString();

                if (string.IsNullOrEmpty(cantidadProducto))
                {
                    MessageBox.Show("Cantidad incorrecta: la cantidad no puede estar vacía.");
                    return;
                }

                int cantidad;
                if (!int.TryParse(cantidadProducto, out cantidad))
                {
                    MessageBox.Show("Cantidad incorrecta: la cantidad debe ser un número entero.");
                    return;
                }

                using (SqlConnection conn = FacturaRepositorio.ObtenerConexion())
                {
                    string selectQuery = "SELECT ProductoID, ProductoCantidad FROM Productos WHERE ProductoNombre = @Nombre";
                    SqlCommand comando = new SqlCommand(selectQuery, conn);
                    comando.Parameters.AddWithValue("@Nombre", nombreProducto);

                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        int productoID = reader.GetInt32(reader.GetOrdinal("ProductoID"));
                        int cantidadBaseDatos = reader.GetInt32(reader.GetOrdinal("ProductoCantidad"));

                        int nuevaCantidad = cantidadBaseDatos + cantidad;

                        reader.Close();

                        string updateQuery = "UPDATE Productos SET ProductoCantidad = @NuevaCantidad WHERE ProductoID = @ProductoID";
                        SqlCommand updateComando = new SqlCommand(updateQuery, conn);
                        updateComando.Parameters.AddWithValue("@NuevaCantidad", nuevaCantidad);
                        updateComando.Parameters.AddWithValue("@ProductoID", productoID);
                        updateComando.ExecuteNonQuery();

                        // Actualizar la cantidad en el DataGridView ProductoDGV
                        foreach (DataGridViewRow row in ProductoDGV.Rows)
                        {
                            int productoIDGrid = Convert.ToInt32(row.Cells["ProductoID"].Value);
                            if (productoIDGrid == productoID)
                            {
                                row.Cells["ProductoCantidad"].Value = nuevaCantidad;
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
            }

            // Limpiar la lista de cantidades restadas y el total de la factura
            cantidadesRestadas.Clear();
            totalFactura = 0;
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton21_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ClienteID.Text) || string.IsNullOrEmpty(NombreCliente.Text) || string.IsNullOrEmpty(ProductoName.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Obtener los valores de los campos
            string clienteID = ClienteID.Text;
            string clienteNombre = NombreCliente.Text;
            string productoNombre = ProductoName.Text;
            decimal total = totalFactura;

            // Guardar los datos en la tabla Facturaas de la base de datos
            using (SqlConnection connection = FacturaRepositorio.ObtenerConexion())
            {
                string query = "INSERT INTO Facturaas (ClienteID, ClienteNombre, ProductoNombre, Total) VALUES (@ClienteID, @ClienteNombre, @ProductoNombre, @Total)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClienteID", clienteID);
                command.Parameters.AddWithValue("@ClienteNombre", clienteNombre);
                command.Parameters.AddWithValue("@ProductoNombre", productoNombre);
                command.Parameters.AddWithValue("@Total", total);
                command.ExecuteNonQuery();
            }

            // Obtener el último IDFactura insertado
            int idFactura = 0;
            using (SqlConnection connection = FacturaRepositorio.ObtenerConexion())
            {
                string query = "SELECT MAX(IDFactura) FROM Facturaas";
                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    idFactura = Convert.ToInt32(result);
                }
            }

            // Agregar la nueva fila al DataGridView "Total"
            DataGridViewRow nuevaFila = new DataGridViewRow();
            nuevaFila.CreateCells(Total);
            nuevaFila.Cells[0].Value = idFactura;
            nuevaFila.Cells[1].Value = clienteID;
            nuevaFila.Cells[2].Value = clienteNombre;
            nuevaFila.Cells[3].Value = productoNombre;
            nuevaFila.Cells[4].Value = total;

            Total.Rows.Add(nuevaFila);

            // Vaciar el DataGridView ProductosFacturados
            ProductosFacturados.Rows.Clear();

            // Restablecer el total de la factura a cero
            totalFactura = 0;
        }

        private void Total_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

