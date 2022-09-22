using CapaEntidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsPedido
{
    public partial class ProductoSuperSmall : UserControl
    {
        public ProductoSuperSmall()
        {
            InitializeComponent();
        }


        private void AsignarDatos(Detalle_pedido detalle)
        {
            StringBuilder info = new StringBuilder();

            info.Append($"{detalle.Producto.Nombre_producto} | Precio: {detalle.Precio:C} | Cantidad: {detalle.Cantidad}");

            if (detalle.Cantidad > 1)
            {
                info.Append($" | Total: {detalle.Precio_total:C}");
            }

            this.txtInfo.Text = info.ToString();
        }

        private Detalle_pedido _detalle;
        public Detalle_pedido Detalle
        {
            get => _detalle;
            set
            {
                _detalle = value;
                this.AsignarDatos(value);
            }
        }
    }
}
