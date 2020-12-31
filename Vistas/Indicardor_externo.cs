using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    public partial class Indicardor_externo : Form
    {

        public Indicardor_externo()
        {
            ejecutar();
            SetStartup();
            DateTime fechaActual = DateTime.Today;
            textBox1.Text = fechaActual.ToString("MMMM").ToUpper();

            dateTimePicker1.Value = fechaActual;
            dateTimePicker2.Value = fechaActual;

            textBox5.Visible = false;

            string[] ESTADO = { "ABIERTO", "CERRADO" };
            string[] Centros = { "Paquetes", "Produccion", "Calidad", "Semiautomaticas", "Corte", "Financiero", "Comercio Exterior", "Costos", "Abastecimiento", "Compras", "Logistica", "Externos", "Ambiental", "Sistemas", "Comercial", "Gestión Humana", "Gerencia" };

            for (int i = 0; i < Centros.Length; i++)
            {
                comboBox1.Items.Add(Centros[i]);
            }

            for (int i = 0; i < Centros.Length; i++)
            {
                comboBox3.Items.Add(Centros[i]);
            }
            for (int i = 0; i < ESTADO.Length; i++)
            {
                comboBox5.Items.Add(ESTADO[i]);
                comboBox5.SelectedIndex = +0;
            }
        }
        private void SetStartup()
        {
            string appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue(appName, Application.ExecutablePath);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
            if (textBox2.Text == string.Empty && textBox3.Text == string.Empty && textBox4.Text == string.Empty)
            {
                MessageBox.Show("LOS CAMPOS ESTAN VACIOS");
            }
            else
            {
                DialogResult btn = MessageBox.Show("LOS DATOS ESTAN CORRECTOS ?", "VERIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (btn == DialogResult.Yes)
                {
                    insertar();
                }
                else
                {
                    MessageBox.Show("VERIFIQUE LOS DATOS PRIMERO SI TODO ESTA CORRECTO !!", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public void insertar()
        {

            string mes = textBox1.Text;
            string no_conforme = textBox2.Text;
            string detalle = textBox3.Text;
            string detalle_especifico = textBox4.Text;
            string area = comboBox1.SelectedItem.ToString();
            string responsable = comboBox2.SelectedItem.ToString();
            string solicito = comboBox4.SelectedItem.ToString();
            string fechaEnvio = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string fechaCierre = dateTimePicker2.Value.ToString("dd/MM/yyyy");
            string fechaCierreAccion = "NO ASIGNADO";
            string diaCierre = textBox5.Text;
            string estado = comboBox5.SelectedItem.ToString();
            string verificado = "EXTERNO";
            string observacion = "SIN OBSERVACION";
            string plan_de_accion = "SIN PLAN DE ACCION";

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            try
            {
                string consulta = "INSERT INTO proyecto.dbo.Indicador_acciones (MES,N_conforme,detallado,especifico,area,responsable,solicito,fecha_enviado,fecha_respuesta,fecha_cierre,dias,estado,verificado,planes,observaciones) VALUES ('" + mes + "','" + no_conforme + "','" + detalle + "','" + detalle_especifico + "','" + area + "','" + responsable + "','" + solicito + "','" + fechaEnvio + "','" + fechaCierre + "','" + fechaCierreAccion + "','" + diaCierre + "','" + estado + "','" + verificado + "','" + plan_de_accion + "','" + observacion + "' ) "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {

                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión

                comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                MessageBox.Show("EL REGISTRO FUE INSERTADO CORRECTAMENTE !!", "EXITOSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Consulta();

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); //Si existe un error aquí muestra el mensaje
            }
            finally
            {
                connecting.Close();//Cierra la conexión a MySQL
            }

        }

        public void Consulta()
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataAdapter da;
            DataTable dt;
            try
            {
                da = new SqlDataAdapter("SELECT MES,N_conforme,responsable,solicito,fecha_enviado,fecha_respuesta,fecha_cierre FROM [proyecto].[dbo].[Indicador_acciones] WHERE verificado='EXTERNO'", connecting);
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

        public bool ejecutar()
        {
            string currPrsName = Process.GetCurrentProcess().ProcessName;

            //Get the name of all processes having the 
            //same name as this process name 
            Process[] allProcessWithThisName
                         = Process.GetProcessesByName(currPrsName);

            //if more than one process is running return true.
            //which means already previous instance of the application 
            //is running
            if (allProcessWithThisName.Length > 1)
            {
                MessageBox.Show("LA APLICACION YA SE ESTA EJECUTANDO ", "NO SE PUEDE ABRIR", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return true; // Yes Previous Instance Exist
            }
            else
            {
                InitializeComponent();
                Consulta();
                return false; //No Prev Instance Running
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            object select = comboBox1.SelectedItem;

            string[] Paquetes = { "Yeison Valencia", "Maricel Goyes", "Luz Angela Villegas", "Maribel Gómez" };
            string[] Produccion = { "Mauricio Castrillon", "Luz Angela Villegas" };
            string[] Calidad = { "Cristhian Muñoz", "Santiago Tarapuez", "Jennifer Campo " };
            string[] Semiautomaticas = { "James Lopez", "Diana Bastidas" };
            string[] Corte = { "Luz Angela Villegas", "Alexandra Taquinas" };
            string[] Financiero = { "Claudia Martinez", "Sandra Palacios", "Yolima Muñoz", "Martha Isabel Moreno", "Paula Betancur", "Maria Davila" };
            string[] Exterior = { "Leidy Bedoya" };
            string[] Costos = { "Luis Hernando Aponza", "Estefania Riaño", "Marlen Riascos" };
            string[] Abastecimiento = { "Alejandro Sandoval", "Juan David Solis", "Juan David Duque", "Cristhian Sanchez", "Julio Yatacue", "Wilson Ospina" };
            string[] Compras = { "Wilmar Villareal" };
            string[] Logistica = { "Jhonatan Fajardo", "Michael Osorio" };
            string[] Externos = { "Harold Bastidas", "Mauricio Gil", "Tatiana Vargas" };
            string[] Ambiental = { "Monica Hernandez" };
            string[] Sistemas = { "Emerson Restrepo", "Jhonatan Fernandez" };
            string[] Comercial = { "Diana Lasso", "Yenny Mercado", "Alejandro Clavijo", "Deisy Yurani Gomez", "Elizabeth Ardila", "Viviana Velasquez", "Julian Henao" };
            string[] Gestión = { "Ana Patria Angulo", "Lina Galindez", "Bella Consuegra", "Jhon Fabio Morales", "Johan Carvajal" };
            string[] Gerente = { "Janeth Moreno" };

            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>
            {
                { "Paquetes", Paquetes }
            };
            string[] Sistema = dictionary["Paquetes"];

            Dictionary<string, string[]> dictionary1 = new Dictionary<string, string[]>
            {
                { "Produccion", Produccion }
            };
            string[] Sistema1 = dictionary1["Produccion"];

            Dictionary<string, string[]> dictionary2 = new Dictionary<string, string[]>
            {
                { "Calidad", Calidad }
            };
            string[] Sistema2 = dictionary2["Calidad"];

            Dictionary<string, string[]> dictionary3 = new Dictionary<string, string[]>
            {
                { "Semiautomaticas", Semiautomaticas }
            };
            string[] Sistema3 = dictionary3["Semiautomaticas"];

            Dictionary<string, string[]> dictionary4 = new Dictionary<string, string[]>
            {
                { "Corte", Corte }
            };
            string[] Sistema4 = dictionary4["Corte"];

            Dictionary<string, string[]> dictionary5 = new Dictionary<string, string[]>
            {
                { "Financiero", Financiero }
            };
            string[] Sistema5 = dictionary5["Financiero"];

            Dictionary<string, string[]> dictionary6 = new Dictionary<string, string[]>
            {
                { "Exterior", Exterior }
            };
            string[] Sistema6 = dictionary6["Exterior"];

            Dictionary<string, string[]> dictionary7 = new Dictionary<string, string[]>
            {
                { "Costos", Costos }
            };
            string[] Sistema7 = dictionary7["Costos"];

            Dictionary<string, string[]> dictionary8 = new Dictionary<string, string[]>
            {
                { "Abastecimiento", Abastecimiento }
            };
            string[] Sistema8 = dictionary8["Abastecimiento"];

            Dictionary<string, string[]> dictionary9 = new Dictionary<string, string[]>
            {
                { "Compras", Compras }
            };
            string[] Sistema9 = dictionary9["Compras"];

            Dictionary<string, string[]> dictionary10 = new Dictionary<string, string[]>
            {
                { "Logistica", Logistica }
            };
            string[] Sistema10 = dictionary10["Logistica"];

            Dictionary<string, string[]> dictionary11 = new Dictionary<string, string[]>
            {
                { "Externos", Externos }
            };
            string[] Sistema11 = dictionary11["Externos"];

            Dictionary<string, string[]> dictionary12 = new Dictionary<string, string[]>
            {
                { "Ambiental", Ambiental }
            };
            string[] Sistema12 = dictionary12["Ambiental"];

            Dictionary<string, string[]> dictionary13 = new Dictionary<string, string[]>
            {
                { "Sistemas", Sistemas }
            };
            string[] Sistema13 = dictionary13["Sistemas"];

            Dictionary<string, string[]> dictionary14 = new Dictionary<string, string[]>
            {
                { "Comercial", Comercial }
            };
            string[] Sistema14 = dictionary14["Comercial"];

            Dictionary<string, string[]> dictionary15 = new Dictionary<string, string[]>
            {
                { "Gestión", Gestión }
            };
            string[] Sistema15 = dictionary15["Gestión"];

            Dictionary<string, string[]> dictionary16 = new Dictionary<string, string[]>
            {
                { "Gerente", Gerente }
            };
            string[] Sistema16 = dictionary16["Gerente"];



            /**************************************************/

#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Paquetes")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema.Length; i++)
                {
                    comboBox2.Items.Add(Sistema[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Produccion")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema1.Length; i++)
                {
                    comboBox2.Items.Add(Sistema1[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Calidad")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema2.Length; i++)
                {
                    comboBox2.Items.Add(Sistema2[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Semiautomaticas")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema3.Length; i++)
                {
                    comboBox2.Items.Add(Sistema3[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Corte")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema4.Length; i++)
                {
                    comboBox2.Items.Add(Sistema4[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Financiero")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema5.Length; i++)
                {
                    comboBox2.Items.Add(Sistema5[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Comercio Exterior")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema6.Length; i++)
                {
                    comboBox2.Items.Add(Sistema6[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Costos")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema7.Length; i++)
                {
                    comboBox2.Items.Add(Sistema7[i]);
                }
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Abastecimiento")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema8.Length; i++)
                {
                    comboBox2.Items.Add(Sistema8[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Compras")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema9.Length; i++)
                {
                    comboBox2.Items.Add(Sistema9[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Logistica")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema10.Length; i++)
                {
                    comboBox2.Items.Add(Sistema10[i]);
                }
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Externos")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema11.Length; i++)
                {
                    comboBox2.Items.Add(Sistema11[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Ambiental")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema12.Length; i++)
                {
                    comboBox2.Items.Add(Sistema12[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Sistemas")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema13.Length; i++)
                {
                    comboBox2.Items.Add(Sistema13[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Comercial")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema14.Length; i++)
                {
                    comboBox2.Items.Add(Sistema14[i]);
                }
                comboBox2.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Gestión Humana")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema15.Length; i++)
                {
                    comboBox2.Items.Add(Sistema15[i]);
                }
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Gerencia")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox2.Items.Clear();
                for (int i = 0; i < Sistema16.Length; i++)
                {
                    comboBox2.Items.Add(Sistema16[i]);
                }
                comboBox2.SelectedIndex = +0;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            object select = comboBox3.SelectedItem;

            string[] Paquetes = { "Yeison Valencia", "Maricel Goyes", "Luz Angela Villegas", "Maribel Gómez" };
            string[] Produccion = { "Mauricio Castrillon", "Luz Angela Villegas" };
            string[] Calidad = { "Cristhian Muñoz", "Santiago Tarapuez", "Jennifer Campo " };
            string[] Semiautomaticas = { "James Lopez", "Diana Bastidas" };
            string[] Corte = { "Luz Angela Villegas", "Alexandra Taquinas" };
            string[] Financiero = { "Claudia Martinez", "Sandra Palacios", "Yolima Muñoz", "Martha Isabel Moreno", "Paula Betancur", "Maria Davila" };
            string[] Exterior = { "Leidy Bedoya" };
            string[] Costos = { "Luis Hernando Aponza", "Estefania Riaño", "Marlen Riascos" };
            string[] Abastecimiento = { "Alejandro Sandoval", "Juan David Solis", "Juan David Duque", "Cristhian Sanchez", "Julio Yatacue", "Wilson Ospina" };
            string[] Compras = { "Wilmar Villareal" };
            string[] Logistica = { "Jhonatan Fajardo", "Michael Osorio" };
            string[] Externos = { "Harold Bastidas", "Mauricio Gil", "Tatiana Vargas" };
            string[] Ambiental = { "Monica Hernandez" };
            string[] Sistemas = { "Emerson Restrepo", "Jhonatan Fernandez" };
            string[] Comercial = { "Diana Lasso", "Yenny Mercado", "Alejandro Clavijo", "Deisy Yurani Gomez", "Elizabeth Ardila", "Viviana Velasquez", "Julian Henao" };
            string[] Gestión = { "Ana Patria Angulo", "Lina Galindez", "Bella Consuegra", "Jhon Fabio Morales", "Johan Carvajal" };
            string[] Gerente = { "Janeth Moreno" };

            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>
            {
                { "Paquetes", Paquetes }
            };
            string[] Sistema = dictionary["Paquetes"];

            Dictionary<string, string[]> dictionary1 = new Dictionary<string, string[]>
            {
                { "Produccion", Produccion }
            };
            string[] Sistema1 = dictionary1["Produccion"];

            Dictionary<string, string[]> dictionary2 = new Dictionary<string, string[]>
            {
                { "Calidad", Calidad }
            };
            string[] Sistema2 = dictionary2["Calidad"];

            Dictionary<string, string[]> dictionary3 = new Dictionary<string, string[]>
            {
                { "Semiautomaticas", Semiautomaticas }
            };
            string[] Sistema3 = dictionary3["Semiautomaticas"];

            Dictionary<string, string[]> dictionary4 = new Dictionary<string, string[]>
            {
                { "Corte", Corte }
            };
            string[] Sistema4 = dictionary4["Corte"];

            Dictionary<string, string[]> dictionary5 = new Dictionary<string, string[]>
            {
                { "Financiero", Financiero }
            };
            string[] Sistema5 = dictionary5["Financiero"];

            Dictionary<string, string[]> dictionary6 = new Dictionary<string, string[]>
            {
                { "Exterior", Exterior }
            };
            string[] Sistema6 = dictionary6["Exterior"];

            Dictionary<string, string[]> dictionary7 = new Dictionary<string, string[]>
            {
                { "Costos", Costos }
            };
            string[] Sistema7 = dictionary7["Costos"];

            Dictionary<string, string[]> dictionary8 = new Dictionary<string, string[]>
            {
                { "Abastecimiento", Abastecimiento }
            };
            string[] Sistema8 = dictionary8["Abastecimiento"];

            Dictionary<string, string[]> dictionary9 = new Dictionary<string, string[]>
            {
                { "Compras", Compras }
            };
            string[] Sistema9 = dictionary9["Compras"];

            Dictionary<string, string[]> dictionary10 = new Dictionary<string, string[]>
            {
                { "Logistica", Logistica }
            };
            string[] Sistema10 = dictionary10["Logistica"];

            Dictionary<string, string[]> dictionary11 = new Dictionary<string, string[]>
            {
                { "Externos", Externos }
            };
            string[] Sistema11 = dictionary11["Externos"];

            Dictionary<string, string[]> dictionary12 = new Dictionary<string, string[]>
            {
                { "Ambiental", Ambiental }
            };
            string[] Sistema12 = dictionary12["Ambiental"];

            Dictionary<string, string[]> dictionary13 = new Dictionary<string, string[]>
            {
                { "Sistemas", Sistemas }
            };
            string[] Sistema13 = dictionary13["Sistemas"];

            Dictionary<string, string[]> dictionary14 = new Dictionary<string, string[]>
            {
                { "Comercial", Comercial }
            };
            string[] Sistema14 = dictionary14["Comercial"];

            Dictionary<string, string[]> dictionary15 = new Dictionary<string, string[]>
            {
                { "Gestión", Gestión }
            };
            string[] Sistema15 = dictionary15["Gestión"];

            Dictionary<string, string[]> dictionary16 = new Dictionary<string, string[]>
            {
                { "Gerente", Gerente }
            };
            string[] Sistema16 = dictionary16["Gerente"];



            /**************************************************/

#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Paquetes")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema.Length; i++)
                {
                    comboBox4.Items.Add(Sistema[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Produccion")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema1.Length; i++)
                {
                    comboBox4.Items.Add(Sistema1[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Calidad")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema2.Length; i++)
                {
                    comboBox4.Items.Add(Sistema2[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Semiautomaticas")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema3.Length; i++)
                {
                    comboBox4.Items.Add(Sistema3[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Corte")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema4.Length; i++)
                {
                    comboBox4.Items.Add(Sistema4[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Financiero")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema5.Length; i++)
                {
                    comboBox4.Items.Add(Sistema5[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Comercio Exterior")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema6.Length; i++)
                {
                    comboBox4.Items.Add(Sistema6[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Costos")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema7.Length; i++)
                {
                    comboBox4.Items.Add(Sistema7[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Abastecimiento")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema8.Length; i++)
                {
                    comboBox4.Items.Add(Sistema8[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Compras")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema9.Length; i++)
                {
                    comboBox4.Items.Add(Sistema9[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Logistica")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema10.Length; i++)
                {
                    comboBox4.Items.Add(Sistema10[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Externos")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema11.Length; i++)
                {
                    comboBox4.Items.Add(Sistema11[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Ambiental")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema12.Length; i++)
                {
                    comboBox4.Items.Add(Sistema12[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Sistemas")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema13.Length; i++)
                {
                    comboBox4.Items.Add(Sistema13[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Comercial")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema14.Length; i++)
                {
                    comboBox4.Items.Add(Sistema14[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Gestión Humana")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema15.Length; i++)
                {
                    comboBox4.Items.Add(Sistema15[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
#pragma warning disable CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            if (select == "Gerencia")
#pragma warning restore CS0252 // Posible comparación de referencias no intencionada; para obtener una comparación de valores, convierta el lado de la izquierda en el tipo 'string'
            {

                comboBox4.Items.Clear();
                for (int i = 0; i < Sistema16.Length; i++)
                {
                    comboBox4.Items.Add(Sistema16[i]);
                }
                comboBox4.SelectedIndex = +0;
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            textBox5.Text = "" + 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Respuesta_interno respuesta = new Respuesta_interno();
            respuesta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Filtro_interno filtro = new Filtro_interno();
            filtro.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Exportar_interno exporta = new Exportar_interno();
            exporta.Show();


        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty && textBox3.Text == string.Empty && textBox4.Text == string.Empty)
            {
                MessageBox.Show("LOS CAMPOS ESTAN VACIOS");
            }
            else
            {
                DialogResult btn = MessageBox.Show("LOS DATOS ESTAN CORRECTOS ?", "VERIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (btn == DialogResult.Yes)
                {
                    insertar();
                }
                else
                {
                    MessageBox.Show("VERIFIQUE LOS DATOS PRIMERO SI TODO ESTA CORRECTO !!", "VERIFIQUE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Respuesta_externo respuesta = new Respuesta_externo();
            respuesta.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Filtro_externo filtro = new Filtro_externo();
            filtro.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Exportar_externo exporta = new Exportar_externo();
            exporta.Show();
        }

        private void Indicardor_externo_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
