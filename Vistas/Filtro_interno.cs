using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    public partial class Filtro_interno : Form
    {
        public Filtro_interno()
        {
            InitializeComponent();
            FILTROEPS();
        }
        public void FILTROEPS()
        {
            string[] FILTROEPS = { "SELECCIONE MES PARA FILTRAR", "ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE" };
            for (int i = 0; i < FILTROEPS.Length; i++)
            {
                comboBox1.Items.Add(FILTROEPS[i]);
            }
            comboBox1.SelectedIndex = +0;

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string valor = comboBox1.SelectedItem.ToString();

            if (valor == "SELECCIONE MES PARA FILTRAR")
            {

                MessageBox.Show("SE MOSTRARA TODOS LOS MESES ", "TODO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SinFiltro();
            }
            else
            {

                ConFiltro(valor);
            }
        }
        public void SinFiltro()
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataAdapter da;
            DataTable dt;
            try
            {
                da = new SqlDataAdapter("SELECT * FROM proyecto.dbo.Indicador_acciones WHERE verificado='INTERNO'", connecting);
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
        public void ConFiltro(string valor)
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataAdapter da;
            DataTable dt;
            try
            {
                da = new SqlDataAdapter("SELECT * FROM proyecto.dbo.Indicador_acciones WHERE MES='" + valor + "' AND verificado='INTERNO'", connecting);
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

        private void Filtro_interno_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.Indicador_acciones' Puede moverla o quitarla según sea necesario.
            this.indicador_accionesTableAdapter.Fill(this.dataSet1.Indicador_acciones);

        }
    }
}
