using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                string insertQuery = "INSERT INTO Empleados (EmpNombre, EmpDireccion, EmpTelefono, EmpContraseña)" +
                                        "VALUES (@Nombre, @Direccion, @Telefono, @Contraseña)";
                SqlCommand Comando = new SqlCommand(insertQuery, conn);
                Comando.Parameters.AddWithValue("@Nombre", empleado.nombre);
                Comando.Parameters.AddWithValue("@Direccion", empleado.direccion);
                Comando.Parameters.AddWithValue("@Telefono", empleado.telefono);
                Comando.Parameters.AddWithValue("@Contraseña", empleado.contraseña);

                retorno = Comando.ExecuteNonQuery();
                conn.Close();
            }
            return retorno;
        }
    }
}
