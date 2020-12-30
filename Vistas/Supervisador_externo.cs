using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad.Vistas
{
    public partial class Supervisor_externo : Form
    {
        public Supervisor_externo(string valor)
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
                da = new SqlDataAdapter("SELECT N_conforme,detallado,responsable,solicito,fecha_enviado,fecha_respuesta,fecha_cierre,dias FROM [proyecto].[dbo].[Indicador_acciones] WHERE fecha_respuesta='" + valor + "' AND verificado='EXTERNO'", connecting);
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
            Indicardor_externo supervisador = new Indicardor_externo();
            supervisador.Show();
            this.Hide();
        }

        private void Supervisor_externo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Indicardor_externo supervisador = new Indicardor_externo();
            supervisador.Show();
        }
    }
}
