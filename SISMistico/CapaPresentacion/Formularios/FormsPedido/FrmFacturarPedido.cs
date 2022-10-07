using CapaEntidades.Helpers;
using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsEmpleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaPresentacion.Formularios.FormsPedido
{
    public partial class FrmFacturarPedido : Form
    {
        DescuentosOpcionesPedido opcionesPedido;
        PoperContainer poperContainer1;
        PoperContainer poperContainer2;
        public FrmFacturarPedido()
        {
            InitializeComponent();
            this.opcionesPedido = new DescuentosOpcionesPedido();
            this.poperContainer1 = new PoperContainer(opcionesPedido);

            this.Load += FrmFacturarPedido_Load;
            this.btnTerminar.Click += BtnTerminar_Click;
            this.lblMesero.Click += LblMesero_Click;
        }

        private FrmFacturaFinal frmFacturaFinal = new FrmFacturaFinal();

        private void DatosUsuario_onChangedEmail(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            this.toolTip1.SetToolTip(this.lblCliente, txt.Text);
            this.Correo_electronico = txt.Text;
        }

        private void LblMesero_Click(object sender, EventArgs e)
        {
            this.Comprobacion();
            if (this.Cargo_empleado != null)
            {
                if (this.Cargo_empleado.Equals("ADMINISTRADOR"))
                {
                    FrmObservarEmpleados frmObservarEmpleados = new FrmObservarEmpleados();
                    frmObservarEmpleados.StartPosition = FormStartPosition.CenterScreen;
                    frmObservarEmpleados.facturar_pedido = true;
                    frmObservarEmpleados.FormClosed += FrmObservarEmpleados_FormClosed;
                    frmObservarEmpleados.ShowDialog();
                }
                else
                {
                    Mensajes.MensajeInformacion("No tiene permisos para realizar esta acción", "Entendido");
                }
            }
        }

        private void FrmObservarEmpleados_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            if (frm.Tag != null)
            {
                List<string> datosEmpleado = (List<string>)frm.Tag;
                this.lblMesero.Text = datosEmpleado[1];
                this.lblMesero.Tag = datosEmpleado[0];
                this.Correo_electronico = datosEmpleado[3];
            }
        }

        private string ObtenerValorPanel(Panel panel)
        {
            string rpta = "";
            foreach (Control control in panel.Controls)
            {
                if (control is RadioButton rd)
                {
                    if (rd.Checked)
                    {
                        rpta = rd.Tag.ToString().ToUpper();
                        break;
                    }
                }
            }
            return rpta;
        }

        private bool Comprobaciones(out Ventas venta, out DataTable detallePago)
        {
            detallePago = this.opcionesPedido.TablaPago(this.IsPrecuenta);
            venta = null;
            try
            {
                if (!decimal.TryParse(Convert.ToString(this.opcionesPedido.txtPropina.Tag), out decimal propina))
                {
                    Mensajes.MensajeInformacion("Verifique la propina");
                    return false;
                }

                if (!decimal.TryParse(Convert.ToString(this.lblSubTotal.Tag), out decimal subtotal))
                {
                    Mensajes.MensajeInformacion("Verifique el subtotal");
                    return false;
                }

                if (!decimal.TryParse(Convert.ToString(this.opcionesPedido.ListaDescuentos.SelectedValue), out decimal descuento))
                {
                    Mensajes.MensajeInformacion("Verifique el descuento");
                    return false;
                }

                if (!decimal.TryParse(Convert.ToString(this.opcionesPedido.txtPrecioDesechables.Tag), out decimal desechables))
                {
                    Mensajes.MensajeInformacion("Verifique el precio de desechables");
                    return false;
                }

                if (!decimal.TryParse(Convert.ToString(this.opcionesPedido.txtDomicilio.Tag), out decimal domicilio))
                {
                    Mensajes.MensajeInformacion("Verifique el precio de domicilio");
                    return false;
                }

                if (this.rdCorreo.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtCorreo.Text))
                    {
                        Mensajes.MensajeInformacion("Verifique el correo electrónico para enviar el comprobante");
                        return false;
                    }

                    if (!MailHelper.Email_comprobation(this.txtCorreo.Text))
                    {
                        Mensajes.MensajeInformacion("Verifique el correo electrónico para enviar el comprobante, direccion no valida");
                        return false;
                    }
                }

                DatosInicioSesion datos = DatosInicioSesion.GetInstancia();

                venta = new Ventas
                {
                    Id_turno = datos.Turno.Id_turno,
                    Id_pedido = this.Pedido.Id_pedido,
                    Total_parcial = this.Total_parcial,
                    Propina = propina,
                    Subtotal = subtotal,
                    Descuento = descuento,
                    Bono_cupon = this.opcionesPedido.txtCupon.Text,
                    Desechables = desechables,
                    Domicilio = domicilio,
                    Total_final = this.Total_final,
                    Observaciones = this.opcionesPedido.txtObservaciones.Text,
                    Fecha_venta = DateTime.Now,
                    Hora_venta = DateTime.Now.TimeOfDay,
                    Estado = "TERMINADO",
                    Pedido = this.Pedido,
                };
            }
            catch (Exception)
            {
                venta = null;
            }
           
            return true;
        }

        public event EventHandler OnFacturarPedidoSuccess;

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "OK";
                int id_venta;
                if (this.panelSubTotal.Visible)
                {
                    DataTable detalle_pago;
                    bool result = this.Comprobaciones(out Ventas venta, out detalle_pago);
                    if (!result)
                        return;

                    if (detalle_pago != null)
                    {
                        if (detalle_pago.Rows.Count > 0)
                        {
                            MensajeEspera.ShowWait("Facturando y terminando");

                            rpta =
                                NVentas.InsertarVenta(venta, detalle_pago);
                            if (rpta.Equals("OK"))
                            {
                                string metodo = this.ObtenerValorPanel(this.panelTipoPedido);
                                if (metodo.Equals("IMPRIMIR"))
                                {
                                    frmFacturaFinal.Id_pedido = this.Id_pedido;
                                    frmFacturaFinal.AsignarReporte();
                                    frmFacturaFinal.AsignarTablasCuentaFinal();
                                    frmFacturaFinal.ImprimirFactura(1);
                                }
                                else if (metodo.Equals("CORREO"))
                                {
                                    MailHelper mail = new MailHelper();
                                    string rpta_email =
                                        mail.SendEmailFactura(this.Correo_electronico, venta, this.DetallesPedido, detalle_pago);
                                    if (!rpta_email.Equals("OK"))
                                    {
                                        MensajeEspera.CloseForm();
                                        Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                                    }
                                }
                                else if (metodo.Equals("AMBAS"))
                                {
                                    frmFacturaFinal.Id_pedido = this.Id_pedido;
                                    frmFacturaFinal.AsignarReporte();
                                    frmFacturaFinal.AsignarTablasCuentaFinal();
                                    frmFacturaFinal.ImprimirFactura(1);
                                    string rpta_email =
                                        EmailFactura.SendEmailFactura(this.Id_pedido, this.txtCorreo.Text);
                                    if (!rpta_email.Equals("OK"))
                                    {
                                        MensajeEspera.CloseForm();
                                        Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                                    }
                                }

                                MensajeEspera.CloseForm();
                                Mensajes.MensajeOkForm("Se realizó la facturación correctamente");
                                this.OnFacturarPedidoSuccess?.Invoke(this.Pedido, e);
                                this.Close();
                            }
                            else
                            {
                                throw new Exception(rpta);
                            }

                            MensajeEspera.CloseForm();
                        }
                        else
                        {
                            MensajeEspera.CloseForm();
                            Mensajes.MensajeErrorForm("Debe de seleccionar un método de pago");
                        }
                    }
                    else
                    {
                        MensajeEspera.CloseForm();
                        Mensajes.MensajeErrorForm("Debe de seleccionar un método de pago");
                    }

                }
                MensajeEspera.CloseForm();
            }
            catch (Exception ex)
            {
                MensajeEspera.CloseForm();
                Mensajes.MensajeErrorCompleto(this.Name, "BtnTerminar_Click",
                    "Hubo un error al terminar una venta", ex.Message);
            }
        }

        public void ObtenerTotales(decimal total_parcial, int sub_total, int total)
        {
            this.Total_parcial = total_parcial;
            this.lblTotalParcial.Text = string.Format("{0:C}", this.Total_parcial);
            this.lblTotalParcial.Tag = total_parcial;

            this.panelSubTotal.Visible = true;
            this.lblSubTotal.Text = string.Format("{0:C}", sub_total);
            this.lblSubTotal.Tag = sub_total;

            this.Total_final = total;
            this.lblTotal.Text = string.Format("{0:C}", this.Total_final);
            this.lblTotal.Tag = Total_final;
        }

        private void FrmFacturarPedido_Load(object sender, EventArgs e)
        {
            this.panelSubTotal.Visible = false;
            this.frmFacturaFinal.Is_precuenta = this.IsPrecuenta;
            this.frmFacturaFinal.AsignarReporte();

            this.btnTerminar.Enabled = true;
            this.opcionesPedido.IsDomicilio = this.IsDomicilio;
            this.opcionesPedido.Total_parcial = this.Total_parcial;
            this.opcionesPedido.frmFacturarPedido = this;
            this.panelDescuentos.Controls.Add(this.opcionesPedido);
            this.Show();
        }

        private void Comprobacion()
        {
            FrmComprobacion frm = new FrmComprobacion();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.Cargo_empleado = frm.Cargo_empleado;
            }
        }

        #region VARIABLES
        private int _id_pedido;
        private DateTime fecha_pedido;
        private int id_cliente;
        private string nombre_cliente;
        private string correo_electronico;
        private int id_empleado;
        private string nombre_empleado;
        private DataTable tablaVista;
        private DataTable tablaDetalle;
        private decimal total_parcial;
        private decimal total_final;
        private int cantidad_pedidos;
        private int id_mesa;
        private string mesa;
        private string _cargo_empleado;
        private bool isPrecuenta;
        public int Id_pedido { get => _id_pedido; set => _id_pedido = value; }
        public DateTime Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }
        public int Id_cliente { get => id_cliente; set => id_cliente = value; }
        public string Nombre_cliente { get => nombre_cliente; set => nombre_cliente = value; }
        public string Correo_electronico { get => correo_electronico; set => correo_electronico = value; }
        public int Id_empleado { get => id_empleado; set => id_empleado = value; }
        public string Nombre_empleado { get => nombre_empleado; set => nombre_empleado = value; }
        public DataTable TablaVista { get => tablaVista; set => tablaVista = value; }
        public DataTable TablaDetalle { get => tablaDetalle; set => tablaDetalle = value; }
        public decimal Total_parcial { get => total_parcial; set => total_parcial = value; }
        public decimal Total_final
        {
            get => total_final;
            set
            {
                total_final = value;
            }
        }
        public int Cantidad_pedidos { get => cantidad_pedidos; set => cantidad_pedidos = value; }
        public int Id_mesa { get => id_mesa; set => id_mesa = value; }
        public string Mesa { get => mesa; set => mesa = value; }
        public string Cargo_empleado { get => _cargo_empleado; set => _cargo_empleado = value; }
        public bool IsPrecuenta { get => isPrecuenta; set => isPrecuenta = value; }


        #endregion

        public void ObtenerPedido(int id_pedido)
        {
            this.Id_pedido = id_pedido;
            try
            {
                DataTable dtPedido = NPedido.BuscarPedidos("ID PEDIDO", id_pedido.ToString());

                if (dtPedido == null)
                    throw new Exception($"Error buscando el pedido {id_pedido}");

                if (dtPedido.Rows.Count < 1)
                    throw new Exception($"Error buscando el pedido {id_pedido}");

                Pedidos pedido = new Pedidos(dtPedido.Rows[0]);

                this.Nombre_cliente = pedido.Cliente.Nombre_cliente;
                this.Correo_electronico = pedido.Cliente.Correo_electronico;

                this.toolTip1.SetToolTip(this.lblCliente, "Correo electrónico registrado: " + pedido.Cliente.Correo_electronico);

                this.gbInfo.Text = pedido.Id_pedido.ToString();
                this.lblFecha.Text = $"{pedido.Fecha_pedido.ToLongDateString()} | {pedido.Hora_pedido}";
                this.lblCliente.Text = pedido.Cliente.Nombre_cliente;
                this.lblMesero.Text = pedido.Empleado.Nombre_empleado;

                DataTable dtDetalles = NPedido.BuscarPedidos("ID PEDIDO DETALLE PRODUCTOS", id_pedido.ToString());

                if (dtPedido == null)
                    throw new Exception($"Error buscando los detalles del pedido {id_pedido}");

                if (dtPedido.Rows.Count < 1)
                    throw new Exception($"Error buscando los detalles del pedido {id_pedido}");

                List<Detalle_pedido> detalles = (from DataRow row in dtDetalles.Rows
                                                 select new Detalle_pedido(row)).ToList();

                this.DetallesPedido = detalles;

                List<UserControl> controls = new List<UserControl>();

                foreach (Detalle_pedido detalle in detalles)
                {
                    ProductoSuperSmall producto = new ProductoSuperSmall()
                    {
                        Detalle = detalle,
                    };
                    controls.Add(producto);
                }
                this.panelProductos.AddArrayControl(controls);

                this.SumarPrecios();
            }
            catch (Exception)
            {

            }
        }
        public void AsignarDatos(Pedidos pedido)
        {
            this.Id_pedido = pedido.Id_pedido;
            try
            {
                this.Nombre_cliente = pedido.Cliente.Nombre_cliente;
                this.Correo_electronico = pedido.Cliente.Correo_electronico;

                this.toolTip1.SetToolTip(this.lblCliente, "Correo electrónico registrado: " + pedido.Cliente.Correo_electronico);

                this.gbInfo.Text = $"Pedido número {pedido.Id_pedido}";
                this.lblFecha.Text = $"{pedido.Fecha_pedido.ToLongDateString()} | {pedido.Hora_pedido}";
                this.lblCliente.Text = pedido.Cliente.Nombre_cliente;
                this.txtCorreo.Text = pedido.Cliente.Correo_electronico;
                this.lblMesero.Text = pedido.Empleado.Nombre_empleado;

                DataTable dtDetalles = NPedido.BuscarPedidos("ID PEDIDO DETALLE PRODUCTOS", pedido.Id_pedido.ToString());

                if (dtDetalles == null)
                    throw new Exception($"Error buscando los detalles del pedido {pedido.Id_pedido}");

                if (dtDetalles.Rows.Count < 1)
                    throw new Exception($"Error buscando los detalles del pedido {pedido.Id_pedido}");

                List<Detalle_pedido> detalles = (from DataRow row in dtDetalles.Rows
                                                 select new Detalle_pedido(row)).ToList();

                this.DetallesPedido = detalles;

                List<UserControl> controls = new List<UserControl>();

                foreach (Detalle_pedido detalle in detalles)
                {
                    ProductoSuperSmall producto = new ProductoSuperSmall()
                    {
                        Detalle = detalle,
                    };
                    controls.Add(producto);
                }
                this.panelProductos.AddArrayControl(controls);

                this.SumarPrecios();
            }
            catch (Exception)
            {

            }
        }
        private void SumarPrecios()
        {
            decimal total_parcial = 0;

            if (this.DetallesPedido != null)
                total_parcial = this.DetallesPedido.Sum(x => x.Precio_total);

            this.Total_parcial = total_parcial;
            this.lblTotalParcial.Text = string.Format("{0:C}", this.Total_parcial);
            this.lblTotalParcial.Tag = total_parcial;

            this.Total_final = total_parcial;
            this.lblTotal.Text = string.Format("{0:C}", this.Total_parcial);
            this.lblTotal.Tag = total_parcial;
        }
        public List<Detalle_pedido> DetallesPedido { get; set; }

        private Pedidos _pedido;
        private bool _isDomicilio;
        public bool IsDomicilio
        {
            get => _isDomicilio;
            set
            {
                _isDomicilio = value;
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
