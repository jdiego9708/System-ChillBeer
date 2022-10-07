namespace CapaPresentacion.Formularios.FormsTurnos
{
    partial class FrmTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTurno));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBase = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTotalVentas = new System.Windows.Forms.TextBox();
            this.gbBase = new System.Windows.Forms.GroupBox();
            this.txtCambiarBase = new System.Windows.Forms.TextBox();
            this.gbGuardarBase = new System.Windows.Forms.GroupBox();
            this.btnSaveBase = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtEgresos = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.txtOtrosIngresos = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInfoPagos = new System.Windows.Forms.TextBox();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnHistorialTurnos = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTotalTurno = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnResumenDiario = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbBase.SuspendLayout();
            this.gbGuardarBase.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBase);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 115);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base inicial";
            // 
            // txtBase
            // 
            this.txtBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBase.BackColor = System.Drawing.Color.White;
            this.txtBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBase.Enabled = false;
            this.txtBase.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtBase.Location = new System.Drawing.Point(8, 47);
            this.txtBase.Margin = new System.Windows.Forms.Padding(5);
            this.txtBase.Name = "txtBase";
            this.txtBase.ReadOnly = true;
            this.txtBase.Size = new System.Drawing.Size(183, 39);
            this.txtBase.TabIndex = 1;
            this.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTotalVentas);
            this.groupBox3.Location = new System.Drawing.Point(12, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 115);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total ventas";
            // 
            // txtTotalVentas
            // 
            this.txtTotalVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalVentas.BackColor = System.Drawing.Color.White;
            this.txtTotalVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalVentas.Enabled = false;
            this.txtTotalVentas.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtTotalVentas.Location = new System.Drawing.Point(8, 47);
            this.txtTotalVentas.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalVentas.Name = "txtTotalVentas";
            this.txtTotalVentas.ReadOnly = true;
            this.txtTotalVentas.Size = new System.Drawing.Size(183, 39);
            this.txtTotalVentas.TabIndex = 1;
            this.txtTotalVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbBase
            // 
            this.gbBase.Controls.Add(this.txtCambiarBase);
            this.gbBase.Location = new System.Drawing.Point(236, 91);
            this.gbBase.Name = "gbBase";
            this.gbBase.Size = new System.Drawing.Size(203, 115);
            this.gbBase.TabIndex = 2;
            this.gbBase.TabStop = false;
            this.gbBase.Text = "Nueva base";
            this.toolTip1.SetToolTip(this.gbBase, "Nuevo valor para la base inicial");
            // 
            // txtCambiarBase
            // 
            this.txtCambiarBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCambiarBase.BackColor = System.Drawing.Color.White;
            this.txtCambiarBase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCambiarBase.Font = new System.Drawing.Font("Segoe UI Emoji", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCambiarBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtCambiarBase.Location = new System.Drawing.Point(16, 45);
            this.txtCambiarBase.Margin = new System.Windows.Forms.Padding(5);
            this.txtCambiarBase.Name = "txtCambiarBase";
            this.txtCambiarBase.Size = new System.Drawing.Size(171, 40);
            this.txtCambiarBase.TabIndex = 1;
            this.txtCambiarBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtCambiarBase, "Nuevo valor para la base inicial");
            // 
            // gbGuardarBase
            // 
            this.gbGuardarBase.Controls.Add(this.btnSaveBase);
            this.gbGuardarBase.Location = new System.Drawing.Point(459, 91);
            this.gbGuardarBase.Name = "gbGuardarBase";
            this.gbGuardarBase.Size = new System.Drawing.Size(109, 115);
            this.gbGuardarBase.TabIndex = 3;
            this.gbGuardarBase.TabStop = false;
            this.gbGuardarBase.Text = "Guardar";
            // 
            // btnSaveBase
            // 
            this.btnSaveBase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveBase.BackgroundImage")));
            this.btnSaveBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveBase.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSaveBase.FlatAppearance.BorderSize = 0;
            this.btnSaveBase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSaveBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBase.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBase.Location = new System.Drawing.Point(21, 34);
            this.btnSaveBase.Margin = new System.Windows.Forms.Padding(5);
            this.btnSaveBase.Name = "btnSaveBase";
            this.btnSaveBase.Size = new System.Drawing.Size(70, 70);
            this.btnSaveBase.TabIndex = 29;
            this.toolTip1.SetToolTip(this.btnSaveBase, "Guardar el nuevo valor de la base");
            this.btnSaveBase.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtEgresos);
            this.groupBox8.Location = new System.Drawing.Point(236, 212);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(203, 115);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Total egresos";
            // 
            // txtEgresos
            // 
            this.txtEgresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEgresos.BackColor = System.Drawing.Color.White;
            this.txtEgresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEgresos.Enabled = false;
            this.txtEgresos.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtEgresos.Location = new System.Drawing.Point(8, 47);
            this.txtEgresos.Margin = new System.Windows.Forms.Padding(5);
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.ReadOnly = true;
            this.txtEgresos.Size = new System.Drawing.Size(186, 39);
            this.txtEgresos.TabIndex = 1;
            this.txtEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.txtOtrosIngresos);
            this.groupBox10.Location = new System.Drawing.Point(12, 333);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(200, 115);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Otros ingresos";
            // 
            // txtOtrosIngresos
            // 
            this.txtOtrosIngresos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOtrosIngresos.BackColor = System.Drawing.Color.White;
            this.txtOtrosIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOtrosIngresos.Enabled = false;
            this.txtOtrosIngresos.Font = new System.Drawing.Font("Segoe UI Emoji", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtrosIngresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtOtrosIngresos.Location = new System.Drawing.Point(8, 47);
            this.txtOtrosIngresos.Margin = new System.Windows.Forms.Padding(5);
            this.txtOtrosIngresos.Name = "txtOtrosIngresos";
            this.txtOtrosIngresos.ReadOnly = true;
            this.txtOtrosIngresos.Size = new System.Drawing.Size(183, 39);
            this.txtOtrosIngresos.TabIndex = 1;
            this.txtOtrosIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(33)))), ((int)(((byte)(116)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 23);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtInfoPagos);
            this.groupBox1.Location = new System.Drawing.Point(12, 455);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 187);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de pagos";
            // 
            // txtInfoPagos
            // 
            this.txtInfoPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoPagos.BackColor = System.Drawing.Color.White;
            this.txtInfoPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoPagos.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoPagos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtInfoPagos.Location = new System.Drawing.Point(8, 32);
            this.txtInfoPagos.Margin = new System.Windows.Forms.Padding(5);
            this.txtInfoPagos.Multiline = true;
            this.txtInfoPagos.Name = "txtInfoPagos";
            this.txtInfoPagos.ReadOnly = true;
            this.txtInfoPagos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfoPagos.Size = new System.Drawing.Size(677, 147);
            this.txtInfoPagos.TabIndex = 1;
            this.txtInfoPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarCaja.FlatAppearance.BorderSize = 0;
            this.btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrarCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarCaja.Image")));
            this.btnCerrarCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarCaja.Location = new System.Drawing.Point(375, 31);
            this.btnCerrarCaja.Margin = new System.Windows.Forms.Padding(6);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(348, 57);
            this.btnCerrarCaja.TabIndex = 12;
            this.btnCerrarCaja.Text = "Cerrar caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = false;
            // 
            // btnHistorialTurnos
            // 
            this.btnHistorialTurnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHistorialTurnos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialTurnos.FlatAppearance.BorderSize = 0;
            this.btnHistorialTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialTurnos.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorialTurnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnHistorialTurnos.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialTurnos.Image")));
            this.btnHistorialTurnos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialTurnos.Location = new System.Drawing.Point(12, 31);
            this.btnHistorialTurnos.Margin = new System.Windows.Forms.Padding(6);
            this.btnHistorialTurnos.Name = "btnHistorialTurnos";
            this.btnHistorialTurnos.Size = new System.Drawing.Size(343, 57);
            this.btnHistorialTurnos.TabIndex = 9;
            this.btnHistorialTurnos.Text = "Historial de cierres";
            this.btnHistorialTurnos.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtTotalTurno);
            this.groupBox4.Location = new System.Drawing.Point(236, 333);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(203, 115);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Total turno";
            // 
            // txtTotalTurno
            // 
            this.txtTotalTurno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalTurno.BackColor = System.Drawing.Color.White;
            this.txtTotalTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalTurno.Enabled = false;
            this.txtTotalTurno.Font = new System.Drawing.Font("Segoe UI Emoji", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalTurno.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.txtTotalTurno.Location = new System.Drawing.Point(8, 48);
            this.txtTotalTurno.Margin = new System.Windows.Forms.Padding(5);
            this.txtTotalTurno.Name = "txtTotalTurno";
            this.txtTotalTurno.ReadOnly = true;
            this.txtTotalTurno.Size = new System.Drawing.Size(186, 43);
            this.txtTotalTurno.TabIndex = 1;
            this.txtTotalTurno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnResumenDiario);
            this.groupBox5.Location = new System.Drawing.Point(459, 334);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(109, 115);
            this.groupBox5.TabIndex = 33;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ver";
            // 
            // btnResumenDiario
            // 
            this.btnResumenDiario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnResumenDiario.BackgroundImage")));
            this.btnResumenDiario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnResumenDiario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResumenDiario.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnResumenDiario.FlatAppearance.BorderSize = 0;
            this.btnResumenDiario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnResumenDiario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnResumenDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumenDiario.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumenDiario.Location = new System.Drawing.Point(21, 33);
            this.btnResumenDiario.Margin = new System.Windows.Forms.Padding(5);
            this.btnResumenDiario.Name = "btnResumenDiario";
            this.btnResumenDiario.Size = new System.Drawing.Size(70, 70);
            this.btnResumenDiario.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnResumenDiario, "Generar reporte");
            this.btnResumenDiario.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnRefresh);
            this.groupBox11.Location = new System.Drawing.Point(459, 212);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(109, 115);
            this.groupBox11.TabIndex = 33;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Hoy";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(21, 33);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(70, 70);
            this.btnRefresh.TabIndex = 32;
            this.toolTip1.SetToolTip(this.btnRefresh, "Cargar la caja de HOY");
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // FrmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(723, 654);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnHistorialTurnos);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.gbGuardarBase);
            this.Controls.Add(this.gbBase);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Segoe UI Emoji", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(0)))), ((int)(((byte)(85)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmTurno";
            this.Text = "Caja diaria";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbBase.ResumeLayout(false);
            this.gbBase.PerformLayout();
            this.gbGuardarBase.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBase;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtTotalVentas;
        private System.Windows.Forms.GroupBox gbBase;
        private System.Windows.Forms.TextBox txtCambiarBase;
        private System.Windows.Forms.GroupBox gbGuardarBase;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtEgresos;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox txtOtrosIngresos;
        private System.Windows.Forms.Button btnHistorialTurnos;
        private System.Windows.Forms.Button btnSaveBase;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInfoPagos;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTotalTurno;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnResumenDiario;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button btnRefresh;
    }
}