using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Proyecto
{
    internal class Impresor
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        public void Imprime(LocalReport rdlc, int copias)
        {
            Export(rdlc);
            Print(copias);
        }
        
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <MarginTop>0.0in</MarginTop>
                <MarginLeft>0.0in</MarginLeft>
                <MarginRight>0.0in</MarginRight>
                <MarginBottom>0.0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
            { stream.Position = 0; }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Print(int copias)
        {
            PrintDocument printDoc;

            String printerName = ImpresoraPredeterminada();

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: No hay datos que imprimir.");

            printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = printerName;
            printDoc.PrinterSettings.Copies = (short)copias;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception(String.Format("No puedo encontrar la impresora \"{0}\".", printerName));
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;

                printDoc.Print();
            }
        }

        private string ImpresoraPredeterminada()
        {
            for (Int32 i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                PrinterSettings a = new PrinterSettings();
                a.PrinterName = PrinterSettings.InstalledPrinters[i].ToString();
                if (a.IsDefaultPrinter)
                { return PrinterSettings.InstalledPrinters[i].ToString(); }
            }
            return "";
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            //Crea un marco que contiene el documento (No es necesario)
            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Dibuja un fondo blanco para el report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Dibuja el contenido del report
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Lo prepara para la siguiente página y comprueba que no llegado al final
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }










        public void Imprime3(LocalReport rdlc, int copias)
        {
            Export3(rdlc);
            Print3(copias);


        }

        private void Export3(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <MarginTop>0.0in</MarginTop>
                <MarginLeft>0.0in</MarginLeft>
                <MarginRight>0.0in</MarginRight>
                <MarginBottom>0.0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream3, out warnings);
            foreach (Stream stream in m_streams)
            { stream.Position = 0; }
        }
        private Stream CreateStream3(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Print3(int copias)
        {


            PrintDialog p = new PrintDialog();
            PrintDocument printDoc;

            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: No hay datos que imprimir.");

            printDoc = new PrintDocument();

            printDoc.PrinterSettings.Copies = (short)copias;

            p.Document = printDoc;
            if (p.ShowDialog() == DialogResult.OK)
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;

                printDoc.Print();
            }
                



        }

        private void PrintPage3(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);

            //Crea un marco que contiene el documento (No es necesario)
            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Dibuja un fondo blanco para el report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Dibuja el contenido del report
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Lo prepara para la siguiente página y comprueba que no llegado al final
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Dispose3()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }


    }
}
