namespace CapaPresentacion.Formularios.FormsPrincipales
{
    partial class FrmPantallaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPantallaInicial));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHistorialVentas = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNuevaVenta = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelCuentas = new CapaPresentacion.Controles.CustomGridPanel();
            this.panelVentas = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.panelVentas);
            this.groupBox1.Controls.Add(this.btnHistorialVentas);
            this.groupBox1.Location = new System.Drawing.Point(4, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 641);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Últimas 20 ventas";
            // 
            // btnHistorialVentas
            // 
            this.btnHistorialVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorialVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialVentas.FlatAppearance.BorderSize = 0;
            this.btnHistorialVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialVentas.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHistorialVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialVentas.Image")));
            this.btnHistorialVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialVentas.Location = new System.Drawing.Point(9, 37);
            this.btnHistorialVentas.Margin = new System.Windows.Forms.Padding(6);
            this.btnHistorialVentas.Name = "btnHistorialVentas";
            this.btnHistorialVentas.Size = new System.Drawing.Size(907, 57);
            this.btnHistorialVentas.TabIndex = 4;
            this.btnHistorialVentas.Text = "Historial de ventas";
            this.btnHistorialVentas.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panelCuentas);
            this.groupBox2.Controls.Add(this.btnNuevaVenta);
            this.groupBox2.Location = new System.Drawing.Point(932, -2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(471, 641);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuentas en curso";
            // 
            // btnNuevaVenta
            // 
            this.btnNuevaVenta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevaVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaVenta.FlatAppearance.BorderSize = 0;
            this.btnNuevaVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaVenta.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevaVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaVenta.Image")));
            this.btnNuevaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaVenta.Location = new System.Drawing.Point(9, 37);
            this.btnNuevaVenta.Margin = new System.Windows.Forms.Padding(6);
            this.btnNuevaVenta.Name = "btnNuevaVenta";
            this.btnNuevaVenta.Size = new System.Drawing.Size(446, 57);
            this.btnNuevaVenta.TabIndex = 5;
            this.btnNuevaVenta.Text = "Nueva venta";
            this.btnNuevaVenta.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1409, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 32;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panelCuentas
            // 
            this.panelCuentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCuentas.AutoScroll = true;
            this.panelCuentas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelCuentas.BackgroundImage")));
            this.panelCuentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelCuentas.Location = new System.Drawing.Point(9, 103);
            this.panelCuentas.Name = "panelCuentas";
            this.panelCuentas.PageSize = 10;
            this.panelCuentas.Size = new System.Drawing.Size(456, 532);
            this.panelCuentas.TabIndex = 6;
            // 
            // panelVentas
            // 
            this.panelVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVentas.AutoScroll = true;
            this.panelVentas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelVentas.BackgroundImage")));
            this.panelVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelVentas.Location = new System.Drawing.Point(9, 103);
            this.panelVentas.Name = "panelVentas";
            this.panelVentas.PageSize = 10;
            this.panelVentas.Size = new System.Drawing.Size(907, 532);
            this.panelVentas.TabIndex = 5;
            // 
            // FrmPantallaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1446, 645);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmPantallaInicial";
            this.Text = "Pantalla inicial";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHistorialVentas;
        private System.Windows.Forms.Button btnNuevaVenta;
        private CapaPresentacion.Controles.CustomGridPanel panelVentas;
        private CapaPresentacion.Controles.CustomGridPanel panelCuentas;
        private System.Windows.Forms.Button btnClose;
    }
}