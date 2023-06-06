using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaDeMascotas.Clases;

namespace TiendaDeMascotas.Repositorios
{
    public class ClienteRepositorio
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Server=(local); Database=TiendaDeMascotas; Integrated Security = true");
            conn.Open();
            return conn;
        }

        public static int Agregar(ClassCliente cliente)
        {
            int retorno = 0;
            using (SqlConnection conn = ObtenerConexion())
            {
                string insertQuery = "INSERT INTO Clientes (ClienteNombre, ClienteDireccion, ClienteTelefono)" +
                                        "VALUES (@Nombre, @Direccion, @Telefono)";
                SqlCommand comando = new SqlCommand(insertQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", cliente.nombreCliente);
                comando.Parameters.AddWithValue("@Direccion", cliente.direccionCliente);
                comando.Parameters.AddWithValue("@Telefono", cliente.telefonoCliente);

                retorno = comando.ExecuteNonQuery();
                conn.Close();
            }

            return retorno;
        }

        public static bool Eliminar(int ClienteID)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string deleteQuery = "DELETE FROM Clientes WHERE ClienteID = @ClienteNum";
                SqlCommand comando = new SqlCommand(deleteQuery, conn);
                comando.Parameters.AddWithValue("@ClienteNum", ClienteID);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }

        public static bool Actualizar(int clienteNum, string nuevoNombre, string nuevaDireccion, string nuevoTelefono)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string updateQuery = "UPDATE Clientes SET ClienteNombre = @Nombre, ClienteDireccion = @Direccion, ClienteTelefono = @Telefono WHERE ClienteID = @ClienteNum";
                SqlCommand comando = new SqlCommand(updateQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Direccion", nuevaDireccion);
                comando.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                comando.Parameters.AddWithValue("@ClienteNum", clienteNum);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }
    }
}
