namespace CapaEntidades.Models
{
    using CapaEntidades.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public class Ingresos
    {
        public Ingresos()
        {

        }

        public Ingresos(DataRow row)
        {
            try
            {
                this.Id_ingreso = Convert.ToInt32(row["Id_ingreso"]);
                this.Id_empleado = Convert.ToInt32(row["Id_empleado"]);
                this.Id_turno = Convert.ToInt32(row["Id_turno"]);
                this.Empleado = new Empleados(row);
                this.Fecha_ingreso = Convert.ToDateTime(row["Fecha_ingreso"]);
                this.Hora_ingreso = ConvertValueHelper.ConvertirHora(row["Hora_ingreso"]);
                this.Valor_ingreso = Convert.ToDecimal(row["Valor_ingreso"]);
                this.Descripcion_ingreso = Convert.ToString(row["Descripcion_ingreso"]);
                this.Estado_ingreso = Convert.ToString(row["Estado_ingreso"]);
            }
            catch (Exception ex)
            {

            }
        }

        public int Id_ingreso { get; set; }
        public int Id_empleado { get; set; }
        public int Id_turno { get; set;  }
        public Empleados Empleado { get; set; }
        public DateTime Fecha_ingreso { get; set; } = DateTime.Now;
        public TimeSpan Hora_ingreso { get; set; }
        public decimal Valor_ingreso { get; set; }
        public string Descripcion_ingreso { get; set; }
        public string Estado_ingreso { get; set; }
    }
}
