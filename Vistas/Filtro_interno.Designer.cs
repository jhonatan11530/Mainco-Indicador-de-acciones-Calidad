namespace Indicador_de_acciones_Calidad
{
    partial class Filtro_interno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filtro_interno));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataSet1 = new Indicador_de_acciones_Calidad.DataSets.DataSet1();
            this.indicadoraccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.indicador_accionesTableAdapter = new Indicador_de_acciones_Calidad.DataSets.DataSet1TableAdapters.Indicador_accionesTableAdapter();
            this.mESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nconformeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especificoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaenviadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharespuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(50, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(247, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECCIONES EL MES";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1223, 345);
            this.panel1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mESDataGridViewTextBoxColumn,
            this.nconformeDataGridViewTextBoxColumn,
            this.detalladoDataGridViewTextBoxColumn,
            this.especificoDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.responsableDataGridViewTextBoxColumn,
            this.solicitoDataGridViewTextBoxColumn,
            this.fechaenviadoDataGridViewTextBoxColumn,
            this.fechacierreDataGridViewTextBoxColumn,
            this.fecharespuestaDataGridViewTextBoxColumn,
            this.diasDataGridViewTextBoxColumn,
            this.estadoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.indicadoraccionesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1215, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // indicadoraccionesBindingSource
            // 
            this.indicadoraccionesBindingSource.DataMember = "Indicador_acciones";
            this.indicadoraccionesBindingSource.DataSource = this.dataSet1;
            // 
            // indicador_accionesTableAdapter
            // 
            this.indicador_accionesTableAdapter.ClearBeforeFill = true;
            // 
            // mESDataGridViewTextBoxColumn
            // 
            this.mESDataGridViewTextBoxColumn.DataPropertyName = "MES";
            this.mESDataGridViewTextBoxColumn.HeaderText = "MES";
            this.mESDataGridViewTextBoxColumn.Name = "mESDataGridViewTextBoxColumn";
            this.mESDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nconformeDataGridViewTextBoxColumn
            // 
            this.nconformeDataGridViewTextBoxColumn.DataPropertyName = "N_conforme";
            this.nconformeDataGridViewTextBoxColumn.HeaderText = "N° NO CONFORME";
            this.nconformeDataGridViewTextBoxColumn.Name = "nconformeDataGridViewTextBoxColumn";
            this.nconformeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // detalladoDataGridViewTextBoxColumn
            // 
            this.detalladoDataGridViewTextBoxColumn.DataPropertyName = "detallado";
            this.detalladoDataGridViewTextBoxColumn.HeaderText = "DETALLADO";
            this.detalladoDataGridViewTextBoxColumn.Name = "detalladoDataGridViewTextBoxColumn";
            this.detalladoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // especificoDataGridViewTextBoxColumn
            // 
            this.especificoDataGridViewTextBoxColumn.DataPropertyName = "especifico";
            this.especificoDataGridViewTextBoxColumn.HeaderText = "ESPECIFICO";
            this.especificoDataGridViewTextBoxColumn.Name = "especificoDataGridViewTextBoxColumn";
            this.especificoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "AREA";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // responsableDataGridViewTextBoxColumn
            // 
            this.responsableDataGridViewTextBoxColumn.DataPropertyName = "responsable";
            this.responsableDataGridViewTextBoxColumn.HeaderText = "RESPONSABLE";
            this.responsableDataGridViewTextBoxColumn.Name = "responsableDataGridViewTextBoxColumn";
            this.responsableDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // solicitoDataGridViewTextBoxColumn
            // 
            this.solicitoDataGridViewTextBoxColumn.DataPropertyName = "solicito";
            this.solicitoDataGridViewTextBoxColumn.HeaderText = "SOLICITO";
            this.solicitoDataGridViewTextBoxColumn.Name = "solicitoDataGridViewTextBoxColumn";
            this.solicitoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaenviadoDataGridViewTextBoxColumn
            // 
            this.fechaenviadoDataGridViewTextBoxColumn.DataPropertyName = "fecha_enviado";
            this.fechaenviadoDataGridViewTextBoxColumn.HeaderText = "FECHA ENVIADO";
            this.fechaenviadoDataGridViewTextBoxColumn.Name = "fechaenviadoDataGridViewTextBoxColumn";
            this.fechaenviadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechacierreDataGridViewTextBoxColumn
            // 
            this.fechacierreDataGridViewTextBoxColumn.DataPropertyName = "fecha_cierre";
            this.fechacierreDataGridViewTextBoxColumn.HeaderText = "FECHA CIERRE";
            this.fechacierreDataGridViewTextBoxColumn.Name = "fechacierreDataGridViewTextBoxColumn";
            this.fechacierreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fecharespuestaDataGridViewTextBoxColumn
            // 
            this.fecharespuestaDataGridViewTextBoxColumn.DataPropertyName = "fecha_respuesta";
            this.fecharespuestaDataGridViewTextBoxColumn.HeaderText = "FECHA RESPUESTA";
            this.fecharespuestaDataGridViewTextBoxColumn.Name = "fecharespuestaDataGridViewTextBoxColumn";
            this.fecharespuestaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diasDataGridViewTextBoxColumn
            // 
            this.diasDataGridViewTextBoxColumn.DataPropertyName = "dias";
            this.diasDataGridViewTextBoxColumn.HeaderText = "DIAS";
            this.diasDataGridViewTextBoxColumn.Name = "diasDataGridViewTextBoxColumn";
            this.diasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            this.estadoDataGridViewTextBoxColumn.DataPropertyName = "estado";
            this.estadoDataGridViewTextBoxColumn.HeaderText = "ESTADO";
            this.estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            this.estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Filtro_interno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filtro_interno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filtro";
            this.Load += new System.EventHandler(this.Filtro_interno_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSets.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource indicadoraccionesBindingSource;
        private DataSets.DataSet1TableAdapters.Indicador_accionesTableAdapter indicador_accionesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mESDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nconformeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalladoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn especificoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaenviadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharespuestaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
    }
}