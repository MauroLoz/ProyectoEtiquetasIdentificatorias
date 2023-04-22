using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Proyecto
{
    public partial class Form4 : System.Windows.Forms.Form
    {
        public List<Datos> datos = new List<Datos>();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {


        }

        public void Cargar(int copias)
        {
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
            this.reportViewer2.RefreshReport();

            Impresor imp = new Proyecto.Impresor();
            imp.Imprime(reportViewer2.LocalReport, copias);
        }

        public void Cargar2(int copias)
        {
            reportViewer2.LocalReport.DataSources.Clear();
            reportViewer2.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
            this.reportViewer2.RefreshReport();

            Impresor imp = new Proyecto.Impresor();
            imp.Imprime3(reportViewer2.LocalReport, copias);
        }
    }
}
