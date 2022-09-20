using CapaEntidades.Models;

namespace CapaEntidades.BindingModels
{
    public class ProductoPedidoBindingModel
    {
        public Detalle_pedido DetallePedido { get; set; }
        public int Id_producto { get; set; }
        public Productos Producto { get; set; }
    }
}
