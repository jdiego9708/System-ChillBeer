namespace CapaPresentacion.Formularios.FormsVentas
{
    partial class FrmPerfilVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfilVenta));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnArchivarVenta = new System.Windows.Forms.Button();
            this.txtInfoVenta = new System.Windows.Forms.TextBox();
            this.txtInfoCliente = new System.Windows.Forms.TextBox();
            this.txtInfoPago = new System.Windows.Forms.TextBox();
            this.txtInfoProductos = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInfoCliente);
            this.groupBox1.Location = new System.Drawing.Point(12, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del cliente";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInfoVenta);
            this.groupBox2.Location = new System.Drawing.Point(12, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de la venta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInfoPago);
            this.groupBox3.Location = new System.Drawing.Point(12, 267);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 176);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del pago";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtInfoProductos);
            this.groupBox4.Location = new System.Drawing.Point(596, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(684, 603);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Productos consumidos";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnArchivarVenta);
            this.groupBox5.Controls.Add(this.btnSendEmail);
            this.groupBox5.Controls.Add(this.btnPrint);
            this.groupBox5.Location = new System.Drawing.Point(12, 625);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1268, 109);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Opciones";
            // 
            // btnPrint
            // 
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(12, 37);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(158, 57);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendEmail.FlatAppearance.BorderSize = 0;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSendEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnSendEmail.Image")));
            this.btnSendEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendEmail.Location = new System.Drawing.Point(178, 37);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(6);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(197, 57);
            this.btnSendEmail.TabIndex = 5;
            this.btnSendEmail.Text = "Enviar correo";
            this.btnSendEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendEmail.UseVisualStyleBackColor = true;
            // 
            // btnArchivarVenta
            // 
            this.btnArchivarVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchivarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnArchivarVenta.FlatAppearance.BorderSize = 0;
            this.btnArchivarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchivarVenta.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchivarVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnArchivarVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnArchivarVenta.Image")));
            this.btnArchivarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnArchivarVenta.Location = new System.Drawing.Point(1043, 37);
            this.btnArchivarVenta.Margin = new System.Windows.Forms.Padding(6);
            this.btnArchivarVenta.Name = "btnArchivarVenta";
            this.btnArchivarVenta.Size = new System.Drawing.Size(216, 57);
            this.btnArchivarVenta.TabIndex = 6;
            this.btnArchivarVenta.Text = "Archivar venta";
            this.btnArchivarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnArchivarVenta.UseVisualStyleBackColor = true;
            // 
            // txtInfoVenta
            // 
            this.txtInfoVenta.BackColor = System.Drawing.Color.White;
            this.txtInfoVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoVenta.Enabled = false;
            this.txtInfoVenta.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoVenta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtInfoVenta.Location = new System.Drawing.Point(6, 32);
            this.txtInfoVenta.Multiline = true;
            this.txtInfoVenta.Name = "txtInfoVenta";
            this.txtInfoVenta.ReadOnly = true;
            this.txtInfoVenta.Size = new System.Drawing.Size(560, 210);
            this.txtInfoVenta.TabIndex = 25;
            this.txtInfoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInfoCliente
            // 
            this.txtInfoCliente.BackColor = System.Drawing.Color.White;
            this.txtInfoCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoCliente.Enabled = false;
            this.txtInfoCliente.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtInfoCliente.Location = new System.Drawing.Point(10, 36);
            this.txtInfoCliente.Multiline = true;
            this.txtInfoCliente.Name = "txtInfoCliente";
            this.txtInfoCliente.ReadOnly = true;
            this.txtInfoCliente.Size = new System.Drawing.Size(560, 130);
            this.txtInfoCliente.TabIndex = 26;
            this.txtInfoCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInfoPago
            // 
            this.txtInfoPago.BackColor = System.Drawing.Color.White;
            this.txtInfoPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoPago.Enabled = false;
            this.txtInfoPago.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtInfoPago.Location = new System.Drawing.Point(6, 34);
            this.txtInfoPago.Multiline = true;
            this.txtInfoPago.Name = "txtInfoPago";
            this.txtInfoPago.ReadOnly = true;
            this.txtInfoPago.Size = new System.Drawing.Size(560, 130);
            this.txtInfoPago.TabIndex = 27;
            this.txtInfoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInfoProductos
            // 
            this.txtInfoProductos.BackColor = System.Drawing.Color.White;
            this.txtInfoProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoProductos.Enabled = false;
            this.txtInfoProductos.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtInfoProductos.Location = new System.Drawing.Point(7, 29);
            this.txtInfoProductos.Multiline = true;
            this.txtInfoProductos.Name = "txtInfoProductos";
            this.txtInfoProductos.ReadOnly = true;
            this.txtInfoProductos.Size = new System.Drawing.Size(671, 564);
            this.txtInfoProductos.TabIndex = 28;
            this.txtInfoProductos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmPerfilVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1292, 741);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FrmPerfilVenta";
            this.Text = "Venta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnArchivarVenta;
        private System.Windows.Forms.TextBox txtInfoVenta;
        private System.Windows.Forms.TextBox txtInfoCliente;
        private System.Windows.Forms.TextBox txtInfoPago;
        private System.Windows.Forms.TextBox txtInfoProductos;
    }
}