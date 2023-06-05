using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaDeMascotas
{
    public class ClassEmpleado
    {
        public int idEmpleado;
        public string nombre;
        public string direccion;
        public string telefono;
        public string contraseña;

        public ClassEmpleado()
        {
            nombre = null;
            direccion = null;
            telefono = null;
            contraseña = null;
        }
    }
}