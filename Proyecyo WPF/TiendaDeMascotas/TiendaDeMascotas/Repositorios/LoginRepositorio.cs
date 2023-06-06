using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeMascotas.Repositorios
{
    internal class LoginRepositorio
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conn = new SqlConnection("Server=(local); Database=TiendaDeMascotas; Integrated Security = true");
            conn.Open();
            return conn;
        }
    }
}
