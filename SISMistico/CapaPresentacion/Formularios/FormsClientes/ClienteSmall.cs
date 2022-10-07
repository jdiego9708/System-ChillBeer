using CapaEntidades.Helpers;
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

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class ClienteSmall : UserControl
    {
        public ClienteSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.btnEditar.Click += BtnEditar_Click;
        }

        public event EventHandler OnBtnNext;

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frmAgregar = new FrmAgregarCliente()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                Cliente = this.Cliente,
            };
            frmAgregar.OnClienteSuccess += FrmAgregar_OnClienteSuccess;
            frmAgregar.ShowDialog();
        }

        private void FrmAgregar_OnClienteSuccess(object sender, EventArgs e)
        {
            Clientes cliente = (Clientes)sender;
            this.AsignarDatos(cliente);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNext?.Invoke(this.Cliente, e);
        }

        private void AsignarDatos(Clientes cliente)
        {
            this.txtNombre.Text = cliente.Nombre_cliente;
            this.txtCorreo.Text = cliente.Correo_electronico;
            this.txtCelular.Text = cliente.Telefono_cliente;

            StringBuilder info = new StringBuilder();
            DataTable dtClientes = NClientes.BuscarClientes("RESUMEN ID CLIENTE", cliente.Id_cliente.ToString());

            if (dtClientes == null)
            {
                info.Append("Aún no tiene ventas en Chill.");
                this.txtInformacion.Text = info.ToString();
                return;
            }        

            if (dtClientes.Rows.Count == 0)
            {
                info.Append("Aún no tiene ventas en Chill.");
                this.txtInformacion.Text = info.ToString();
                return;
            }
                
            if (dtClientes.Rows.Count == 1)
            {
                info.Append("Una venta registrada en Chill.");
             
                TimeSpan hora_ultima_venta = ConvertValueHelper.ConvertirHora(dtClientes.Rows[0]["Hora_venta"]);
                DateTime fecha_ultima_venta = ConvertValueHelper.ConvertirFecha(dtClientes.Rows[0]["Fecha_venta"]);
                DateTime fecha_ultima_venta_editada = fecha_ultima_venta.Add(hora_ultima_venta);

                info.Append($" | Última venta: {fecha_ultima_venta_editada.ToLongDateString()} - {fecha_ultima_venta_editada.ToLongTimeString()}");
                this.txtInformacion.Text = info.ToString();
                return;
            }
                
            if (dtClientes.Rows.Count > 1)
            {
                info.Append($"{dtClientes.Rows.Count} ventas registradas en Chill.");

                TimeSpan hora_ultima_venta = ConvertValueHelper.ConvertirHora(dtClientes.Rows[0]["Hora_venta"]);
                DateTime fecha_ultima_venta = ConvertValueHelper.ConvertirFecha(dtClientes.Rows[0]["Fecha_venta"]);
                DateTime fecha_ultima_venta_editada = fecha_ultima_venta.Add(hora_ultima_venta);

                info.Append($" | Última venta: {fecha_ultima_venta_editada.ToLongDateString()} - {fecha_ultima_venta_editada.ToLongTimeString()}");
                this.txtInformacion.Text = info.ToString();
                return;
            }       
        }

        private Clientes _cliente;

        public Clientes Cliente
        {
            get => _cliente;
            set
            {
                _cliente = value;
                this.AsignarDatos(value);
            }
        }
    }
}
