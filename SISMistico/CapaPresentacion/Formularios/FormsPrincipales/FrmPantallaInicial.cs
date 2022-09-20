using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsPedido;
using CapaPresentacion.Formularios.FormsVentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public partial class FrmPantallaInicial : Form
    {
        public FrmPantallaInicial()
        {
            InitializeComponent();
            this.btnNuevaVenta.Click += BtnNuevaVenta_Click;
            this.btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnNuevaVenta_Click(object sender, EventArgs e)
        {
            FrmPedido frmPedido = new FrmPedido()
            {
                WindowState = FormWindowState.Maximized,
            };
            frmPedido.OnBtnPedidoSuccess += FrmPedido_OnBtnPedidoSuccess;
            frmPedido.ShowDialog();
        }
        private void FrmPedido_OnBtnPedidoSuccess(object sender, EventArgs e)
        {
            this.LoadVentas("FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
        }
        public void LoadVentas(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
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
                    controls.Add(ventaSmall);
                }
                this.panelVentas.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando las ventas | {ex.Message}");
            }
        }
    }
}
