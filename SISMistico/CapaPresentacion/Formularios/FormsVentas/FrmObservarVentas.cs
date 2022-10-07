using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsClientes;
using CapaPresentacion.Formularios.FormsEmpleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVentas
{
    public partial class FrmObservarVentas : Form
    {
        PoperContainer containerFiltros;
        Filtrosventa filtrosventa;

        PoperContainer containerResumen;
        ResumenVenta resumenVenta;

        public FrmObservarVentas()
        {
            InitializeComponent();
            this.Load += FrmObservarVentas_Load;
        }

        private void FrmObservarVentas_Load(object sender, EventArgs e)
        {
            this.LoadVentas("FECHA", DateTime.Now.ToString("yyyy-MM-dd"));

            this.btnSelect.Text = DateTime.Now.ToLongDateString();
        }
        public void LoadVentas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelVentas.clearDataSource();

                DataTable dtVentas = NVentas.BuscarVenta(tipo_busqueda,
                    texto_busqueda, DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("HH:mm"),
                    DateTime.Now.ToString("HH:mm"));

                if (dtVentas == null)
                {
                    this.panelVentas.BackgroundImage = Properties.Resources.No_hay_ventas;
                    return;
                }

                this.panelVentas.BackgroundImage = null;

                List<UserControl> controls = new List<UserControl>();
                foreach (DataRow row in dtVentas.Rows)
                {
                    Ventas venta = new Ventas(row);
                    VentaSmall ventaSmall = new VentaSmall()
                    {
                        Venta = venta,
                    };
                    ventaSmall.OnBtnNextClick += VentaSmall_OnBtnNextClick;
                    controls.Add(ventaSmall);
                }
                this.panelVentas.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando las ventas | {ex.Message}");
            }
        }
        private void VentaSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            Ventas venta = (Ventas)sender;
            FrmPerfilVenta frmPerfilVenta = new FrmPerfilVenta
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                Venta = venta,
            };
            frmPerfilVenta.ShowDialog();
        }
    }
}
