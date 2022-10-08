namespace CapaPresentacion.Formularios.FormsAdministracion
{
    partial class FrmAdministracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministracion));
            this.gbTurno = new System.Windows.Forms.GroupBox();
            this.panelTurno = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnHistorialVentas = new System.Windows.Forms.Button();
            this.btnAddIngreso = new System.Windows.Forms.Button();
            this.btnAddGasto = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.graphicsVentas2 = new CapaPresentacion.Formularios.FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas();
            this.graphicsVentas1 = new CapaPresentacion.Formularios.FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas();
            this.gbTurno.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTurno
            // 
            this.gbTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTurno.Controls.Add(this.panelTurno);
            this.gbTurno.Location = new System.Drawing.Point(12, -5);
            this.gbTurno.Name = "gbTurno";
            this.gbTurno.Size = new System.Drawing.Size(761, 795);
            this.gbTurno.TabIndex = 0;
            this.gbTurno.TabStop = false;
            this.gbTurno.Text = "Caja del día";
            // 
            // panelTurno
            // 
            this.panelTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelTurno.Location = new System.Drawing.Point(6, 34);
            this.panelTurno.Name = "panelTurno";
            this.panelTurno.Size = new System.Drawing.Size(749, 755);
            this.panelTurno.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnReportes);
            this.groupBox2.Controls.Add(this.btnHistorialVentas);
            this.groupBox2.Controls.Add(this.btnAddIngreso);
            this.groupBox2.Controls.Add(this.btnAddGasto);
            this.groupBox2.Location = new System.Drawing.Point(1308, -5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 795);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accesos directos";
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.White;
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(4, 291);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(6);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(273, 75);
            this.btnReportes.TabIndex = 16;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = false;
            // 
            // btnHistorialVentas
            // 
            this.btnHistorialVentas.BackColor = System.Drawing.Color.White;
            this.btnHistorialVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialVentas.FlatAppearance.BorderSize = 0;
            this.btnHistorialVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialVentas.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHistorialVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialVentas.Image")));
            this.btnHistorialVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialVentas.Location = new System.Drawing.Point(4, 204);
            this.btnHistorialVentas.Margin = new System.Windows.Forms.Padding(6);
            this.btnHistorialVentas.Name = "btnHistorialVentas";
            this.btnHistorialVentas.Size = new System.Drawing.Size(273, 75);
            this.btnHistorialVentas.TabIndex = 15;
            this.btnHistorialVentas.Text = "Historial de \r\nventas";
            this.btnHistorialVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistorialVentas.UseVisualStyleBackColor = false;
            // 
            // btnAddIngreso
            // 
            this.btnAddIngreso.BackColor = System.Drawing.Color.White;
            this.btnAddIngreso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIngreso.FlatAppearance.BorderSize = 0;
            this.btnAddIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIngreso.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIngreso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnAddIngreso.Image")));
            this.btnAddIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddIngreso.Location = new System.Drawing.Point(4, 37);
            this.btnAddIngreso.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddIngreso.Name = "btnAddIngreso";
            this.btnAddIngreso.Size = new System.Drawing.Size(273, 75);
            this.btnAddIngreso.TabIndex = 14;
            this.btnAddIngreso.Text = "Registrar ingreso";
            this.btnAddIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddIngreso.UseVisualStyleBackColor = false;
            // 
            // btnAddGasto
            // 
            this.btnAddGasto.BackColor = System.Drawing.Color.White;
            this.btnAddGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddGasto.FlatAppearance.BorderSize = 0;
            this.btnAddGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGasto.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGasto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGasto.Image")));
            this.btnAddGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddGasto.Location = new System.Drawing.Point(4, 117);
            this.btnAddGasto.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddGasto.Name = "btnAddGasto";
            this.btnAddGasto.Size = new System.Drawing.Size(273, 75);
            this.btnAddGasto.TabIndex = 13;
            this.btnAddGasto.Text = "Registrar gasto";
            this.btnAddGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddGasto.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.graphicsVentas2);
            this.groupBox3.Controls.Add(this.graphicsVentas1);
            this.groupBox3.Location = new System.Drawing.Point(779, -5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 795);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estadísticas";
            // 
            // graphicsVentas2
            // 
            this.graphicsVentas2.BackColor = System.Drawing.Color.White;
            this.graphicsVentas2.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsVentas2.Location = new System.Drawing.Point(9, 375);
            this.graphicsVentas2.Margin = new System.Windows.Forms.Padding(6);
            this.graphicsVentas2.Name = "graphicsVentas2";
            this.graphicsVentas2.Size = new System.Drawing.Size(477, 340);
            this.graphicsVentas2.TabIndex = 1;
            // 
            // graphicsVentas1
            // 
            this.graphicsVentas1.BackColor = System.Drawing.Color.White;
            this.graphicsVentas1.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphicsVentas1.Location = new System.Drawing.Point(7, 35);
            this.graphicsVentas1.Margin = new System.Windows.Forms.Padding(6);
            this.graphicsVentas1.Name = "graphicsVentas1";
            this.graphicsVentas1.Size = new System.Drawing.Size(479, 340);
            this.graphicsVentas1.TabIndex = 0;
            // 
            // FrmAdministracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1611, 802);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTurno);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmAdministracion";
            this.Text = "Administracion Chill Beer";
            this.gbTurno.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTurno;
        private System.Windows.Forms.Panel panelTurno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddGasto;
        private System.Windows.Forms.Button btnAddIngreso;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnHistorialVentas;
        private FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas graphicsVentas2;
        private FormsEstadisticas.FormEstadisticasIniciales.GraphicsVentas graphicsVentas1;
    }
}