namespace Indicador_de_acciones_Calidad.Vistas
{
    partial class Supervisor_externo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supervisor_externo));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nconformeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaenviadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharespuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indicadoraccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new Indicador_de_acciones_Calidad.DataSets.DataSet2();
            this.button1 = new System.Windows.Forms.Button();
            this.indicador_accionesTableAdapter = new Indicador_de_acciones_Calidad.DataSets.DataSet2TableAdapters.Indicador_accionesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nconformeDataGridViewTextBoxColumn,
            this.detalladoDataGridViewTextBoxColumn,
            this.responsableDataGridViewTextBoxColumn,
            this.solicitoDataGridViewTextBoxColumn,
            this.fechaenviadoDataGridViewTextBoxColumn,
            this.fecharespuestaDataGridViewTextBoxColumn,
            this.fechacierreDataGridViewTextBoxColumn,
            this.diasDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.indicadoraccionesBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(16, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(768, 354);
            this.dataGridView1.TabIndex = 1;
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
            // fecharespuestaDataGridViewTextBoxColumn
            // 
            this.fecharespuestaDataGridViewTextBoxColumn.DataPropertyName = "fecha_respuesta";
            this.fecharespuestaDataGridViewTextBoxColumn.HeaderText = "FECHA RESPUESTA";
            this.fecharespuestaDataGridViewTextBoxColumn.Name = "fecharespuestaDataGridViewTextBoxColumn";
            this.fecharespuestaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechacierreDataGridViewTextBoxColumn
            // 
            this.fechacierreDataGridViewTextBoxColumn.DataPropertyName = "fecha_cierre";
            this.fechacierreDataGridViewTextBoxColumn.HeaderText = "FECHA CIERRE";
            this.fechacierreDataGridViewTextBoxColumn.Name = "fechacierreDataGridViewTextBoxColumn";
            this.fechacierreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diasDataGridViewTextBoxColumn
            // 
            this.diasDataGridViewTextBoxColumn.DataPropertyName = "dias";
            this.diasDataGridViewTextBoxColumn.HeaderText = "DIAS";
            this.diasDataGridViewTextBoxColumn.Name = "diasDataGridViewTextBoxColumn";
            this.diasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // indicadoraccionesBindingSource
            // 
            this.indicadoraccionesBindingSource.DataMember = "Indicador_acciones";
            this.indicadoraccionesBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(367, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "CONTINUAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // indicador_accionesTableAdapter
            // 
            this.indicador_accionesTableAdapter.ClearBeforeFill = true;
            // 
            // Supervisor_externo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Supervisor_externo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisor_externo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Supervisor_externo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private DataSets.DataSet2 dataSet2;
        private System.Windows.Forms.BindingSource indicadoraccionesBindingSource;
        private DataSets.DataSet2TableAdapters.Indicador_accionesTableAdapter indicador_accionesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nconformeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalladoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsableDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn solicitoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaenviadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharespuestaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechacierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diasDataGridViewTextBoxColumn;
    }
}