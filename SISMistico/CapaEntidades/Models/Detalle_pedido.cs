namespace CapaEntidades.Models
{
    using CapaEntidades.Helpers;
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
                    this.Id_detalle_pedido = ConvertValueHelper.ConvertirNumero(row["Id_detalle_pedido"]);

                this.Id_pedido = ConvertValueHelper.ConvertirNumero(row["Id_pedido"]);
                this.Id_tipo = ConvertValueHelper.ConvertirNumero(row["Id_tipo"]);
                this.Tipo = ConvertValueHelper.ConvertirCadena(row["Tipo"]);
                this.Precio = ConvertValueHelper.ConvertirDecimal(row["Precio"]);
                this.Cantidad = ConvertValueHelper.ConvertirNumero(row["Cantidad"]);
                this.Observaciones = ConvertValueHelper.ConvertirCadena(row["Observaciones"]);

                if (row.Table.Columns.Contains("Precio_total"))
                    this.Precio_total = ConvertValueHelper.ConvertirDecimal(row["Precio_total"]);
                else
                    this.Precio_total = this.Precio * this.Cantidad;

                this.Producto = new Productos(row);
            }
            catch (Exception ex)
            {
                OnError?.Invoke(ex.Message, null);
            }
        }

        public int Id_detalle_pedido { get; set; }
        public int Id_tipo { get; set; }
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
