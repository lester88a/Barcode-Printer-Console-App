using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Printer_Console
{
    class Printer
    {
        //printer name variable
        public string printerName = "";
        //constructor
        public Printer()
        {
            //display all printers
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                if (printer == "Brother QL-710W")
                {
                    this.printerName = printer;
                }

            }

            if (printerName != "Brother QL-710W")
            {
                this.printerName = null;
            }
        }

        //get printer
        public void GetPrinter()
        {
            //display all printers
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {

                if (printer == "Brother QL-710W")
                {
                    printerName = printer;
                    //only display the Brother QL-710W printer
                    Console.WriteLine("Found the label printer: {0}.", printerName);

                    //call Bar-code class
                    Barcode br = new Barcode();
                    while (true)
                    {
                        Console.WriteLine();

                        br.GetInfo();
                        Console.WriteLine("\nSuccessful! Rerun the program.");

                        br.PrintBarcode();

                    }
                }

            }

            if (printerName != "Brother QL-710W")
            {
                Console.WriteLine("No Label Printer!");
            }

        }


    }
}
