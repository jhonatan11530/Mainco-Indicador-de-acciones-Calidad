using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Indicador_de_acciones_Calidad
{
    public partial class Exportar_interno : Form
    {
        private int num = 9;
        public Exportar_interno()
        {
            InitializeComponent();


            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            button1.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valor_uno = comboBox1.Text;
            string valor_dos = comboBox2.Text;
            string valor_tres = comboBox3.Text;
            string valor_cuatro = comboBox4.Text;
            if (valor_uno != "")
            {
                ExportMes(valor_uno);
            }
            if (valor_dos != "")
            {
                ExportDetalle(valor_dos);
            }
            if (valor_tres != "")
            {
                ExportArea(valor_tres);
            }
            if (valor_cuatro != "")
            {
                ExportDato();
            }

        }

        public void mes()
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT MES FROM proyecto.dbo.Indicador_acciones WHERE verificado='INTERNO' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    comboBox1.Items.Add(reader.GetString(0));
                    comboBox1.SelectedIndex = +0;
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

        public void detalle()
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT detallado FROM proyecto.dbo.Indicador_acciones WHERE verificado='INTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    comboBox2.Items.Add(reader.GetString(0));
                    comboBox2.SelectedIndex = +0;
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

        public void area()
        {

            Conexion conexion = new Conexion();
            SqlConnection connecting = conexion.connecting();
            SqlDataReader reader = conexion.reader();
            try
            {
                string consulta = "SELECT area FROM proyecto.dbo.Indicador_acciones WHERE verificado='INTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                SqlCommand comando = new SqlCommand(consulta)
                {
                    Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                }; //Declaración SQL para ejecutar contra una base de datos MySQL
                connecting.Open(); //Abre la conexión
                reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader

                while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                {
                    comboBox3.Items.Add(reader.GetString(0));
                    comboBox3.SelectedIndex = +0;
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

        public void ExportDato()
        {

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    string ruta = fd.SelectedPath;


                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                    if (xlApp == null)

                    {

                        MessageBox.Show("Excel no esta instalado en el equipo!!");

                        return;

                    }



                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells.Columns[2].ColumnWidth = 21;
                    xlWorkSheet.Cells.Columns[3].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[4].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[6].ColumnWidth = 17;
                    xlWorkSheet.Cells.Columns[8].ColumnWidth = 20;
                    xlWorkSheet.Cells.Columns[9].ColumnWidth = 23;
                    xlWorkSheet.Cells.Columns[10].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[11].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[13].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[14].ColumnWidth = 15;

                    xlWorkSheet.Cells[8, 1] = "MES";
                    xlWorkSheet.Cells[8, 2] = "No. NO CONFORMIDAD";
                    xlWorkSheet.Cells[8, 3] = "DETALLES";
                    xlWorkSheet.Cells[8, 4] = "DETALLES ESPECIFICO";
                    xlWorkSheet.Cells[8, 5] = "AREA";
                    xlWorkSheet.Cells[8, 6] = "RESPONSABLE";
                    xlWorkSheet.Cells[8, 7] = "SOLICITO";
                    xlWorkSheet.Cells[8, 8] = "FECHA RESPUESTA";
                    xlWorkSheet.Cells[8, 9] = "FECHA CIERRE ACCION";
                    xlWorkSheet.Cells[8, 10] = "FECHA CIERRE REAL";
                    xlWorkSheet.Cells[8, 11] = "DIAS CIERRE";
                    xlWorkSheet.Cells[8, 12] = "ESTADO";
                    xlWorkSheet.Cells[8, 13] = "PLANES DE ACCION";
                    xlWorkSheet.Cells[8, 13] = "PLAN DE ACCION";
                    xlWorkSheet.Cells[8, 14] = "OBSERVACIONES";

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
                        ArrayList num1 = new ArrayList();
                        List<int> num2 = new List<int>();
                        ArrayList num3 = new ArrayList();
                        ArrayList num4 = new ArrayList();
                        ArrayList num5 = new ArrayList();
                        ArrayList num6 = new ArrayList();
                        ArrayList num7 = new ArrayList();
                        ArrayList num8 = new ArrayList();
                        ArrayList num9 = new ArrayList();
                        ArrayList num10 = new ArrayList();
                        List<int> num11 = new List<int>();
                        ArrayList num12 = new ArrayList();
                        ArrayList num13 = new ArrayList();
                        ArrayList num14 = new ArrayList();
                        while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                        {
                            //reader.GetInt32(1) reader.GetInt32(10)
                            num1.Add(reader.GetString(0));
                            num2.Add(Convert.ToInt32(reader["N_conforme"]));
                            num3.Add(reader.GetString(2));
                            num4.Add(reader.GetString(3));
                            num5.Add(reader.GetString(4));
                            num6.Add(reader.GetString(5));
                            num7.Add(reader.GetString(6));
                            num8.Add(reader.GetString(7));
                            num9.Add(reader.GetString(8));
                            num10.Add(reader.GetString(9));
                            num11.Add(Convert.ToInt32(reader["dias"]));
                            num12.Add(reader.GetString(11));
                            num13.Add(reader.GetString(12));
                            num14.Add(reader.GetString(13));

                        }


                        for (int i = 0; i < num1.Count; i++)
                        {
                            xlWorkSheet.Cells[num, 1] = num1[i];
                            xlWorkSheet.Cells[num, 2] = num2[i];
                            xlWorkSheet.Cells[num, 3] = num3[i];
                            xlWorkSheet.Cells[num, 4] = num4[i];
                            xlWorkSheet.Cells[num, 5] = num5[i];
                            xlWorkSheet.Cells[num, 6] = num6[i];
                            xlWorkSheet.Cells[num, 7] = num7[i];
                            xlWorkSheet.Cells[num, 8] = num8[i];
                            xlWorkSheet.Cells[num, 9] = num9[i];
                            xlWorkSheet.Cells[num, 10] = num10[i];
                            xlWorkSheet.Cells[num, 11] = num11[i];
                            xlWorkSheet.Cells[num, 12] = num12[i];
                            xlWorkSheet.Cells[num, 13] = num13[i];
                            xlWorkSheet.Cells[num, 14] = num14[i];
                            num++;
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



                    xlWorkBook.SaveAs(ruta + "/INFORME.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);

                    xlApp.Quit();


                    Marshal.ReleaseComObject(xlWorkSheet);

                    Marshal.ReleaseComObject(xlWorkBook);

                    Marshal.ReleaseComObject(xlApp);


                    MessageBox.Show("EL ARCHIVO EXCEL FUE CREADO Y SE ENCUENTRA EN " + ruta + "/INFORME.xls", "EXPORTACION EXITOSAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Hide();
        }

        public void ExportMes(string variable)
        {

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    string ruta = fd.SelectedPath;


                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                    if (xlApp == null)

                    {

                        MessageBox.Show("Excel no esta instalado en el equipo!!");

                        return;

                    }



                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells.Columns[2].ColumnWidth = 21;
                    xlWorkSheet.Cells.Columns[3].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[4].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[6].ColumnWidth = 17;
                    xlWorkSheet.Cells.Columns[8].ColumnWidth = 20;
                    xlWorkSheet.Cells.Columns[9].ColumnWidth = 23;
                    xlWorkSheet.Cells.Columns[10].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[11].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[13].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[14].ColumnWidth = 15;

                    xlWorkSheet.Cells[8, 1] = "MES";
                    xlWorkSheet.Cells[8, 2] = "No. NO CONFORMIDAD";
                    xlWorkSheet.Cells[8, 3] = "DETALLES";
                    xlWorkSheet.Cells[8, 4] = "DETALLES ESPECIFICO";
                    xlWorkSheet.Cells[8, 5] = "AREA";
                    xlWorkSheet.Cells[8, 6] = "RESPONSABLE";
                    xlWorkSheet.Cells[8, 7] = "SOLICITO";
                    xlWorkSheet.Cells[8, 8] = "FECHA RESPUESTA";
                    xlWorkSheet.Cells[8, 9] = "FECHA CIERRE ACCION";
                    xlWorkSheet.Cells[8, 10] = "FECHA CIERRE REAL";
                    xlWorkSheet.Cells[8, 11] = "DIAS CIERRE";
                    xlWorkSheet.Cells[8, 12] = "ESTADO";
                    xlWorkSheet.Cells[8, 13] = "PLANES DE ACCION";
                    xlWorkSheet.Cells[8, 13] = "PLAN DE ACCION";
                    xlWorkSheet.Cells[8, 14] = "OBSERVACIONES";

                    Conexion conexion = new Conexion();
                    SqlConnection connecting = conexion.connecting();
                    SqlDataReader reader = conexion.reader();
                    try
                    {
                        string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones WHERE MES='" + variable + "' AND verificado='INTERNO' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                        SqlCommand comando = new SqlCommand(consulta)
                        {
                            Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                        }; //Declaración SQL para ejecutar contra una base de datos MySQL
                        connecting.Open(); //Abre la conexión
                        reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                        ArrayList num1 = new ArrayList();
                        List<int> num2 = new List<int>();
                        ArrayList num3 = new ArrayList();
                        ArrayList num4 = new ArrayList();
                        ArrayList num5 = new ArrayList();
                        ArrayList num6 = new ArrayList();
                        ArrayList num7 = new ArrayList();
                        ArrayList num8 = new ArrayList();
                        ArrayList num9 = new ArrayList();
                        ArrayList num10 = new ArrayList();
                        List<int> num11 = new List<int>();
                        ArrayList num12 = new ArrayList();
                        ArrayList num13 = new ArrayList();
                        ArrayList num14 = new ArrayList();
                        while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                        {
                            //reader.GetInt32(1) reader.GetInt32(10)
                            num1.Add(reader.GetString(0));
                            num2.Add(Convert.ToInt32(reader["N_conforme"]));
                            num3.Add(reader.GetString(2));
                            num4.Add(reader.GetString(3));
                            num5.Add(reader.GetString(4));
                            num6.Add(reader.GetString(5));
                            num7.Add(reader.GetString(6));
                            num8.Add(reader.GetString(7));
                            num9.Add(reader.GetString(8));
                            num10.Add(reader.GetString(9));
                            num11.Add(Convert.ToInt32(reader["dias"]));
                            num12.Add(reader.GetString(11));
                            num13.Add(reader.GetString(12));
                            num14.Add(reader.GetString(13));

                        }


                        for (int i = 0; i < num1.Count; i++)
                        {
                            xlWorkSheet.Cells[num, 1] = num1[i];
                            xlWorkSheet.Cells[num, 2] = num2[i];
                            xlWorkSheet.Cells[num, 3] = num3[i];
                            xlWorkSheet.Cells[num, 4] = num4[i];
                            xlWorkSheet.Cells[num, 5] = num5[i];
                            xlWorkSheet.Cells[num, 6] = num6[i];
                            xlWorkSheet.Cells[num, 7] = num7[i];
                            xlWorkSheet.Cells[num, 8] = num8[i];
                            xlWorkSheet.Cells[num, 9] = num9[i];
                            xlWorkSheet.Cells[num, 10] = num10[i];
                            xlWorkSheet.Cells[num, 11] = num11[i];
                            xlWorkSheet.Cells[num, 12] = num12[i];
                            xlWorkSheet.Cells[num, 13] = num13[i];
                            xlWorkSheet.Cells[num, 14] = num14[i];
                            num++;
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



                    xlWorkBook.SaveAs(ruta + "/INFORME.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);

                    xlApp.Quit();


                    Marshal.ReleaseComObject(xlWorkSheet);

                    Marshal.ReleaseComObject(xlWorkBook);

                    Marshal.ReleaseComObject(xlApp);


                    MessageBox.Show("EL ARCHIVO EXCEL FUE CREADO Y SE ENCUENTRA EN " + ruta + "/INFORME.xls", "EXPORTACION EXITOSAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Hide();
        }

        public void ExportDetalle(string variable)
        {

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    string ruta = fd.SelectedPath;


                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                    if (xlApp == null)

                    {

                        MessageBox.Show("Excel no esta instalado en el equipo!!");

                        return;

                    }



                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells.Columns[2].ColumnWidth = 21;
                    xlWorkSheet.Cells.Columns[3].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[4].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[6].ColumnWidth = 17;
                    xlWorkSheet.Cells.Columns[8].ColumnWidth = 20;
                    xlWorkSheet.Cells.Columns[9].ColumnWidth = 23;
                    xlWorkSheet.Cells.Columns[10].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[11].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[13].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[14].ColumnWidth = 15;

                    xlWorkSheet.Cells[8, 1] = "MES";
                    xlWorkSheet.Cells[8, 2] = "No. NO CONFORMIDAD";
                    xlWorkSheet.Cells[8, 3] = "DETALLES";
                    xlWorkSheet.Cells[8, 4] = "DETALLES ESPECIFICO";
                    xlWorkSheet.Cells[8, 5] = "AREA";
                    xlWorkSheet.Cells[8, 6] = "RESPONSABLE";
                    xlWorkSheet.Cells[8, 7] = "SOLICITO";
                    xlWorkSheet.Cells[8, 8] = "FECHA RESPUESTA";
                    xlWorkSheet.Cells[8, 9] = "FECHA CIERRE ACCION";
                    xlWorkSheet.Cells[8, 10] = "FECHA CIERRE REAL";
                    xlWorkSheet.Cells[8, 11] = "DIAS CIERRE";
                    xlWorkSheet.Cells[8, 12] = "ESTADO";
                    xlWorkSheet.Cells[8, 13] = "PLANES DE ACCION";
                    xlWorkSheet.Cells[8, 13] = "PLAN DE ACCION";
                    xlWorkSheet.Cells[8, 14] = "OBSERVACIONES";

                    Conexion conexion = new Conexion();
                    SqlConnection connecting = conexion.connecting();
                    SqlDataReader reader = conexion.reader();
                    try
                    {
                        string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones WHERE detallado='" + variable + "' AND verificado='INTERNO' "; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                        SqlCommand comando = new SqlCommand(consulta)
                        {
                            Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                        }; //Declaración SQL para ejecutar contra una base de datos MySQL
                        connecting.Open(); //Abre la conexión
                        reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                        ArrayList num1 = new ArrayList();
                        List<int> num2 = new List<int>();
                        ArrayList num3 = new ArrayList();
                        ArrayList num4 = new ArrayList();
                        ArrayList num5 = new ArrayList();
                        ArrayList num6 = new ArrayList();
                        ArrayList num7 = new ArrayList();
                        ArrayList num8 = new ArrayList();
                        ArrayList num9 = new ArrayList();
                        ArrayList num10 = new ArrayList();
                        List<int> num11 = new List<int>();
                        ArrayList num12 = new ArrayList();
                        ArrayList num13 = new ArrayList();
                        ArrayList num14 = new ArrayList();
                        while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                        {
                            //reader.GetInt32(1) reader.GetInt32(10)
                            num1.Add(reader.GetString(0));
                            num2.Add(Convert.ToInt32(reader["N_conforme"]));
                            num3.Add(reader.GetString(2));
                            num4.Add(reader.GetString(3));
                            num5.Add(reader.GetString(4));
                            num6.Add(reader.GetString(5));
                            num7.Add(reader.GetString(6));
                            num8.Add(reader.GetString(7));
                            num9.Add(reader.GetString(8));
                            num10.Add(reader.GetString(9));
                            num11.Add(Convert.ToInt32(reader["dias"]));
                            num12.Add(reader.GetString(11));
                            num13.Add(reader.GetString(12));
                            num14.Add(reader.GetString(13));

                        }


                        for (int i = 0; i < num1.Count; i++)
                        {
                            xlWorkSheet.Cells[num, 1] = num1[i];
                            xlWorkSheet.Cells[num, 2] = num2[i];
                            xlWorkSheet.Cells[num, 3] = num3[i];
                            xlWorkSheet.Cells[num, 4] = num4[i];
                            xlWorkSheet.Cells[num, 5] = num5[i];
                            xlWorkSheet.Cells[num, 6] = num6[i];
                            xlWorkSheet.Cells[num, 7] = num7[i];
                            xlWorkSheet.Cells[num, 8] = num8[i];
                            xlWorkSheet.Cells[num, 9] = num9[i];
                            xlWorkSheet.Cells[num, 10] = num10[i];
                            xlWorkSheet.Cells[num, 11] = num11[i];
                            xlWorkSheet.Cells[num, 12] = num12[i];
                            xlWorkSheet.Cells[num, 13] = num13[i];
                            xlWorkSheet.Cells[num, 14] = num14[i];
                            num++;
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



                    xlWorkBook.SaveAs(ruta + "/INFORME.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);

                    xlApp.Quit();


                    Marshal.ReleaseComObject(xlWorkSheet);

                    Marshal.ReleaseComObject(xlWorkBook);

                    Marshal.ReleaseComObject(xlApp);


                    MessageBox.Show("EL ARCHIVO EXCEL FUE CREADO Y SE ENCUENTRA EN " + ruta + "/INFORME.xls", "EXPORTACION EXITOSAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Hide();
        }

        public void ExportArea(string variable)
        {

            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                {
                    string ruta = fd.SelectedPath;


                    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                    if (xlApp == null)

                    {

                        MessageBox.Show("Excel no esta instalado en el equipo!!");

                        return;

                    }



                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    xlWorkSheet.Cells.Columns[2].ColumnWidth = 21;
                    xlWorkSheet.Cells.Columns[3].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[4].ColumnWidth = 35;
                    xlWorkSheet.Cells.Columns[6].ColumnWidth = 17;
                    xlWorkSheet.Cells.Columns[8].ColumnWidth = 20;
                    xlWorkSheet.Cells.Columns[9].ColumnWidth = 23;
                    xlWorkSheet.Cells.Columns[10].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[11].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[13].ColumnWidth = 15;
                    xlWorkSheet.Cells.Columns[14].ColumnWidth = 15;

                    xlWorkSheet.Cells[8, 1] = "MES";
                    xlWorkSheet.Cells[8, 2] = "No. NO CONFORMIDAD";
                    xlWorkSheet.Cells[8, 3] = "DETALLES";
                    xlWorkSheet.Cells[8, 4] = "DETALLES ESPECIFICO";
                    xlWorkSheet.Cells[8, 5] = "AREA";
                    xlWorkSheet.Cells[8, 6] = "RESPONSABLE";
                    xlWorkSheet.Cells[8, 7] = "SOLICITO";
                    xlWorkSheet.Cells[8, 8] = "FECHA RESPUESTA";
                    xlWorkSheet.Cells[8, 9] = "FECHA CIERRE ACCION";
                    xlWorkSheet.Cells[8, 10] = "FECHA CIERRE REAL";
                    xlWorkSheet.Cells[8, 11] = "DIAS CIERRE";
                    xlWorkSheet.Cells[8, 12] = "ESTADO";
                    xlWorkSheet.Cells[8, 13] = "PLANES DE ACCION";
                    xlWorkSheet.Cells[8, 13] = "PLAN DE ACCION";
                    xlWorkSheet.Cells[8, 14] = "OBSERVACIONES";

                    Conexion conexion = new Conexion();
                    SqlConnection connecting = conexion.connecting();
                    SqlDataReader reader = conexion.reader();
                    try
                    {
                        string consulta = "SELECT * FROM proyecto.dbo.Indicador_acciones WHERE area='" + variable + "' AND verificado='INTERNO'"; //Consulta a MySQL (Muestra las bases de datos que tiene el servidor)
                        SqlCommand comando = new SqlCommand(consulta)
                        {
                            Connection = connecting //Establece la MySqlConnection utilizada por esta instancia de MySqlCommand
                        }; //Declaración SQL para ejecutar contra una base de datos MySQL
                        connecting.Open(); //Abre la conexión
                        reader = comando.ExecuteReader(); //Ejecuta la consulta y crea un MySqlDataReader
                        ArrayList num1 = new ArrayList();
                        List<int> num2 = new List<int>();
                        ArrayList num3 = new ArrayList();
                        ArrayList num4 = new ArrayList();
                        ArrayList num5 = new ArrayList();
                        ArrayList num6 = new ArrayList();
                        ArrayList num7 = new ArrayList();
                        ArrayList num8 = new ArrayList();
                        ArrayList num9 = new ArrayList();
                        ArrayList num10 = new ArrayList();
                        List<int> num11 = new List<int>();
                        ArrayList num12 = new ArrayList();
                        ArrayList num13 = new ArrayList();
                        ArrayList num14 = new ArrayList();
                        while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
                        {
                            //reader.GetInt32(1) reader.GetInt32(10)
                            num1.Add(reader.GetString(0));
                            num2.Add(Convert.ToInt32(reader["N_conforme"]));
                            num3.Add(reader.GetString(2));
                            num4.Add(reader.GetString(3));
                            num5.Add(reader.GetString(4));
                            num6.Add(reader.GetString(5));
                            num7.Add(reader.GetString(6));
                            num8.Add(reader.GetString(7));
                            num9.Add(reader.GetString(8));
                            num10.Add(reader.GetString(9));
                            num11.Add(Convert.ToInt32(reader["dias"]));
                            num12.Add(reader.GetString(11));
                            num13.Add(reader.GetString(12));
                            num14.Add(reader.GetString(13));

                        }


                        for (int i = 0; i < num1.Count; i++)
                        {
                            xlWorkSheet.Cells[num, 1] = num1[i];
                            xlWorkSheet.Cells[num, 2] = num2[i];
                            xlWorkSheet.Cells[num, 3] = num3[i];
                            xlWorkSheet.Cells[num, 4] = num4[i];
                            xlWorkSheet.Cells[num, 5] = num5[i];
                            xlWorkSheet.Cells[num, 6] = num6[i];
                            xlWorkSheet.Cells[num, 7] = num7[i];
                            xlWorkSheet.Cells[num, 8] = num8[i];
                            xlWorkSheet.Cells[num, 9] = num9[i];
                            xlWorkSheet.Cells[num, 10] = num10[i];
                            xlWorkSheet.Cells[num, 11] = num11[i];
                            xlWorkSheet.Cells[num, 12] = num12[i];
                            xlWorkSheet.Cells[num, 13] = num13[i];
                            xlWorkSheet.Cells[num, 14] = num14[i];
                            num++;
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



                    xlWorkBook.SaveAs(ruta + "/INFORME.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    xlWorkBook.Close(true, misValue, misValue);

                    xlApp.Quit();


                    Marshal.ReleaseComObject(xlWorkSheet);

                    Marshal.ReleaseComObject(xlWorkBook);

                    Marshal.ReleaseComObject(xlApp);


                    MessageBox.Show("EL ARCHIVO EXCEL FUE CREADO Y SE ENCUENTRA EN " + ruta + "/INFORME.xls", "EXPORTACION EXITOSAMENTE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            button1.Enabled = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();

            button1.Enabled = true;

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox4.Checked = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            button1.Enabled = true;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();


        }

        private void checkBox1_Click_1(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            comboBox1.Enabled = true;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            button1.Enabled = true;
            mes();
        }

        private void checkBox2_Click_1(object sender, EventArgs e)
        {
            checkBox2.Checked = true;
            comboBox2.Enabled = true;

            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;

            button1.Enabled = true;

            detalle();
        }

        private void checkBox3_Click_1(object sender, EventArgs e)
        {
            checkBox3.Checked = true;
            comboBox3.Enabled = true;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox4.Enabled = false;

            button1.Enabled = true;
            area();
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            checkBox4.Checked = true;
            comboBox4.Enabled = true;

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;

            comboBox4.Items.Add("EXPORTAR TODO");

            button1.Enabled = true;

            comboBox4.SelectedIndex = +0;
        }

    }
}
