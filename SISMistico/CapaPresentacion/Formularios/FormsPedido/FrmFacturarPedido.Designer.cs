namespace CapaPresentacion.Formularios.FormsPedido
{
    partial class FrmFacturarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturarPedido));
            this.lblFecha = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblMesero = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTerminar = new System.Windows.Forms.Button();
            this.rdNinguna = new System.Windows.Forms.RadioButton();
            this.chkRecordarOpcion = new System.Windows.Forms.CheckBox();
            this.rdAmbas = new System.Windows.Forms.RadioButton();
            this.rdCorreo = new System.Windows.Forms.RadioButton();
            this.rdImprimir = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotalParcial = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelSubTotal = new System.Windows.Forms.Panel();
            this.txtCantidadPedidosCliente = new System.Windows.Forms.TextBox();
            this.panelDescuentos = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelTipoPedido = new System.Windows.Forms.Panel();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.panelProductos = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelSubTotal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelTipoPedido.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblFecha.Location = new System.Drawing.Point(13, 36);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(59, 21);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label6.Location = new System.Drawing.Point(10, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 28);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cliente:";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblCliente.Location = new System.Drawing.Point(93, 69);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(83, 26);
            this.lblCliente.TabIndex = 7;
            this.lblCliente.Text = "Cliente:";
            this.toolTip1.SetToolTip(this.lblCliente, "Ver datos del cliente");
            // 
            // lblMesero
            // 
            this.lblMesero.AutoSize = true;
            this.lblMesero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMesero.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblMesero.Location = new System.Drawing.Point(105, 108);
            this.lblMesero.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMesero.Name = "lblMesero";
            this.lblMesero.Size = new System.Drawing.Size(86, 26);
            this.lblMesero.TabIndex = 9;
            this.lblMesero.Text = "Mesero:";
            this.toolTip1.SetToolTip(this.lblMesero, "Seleccionar otro mesero");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label9.Location = new System.Drawing.Point(10, 106);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 28);
            this.label9.TabIndex = 8;
            this.label9.Text = "Atiende:";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTerminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnTerminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminar.Image")));
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTerminar.Location = new System.Drawing.Point(14, 291);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(5);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(173, 63);
            this.btnTerminar.TabIndex = 11;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnTerminar, "Terminar");
            this.btnTerminar.UseVisualStyleBackColor = true;
            // 
            // rdNinguna
            // 
            this.rdNinguna.AutoSize = true;
            this.rdNinguna.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdNinguna.Location = new System.Drawing.Point(5, 156);
            this.rdNinguna.Margin = new System.Windows.Forms.Padding(5);
            this.rdNinguna.Name = "rdNinguna";
            this.rdNinguna.Size = new System.Drawing.Size(110, 32);
            this.rdNinguna.TabIndex = 25;
            this.rdNinguna.Tag = "Ninguna";
            this.rdNinguna.Text = "Ninguna";
            this.rdNinguna.UseVisualStyleBackColor = true;
            // 
            // chkRecordarOpcion
            // 
            this.chkRecordarOpcion.AutoSize = true;
            this.chkRecordarOpcion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRecordarOpcion.Location = new System.Drawing.Point(8, 724);
            this.chkRecordarOpcion.Margin = new System.Windows.Forms.Padding(5);
            this.chkRecordarOpcion.Name = "chkRecordarOpcion";
            this.chkRecordarOpcion.Size = new System.Drawing.Size(183, 32);
            this.chkRecordarOpcion.TabIndex = 3;
            this.chkRecordarOpcion.Text = "Recordar opción";
            this.chkRecordarOpcion.UseVisualStyleBackColor = true;
            this.chkRecordarOpcion.Visible = false;
            // 
            // rdAmbas
            // 
            this.rdAmbas.AutoSize = true;
            this.rdAmbas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdAmbas.Location = new System.Drawing.Point(5, 114);
            this.rdAmbas.Margin = new System.Windows.Forms.Padding(5);
            this.rdAmbas.Name = "rdAmbas";
            this.rdAmbas.Size = new System.Drawing.Size(94, 32);
            this.rdAmbas.TabIndex = 2;
            this.rdAmbas.Tag = "Ambas";
            this.rdAmbas.Text = "Ambas";
            this.rdAmbas.UseVisualStyleBackColor = true;
            // 
            // rdCorreo
            // 
            this.rdCorreo.AutoSize = true;
            this.rdCorreo.Checked = true;
            this.rdCorreo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdCorreo.Location = new System.Drawing.Point(5, 44);
            this.rdCorreo.Margin = new System.Windows.Forms.Padding(5);
            this.rdCorreo.Name = "rdCorreo";
            this.rdCorreo.Size = new System.Drawing.Size(151, 60);
            this.rdCorreo.TabIndex = 1;
            this.rdCorreo.TabStop = true;
            this.rdCorreo.Tag = "Correo";
            this.rdCorreo.Text = "Enviar correo\r\nelectrónico";
            this.rdCorreo.UseVisualStyleBackColor = true;
            // 
            // rdImprimir
            // 
            this.rdImprimir.AutoSize = true;
            this.rdImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdImprimir.Location = new System.Drawing.Point(5, 2);
            this.rdImprimir.Margin = new System.Windows.Forms.Padding(5);
            this.rdImprimir.Name = "rdImprimir";
            this.rdImprimir.Size = new System.Drawing.Size(108, 32);
            this.rdImprimir.TabIndex = 0;
            this.rdImprimir.Tag = "Imprimir";
            this.rdImprimir.Text = "Imprimir";
            this.rdImprimir.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblTotal.Location = new System.Drawing.Point(124, 253);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(105, 36);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label11.Location = new System.Drawing.Point(11, 253);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 36);
            this.label11.TabIndex = 14;
            this.label11.Text = "TOTAL:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label12.Location = new System.Drawing.Point(10, 148);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 28);
            this.label12.TabIndex = 16;
            this.label12.Text = "Total parcial:";
            // 
            // lblTotalParcial
            // 
            this.lblTotalParcial.AutoSize = true;
            this.lblTotalParcial.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalParcial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblTotalParcial.Location = new System.Drawing.Point(156, 148);
            this.lblTotalParcial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalParcial.Name = "lblTotalParcial";
            this.lblTotalParcial.Size = new System.Drawing.Size(144, 28);
            this.lblTotalParcial.TabIndex = 17;
            this.lblTotalParcial.Text = "Total parcial:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblSubTotal.Location = new System.Drawing.Point(125, 12);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(85, 28);
            this.lblSubTotal.TabIndex = 22;
            this.lblSubTotal.Text = "TOTAL:";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 28);
            this.label5.TabIndex = 21;
            this.label5.Text = "Subtotal:";
            // 
            // panelSubTotal
            // 
            this.panelSubTotal.Controls.Add(this.label5);
            this.panelSubTotal.Controls.Add(this.lblSubTotal);
            this.panelSubTotal.Location = new System.Drawing.Point(0, 190);
            this.panelSubTotal.Margin = new System.Windows.Forms.Padding(5);
            this.panelSubTotal.Name = "panelSubTotal";
            this.panelSubTotal.Size = new System.Drawing.Size(414, 58);
            this.panelSubTotal.TabIndex = 23;
            // 
            // txtCantidadPedidosCliente
            // 
            this.txtCantidadPedidosCliente.BackColor = System.Drawing.Color.White;
            this.txtCantidadPedidosCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadPedidosCliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPedidosCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCantidadPedidosCliente.Location = new System.Drawing.Point(10, 1026);
            this.txtCantidadPedidosCliente.Margin = new System.Windows.Forms.Padding(5);
            this.txtCantidadPedidosCliente.Multiline = true;
            this.txtCantidadPedidosCliente.Name = "txtCantidadPedidosCliente";
            this.txtCantidadPedidosCliente.Size = new System.Drawing.Size(934, 81);
            this.txtCantidadPedidosCliente.TabIndex = 24;
            // 
            // panelDescuentos
            // 
            this.panelDescuentos.Location = new System.Drawing.Point(8, 36);
            this.panelDescuentos.Margin = new System.Windows.Forms.Padding(5);
            this.panelDescuentos.Name = "panelDescuentos";
            this.panelDescuentos.Size = new System.Drawing.Size(672, 721);
            this.panelDescuentos.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelProductos);
            this.groupBox1.Location = new System.Drawing.Point(12, 322);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 454);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del pedido";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelTipoPedido);
            this.groupBox2.Controls.Add(this.btnTerminar);
            this.groupBox2.Controls.Add(this.chkRecordarOpcion);
            this.groupBox2.Location = new System.Drawing.Point(1148, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 764);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factura";
            // 
            // panelTipoPedido
            // 
            this.panelTipoPedido.Controls.Add(this.rdImprimir);
            this.panelTipoPedido.Controls.Add(this.rdCorreo);
            this.panelTipoPedido.Controls.Add(this.rdNinguna);
            this.panelTipoPedido.Controls.Add(this.rdAmbas);
            this.panelTipoPedido.Location = new System.Drawing.Point(7, 63);
            this.panelTipoPedido.Name = "panelTipoPedido";
            this.panelTipoPedido.Size = new System.Drawing.Size(187, 196);
            this.panelTipoPedido.TabIndex = 26;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.label12);
            this.gbInfo.Controls.Add(this.label11);
            this.gbInfo.Controls.Add(this.lblTotal);
            this.gbInfo.Controls.Add(this.lblTotalParcial);
            this.gbInfo.Controls.Add(this.lblMesero);
            this.gbInfo.Controls.Add(this.panelSubTotal);
            this.gbInfo.Controls.Add(this.label9);
            this.gbInfo.Controls.Add(this.lblFecha);
            this.gbInfo.Controls.Add(this.lblCliente);
            this.gbInfo.Controls.Add(this.label6);
            this.gbInfo.Location = new System.Drawing.Point(12, 12);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(414, 304);
            this.gbInfo.TabIndex = 33;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Pedido número";
            // 
            // panelProductos
            // 
            this.panelProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProductos.AutoScroll = true;
            this.panelProductos.Location = new System.Drawing.Point(6, 32);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.PageSize = 10;
            this.panelProductos.Size = new System.Drawing.Size(400, 415);
            this.panelProductos.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panelDescuentos);
            this.groupBox3.Location = new System.Drawing.Point(434, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(708, 764);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Opciones de facturación";
            // 
            // FrmFacturarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1360, 782);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtCantidadPedidosCliente);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.MaximizeBox = false;
            this.Name = "FrmFacturarPedido";
            this.Text = "Facturar pedido";
            this.panelSubTotal.ResumeLayout(false);
            this.panelSubTotal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelTipoPedido.ResumeLayout(false);
            this.panelTipoPedido.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblMesero;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.RadioButton rdCorreo;
        private System.Windows.Forms.RadioButton rdImprimir;
        private System.Windows.Forms.RadioButton rdAmbas;
        private System.Windows.Forms.CheckBox chkRecordarOpcion;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotalParcial;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelSubTotal;
        private System.Windows.Forms.TextBox txtCantidadPedidosCliente;
        private System.Windows.Forms.RadioButton rdNinguna;
        private System.Windows.Forms.Panel panelDescuentos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CapaPresentacion.Controles.CustomGridPanel panelProductos;
        private System.Windows.Forms.Panel panelTipoPedido;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}