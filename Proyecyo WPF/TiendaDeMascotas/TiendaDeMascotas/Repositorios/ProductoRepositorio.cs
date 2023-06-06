using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TiendaDeMascotas.Clases;

namespace TiendaDeMascotas
{
    public class ProductoRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Server=(local); Database=TiendaDeMascotas; Integrated Security = true");
            conn.Open();
            return conn;
        }

        public static int Agregar(ClassProducto producto)
        {
            int retorno = 0;
            using (SqlConnection conn = ObtenerConexion())
            {
                string insertQuery = "INSERT INTO Productos (ProductoNombre, ProductoCategoria, ProductoCantidad, ProductoPrecio)" +
                                        "VALUES (@Nombre, @Categoria, @Cantidad, @Precio)";
                SqlCommand comando = new SqlCommand(insertQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", producto.nombreProducto);
                comando.Parameters.AddWithValue("@Categoria", producto.categoriaProducto);
                comando.Parameters.AddWithValue("@Cantidad", producto.cantidadProducto);
                comando.Parameters.AddWithValue("@Precio", producto.precioProducto);

                retorno = comando.ExecuteNonQuery();
                conn.Close();
            }

            return retorno;
        }

        public static bool Eliminar(int ProductoID)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string deleteQuery = "DELETE FROM Productos WHERE ProductoID = @ProdNum";
                SqlCommand comando = new SqlCommand(deleteQuery, conn);
                comando.Parameters.AddWithValue("@ProdNum", ProductoID);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }

        public static bool Actualizar(int prodNum, string nuevoNombre, string nuevaCategoria, string nuevaCantidad, string nuevoPrecio)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string updateQuery = "UPDATE Productos SET ProductoNombre = @Nombre, ProductoCategoria = @Categoria, ProductoCantidad = @Cantidad, ProductoPrecio = @Precio WHERE ProductoID = @ProdNum";
                SqlCommand comando = new SqlCommand(updateQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Categoria", nuevaCategoria);
                comando.Parameters.AddWithValue("@Cantidad", nuevaCantidad);
                comando.Parameters.AddWithValue("@Precio", nuevoPrecio);
                comando.Parameters.AddWithValue("@ProdNum", prodNum);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }

    }
}
