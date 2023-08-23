﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USB_Barcode_Scanner;
using MySql.Data.MySqlClient;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System.Collections;
using Org.BouncyCastle.Utilities;

namespace USB_Barcode_Scanner_Tutorial___C_Sharp
{
    public partial class AddItemP1 : Form
    {
        public AddItemP1()
        {
            InitializeComponent();
        }

        private void BarcodeScanner_BarcodeScanned2(object sender, BarcodeScannerEventArgs e)
        {
            QRText.Text = "Retrieving barcode product data.";
            BarcodeText.Text = e.Barcode;
            AddItem2(e.Barcode);
        }
        private void AddItem2(string barcode)
        {
            AddItemP1 AddItemForm1 = MainMenu.initializedForms.Find(f => f is AddItemP1) as AddItemP1;
            AddItemP2 AddItemForm2 = MainMenu.initializedForms.Find(f => f is AddItemP2) as AddItemP2;
            if (AddItemForm2 != null)
            {
                AddItemForm1.Hide();
                AddItemForm2.Show();
                AddItemForm2.AssignBarcodeText(barcode);
            }
        }

        private void QRText_Click(object sender, EventArgs e)
        {

        }
        private void InitializeApplication()
        {
            //InitializeBarcode
            BarcodeScanner barcodeScanner = new BarcodeScanner(BarcodeText);
            barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned2;
            QRText.Text = "Please kindly scan barcode on your desired product.";
            BarcodeText.Text = "";
        }
        private void AddItemP1_Load(object sender, EventArgs e)
        {
            InitializeApplication();
        }

        private void BarcodeText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
