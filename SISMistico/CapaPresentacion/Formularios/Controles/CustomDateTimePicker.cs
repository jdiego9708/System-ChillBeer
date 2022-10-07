using Syncfusion.WinForms.Input;
using Syncfusion.WinForms.Input.Events;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios.Controles
{
    public partial class CustomDateTimePicker : UserControl
    {
        public CustomDateTimePicker()
        {
            InitializeComponent();
            this.calendar1.SelectionChanged += Calendar1_SelectionChanged;
            this.Load += CustomDateTimePicker_Load;
        }

        private void CustomDateTimePicker_Load(object sender, EventArgs e)
        {
            this.calendar1.MinDate = new DateTime(2022, 9, 1);
            this.calendar1.MaxDate = DateTime.Now;
        }

        public event EventHandler OnCalendarSelectionChanged;

        private void Calendar1_SelectionChanged(SfCalendar sender, SelectionChangedEventArgs e)
        {
            SfCalendar sfCalendar = sender as SfCalendar;

            this.OnCalendarSelectionChanged?.Invoke(sfCalendar, e);
        }
    }
}
