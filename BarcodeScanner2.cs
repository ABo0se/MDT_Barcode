using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    internal class BarcodeScanner2
    {
        private string barcode;

        private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public event EventHandler<BarcodeScannerEventArgs> BarcodeScanned;

        public BarcodeScanner2(Control control)
        {
            timer.Interval = 20;
            barcode = "";
            timer.Tick += Timer_Tick;
            control.KeyDown += Control_KeyDown;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            barcode = "";
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            timer.Stop();
            if (e.KeyCode == Keys.Return)
            {
                if (barcode != "")
                {
                    this.BarcodeScanned?.Invoke(this, new BarcodeScannerEventArgs(barcode));
                }

                barcode = "";
                return;
            }

            if (e.KeyCode != Keys.ShiftKey)
            {
                int num = e.KeyValue;
                if (e.KeyData >= Keys.A && e.KeyData <= Keys.Z && !e.KeyData.HasFlag(Keys.Shift))
                {
                    num += 32;
                }

                barcode += (char)num;
            }

            timer.Start();
        }
    }
    public class BarcodeScannerEventArgs : EventArgs
    {
        public string Barcode { get; }

        public BarcodeScannerEventArgs(string barcode)
        {
            Barcode = barcode;
        }
    }
}