using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeMascotas
{
    public class EmpleadoRepository
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Server=(local); Database=TiendaDeMascotas; Integrated Security = true");
            conn.Open();
            return conn;
        }

        public static int Agregar(ClassEmpleado empleado)
        {
            int retorno = 0;
            using (SqlConnection conn = ObtenerConexion())
            {
                string insertQuery = "INSERT INTO Trabajadores (EmpNombre, EmpDireccion, EmpTelefono, EmpContraseña, EmpRol)" +
                                        "VALUES (@Nombre, @Direccion, @Telefono, @Contraseña, @Rol)";
                SqlCommand Comando = new SqlCommand(insertQuery, conn);
                Comando.Parameters.AddWithValue("@Nombre", empleado.nombre);
                Comando.Parameters.AddWithValue("@Direccion", empleado.direccion);
                Comando.Parameters.AddWithValue("@Telefono", empleado.telefono);
                Comando.Parameters.AddWithValue("@Contraseña", empleado.contraseña);
                Comando.Parameters.AddWithValue("@Rol", empleado.rol);

                retorno = Comando.ExecuteNonQuery();
                conn.Close();
            }

            return retorno;
        }

        public static bool Eliminar(int empNum)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string deleteQuery = "DELETE FROM Trabajadores WHERE EmpNum = @EmpNum";
                SqlCommand comando = new SqlCommand(deleteQuery, conn);
                comando.Parameters.AddWithValue("@EmpNum", empNum);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }

        public static bool Actualizar(int empNum, string nuevoNombre, string nuevaDireccion, string nuevoTelefono, string nuevaContraseña, string nuevoRol)
        {
            bool exito = false;
            using (SqlConnection conn = ObtenerConexion())
            {
                string updateQuery = "UPDATE Trabajadores SET EmpNombre = @Nombre, EmpDireccion = @Direccion, EmpTelefono = @Telefono, EmpContraseña = @Contraseña, EmpRol = @Rol WHERE EmpNum = @EmpNum";
                SqlCommand comando = new SqlCommand(updateQuery, conn);
                comando.Parameters.AddWithValue("@Nombre", nuevoNombre);
                comando.Parameters.AddWithValue("@Direccion", nuevaDireccion);
                comando.Parameters.AddWithValue("@Telefono", nuevoTelefono);
                comando.Parameters.AddWithValue("@Contraseña", nuevaContraseña);
                comando.Parameters.AddWithValue("@Rol", nuevoRol);
                comando.Parameters.AddWithValue("@EmpNum", empNum);

                int filasAfectadas = comando.ExecuteNonQuery();
                exito = (filasAfectadas > 0);
            }

            return exito;
        }
    }
}
