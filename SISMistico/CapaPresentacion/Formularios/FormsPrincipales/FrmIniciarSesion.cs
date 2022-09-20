using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPrincipales
{
    public partial class FrmIniciarSesion : Form
    {
        public FrmIniciarSesion()
        {
            InitializeComponent();
            this.Load += FrmIniciarSesion_Load;
            this.btnIngresar.Click += BtnIngresar_Click;
            this.FormClosing += FrmIniciarSesion_FormClosing;
            this.txtPass.KeyPress += TxtPass_onKeyPress;
        }

        private void TxtPass_onKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                Login();
            }
        }

        private void FrmIniciarSesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        {
            try
            {
                var result = NEmpleados.Login(this.txtPass.Text, DateTime.Now.ToString("yyyy-MM-dd"));

                string rpta = result.Result.rpta;
                List<object> objects = result.Result.objects;

                if (rpta.Equals("OK"))
                {
                    Empleados empleado = (Empleados)objects[0];
                    Turno turno = (Turno)objects[1];

                    DatosInicioSesion datos = DatosInicioSesion.GetInstancia();
                    datos.Id_empleado = empleado.Id_empleado;
                    datos.Nombre_empleado = empleado.Nombre_empleado;
                    datos.Cargo_empleado = empleado.Cargo_empleado;
                    datos.EmpleadoLogin = empleado;
                    datos.Turno = turno;
                    datos.EmpleadoLogin = empleado;
                    datos.EmpleadoClaveMaestra = empleado;
                    datos.ClienteDefault = new Clientes
                    {
                        Id_cliente = 0,
                        Nombre_cliente = "NINGUNO",
                        Telefono_cliente = "NINGUNO",
                        Correo_electronico = string.Empty,
                        Direccion_cliente = "NINGUNO",
                        Referencia_ubicacion = string.Empty,
                        Otras_observaciones = string.Empty,
                        Estado_cliente = "ACTIVO",
                    };

                    FrmPrincipal frmPrincipal = new FrmPrincipal
                    {
                        WindowState = FormWindowState.Maximized
                    };
                    frmPrincipal.Show();

                    this.Hide();
                }
                else if (rpta.Equals(""))
                {
                    Mensajes.MensajeInformacion("No se encontró el usuario, intentelo de nuevo", "Entendido");
                }
                else
                {
                    throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BtnIngresar_Click",
                    "Hubo un error al ingresar", ex.Message);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmIniciarSesion_Load(object sender, EventArgs e)
        {
            string rpta;
            DataTable tablaEmpleados =
                NEmpleados.BuscarEmpleados("COMPLETO", "", out rpta);

            if (tablaEmpleados == null)
            {
                Mensajes.MensajePregunta("Hubo un error conectando con el servidor, desea intentar de nuevo?",
                "Intentar de nuevo", "Cerrar", out DialogResult dialog);
                if (dialog == DialogResult.Yes)
                {
                    string servicio = Convert.ToString(ConfigurationManager.AppSettings["nameServiceStarter"]);
                    ServiceController sc = new ServiceController(servicio);
                    try
                    {
                        if (sc != null && sc.Status == ServiceControllerStatus.Stopped)
                        {
                            sc.Start();
                        }
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        sc.Close();
                    }
                    catch (Exception ex)
                    {
                        Mensajes.MensajeErrorCompleto(this.Name, "Iniciar servicio",
                            "Error al iniciar el servicio: ", ex.Message);
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Insert)
            {
                try
                {
                    this.Login();
                }
                catch (Exception ex)
                {
                    Mensajes.MensajeErrorForm(ex.Message);
                }
            }
            else if (keyData == Keys.Escape)
            {
                this.Close();
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }
    }
}
