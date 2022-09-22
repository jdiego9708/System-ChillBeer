using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsVentas
{
    public partial class VentaSmall : UserControl
    {
        public VentaSmall()
        {
            InitializeComponent();

            this.btnNext.Click += BtnNext_Click;
        }
        public event EventHandler OnBtnNextClick;
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (this.Venta != null)
                this.OnBtnNextClick?.Invoke(this.Venta, e);
            else
                this.OnBtnNextClick?.Invoke(this.Pedido, e);
        }
        private void AsignarDatos(Ventas venta)
        {
            try
            {
                //Obtener el detalle del pedido de la venta
                DataTable dtVentas = NVentas.BuscarVenta("ID VENTA DETALLE", venta.Id_pedido.ToString());

                if (dtVentas == null) return;

                List<Detalle_pedido> detalles = (from DataRow row in dtVentas.Rows
                                                 select new Detalle_pedido(row)).ToList();

                if (detalles == null) return;

                StringBuilder sb = new StringBuilder();
                sb.Append($"Hora: {DateTime.Now:hh:mm tt} | Total: ${venta.Total_final:N} | ");

                if (detalles.Count == 1)
                {
                    sb.Append($"{detalles[0].Producto.Nombre_producto.ToUpper()}");
                }
                else
                {
                    sb.Append($"{detalles.Count} productos");
                }
                this.txtInfo.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error en AsignarDatos de una venta | {ex.Message}");
            }
        }
        private void AsignarDatos(Pedidos pedido)
        {
            try
            {
                //Obtener el detalle del pedido de la venta
                DataTable dtVentas = NPedido.BuscarPedidos("ID PEDIDO DETALLE PRODUCTOS", pedido.Id_pedido.ToString());

                if (dtVentas == null) return;

                List<Detalle_pedido> detalles = (from DataRow row in dtVentas.Rows
                                                 select new Detalle_pedido(row)).ToList();

                if (detalles == null) return;

                decimal total = detalles.Sum(x => x.Precio_total);

                StringBuilder sb = new StringBuilder();
                sb.Append($"Hora: {pedido.Hora_pedido} | {pedido.Cliente.Nombre_cliente}");

                //if (pedido.Cliente.Telefono_cliente != null)
                //    sb.Append($" | Celular: {pedido.Cliente.Telefono_cliente}");

                sb.Append($"{Environment.NewLine}Total: {total:C}{Environment.NewLine}");

                if (detalles.Count == 1)
                {
                    sb.Append($"1 producto consumido");
                }
                else
                {
                    sb.Append($"{detalles.Count} productos");
                }
                this.txtInfo.Text = sb.ToString();

                this.txtInfo.BackColor = Color.FromArgb(255, 226, 226);
                this.BackColor = Color.FromArgb(255, 226, 226);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error en AsignarDatos de un pedido | {ex.Message}");
            }
        }

        private Ventas _venta;
        private Pedidos _pedido;

        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.AsignarDatos(value);
            }
        }
        public Pedidos Pedido
        {
            get => _pedido;
            set
            {
                _pedido = value;
                this.AsignarDatos(value);
            }
        }
    }
}
