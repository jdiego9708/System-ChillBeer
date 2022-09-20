using CapaEntidades.Models;
using CapaNegocio;
using CapaPresentacion.Formularios.FormsPedido;
using System;
using System.Linq;
using System.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmObservarClientes : Form
    {
        PoperContainer PoperContainer;

        public FrmObservarClientes()
        {
            InitializeComponent();

            this.Load += FrmObservarClientes_Load;
            this.btnAddCliente.Click += BtnAddCliente_Click;
            this.txtBusqueda.KeyPress += TxtBusqueda_KeyPress;
        }

        private void TxtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt.Text))
                    this.BuscarClientes("COMPLETO", "");
                else
                    this.BuscarClientes("BUSQUEDA COMPLETA", txt.Text);
            }
        }

        private void BtnAddCliente_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente frmAgregar = new FrmAgregarCliente()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
            };
            frmAgregar.OnClienteSuccess += FrmAgregar_OnClienteSuccess;
            frmAgregar.ShowDialog();
        }

        private void FrmAgregar_OnClienteSuccess(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
        }

        public bool venta = false;

        private void BuscarClientes(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelClientes.clearDataSource();

                DataTable dtClientes = NClientes.BuscarClientes(tipo_busqueda, texto_busqueda);

                if (dtClientes == null)
                {
                    this.panelClientes.BackgroundImage = Properties.Resources.No_hay_clientes;
                    return;
                }
                    
                if (dtClientes.Rows.Count < 1)
                {
                    this.panelClientes.BackgroundImage = Properties.Resources.No_hay_clientes;
                    return;
                }

                List<UserControl> controls = new List<UserControl>();
                foreach(DataRow row in dtClientes.Rows)
                {
                    Clientes cliente = new Clientes(row);

                    ClienteSmall clienteSmall = new ClienteSmall()
                    {
                        Cliente = cliente,
                    };
                    controls.Add(clienteSmall);
                }

                if (controls.Count < 1)
                {
                    this.panelClientes.BackgroundImage = Properties.Resources.No_hay_clientes;
                    return;
                }

                this.panelClientes.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarClientes",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }

        private void FrmObservarClientes_Load(object sender, EventArgs e)
        {
            this.BuscarClientes("COMPLETO", "");
        }
    }
}
