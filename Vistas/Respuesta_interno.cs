using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    public partial class Respuesta_interno : Form
    {
        DateTime fechaActual = new DateTime();
        public Respuesta_interno()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            fechaActual = DateTime.Today;

            dateTimePicker1.Value = fechaActual;

            dateTimePicker1.Enabled = false;

            button1.Enabled = false;

            string[] ESTADO = { "ABIERTO", "CERRADO" };
            for (int i = 0; i < ESTADO.Length; i++)
            {
                comboBox1.Items.Add(ESTADO[i]);
                comboBox1.SelectedIndex = +0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            ThreadStart delegado = new ThreadStart(Buscar);
            Thread hilo = new Thread(delegado);
            hilo.Start();


        }
        public void Buscar()
        {


            string buscar = textBox1.Text;
            string detalle = null;
            string especifico = null;
            string respuesta = null;

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT detallado,especifico,fecha_respuesta FROM [proyecto].[dbo].[Indicador_acciones] WHERE N_conforme='" + buscar + "' AND verificado='INTERNO' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    detalle = reader.GetString(0);
                    especifico = reader.GetString(1);   //Almacena cada registro con un salto de linea
                    respuesta = reader.GetString(2);
                }
                textBox2.Text = detalle;
                textBox3.Text = especifico;
                textBox4.Text = respuesta;

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Observaciones.Text == String.Empty && plan.Text == String.Empty)
            {
                MessageBox.Show("LOS CAMPOS ESTAN VACIOS");
            }
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {

                MessageBox.Show("DEBE SELECIONAR UNA OPCION");
            }
            else
            {


                int DIAS = 0; ;
                string estado = comboBox1.SelectedItem.ToString();
                string planes = plan.Text;
                string observacion = Observaciones.Text;
                string Numero = textBox1.Text;
                string fechaCierreAccion = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                Conexion conexion = new Conexion();
                SqlConnection connecting = conexion.connecting();
                SqlDataReader reader = conexion.reader();

                try
                {
                    string select = "SELECT fecha_respuesta FROM dbo.Indicador_acciones where N_conforme=" + Numero + " AND verificado='INTERNO' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                    SqlCommand comandos = new SqlCommand(select)
                    {
                        Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                    }; //Declaración SQL para ejecutar contra una base de datos MySQL
                    connecting.Open(); //Abre la conexión
                    reader = comandos.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                    while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                    {
                        string fecha_respuesta = reader.GetString(0); //Almacena cada registro con un salto de linea

                        DateTime fechainicio = dateTimePicker1.Value;
                        DateTime fechafin = DateTime.Parse(fecha_respuesta);
                        DIAS = (fechafin - fechainicio).Days;

                    }

                    connecting.Close(); //Cierra la conexión a MySQL
                    if (checkBox1.Checked == true)
                    {

                        if (DIAS < 0)
                        {

                            MessageBox.Show("NO PUEDES SOBRE PASAR EL LIMITE DE DIAS DE RESPUESTA", "NO PUEDE SOBREPASAR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                        else
                        {
                            try
                            {
                                string consulta = "UPDATE dbo.Indicador_acciones SET dias='" + DIAS + "',estado='" + estado + "',observaciones='" + observacion + "',planes='" + planes + "',fecha_cierre='" + fechaCierreAccion + "' WHERE N_conforme='" + Numero + "' AND verificado='INTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                                SqlCommand comando = new SqlCommand(consulta)
                                {
                                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                                connecting.Open();//Abre la conexión
                                comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                                MessageBox.Show("EL REGISTRO FUE INSERTADO CORRECTAMENTE !!", "EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Hide();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
                            }
                        }
                    }
#pragma warning disable CS0665 // La asignación en la expresión condicional siempre es constante; ¿quería utilizar == en lugar de = ?
                    else if (checkBox2.Checked = true)
#pragma warning restore CS0665 // La asignación en la expresión condicional siempre es constante; ¿quería utilizar == en lugar de = ?
                    {
                        try
                        {
                            string consulta = "UPDATE dbo.Indicador_acciones SET dias='" + DIAS + "',estado='" + estado + "',observaciones='" + observacion + "',planes='" + planes + "',fecha_cierre='" + fechaCierreAccion + "' WHERE N_conforme='" + Numero + "' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                            SqlCommand comando = new SqlCommand(consulta)
                            {
                                Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                            }; //Declaración SQL para ejecutar contra una base de datos MySQL
                            connecting.Open();//Abre la conexión
                            comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                            MessageBox.Show("EL REGISTRO FUE INSERTADO CORRECTAMENTE !!", "EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Hide();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
                        }
                    }
                    else if (checkBox3.Checked == true)
                    {
                        try
                        {
                            string consulta = "UPDATE dbo.Indicador_acciones SET dias='" + DIAS + "',estado='" + estado + "',observaciones='" + observacion + "',planes='" + planes + "',fecha_cierre='" + fechaCierreAccion + "' WHERE N_conforme='" + Numero + "' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                            SqlCommand comando = new SqlCommand(consulta)
                            {
                                Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                            }; //Declaración SQL para ejecutar contra una base de datos MySQL
                            connecting.Open();//Abre la conexión
                            comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                            MessageBox.Show("EL REGISTRO FUE INSERTADO CORRECTAMENTE !!", "EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Hide();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            dateTimePicker1.Enabled = true;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = fechaActual;
            checkBox1.Checked = true;
            dateTimePicker1.Enabled = true;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            dateTimePicker1.Enabled = true;
        }

    }
}
