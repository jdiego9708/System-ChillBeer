namespace CapaPresentacion.Formularios.FormsPedido
{
    partial class DescuentosOpcionesPedido
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ListaDescuentos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPropina = new System.Windows.Forms.TextBox();
            this.gbCupon = new System.Windows.Forms.GroupBox();
            this.txtCupon = new System.Windows.Forms.TextBox();
            this.lblTotalParcial = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPropinaSugerida = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkDesechables = new System.Windows.Forms.CheckBox();
            this.txtPrecioDesechables = new System.Windows.Forms.TextBox();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.chkDomicilio = new System.Windows.Forms.CheckBox();
            this.panelMetodosPago = new CapaPresentacion.Controles.CustomGridPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbCupon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(593, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descuentos disponibles:";
            // 
            // ListaDescuentos
            // 
            this.ListaDescuentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListaDescuentos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListaDescuentos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ListaDescuentos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListaDescuentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.ListaDescuentos.FormattingEnabled = true;
            this.ListaDescuentos.Location = new System.Drawing.Point(627, 40);
            this.ListaDescuentos.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.ListaDescuentos.Name = "ListaDescuentos";
            this.ListaDescuentos.Size = new System.Drawing.Size(169, 29);
            this.ListaDescuentos.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(256, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Propina mesero:";
            this.label2.Visible = false;
            // 
            // txtPropina
            // 
            this.txtPropina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtPropina.Location = new System.Drawing.Point(262, 343);
            this.txtPropina.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtPropina.Name = "txtPropina";
            this.txtPropina.Size = new System.Drawing.Size(166, 32);
            this.txtPropina.TabIndex = 3;
            this.txtPropina.Tag = "PROPINA";
            this.txtPropina.Visible = false;
            // 
            // gbCupon
            // 
            this.gbCupon.Controls.Add(this.txtCupon);
            this.gbCupon.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCupon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.gbCupon.Location = new System.Drawing.Point(637, 75);
            this.gbCupon.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbCupon.Name = "gbCupon";
            this.gbCupon.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbCupon.Size = new System.Drawing.Size(145, 72);
            this.gbCupon.TabIndex = 4;
            this.gbCupon.TabStop = false;
            this.gbCupon.Text = "Cupón o bono";
            // 
            // txtCupon
            // 
            this.txtCupon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtCupon.Location = new System.Drawing.Point(12, 30);
            this.txtCupon.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtCupon.Name = "txtCupon";
            this.txtCupon.Size = new System.Drawing.Size(116, 29);
            this.txtCupon.TabIndex = 5;
            // 
            // lblTotalParcial
            // 
            this.lblTotalParcial.AutoSize = true;
            this.lblTotalParcial.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalParcial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblTotalParcial.Location = new System.Drawing.Point(134, 7);
            this.lblTotalParcial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotalParcial.Name = "lblTotalParcial";
            this.lblTotalParcial.Size = new System.Drawing.Size(144, 28);
            this.lblTotalParcial.TabIndex = 21;
            this.lblTotalParcial.Text = "Total parcial:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 26);
            this.label12.TabIndex = 20;
            this.label12.Text = "Total parcial:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtObservaciones.Location = new System.Drawing.Point(9, 28);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(251, 124);
            this.txtObservaciones.TabIndex = 25;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.lblTotal.Location = new System.Drawing.Point(472, 204);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 36);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.label5.Location = new System.Drawing.Point(373, 204);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 36);
            this.label5.TabIndex = 26;
            this.label5.Text = "TOTAL:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblSubtotal.Location = new System.Drawing.Point(450, 157);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(144, 28);
            this.lblSubtotal.TabIndex = 29;
            this.lblSubtotal.Text = "Total parcial:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label6.Location = new System.Drawing.Point(351, 159);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 26);
            this.label6.TabIndex = 28;
            this.label6.Text = "Subtotal:";
            // 
            // lblPropinaSugerida
            // 
            this.lblPropinaSugerida.AutoSize = true;
            this.lblPropinaSugerida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPropinaSugerida.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPropinaSugerida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.lblPropinaSugerida.Location = new System.Drawing.Point(432, 274);
            this.lblPropinaSugerida.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPropinaSugerida.Name = "lblPropinaSugerida";
            this.lblPropinaSugerida.Size = new System.Drawing.Size(90, 28);
            this.lblPropinaSugerida.TabIndex = 30;
            this.lblPropinaSugerida.Text = "Propina";
            this.toolTip1.SetToolTip(this.lblPropinaSugerida, "Oprima para editar");
            this.lblPropinaSugerida.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(257, 274);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 26);
            this.label4.TabIndex = 31;
            this.label4.Text = "Propina sugerida:";
            this.label4.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelMetodosPago);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.groupBox1.Location = new System.Drawing.Point(9, 240);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Size = new System.Drawing.Size(814, 289);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Método de pago";
            // 
            // chkDesechables
            // 
            this.chkDesechables.AutoSize = true;
            this.chkDesechables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDesechables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.chkDesechables.Location = new System.Drawing.Point(340, 7);
            this.chkDesechables.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chkDesechables.Name = "chkDesechables";
            this.chkDesechables.Size = new System.Drawing.Size(215, 30);
            this.chkDesechables.TabIndex = 34;
            this.chkDesechables.Text = "Cobrar desechables";
            this.chkDesechables.UseVisualStyleBackColor = true;
            // 
            // txtPrecioDesechables
            // 
            this.txtPrecioDesechables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtPrecioDesechables.Location = new System.Drawing.Point(356, 36);
            this.txtPrecioDesechables.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtPrecioDesechables.Name = "txtPrecioDesechables";
            this.txtPrecioDesechables.Size = new System.Drawing.Size(166, 32);
            this.txtPrecioDesechables.TabIndex = 35;
            this.txtPrecioDesechables.Tag = "0";
            this.txtPrecioDesechables.Visible = false;
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtDomicilio.Location = new System.Drawing.Point(356, 102);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(166, 32);
            this.txtDomicilio.TabIndex = 37;
            this.txtDomicilio.Tag = "0";
            this.txtDomicilio.Visible = false;
            // 
            // chkDomicilio
            // 
            this.chkDomicilio.AutoSize = true;
            this.chkDomicilio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkDomicilio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.chkDomicilio.Location = new System.Drawing.Point(348, 73);
            this.chkDomicilio.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.chkDomicilio.Name = "chkDomicilio";
            this.chkDomicilio.Size = new System.Drawing.Size(188, 30);
            this.chkDomicilio.TabIndex = 36;
            this.chkDomicilio.Text = "Cobrar domicilio";
            this.chkDomicilio.UseVisualStyleBackColor = true;
            // 
            // panelMetodosPago
            // 
            this.panelMetodosPago.AutoScroll = true;
            this.panelMetodosPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.panelMetodosPago.Location = new System.Drawing.Point(9, 34);
            this.panelMetodosPago.Margin = new System.Windows.Forms.Padding(4);
            this.panelMetodosPago.Name = "panelMetodosPago";
            this.panelMetodosPago.PageSize = 10;
            this.panelMetodosPago.Size = new System.Drawing.Size(794, 246);
            this.panelMetodosPago.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtObservaciones);
            this.groupBox2.Location = new System.Drawing.Point(9, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 159);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Observaciones";
            // 
            // DescuentosOpcionesPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.chkDomicilio);
            this.Controls.Add(this.txtPrecioDesechables);
            this.Controls.Add(this.chkDesechables);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPropinaSugerida);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTotalParcial);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.gbCupon);
            this.Controls.Add(this.txtPropina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ListaDescuentos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DescuentosOpcionesPedido";
            this.Size = new System.Drawing.Size(832, 536);
            this.gbCupon.ResumeLayout(false);
            this.gbCupon.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbCupon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox ListaDescuentos;
        public System.Windows.Forms.TextBox txtPropina;
        public System.Windows.Forms.TextBox txtCupon;
        public System.Windows.Forms.Label lblTotalParcial;
        public System.Windows.Forms.Label lblSubtotal;
        public System.Windows.Forms.Label lblPropinaSugerida;
        public System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.CheckBox chkDesechables;
        public System.Windows.Forms.TextBox txtPrecioDesechables;
        public System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.CheckBox chkDomicilio;
        private CapaPresentacion.Controles.CustomGridPanel panelMetodosPago;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
