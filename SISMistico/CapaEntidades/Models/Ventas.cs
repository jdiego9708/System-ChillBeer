using CapaEntidades.Helpers;
using System;
using System.Data;

namespace CapaEntidades.Models
{
    public class Ventas
    {
        public Ventas()
        {

        }
        public Ventas(DataRow row)
        {
            this.Id_venta = ConvertValueHelper.ConvertirNumero(row["Id_venta"]);
            this.Id_pedido = ConvertValueHelper.ConvertirNumero(row["Id_pedido"]);    
            this.Id_turno = ConvertValueHelper.ConvertirNumero(row["Id_turno"]);    
            this.Fecha_venta = ConvertValueHelper.ConvertirFecha(row["Fecha_venta"]);
            this.Hora_venta = ConvertValueHelper.ConvertirHora(row["Hora_venta"]);
            this.Total_parcial = ConvertValueHelper.ConvertirDecimal(row["Total_parcial"]);
            this.Propina = ConvertValueHelper.ConvertirDecimal(row["Propina"]);
            this.Subtotal = ConvertValueHelper.ConvertirDecimal(row["Subtotal"]);
            this.Descuento = ConvertValueHelper.ConvertirDecimal(row["Descuento"]);
            this.Bono_cupon = ConvertValueHelper.ConvertirCadena(row["Bono_cupon"]);
            this.Desechables = ConvertValueHelper.ConvertirDecimal(row["Desechables"]);
            this.Domicilio = ConvertValueHelper.ConvertirDecimal(row["Domicilio"]);
            this.Total_final = ConvertValueHelper.ConvertirDecimal(row["Total_final"]);
            this.Observaciones = ConvertValueHelper.ConvertirCadena(row["Observaciones"]);
            this.Estado = ConvertValueHelper.ConvertirCadena(row["Estado"]);
            this.Pedido = new Pedidos(row);
        }
        public int Id_venta { get; set; }
        public int Id_pedido { get; set; }
        public int Id_turno { get; set; }
        public Pedidos Pedido { get; set; }
        public DateTime Fecha_venta { get; set; }
        public TimeSpan Hora_venta { get; set; }
        public decimal Total_parcial { get; set; }
        public decimal Propina { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string Bono_cupon { get; set; }
        public decimal Desechables { get; set; }
        public decimal Domicilio { get; set; }
        public decimal Total_final { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
