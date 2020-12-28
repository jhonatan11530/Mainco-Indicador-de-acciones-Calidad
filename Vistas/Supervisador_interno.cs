using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    public partial class Supervisador_interno : Form
    {
        public Supervisador_interno(string valor)
        {
            InitializeComponent();

            mostrar(valor);
        }
        public void mostrar(string valor)
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataAdapter da;
            DataTable dt;
            try
            {
                da = new SqlDataAdapter("SELECT N_conforme,detallado,responsable,solicito,fecha_enviado,fecha_respuesta,fecha_cierre,dias FROM [proyecto].[dbo].[Indicador_acciones] WHERE fecha_respuesta='" + valor + "' AND verificado='INTERNO'", connecting);
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                connecting.Close(); //Cierra la conexión a MySQL
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
