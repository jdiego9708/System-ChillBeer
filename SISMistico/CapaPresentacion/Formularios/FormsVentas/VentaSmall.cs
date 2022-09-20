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
        private void BtnNext_Click(object sender, EventArgs e)
        {
            //FrmPerfilVenta perfilVenta = new()
            //{
            //    StartPosition = FormStartPosition.CenterScreen,
            //};
            //perfilVenta.ShowDialog();
            Mensajes.MensajeInformacion("¡Función en mantenimiento!");
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

        private Ventas venta;

        public Ventas Venta
        {
            get => venta;
            set
            {
                venta = value;
                this.AsignarDatos(value);
            }
        }
    }
}
