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
    public partial class Form2 : System.Windows.Forms.Form
    {
        public List<Datos> datos = new List<Datos>();
        public Form2()
        {
            InitializeComponent();
           
        }
        public void Form2_Load(object sender, EventArgs e)
        {
         
        }

        public void Cargar(int copias){
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", datos));
            this.reportViewer1.RefreshReport();

            Impresor imp = new Proyecto.Impresor();
            imp.Imprime(reportViewer1.LocalReport, copias);
        }

        public void Cargar2(int copias)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", datos));
            this.reportViewer1.RefreshReport();

            Impresor imp = new Proyecto.Impresor();
            imp.Imprime3(reportViewer1.LocalReport, copias);
        }

    }
}
