using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using CapaEntidades.Models;

namespace CapaNegocio
{
    public class NClientes
    {
        #region INSERTAR CLIENTE

        public static string InsertarCliente(Clientes cliente)
        {
            DClientes DClientes = new DClientes();
            return DClientes.InsertarClientes(cliente);
        }

        #endregion

        #region EDITAR CLIENTE

        public static string EditarCliente(Clientes cliente)
        {
            DClientes DClientes = new DClientes();
            return DClientes.EditarClientes(cliente);
        }

        #endregion

        #region BUSCAR CLIENTES

        public static DataTable BuscarClientes(string tipo_busqueda, string texto_busqueda)
        {
            return DClientes.BuscarClientes(tipo_busqueda, texto_busqueda);
        }

        #endregion
    }
}
