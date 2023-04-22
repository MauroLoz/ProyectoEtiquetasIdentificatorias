using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Printing;
using System.Runtime.InteropServices;

namespace Proyecto
{
    public partial class Form1 : Form
    {
        //Cadena Conexion Microsoft Access
        string conn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\excels\Database2.mdb";

        public Form1()
        {
            InitializeComponent();
        }


        //Carga del Winform
        private void Form1_Load(object sender, EventArgs e)
        {
            txtPieza.Focus();
            cmbLoteMes.Items.Add("A");
            cmbLoteMes.Items.Add("B");
            cmbLoteMes.Items.Add("C");
            cmbLoteMes.Items.Add("D");
            cmbLoteMes.Items.Add("E");
            cmbLoteMes.Items.Add("F");
            cmbLoteMes.Items.Add("G");
            cmbLoteMes.Items.Add("J");
            cmbLoteMes.Items.Add("K");
            cmbLoteMes.Items.Add("L");
            cmbLoteMes.Items.Add("M");
            cargarListBox();
        }

        //Busqueda Dinamica mientras se ingresan caracteres en el TextBox de Pts
        public void BusquedaTextBox_TextChanged(object sender, EventArgs e)
        {
            ListBoxPro.Items.Clear();
            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(conn);
            conector.Open();
            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select [Item] from Modulo where [Item] like '%" + txtPieza.Text + "%'", conector);;
            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;
            DataTable tabla = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta);
            da.Fill(tabla);
            foreach (DataRow fila in tabla.Rows)
            {
                ListBoxPro.Items.Add(fila[0] + "");
            }
            conector.Close();
            if (ListBoxPro.Items.Count > 0)
            {
                ListBoxPro.SelectedIndex = 0;
                //var vari2 = (ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty);
                var vari2 = ListBoxPro.SelectedItem.ToString();
                ImportarDatosProveedor(vari2);
            }
            else
            {
                txtDescripcion.Text = "";
                txtCliente.Text = "";
                txtModulo.Text = "";
            }
        }

        //Seleccion del ListBox
        public void ListBoxPro_SelectedIndexChanged (object sender, EventArgs e)
        {

            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("S"))
            {
                txtCliente.Text = "";
                txtColada.Enabled = true;
                txtOF.Enabled = true;
            }
            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("PT"))
            {
                txtColada.Enabled = false;
                txtOF.Enabled = false;
                txtColada.Text = "";
                txtOF.Text = "";
            }

            txtLoteDia.Enabled = true;
            cmbLoteMes.Enabled = true;
            txtModulo.Enabled = true;
            txtCopias.Enabled = true;
            txtLoteDia.Text = "";

            ImportarDatosProveedor(ListBoxPro.SelectedItem.ToString());         
        }

        //Cargar el ListBox de PTs
        public void cargarListBox()
        {
            DataTable table = ObtenerPTS();
            foreach (DataRow fila in table.Rows)
            {
                ListBoxPro.Items.Add(fila[0] + "");
            }
        }

        //Generar e Imprimir la Etiquetia
        public void btnGenerarReporte_Click(object sender, EventArgs e)
        {

            Datos datos = new Datos();

            txtLoteDia.Enabled = false;
            txtModulo.Enabled = false;
            btnGenerarInforme.Enabled = false;
            btnConfig.Enabled = false;
            txtCopias.Enabled = false;
            datos.CodPieza = ImportarCodigoPieza((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
            datos.Pieza = (ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty);
            datos.Descripcion = txtDescripcion.Text;
            datos.Cliente = txtCliente.Text;
            datos.Lote = txtLoteDia.Text + "-" + cmbLoteMes.Text + "-" + txtLoteAño.Text;
            datos.Modulo = Int32.Parse(txtModulo.Text);
            string var = ImportarDatosProveedor2((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
            datos.Peso = double.Parse(var) * datos.Modulo;
            datos.Fecha = DateTime.Now.ToString("dd/MM/yy");
            datos.Usuario = Environment.UserName;
            string var1 = (ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty);
            datos.Codigo = var1 + "." + datos.Lote + "." + txtModulo.Text; 


            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("PT"))
            {
                Form2 frm2 = new Form2();
                DataTable tabla = ImportarDatosCliente2(txtCliente.Text);
                datos.CP = tabla.Rows[0][0].ToString();
                datos.Direccion = tabla.Rows[0][1].ToString();
                datos.Provincia = tabla.Rows[0][2].ToString();
                datos.CodProveedor = tabla.Rows[0][3].ToString();

                DataTable tabla2 = ImportarColores((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
                datos.Color1 = tabla2.Rows[0][0].ToString();
                if (datos.Color1 == "Sin color")
                {
                    datos.Color1 = "";
                }
                datos.Color2 = tabla2.Rows[0][1].ToString();
                if (datos.Color2 == "Sin color")
                {
                    datos.Color2 = "";
                }
                datos.Color3 = tabla2.Rows[0][2].ToString();
                if (datos.Color3 == "Sin color")
                {
                    datos.Color3 = "";
                }
                datos.Color4 = tabla2.Rows[0][3].ToString();
                if (datos.Color4 == "Sin color")
                {
                    datos.Color4 = "";
                }
                frm2.datos.Add(datos);
                frm2.Cargar(Convert.ToInt16(txtCopias.Text));
                txtCopias.Text = "1";

            }

            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("S"))
            {
                Form4 frm4 = new Form4();
                datos.Colada = txtColada.Text;
                datos.OF = txtOF.Text;
                frm4.datos.Add(datos);
                frm4.Cargar(Convert.ToInt16(txtCopias.Text));
                txtCopias.Text = "1";
            }

            txtPieza.Text = "";
            txtDescripcion.Text = "";
            txtCliente.Text = "";
            txtLoteDia.Text = "";
            txtLoteAño.Text = "";
            txtModulo.Text = "";
            txtColada.Text = "";
            txtOF.Text = "";
        }

        //Importar datos de Proveedor
        public void ImportarDatosProveedor(string Cod)
        {
            try
            {

                OleDbConnection conector = default(OleDbConnection);
                conector = new OleDbConnection(conn);
                conector.Open();

                OleDbCommand consulta = default(OleDbCommand);
                //consulta = new OleDbCommand("select [Item-Descripcion-Masa$].[Proveedor] from [Hoja1$] where [Hoja1$].[Numero] = @param", conector);
                consulta = new OleDbCommand("select [Descripcion] from Descripcion where [Item] = @param", conector);
                consulta.Parameters.AddWithValue("@param", Cod);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                adaptador.SelectCommand = consulta;
                DataTable tabla = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(consulta);
                da.Fill(tabla);

                txtDescripcion.Text = tabla.Rows[0][0].ToString();
                conector.Close();
                ImportarDatosCliente(Cod);
                ImportarDatosModulo(Cod);

                CargarFechas();
            }
            catch (Exception)
            {
                MessageBox.Show("No se encuentra ningun proveedor asociado a ese numero");
                txtPieza.Focus();             
            }            
        }

        //Importar datos Proveedor 
        public string ImportarDatosProveedor2(string Cod)
        {            


                OleDbConnection conector = default(OleDbConnection);
                conector = new OleDbConnection(conn);
                conector.Open();

                OleDbCommand consulta = default(OleDbCommand);
                //consulta = new OleDbCommand("select [Item-Descripcion-Masa$].[Proveedor] from [Hoja1$] where [Hoja1$].[Numero] = @param", conector);
                consulta = new OleDbCommand("select [Masa] from Descripcion where [Item] = @param", conector);
                consulta.Parameters.AddWithValue("@param", Cod);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                adaptador.SelectCommand = consulta;
                DataTable tabla = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(consulta);
                da.Fill(tabla);

                string masa = tabla.Rows[0][0].ToString();

                conector.Close();
                return masa;            
        }

        //Gestion de la fechas para el lote
        public void CargarFechas()
        {

            txtLoteAño.Text = DateTime.Now.ToString("yy").ToString();
            string fechaMes = DateTime.Now.ToString("MM");
            if ( fechaMes == "01")
            {
                cmbLoteMes.Text = "A";
            }
            if (fechaMes == "02")
            {
                cmbLoteMes.Text = "B";
            }
            if (fechaMes == "03")
            {
                cmbLoteMes.Text = "C";
            }
            if (fechaMes == "04")
            {
                cmbLoteMes.Text = "D";
            }
            if (fechaMes == "05")
            {
                cmbLoteMes.Text = "E";
            }
            if (fechaMes == "06")
            {
                cmbLoteMes.Text = "F";
            }
            if (fechaMes == "07")
            {
                cmbLoteMes.Text = "G";
            }
            if (fechaMes == "08")
            {
                cmbLoteMes.Text = "H";
            }
            if (fechaMes == "09")
            {
                cmbLoteMes.Text = "J";
            }
            if (fechaMes == "10")
            {
                cmbLoteMes.Text = "K";
            }
            if (fechaMes == "11")
            {
                cmbLoteMes.Text = "L";
            }
            if (fechaMes == "12")
            {
                cmbLoteMes.Text = "M";
            }
        }

        //Buscar datos Modulo
        public void ImportarDatosModulo(string Cod)
        {       

            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(conn);
            conector.Open();

            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select [Modulo] from Modulo where [Item] = @param", conector);
            consulta.Parameters.AddWithValue("@param", Cod);

            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;
            DataTable tabla = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta);
            da.Fill(tabla);

            txtModulo.Text = tabla.Rows[0][0].ToString();
            conector.Close();

            ImportarDatosCliente(Cod);
        }

        //Importar datos Cliente
        public void ImportarDatosCliente(string Cod)
        {
            if (Cod.StartsWith("PT"))
            {
                try
                {

                    OleDbConnection conector = default(OleDbConnection);
                    conector = new OleDbConnection(conn);
                    conector.Open();

                    OleDbCommand consulta = default(OleDbCommand);
                    consulta = new OleDbCommand("select [RazonSocial] from Item where [Item] = @param", conector);
                    consulta.Parameters.AddWithValue("@param", Cod);

                    OleDbDataAdapter adaptador = new OleDbDataAdapter();
                    adaptador.SelectCommand = consulta;
                    DataTable tabla = new DataTable();
                    OleDbDataAdapter da = new OleDbDataAdapter(consulta);
                    da.Fill(tabla);

                    txtCliente.Text = tabla.Rows[0][0].ToString();
                    conector.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se encuentra ningun proveedor asociado a ese numero");

                    txtPieza.Focus();
                }


            }

        }

        //Importar Datos Pieza
        public string ImportarCodigoPieza(string Cod)
        {
            if (Cod.StartsWith("PT"))
            {

                OleDbConnection conector = default(OleDbConnection);
                conector = new OleDbConnection(conn);
                conector.Open();

                OleDbCommand consulta = default(OleDbCommand);
                consulta = new OleDbCommand("select [ItemCliente] from Item where [Item] = @param", conector);
                consulta.Parameters.AddWithValue("@param", Cod);

                OleDbDataAdapter adaptador = new OleDbDataAdapter();
                adaptador.SelectCommand = consulta;
                DataTable tabla = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(consulta);
                da.Fill(tabla);

                string dato = tabla.Rows[0][0].ToString();
                conector.Close();
                return dato;

            }    
            else
            {
                return null;
            }
        }


        //Data Table's

        //Importar Colores
        public DataTable ImportarColores(string Cod)
        {


            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(conn);
            conector.Open();

            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select [Color1], [Color2], [Color3], [Color4]" +
                " from Colores where [Item] = @param", conector);
            consulta.Parameters.AddWithValue("@param", Cod);

            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;
            DataTable tabla = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta);
            da.Fill(tabla);
            conector.Close();
            return tabla;
        }

        //Importar datos Cliente
        public DataTable ImportarDatosCliente2(string Cod)
        {

            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(conn);
            conector.Open();
            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select [CP], [Direccion], [Provincia], [CodProveedor] from Clientes where [RazonSocial] = @param", conector);
            consulta.Parameters.AddWithValue("@param", Cod);
            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;
            DataTable tabla = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta);
            da.Fill(tabla);
            return tabla;
            conector.Close();
        }

        //Obtener PTs
        public DataTable ObtenerPTS()
        {

            OleDbConnection conector = default(OleDbConnection);
            conector = new OleDbConnection(conn);
            conector.Open();
            OleDbCommand consulta = default(OleDbCommand);
            consulta = new OleDbCommand("select [Item] from Modulo where [Item] like 'PT%'", conector);
            OleDbDataAdapter adaptador = new OleDbDataAdapter();
            adaptador.SelectCommand = consulta;
            DataTable tabla = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta);
            da.Fill(tabla);
            conector.Close();
            return tabla;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Datos datos = new Datos();

            txtLoteDia.Enabled = false;
            txtModulo.Enabled = false;
            btnGenerarInforme.Enabled = false;
            btnConfig.Enabled = false;
            txtCopias.Enabled = false;
            datos.CodPieza = ImportarCodigoPieza((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
            datos.Pieza = (ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty);
            datos.Descripcion = txtDescripcion.Text;
            datos.Cliente = txtCliente.Text;
            datos.Lote = txtLoteDia.Text + "-" + cmbLoteMes.Text + "-" + txtLoteAño.Text;
            datos.Modulo = Int32.Parse(txtModulo.Text);
            string var = ImportarDatosProveedor2((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
            datos.Peso = double.Parse(var) * datos.Modulo;
            datos.Fecha = DateTime.Now.ToString("dd/MM/yy");
            datos.Usuario = Environment.UserName;
            string var1 = (ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty);
            datos.Codigo = var1 + "." + datos.Lote + "." + txtModulo.Text;


            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("PT"))
            {
                Form2 frm2 = new Form2();
                DataTable tabla = ImportarDatosCliente2(txtCliente.Text);
                datos.CP = tabla.Rows[0][0].ToString();
                datos.Direccion = tabla.Rows[0][1].ToString();
                datos.Provincia = tabla.Rows[0][2].ToString();
                datos.CodProveedor = tabla.Rows[0][3].ToString();

                DataTable tabla2 = ImportarColores((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty));
                datos.Color1 = tabla2.Rows[0][0].ToString();
                if (datos.Color1 == "Sin color")
                {
                    datos.Color1 = "";
                }
                datos.Color2 = tabla2.Rows[0][1].ToString();
                if (datos.Color2 == "Sin color")
                {
                    datos.Color2 = "";
                }
                datos.Color3 = tabla2.Rows[0][2].ToString();
                if (datos.Color3 == "Sin color")
                {
                    datos.Color3 = "";
                }
                datos.Color4 = tabla2.Rows[0][3].ToString();
                if (datos.Color4 == "Sin color")
                {
                    datos.Color4 = "";
                }
                frm2.datos.Add(datos);
                frm2.Cargar2(Convert.ToInt16(txtCopias.Text));
                txtCopias.Text = "1";

            }

            if ((ListBoxPro.SelectedItem.ToString()).Replace(" ", String.Empty).StartsWith("S"))
            {
                Form4 frm4 = new Form4();
                datos.Colada = txtColada.Text;
                datos.OF = txtOF.Text;
                frm4.datos.Add(datos);
                frm4.Cargar2(Convert.ToInt16(txtCopias.Text));
                txtCopias.Text = "1";
            }

            txtPieza.Text = "";
            txtDescripcion.Text = "";
            txtCliente.Text = "";
            txtLoteDia.Text = "";
            txtLoteAño.Text = "";
            txtModulo.Text = "";
            txtColada.Text = "";
            txtOF.Text = "";
        }

        private void txtLoteDia_TextChanged(object sender, EventArgs e)
        {

                if (txtLoteDia.Text == "" || txtCopias.Text == "")
                {
                    btnConfig.Enabled = false;
                    btnGenerarInforme.Enabled = false;
                }
                else
                {
                    btnConfig.Enabled = true;
                    btnGenerarInforme.Enabled = true;
                }
            
           
        }

    }
}
