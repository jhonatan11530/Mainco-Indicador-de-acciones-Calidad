using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad.Vistas
{
    public partial class Separador : Form
    {
        public Separador()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verificar1();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            verificar2();
        }
        public void verificar1()
        {

            DateTime fechaActual = DateTime.Today;
            string hoy = fechaActual.ToString("dd/MM/yyyy");
            string FECHA_CIERRE = null;

            fechaActual.AddDays(+1).ToString("dd/MM/yyyy");

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    FECHA_CIERRE = reader.GetString(8);

                }
                if (hoy == FECHA_CIERRE)
                {

                    notifyIcon1.Visible = true;
                    notifyIcon1.Icon = new Icon("C:/Users/darthvirus/source/repos/Indicador de acciones Calidad/Resources/mainco.ico");
                    notifyIcon1.Text = "Notificacion";
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000, "EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "ABRA LA APLICACION", ToolTipIcon.Info);

                    dynamic result = MessageBox.Show("EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "SE VENCIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Supervisador_interno supervisador = new Supervisador_interno(hoy);
                        supervisador.Show();
                        Hide();

                    }
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("DEBE VER LOS INDICADORES CON FECHA VENCIDO", "DEBE REVISAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        Supervisador_interno supervisador = new Supervisador_interno(hoy);
                        supervisador.Show();
                        Hide();
                    }
                }


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
        public void verificar2()
        {

            DateTime fechaActual = DateTime.Today;
            string hoy = fechaActual.ToString("dd/MM/yyyy");
            string FECHA_CIERRE = null;

            fechaActual.AddDays(+1).ToString("dd/MM/yyyy");

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    FECHA_CIERRE = reader.GetString(8);

                }
                if (hoy == FECHA_CIERRE)
                {

                    notifyIcon1.Visible = true;
                    notifyIcon1.Icon = new Icon("C:/Users/darthvirus/source/repos/Indicador de acciones Calidad/Resources/mainco.ico");
                    notifyIcon1.Text = "Notificacion";
                    notifyIcon1.Visible = true;
                    notifyIcon1.ShowBalloonTip(5000, "EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "ABRA LA APLICACION", ToolTipIcon.Info);

                    dynamic result = MessageBox.Show("EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "SE VENCIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Supervisador_interno supervisador = new Supervisador_interno(hoy);
                        supervisador.Show();
                        Hide();

                    }
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("DEBE VER LOS INDICADORES CON FECHA VENCIDO", "DEBE REVISAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        Supervisador_interno supervisador = new Supervisador_interno(hoy);
                        supervisador.Show();
                        Hide();
                    }
                }


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

        
    }
}
