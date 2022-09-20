using CapaDatos;
using CapaEntidades.Models;
using System.Data;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NCatalogo
    {
        public static Task<string> InsertarCatalogo(Catalogo catalogo)
        {
            DCatalogo DCatalogo = new DCatalogo();
            return DCatalogo.InsertarCatalogo(catalogo);
        }
        public static Task<(string rpta, DataTable dt)> BuscarCatalogo(string tipo_busqueda, string texto_busqueda)
        {
            DCatalogo DCatalogo = new DCatalogo();
            return DCatalogo.BuscarCatalogo(tipo_busqueda, texto_busqueda);
        }
    }
}
