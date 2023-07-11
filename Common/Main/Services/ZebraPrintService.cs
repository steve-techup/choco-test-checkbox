using RFIDAbstractionLayer.TagEncoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Services;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;

namespace Caretag_Class.Services
{
    public class ZebraPrintService
    {
        public void PrintLabel(TrayLabel trayLabel, int copies, string filename)
        {
            var printers = UsbDiscoverer.GetZebraUsbPrinters();
            
            if (printers.Any())
            {
                var zPrinter = ZebraPrinterFactory.GetInstance(PrinterLanguage.ZPL, printers.First().GetConnection());
                zPrinter.Connection.Open();
                zPrinter.SendFileContents(filename);
                for (int i = 0; i < copies; i++)
                    zPrinter.PrintStoredFormat(filename.ToUpperInvariant(), trayLabel.getLabelArray());
                zPrinter.Connection.Close();
            }
        }
    }
}
