using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Printer_Console
{
    class Barcode
    {
        //user input info
        public string inputInfo = "";
        private string _printerName;
        //constructor
        public Barcode()
        {

        }

        //get information method
        public void GetInfo()
        {
            //first ask user input info
            Console.WriteLine("Please input:");
            inputInfo = Console.ReadLine();

            //then verify the user's input, if the user's input is not equal to 15 digits then ask the user input again.
            while (inputInfo.Length!=6)
            {
                Console.WriteLine("Incorrect length of bar-code, please try again:");
                inputInfo = Console.ReadLine();
            }
            
            //when the input info is correct then display the info and print the bar-code
            Console.WriteLine(inputInfo);

        }

        public void PrintBarcode()
        {
            //get the label printer name and verify the printer name
            Printer p = new Printer();
            this._printerName = p.printerName;
            if (this._printerName == "Brother QL-710W")
            {
                Console.WriteLine("The printer name: {0}", this._printerName);

                //print function
                #region
                //print doc object
                System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();


                myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
                //use the selected printer name
                myPrintDocument1.PrinterSettings.PrinterName = this._printerName;
                //set number of copies to print
                myPrintDocument1.PrinterSettings.Copies = 1;
                try
                {
                    myPrintDocument1.Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error:\n{0}",e);
                }
                #endregion

            }
            else
            {
                Console.WriteLine("No Label Printer!");
            }

        }

        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            //set font
            Font printFont = new Font("Code 3 de 9", 14);
            Font printFont2 = new Font("Arial", 6);
            Font printFont3 = new Font("Arial", 8);

            //set the bar-code width
            Matrix m = new Matrix();
            m.Scale(1.5F, 0.8F); //1.5times width than original width, 0.8 times height than original height

            //begin scale the bar-code width
            e.Graphics.Transform = m;
            e.Graphics.DrawString("*"+inputInfo+"*", printFont, Brushes.Black, 22, 2, new StringFormat());
            //reset the font to regular width
            e.Graphics.ResetTransform();
            e.Graphics.DrawString(inputInfo, printFont2, Brushes.Black, 5, 20, new StringFormat());
            e.Graphics.DrawString(inputInfo, printFont3, Brushes.Black, 80, 18, new StringFormat());
            e.Graphics.DrawString(DateTime.Now.ToString("MMM dd,yyyy"), printFont2, Brushes.Black, 175, 20, new StringFormat());


        }
    }
}
