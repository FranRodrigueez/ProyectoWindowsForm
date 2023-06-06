using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeMascotas.Repositorios
{
    public class HomeRepositorio
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Server=(local); Database=TiendaDeMascotas; Integrated Security = true");
            conn.Open();
            return conn;
        }

        public static Dictionary<string, int> ObtenerCantidadProductosPorCategoria()
        {
            Dictionary<string, int> cantidadProductos = new Dictionary<string, int>();

            using (SqlConnection conn = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductoCategoria, SUM(ProductoCantidad) AS Cantidad FROM Productos GROUP BY ProductoCategoria", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string categoria = reader["ProductoCategoria"].ToString();
                    int cantidad = Convert.ToInt32(reader["Cantidad"]);

                    cantidadProductos.Add(categoria, cantidad);
                }
            }

            return cantidadProductos;
        }

    }
}
