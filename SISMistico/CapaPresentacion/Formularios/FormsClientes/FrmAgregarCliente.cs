using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.Models;
using CapaNegocio;

namespace CapaPresentacion.Formularios.FormsClientes
{
    public partial class FrmAgregarCliente : Form
    {
        public FrmAgregarCliente()
        {
            InitializeComponent();
            this.btnCancelar.Click += BtnCancelar_Click;
            this.btnGuardar.Click += BtnGuardar_Click;
            this.Load += FrmAgregarCliente_Load;
        }
        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {

        }
        public bool DireccionEmailValida(string direccion, out string errorMessage)
        {
            if (direccion.Length == 0)
            {
                errorMessage = "La dirección de correo es necesaria";
                return false;
            }

            if (direccion.IndexOf("@") > -1)
            {
                if (direccion.IndexOf(".", direccion.IndexOf("@")) > direccion.IndexOf("@"))
                {
                    errorMessage = "OK";
                    return true;
                }
            }

            errorMessage = "La dirección de correo no tiene un formato válido \n" +
               "Por ejemplo 'nombre@gmail.com' ";
            return false;
        }
        private bool Comprobaciones(out Clientes cliente)
        {
            if (this.Cliente == null)
                cliente = new Clientes();
            else
                cliente = this.Cliente;

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                Mensajes.MensajeInformacion("El nombre no puede estar vacío");
                return false;
            }

            if (!string.IsNullOrEmpty(this.txtCorreo.Text))
            {
                if (!this.DireccionEmailValida(this.txtCorreo.Text, out string errorMessage))
                {
                    Mensajes.MensajeInformacion("El correo electrónico no es válido");
                    return false;
                }
            }

            cliente.Nombre_cliente = this.txtNombre.Text;
            cliente.Correo_electronico = this.txtCorreo.Text;
            cliente.Telefono_cliente = this.txtTelefono.Text;
            cliente.Referencia_ubicacion = string.Empty;
            cliente.Direccion_cliente = string.Empty;
            cliente.Otras_observaciones = string.Empty;
            cliente.Estado_cliente = "ACTIVO";

            return true;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string rpta = "";
            string mensaje = "";
            try
            {
                if (this.Comprobaciones(out Clientes cliente))
                {
                    if (this.IsEditar)
                    {
                        rpta = NClientes.EditarCliente(cliente);
                        mensaje = "actualizó";

                        if (this.IsPedido)
                        {
                            if (this.OnChangedEmail != null)
                                this.OnChangedEmail(this.txtCorreo, e);
                        }
                    }
                    else
                    {
                        rpta = NClientes.InsertarCliente(cliente);
                        mensaje = "agregó";
                    }

                    if (rpta.Equals("OK"))
                    {
                        this.OnClienteSuccess?.Invoke(cliente, e);
                        Mensajes.MensajeOkForm("Se " + mensaje + " el cliente correctamente");
                        this.Close();
                    }
                    else
                    {
                        throw new Exception(rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnGuardar_Click",
                    "Hubo un error al " + mensaje + " un cliente", ex.Message);
            }
        }
        private void AsignarDatos(Clientes cliente)
        {
            this.txtNombre.Text = cliente.Nombre_cliente;
            this.txtCorreo.Text = cliente.Correo_electronico;
            this.txtTelefono.Text = cliente.Telefono_cliente;
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public event EventHandler OnChangedEmail;
        public event EventHandler OnClienteSuccess;

        private Clientes _cliente;
        private string estado;
        private bool _isPedido;
        public bool IsPedido { get => _isPedido; set => _isPedido = value; }
        public Clientes Cliente
        {
            get => _cliente;
            set
            {
                this.IsEditar = true;
                _cliente = value;
                this.AsignarDatos(value);
            }
        }

        public bool IsEditar { get => _isEditar; set => _isEditar = value; }

        private bool _isEditar;
    }
}
