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
    public partial class FrmPerfilVenta : Form
    {
        public FrmPerfilVenta()
        {
            InitializeComponent();

            this.btnPrint.Click += BtnPrint_Click;
            this.btnSendEmail.Click += BtnSendEmail_Click;
            this.btnArchivarVenta.Click += BtnArchivarVenta_Click;
        }

        private void BtnArchivarVenta_Click(object sender, EventArgs e)
        {
            Mensajes.MensajeInformacion("¡Función en mantenimiento!");
        }

        private void BtnSendEmail_Click(object sender, EventArgs e)
        {
            Mensajes.MensajeInformacion("¡Función en mantenimiento!");
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            Mensajes.MensajeInformacion("¡Función en mantenimiento!");
        }

        private void AsignarDatos(Ventas venta)
        {
            try
            {
                #region ASIGNAR DATOS DE VENTA
                DateTime fechaVenta = venta.Fecha_venta;
                DateTime horaVenta = fechaVenta.Add(venta.Hora_venta);
                StringBuilder infoVenta = new StringBuilder();

                this.Text = $"Venta número {venta.Id_venta}";

                if (venta.Estado.Equals("CANCELADO"))
                {
                    if (venta.Pedido.Fecha_pedido.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                        infoVenta.Append($"HOY | Hora: {horaVenta:hh:mm tt} | {venta.Pedido.Cliente.Nombre_cliente} | CANCELADO ");
                    else if (venta.Pedido.Fecha_pedido.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))
                        infoVenta.Append($"AYER | Hora: {horaVenta:hh:mm tt} | {venta.Pedido.Cliente.Nombre_cliente} | CANCELADO ");
                    else if (venta.Pedido.Fecha_pedido.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"))
                        infoVenta.Append($"HACE DOS DIAS | Hora: {horaVenta:hh:mm tt} | CANCELADO | ");
                    else
                        infoVenta.Append($"{venta.Fecha_venta.ToLongDateString()} | Hora: {horaVenta:hh:mm tt} | {venta.Pedido.Cliente.Nombre_cliente} | CANCELADO ");

                    this.txtInfoVenta.Text = infoVenta.ToString();

                    this.txtInfoVenta.BackColor = Color.FromArgb(255, 226, 226);
                    this.BackColor = Color.FromArgb(255, 226, 226);
                }
                else
                {
                    if (fechaVenta.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd"))
                        infoVenta.Append($"HOY | Hora: {horaVenta:hh:mm tt} ");
                    else if (fechaVenta.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))
                        infoVenta.Append($"AYER | Hora: {horaVenta:hh:mm tt} ");
                    else if (fechaVenta.ToString("yyyy-MM-dd") == DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"))
                        infoVenta.Append($"HACE DOS DIAS | Hora: {horaVenta:hh:mm tt} ");
                    else
                        infoVenta.Append($"{fechaVenta.ToLongDateString()} | Hora: {horaVenta:hh:mm tt} ");

                    infoVenta.Append(Environment.NewLine);

                    infoVenta.Append($"Total en productos: {venta.Total_parcial:C} ");

                    infoVenta.Append(Environment.NewLine);

                    if (venta.Descuento == 0)
                        infoVenta.Append("No se aplicaron descuentos");
                    else
                        infoVenta.Append($"Descuento por valor de {venta.Descuento:C}");

                    infoVenta.Append(Environment.NewLine);

                    if (venta.Desechables == 0)
                        infoVenta.Append("No desechables");
                    else
                        infoVenta.Append($"Desechables por valor de {venta.Desechables:C}");

                    infoVenta.Append(Environment.NewLine);

                    if (venta.Domicilio == 0)
                        infoVenta.Append("No domicilio");
                    else
                        infoVenta.Append($"Domicilio por valor de {venta.Domicilio:C}");

                    infoVenta.Append(Environment.NewLine);

                    infoVenta.Append($"Total venta: {venta.Total_final:C} ");

                    this.txtInfoVenta.Text = infoVenta.ToString();
                }

                #endregion

                #region ASIGNAR DATOS DE PRODUCTOS
                StringBuilder infoDetalles = new StringBuilder();

                //Obtener el detalle del pedido de la venta
                DataTable dtVentas = NVentas.BuscarVenta("ID VENTA DETALLE", venta.Id_pedido.ToString());

                if (dtVentas == null) return;

                List<Detalle_pedido> detalles = (from DataRow row in dtVentas.Rows
                                                 select new Detalle_pedido(row)).ToList();

                if (detalles == null)
                {
                    infoDetalles.Append($"No se encontró los detalles de la venta");
                    return;
                }

                int total_productos = detalles.Sum(x => x.Cantidad);

                infoDetalles.Append($"CANTIDAD DE PRODUCTOS {total_productos}").Append(Environment.NewLine);

                foreach (Detalle_pedido detalle in detalles)
                {
                    infoDetalles.Append($"* {detalle.Producto.Nombre_producto} | Precio {detalle.Precio:C} | Cantidad {detalle.Cantidad}");
                    infoDetalles.Append(Environment.NewLine);
                }

                this.txtInfoProductos.Text = infoDetalles.ToString();
                #endregion

                #region ASIGNAR DATOS DE CLIENTE
                StringBuilder infoCliente = new StringBuilder();

                infoCliente.Append($"{venta.Pedido.Cliente.Nombre_cliente}");
                infoCliente.Append(Environment.NewLine);

                if (!string.IsNullOrEmpty(venta.Pedido.Cliente.Telefono_cliente))
                    infoCliente.Append($"Celular: {venta.Pedido.Cliente.Telefono_cliente} ");

                infoCliente.Append(Environment.NewLine);

                if (!string.IsNullOrEmpty(venta.Pedido.Cliente.Correo_electronico))
                    infoCliente.Append($"Correo: {venta.Pedido.Cliente.Correo_electronico} ");

                infoCliente.Append(Environment.NewLine);

                this.txtInfoCliente.Text = infoCliente.ToString();
                #endregion

                #region ASIGNAR DATOS DE PAGO
                StringBuilder infoPago = new StringBuilder();

                DataTable dtPagoVenta = NVentas.BuscarVenta("ID VENTA DETALLE PAGO", venta.Id_venta.ToString());

                if (dtPagoVenta == null) return;

                List<Detalle_venta> detallePagoVenta = (from DataRow row in dtPagoVenta.Rows
                                                        select new Detalle_venta(row)).ToList();

                if (detallePagoVenta == null)
                {
                    infoPago.Append("No se encontraró los métodos de pago de la venta");
                    return;
                }

                infoPago.Append("Métodos de pago usados: ").Append(Environment.NewLine);

                foreach (Detalle_venta detalleVenta in detallePagoVenta)
                {
                    infoPago.Append($"* {detalleVenta.Metodo_pago} | Valor {detalleVenta.Valor_pago:C}").Append(Environment.NewLine);
                }

                this.txtInfoPago.Text = infoPago.ToString();
                #endregion
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error en AsignarDatos de una venta | {ex.Message}");
            }
        }

        private Ventas _venta;

        public Ventas Venta
        {
            get => _venta;
            set
            {
                _venta = value;
                this.AsignarDatos(value);
            }
        }
    }
}
