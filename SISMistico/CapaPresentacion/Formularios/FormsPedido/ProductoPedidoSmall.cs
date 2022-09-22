using CapaEntidades.BindingModels;
using CapaPresentacion.Formularios.Controles;
using CapaPresentacion.Formularios.FormsProductos;
using CapaPresentacion.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

            this.txtInfo.ForeColor = Color.FromArgb(4, 0, 85);
        }

        public event EventHandler OnAddButtonClick;
        public event EventHandler OnRefreshList;
        public event EventHandler OnRemoveButtonClick;

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            this.OnRemoveButtonClick?.Invoke(this.Producto, e);
        }
        private void BtnComment_Click(object sender, EventArgs e)
        {
            //Este botón cuando está en la lista de productos no agregados lo podremos usar para editar dicho producto
            if (this.Producto.DetallePedido == null)
            {
                FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto()
                {
                    StartPosition = FormStartPosition.CenterScreen,
                    MinimizeBox = false,
                    MaximizeBox = false,
                    Producto = this.Producto.Producto,
                };
                frmAgregarProducto.OnProductSuccess += FrmAgregarProducto_OnProductSuccess;
                frmAgregarProducto.ShowDialog();
            }
            else
            {
                PoperContainer container = new PoperContainer(Observacion);
                container.VisibleChanged += Container_VisibleChanged;
                container.Show(this.btnComment);
            }
        }
        private void FrmAgregarProducto_OnProductSuccess(object sender, EventArgs e)
        {
            this.OnRefreshList?.Invoke(sender, e);
        }
        private void Container_VisibleChanged(object sender, EventArgs e)
        {
            string observaciones = this.Observacion.txtObservacion.Text;
            this.Producto.DetallePedido.Observaciones = observaciones;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.OnAddButtonClick?.Invoke(this.Producto, e);
        }

        Observacion Observacion = new Observacion();
        private Image _imagenProducto;
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

        public Image ImagenProducto
        {
            get => _imagenProducto;
            set
            {
                _imagenProducto = value;
                if (value == null)
                    this.pxImagen.Image = Resources.SIN_IMAGENES;
                else
                    this.pxImagen.Image = value;
            }
        }

        private void AsignarDatos(ProductoPedidoBindingModel producto)
        {
            StringBuilder info = new StringBuilder();
            if (producto.DetallePedido == null)
            {
                info.Append(producto.Producto.Nombre_producto).Append(Environment.NewLine);
                info.Append($"{((int)producto.Producto.Precio_producto):C} | ");
                info.Append(producto.Producto.Descripcion_producto);      
                this.btnComment.BackgroundImage = Resources.editx64;
                this.toolTip1.SetToolTip(this.btnComment, "Editar datos del producto");
                this.btnRemove.Visible = false;
                this.btnComment.Visible = true;               
                this.btnAdd.Visible = true;
            }
            else
            {
                info.Append(producto.Producto.Nombre_producto).Append(Environment.NewLine);
                info.Append($"{producto.DetallePedido.Precio:C}").Append(" | Cantidad ");
                info.Append(producto.DetallePedido.Cantidad).Append(Environment.NewLine); ;
                info.Append($"Subtotal: {((int)producto.DetallePedido.Precio_total):C}");
                this.btnComment.BackgroundImage = Resources.commentsx128;
                this.toolTip1.SetToolTip(this.btnComment, "Realizar un comentario al producto");
                this.btnComment.Visible = true;
                this.btnRemove.Visible = true;
                this.btnAdd.Visible = false;
            }
            this.txtInfo.Text = info.ToString();
        }
    }
}
