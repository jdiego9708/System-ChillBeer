using CapaEntidades.Helpers;
using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.Controles;
using CapaPresentacion.Formularios.FormsEstadisticas;
using Microsoft.Win32;
using Syncfusion.WinForms.Input;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsTurnos
{
    public partial class FrmTurno : Form
    {
        public FrmTurno()
        {
            InitializeComponent();
            this.txtCambiarBase.KeyPress += Txt_KeyPress;
            this.txtCambiarBase.GotFocus += Txt_GotFocus;
            this.txtCambiarBase.LostFocus += Txt_LostFocus;
            this.btnSaveBase.Click += BtnSaveBase_Click;
            this.btnHistorialTurnos.Click += BtnHistorialTurnos_Click;
            this.btnResumenDiario.Click += BtnResumenDiario_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            string fecha_seleccionada = DateTime.Now.ToString("yyyy-MM-dd");
            this.btnHistorialTurnos.Text = DateTime.Now.ToString("yyyy-MM-dd");

            BaseChangedSuccess?.Invoke(this.Turno, e);
        }
        private void BtnResumenDiario_Click(object sender, EventArgs e)
        {
            FrmReporteDiario frmReporteDiario = new FrmReporteDiario
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
            };
            frmReporteDiario.LoadEstadistica(this.Turno.Id_turno);
            frmReporteDiario.ShowDialog();
        }
        private void BtnHistorialTurnos_Click(object sender, EventArgs e)
        {
            CustomDateTimePicker picker = new CustomDateTimePicker();
            picker.OnCalendarSelectionChanged += Picker_OnCalendarSelectionChanged;
            this.containerCalendario = new PoperContainer(picker);
            this.containerCalendario.Show(this.btnHistorialTurnos);
        }
        private void Picker_OnCalendarSelectionChanged(object sender, EventArgs e)
        {
            SfCalendar calendar1 = (SfCalendar)sender;

            if (calendar1 == null) return;

            DateTime? dateSelected = calendar1.SelectedDate;

            if (dateSelected == null) return;

            string fecha_seleccionada = dateSelected.Value.ToString("yyyy-MM-dd");

            this.btnHistorialTurnos.Text = dateSelected.Value.ToString("yyyy-MM-dd");

            var result = NTurnos.BuscarTurnos("FECHA", fecha_seleccionada, "");

            if (result == null)
            {
                Mensajes.MensajeInformacion("No se encontraron cajas abiertas en el día seleccionado");
                return;
            }

            DataTable dtTurnos = result.Result.dtTurnos;

            if (dtTurnos == null)
            {
                Mensajes.MensajeInformacion("No se encontraron cajas abiertas en el día seleccionado");
                return;
            }

            if (dtTurnos.Rows.Count < 1)
            {
                Mensajes.MensajeInformacion("No se encontraron cajas abiertas en el día seleccionado");
                return;
            }

            Turno turno = new Turno(dtTurnos.Rows[0]);

            if (turno == null)
            {
                Mensajes.MensajeInformacion("No se encontraron cajas abiertas en el día seleccionado");
                return;
            }

            this.Turno = turno;

            FechaTurnoChangedSuccess?.Invoke(dateSelected.Value, e);

            this.containerCalendario.Hide();
        }
        private void BtnSaveBase_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(this.txtCambiarBase.Text, out decimal base_nueva))
                {
                    Mensajes.MensajeInformacion("Verifique el valor de la base");
                    return;
                }

                if (base_nueva == 0)
                {
                    Mensajes.MensajeInformacion("La base no puede ser 0");
                    return;
                }

                string rpta = NTurnos.InsertarBase(this.Turno.Id_turno, base_nueva).Result;

                if (!rpta.Equals("OK"))
                {
                    Mensajes.MensajeInformacion("No se pudo actualizar la base, comuniquese con el administrador");
                    return;
                }

                this.txtCambiarBase.Text = "0";

                BaseChangedSuccess?.Invoke(this.Turno, e);

                Mensajes.MensajeOkForm("¡Base actualizada correctamente!");

                return;
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error actualizando al base {ex.Message}");
            }
        }
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Txt_LostFocus(object sender, EventArgs e)
        {
            if (this.txtCambiarBase.Text.Equals(""))
            {
                this.txtCambiarBase.Text = "0";
            }
        }
        private void Txt_GotFocus(object sender, EventArgs e)
        {
            this.txtCambiarBase.SelectAll();
        }
        private void AsignarDatos(Turno turno)
        {
            if (turno.Estado_turno.Equals("CERRADO"))
            {
                this.btnCerrarCaja.Text = "Abrir Caja";
                this.btnCerrarCaja.BackColor = Color.FromArgb(192, 255, 192);
                this.btnCerrarCaja.Click += BtnAbrirCaja_Click;

                this.gbGuardarBase.Visible = false;
                this.gbBase.Visible = false;
            }
            else
            {
                this.gbGuardarBase.Visible = true;
                this.gbBase.Visible = true;

                this.btnCerrarCaja.Click += BtnCerrarCaja_Click;
            }

            this.txtBase.Text = turno.Valor_inicial.ToString("C").Replace(",00", "").Replace(",00", "");
            this.txtBase.Tag = turno.Valor_inicial;

            this.txtTotalVentas.Text = turno.Total_ventas.ToString("C").Replace(",00", "").Replace(",00", "");
            this.txtTotalVentas.Tag = turno.Total_ventas;

            this.txtOtrosIngresos.Text = turno.Total_ingresos.ToString("C").Replace(",00", "").Replace(",00", "");
            this.txtOtrosIngresos.Tag = turno.Total_ingresos;

            this.txtEgresos.Text = turno.Total_egresos.ToString("C").Replace(",00", "").Replace(",00", "");
            this.txtEgresos.Tag = turno.Total_egresos;

            this.txtTotalTurno.Text = turno.Total_turno.ToString("C").Replace(",00", "").Replace(",00", "");
            this.txtTotalTurno.Tag = turno.Total_turno;

            StringBuilder infoPagos = new StringBuilder();

            DataTable dtPagos =
                NVentas.BuscarVenta("DETALLES PAGO", turno.Fecha_turno.ToString("yyyy-MM-dd"));
            if (dtPagos == null)
            {
                infoPagos.Append("No se encontraron detalles de pago");
                this.txtInfoPagos.Text = infoPagos.ToString();
                return;
            }

            foreach (DataRow row in dtPagos.Rows)
            {
                string metodo_pago = ConvertValueHelper.ConvertirCadena(row["Metodo_pago"]);
                int cantidad = ConvertValueHelper.ConvertirNumero(row["Cantidad"]);
                decimal total_pagos = ConvertValueHelper.ConvertirNumero(row["Total_pagos"]);
                string total_pago_view = total_pagos.ToString("C").Replace(",00", "").Replace(",00", "");

                infoPagos.Append($"{metodo_pago} | Cantidad {cantidad} | Total {total_pago_view}");
                infoPagos.Append(Environment.NewLine);
            }

            this.txtInfoPagos.Text = infoPagos.ToString();
            return;
        }
        private void BtnAbrirCaja_Click(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta($"Al abrir la caja podrá registrar ventas, gastos e ingresos. {Environment.NewLine} ¿Confirma la apertura?",
                "CONFIRMAR", "CANCELAR", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                Turno turnoNuevo = new Turno
                {
                    Fecha_turno = DateTime.Now,
                    Hora_turno = DateTime.Now.TimeOfDay,
                    Valor_inicial = 0,
                    Total_ingresos = 0,
                    Total_egresos = 0,
                    Total_ventas = 0,
                    Total_nomina = 0,
                    Total_turno = 0,
                    Estado_turno = "ABIERTO",
                };

                string rpta = NTurnos.InsertarTurno(turnoNuevo).Result;
                if (rpta.Equals("OK"))
                {
                    this.Turno = turnoNuevo;
                    this.BaseChangedSuccess?.Invoke(turnoNuevo, e);
                }
            }
        }
        private void BtnCerrarCaja_Click(object sender, EventArgs e)
        {
            Mensajes.MensajePregunta($"Si cierra la caja no podría hacer ventas. {Environment.NewLine} ¿Confirma el cierre?",
                "CONFIRMAR", "CANCELAR", out DialogResult dialog);
            if (dialog == DialogResult.Yes)
            {
                string rpta = NTurnos.EditarEstadoTurno(this.Turno.Id_turno, "CERRADO").Result;
                if (rpta.Equals("OK"))
                {
                    rpta = NTurnos.InsertarCierreTurno(new Turnos_cierres
                    {
                        Id_turno = this.Turno.Id_turno,
                        Fecha_cierre = DateTime.Now,
                        Hora_cierre = DateTime.Now.TimeOfDay,
                        Observaciones = string.Empty,
                    }).Result;

                    Mensajes.MensajeInformacion($"Se cerró la caja correctamente. {Environment.NewLine}" +
                        $"Revise la información enviada al correo electrónico del administrador de Chill Beer. {Environment.NewLine}" +
                        "Recuerde que no puede hacer ventas si no abre la caja manualmente");

                    this.BaseChangedSuccess?.Invoke(this.Turno, e);
                }
            }
        }

        private PoperContainer containerCalendario;
        public event EventHandler FechaTurnoChangedSuccess;
        public event EventHandler BaseChangedSuccess;

        private Turno _turno;
        public Turno Turno
        {
            get => _turno;
            set
            {
                _turno = value;
                this.AsignarDatos(value);
            }
        }
    }
}
