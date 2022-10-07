namespace CapaPresentacion.Formularios.FormsPedido
{
    using CapaEntidades.BindingModels;
    using CapaEntidades.Models;
    using CapaNegocio;
    using CapaPresentacion.Formularios.FormsClientes;
    using CapaPresentacion.Formularios.FormsPedido.Platos;
    using CapaPresentacion.Formularios.FormsProductos;
    using CapaPresentacion.Properties;
    using Microsoft.ReportingServices.Diagnostics.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
            //this.txtBusqueda.KeyPress += TxtBusqueda_OnTextoKeyPress;
            this.btnSave.Click += BtnSave_Click;
            this.Load += FrmPedido_Load;
            this.btnAddProduct.Click += BtnAddProduct_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (this.TipoProductoSelected == null)
                return;

            this.LoadProductos("ID TIPO PRODUCTO", TipoProductoSelected.Id_tipo.ToString());
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto()
            {
                MinimizeBox = false,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
            };
            frmAgregarProducto.OnProductSuccess += FrmAgregarProducto_OnProductSuccess;
            frmAgregarProducto.ShowDialog();
        }
        private void FrmAgregarProducto_OnProductSuccess(object sender, EventArgs e)
        {
            if (this.TipoProductoSelected == null)
                return;

            this.LoadProductos("ID TIPO PRODUCTO", TipoProductoSelected.Id_tipo.ToString());
        }
        private bool Comprobaciones(out Pedidos pedido,
            out List<Detalle_pedido> detalles,
            out string rpta)
        {
            if (this.Pedido == null)
            {
                pedido = new Pedidos
                {
                    Fecha_pedido = DateTime.Now,
                    Hora_pedido = DateTime.Now.ToString("HH:mm"),
                    Observaciones_pedido = string.Empty,
                    CantidadClientes = 0
                };
            }
            else
                pedido = this.Pedido;

            detalles = new List<Detalle_pedido>();
            rpta = "OK";
            try
            {
                int id_pedido = this.Pedido == null ? 0 : this.Pedido.Id_pedido;

                DatosInicioSesion datos = DatosInicioSesion.GetInstancia();

                string estado_pedido = string.Empty;
                string tipo_pedido = string.Empty;

                if (chkFacturar.Checked)
                {
                    estado_pedido = "TERMINADO";
                    tipo_pedido = "INMEDIATO";
                }
                else
                {
                    estado_pedido = "PENDIENTE";
                    tipo_pedido = "CUENTA ABIERTA";

                    if (this.ClienteSelected == null)
                    {
                        FrmObservarClientes frmObservarClientes = new FrmObservarClientes()
                        {
                            StartPosition = FormStartPosition.CenterScreen,
                        };
                        frmObservarClientes.OnBtnNext += FrmObservarClientes_OnBtnNext;
                        frmObservarClientes.ShowDialog();
                    }
                }

                if (this.ClienteSelected == null)
                {
                    if (tipo_pedido.Equals("CUENTA ABIERTA"))
                    {
                        throw new Exception("Debe seleccionar un cliente para abrir una cuenta");
                    }
                    else
                        this.ClienteSelected = new Clientes
                        {
                            Id_cliente = 0,
                            Nombre_cliente = "CLIENTE CHILL",
                            Correo_electronico = "solucionesinformaticas9708@gmail.com",
                        };
                }

                if (datos.EmpleadoClaveMaestra == null)
                    datos.EmpleadoClaveMaestra = new Empleados
                    {
                        Id_empleado = datos.Id_empleado,
                    };

                //Comprobar los productos seleccionados
                if (this.ProductsAddSelected == null)
                    throw new Exception("Seleccione algún producto");

                if (this.ProductsAddSelected.Count <= 0)
                    throw new Exception("Seleccione algún producto");

                decimal total_venta = 0;

                foreach (ProductoPedidoBindingModel product in this.ProductsAddSelected)
                {
                    Detalle_pedido detalle = new Detalle_pedido()
                    {
                        Id_pedido = id_pedido,
                        Id_producto = product.Id_producto,
                        Id_tipo = product.Id_producto,
                        Fecha_detalle = DateTime.Now,
                        Hora_detalle = DateTime.Now.TimeOfDay,
                        Precio = product.DetallePedido.Precio,
                        Cantidad = product.DetallePedido.Cantidad,
                        Precio_total = product.DetallePedido.Precio * product.DetallePedido.Cantidad,
                        Observaciones = product.DetallePedido.Observaciones ?? string.Empty,
                        Tipo = "PRODUCTO"
                    };

                    total_venta += detalle.Precio_total;

                    detalles.Add(detalle);
                }

                pedido.Cliente = this.ClienteSelected;
                pedido.Id_cliente = this.ClienteSelected.Id_cliente;
                pedido.Empleado = datos.EmpleadoClaveMaestra;
                pedido.Id_empleado = datos.EmpleadoClaveMaestra.Id_empleado;
                pedido.Estado_pedido = estado_pedido;
                pedido.Tipo_pedido = tipo_pedido;

                pedido.Id_turno = datos.Turno.Id_turno;

                return true;
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion(ex.Message);
                rpta = ex.Message;
                return false;
            }
        }
        private void FrmObservarClientes_OnBtnNext(object sender, EventArgs e)
        {
            Clientes cliente = (Clientes)sender;
            this.ClienteSelected = cliente;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.Comprobaciones(out Pedidos pedido, out List<Detalle_pedido> detalles, out string rpta))
                    return;

                if (this.Pedido == null)
                    rpta = NPedido.InsertarPedido(pedido);

                if (!rpta.Equals("OK"))
                    throw new Exception($"No se pudo insertar el pedido, comuníquese con el administrador | {rpta}");

                foreach (Detalle_pedido detalle in detalles)
                {
                    detalle.Id_pedido = pedido.Id_pedido;
                    rpta = NPedido.InsertarDetallePedido(detalle);
                    if (!rpta.Equals("OK"))
                        throw new Exception($"No se pudo insertar un detalle de un pedido, se canceló la operación | {rpta}");
                }

                if (this.chkFacturar.Checked && this.Pedido == null)
                {
                    FrmFacturarPedido frmFacturarPedido = new FrmFacturarPedido
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                        MinimizeBox = false,
                        MaximizeBox = false,
                        Pedido = pedido,
                    };
                    frmFacturarPedido.ShowDialog();
                }

                this.OnBtnPedidoSuccess?.Invoke(pedido, e);
                this.Close();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error guardando un pedido | {ex.Message}");
            }
        }
        public void AddProduct(ProductoPedidoBindingModel product)
        {
            try
            {
                //Veririfico los productos SELECCIONADOS
                if (this.ProductsAddSelected == null)
                    this.ProductsAddSelected = new List<ProductoPedidoBindingModel>();

                List<ProductoPedidoBindingModel> findProductsSelected =
                    this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                if (findProductsSelected.Count > 0)
                {
                    ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                    productSelected.DetallePedido.Cantidad++;

                    productSelected.DetallePedido.Precio_total =
                        productSelected.DetallePedido.Precio * productSelected.DetallePedido.Cantidad;
                }
                else
                {
                    this.ProductsAddSelected.Add(new ProductoPedidoBindingModel()
                    {
                        Producto = product.Producto,
                        Id_producto = product.Id_producto,
                        DetallePedido = new Detalle_pedido
                        {
                            Id_producto = product.Id_producto,
                            Cantidad = 1,
                            Precio = product.Producto.Precio_producto,
                            Precio_total = product.Producto.Precio_producto,
                        },
                    });
                }

                this.LoadInfoInformacionSuperior();

                this.panelPedido.clearDataSource();

                this.LoadProductosSelected(this.ProductsAddSelected);

                if (this.ProductsSelected == null)
                    return;

                if (this.ProductsSelected.Count < 1)
                    return;

                this.LoadProductosSelected(this.ProductsSelected);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error agregando un producto | {ex.Message}");
            }
        }
        public void RemoveProduct(ProductoPedidoBindingModel product)
        {
            try
            {
                //Comprobar existencia del producto en los productos nuevos seleccionados 
                if (this.ProductsAddSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        productSelected.DetallePedido.Cantidad--;

                        if (productSelected.DetallePedido.Cantidad != 0)
                        {
                            productSelected.DetallePedido.Precio_total =
                                productSelected.DetallePedido.Precio * productSelected.DetallePedido.Cantidad;
                        }
                        else
                        {
                            ProductsAddSelected.Remove(product);
                        }
                    }
                }

                //Comprobar existencia del producto en los productos seleccionados
                if (this.ProductsSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];

                        //Comprobación de eliminación en base de datos
                        Mensajes.MensajePregunta("Va a eliminar un producto ya guardado, desea continuar?",
                            "Continuar", "Cancelar", out DialogResult dialog);
                        if (dialog != DialogResult.Yes)
                        {
                            DatosInicioSesion datos = DatosInicioSesion.GetInstancia();

                            productSelected.DetallePedido.Cantidad--;

                            //Actualizar la base de datos
                            string rpta = NPedido.ActualizarDetallePedido(productSelected.DetallePedido, datos.Id_empleado, "");
                            if (!rpta.Equals("OK"))
                                Mensajes.MensajeInformacion("No se pudo eliminar el detalle del pedido, comuníquese con el administrador");

                            this.ProductsAddSelected.Remove(productSelected);
                        }
                    }
                }

                this.LoadInfoInformacionSuperior();

                this.panelPedido.clearDataSource();

                this.LoadProductosSelected(this.ProductsAddSelected);

                if (this.ProductsSelected == null)
                    return;

                if (this.ProductsSelected.Count < 1)
                    return;

                this.LoadProductosSelected(this.ProductsSelected);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error removiendo un producto | {ex.Message}");
            }
        }
        private void FrmPedido_Load(object sender, EventArgs e)
        {
            if (Pedido == null)
                this.gbInfo.Text = $"Nueva venta | {DateTime.Now.ToLongDateString()} | {DateTime.Now.ToLongTimeString()}";
            else
                this.gbInfo.Text = $"Agregar/Remover productos | {this.Pedido.Tipo_pedido}";

            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            if (this.Categorias != null)
            {
                Catalogo TipoDefault = this.Categorias[0];

                if (TipoDefault == null)
                    return;

                this.LoadProductos("ID TIPO PRODUCTO", TipoDefault.Id_tipo.ToString());
            }
        }
        private void LoadProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelProductos.clearDataSource();

                var result = NProductos.BuscarProductos(tipo_busqueda, texto_busqueda);

                DataTable dtProductos = result.Result.dt;

                if (dtProductos != null)
                {
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtProductos.Rows)
                    {
                        Productos producto = new Productos(row);

                        ProductoPedidoSmall productoSmall = new ProductoPedidoSmall()
                        {
                            Producto = new ProductoPedidoBindingModel()
                            {
                                Id_producto = producto.Id_producto,
                                Producto = producto,
                                DetallePedido = null,
                            }
                        };
                        productoSmall.OnAddButtonClick += ProductoSmall_OnAddButtonClick;
                        productoSmall.OnRemoveButtonClick += ProductoSmall_OnRemoveButtonClick;
                        productoSmall.OnRefreshList += ProductoSmall_OnRefreshList;

                        controls.Add(productoSmall);
                    }
                    this.panelProductos.BackgroundImage = null;
                    this.panelProductos.AddArrayControl(controls);

                    this.threadLoadImages = new Thread(new ThreadStart(() => LoadImages()))
                    {
                        IsBackground = true
                    };
                    this.threadLoadImages.SetApartmentState(ApartmentState.STA);
                    this.threadLoadImages.Start();
                }
                else
                {
                    Image image = (Image)Resources.ResourceManager.GetObject("SIN_IMAGENES.jpg");
                    this.panelProductos.BackgroundImage = image;
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando los productos | {ex.Message}");
            }
        }
        private void LoadProductosSelected(List<ProductoPedidoBindingModel> products)
        {
            try
            {
                List<UserControl> controls = new List<UserControl>();

                foreach (ProductoPedidoBindingModel product in products)
                {
                    ProductoPedidoSmall productoSmall = new ProductoPedidoSmall()
                    {
                        Producto = product,
                    };
                    productoSmall.OnAddButtonClick += ProductoSmall_OnAddButtonClick;
                    productoSmall.OnRemoveButtonClick += ProductoSmall_OnRemoveButtonClick;
                    productoSmall.OnRefreshList += ProductoSmall_OnRefreshList;

                    controls.Add(productoSmall);
                }

                this.panelPedido.BackgroundImage = null;
                this.panelPedido.AddArrayControl(controls);

                this.threadLoadImages = new Thread(new ThreadStart(() => LoadImagesProductsSelected()))
                {
                    IsBackground = true
                };
                this.threadLoadImages.SetApartmentState(ApartmentState.STA);
                this.threadLoadImages.Start();
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando los productos seleccionados | {ex.Message}");
            }
        }
        private void ProductoSmall_OnRefreshList(object sender, EventArgs e)
        {
            if (this.Categorias != null)
            {
                Catalogo TipoDefault = this.Categorias[0];

                if (TipoDefault == null)
                    return;

                this.LoadProductos("ID TIPO PRODUCTO", TipoDefault.Id_tipo.ToString());
            }
        }
        private void ProductoSmall_OnRemoveButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
            this.RemoveProduct(product);
        }
        private void ProductoSmall_OnAddButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
            this.AddProduct(product);
        }
        private void LoadCategorias(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelCategorias.clearDataSource();

                var result = NProductos.BuscarTipoProductos(tipo_busqueda, texto_busqueda);

                if (result == null)
                    throw new Exception("Error obteniendo las categorias");

                if (result.Result.dt != null)
                {
                    DataTable dtCategorias = result.Result.dt;
                    List<UserControl> controls = new List<UserControl>();
                    this.Categorias = new List<Catalogo>();
                    foreach (DataRow row in dtCategorias.Rows)
                    {
                        Catalogo ca = new Catalogo(row);
                        TipoItem categoria = new TipoItem()
                        {
                            Catalogo = ca,
                            NombreTipo = ca.Nombre_tipo,
                        };
                        categoria.OnBtnTipoClick += Categoria_OnBtnCatalogo;
                        controls.Add(categoria);
                        this.Categorias.Add(ca);
                    }
                    this.panelCategorias.AddArrayControl(controls);
                }
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"No se pudieron obtener las categorías | {ex.Message}");
            }
        }
        private void Categoria_OnBtnCatalogo(object sender, EventArgs e)
        {
            Catalogo catalogo = (Catalogo)sender;

            if (catalogo == null)
                return;

            TipoProductoSelected = catalogo;

            this.LoadProductos("ID TIPO PRODUCTO", catalogo.Id_tipo.ToString());
        }
        private void AsignarDatos(Pedidos pedido)
        {
            this.chkFacturar.Visible = false;
            this.ClienteSelected = pedido.Cliente;

            //Obtener los detalles del pedido
            DataTable dtDetallePedido = NPedido.BuscarPedidos("ID PEDIDO DETALLE PRODUCTOS", pedido.Id_pedido.ToString());
            if (dtDetallePedido != null)
            {
                List<ProductoPedidoBindingModel> listProducts = new List<ProductoPedidoBindingModel>();
                DataTable dtDetalle = dtDetallePedido;

                foreach (DataRow row in dtDetalle.Rows)
                {
                    Detalle_pedido detalle = new Detalle_pedido(row);
                    ProductoPedidoBindingModel productoPedido = new ProductoPedidoBindingModel()
                    {
                        Id_producto = detalle.Id_producto,
                        Producto = detalle.Producto,
                        DetallePedido = detalle,
                    };
                    listProducts.Add(productoPedido);
                }

                this.ProductsSelected = listProducts;
                this.LoadProductosSelected(listProducts);
                this.LoadInfoInformacionSuperior();
            }
        }
        private void LoadImages()
        {
            foreach (UserControl control in this.panelProductos.controlsUser)
            {
                if (control is ProductoPedidoSmall product)
                {
                    Image img;
                    string nombreimagen = product.Producto.Producto.Imagen_producto;
                    if (!string.IsNullOrEmpty(nombreimagen))
                    {
                        img = Imagenes.ObtenerImagen("RUTAIMAGES", nombreimagen, out string ruta_destino);

                        if (img == null)
                            img = Resources.SIN_IMAGENES;

                        product.ImagenProducto = img;
                    }
                    else
                    {
                        img = Resources.SIN_IMAGENES;
                        product.ImagenProducto = img;
                    }
                }
            }

            if (this.threadLoadImages.IsAlive)
                this.threadLoadImages.Interrupt();
        }
        private void LoadImagesProductsSelected()
        {
            if (this.ProductsSelected != null || this.ProductsAddSelected != null)
            {
                try
                {
                    foreach (UserControl control in this.panelPedido.controlsUser)
                    {
                        if (control is ProductoPedidoSmall product)
                        {
                            Image img;
                            string nombreimagen = product.Producto.Producto.Imagen_producto;
                            if (!string.IsNullOrEmpty(nombreimagen))
                            {
                                img = Imagenes.ObtenerImagen("RUTAIMAGES", nombreimagen, out string ruta_destino);

                                if (img == null)
                                    img = Resources.SIN_IMAGENES;

                                product.ImagenProducto = img;
                            }
                            else
                            {
                                img = Resources.SIN_IMAGENES;
                                product.ImagenProducto = img;
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }

                if (this.threadLoadImages.IsAlive)
                    this.threadLoadImages.Interrupt();
            }
        }
        private void LoadInfoInformacionSuperior()
        {
            try
            {
                StringBuilder info = new StringBuilder();

                if (this.ProductsAddSelected != null)
                {
                    int cantidad_productos = ProductsAddSelected.Sum(x => x.DetallePedido.Cantidad);
                    decimal total = ProductsAddSelected.Sum(x => x.DetallePedido.Precio_total);
                    info.Append($"Cantidad de productos para agregar al pedido {cantidad_productos} | ");
                    info.Append($"Total ${total:N} ");
                }

                if (this.ProductsSelected != null)
                {
                    int cantidad_productos = ProductsSelected.Sum(x => x.DetallePedido.Cantidad);
                    decimal total = ProductsSelected.Sum(x => x.DetallePedido.Precio_total);
                    info.Append($" | Cantidad de productos agregados anteriormente al pedido {cantidad_productos} | ");
                    info.Append($"Total ${total:N} ");
                }

                this.txtInfoPedido.Text = info.ToString();
            }
            catch (Exception)
            {
                this.txtInfoPedido.Text = "SIN INFORMACIÓN DISPONIBLE";
            }
        }

        Thread threadLoadImages;
        public event EventHandler OnBtnActualizarPedido;
        public event EventHandler OnBtnNuevoPedido;
        public event EventHandler OnBtnPedidoSuccess;

        public List<ProductoPedidoBindingModel> ProductsSelected { get; set; }
        public List<ProductoPedidoBindingModel> ProductsAddSelected { get; set; }
        public List<Catalogo> Categorias { get; set; }
        public Catalogo TipoProductoSelected { get; set; }
        public string Tipo_pedido { get; set; }
        public Clientes ClienteSelected { get; set; }

        private Pedidos _pedido;
        public Pedidos Pedido
        {
            get => _pedido;
            set
            {
                _pedido = value;
                this.AsignarDatos(value);
            }
        }
    }
}
