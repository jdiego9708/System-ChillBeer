using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Formularios.FormsPrincipales;

namespace SISMistico
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzI0MzY4QDMyMzAyZTMyMmUzMFZnd2g4SEFwWHNhaUxBcEdzNDJWUTVTUFd2TitYaGlFZlA0a3RmWFlRMEE9");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmIniciarSesion());
        }
    }
}
