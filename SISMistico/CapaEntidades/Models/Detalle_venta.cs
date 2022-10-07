using CapaEntidades.Helpers;
using System.Data;

namespace CapaEntidades.Models
{
    public class Detalle_venta
    {
        public Detalle_venta()
        {

        }
        public Detalle_venta(DataRow row)
        {
            this.Id_venta = ConvertValueHelper.ConvertirNumero(row["Id_venta"]);
            this.Metodo_pago = ConvertValueHelper.ConvertirCadena(row["Metodo_pago"]);
            this.Valor_pago = ConvertValueHelper.ConvertirDecimal(row["Valor_pago"]);
            this.Vaucher = ConvertValueHelper.ConvertirCadena(row["Vaucher"]);
            this.Observaciones = ConvertValueHelper.ConvertirCadena(row["Observaciones"]);              
        }
        public int Id_venta { get; set; }
        public string Metodo_pago { get; set; }
        public decimal Valor_pago { get; set; }
        public string Vaucher { get; set; }
        public string Observaciones { get; set; }
    }
}
