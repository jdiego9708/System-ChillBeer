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

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class ProductoSmall : UserControl
    {
        public ProductoSmall()
        {
            InitializeComponent();
            this.btnEditar.Click += BtnEditar_Click;
            this.btnNext.Click += BtnNext_Click;
        }

        public event EventHandler OnBtnNextClick;
        public event EventHandler OnBtnEditarClick;
        public event EventHandler OnBtnEditarStockClick;

        private void BtnNext_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            this.OnBtnEditarClick?.Invoke(this.Producto, e);
        }

        private void ObtenerStockProducto()
        {

        }
        private void AsignarDatos(Productos producto)
        {
            this.txtNombre.Text = producto.Nombre_producto;
            this.txtTipo.Text = producto.Tipo_producto.Nombre_tipo;

            this.pxImagen.Image = Imagenes.ObtenerImagen("RUTAIMAGES", 
                producto.Imagen_producto, out string ruta_destino);
          
            StringBuilder info = new StringBuilder();

            info.Append($"Precio: {producto.Precio_producto:C}");

            if (!string.IsNullOrEmpty(producto.Descripcion_producto))
                info.Append($" | {producto.Descripcion_producto} | ");

            this.txtInformacion.Text = info.ToString();
        }

        private Productos _producto;
        public Productos Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }
    }
}
