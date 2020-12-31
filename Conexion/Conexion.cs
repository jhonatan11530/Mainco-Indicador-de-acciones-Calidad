using System.Data.SqlClient;

namespace Indicador_de_acciones_Calidad
{
    internal class Conexion
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
