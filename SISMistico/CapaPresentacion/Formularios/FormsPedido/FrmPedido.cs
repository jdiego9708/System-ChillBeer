namespace CapaPresentacion.Formularios.FormsPedido
{
    using CapaEntidades.BindingModels;
    using CapaEntidades.Models;
    using CapaNegocio;
    using CapaPresentacion.Formularios.FormsClientes;
    using CapaPresentacion.Formularios.FormsPedido.Platos;
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
        }
        private bool Comprobaciones(out Pedidos pedido,
            out List<Detalle_pedido> detalles,
            out string rpta)
        {
            if (this.Pedido == null)
                pedido = new Pedidos();
            else
                pedido = this.Pedido;

            detalles = new List<Detalle_pedido>();
            rpta = string.Empty;
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

                    FrmObservarClientes frmObservarClientes = new FrmObservarClientes()
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                    };
                    frmObservarClientes.OnBtnNext += FrmObservarClientes_OnBtnNext;
                    frmObservarClientes.ShowDialog();
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

                foreach (ProductoPedidoBindingModel product in this.ProductsSelected)
                {
                    Detalle_pedido detalle = new Detalle_pedido()
                    {
                        Id_pedido = id_pedido,
                        Id_producto = product.Id_producto,
                        Fecha_detalle = DateTime.UtcNow,
                        Hora_detalle = DateTime.UtcNow.TimeOfDay,
                        Precio = product.DetallePedido.Precio,
                        Cantidad = product.DetallePedido.Cantidad,
                        Precio_total = product.DetallePedido.Precio * product.DetallePedido.Cantidad,
                    };

                    total_venta += detalle.Precio_total;

                    detalles.Add(detalle);
                }

                pedido = new Pedidos()
                {
                    Fecha_pedido = DateTime.UtcNow,
                    Hora_pedido = DateTime.UtcNow.ToString("HH:mm"),
                    Id_cliente = this.ClienteSelected.Id_cliente,
                    Id_empleado = datos.EmpleadoClaveMaestra.Id_empleado,
                    Estado_pedido = estado_pedido,
                    Tipo_pedido = tipo_pedido, 
                };

                return true;
            }
            catch (Exception ex)
            {
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

                rpta = NPedido.InsertarPedido(pedido);

                if (!rpta.Equals("OK"))
                    throw new Exception($"No se pudo insertar el pedido, comuníquese con el administrador | {rpta}");

                foreach(Detalle_pedido detalle in detalles)
                {
                    rpta = NPedido.InsertarDetallePedido(detalle);
                    if (!rpta.Equals("OK"))
                        throw new Exception($"No se pudo insertar un detalle de un pedido, se canceló la operación | {rpta}");
                }

                Mensajes.MensajeInformacion("¡Pedido realizado!");
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
                //Comprobar existencia del producto en los productos seleccionados
                if (this.ProductsSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        //productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

                //Comprobar existencia del producto en los productos nuevos seleccionados 
                if (this.ProductsAddSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

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
                //Comprobar existencia del producto en los productos seleccionados
                if (this.ProductsSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        //productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

                //Comprobar existencia del producto en los productos nuevos seleccionados 
                if (this.ProductsAddSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error removiendo un producto | {ex.Message}");
            }
        }
        private void FrmPedido_Load(object sender, EventArgs e)
        {
            this.LoadCategorias("CATALOGO PADRE", "TIPOS DE PRODUCTOS");

            if (this.Categorias != null)
                this.LoadProductos("ID TIPO PRODUCTO", this.Categorias[0].Id_tipo.ToString());
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
                            Producto = new ProductoPedidoBindingModel
                            {
                                Producto = producto,
                            },
                        };
                        controls.Add(productoSmall);
                    }
                    this.panelProductos.BackgroundImage = null;
                    this.panelProductos.AddArrayControl(controls);
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
                    productoSmall.OnCommentButtonClick += ProductoSmall_OnCommentButtonClick;

                    controls.Add(productoSmall);
                }

                this.panelProductos.BackgroundImage = null;
                this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeInformacion($"Error cargando los productos seleccionados | {ex.Message}");
            }
        }
        private void ProductoSmall_OnCommentButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
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
            this.LoadProductos("ID TIPO PRODUCTO", catalogo.Id_tipo.ToString());
        }
        private void AsignarDatos(Pedidos pedido)
        {
            //Obtener los detalles del pedido
            DataTable dtDetallePedido = NPedido.BuscarPedidos("DETALLE ID PEDIDO", pedido.Id_pedido.ToString());
            if (dtDetallePedido != null)
            {
                List<ProductoPedidoBindingModel> listProducts = new List<ProductoPedidoBindingModel>();
                DataTable dtDetalle = dtDetallePedido;

                foreach (DataRow row in dtDetalle.Rows)
                {
                    Detalle_pedido detalle = new Detalle_pedido(row);
                    ProductoPedidoBindingModel productoPedido = new ProductoPedidoBindingModel()
                    {
                        DetallePedido = detalle,
                    };
                    listProducts.Add(productoPedido);
                }

                this.ProductsSelected = listProducts;
                this.LoadProductosSelected(listProducts);
            }
            this.gbInfo.Text = $"Agregar/Remover productos | {pedido.Tipo_pedido}";
        }

        public event EventHandler OnBtnActualizarPedido;
        public event EventHandler OnBtnNuevoPedido;
        public event EventHandler OnBtnPedidoSuccess;

        public List<ProductoPedidoBindingModel> ProductsSelected { get; set; }
        public List<ProductoPedidoBindingModel> ProductsAddSelected { get; set; }
        public List<Catalogo> Categorias { get; set; }
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
