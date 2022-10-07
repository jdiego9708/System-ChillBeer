using System;

namespace CapaEntidades.Models
{
    public class Turnos_cierres
    {
        public int Id_cierre { get; set; }
        public int Id_turno { get; set; }
        public DateTime Fecha_cierre { get; set; }
        public TimeSpan Hora_cierre { get; set; }
        public string Observaciones { get; set; }
    }
}
