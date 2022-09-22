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

            this.lblCliente.Click += LblCliente_Click;
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

        private List<string> Variables(out DataTable detallePago)
        {
            detallePago = this.opcionesPedido.TablaPago(this.IsPrecuenta);

            List<string> vs = new List<string>
            {
                Convert.ToString(this.Id_pedido),
                Convert.ToString(this.Total_parcial),
                Convert.ToString(this.opcionesPedido.txtPropina.Tag),
                Convert.ToString(this.lblSubTotal.Tag),
                Convert.ToString(this.opcionesPedido.ListaDescuentos.SelectedValue),
                Convert.ToString(this.opcionesPedido.txtCupon.Text),
                Convert.ToString(this.opcionesPedido.txtPrecioDesechables.Tag),
                Convert.ToString(this.opcionesPedido.txtDomicilio.Tag),
                Convert.ToString(this.Total_final),
                Convert.ToString(this.opcionesPedido.txtObservaciones.Text),
            };
            return vs;
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
                    List<string> variables = this.Variables(out detalle_pago);

                    if (this.IsPrecuenta)
                    {
                        frmFacturaFinal.Is_precuenta = this.IsPrecuenta;
                        frmFacturaFinal.Id_pedido = this.Id_pedido;

                        frmFacturaFinal.AsignarReporte();
                        frmFacturaFinal.AsignarTablasPrecuenta(variables);

                        string metodo = this.ObtenerValorPanel(this.panelTipoPedido);
                        if (metodo.Equals("IMPRIMIR"))
                        {
                            frmFacturaFinal.ImprimirFactura(1);
                        }
                        else if (metodo.Equals("CORREO"))
                        {
                            string rpta_email =
                                EmailFactura.SendEmailFactura(this.Id_pedido, this.Correo_electronico);
                            if (!rpta_email.Equals("OK"))
                            {
                                Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                            }
                        }
                        else if (metodo.Equals("AMBAS"))
                        {
                            frmFacturaFinal.ImprimirFactura(1);
                            string rpta_email =
                                EmailFactura.SendEmailFactura(this.Id_pedido, this.Correo_electronico);
                            if (!rpta_email.Equals("OK"))
                            {
                                Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                            }
                        }

                        FrmObservarMesas frm = FrmObservarMesas.GetInstancia();
                        frm.MesaSaliendo(this.Id_mesa, this.Id_pedido);

                        MensajeEspera.CloseForm();
                        Mensajes.MensajeOkForm("Se realizó la precuenta correctamente");
                        this.OnFacturarPedidoSuccess?.Invoke(this.Id_pedido, e);
                        this.Close();
                    }
                    else
                    {
                        if (detalle_pago != null)
                        {
                            if (detalle_pago.Rows.Count > 0)
                            {
                                MensajeEspera.ShowWait("Facturando y terminando");

                                rpta =
                                    NVentas.InsertarVenta(variables, out id_venta, detalle_pago);
                                if (rpta.Equals("OK"))
                                {
                                    FrmObservarMesas frm = FrmObservarMesas.GetInstancia();
                                    frm.LiberarMesa(this.Id_mesa);
                                    MensajeEspera.CloseForm();
                                    frmFacturaFinal.Id_pedido = this.Id_pedido;
                                    frmFacturaFinal.AsignarReporte();
                                    frmFacturaFinal.AsignarTablasCuentaFinal();
                                    MensajeEspera.CloseForm();
                                    string metodo = this.ObtenerValorPanel(this.panelTipoPedido);
                                    if (metodo.Equals("IMPRIMIR"))
                                    {
                                        frmFacturaFinal.ImprimirFactura(1);
                                    }
                                    else if (metodo.Equals("CORREO"))
                                    {
                                        string rpta_email =
                                            EmailFactura.SendEmailFactura(this.Id_pedido, this.Correo_electronico);
                                        if (!rpta_email.Equals("OK"))
                                        {
                                            MensajeEspera.CloseForm();
                                            Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                                        }
                                    }
                                    else if (metodo.Equals("AMBAS"))
                                    {
                                        frmFacturaFinal.ImprimirFactura(1);
                                        string rpta_email =
                                            EmailFactura.SendEmailFactura(this.Id_pedido, this.Correo_electronico);
                                        if (!rpta_email.Equals("OK"))
                                        {
                                            MensajeEspera.CloseForm();
                                            Mensajes.MensajeErrorForm("Hubo un error al enviar el correo electrónico");
                                        }
                                    }

                                    MensajeEspera.CloseForm();
                                    Mensajes.MensajeOkForm("Se realizó la facturación correctamente");
                                    this.OnFacturarPedidoSuccess?.Invoke(this.Id_pedido, e);
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

        private void LblCliente_Click(object sender, EventArgs e)
        {
            //this.datosUsuario.Id_cliente = this.Id_cliente;
            this.poperContainer2.Show(this.lblCliente);
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
            this.rdImprimir.Checked = true;
            this.chkRecordarOpcion.Checked = true;
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
        private int id_pedido;
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
        public int Id_pedido { get => id_pedido; set => id_pedido = value; }
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
                this.lblFecha.Text = $"{pedido.Fecha_pedido.ToLongDateString()} | {pedido.Hora_pedido}" ;
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
            this.Id_pedido = id_pedido;
            try
            {
                this.Nombre_cliente = pedido.Cliente.Nombre_cliente;
                this.Correo_electronico = pedido.Cliente.Correo_electronico;

                this.toolTip1.SetToolTip(this.lblCliente, "Correo electrónico registrado: " + pedido.Cliente.Correo_electronico);

                this.gbInfo.Text = $"Pedido número {pedido.Id_pedido}";
                this.lblFecha.Text = $"{pedido.Fecha_pedido.ToLongDateString()} | {pedido.Hora_pedido}";
                this.lblCliente.Text = pedido.Cliente.Nombre_cliente;
                this.lblMesero.Text = pedido.Empleado.Nombre_empleado;

                DataTable dtDetalles = NPedido.BuscarPedidos("ID PEDIDO DETALLE PRODUCTOS", id_pedido.ToString());

                if (dtDetalles == null)
                    throw new Exception($"Error buscando los detalles del pedido {id_pedido}");

                if (dtDetalles.Rows.Count < 1)
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
