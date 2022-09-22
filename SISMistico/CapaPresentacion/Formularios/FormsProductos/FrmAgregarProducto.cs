using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Web.Services.Description;
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
            //if (int.TryParse(Convert.ToString(this.listaTipoProductos.SelectedValue), out int id_tipo_producto))
            //    LlenarListas.LlenarListaCatalogoGeneral(this.listaTipoProductos);
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            if (this.Producto == null)
            {
                LlenarListas.LlenarListaCatalogoGeneral(this.listaTipoProductos);
            }
        }

        public event EventHandler OnProductSuccess;

        private bool Comprobaciones(out Productos product)
        {
            if (this.Producto == null)
                product = new Productos();
            else
                product = this.Producto;

            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                Mensajes.MensajeInformacion("Verifique los campos");
                return false;
            }

            if (!decimal.TryParse(this.txtPrecio.Text, out decimal precio))
            {
                Mensajes.MensajeInformacion("Verifique el precio");
                return false;
            }
            else
            {
                if (precio == 0)
                {
                    Mensajes.MensajeInformacion("Verifique el precio del producto");
                    return false;
                }
            }

            if (!int.TryParse(Convert.ToString(this.listaTipoProductos.SelectedValue), out int id_tipo_producto))
            {
                Mensajes.MensajeInformacion("Verifique el tipo de producto");
                return false;
            }

            string imagen = string.Empty;

            if (this.uploadImagen.Nombre_imagen != null)
            {
                imagen = string.Concat(this.uploadImagen.Nombre_imagen);
            }

            product.Id_tipo_producto = id_tipo_producto;
            product.Nombre_producto = this.txtNombre.Text;
            product.Precio_producto = precio;
            product.Descripcion_producto = this.txtDescripcion.Text;
            product.Estado_producto = "ACTIVO";
            product.Imagen_producto = imagen;

            return true;        
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                string rpta;
                bool result = this.Comprobaciones(out Productos product);
                if (result)
                {
                    if (!this.IsEditar)
                    {
                        rpta = NProductos.InsertarProducto(product).Result;
                        mensaje = "Producto guardado con exito";
                    }
                    else
                    {
                        rpta = NProductos.EditarProducto(product).Result;
                        mensaje = "Producto actualizado con exito";
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.uploadImagen.Nombre_imagen == null)
                            this.uploadImagen.Nombre_imagen = "SIN IMAGEN";

                        if (!this.uploadImagen.Nombre_imagen.Equals("SIN IMAGEN"))
                        {
                            rpta = ArchivosAdjuntos.GuardarArchivo(product.Id_producto, "rutaImages",
                                this.uploadImagen.Nombre_imagen,
                                this.uploadImagen.Ruta_origen);

                            if (!rpta.Equals("OK"))
                                mensaje += " pero no se pudo guardar su imagen";
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

            this.uploadImagen.AsignarImagen(product.Imagen_producto, "RUTAIMAGES");
        }

        private bool _isEditar;
        private Productos _product;

        public Productos Producto
        {
            get => _product;
            set
            {
                _product = value;
                this.IsEditar = true;
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
