using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades.Models;
using CapaEntidades.Helpers;

namespace CapaNegocio
{
    public class NTurnos
    {
        public static Task<string> InsertarCierreTurno(Turnos_cierres cierre)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.InsertarCierreTurno(cierre);
        }
        public static Task<string> InsertarTurno(Turno turno)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.InsertarTurno(turno);
        }

        public static Task<(string rpta, DataTable dtTurnos)> BuscarTurnos(string tipo_busqueda, string texto_busqueda1,
            string texto_busqueda2)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.BuscarTurnos(tipo_busqueda, texto_busqueda1, texto_busqueda2);
        }

        public static Task<string> InsertarBase(int id_turno, decimal base_nueva)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.InsertarBase(id_turno, base_nueva);
        }
        public static Task<string> EditarEstadoTurno(int id_turno, string estado)
        {
            DTurnos DTurnos = new DTurnos();
            return DTurnos.EditarEstadoTurno(id_turno, estado);
        }
        public static Task<(string rpta, DataTable dtEstadistica, DataTable dtDetalle, DataTable dtPagos)> BuscarEstadistica(int id_turno)
        {
            DTurnos dTurnos = new DTurnos();
            return dTurnos.BuscarEstadistica(id_turno);
        }

    }
}
