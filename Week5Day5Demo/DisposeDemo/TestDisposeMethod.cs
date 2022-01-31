using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Week5Day5Demo.DisposeDemo
{
    class ReceiptPrinter : IDisposable
    {
        public bool printerIsConnected { get; set; }

        public void ConnectToPrinter()
        {
            printerIsConnected = true;
            Console.WriteLine("Printer connecting...");
        }

        public void PrintReceipt()
        {
            throw new AccessViolationException("Oops Printer is off");
            Console.WriteLine("----- Bill-----");
            Console.WriteLine("Total Value: $100");
            Console.WriteLine("----- Bill-----");
        }

        public void DisconnectFromPrinter()
        {
            printerIsConnected = false;
            Console.WriteLine("Printer disconnected...");
        }

        public void Dispose()
        {
            DisconnectFromPrinter();
        }
    }

    internal class TestDisposeMethod
    {
        private const string path = @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\28-Jan-2022\Week5Day5Demo\Week5Day5Demo\DisposeDemo\files\Code.txt";

        public static void Demo()
        {
            using (var receiptPrinter = new ReceiptPrinter())
            {

                receiptPrinter.ConnectToPrinter();
                receiptPrinter.PrintReceipt();

                Console.WriteLine("************************");
            }

            Console.WriteLine("###############################");
        }

        public static void Demo2()
        {
            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        if (line != "")
                            Console.WriteLine(line);
                        else
                            Console.WriteLine(int.Parse(line));
                    }
                }

                Console.WriteLine("The file has been read and displayed on screen. Blank lines omitted. Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
