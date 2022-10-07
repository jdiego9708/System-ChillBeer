using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.FormsProductos
{
    public partial class FrmObservarProductos : Form
    {
        public FrmObservarProductos()
        {
            InitializeComponent();

            this.Load += FrmObservarProductos_Load;
            this.btnAddProduct.Click += BtnAddProduct_Click;
            this.btnRefresh.Click += BtnRefresh_Click;
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.BuscarProductos("COMPLETO", string.Empty);
        }
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
            };
            frmAgregarProducto.OnProductSuccess += FrmAgregarProducto_OnProductSuccess;
            frmAgregarProducto.ShowDialog();
        }
        private void FrmAgregarProducto_OnProductSuccess(object sender, EventArgs e)
        {
            this.BuscarProductos("COMPLETO", string.Empty);
        }
        private void FrmObservarProductos_Load(object sender, EventArgs e)
        {
            this.BuscarProductos("COMPLETO", string.Empty);
        }
        private void BuscarProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelProductos.clearDataSource();

                var result = NProductos.BuscarProductos(tipo_busqueda, texto_busqueda);

                DataTable dtProductos = result.Result.dt;

                if (dtProductos == null)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                if (dtProductos.Rows.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                List<UserControl> controls = new List<UserControl>();
                foreach (DataRow row in dtProductos.Rows)
                {
                    Productos producto = new Productos(row);

                    ProductoSmall productoSmall = new ProductoSmall()
                    {
                        Producto = producto,
                    };
                    productoSmall.OnBtnNextClick += ProductoSmall_OnBtnNextClick;
                    productoSmall.OnBtnEditarClick += ProductoSmall_OnBtnEditarClick;
                    productoSmall.OnBtnEditarStockClick += ProductoSmall_OnBtnEditarStockClick;
                    controls.Add(productoSmall);
                }

                if (controls.Count < 1)
                {
                    this.panelProductos.BackgroundImage = Properties.Resources.No_hay_productos;
                    return;
                }

                this.panelProductos.BackgroundImage = null;
                this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                Mensajes.MensajeErrorCompleto(this.Name, "BuscarProductos",
                    "Hubo un error con la tabla de datos", ex.Message);
            }
        }
        private void ProductoSmall_OnBtnEditarStockClick(object sender, EventArgs e)
        {
            
        }
        private void ProductoSmall_OnBtnEditarClick(object sender, EventArgs e)
        {
            Productos producto = (Productos)sender;

            FrmAgregarProducto frmEditarProducto = new FrmAgregarProducto()
            {
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false,
                Producto = producto,
            };
            frmEditarProducto.ShowDialog();
        }
        private void ProductoSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            
        }
    }
}
