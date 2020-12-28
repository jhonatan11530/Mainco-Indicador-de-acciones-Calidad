namespace Indicador_de_acciones_Calidad
{
    partial class Supervisador_interno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Supervisador_interno));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.indicadoraccionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet7 = new Indicador_de_acciones_Calidad.DataSets.DataSet7();
            this.button1 = new System.Windows.Forms.Button();
            this.indicador_accionesTableAdapter = new Indicador_de_acciones_Calidad.DataSets.DataSet7TableAdapters.Indicador_accionesTableAdapter();
            this.nconformeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalladoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solicitoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaenviadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharespuestaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechacierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet7)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 362);
            this.panel1.TabIndex = 0;
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(768, 354);
            this.dataGridView1.TabIndex = 0;
            // 
            // indicadoraccionesBindingSource
            // 
            this.indicadoraccionesBindingSource.DataMember = "Indicador_acciones";
            this.indicadoraccionesBindingSource.DataSource = this.dataSet7;
            // 
            // dataSet7
            // 
            this.dataSet7.DataSetName = "DataSet7";
            this.dataSet7.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(359, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "CONTINUAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // indicador_accionesTableAdapter
            // 
            this.indicador_accionesTableAdapter.ClearBeforeFill = true;
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
            // Supervisador_interno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Supervisador_interno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supervisador";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.indicadoraccionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private DataSets.DataSet7 dataSet7;
        private System.Windows.Forms.BindingSource indicadoraccionesBindingSource;
        private DataSets.DataSet7TableAdapters.Indicador_accionesTableAdapter indicador_accionesTableAdapter;
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