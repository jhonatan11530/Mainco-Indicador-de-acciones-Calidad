using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indicador_de_acciones_Calidad
{
    class Conexion
    {
        public SqlConnection connecting()
        {

            SqlConnection conn = new SqlConnection("server=192.168.20.9 ; database=proyecto ; integrated security = false;User ID=proyecto;Password=12345;");

            return conn;
        }
        public SqlDataReader reader()
        {
            SqlDataReader reader = null;

            return reader;
        }
    }
}
