namespace CapaEntidades.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Detalle_pedido
    {
        public Detalle_pedido()
        {

        }

        public Detalle_pedido(DataRow row)
        {
            try
            {
                if (row.Table.Columns.Contains("Id_detalle_pedido"))
                    this.Id_detalle_pedido = Convert.ToInt32(row["Id_detalle_pedido"]);

                this.Id_pedido = Convert.ToInt32(row["Id_pedido"]);
                this.Id_producto = Convert.ToInt32(row["Id_tipo"]);
                this.Tipo = Convert.ToString(row["Tipo"]);
                this.Precio = Convert.ToDecimal(row["Precio"]);
                this.Cantidad = Convert.ToInt32(row["Cantidad"]);
                this.Observaciones = Convert.ToString(row["Observaciones"]);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_detalle_pedido { get; set; }
        public int Id_pedido { get; set; }
        public int Id_producto { get; set; }
        public Productos Producto { get; set; }
        public DateTime Fecha_detalle { get; set; }
        public TimeSpan Hora_detalle { get; set; }
        public string Tipo { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_total { get; set; }
        public string Observaciones { get; set; }
        public List<Detalle_ingredientes_pedido> ListDetalleIngredientes { get; set; }
        public event EventHandler OnError;
    }
}
