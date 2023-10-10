using System;
using System.Timers;


    public class BarcodeScanner2
    {
        private string barcode;
        private readonly System.Timers.Timer timer = new System.Timers.Timer();

        public event EventHandler<BarcodeScannerEventArgs> BarcodeScanned;

        public BarcodeScanner2()
        {
            timer.Interval = 200; // Adjust the interval as needed
            barcode = "";
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false; // Fire the event only once per interval
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            barcode = "";
        }

        public void HandleKeyInput(char inputChar)
        {
            timer.Stop();

            if (inputChar == '\r') // Check for Enter key
            {
                if (!string.IsNullOrEmpty(barcode))
                {
                    BarcodeScanned?.Invoke(this, new BarcodeScannerEventArgs(barcode));
                }

                barcode = "";
            }
            else
            {
                barcode += inputChar;
                timer.Start();
            }
        }
    }
    public class BarcodeScannerEventArgs2 : EventArgs
    {
        public string Barcode { get; }

        public BarcodeScannerEventArgs2(string barcode)
        {
            Barcode = barcode;
        }
    }