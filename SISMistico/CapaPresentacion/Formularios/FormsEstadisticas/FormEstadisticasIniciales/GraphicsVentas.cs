using CapaEntidades.Helpers;
using CapaEntidades.Models;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion.Formularios.FormsEstadisticas.FormEstadisticasIniciales
{
    public partial class GraphicsVentas : UserControl
    {
        public GraphicsVentas()
        {
            InitializeComponent();
        }
        public void CargarGraficoGastos5Dias()
        {
            try
            {
                //Limpiar recursos anteriores
                this.chart1.Titles.Clear();
                this.chart1.Series.Clear();
                this.chart1.Legends.Clear();

                //Agregamos un titulo al gráfico
                //Title title = new Title
                //{
                //    Font = new Font("Segoe UI Emoji", 14F, FontStyle.Bold, GraphicsUnit.Point, 0),
                //    ForeColor = Color.FromArgb(4, 0, 85),
                //    BorderColor = Color.White,
                //    BorderWidth = 0,
                //    Text = "Gastos en los últimos 5 días"
                //};

                this.groupBox1.Text = "Gastos en los últimos 5 días";

                //this.chart1.Titles.Add(title);

                //Lista de leyendas que tenemos
                List<string> Legends = new List<string>
                {
                    "Total",
                    "Día"
                };

                //Agregamos estas leyendas
                //foreach (string s in Legends)
                //{
                //    Legend legend = new Legend
                //    {
                //        Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0),
                //        ForeColor = Color.FromArgb(4, 0, 85),
                //        LegendStyle = LegendStyle.Table,
                //        Docking = Docking.Right,
                //        Alignment = StringAlignment.Near,
                //        BorderWidth = 0
                //    };
                //    this.chart1.Legends.Add(legend);
                //}

                this.chart1.Location = new Point(-110, 0);

                //Obtenemos los últimos 5 turnos
                var result = NTurnos.BuscarTurnos("TOP 5 TURNOS GASTOS", string.Empty, string.Empty);
                DataTable dtTurnos = result.Result.dtTurnos;

                if (dtTurnos == null) return;

                List<CustomSerie> customSeries = new List<CustomSerie>();

                foreach (DataRow row in dtTurnos.Rows)
                {
                    DateTime fechaEgreso = ConvertValueHelper.ConvertirFecha(row["Fecha_egreso"]);
                    int cantidad = ConvertValueHelper.ConvertirNumero(row["Cantidad"]);
                    decimal total = ConvertValueHelper.ConvertirDecimal(row["Total"]);

                    CustomSerie customSerie1 = new CustomSerie
                    {
                        Valor_real = Convert.ToInt32(total),
                        Valor_decimal = total,
                        Texto_mostrar = total.ToString("C").Replace(",00", "").Replace(",00", ""),
                        Legend_text = fechaEgreso.ToString("MM/dd"),
                        Tool_tip = total.ToString("C").Replace(",00", "").Replace(",00", ""),
                    };
                    customSeries.Add(customSerie1);
                }

                Series serie = new Series
                {
                    Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    LabelForeColor = Color.FromArgb(4, 0, 85),
                    LabelBorderWidth = 0,
                    BorderWidth = 0,
                    BorderDashStyle = 0,
                    MarkerBorderWidth = 0,
                    BorderColor = Color.White,
                    MarkerBorderColor = Color.White,
                    ChartType = SeriesChartType.Column,
                    Name = "Gastos"
                };

                this.chart1.Series.Add(serie);

                for (int i = 0; i <= customSeries.Count - 1; i++)
                {
                    int idx = this.chart1.Series[serie.Name].Points.AddXY(customSeries[i].Legend_text,
                        customSeries[i].Valor_decimal);
                    this.chart1.Series[serie.Name].Points[idx].Label = customSeries[i].Texto_mostrar;
                    this.chart1.Series[serie.Name].Points[idx].LegendText = customSeries[i].Legend_text;
                    this.chart1.Series[serie.Name].Points[idx].LabelToolTip = customSeries[i].Tool_tip;
                    this.chart1.Series[serie.Name].Points[idx].ToolTip = customSeries[i].Tool_tip;
                }

                this.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;

                this.chart1.Palette = ChartColorPalette.None;

                Color c = Color.FromArgb(255, 120, 130);

                Color[] colors = new Color[] { c };
                this.chart1.PaletteCustomColors = colors;
            }
            catch (Exception ex)
            {
            }
        }
        public void CargarGraficoVentas5Dias()
        {
            try
            {
                //Limpiar recursos anteriores
                this.chart1.Titles.Clear();
                this.chart1.Series.Clear();
                this.chart1.Legends.Clear();

                //Agregamos un titulo al gráfico
                //Title title = new Title
                //{
                //    Font = new Font("Segoe UI Emoji", 14F, FontStyle.Bold, GraphicsUnit.Point, 0),
                //    ForeColor = Color.FromArgb(4, 0, 85),
                //    BorderColor = Color.White,
                //    BorderWidth = 0,
                //    Text = "Ventas en los últimos 5 días"
                //};

                //this.chart1.Titles.Add(title);

                this.groupBox1.Text = "Ventas en los últimos 5 días";

                //Lista de leyendas que tenemos
                List<string> Legends = new List<string>
                {
                    "Total",
                    "Día"
                };

                //Agregamos estas leyendas
                //foreach (string s in Legends)
                //{
                //    Legend legend = new Legend
                //    {
                //        Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0),
                //        ForeColor = Color.FromArgb(4, 0, 85),
                //        LegendStyle = LegendStyle.Table,
                //        Docking = Docking.Right,
                //        Alignment = StringAlignment.Near,
                //        BorderWidth = 0
                //    };
                //    this.chart1.Legends.Add(legend);
                //}

                this.chart1.Location = new Point(-110, 0);

                //Obtenemos los últimos 5 turnos
                var result = NTurnos.BuscarTurnos("TOP 5 TURNOS VENTAS", string.Empty, string.Empty);
                DataTable dtTurnos = result.Result.dtTurnos;

                if (dtTurnos == null) return;

                List<CustomSerie> customSeries = new List<CustomSerie>();

                foreach (DataRow row in dtTurnos.Rows)
                {
                    int id_turno = ConvertValueHelper.ConvertirNumero(row["Id_turno"]);
                    DateTime fechaVentas = ConvertValueHelper.ConvertirFecha(row["Fecha_venta"]);
                    int cantidad = ConvertValueHelper.ConvertirNumero(row["Cantidad"]);
                    decimal total = ConvertValueHelper.ConvertirDecimal(row["Total"]);

                    CustomSerie customSerie1 = new CustomSerie
                    {
                        Valor_real = Convert.ToInt32(total),
                        Valor_decimal = total,
                        Texto_mostrar = total.ToString("C").Replace(",00", "").Replace(",00", ""),
                        Legend_text = fechaVentas.ToString("MM/dd"),
                        Tool_tip = total.ToString("C").Replace(",00", "").Replace(",00", ""),
                    };
                    customSeries.Add(customSerie1);
                }

                Series serie = new Series
                {
                    Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold, GraphicsUnit.Point, 0),
                    LabelForeColor = Color.FromArgb(4, 0, 85),
                    LabelBorderWidth = 0,
                    BorderWidth = 0,
                    BorderDashStyle = 0,
                    MarkerBorderWidth = 0,
                    BorderColor = Color.White,
                    MarkerBorderColor = Color.White,
                    ChartType = SeriesChartType.Column,
                    Name = "Ventas"
                };

                this.chart1.Series.Clear();
                this.chart1.Series.Add(serie);

                for (int i = 0; i <= customSeries.Count - 1; i++)
                {
                    int idx = this.chart1.Series[serie.Name].Points.AddXY(customSeries[i].Legend_text,
                        customSeries[i].Valor_decimal);
                    this.chart1.Series[serie.Name].Points[idx].Label = customSeries[i].Texto_mostrar;
                    this.chart1.Series[serie.Name].Points[idx].LegendText = customSeries[i].Legend_text;
                    this.chart1.Series[serie.Name].Points[idx].LabelToolTip = customSeries[i].Tool_tip;
                    this.chart1.Series[serie.Name].Points[idx].ToolTip = customSeries[i].Tool_tip;
                }

                this.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                this.chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            }
            catch (Exception ex)
            {
            }
        }
        public class CustomSerie
        {
            public CustomSerie() { }
            public int Valor_real { get; set; }
            public decimal Valor_decimal { get; set; }
            public string Texto_mostrar { get; set; }
            public string Legend_text { get; set; }
            public string Tool_tip { get; set; }
        }
    }
}
