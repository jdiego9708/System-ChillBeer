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
            this.btnHistorialVentas.Click += BtnHistorialVentas_Click;
            this.Load += FrmPantallaInicial_Load;
        }

        private void BtnHistorialVentas_Click(object sender, EventArgs e)
        {
            FrmObservarVentas frmObservarVentas = new FrmObservarVentas
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = true,
            };
            frmObservarVentas.Show();
        }
        private void FrmPantallaInicial_Load(object sender, EventArgs e)
        {
            this.LoadVentas("ULTIMAS VENTAS", string.Empty);

            this.LoadCuentas();
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnNuevaVenta_Click(object sender, EventArgs e)
        {
            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();
            if (datos.Turno.Estado_turno.Equals("CERRADO"))
            {
                Mensajes.MensajeInformacion("La caja está cerrada debe abrirla para realizar ventas");
                return;
            }
             
            FrmPedido frmPedido = new FrmPedido()
            {
                WindowState = FormWindowState.Maximized,
            };
            frmPedido.OnBtnPedidoSuccess += FrmPedido_OnBtnPedidoSuccess;
            frmPedido.ShowDialog();
        }
        private void FrmPedido_OnBtnPedidoSuccess(object sender, EventArgs e)
        {
            this.LoadVentas("ULTIMAS VENTAS", string.Empty);

            this.LoadCuentas();
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
        public void LoadCuentas()
        {
            try
            {
                this.panelCuentas.clearDataSource();

                DataTable dtPedidos = NVentas.BuscarVenta("TIPO PEDIDO",
                    "CUENTA ABIERTA", DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("yyyy-MM-dd"),
                    DateTime.Now.ToString("HH:mm"),
                    DateTime.Now.ToString("HH:mm"));

                if (dtPedidos == null)
                {
                    this.panelCuentas.BackgroundImage = Properties.Resources.No_hay_ventas;
                    return;
                }

                this.panelCuentas.BackgroundImage = null;

                List<UserControl> controls = new List<UserControl>();
                foreach (DataRow row in dtPedidos.Rows)
                {
                    Pedidos pedido = new Pedidos(row);
                    VentaSmall pedidoSmall = new VentaSmall()
                    {
                        Pedido = pedido,
                    };
                    pedidoSmall.OnBtnNextClick += PedidoSmall_OnBtnNextClick;
                    controls.Add(pedidoSmall);
                }
                this.panelCuentas.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando las cuentas abiertas | {ex.Message}");
            }
        }
        private void PedidoSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            //Si es venta va a mostrar el perfil de la venta
            if (sender is Ventas)
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
            else
            {
                Pedidos pe = (Pedidos)sender;

                DatosMesaSmall datosMesa = new DatosMesaSmall
                {
                    Pedido = pe,
                };
                datosMesa.OnBtnCancelarPedidoClick += DatosMesa_OnBtnCancelarPedidoClick;
                datosMesa.OnBtnEditarPedidoClick += DatosMesa_OnBtnEditarPedidoClick;
                datosMesa.OnBtnFacturarPedidoClick += DatosMesa_OnBtnFacturarPedidoClick;
                PoperContainer container = new PoperContainer(datosMesa);
                container.Show(Cursor.Position);
            }
        }
        private void DatosMesa_OnBtnEditarPedidoClick(object sender, EventArgs e)
        {
            Pedidos pedido = (Pedidos)sender;
            FrmPedido frmPedido = new FrmPedido()
            {
                WindowState = FormWindowState.Maximized,
                Pedido = pedido,
            };
            frmPedido.OnBtnPedidoSuccess += FrmPedido_OnBtnPedidoSuccess;
            frmPedido.ShowDialog();
        }
        private void DatosMesa_OnBtnCancelarPedidoClick(object sender, EventArgs e)
        {
            Pedidos pedido = (Pedidos)sender;
            string rpta = NPedido.CancelarPedido(pedido.Id_pedido, pedido.Observaciones_pedido);
            if (rpta.Equals("OK"))
                Mensajes.MensajeOkForm("Pedido cancelado con éxito!");
            else
                Mensajes.MensajeInformacion("No se pudo cancelar el pedido, comuniquese con el administrador");
        }
        private void DatosMesa_OnBtnFacturarPedidoClick(object sender, EventArgs e)
        {
            Pedidos pe = (Pedidos)sender;

            FrmFacturarPedido frmFacturarPedido = new FrmFacturarPedido()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                Pedido = pe,
            };
            frmFacturarPedido.OnFacturarPedidoSuccess += FrmFacturarPedido_OnFacturarPedidoSuccess;
            frmFacturarPedido.ShowDialog();
        }
        private void FrmFacturarPedido_OnFacturarPedidoSuccess(object sender, EventArgs e)
        {
            Pedidos pe = (Pedidos)sender;

            string rpta = NPedido.CambiarEstadoPedido(pe.Id_pedido, "TERMINADO");
            if (!rpta.Equals("OK"))
                Mensajes.MensajeInformacion("Hubo un error cambiando el pedido de estado, comuniquese con el administrador");

            this.LoadVentas("ULTIMAS VENTAS", DateTime.Now.ToString("yyyy-MM-dd"));

            this.LoadCuentas();
        }
    }
}
