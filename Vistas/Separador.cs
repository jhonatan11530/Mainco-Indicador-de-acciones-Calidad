using System;
using System.Data.SqlClient;
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
            IndicadorInterno();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IndicadorExterno();
        }

        public void IndicadorInterno()
        {
            bool read = false;
            string fecha = null;
            DateTime fechaActual = DateTime.Today;
            string hoy = fechaActual.ToString("dd/MM/yyyy");

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones WHERE verificado='INTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    read = true;
                    fecha = reader.GetString(8);

                    if (hoy == fecha)
                    {

                        DateTime fechainicio = Convert.ToDateTime(hoy);
                        DateTime fechafin = Convert.ToDateTime(fecha);
                        int DIAS = (fechafin - fechainicio).Days;

                        if (DIAS <= 0)
                        {

                            notifyIcon1.Visible = true;
                            notifyIcon1.Icon = Properties.Resources.mainco;
                            notifyIcon1.Text = "Notificacion";
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(5000, "EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "ABRA LA APLICACION", ToolTipIcon.Info);

                            dynamic result = MessageBox.Show("EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "SE VENCIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {

                                Supervisador_interno supervisa = new Supervisador_interno(hoy);
                                supervisa.Show();
                                Hide();

                            }
                            if (result == DialogResult.No)
                            {
                                MessageBox.Show("DEBE VER LOS INDICADORES CON FECHA VENCIDO", "DEBE REVISAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                                Supervisador_interno supervi = new Supervisador_interno(hoy);
                                supervi.Show();
                                Hide();
                            }

                        }
                        else
                        {

                            Supervisador_interno superv = new Supervisador_interno(hoy);
                            superv.Show();
                            Hide();
                        }
                    }
                    else
                    {

                        Supervisador_interno superv = new Supervisador_interno(hoy);
                        superv.Show();
                        Hide();
                    }


                }

                if (read == false)
                {
                    read = true;
                    Supervisador_interno superv = new Supervisador_interno(hoy);
                    superv.Show();
                    Hide();
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

        public void IndicadorExterno()
        {
            bool read = false;
            string fecha = null;
            DateTime fechaActual = DateTime.Today;
            string hoy = fechaActual.ToString("dd/MM/yyyy");

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones WHERE verificado='EXTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    read = true;
                    fecha = reader.GetString(8);
                    if (hoy == fecha)
                    {

                        DateTime fechainicio = Convert.ToDateTime(hoy);
                        DateTime fechafin = Convert.ToDateTime(fecha);
                        int DIAS = (fechafin - fechainicio).Days;

                        if (DIAS <= 0)
                        {

                            notifyIcon1.Visible = true;
                            notifyIcon1.Icon = Properties.Resources.mainco;
                            notifyIcon1.Text = "Notificacion";
                            notifyIcon1.Visible = true;
                            notifyIcon1.ShowBalloonTip(5000, "EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "ABRA LA APLICACION", ToolTipIcon.Info);

                            dynamic result = MessageBox.Show("EXISTE INDICADORES ACCIONES CORRECTIVAS VENCIDAS", "SE VENCIO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {

                                Supervisor_externo supervisa = new Supervisor_externo(hoy);
                                supervisa.Show();
                                Hide();

                            }
                            if (result == DialogResult.No)
                            {
                                MessageBox.Show("DEBE VER LOS INDICADORES CON FECHA VENCIDO", "DEBE REVISAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                                Supervisor_externo supervi = new Supervisor_externo(hoy);
                                supervi.Show();
                                Hide();
                            }
                        }

                        else
                        {
                            Supervisor_externo superv = new Supervisor_externo(hoy);
                            superv.Show();
                            Hide();
                        }
                    }
                    else
                    {
                        Supervisor_externo superv = new Supervisor_externo(hoy);
                        superv.Show();
                        Hide();
                    }


                }
                if (read == false)
                {

                    read = true;
                    Supervisor_externo super = new Supervisor_externo(hoy);
                    super.Show();
                    Hide();
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
