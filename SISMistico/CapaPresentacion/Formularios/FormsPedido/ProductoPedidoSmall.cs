using CapaEntidades.BindingModels;
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
    public partial class ProductoPedidoSmall : UserControl
    {
        public ProductoPedidoSmall()
        {
            InitializeComponent();
            this._producto = new ProductoPedidoBindingModel();

            this.btnAdd.Click += BtnAdd_Click;
            this.btnComment.Click += BtnComment_Click;
            this.btnRemove.Click += BtnRemove_Click;
        }

        public event EventHandler OnAddButtonClick;
        public event EventHandler OnCommentButtonClick;
        public event EventHandler OnRemoveButtonClick;

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this.OnRemoveButtonClick?.Invoke(this.Producto, e);
        }
        private void BtnComment_Click(object sender, EventArgs e)
        {
            this.OnCommentButtonClick?.Invoke(this.Producto, e);
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.OnAddButtonClick?.Invoke(this.Producto, e);
        }

        private ProductoPedidoBindingModel _producto;
        public ProductoPedidoBindingModel Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }

        private void AsignarDatos(ProductoPedidoBindingModel producto)
        {
            StringBuilder info = new StringBuilder();
            if (producto.DetallePedido == null)
            {
                info.Append("Producto no especificado");
            }
            else
            {
                info.Append(producto.Producto.Nombre_producto).Append(Environment.NewLine);
                info.Append($"${producto.DetallePedido.Precio:N}").Append(" | ");
                info.Append(producto.DetallePedido.Cantidad).Append(Environment.NewLine); ;
                info.Append($"${producto.DetallePedido.Precio_total:N}");
            }
            this.txtInfo.Text = info.ToString();
        }
    }
}
