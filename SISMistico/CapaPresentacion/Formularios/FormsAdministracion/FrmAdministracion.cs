using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsEgresos;
using CapaPresentacion.Formularios.FormsIngresos;
using CapaPresentacion.Formularios.FormsTurnos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsAdministracion
{
    public partial class FrmAdministracion : Form
    {
        public FrmAdministracion()
        {
            InitializeComponent();
            this.Load += FrmAdministracion_Load;

            this.btnAddGasto.Click += BtnAddGasto_Click;
            this.btnAddIngreso.Click += BtnAddIngreso_Click;
        }

        private void BtnAddIngreso_Click(object sender, EventArgs e)
        {
            FrmNuevoIngreso frmNuevoIngreso = new FrmNuevoIngreso()
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmNuevoIngreso.OnIngresoSuccess += FrmNuevoIngreso_OnIngresoSuccess;
            frmNuevoIngreso.ShowDialog();
        }
        private void FrmNuevoIngreso_OnIngresoSuccess(object sender, EventArgs e)
        {
            if (this.FrmTurno == null) return;

            this.LoadTurno();
        }
        private void BtnAddGasto_Click(object sender, EventArgs e)
        {
            FrmNuevoEgreso frmNuevoEgreso = new FrmNuevoEgreso()
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmNuevoEgreso.OnEgresoSuccess += FrmNuevoEgreso_OnEgresoSuccess;
            frmNuevoEgreso.ShowDialog();
        }
        private void FrmNuevoEgreso_OnEgresoSuccess(object sender, EventArgs e)
        {
            if (this.FrmTurno == null) return;

            this.LoadTurno();
        }
        private void FrmAdministracion_Load(object sender, EventArgs e)
        {
            this.LoadTurno();
        }
        private void FrmTurno_FechaTurnoChangedSuccess(object sender, EventArgs e)
        {
            DateTime date = (DateTime)sender;
            this.gbTurno.Text = $"Mostrando caja del día | {date.ToLongDateString()}";
        }
        public void LoadTurno()
        {
            this.panelTurno.Controls.Clear();

            FrmTurno = new FrmTurno()
            {
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                TopMost = false,
                Dock = DockStyle.Fill,
            };
            FrmTurno.BaseChangedSuccess += FrmTurno_BaseChangedSuccess;
            FrmTurno.FechaTurnoChangedSuccess += FrmTurno_FechaTurnoChangedSuccess;
            this.panelTurno.Controls.Add(FrmTurno);
            FrmTurno.Show();

            //Obtener el turno actual
            var result = NTurnos.BuscarTurnos("ULTIMO TURNO", string.Empty, string.Empty);

            if (result == null) return;

            DataTable dtTurnos = result.Result.dtTurnos;

            if (dtTurnos == null) return;

            if (dtTurnos.Rows.Count < 1) return;

            Turno turno = new Turno(dtTurnos.Rows[0]);

            if (turno == null) return;

            var result1 = NTurnos.BuscarEstadistica(turno.Id_turno);

            if (result1 == null) return;

            DataTable dtTurno = result1.Result.dtEstadistica;

            turno = new Turno(dtTurno.Rows[0]);
         
            this.FrmTurno.Turno = turno;

            StringBuilder info = new StringBuilder();
            info.Append($"Mostrando caja del día | {turno.Fecha_turno.ToLongDateString()}");

            if (turno.Estado_turno.Equals("CERRADO"))
            {
                info.Append($" | CAJA CERRADA");
            }
            else
            {
                info.Append($" | CAJA ABIERTA");
            }

            this.gbTurno.Text = info.ToString();

            this.graphicsVentas1.CargarGraficoVentas5Dias();
            this.graphicsVentas2.CargarGraficoGastos5Dias();
        }
        private void FrmTurno_BaseChangedSuccess(object sender, EventArgs e)
        {
            if (this.FrmTurno == null) return;

            this.LoadTurno();
        }
        public FrmTurno FrmTurno { get; set; }

        private void graphicsVentas1_Load(object sender, EventArgs e)
        {

        }
    }
}
