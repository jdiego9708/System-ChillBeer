using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class FrmAgregarProducto : Form
    {
        public FrmAgregarProducto()
        {
            InitializeComponent();

            this.btnGuardar.Click += BtnSave_Click;
            this.Load += FrmAddProduct_Load;
            this.listaTipoProductos.SelectedIndexChanged += ListaTipoProductos_SelectedIndexChanged;
        }

        private void ListaTipoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(this.listaTipoProductos.SelectedValue), out int id_tipo_producto))
                LlenarListas.LlenarListaCatalogoGeneral(this.listaTipoProductos);
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                LlenarListas.LlenarListaCatalogoGeneral(this.listaTipoProductos);
            }
        }

        public event EventHandler OnProductSuccess;

        private Productos Comprobaciones()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                Mensajes.MensajeInformacion("Verifique los campos");
                return null;
            }

            if (!decimal.TryParse(this.txtPrecio.Text, out decimal precio))
            {
                Mensajes.MensajeInformacion("Verifique el precio");
                return null;
            }
            else
            {
                if (precio == 0)
                {
                    Mensajes.MensajeInformacion("Verifique el precio del producto");
                    return null;
                }
            }

            if (!int.TryParse(Convert.ToString(this.listaTipoProductos.SelectedValue), out int id_tipo_producto))
            {
                Mensajes.MensajeInformacion("Verifique el tipo de producto");
                return null;
            }

            return new Productos
            {
                Id_tipo_producto = id_tipo_producto,
                Nombre_producto = this.txtNombre.Text,
                Precio_producto = precio,
                Descripcion_producto = this.txtDescripcion.Text,
                Estado_producto = "ACTIVO",
            };
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Productos product = this.Comprobaciones();
                if (product != null)
                {
                    string mensaje = string.Empty;

                    string rpta = NProductos.InsertarProducto(product).Result;

                    if (rpta.Equals("OK"))
                    {
                        mensaje = "Producto guardado con exito";

                        if (this.uploadImagen.Nombre_imagen == null)
                            this.uploadImagen.Nombre_imagen = "SIN IMAGEN";

                        if (!this.uploadImagen.Nombre_imagen.Equals("SIN IMAGEN"))
                        {
                            rpta = ArchivosAdjuntos.GuardarArchivo(product.Id_producto, "rutaImages",
                                this.uploadImagen.Nombre_imagen,
                                this.uploadImagen.Ruta_origen);

                            if (rpta.Equals("OK"))
                                mensaje = "Producto guardado con exito";
                            else
                                mensaje = "Producto guardado con exito pero no se pudo guardar su imagen";
                        }

                        Mensajes.MensajeOkForm(mensaje);
                        this.OnProductSuccess?.Invoke(product, e);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Hubo un error guardando el producto, intentalo más tarde | {ex.Message}");
            }
        }

        private void AsignarDatos(Productos product)
        {
            this.txtNombre.Text = product.Nombre_producto;
            this.txtPrecio.Text = product.Precio_producto.ToString("N2");
            this.txtDescripcion.Text = product.Descripcion_producto;

            LlenarListas.LlenarListaCatalogoGeneral(this.listaTipoProductos);

            this.listaTipoProductos.SelectedValue = product.Id_tipo_producto;
        }

        private bool _isEditar;
        private Productos _product;

        public Productos Producto
        {
            get => _product;
            set
            {
                _product = value;
                this.AsignarDatos(value);
            }
        }

        public bool IsEditar
        {
            get => _isEditar;
            set
            {
                _isEditar = value;
                this.Text = "Editar usuarios";
            }
        }
    }
}
